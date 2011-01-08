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

    public sealed class Context : WrapperObject
    {
        #region Constructors

        internal Context(IntPtr handle)
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
                var ptr = Cg.GetFirstEffect(this.Handle);
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
                var ptr = Cg.GetFirstProgram(this.Handle);

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
                var ptr = Cg.GetFirstSamplerState(this.Handle);
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
                var ptr = Cg.GetFirstState(this.Handle);
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
            var ptr = Cg.CreateContext();
            return ptr == IntPtr.Zero ? null : new Context(ptr);
        }

        #endregion Public Static Methods

        #region Public Methods

        public State CreateArraySamplerState(string name, ParameterType type, int elementCount)
        {
            var ptr = Cg.CreateArraySamplerState(this.Handle, name, type, elementCount);
            return ptr == IntPtr.Zero ? null : new State(ptr);
        }

        public State CreateArrayState(string name, ParameterType type, int elementCount)
        {
            var ptr = Cg.CreateArrayState(this.Handle, name, type, elementCount);
            return ptr == IntPtr.Zero ? null : new State(ptr);
        }

        public Buffer CreateBuffer(int size, IntPtr data, BufferUsage bufferUsage)
        {
            var ptr = Cg.CreateBuffer(this.Handle, size, data, bufferUsage);
            return ptr == IntPtr.Zero ? null : new Buffer(ptr);
        }

        public Effect CreateEffect(string code, params string[] args)
        {
            var ptr = Cg.CreateEffect(this.Handle, code, args);
            return ptr == IntPtr.Zero ? null : new Effect(ptr);
        }

        public Effect CreateEffectFromFile(string filename, params string[] args)
        {
            var ptr = Cg.CreateEffectFromFile(this.Handle, filename, args);
            return ptr == IntPtr.Zero ? null : new Effect(ptr);
        }

        public Parameter CreateEffectParameter(string name, ParameterType type)
        {
            var ptr = Cg.CreateEffectParameter(this.Handle, name, type);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr);
        }

        public Obj CreateObj(ProgramType programType, string source, ProfileType profile, params string[] args)
        {
            var ptr = Cg.CreateObj(this.Handle, programType, source, profile, args);
            return ptr == IntPtr.Zero ? null : new Obj(ptr);
        }

        public Obj CreateObjFromFile(ProgramType programType, string sourceFile, ProfileType profile, params string[] args)
        {
            var ptr = Cg.CreateObjFromFile(this.Handle, programType, sourceFile, profile, args);
            return ptr == IntPtr.Zero ? null : new Obj(ptr);
        }

        public Parameter CreateParameter(ParameterType type)
        {
            var ptr = Cg.CreateParameter(this.Handle, type);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr);
        }

        public Parameter CreateParameterArray(ParameterType type, int length)
        {
            var ptr = Cg.CreateParameterArray(this.Handle, type, length);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr);
        }

        public Parameter CreateParameterMultiDimArray(ParameterType type, int dim, int[] lengths)
        {
            var ptr = Cg.CreateParameterMultiDimArray(this.Handle, type, dim, lengths);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr);
        }

        public Program CreateProgram(ProgramType type, string source, ProfileType profile, string entry, params string[] args)
        {
            var ptr = Cg.CreateProgram(this.Handle, type, source, profile, entry, args);
            return ptr == IntPtr.Zero ? null : new Program(ptr)
                   {
                       Type = type,
                   };
        }

        public Program CreateProgramFromFile(ProgramType type, string file, ProfileType profile, string entry, params string[] args)
        {
            var ptr = Cg.CreateProgramFromFile(this.Handle, type, file, profile, entry, args);
            return ptr == IntPtr.Zero ? null : new Program(ptr)
            {
                Type = type,
            };
        }

        public State CreateSamplerState(string name, ParameterType type)
        {
            var ptr = Cg.CreateSamplerState(this.Handle, name, type);
            return ptr == IntPtr.Zero ? null : new State(ptr);
        }

        public State CreateState(string name, ParameterType type)
        {
            var ptr = Cg.CreateState(this.Handle, name, type);
            return ptr == IntPtr.Zero ? null : new State(ptr);
        }

        public string GetLastListing()
        {
            return Cg.GetLastListing(this.Handle);
        }

        public Effect GetNamedEffect(string name)
        {
            var ptr = Cg.GetNamedEffect(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new Effect(ptr) { OwnsHandle = false };
        }

        public State GetNamedSamplerState(string name)
        {
            var ptr = Cg.GetNamedSamplerState(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new State(ptr) { OwnsHandle = false };
        }

        public State GetNamedState(string name)
        {
            var ptr = Cg.GetNamedState(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new State(ptr) { OwnsHandle = false };
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