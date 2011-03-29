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

    public sealed class Technique : WrapperObject
    {
        #region Constructors

        internal Technique(IntPtr handle)
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

        public Effect Effect
        {
            get
            {
                var ptr = CgNativeMethods.cgGetTechniqueEffect(this.Handle);

                return ptr == IntPtr.Zero ? null : new Effect(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public Annotation FirstAnnotation
        {
            get
            {
                var ptr = CgNativeMethods.cgGetFirstTechniqueAnnotation(this.Handle);
                return ptr == IntPtr.Zero ? null : new Annotation(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public Pass FirstPass
        {
            get
            {
                var ptr = CgNativeMethods.cgGetFirstPass(this.Handle);

                return ptr == IntPtr.Zero ? null : new Pass(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public bool IsTechnique
        {
            get
            {
                return CgNativeMethods.cgIsTechnique(this.Handle);
            }
        }

        public bool IsValidated
        {
            get
            {
                return CgNativeMethods.cgIsTechniqueValidated(this.Handle);
            }
        }

        public string Name
        {
            get
            {
                return Marshal.PtrToStringAnsi(CgNativeMethods.cgGetTechniqueName(this.Handle));
            }
        }

        public Technique NextTechnique
        {
            get
            {
                var ptr = CgNativeMethods.cgGetNextTechnique(this.Handle);
                return ptr == IntPtr.Zero ? null : new Technique(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public IEnumerable<Pass> Passes
        {
            get
            {
                return Enumerate(() => this.FirstPass, t => t.NextPass);
            }
        }

        #endregion Public Properties

        #endregion Properties

        #region Methods

        #region Public Static Methods

        public static Technique Create(Effect effect, string name)
        {
            return effect.CreateTechnique(name);
        }

        #endregion Public Static Methods

        #region Public Methods

        public Pass CreatePass(string name)
        {
            var ptr = CgNativeMethods.cgCreatePass(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new Pass(ptr);
        }

        public Annotation CreateTechniqueAnnotation(string name, ParameterType type)
        {
            var ptr = CgNativeMethods.cgCreateTechniqueAnnotation(this.Handle, name, type);
            return ptr == IntPtr.Zero ? null : new Annotation(ptr);
        }

        public Annotation GetNamedAnnotation(string name)
        {
            var ptr = CgNativeMethods.cgGetNamedTechniqueAnnotation(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new Annotation(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public Pass GetNamedPass(string name)
        {
            var ptr = CgNativeMethods.cgGetNamedPass(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new Pass(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public void SetLastListing(string listing)
        {
            CgNativeMethods.cgSetLastListing(this.Handle, listing);
        }

        public bool Validate()
        {
            return CgNativeMethods.cgValidateTechnique(this.Handle);
        }

        #endregion Public Methods

        #endregion Methods
    }
}