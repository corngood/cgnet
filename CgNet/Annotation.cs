﻿/*
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
    using System.Text;

    public sealed class Annotation : WrapperObject
    {
        #region Constructors

        internal Annotation(IntPtr handle)
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
                return CgNativeMethods.cgGetNumDependentAnnotationParameters(this.Handle);
            }
        }

        public bool IsAnnotation
        {
            get
            {
                return CgNativeMethods.cgIsAnnotation(this.Handle);
            }
        }

        public string Name
        {
            get
            {
                return Marshal.PtrToStringAnsi(CgNativeMethods.cgGetAnnotationName(this.Handle));
            }
        }

        public Annotation NextAnnotation
        {
            get
            {
                var ptr = CgNativeMethods.cgGetNextAnnotation(this.Handle);
                return ptr == IntPtr.Zero ? null : new Annotation(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public ParameterType Type
        {
            get
            {
                return CgNativeMethods.cgGetAnnotationType(this.Handle);
            }
        }

        #endregion Public Properties

        #endregion Properties

        #region Methods

        #region Public Methods

        public bool[] GetBoolValues()
        {
            int count;
            var values = CgNativeMethods.cgGetBoolAnnotationValues(this.Handle, out count);
            return Cg.IntPtrToBoolArray(values, count);
        }

        public Parameter GetDependentParameter(int index)
        {
            var ptr = CgNativeMethods.cgGetDependentAnnotationParameter(this.Handle, index);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public float[] GetFloatValues()
        {
            int nvalues;
            return CgNativeMethods.cgGetFloatAnnotationValues(this.Handle, out nvalues);
        }

        public int[] GetIntValues()
        {
            int nvalues;
            return CgNativeMethods.cgGetIntAnnotationValues(this.Handle, out nvalues);
        }

        public string[] GetStringAnnotationValues()
        {
            int nvalues;
            var ptr = CgNativeMethods.cgGetStringAnnotationValues(this.Handle, out nvalues);
            if (nvalues == 0)
            {
                return null;
            }

            unsafe
            {
                var byteArray = (byte**)ptr;
                var lines = new List<string>();
                var buffer = new List<byte>();

                for (int i = 0; i < nvalues; i++)
                {
                    byte* b = *byteArray;
                    for (;;)
                    {
                        if (*b == '\0')
                        {
                            char[] cc = Encoding.ASCII.GetChars(buffer.ToArray());
                            lines.Add(new string(cc));
                            buffer.Clear();
                            break;
                        }

                        buffer.Add(*b);
                        b++;
                    }

                    byteArray++;
                }

                return lines.ToArray();
            }
        }

        public string GetStringValue()
        {
            return Marshal.PtrToStringAnsi(CgNativeMethods.cgGetStringAnnotationValue(this.Handle));
        }

        public bool Set(int value)
        {
            return CgNativeMethods.cgSetIntAnnotation(this.Handle, value);
        }

        public bool Set(float value)
        {
            return CgNativeMethods.cgSetFloatAnnotation(this.Handle, value);
        }

        public bool Set(string value)
        {
            return CgNativeMethods.cgSetStringAnnotation(this.Handle, value);
        }

        public bool Set(bool value)
        {
            return CgNativeMethods.cgSetBoolAnnotation(this.Handle, value);
        }

        #endregion Public Methods

        #endregion Methods
    }
}