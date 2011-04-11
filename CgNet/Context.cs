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

    public sealed class Context : WrapperObject
    {
        #region Fields

        private static readonly object PadLock = new object();

        #endregion Fields

        #region Constructors

        internal Context(IntPtr handle)
            : base(handle)
        {
        }

        #endregion Constructors

        #region Events

        public event EventHandler<CompilerIncludeEventArgs> CompilerInclude
        {
            add
            {
                lock (PadLock)
                {
                    if (this.compilerInclude == null)
                    {
                        CgNativeMethods.cgSetCompilerIncludeCallback(this.Handle, this.OnInclude);
                    }

                    this.compilerInclude += value;
                }
            }

            remove
            {
                lock (PadLock)
                {
                    this.compilerInclude -= value;

                    if (this.compilerInclude == null)
                    {
                        CgNativeMethods.cgSetCompilerIncludeCallback(this.Handle, null);
                    }
                }
            }
        }

        private event EventHandler<CompilerIncludeEventArgs> compilerInclude;

        #endregion Events

        #region Properties

        #region Public Properties

        public AutoCompileMode AutoCompileMode
        {
            get
            {
                return CgNativeMethods.cgGetAutoCompile(this.Handle);
            }

            set
            {
                CgNativeMethods.cgSetAutoCompile(this.Handle, value);
            }
        }

        public Behavior Behavior
        {
            get
            {
                return CgNativeMethods.cgGetContextBehavior(this.Handle);
            }

            set
            {
                CgNativeMethods.cgSetContextBehavior(this.Handle, value);
            }
        }

        public IEnumerable<Effect> Effects
        {
            get
            {
                return Enumerate(() => this.FirstEffect, t => t.NextEffect);
            }
        }

        public Effect FirstEffect
        {
            get
            {
                var ptr = CgNativeMethods.cgGetFirstEffect(this.Handle);
                return ptr == IntPtr.Zero ? null : new Effect(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public Program FirstProgram
        {
            get
            {
                var ptr = CgNativeMethods.cgGetFirstProgram(this.Handle);
                return ptr == IntPtr.Zero ? null : new Program(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public State FirstSamplerState
        {
            get
            {
                var ptr = CgNativeMethods.cgGetFirstSamplerState(this.Handle);
                return ptr == IntPtr.Zero ? null : new State(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public State FirstState
        {
            get
            {
                var ptr = CgNativeMethods.cgGetFirstState(this.Handle);
                return ptr == IntPtr.Zero ? null : new State(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public bool IsContext
        {
            get
            {
                return CgNativeMethods.cgIsContext(this.Handle);
            }
        }

        public string LastListing
        {
            get
            {
                return Marshal.PtrToStringAnsi(CgNativeMethods.cgGetLastListing(this.Handle));
            }

            set
            {
                CgNativeMethods.cgSetLastListing(this.Handle, value);
            }
        }

        public ParameterSettingMode ParameterSettingMode
        {
            get
            {
                return CgNativeMethods.cgGetParameterSettingMode(this.Handle);
            }

            set
            {
                CgNativeMethods.cgSetParameterSettingMode(this.Handle, value);
            }
        }

        public IEnumerable<Program> Programs
        {
            get
            {
                return Enumerate(() => this.FirstProgram, t => t.NextProgram);
            }
        }

        public IEnumerable<State> States
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

        public static Context Create()
        {
            var ptr = CgNativeMethods.cgCreateContext();
            return ptr == IntPtr.Zero ? null : new Context(ptr);
        }

        #endregion Public Static Methods

        #region Public Methods

        /// <summary>
        /// Create an array-typed sampler state definition.
        /// </summary>
        /// <param name="name">The name of the new sampler state.</param>
        /// <param name="type">The type of the new sampler state.</param>
        /// <param name="elementCount">The number of elements in the array.</param>
        /// <returns>Returns the newly created State.</returns>
        public State CreateArraySamplerState(string name, ParameterType type, int elementCount)
        {
            var ptr = CgNativeMethods.cgCreateArraySamplerState(this.Handle, name, type, elementCount);
            return ptr == IntPtr.Zero ? null : new State(ptr);
        }

        public State CreateArrayState(string name, ParameterType type, int elementCount)
        {
            var ptr = CgNativeMethods.cgCreateArrayState(this.Handle, name, type, elementCount);
            return ptr == IntPtr.Zero ? null : new State(ptr);
        }

        public Buffer CreateBuffer(int size, IntPtr data, BufferUsage bufferUsage)
        {
            var ptr = CgNativeMethods.cgCreateBuffer(this.Handle, size, data, bufferUsage);
            return ptr == IntPtr.Zero ? null : new Buffer(ptr);
        }

        public Effect CreateEffect(string code, params string[] args)
        {
            var ptr = CgNativeMethods.cgCreateEffect(this.Handle, code, args);
            return ptr == IntPtr.Zero ? null : new Effect(ptr);
        }

        public Effect CreateEffectFromFile(string filename, params string[] args)
        {
            var ptr = CgNativeMethods.cgCreateEffectFromFile(this.Handle, filename, args);
            return ptr == IntPtr.Zero ? null : new Effect(ptr);
        }

        public Parameter CreateEffectParameter(string name, ParameterType type)
        {
            var ptr = CgNativeMethods.cgCreateEffectParameter(this.Handle, name, type);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr);
        }

        public Obj CreateObj(ProgramType programType, string source, ProfileType profile, params string[] args)
        {
            var ptr = CgNativeMethods.cgCreateObj(this.Handle, programType, source, profile, args);
            return ptr == IntPtr.Zero ? null : new Obj(ptr);
        }

        public Obj CreateObjFromFile(ProgramType programType, string sourceFile, ProfileType profile, params string[] args)
        {
            var ptr = CgNativeMethods.cgCreateObjFromFile(this.Handle, programType, sourceFile, profile, args);
            return ptr == IntPtr.Zero ? null : new Obj(ptr);
        }

        public Parameter CreateParameter(ParameterType type)
        {
            var ptr = CgNativeMethods.cgCreateParameter(this.Handle, type);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr);
        }

        public Parameter CreateParameterArray(ParameterType type, int length)
        {
            var ptr = CgNativeMethods.cgCreateParameterArray(this.Handle, type, length);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr);
        }

        public Parameter CreateParameterMultiDimArray(ParameterType type, int dim, int[] lengths)
        {
            var ptr = CgNativeMethods.cgCreateParameterMultiDimArray(this.Handle, type, dim, lengths);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr);
        }

        public Program CreateProgram(ProgramType type, string source, ProfileType profile, string entry, params string[] args)
        {
            var ptr = CgNativeMethods.cgCreateProgram(this.Handle, type, source, profile, entry, args);
            return ptr == IntPtr.Zero ? null : new Program(ptr)
                                               {
                                                   Type = type,
                                               };
        }

        public Program CreateProgramFromFile(ProgramType type, string file, ProfileType profile, string entry, params string[] args)
        {
            var ptr = CgNativeMethods.cgCreateProgramFromFile(this.Handle, type, file, profile, entry, args);
            return ptr == IntPtr.Zero ? null : new Program(ptr)
                                               {
                                                   Type = type,
                                               };
        }

        public State CreateSamplerState(string name, ParameterType type)
        {
            var ptr = CgNativeMethods.cgCreateSamplerState(this.Handle, name, type);
            return ptr == IntPtr.Zero ? null : new State(ptr);
        }

        public State CreateState(string name, ParameterType type)
        {
            var ptr = CgNativeMethods.cgCreateState(this.Handle, name, type);
            return ptr == IntPtr.Zero ? null : new State(ptr);
        }

        public Effect GetNamedEffect(string name)
        {
            var ptr = CgNativeMethods.cgGetNamedEffect(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new Effect(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public State GetNamedSamplerState(string name)
        {
            var ptr = CgNativeMethods.cgGetNamedSamplerState(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new State(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public State GetNamedState(string name)
        {
            var ptr = CgNativeMethods.cgGetNamedState(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new State(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public void SetCompilerIncludeFile(string name, string filename)
        {
            CgNativeMethods.cgSetCompilerIncludeFile(this.Handle, name, filename);
        }

        public void SetCompilerIncludeString(string name, string source)
        {
            CgNativeMethods.cgSetCompilerIncludeString(this.Handle, name, source);
        }

        #endregion Public Methods

        #region Protected Methods

        protected override void Dispose(bool disposing)
        {
            if (this.OwnsHandle && this.Handle != IntPtr.Zero && this.IsContext)
            {
                CgNativeMethods.cgDestroyContext(this.Handle);
            }
        }

        #endregion Protected Methods

        #region Private Methods

        private void OnInclude(IntPtr context, string filename)
        {
            if (this.compilerInclude != null && this.Handle == context)
            {
                this.compilerInclude(this, new CompilerIncludeEventArgs(filename));
            }
        }

        #endregion Private Methods

        #endregion Methods
    }
}