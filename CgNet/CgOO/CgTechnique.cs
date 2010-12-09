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

    public sealed class CgTechnique : WrapperObject
    {
        #region Constructors

        internal CgTechnique(IntPtr handle)
            : base(handle)
        {
        }

        #endregion Constructors

        #region Properties

        #region Public Properties

        public IEnumerable<CgAnnotation> Annotations
        {
            get
            {
                return Enumerate(() => this.FirstAnnotation, t => t.NextAnnotation);
            }
        }

        public CgEffect Effect
        {
            get
            {
                var ptr = Cg.GetTechniqueEffect(this.Handle);

                return ptr == IntPtr.Zero ? null : new CgEffect(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public CgAnnotation FirstAnnotation
        {
            get
            {
                var ptr = Cg.GetFirstTechniqueAnnotation(this.Handle);
                return ptr == IntPtr.Zero ? null : new CgAnnotation(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public CgPass FirstPass
        {
            get
            {
                var ptr = Cg.GetFirstPass(this.Handle);

                return ptr == IntPtr.Zero ? null : new CgPass(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public bool IsTechnique
        {
            get
            {
                return Cg.IsTechnique(this.Handle);
            }
        }

        public bool IsValidated
        {
            get
            {
                return Cg.IsTechniqueValidated(this.Handle);
            }
        }

        public string Name
        {
            get
            {
                return Cg.GetTechniqueName(this.Handle);
            }
        }

        public CgTechnique NextTechnique
        {
            get
            {
                var ptr = Cg.GetNextTechnique(this.Handle);
                return ptr == IntPtr.Zero ? null : new CgTechnique(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public IEnumerable<CgPass> Passes
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

        public static CgTechnique Create(CgEffect effect, string name)
        {
            return effect.CreateTechnique(name);
        }

        #endregion Public Static Methods

        #region Public Methods

        public CgPass CreatePass(string name)
        {
            var ptr = Cg.CreatePass(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new CgPass(ptr);
        }

        public CgAnnotation CreateTechniqueAnnotation(string name, ParameterType type)
        {
            var ptr = Cg.CreateTechniqueAnnotation(this.Handle, name, type);
            return ptr == IntPtr.Zero ? null : new CgAnnotation(ptr);
        }

        public CgAnnotation GetNamedAnnotation(string name)
        {
            var ptr = Cg.GetNamedTechniqueAnnotation(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new CgAnnotation(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public CgPass GetNamedPass(string name)
        {
            var ptr = Cg.GetNamedPass(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new CgPass(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public bool Validate()
        {
            return Cg.ValidateTechnique(this.Handle);
        }

        #endregion Public Methods

        #endregion Methods
    }
}