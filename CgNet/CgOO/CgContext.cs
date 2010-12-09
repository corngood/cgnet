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

        public IEnumerable<CgEffect> Effects
        {
            get
            {
                return Enumerate(() => this.FirstEffect, t => t.NextEffect);
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
                return ptr == IntPtr.Zero ? null : new CgState(ptr)
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

        public IEnumerable<CgProgram> Programs
        {
            get
            {
                return Enumerate(() => this.FirstProgram, t => t.NextProgram);
            }
        }

        public IEnumerable<CgState> States
        {
            get
            {
                return Enumerate(() => this.FirstState, t => t.NextState);
            }
        }

        #endregion Public Properties

        #endregion Properties

        #region Methods

        #region Public Static Methods

        public static CgContext Create()
        {
            var ptr = Cg.CreateContext();
            return ptr == IntPtr.Zero ? null : new CgContext(ptr);
        }

        #endregion Public Static Methods

        #region Public Methods

        public CgState CreateArraySamplerState(string name, ParameterType type, int elementCount)
        {
            var ptr = Cg.CreateArraySamplerState(this.Handle, name, type, elementCount);
            return ptr == IntPtr.Zero ? null : new CgState(ptr);
        }

        public CgState CreateArrayState(string name, ParameterType type, int elementCount)
        {
            var ptr = Cg.CreateArrayState(this.Handle, name, type, elementCount);
            return ptr == IntPtr.Zero ? null : new CgState(ptr);
        }

        public CgBuffer CreateBuffer(int size, IntPtr data, BufferUsage bufferUsage)
        {
            var ptr = Cg.CreateBuffer(this.Handle, size, data, bufferUsage);
            return ptr == IntPtr.Zero ? null : new CgBuffer(ptr);
        }

        public CgEffect CreateEffect(string code, params string[] args)
        {
            var ptr = Cg.CreateEffect(this.Handle, code, args);
            return ptr == IntPtr.Zero ? null : new CgEffect(ptr);
        }

        public CgEffect CreateEffectFromFile(string filename, params string[] args)
        {
            var ptr = Cg.CreateEffectFromFile(this.Handle, filename, args);
            return ptr == IntPtr.Zero ? null : new CgEffect(ptr);
        }

        public CgParameter CreateEffectParameter(string name, ParameterType type)
        {
            var ptr = Cg.CreateEffectParameter(this.Handle, name, type);
            return ptr == IntPtr.Zero ? null : new CgParameter(ptr);
        }

        public CgObj CreateObj(ProgramType programType, string source, ProfileType profile, params string[] args)
        {
            var ptr = Cg.CreateObj(this.Handle, programType, source, profile, args);
            return ptr == IntPtr.Zero ? null : new CgObj(ptr);
        }

        public CgObj CreateObjFromFile(ProgramType programType, string sourceFile, ProfileType profile, params string[] args)
        {
            var ptr = Cg.CreateObjFromFile(this.Handle, programType, sourceFile, profile, args);
            return ptr == IntPtr.Zero ? null : new CgObj(ptr);
        }

        public CgParameter CreateParameter(ParameterType type)
        {
            var ptr = Cg.CreateParameter(this.Handle, type);
            return ptr == IntPtr.Zero ? null : new CgParameter(ptr);
        }

        public CgParameter CreateParameterArray(ParameterType type, int length)
        {
            var ptr = Cg.CreateParameterArray(this.Handle, type, length);
            return ptr == IntPtr.Zero ? null : new CgParameter(ptr);
        }

        public CgParameter CreateParameterMultiDimArray(ParameterType type, int dim, int[] lengths)
        {
            var ptr = Cg.CreateParameterMultiDimArray(this.Handle, type, dim, lengths);
            return ptr == IntPtr.Zero ? null : new CgParameter(ptr);
        }

        public CgProgram CreateProgram(ProgramType type, string source, ProfileType profile, string entry, params string[] args)
        {
            var ptr = Cg.CreateProgram(this.Handle, type, source, profile, entry, args);
            return ptr == IntPtr.Zero ? null : new CgProgram(ptr)
                   {
                       Type = type,
                   };
        }

        public CgProgram CreateProgramFromFile(ProgramType type, string file, ProfileType profile, string entry, params string[] args)
        {
            var ptr = Cg.CreateProgramFromFile(this.Handle, type, file, profile, entry, args);
            return ptr == IntPtr.Zero ? null : new CgProgram(ptr)
            {
                Type = type,
            };
        }

        public CgState CreateSamplerState(string name, ParameterType type)
        {
            var ptr = Cg.CreateSamplerState(this.Handle, name, type);
            return ptr == IntPtr.Zero ? null : new CgState(ptr);
        }

        public CgState CreateState(string name, ParameterType type)
        {
            var ptr = Cg.CreateState(this.Handle, name, type);
            return ptr == IntPtr.Zero ? null : new CgState(ptr);
        }

        public string GetLastListing()
        {
            return Cg.GetLastListing(this.Handle);
        }

        public CgEffect GetNamedEffect(string name)
        {
            var ptr = Cg.GetNamedEffect(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new CgEffect(ptr) { OwnsHandle = false };
        }

        public CgState GetNamedSamplerState(string name)
        {
            var ptr = Cg.GetNamedSamplerState(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new CgState(ptr) { OwnsHandle = false };
        }

        public CgState GetNamedState(string name)
        {
            var ptr = Cg.GetNamedState(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new CgState(ptr) { OwnsHandle = false };
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