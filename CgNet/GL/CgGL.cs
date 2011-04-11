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
namespace CgNet.GL
{
    using System;
    using System.ComponentModel;
    using System.Runtime.InteropServices;

    using OpenTK;

    public static class CgGL
    {
        #region Methods

        #region Public Static Methods

        public static void DisableProfile(ProfileType profile)
        {
            CgGLNativeMethods.cgGLDisableProfile(profile);
        }

        public static void EnableProfile(ProfileType profile)
        {
            CgGLNativeMethods.cgGLEnableProfile(profile);
        }

        /// <summary>
        /// Gets the latest profile for a profile class.
        /// </summary>
        /// <param name="profileClass">The class of profile that will be returned.</param>
        /// <returns>Returns a profile enumerant for the latest profile of the given class. Returns CG_PROFILE_UNKNOWN if no appropriate profile is available or an error occurs.</returns>
        public static ProfileType GetLatestProfile(ProfileClass profileClass)
        {
            return CgGLNativeMethods.cgGLGetLatestProfile(profileClass);
        }

        public static string[] GetOptimalOptions(ProfileType profile)
        {
            return Cg.IntPtrToStringArray(CgGLNativeMethods.cgGLGetOptimalOptions(profile));
        }

        public static bool IsProfileSupported(ProfileType profile)
        {
            return CgGLNativeMethods.cgGLIsProfileSupported(profile);
        }

        public static void SetDebugMode(bool debug)
        {
            CgGLNativeMethods.cgGLSetDebugMode(debug);
        }

        public static void SetOptimalOptions(ProfileType profile)
        {
            CgGLNativeMethods.cgGLSetOptimalOptions(profile);
        }

        public static void UnbindProgram(ProfileType profile)
        {
            CgGLNativeMethods.cgGLUnbindProgram(profile);
        }

        #endregion Public Static Methods

        #region Internal Static Methods

        internal static T GetMatrixParameter<T>(IntPtr param, Order order)
            where T : struct
        {
            GCHandle handle = GCHandle.Alloc(new T(), GCHandleType.Pinned);

            try
            {
                if (typeof(T) == typeof(Matrix4d))
                {
                    switch (order)
                    {
                        case Order.ColumnMajor:
                            CgGLNativeMethods.cgGLGetMatrixParameterdc(param, handle.AddrOfPinnedObject());
                            break;
                        case Order.RowMajor:
                            CgGLNativeMethods.cgGLGetMatrixParameterdr(param, handle.AddrOfPinnedObject());
                            break;
                        default:
                            throw new InvalidEnumArgumentException("order");
                    }
                }
                else if (typeof(T) == typeof(Matrix4))
                {
                    switch (order)
                    {
                        case Order.ColumnMajor:
                            CgGLNativeMethods.cgGLGetMatrixParameterfc(param, handle.AddrOfPinnedObject());
                            break;
                        case Order.RowMajor:
                            CgGLNativeMethods.cgGLGetMatrixParameterfr(param, handle.AddrOfPinnedObject());
                            break;
                        default:
                            throw new InvalidEnumArgumentException("order");
                    }
                }
                else
                {
                    throw new ArgumentException();
                }

                return (T)handle.Target;
            }
            finally
            {
                handle.Free();
            }
        }

        internal static T[] GetMatrixParameterArray<T>(IntPtr param, int offset, int nelements, Order order)
            where T : struct
        {
            var retValue = new T[nelements];
            GCHandle g = GCHandle.Alloc(retValue, GCHandleType.Pinned);

            try
            {
                if (typeof(T) == typeof(Matrix4))
                {
                    switch (order)
                    {
                        case Order.ColumnMajor:
                            CgGLNativeMethods.cgGLGetMatrixParameterArrayfc(param, offset, nelements, g.AddrOfPinnedObject());
                            break;
                        case Order.RowMajor:
                            CgGLNativeMethods.cgGLGetMatrixParameterArrayfr(param, offset, nelements, g.AddrOfPinnedObject());
                            break;
                        default:
                            throw new InvalidEnumArgumentException("order");
                    }
                }
                else if (typeof(T) == typeof(Matrix4d))
                {
                    switch (order)
                    {
                        case Order.ColumnMajor:
                            CgGLNativeMethods.cgGLGetMatrixParameterArraydc(param, offset, nelements, g.AddrOfPinnedObject());
                            break;
                        case Order.RowMajor:
                            CgGLNativeMethods.cgGLGetMatrixParameterArraydr(param, offset, nelements, g.AddrOfPinnedObject());
                            break;
                        default:
                            throw new InvalidEnumArgumentException("order");
                    }
                }
                else
                {
                    throw new ArgumentException();
                }

                return retValue;
            }
            finally
            {
                g.Free();
            }
        }

        internal static void SetMatrixParameter(IntPtr param, Matrix4d matrix, Order order)
        {
            switch (order)
            {
                case Order.ColumnMajor:
                    CgGLNativeMethods.cgGLSetMatrixParameterdc(param, ref matrix);
                    break;
                case Order.RowMajor:
                    CgGLNativeMethods.cgGLSetMatrixParameterdr(param, ref matrix);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("order");
            }
        }

        internal static void SetMatrixParameterArray(IntPtr param, int offset, int nelements, Matrix4d[] matrices, Order order)
        {
            switch (order)
            {
                case Order.ColumnMajor:
                    CgGLNativeMethods.cgGLSetMatrixParameterArraydc(param, offset, nelements, matrices);
                    break;
                case Order.RowMajor:
                    CgGLNativeMethods.cgGLSetMatrixParameterArraydr(param, offset, nelements, matrices);
                    break;
                default:
                    throw new InvalidEnumArgumentException("order");
            }
        }

        internal static void SetMatrixParameterArray(IntPtr param, int offset, int nelements, Matrix4[] matrices, Order order)
        {
            switch (order)
            {
                case Order.ColumnMajor:
                    CgGLNativeMethods.cgGLSetMatrixParameterArrayfc(param, offset, nelements, matrices);
                    break;
                case Order.RowMajor:
                    CgGLNativeMethods.cgGLSetMatrixParameterArrayfr(param, offset, nelements, matrices);
                    break;
                default:
                    throw new InvalidEnumArgumentException("order");
            }
        }

        #endregion Internal Static Methods

        #endregion Methods
    }
}