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

    public sealed class CgEffect : WrapperObject
    {
        #region Constructors

        internal CgEffect(IntPtr handle)
            : base(handle)
        {
        }

        #endregion Constructors

        #region Properties

        #region Public Properties

        public CgContext Context
        {
            get
            {
                return new CgContext(Cg.GetEffectContext(this.Handle))
                       {
                           OwnsHandle = false
                       };
            }
        }

        public CgAnnotation FirstAnnotation
        {
            get
            {
                var ptr = Cg.GetFirstEffectAnnotation(this.Handle);
                return ptr == IntPtr.Zero ? null : new CgAnnotation(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public CgParameter FirstLeafParameter
        {
            get
            {
                var ptr = Cg.GetFirstLeafEffectParameter(this.Handle);
                return ptr == IntPtr.Zero ? null : new CgParameter(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public CgParameter FirstParameter
        {
            get
            {
                var ptr = Cg.GetFirstEffectParameter(this.Handle);
                return ptr == IntPtr.Zero ? null : new CgParameter(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public CgTechnique FirstTechnique
        {
            get
            {
                var ptr = Cg.GetFirstTechnique(this.Handle);
                return ptr == IntPtr.Zero ? null : new CgTechnique(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public bool IsEffect
        {
            get
            {
                return Cg.IsEffect(this.Handle);
            }
        }

        public string Name
        {
            get
            {
                return Cg.GetEffectName(this.Handle);
            }

            set
            {
                Cg.SetEffectName(this.Handle, value);
            }
        }

        public CgEffect NextEffect
        {
            get
            {
                var ptr = Cg.GetNextEffect(this.Handle);
                return ptr == IntPtr.Zero ? null : new CgEffect(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
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

        public static CgEffect Create(CgContext context, string code, params string[] args)
        {
            return new CgEffect(Cg.CreateEffect(context.Handle, code, args));
        }

        public static CgEffect CreateFromFile(CgContext context, string filename, params string[] args)
        {
            return new CgEffect(Cg.CreateEffectFromFile(context.Handle, filename, args));
        }

        #endregion Public Static Methods

        #region Public Methods

        public CgEffect Copy()
        {
            var ptr = Cg.CopyEffect(this.Handle);
            return ptr == IntPtr.Zero ? null : new CgEffect(ptr);
        }

        public CgAnnotation CreateAnnotation(string name, ParameterType type)
        {
            return new CgAnnotation(Cg.CreateEffectAnnotation(this.Handle, name, type));
        }

        public CgParameter CreateParameterArray(string name, ParameterType type, int length)
        {
            return new CgParameter(Cg.CreateEffectParameterArray(this.Handle, name, type, length));
        }

        public CgParameter CreateParameterMultiDimArray(string name, ParameterType type, int dim, int[] lengths)
        {
            return new CgParameter(Cg.CreateEffectParameterMultiDimArray(this.Handle, name, type, dim, lengths));
        }

        public CgProgram CreateProgram(ProfileType profile, string entry, params string[] args)
        {
            var ptr = Cg.CreateProgramFromEffect(this.Handle, profile, entry, args);
            return ptr == IntPtr.Zero ? null : new CgProgram(ptr);
        }

        public CgTechnique CreateTechnique(string name)
        {
            return new CgTechnique(Cg.CreateTechnique(this.Handle, name));
        }

        public CgAnnotation GetNamedAnnotation(string name)
        {
            var ptr = Cg.GetNamedEffectAnnotation(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new CgAnnotation(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public CgParameter GetNamedParameter(string name)
        {
            var ptr = Cg.GetNamedEffectParameter(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new CgParameter(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public CgTechnique GetNamedTechnique(string name)
        {
            var ptr = Cg.GetNamedTechnique(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new CgTechnique(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public ParameterType GetNamedUserType(string name)
        {
            return Cg.GetNamedUserType(this.Handle, name);
        }

        public CgParameter GetParameterBySemantic(string name)
        {
            var ptr = Cg.GetEffectParameterBySemantic(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new CgParameter(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public ParameterType GetUserType(int index)
        {
            return Cg.GetUserType(this.Handle, index);
        }

        public void SetLastListing(string listing)
        {
            Cg.SetLastListing(this.Handle, listing);
        }

        #endregion Public Methods

        #region Protected Methods

        protected override void Dispose(bool disposing)
        {
            if (this.Handle != IntPtr.Zero)
            {
                Cg.DestroyEffect(this.Handle);
            }
        }

        #endregion Protected Methods

        #endregion Methods
    }
}