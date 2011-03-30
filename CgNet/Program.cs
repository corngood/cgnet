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
namespace CgNet
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

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
                var ptr = CgNativeMethods.cgGetProgramContext(this.Handle);
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
                return CgNativeMethods.cgGetNumProgramDomains(this.Handle);
            }
        }

        public Annotation FirstAnnotation
        {
            get
            {
                var ptr = CgNativeMethods.cgGetFirstProgramAnnotation(this.Handle);
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
                return CgNativeMethods.cgIsProgramCompiled(this.Handle);
            }
        }

        public bool IsProgram
        {
            get
            {
                return CgNativeMethods.cgIsProgram(this.Handle);
            }
        }

        public Program NextProgram
        {
            get
            {
                var ptr = CgNativeMethods.cgGetNextProgram(this.Handle);
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
                return CgNativeMethods.cgGetProgramProfile(this.Handle);
            }

            set
            {
                CgNativeMethods.cgSetProgramProfile(this.Handle, value);
            }
        }

        public Domain ProgramDomain
        {
            get
            {
                return CgNativeMethods.cgGetProgramDomain(this.Handle);
            }
        }

        public ProgramInput ProgramInput
        {
            get
            {
                return CgNativeMethods.cgGetProgramInput(this.Handle);
            }
        }

        public string[] ProgramOptions
        {
            get
            {
                return Cg.IntPtrToStringArray(CgNativeMethods.cgGetProgramOptions(this.Handle));
            }
        }

        public ProgramOutput ProgramOutput
        {
            get
            {
                return CgNativeMethods.cgGetProgramOutput(this.Handle);
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
                return CgNativeMethods.cgGetNumUserTypes(this.Handle);
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

            var ptr = CgNativeMethods.cgCombinePrograms(buf.Length, buf);
            return ptr == IntPtr.Zero ? null : new Program(ptr);
        }

        public static Program Create(Context context, ProgramType type, string source, ProfileType profile, string entry, params string[] args)
        {
            return context.CreateProgram(type, source, profile, entry, args);
        }

        public static Program CreateFromEffect(Effect effect, ProfileType profile, string entry, params string[] args)
        {
            return effect.CreateProgram(profile, entry, args);
        }

        public static Program CreateFromFile(Context context, ProgramType type, string file, ProfileType profile, string entry, params string[] args)
        {
            return context.CreateProgramFromFile(type, file, profile, entry, args);
        }

        #endregion Public Static Methods

        #region Public Methods

        public Program Combine(Program exe1)
        {
            var ptr = CgNativeMethods.cgCombinePrograms2(this.Handle, exe1.Handle);
            return ptr == IntPtr.Zero ? null : new Program(ptr);
        }

        public void Compile()
        {
            CgNativeMethods.cgCompileProgram(this.Handle);
        }

        public Program Copy()
        {
            var ptr = CgNativeMethods.cgCopyProgram(this.Handle);
            return ptr == IntPtr.Zero ? null : new Program(ptr);
        }

        public Annotation CreateAnnotation(string name, ParameterType type)
        {
            var ptr = CgNativeMethods.cgCreateProgramAnnotation(this.Handle, name, type);
            return new Annotation(ptr);
        }

        public float[] EvaluateProgram(int ncomps, int nx, int ny, int nz)
        {
            var retValue = new float[ncomps * nx * ny * nz];
            CgNativeMethods.cgEvaluateProgram(this.Handle, retValue, ncomps, nx, ny, nz);
            return retValue;
        }

        public Buffer GetBuffer(int bufferIndex)
        {
            var ptr = CgNativeMethods.cgGetProgramBuffer(this.Handle, bufferIndex);
            return ptr == IntPtr.Zero ? null : new Buffer(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public Parameter GetFirstLeafParameter(NameSpace nameSpace)
        {
            var ptr = CgNativeMethods.cgGetFirstLeafParameter(this.Handle, nameSpace);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public Parameter GetFirstParameter(NameSpace nameSpace)
        {
            var ptr = CgNativeMethods.cgGetFirstParameter(this.Handle, nameSpace);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public Annotation GetNamedAnnotation(string name)
        {
            var ptr = CgNativeMethods.cgGetNamedProgramAnnotation(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new Annotation(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public Parameter GetNamedParameter(NameSpace nameSpace, string name)
        {
            var ptr = CgNativeMethods.cgGetNamedProgramParameter(this.Handle, nameSpace, name);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public Parameter GetNamedParameter(string parameter)
        {
            var ptr = CgNativeMethods.cgGetNamedParameter(this.Handle, parameter);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public ParameterType GetNamedUserType(string name)
        {
            return CgNativeMethods.cgGetNamedUserType(this.Handle, name);
        }

        public ProfileType GetProgramDomainProfile(int index)
        {
            return CgNativeMethods.cgGetProgramDomainProfile(this.Handle, index);
        }

        public Program GetProgramDomainProgram(int index)
        {
            var ptr = CgNativeMethods.cgGetProgramDomainProgram(this.Handle, index);
            return ptr == IntPtr.Zero ? null : new Program(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public string GetProgramString(SourceType sourceType)
        {
            return Marshal.PtrToStringAnsi(CgNativeMethods.cgGetProgramString(this.Handle, sourceType));
        }

        public ParameterType GetUserType(int index)
        {
            return CgNativeMethods.cgGetUserType(this.Handle, index);
        }

        public void SetLastListing(string listing)
        {
            CgNativeMethods.cgSetLastListing(this.Handle, listing);
        }

        public void SetPassProgramParameters()
        {
            CgNativeMethods.cgSetPassProgramParameters(this.Handle);
        }

        public void SetProgramBuffer(int bufferIndex, Buffer buffer)
        {
            CgNativeMethods.cgSetProgramBuffer(this.Handle, bufferIndex, buffer.Handle);
        }

        public void UpdateParameters()
        {
            CgNativeMethods.cgUpdateProgramParameters(this.Handle);
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
                CgNativeMethods.cgDestroyProgram(this.Handle);
            }
        }

        #endregion Protected Methods

        #endregion Methods
    }
}