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

    public sealed class Effect : WrapperObject
    {
        #region Constructors

        internal Effect(IntPtr handle)
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
                return new Context(CgNativeMethods.cgGetEffectContext(this.Handle))
                       {
                           OwnsHandle = false
                       };
            }
        }

        public Annotation FirstAnnotation
        {
            get
            {
                var ptr = CgNativeMethods.cgGetFirstEffectAnnotation(this.Handle);
                return ptr == IntPtr.Zero ? null : new Annotation(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public Parameter FirstLeafParameter
        {
            get
            {
                var ptr = CgNativeMethods.cgGetFirstLeafEffectParameter(this.Handle);
                return ptr == IntPtr.Zero ? null : new Parameter(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public Parameter FirstParameter
        {
            get
            {
                var ptr = CgNativeMethods.cgGetFirstEffectParameter(this.Handle);
                return ptr == IntPtr.Zero ? null : new Parameter(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public Technique FirstTechnique
        {
            get
            {
                var ptr = CgNativeMethods.cgGetFirstTechnique(this.Handle);
                return ptr == IntPtr.Zero ? null : new Technique(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public bool IsEffect
        {
            get
            {
                return CgNativeMethods.cgIsEffect(this.Handle);
            }
        }

        public string Name
        {
            get
            {
                return Marshal.PtrToStringAnsi(CgNativeMethods.cgGetEffectName(this.Handle));
            }

            set
            {
                CgNativeMethods.cgSetEffectName(this.Handle, value);
            }
        }

        public Effect NextEffect
        {
            get
            {
                var ptr = CgNativeMethods.cgGetNextEffect(this.Handle);
                return ptr == IntPtr.Zero ? null : new Effect(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public IEnumerable<Parameter> Parameters
        {
            get
            {
                return Enumerate(() => this.FirstParameter, t => t.NextParameter);
            }
        }

        public IEnumerable<Technique> Techniques
        {
            get
            {
                return Enumerate(() => this.FirstTechnique, t => t.NextTechnique);
            }
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

        public static Effect Create(Context context, string code, params string[] args)
        {
            return context.CreateEffect(code, args);
        }

        public static Effect CreateFromFile(Context context, string filename, params string[] args)
        {
            return context.CreateEffectFromFile(filename, args);
        }

        #endregion Public Static Methods

        #region Public Methods

        public Effect Copy()
        {
            var ptr = CgNativeMethods.cgCopyEffect(this.Handle);
            return ptr == IntPtr.Zero ? null : new Effect(ptr);
        }

        public Annotation CreateAnnotation(string name, ParameterType type)
        {
            var ptr = CgNativeMethods.cgCreateEffectAnnotation(this.Handle, name, type);
            return ptr == IntPtr.Zero ? null : new Annotation(ptr);
        }

        public Parameter CreateParameterArray(string name, ParameterType type, int length)
        {
            var ptr = CgNativeMethods.cgCreateEffectParameterArray(this.Handle, name, type, length);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr);
        }

        public Parameter CreateParameterMultiDimArray(string name, ParameterType type, int dim, int[] lengths)
        {
            var ptr = CgNativeMethods.cgCreateEffectParameterMultiDimArray(this.Handle, name, type, dim, lengths);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr);
        }

        public Program CreateProgram(ProfileType profile, string entry, params string[] args)
        {
            var ptr = CgNativeMethods.cgCreateProgramFromEffect(this.Handle, profile, entry, args);
            return ptr == IntPtr.Zero ? null : new Program(ptr);
        }

        public Technique CreateTechnique(string name)
        {
            var ptr = CgNativeMethods.cgCreateTechnique(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new Technique(ptr);
        }

        public Annotation GetNamedAnnotation(string name)
        {
            var ptr = CgNativeMethods.cgGetNamedEffectAnnotation(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new Annotation(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public Parameter GetNamedParameter(string name)
        {
            var ptr = CgNativeMethods.cgGetNamedEffectParameter(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public Technique GetNamedTechnique(string name)
        {
            var ptr = CgNativeMethods.cgGetNamedTechnique(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new Technique(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public ParameterType GetNamedUserType(string name)
        {
            return CgNativeMethods.cgGetNamedUserType(this.Handle, name);
        }

        public Parameter GetParameterBySemantic(string name)
        {
            var ptr = CgNativeMethods.cgGetEffectParameterBySemantic(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public ParameterType GetUserType(int index)
        {
            return CgNativeMethods.cgGetUserType(this.Handle, index);
        }

        public void SetLastListing(string listing)
        {
            CgNativeMethods.cgSetLastListing(this.Handle, listing);
        }

        #endregion Public Methods

        #region Protected Methods

        protected override void Dispose(bool disposing)
        {
            if (this.Handle != IntPtr.Zero)
            {
                CgNativeMethods.cgDestroyEffect(this.Handle);
            }
        }

        #endregion Protected Methods

        #endregion Methods
    }
}