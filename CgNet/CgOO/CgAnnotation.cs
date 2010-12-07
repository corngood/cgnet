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

    public sealed class CgAnnotation : WrapperObject
    {
        #region Constructors

        internal CgAnnotation(IntPtr handle)
            : base(handle)
        {
        }

        #endregion Constructors

        #region Properties

        #region Public Properties

        public int DependentParametersCount
        {
            get
            {
                return Cg.GetNumDependentAnnotationParameters(this.Handle);
            }
        }

        public bool IsAnnotation
        {
            get
            {
                return Cg.IsAnnotation(this.Handle);
            }
        }

        public string Name
        {
            get
            {
                return Cg.GetAnnotationName(this.Handle);
            }
        }

        public CgAnnotation NextAnnotation
        {
            get
            {
                var ptr = Cg.GetNextAnnotation(this.Handle);
                return ptr == IntPtr.Zero ? null : new CgAnnotation(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public ParameterType Type
        {
            get
            {
                return Cg.GetAnnotationType(this.Handle);
            }
        }

        #endregion Public Properties

        #endregion Properties

        #region Methods

        #region Public Methods

        public bool[] GetBoolValues()
        {
            return Cg.GetBoolAnnotationValues(this.Handle);
        }

        public CgParameter GetDependentParameter(int index)
        {
            var ptr = Cg.GetDependentAnnotationParameter(this.Handle, index);
            return ptr == IntPtr.Zero ? null : new CgParameter(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public float[] GetFloatValues()
        {
            return Cg.GetFloatAnnotationValues(this.Handle);
        }

        public int[] GetIntValues()
        {
            return Cg.GetIntAnnotationValues(this.Handle);
        }

        public string[] GetStringAnnotationValues()
        {
            return Cg.GetStringAnnotationValues(this.Handle);
        }

        public string GetStringValue()
        {
            return Cg.GetStringAnnotationValue(this.Handle);
        }

        public bool Set(int value)
        {
            return Cg.SetAnnotation(this.Handle, value);
        }

        public bool Set(float value)
        {
            return Cg.SetAnnotation(this.Handle, value);
        }

        public bool Set(string value)
        {
            return Cg.SetAnnotation(this.Handle, value);
        }

        public bool Set(bool value)
        {
            return Cg.SetAnnotation(this.Handle, value);
        }

        #endregion Public Methods

        #endregion Methods
    }
}