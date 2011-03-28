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
    using System.Runtime.InteropServices;

    using CgNet;
    using CgNet.GL;

    using OpenTK;
    using OpenTK.Graphics.OpenGL;

    public static class CgGLParameter
    {
        #region Methods

        #region Public Static Methods

        // TODO: TextureParameter
        public static void Disable(this Parameter param)
        {
            CgGLNativeMethods.cgGLDisableTextureParameter(param.Handle);
        }

        public static void DisableClientState(this Parameter param)
        {
            CgGLNativeMethods.cgGLDisableClientState(param.Handle);
        }

        // TODO: TextureParameter
        public static void Enable(this Parameter param)
        {
            CgGLNativeMethods.cgGLEnableTextureParameter(param.Handle);
        }

        public static void EnableClientState(this Parameter param)
        {
            CgGLNativeMethods.cgGLEnableClientState(param.Handle);
        }

        public static T Get<T>(this Parameter param)
            where T : struct
        {
            IntPtr param1 = param.Handle;
            GCHandle handle = GCHandle.Alloc(new T(), GCHandleType.Pinned);
            try
            {
                if (typeof(T) == typeof(float))
                {
                    CgGLNativeMethods.cgGLGetParameter1f(param1, handle.AddrOfPinnedObject());
                }
                else if (typeof(T) == typeof(double))
                {
                    CgGLNativeMethods.cgGLGetParameter1d(param1, handle.AddrOfPinnedObject());
                }
                else if (typeof(T) == typeof(Vector2))
                {
                    CgGLNativeMethods.cgGLGetParameter2f(param1, handle.AddrOfPinnedObject());
                }
                else if (typeof(T) == typeof(Vector2d))
                {
                    CgGLNativeMethods.cgGLGetParameter2d(param1, handle.AddrOfPinnedObject());
                }
                else if (typeof(T) == typeof(Vector3))
                {
                    CgGLNativeMethods.cgGLGetParameter3f(param1, handle.AddrOfPinnedObject());
                }
                else if (typeof(T) == typeof(Vector3d))
                {
                    CgGLNativeMethods.cgGLGetParameter3d(param1, handle.AddrOfPinnedObject());
                }
                else if (typeof(T) == typeof(Vector4))
                {
                    CgGLNativeMethods.cgGLGetParameter4f(param1, handle.AddrOfPinnedObject());
                }
                else if (typeof(T) == typeof(Vector4d))
                {
                    CgGLNativeMethods.cgGLGetParameter4d(param1, handle.AddrOfPinnedObject());
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

        public static void Get(this Parameter param, ref float[] values)
        {
            IntPtr param1 = param.Handle;
            GCHandle handle = GCHandle.Alloc(values, GCHandleType.Pinned);
            try
            {
                switch (values.Length)
                {
                    case 1:
                        CgGLNativeMethods.cgGLGetParameter1f(param1, handle.AddrOfPinnedObject());
                        break;
                    case 2:
                        CgGLNativeMethods.cgGLGetParameter2f(param1, handle.AddrOfPinnedObject());
                        break;
                    case 3:
                        CgGLNativeMethods.cgGLGetParameter3f(param1, handle.AddrOfPinnedObject());
                        break;
                    case 4:
                        CgGLNativeMethods.cgGLGetParameter4f(param1, handle.AddrOfPinnedObject());
                        break;
                }
            }
            finally
            {
                handle.Free();
            }
        }

        public static void Get(this Parameter param, ref double[] values)
        {
            IntPtr param1 = param.Handle;
            GCHandle handle = GCHandle.Alloc(values);
            try
            {
                switch (values.Length)
                {
                    case 1:
                        CgGLNativeMethods.cgGLGetParameter1d(param1, handle.AddrOfPinnedObject());
                        break;
                    case 2:
                        CgGLNativeMethods.cgGLGetParameter2d(param1, handle.AddrOfPinnedObject());
                        break;
                    case 3:
                        CgGLNativeMethods.cgGLGetParameter3d(param1, handle.AddrOfPinnedObject());
                        break;
                    case 4:
                        CgGLNativeMethods.cgGLGetParameter4d(param1, handle.AddrOfPinnedObject());
                        break;
                }
            }
            finally
            {
                handle.Free();
            }
        }

        public static void GetArray(this Parameter param, int offset, int nelements, ref float[] values)
        {
            IntPtr param1 = param.Handle;
            GCHandle g = GCHandle.Alloc(values, GCHandleType.Pinned);

            try
            {
                switch (values.Length / nelements)
                {
                    case 1:
                        CgGLNativeMethods.cgGLGetParameterArray1f(param1, offset, nelements, g.AddrOfPinnedObject());
                        break;
                    case 2:
                        CgGLNativeMethods.cgGLGetParameterArray2f(param1, offset, nelements, g.AddrOfPinnedObject());
                        break;
                    case 3:
                        CgGLNativeMethods.cgGLGetParameterArray3f(param1, offset, nelements, g.AddrOfPinnedObject());
                        break;
                    case 4:
                        CgGLNativeMethods.cgGLGetParameterArray4f(param1, offset, nelements, g.AddrOfPinnedObject());
                        break;
                }
            }
            finally
            {
                g.Free();
            }
        }

        public static void GetArray(this Parameter param, int offset, int nelements, ref double[] values)
        {
            IntPtr param1 = param.Handle;
            GCHandle g = GCHandle.Alloc(values, GCHandleType.Pinned);

            try
            {
                switch (values.Length / nelements)
                {
                    case 1:
                        CgGLNativeMethods.cgGLGetParameterArray1d(param1, offset, nelements, g.AddrOfPinnedObject());
                        break;
                    case 2:
                        CgGLNativeMethods.cgGLGetParameterArray2d(param1, offset, nelements, g.AddrOfPinnedObject());
                        break;
                    case 3:
                        CgGLNativeMethods.cgGLGetParameterArray3d(param1, offset, nelements, g.AddrOfPinnedObject());
                        break;
                    case 4:
                        CgGLNativeMethods.cgGLGetParameterArray4d(param1, offset, nelements, g.AddrOfPinnedObject());
                        break;
                }
            }
            finally
            {
                g.Free();
            }
        }

        public static void GetMatrix(this Parameter param, out Matrix4 value)
        {
            value = CgGL.GetMatrixParameter<Matrix4>(param.Handle, Order.RowMajor);
        }

        public static void GetMatrix(this Parameter param, out Matrix4d value)
        {
            value = CgGL.GetMatrixParameter<Matrix4d>(param.Handle, Order.RowMajor);
        }

        public static T GetMatrix<T>(this Parameter param)
            where T : struct
        {
            return CgGL.GetMatrixParameter<T>(param.Handle, Order.RowMajor);
        }

        public static T GetMatrix<T>(this Parameter param, Order order)
            where T : struct
        {
            return CgGL.GetMatrixParameter<T>(param.Handle, order);
        }

        public static void GetMatrixArray(this Parameter param, int offset, int nelements, out Matrix4[] values)
        {
            values = CgGL.GetMatrixParameterArray<Matrix4>(param.Handle, offset, nelements, Order.RowMajor);
        }

        public static void GetMatrixArray(this Parameter param, int offset, int nelements, out Matrix4d[] values)
        {
            values = CgGL.GetMatrixParameterArray<Matrix4d>(param.Handle, offset, nelements, Order.RowMajor);
        }

        public static T[] GetMatrixArray<T>(this Parameter param, int offset, int nelements)
            where T : struct
        {
            return CgGL.GetMatrixParameterArray<T>(param.Handle, offset, nelements, Order.RowMajor);
        }

        public static T[] GetMatrixArray<T>(this Parameter param, int offset, int nelements, Order order)
            where T : struct
        {
            return CgGL.GetMatrixParameterArray<T>(param.Handle, offset, nelements, order);
        }

        public static int GetTextureEnum(this Parameter param)
        {
            return CgGLNativeMethods.cgGLGetTextureEnum(param.Handle);
        }

        public static int GetTextureParameter(this Parameter param)
        {
            return CgGLNativeMethods.cgGLGetTextureParameter(param.Handle);
        }

        public static void Set(this Parameter param, double x)
        {
            CgGLNativeMethods.cgGLSetParameter1d(param.Handle, x);
        }

        public static void Set(this Parameter param, double[] v)
        {
            IntPtr param1 = param.Handle;
            switch (v.Length)
            {
                case 1:
                    CgGLNativeMethods.cgGLSetParameter1dv(param1, v);
                    break;
                case 2:
                    CgGLNativeMethods.cgGLSetParameter2dv(param1, v);
                    break;
                case 3:
                    CgGLNativeMethods.cgGLSetParameter3dv(param1, v);
                    break;
                case 4:
                    CgGLNativeMethods.cgGLSetParameter4dv(param1, v);
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        public static void Set(this Parameter param, float[] v)
        {
            IntPtr param1 = param.Handle;
            switch (v.Length)
            {
                case 1:
                    CgGLNativeMethods.cgGLSetParameter1fv(param1, v);
                    break;
                case 2:
                    CgGLNativeMethods.cgGLSetParameter2fv(param1, v);
                    break;
                case 3:
                    CgGLNativeMethods.cgGLSetParameter3fv(param1, v);
                    break;
                case 4:
                    CgGLNativeMethods.cgGLSetParameter4fv(param1, v);
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        public static void Set(this Parameter param, float x)
        {
            CgGLNativeMethods.cgGLSetParameter1f(param.Handle, x);
        }

        public static void Set(this Parameter param, double x, double y)
        {
            CgGLNativeMethods.cgGLSetParameter2d(param.Handle, x, y);
        }

        public static void Set(this Parameter param, float x, float y)
        {
            CgGLNativeMethods.cgGLSetParameter2f(param.Handle, x, y);
        }

        public static void Set(this Parameter param, double x, double y, double z)
        {
            CgGLNativeMethods.cgGLSetParameter3d(param.Handle, x, y, z);
        }

        public static void Set(this Parameter param, float x, float y, float z)
        {
            CgGLNativeMethods.cgGLSetParameter3f(param.Handle, x, y, z);
        }

        public static void Set(this Parameter param, double x, double y, double z, double w)
        {
            CgGLNativeMethods.cgGLSetParameter4d(param.Handle, x, y, z, w);
        }

        public static void Set(this Parameter param, float x, float y, float z, float w)
        {
            CgGLNativeMethods.cgGLSetParameter4f(param.Handle, x, y, z, w);
        }

        public static void Set(this Parameter param, Vector2 v)
        {
            Vector2 v1 = v;
            CgGLNativeMethods.cgGLSetParameter2f(param.Handle, v1.X, v1.Y);
        }

        public static void Set(this Parameter param, Vector2d v)
        {
            Vector2d v1 = v;
            CgGLNativeMethods.cgGLSetParameter2d(param.Handle, v1.X, v1.Y);
        }

        public static void Set(this Parameter param, Vector3 v)
        {
            Vector3 v1 = v;
            CgGLNativeMethods.cgGLSetParameter3f(param.Handle, v1.X, v1.Y, v1.Z);
        }

        public static void Set(this Parameter param, Vector3d v)
        {
            Vector3d v1 = v;
            CgGLNativeMethods.cgGLSetParameter3d(param.Handle, v1.X, v1.Y, v1.Z);
        }

        public static void Set(this Parameter param, Vector4 v)
        {
            Vector4 v1 = v;
            CgGLNativeMethods.cgGLSetParameter4f(param.Handle, v1.X, v1.Y, v1.Z, v1.W);
        }

        public static void Set(this Parameter param, Vector4d v)
        {
            Vector4d v1 = v;
            CgGLNativeMethods.cgGLSetParameter4d(param.Handle, v1.X, v1.Y, v1.Z, v1.W);
        }

        public static void SetArray(this Parameter param, int offset, int nelements, float[] values)
        {
            IntPtr param1 = param.Handle;
            switch (values.Length / nelements)
            {
                case 1:
                    CgGLNativeMethods.cgGLSetParameterArray1f(param1, offset, nelements, values);
                    break;
                case 2:
                    CgGLNativeMethods.cgGLSetParameterArray2f(param1, offset, nelements, values);
                    break;
                case 3:
                    CgGLNativeMethods.cgGLSetParameterArray3f(param1, offset, nelements, values);
                    break;
                case 4:
                    CgGLNativeMethods.cgGLSetParameterArray4f(param1, offset, nelements, values);
                    break;
            }
        }

        public static void SetArray(this Parameter param, int offset, int nelements, double[] values)
        {
            IntPtr param1 = param.Handle;
            switch (values.Length / nelements)
            {
                case 1:
                    CgGLNativeMethods.cgGLSetParameterArray1d(param1, offset, nelements, values);
                    break;
                case 2:
                    CgGLNativeMethods.cgGLSetParameterArray2d(param1, offset, nelements, values);
                    break;
                case 3:
                    CgGLNativeMethods.cgGLSetParameterArray3d(param1, offset, nelements, values);
                    break;
                case 4:
                    CgGLNativeMethods.cgGLSetParameterArray4d(param1, offset, nelements, values);
                    break;
            }
        }

        public static void SetMatrix(this Parameter param, Matrix4 matrix)
        {
            IntPtr param1 = param.Handle;
            Order order = Order.RowMajor;
            switch (order)
            {
                case Order.ColumnMajor:
                    CgGLNativeMethods.cgGLSetMatrixParameterfc(param1, matrix);
                    break;
                case Order.RowMajor:
                    CgGLNativeMethods.cgGLSetMatrixParameterfr(param1, matrix);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("order");
            }
        }

        public static void SetMatrix(this Parameter param, Matrix4 matrix, Order order)
        {
            IntPtr param1 = param.Handle;
            switch (order)
            {
                case Order.ColumnMajor:
                    CgGLNativeMethods.cgGLSetMatrixParameterfc(param1, matrix);
                    break;
                case Order.RowMajor:
                    CgGLNativeMethods.cgGLSetMatrixParameterfr(param1, matrix);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("order");
            }
        }

        public static void SetMatrix(this Parameter param, Matrix4d matrix)
        {
            CgGL.SetMatrixParameter(param.Handle, matrix, Order.RowMajor);
        }

        public static void SetMatrix(this Parameter param, Matrix4d matrix, Order order)
        {
            CgGL.SetMatrixParameter(param.Handle, matrix, order);
        }

        public static void SetMatrixArray(this Parameter param, int offset, int nelements, Matrix4d[] matrices)
        {
            CgGL.SetMatrixParameterArray(param.Handle, offset, nelements, matrices, Order.RowMajor);
        }

        public static void SetMatrixArray(this Parameter param, int offset, int nelements, Matrix4[] matrices)
        {
            CgGL.SetMatrixParameterArray(param.Handle, offset, nelements, matrices, Order.RowMajor);
        }

        public static void SetMatrixArray(this Parameter param, int offset, int nelements, Matrix4d[] matrices, Order order)
        {
            CgGL.SetMatrixParameterArray(param.Handle, offset, nelements, matrices, order);
        }

        public static void SetMatrixArray(this Parameter param, int offset, int nelements, Matrix4[] matrices, Order order)
        {
            CgGL.SetMatrixParameterArray(param.Handle, offset, nelements, matrices, order);
        }

        public static void SetPointer(this Parameter param, int fsize, DataType type, int stride, IntPtr pointer)
        {
            CgGLNativeMethods.cgGLSetParameterPointer(param.Handle, fsize, type, stride, pointer);
        }

        public static void SetStateMatrix(this Parameter param, MatrixType matrix, MatrixTransform transform)
        {
            CgGLNativeMethods.cgGLSetStateMatrixParameter(param.Handle, matrix, transform);
        }

        // TODO: TextureParameter
        public static void SetTexture(this Parameter param, int texobj)
        {
            CgGLNativeMethods.cgGLSetTextureParameter(param.Handle, texobj);
        }

        public static void SetupSampler(this Parameter param, int texobj)
        {
            CgGLNativeMethods.cgGLSetupSampler(param.Handle, texobj);
        }

        #endregion Public Static Methods

        #endregion Methods
    }
}