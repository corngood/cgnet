namespace CgToCode
{
    using System;
    using System.CodeDom;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Reflection;

    using CgNet;

    using Microsoft.CSharp;
    using Microsoft.VisualBasic;

    public sealed class Converter : IDisposable
    {
        #region Fields

        private readonly Context context;
        private readonly CodeDomProvider provider;

        #endregion Fields

        #region Constructors

        public Converter()
        {
            this.context = Context.Create();
            this.provider = new CSharpCodeProvider();
        }

        #endregion Constructors

        #region Methods

        #region Public Methods

        public void Convert(string file, string entrypoint, ProfileType profile, string className, string namespaceName, string destFolder)
        {
            var programText = File.ReadAllText(file);

            var program = context.CreateProgram(ProgramType.Source, programText, profile, entrypoint, null);
            var text = this.GenerateCode(program, className, namespaceName);
            program.Dispose();

            using (var sw = new StreamWriter(Path.Combine(destFolder, className + "." + provider.FileExtension)))
            {
                sw.Write(text);
                sw.Flush();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            this.context.Dispose();
        }

        #endregion Public Methods

        #region Private Static Methods

        private static CodeConstructor CreateConstructor(CodeTypeDeclaration codeTypeDeclaration)
        {
            var codeConstructor = new CodeConstructor
                                  {
                                      Attributes = MemberAttributes.Public
                                  };

            // 'context' parameter
            codeConstructor.Parameters.Add(new CodeParameterDeclarationExpression(new CodeTypeReference("Context"), "context"));

            codeTypeDeclaration.Members.Add(codeConstructor);
            return codeConstructor;
        }

        private static void CreateFields(CodeTypeDeclaration codeTypeDeclaration, CodeConstructor codeConstructor, CgNet.Program program)
        {
            string programProfile = program.Profile.ToString();
            string programString = program.GetProgramString(SourceType.CompiledProgram);
            string programEntry = program.GetProgramString(SourceType.ProgramEntry);

            // 'program' field
            var programField = new CodeMemberField("Program", "program");
            codeTypeDeclaration.Members.Add(programField);
            var programExp = new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "program");

            // 'programSource' field
            var programSourceField = new CodeMemberField(typeof(string), "programSource");
            codeTypeDeclaration.Members.Add(programSourceField);
            var programSourceExp = new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "programSource");

            // assign 'programSource'
            codeConstructor.Statements.Add(
                new CodeAssignStatement(programSourceExp, new CodePrimitiveExpression(programString)));

            // assing 'program'
            codeConstructor.Statements.Add(
                new CodeAssignStatement(programExp,
                                        new CodeMethodInvokeExpression(
                                            new CodeVariableReferenceExpression("context"),
                                            "CreateProgram",
                                            new CodeTypeReferenceExpression("ProgramType.Object"),
                                            programSourceExp,
                                            new CodeMethodReferenceExpression(new CodeTypeReferenceExpression("ProfileType"), programProfile),
                                            new CodePrimitiveExpression(programEntry),
                                            new CodePrimitiveExpression(null))));

            // load program
            codeConstructor.Statements.Add(new CodeMethodInvokeExpression(programExp, "Load"));
        }

        private static void CreateMethods(CodeTypeDeclaration codeTypeDeclaration, string programProfile)
        {
            var programExp = new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "program");

            // 'Dispose' method
            var dispose = new CodeMemberMethod
                          {
                              Name = "Dispose",
                              Attributes = MemberAttributes.Public | MemberAttributes.Final
                          };
            dispose.Statements.Add(new CodeMethodInvokeExpression(programExp, "Dispose"));
            dispose.Statements.Add(new CodeMethodInvokeExpression(new CodeTypeReferenceExpression("GC"), "SuppressFinalize", new CodeThisReferenceExpression()));
            codeTypeDeclaration.Members.Add(dispose);

            // 'Bind' method
            var bind = new CodeMemberMethod
                       {
                           Name = "Bind",
                           Attributes = MemberAttributes.Public | MemberAttributes.Final
                       };
            bind.Statements.Add(new CodeMethodInvokeExpression(programExp, "Bind"));
            codeTypeDeclaration.Members.Add(bind);

            // 'EnableProfile' method
            var enableProfile = new CodeMemberMethod
                                {
                                    Name = "EnableProfile",
                                    Attributes = MemberAttributes.Public | MemberAttributes.Final
                                };
            enableProfile.Statements.Add(new CodeMethodInvokeExpression(new CodeTypeReferenceExpression("CgGL"), "EnableProfile", new CodeMethodReferenceExpression(new CodeTypeReferenceExpression("ProfileType"), programProfile)));
            codeTypeDeclaration.Members.Add(enableProfile);

            // 'DisableProfile' method
            var disableProfile = new CodeMemberMethod
                                 {
                                     Name = "DisableProfile",
                                     Attributes = MemberAttributes.Public | MemberAttributes.Final
                                 };
            disableProfile.Statements.Add(new CodeMethodInvokeExpression(new CodeTypeReferenceExpression("CgGL"), "DisableProfile", new CodeMethodReferenceExpression(new CodeTypeReferenceExpression("ProfileType"), programProfile)));
            codeTypeDeclaration.Members.Add(disableProfile);
        }

        private static void CreateNameSpaces(CodeCompileUnit codeCompileUnit, string namespaceName)
        {
            var codeNamespace = new CodeNamespace(namespaceName);
            codeNamespace.Imports.AddRange(new[] { new CodeNamespaceImport("System"), new CodeNamespaceImport("CgNet"), new CodeNamespaceImport("CgNet.GL") });
            codeCompileUnit.Namespaces.Add(codeNamespace);
        }

        private static void CreateProperties(CodeTypeDeclaration codeTypeDeclaration, CodeMemberMethod codeConstructor, IEnumerable<ParameterDef> paras)
        {
            var programExp = new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "program");
            foreach (var para in paras)
            {
                var propertyType = new CodeTypeReference(para.Type);
                var property = new CodeMemberProperty
                               {
                                   Type = propertyType,
                                   Name = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(para.Name),
                                   Attributes = MemberAttributes.Public | MemberAttributes.Final
                               };

                // creating backing field
                var field = new CodeMemberField("Parameter", para.Name);
                codeTypeDeclaration.Members.Add(field);
                var fieldExp = new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), para.Name);

                // assign backing field in constructor
                var fieldAssign = new CodeAssignStatement(
                    fieldExp,
                    new CodeMethodInvokeExpression(
                        programExp,
                        "GetNamedParameter",
                        new CodePrimitiveExpression(para.Name)));
                codeConstructor.Statements.Add(fieldAssign);

                // Getter
                CodeStatement getValueExp;
                if (para.IsArray)
                {
                    property.GetStatements.Add(
                        new CodeVariableDeclarationStatement(propertyType, "buffer",
                                                             new CodeArrayCreateExpression(propertyType, para.ArraySize)));

                    var methodCall = new CodeMethodInvokeExpression(
                        fieldExp,
                        "GetValue",
                        new CodeDirectionExpression(FieldDirection.Ref, new CodeVariableReferenceExpression("buffer")));

                    property.GetStatements.Add(methodCall);

                    getValueExp = new CodeMethodReturnStatement(new CodeVariableReferenceExpression("buffer"));
                }
                else
                {
                    getValueExp = new CodeMethodReturnStatement(
                        new CodeMethodInvokeExpression(
                            new CodeMethodReferenceExpression(
                                fieldExp,
                                "GetValue",
                                new[]
                                {
                                    propertyType
                                })));
                }

                property.GetStatements.Add(getValueExp);

                // Setter
                CodeMethodInvokeExpression setValueExp;
                if (para.IsArray)
                {
                    setValueExp = new CodeMethodInvokeExpression(
                        fieldExp,
                        "SetValue",
                        new CodeVariableReferenceExpression("value"));
                }
                else
                {
                    setValueExp = new CodeMethodInvokeExpression(
                        fieldExp,
                        "Set",
                        new CodeVariableReferenceExpression("value"));
                }

                property.SetStatements.Add(setValueExp);

                codeTypeDeclaration.Members.Add(property);
            }
        }

        private static CodeTypeDeclaration CreateType(CodeCompileUnit codeCompileUnit, string className)
        {
            var codeTypeDeclaration = new CodeTypeDeclaration(className)
                                      {
                                          TypeAttributes = TypeAttributes.Sealed
                                      };
            codeTypeDeclaration.BaseTypes.Add(new CodeTypeReference("IDisposable"));
            codeCompileUnit.Namespaces[0].Types.Add(codeTypeDeclaration);
            return codeTypeDeclaration;
        }

        private static IEnumerable<ParameterDef> GetParameters(CgNet.Program program)
        {
            var retValue = new List<ParameterDef>();

            var para = program.GetFirstParameter(NameSpace.Program);
            while (para != null)
            {
                if (para.Variability == Variability.Uniform)
                {
                    bool isArray = false;
                    int arraySize = 0;
                    var type = para.Type;
                    Type clrType = null;

                    if (type == ParameterType.Array)
                    {
                        isArray = true;
                        type = para.BaseType;
                        arraySize = para.Rows * para.Columns;
                        var totalSize = para.GetArrayTotalSize();
                        if (totalSize > 0)
                        {
                            arraySize *= totalSize;
                        }
                    }

                    switch (type)
                    {
                        case ParameterType.Float:
                            clrType = isArray ? typeof(float[]) : typeof(float);
                            break;
                        case ParameterType.Double:
                            clrType = isArray ? typeof(double[]) : typeof(double);
                            break;
                        case ParameterType.Int:
                            clrType = isArray ? typeof(int[]) : typeof(int);
                            break;
                    }

                    retValue.Add(new ParameterDef
                                 {
                                     Name = para.Name,
                                     Type = clrType,
                                     IsArray = isArray,
                                     ArraySize = arraySize,
                                 });
                }

                para = para.NextParameter;
            }

            return retValue;
        }

        #endregion Private Static Methods

        #region Private Methods

        private string GenerateCode(CgNet.Program program, string className, string namespaceName)
        {
            var codeCompileUnit = new CodeCompileUnit();

            CreateNameSpaces(codeCompileUnit, namespaceName);
            var codeTypeDeclaration = CreateType(codeCompileUnit, className);
            var codeConstructor = CreateConstructor(codeTypeDeclaration);
            CreateFields(codeTypeDeclaration, codeConstructor, program);
            CreateProperties(codeTypeDeclaration, codeConstructor, GetParameters(program));
            CreateMethods(codeTypeDeclaration, program.Profile.ToString());

            using (var tw = new StringWriter())
            {
                var codeGeneratorOptions = new CodeGeneratorOptions
                {
                    BracingStyle = "C"
                };

                this.provider.GenerateCodeFromCompileUnit(codeCompileUnit, tw, codeGeneratorOptions);
                tw.Flush();
                return tw.ToString();
            }
        }

        #endregion Private Methods

        #endregion Methods

        #region Nested Types

        private sealed class ParameterDef
        {
            #region Properties

            #region Public Properties

            public int ArraySize
            {
                get;
                set;
            }

            public bool IsArray
            {
                get;
                set;
            }

            public string Name
            {
                get;
                set;
            }

            public Type Type
            {
                get;
                set;
            }

            #endregion Public Properties

            #endregion Properties
        }

        #endregion Nested Types
    }
}