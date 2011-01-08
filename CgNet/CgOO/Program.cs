/*
 CgNet v1.0
 Copyright (c) 2010 Tobias Bohnen

 Permission is hereby granted, free of charge, to any person obtaining a copy of this
 software and associated documentation files (the "Software"), to deal in the Software
 without restriction, including without limitation the rights to use, copy, modify, merge,
 publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
 to whom the Software is furnished to do so, subject to the following conditions:

 The above copyright notice and this permission notice shall be included in all copies or
 substantial portions of the Software.

 THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
 INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
 PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
 FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
 OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
 DEALINGS IN THE SOFTWARE.
 */
namespace CgOO
{
    using System;
    using System.Collections.Generic;

    using CgNet;

    public sealed class Program : WrapperObject
    {
        #region Constructors

        internal Program(IntPtr handle)
            : base(handle)
        {
        }

        #endregion Constructors

        #region Properties

        #region Public Properties

        public IEnumerable<Annotation> Annotations
        {
            get
            {
                return Enumerate(() => this.FirstAnnotation, t => t.NextAnnotation);
            }
        }

        public Context Context
        {
            get
            {
                var ptr = Cg.GetProgramContext(this.Handle);
                return ptr == IntPtr.Zero ? null : new Context(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public int DomainsCount
        {
            get
            {
                return Cg.GetNumProgramDomains(this.Handle);
            }
        }

        public Annotation FirstAnnotation
        {
            get
            {
                var ptr = Cg.GetFirstProgramAnnotation(this.Handle);
                return ptr == IntPtr.Zero ? null : new Annotation(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public bool IsCompiled
        {
            get
            {
                return Cg.IsProgramCompiled(this.Handle);
            }
        }

        public bool IsProgram
        {
            get
            {
                return Cg.IsProgram(this.Handle);
            }
        }

        public Program NextProgram
        {
            get
            {
                var ptr = Cg.GetNextProgram(this.Handle);
                return ptr == IntPtr.Zero ? null : new Program(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public ProfileType Profile
        {
            get
            {
                return Cg.GetProgramProfile(this.Handle);
            }

            set
            {
                Cg.SetProgramProfile(this.Handle, value);
            }
        }

        public Domain ProgramDomain
        {
            get
            {
                return Cg.GetProgramDomain(this.Handle);
            }
        }

        public ProgramInput ProgramInput
        {
            get
            {
                return Cg.GetProgramInput(this.Handle);
            }
        }

        public string[] ProgramOptions
        {
            get
            {
                return Cg.GetProgramOptions(this.Handle);
            }
        }

        public ProgramOutput ProgramOutput
        {
            get
            {
                return Cg.GetProgramOutput(this.Handle);
            }
        }

        public ProgramType Type
        {
            get;
            internal set;
        }

        public int UserTypesCount
        {
            get
            {
                return Cg.GetNumUserTypes(this.Handle);
            }
        }

        #endregion Public Properties

        #endregion Properties

        #region Methods

        #region Public Static Methods

        public static Program CombinePrograms(params Program[] programs)
        {
            var buf = new IntPtr[programs.Length];
            for (int i = 0; i < programs.Length; i++)
            {
                buf[i] = programs[i].Handle;
            }

            var ptr = Cg.CombinePrograms(buf);
            return ptr == IntPtr.Zero ? null : new Program(ptr);
        }

        public static Program Create(Context context, ProgramType type, string source, ProfileType profile, string entry, params string[] args)
        {
            return context.CreateProgram(type, source, profile, entry, args);
        }

        public static Program CreateFromFile(Context context, ProgramType type, string file, ProfileType profile, string entry, params string[] args)
        {
            return context.CreateProgramFromFile(type, file, profile, entry, args);
        }

        #endregion Public Static Methods

        #region Public Methods

        public Program Combine(Program exe1)
        {
            var ptr = Cg.CombinePrograms(this.Handle, exe1.Handle);
            return ptr == IntPtr.Zero ? null : new Program(ptr);
        }

        public void Compile()
        {
            Cg.CompileProgram(this.Handle);
        }

        public Program Copy()
        {
            var ptr = Cg.CopyProgram(this.Handle);
            return ptr == IntPtr.Zero ? null : new Program(ptr);
        }

        public Annotation CreateAnnotation(string name, ParameterType type)
        {
            var ptr = Cg.CreateProgramAnnotation(this.Handle, name, type);
            return new Annotation(ptr);
        }

        public float[] EvaluateProgram(int ncomps, int nx, int ny, int nz)
        {
            return Cg.EvaluateProgram(this.Handle, ncomps, nx, ny, nz);
        }

        public Buffer GetBuffer(int bufferIndex)
        {
            var ptr = Cg.GetProgramBuffer(this.Handle, bufferIndex);
            return ptr == IntPtr.Zero ? null : new Buffer(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public Parameter GetFirstLeafParameter(int nameSpace)
        {
            var ptr = Cg.GetFirstLeafParameter(this.Handle, nameSpace);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public Parameter GetFirstParameter(int nameSpace)
        {
            var ptr = Cg.GetFirstParameter(this.Handle, nameSpace);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public Annotation GetNamedAnnotation(string name)
        {
            var ptr = Cg.GetNamedProgramAnnotation(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new Annotation(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public Parameter GetNamedParameter(ProgramNamespace nameSpace, string name)
        {
            var ptr = Cg.GetNamedProgramParameter(this.Handle, nameSpace, name);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public Parameter GetNamedParameter(string parameter)
        {
            var ptr = Cg.GetNamedParameter(this.Handle, parameter);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public ParameterType GetNamedUserType(string name)
        {
            return Cg.GetNamedUserType(this.Handle, name);
        }

        public ProfileType GetProgramDomainProfile(int index)
        {
            return Cg.GetProgramDomainProfile(this.Handle, index);
        }

        public Program GetProgramDomainProgram(int index)
        {
            var ptr = Cg.GetProgramDomainProgram(this.Handle, index);
            return ptr == IntPtr.Zero ? null : new Program(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public string GetProgramString(SourceType sourceType)
        {
            return Cg.GetProgramString(this.Handle, sourceType);
        }

        public ParameterType GetUserType(int index)
        {
            return Cg.GetUserType(this.Handle, index);
        }

        public void SetLastListing(string listing)
        {
            Cg.SetLastListing(this.Handle, listing);
        }

        public void SetPassProgramParameters()
        {
            Cg.SetPassProgramParameters(this.Handle);
        }

        public void SetProgramBuffer(int bufferIndex, Buffer buffer)
        {
            Cg.SetProgramBuffer(this.Handle, bufferIndex, buffer.Handle);
        }

        public void UpdateProgramParameters()
        {
            Cg.UpdateProgramParameters(this.Handle);
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        protected override void Dispose(bool disposing)
        {
            if (this.Handle != IntPtr.Zero)
            {
                Cg.DestroyProgram(this.Handle);
            }
        }

        #endregion Protected Methods

        #endregion Methods
    }
}