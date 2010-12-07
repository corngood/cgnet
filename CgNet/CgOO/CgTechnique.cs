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

        #endregion Public Properties

        #endregion Properties

        #region Methods

        #region Public Static Methods

        public static CgTechnique Create(CgEffect effect, string name)
        {
            return new CgTechnique(Cg.CreateTechnique(effect.Handle, name));
        }

        #endregion Public Static Methods

        #region Public Methods

        public CgPass CreatePass(string name)
        {
            return new CgPass(Cg.CreatePass(this.Handle, name));
        }

        public CgAnnotation CreateTechniqueAnnotation(string name, ParameterType type)
        {
            return new CgAnnotation(Cg.CreateTechniqueAnnotation(this.Handle, name, type));
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