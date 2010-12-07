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
namespace CgNet.CgOO
{
    using System;

    using CgNet;

    public sealed class CgContext : WrapperObject
    {
        #region Constructors

        internal CgContext(IntPtr handle)
            : base(handle)
        {
        }

        #endregion Constructors

        #region Properties

        #region Public Properties

        public AutoCompileMode AutoCompileMode
        {
            get
            {
                return Cg.GetAutoCompile(this.Handle);
            }

            set
            {
                Cg.SetAutoCompile(this.Handle, value);
            }
        }

        public Behavior Behavior
        {
            get
            {
                return Cg.GetContextBehavior(this.Handle);
            }

            set
            {
                Cg.SetContextBehavior(this.Handle, value);
            }
        }

        public Cg.CgIncludeCallbackFunc CompilerIncludeCallback
        {
            get
            {
                return Cg.GetCompilerIncludeCallback(this.Handle);
            }

            set
            {
                Cg.SetCompilerIncludeCallback(this.Handle, value);
            }
        }

        public CgEffect FirstEffect
        {
            get
            {
                var ptr = Cg.GetFirstEffect(this.Handle);
                return ptr == IntPtr.Zero ? null : new CgEffect(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public CgProgram FirstProgram
        {
            get
            {
                var ptr = Cg.GetFirstProgram(this.Handle);

                return ptr == IntPtr.Zero ? null : new CgProgram(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public CgState FirstSamplerState
        {
            get
            {
                var ptr = Cg.GetFirstSamplerState(this.Handle);
                return ptr != IntPtr.Zero ? null : new CgState(ptr)
                                   {
                                       OwnsHandle = false
                                   };
            }
        }

        public CgState FirstState
        {
            get
            {
                var ptr = Cg.GetFirstState(this.Handle);
                return ptr == IntPtr.Zero ? null : new CgState(ptr)
                {
                    OwnsHandle = false
                };
            }
        }

        public bool IsContext
        {
            get
            {
                return Cg.IsContext(this.Handle);
            }
        }

        public ParameterSettingMode ParameterSettingMode
        {
            get
            {
                return Cg.GetParameterSettingMode(this.Handle);
            }

            set
            {
                Cg.SetParameterSettingMode(this.Handle, value);
            }
        }

        #endregion Public Properties

        #endregion Properties

        #region Methods

        #region Public Static Methods

        public static CgContext Create()
        {
            return new CgContext(Cg.CreateContext());
        }

        #endregion Public Static Methods

        #region Public Methods

        public CgBuffer CreateBuffer(int size, IntPtr data, BufferUsage bufferUsage)
        {
            return new CgBuffer(Cg.CreateBuffer(this.Handle, size, data, bufferUsage));
        }

        public CgEffect CreateEffect(string code, params string[] args)
        {
            return new CgEffect(Cg.CreateEffect(this.Handle, code, args));
        }

        public CgEffect CreateEffectFromFile(string filename, params string[] args)
        {
            return new CgEffect(Cg.CreateEffectFromFile(this.Handle, filename, args));
        }

        public CgProgram CreateProgram(ProgramType type, string source, ProfileType profile, string entry, params string[] args)
        {
            return new CgProgram(Cg.CreateProgram(this.Handle, type, source, profile, entry, args))
                   {
                       Type = type,
                   };
        }

        public CgProgram CreateProgramFromFile(ProgramType type, string file, ProfileType profile, string entry, params string[] args)
        {
            return new CgProgram(Cg.CreateProgramFromFile(this.Handle, type, file, profile, entry, args))
                   {
                       Type = type,
                   };
        }

        public CgState CreateState(string name, ParameterType type)
        {
            return new CgState(Cg.CreateState(this.Handle, name, type));
        }

        public string GetLastListing()
        {
            return Cg.GetLastListing(this.Handle);
        }

        public CgEffect GetNamedEffect(string name)
        {
            var ptr = Cg.GetNamedEffect(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new CgEffect(ptr);
        }

        public CgState GetNamedSamplerState(string name)
        {
            return new CgState(Cg.GetNamedSamplerState(this.Handle, name));
        }

        public CgState GetNamedState(string name)
        {
            return new CgState(Cg.GetNamedState(this.Handle, name));
        }

        public void SetCompilerIncludeFile(string name, string filename)
        {
            Cg.SetCompilerIncludeFile(this.Handle, name, filename);
        }

        public void SetCompilerIncludeString(string name, string source)
        {
            Cg.SetCompilerIncludeString(this.Handle, name, source);
        }

        #endregion Public Methods

        #region Protected Methods

        protected override void Dispose(bool disposing)
        {
            if (this.Handle != IntPtr.Zero)
            {
                Cg.DestroyContext(this.Handle);
            }
        }

        #endregion Protected Methods

        #endregion Methods
    }
}