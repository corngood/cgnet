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
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Text;

    using OpenTK;
    using OpenTK.Graphics.OpenGL;

    public static class CgGL
    {
        #region Methods

        #region Public Static Methods

        public static void BindProgram(IntPtr program)
        {
            CgGLNativeMethods.cgGLBindProgram(program);
        }

        public static IntPtr CreateBuffer(IntPtr context, int size, IntPtr data, BufferUsageHint bufferUsage)
        {
            return CgGLNativeMethods.cgGLCreateBuffer(context, size, data, bufferUsage);
        }

        public static void DisableClientState(IntPtr param)
        {
            CgGLNativeMethods.cgGLDisableClientState(param);
        }

        public static void DisableProfile(CgProfile profile)
        {
            CgGLNativeMethods.cgGLDisableProfile(profile);
        }

        public static void DisableProgramProfiles(IntPtr program)
        {
            CgGLNativeMethods.cgGLDisableProgramProfiles(program);
        }

        public static void DisableTextureParameter(IntPtr param)
        {
            CgGLNativeMethods.cgGLDisableTextureParameter(param);
        }

        public static void EnableClientState(IntPtr param)
        {
            CgGLNativeMethods.cgGLEnableClientState(param);
        }

        public static void EnableProfile(CgProfile profile)
        {
            CgGLNativeMethods.cgGLEnableProfile(profile);
        }

        public static void EnableProgramProfiles(IntPtr program)
        {
            CgGLNativeMethods.cgGLEnableProgramProfiles(program);
        }

        public static void EnableTextureParameter(IntPtr param)
        {
            CgGLNativeMethods.cgGLEnableTextureParameter(param);
        }

        public static int GetBufferObject(IntPtr buffer)
        {
            return CgGLNativeMethods.cgGLGetBufferObject(buffer);
        }

        public static CgProfile GetLatestProfile(ProfileClass profileClass)
        {
            return CgGLNativeMethods.cgGLGetLatestProfile(profileClass);
        }

        public static int GetManageTextureParameters(IntPtr context)
        {
            return CgGLNativeMethods.cgGLGetManageTextureParameters(context);
        }

        public static T GetMatrixParameter<T>(IntPtr param)
            where T : struct
        {
            return GetMatrixParameter<T>(param, Order.RowMajor);
        }

        public static T GetMatrixParameter<T>(IntPtr param, Order order)
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

        public static T[] GetMatrixParameterArray<T>(IntPtr param, int offset, int nelements)
        {
            return GetMatrixParameterArray<T>(param, offset, nelements, Order.RowMajor);
        }

        public static T[] GetMatrixParameterArray<T>(IntPtr param, int offset, int nelements, Order order)
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

        public static T GetParameter<T>(IntPtr param)
            where T : struct
        {
            GCHandle handle = GCHandle.Alloc(new T(), GCHandleType.Pinned);
            try
            {
                if (typeof(T) == typeof(float))
                {
                    CgGLNativeMethods.cgGLGetParameter1f(param, handle.AddrOfPinnedObject());
                }
                else if (typeof(T) == typeof(double))
                {
                    CgGLNativeMethods.cgGLGetParameter1d(param, handle.AddrOfPinnedObject());
                }
                else if (typeof(T) == typeof(Vector2))
                {
                    CgGLNativeMethods.cgGLGetParameter2f(param, handle.AddrOfPinnedObject());
                }
                else if (typeof(T) == typeof(Vector2d))
                {
                    CgGLNativeMethods.cgGLGetParameter2d(param, handle.AddrOfPinnedObject());
                }
                else if (typeof(T) == typeof(Vector3))
                {
                    CgGLNativeMethods.cgGLGetParameter3f(param, handle.AddrOfPinnedObject());
                }
                else if (typeof(T) == typeof(Vector3d))
                {
                    CgGLNativeMethods.cgGLGetParameter3d(param, handle.AddrOfPinnedObject());
                }
                else if (typeof(T) == typeof(Vector4))
                {
                    CgGLNativeMethods.cgGLGetParameter4f(param, handle.AddrOfPinnedObject());
                }
                else if (typeof(T) == typeof(Vector4d))
                {
                    CgGLNativeMethods.cgGLGetParameter4d(param, handle.AddrOfPinnedObject());
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

        public static void GetParameter(IntPtr param, ref float[] values)
        {
            GCHandle handle = GCHandle.Alloc(values, GCHandleType.Pinned);
            try
            {
                switch (values.Length)
                {
                    case 1:
                        CgGLNativeMethods.cgGLGetParameter1f(param, handle.AddrOfPinnedObject());
                        break;
                    case 2:
                        CgGLNativeMethods.cgGLGetParameter2f(param, handle.AddrOfPinnedObject());
                        break;
                    case 3:
                        CgGLNativeMethods.cgGLGetParameter3f(param, handle.AddrOfPinnedObject());
                        break;
                    case 4:
                        CgGLNativeMethods.cgGLGetParameter4f(param, handle.AddrOfPinnedObject());
                        break;
                }
            }
            finally
            {
                handle.Free();
            }
        }

        public static void GetParameter(IntPtr param, ref double[] values)
        {
            GCHandle handle = GCHandle.Alloc(values);
            try
            {
                switch (values.Length)
                {
                    case 1:
                        CgGLNativeMethods.cgGLGetParameter1d(param, handle.AddrOfPinnedObject());
                        break;
                    case 2:
                        CgGLNativeMethods.cgGLGetParameter2d(param, handle.AddrOfPinnedObject());
                        break;
                    case 3:
                        CgGLNativeMethods.cgGLGetParameter3d(param, handle.AddrOfPinnedObject());
                        break;
                    case 4:
                        CgGLNativeMethods.cgGLGetParameter4d(param, handle.AddrOfPinnedObject());
                        break;
                }
            }
            finally
            {
                handle.Free();
            }
        }

        public static void GetParameterArray(IntPtr param, int offset, int nelements, ref float[] values)
        {
            GCHandle g = GCHandle.Alloc(values, GCHandleType.Pinned);

            try
            {
                switch (values.Length / nelements)
                {
                    case 1:
                        CgGLNativeMethods.cgGLGetParameterArray1f(param, offset, nelements, g.AddrOfPinnedObject());
                        break;
                    case 2:
                        CgGLNativeMethods.cgGLGetParameterArray2f(param, offset, nelements, g.AddrOfPinnedObject());
                        break;
                    case 3:
                        CgGLNativeMethods.cgGLGetParameterArray3f(param, offset, nelements, g.AddrOfPinnedObject());
                        break;
                    case 4:
                        CgGLNativeMethods.cgGLGetParameterArray4f(param, offset, nelements, g.AddrOfPinnedObject());
                        break;
                }
            }
            finally
            {
                g.Free();
            }
        }

        public static void GetParameterArray(IntPtr param, int offset, int nelements, ref double[] values)
        {
            GCHandle g = GCHandle.Alloc(values, GCHandleType.Pinned);

            try
            {
                switch (values.Length / nelements)
                {
                    case 1:
                        CgGLNativeMethods.cgGLGetParameterArray1d(param, offset, nelements, g.AddrOfPinnedObject());
                        break;
                    case 2:
                        CgGLNativeMethods.cgGLGetParameterArray2d(param, offset, nelements, g.AddrOfPinnedObject());
                        break;
                    case 3:
                        CgGLNativeMethods.cgGLGetParameterArray3d(param, offset, nelements, g.AddrOfPinnedObject());
                        break;
                    case 4:
                        CgGLNativeMethods.cgGLGetParameterArray4d(param, offset, nelements, g.AddrOfPinnedObject());
                        break;
                }
            }
            finally
            {
                g.Free();
            }
        }

        public static int GetProgramID(IntPtr program)
        {
            return CgGLNativeMethods.cgGLGetProgramID(program);
        }

        public static int GetTextureEnum(IntPtr param)
        {
            return CgGLNativeMethods.cgGLGetTextureEnum(param);
        }

        public static int GetTextureParameter(IntPtr param)
        {
            return CgGLNativeMethods.cgGLGetTextureParameter(param);
        }

        public static string[] GLGetOptimalOptions(CgProfile profile)
        {
            var ptr = CgGLNativeMethods.cgGLGetOptimalOptions(profile);
            unsafe
            {
                var byteArray = (byte**)ptr;
                var lines = new List<string>();
                var buffer = new List<byte>();

                for (; ; )
                {
                    byte* b = *byteArray;
                    for (; ; )
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

                    if (*byteArray == null)
                    {
                        break;
                    }
                }

                return lines.ToArray();
            }
        }

        public static bool IsProfileSupported(CgProfile profile)
        {
            return CgGLNativeMethods.cgGLIsProfileSupported(profile);
        }

        public static bool IsProgramLoaded(IntPtr program)
        {
            return CgGLNativeMethods.cgGLIsProgramLoaded(program);
        }

        public static void LoadProgram(IntPtr program)
        {
            CgGLNativeMethods.cgGLLoadProgram(program);
        }

        public static void RegisterStates(IntPtr context)
        {
            CgGLNativeMethods.cgGLRegisterStates(context);
        }

        public static void SetDebugMode(bool debug)
        {
            CgGLNativeMethods.cgGLSetDebugMode(debug);
        }

        public static void SetManageTextureParameters(IntPtr context, bool flag)
        {
            CgGLNativeMethods.cgGLSetManageTextureParameters(context, flag);
        }

        public static void SetMatrixParameter(IntPtr param, Matrix4 matrix)
        {
            SetMatrixParameter(param, matrix, Order.RowMajor);
        }

        public static void SetMatrixParameter(IntPtr param, Matrix4 matrix, Order order)
        {
            switch (order)
            {
                case Order.ColumnMajor:
                    CgGLNativeMethods.cgGLSetMatrixParameterfc(param, matrix);
                    break;
                case Order.RowMajor:
                    CgGLNativeMethods.cgGLSetMatrixParameterfr(param, matrix);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("order");
            }
        }

        public static void SetMatrixParameter(IntPtr param, Matrix4d matrix)
        {
            SetMatrixParameter(param, matrix, Order.RowMajor);
        }

        public static void SetMatrixParameter(IntPtr param, Matrix4d matrix, Order order)
        {
            switch (order)
            {
                case Order.ColumnMajor:
                    CgGLNativeMethods.cgGLSetMatrixParameterdc(param, matrix);
                    break;
                case Order.RowMajor:
                    CgGLNativeMethods.cgGLSetMatrixParameterdr(param, matrix);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("order");
            }
        }

        public static void SetMatrixParameterArray(IntPtr param, int offset, int nelements, Matrix4d[] matrices)
        {
            SetMatrixParameterArray(param, offset, nelements, matrices, Order.RowMajor);
        }

        public static void SetMatrixParameterArray(IntPtr param, int offset, int nelements, Matrix4[] matrices)
        {
            SetMatrixParameterArray(param, offset, nelements, matrices, Order.RowMajor);
        }

        public static void SetMatrixParameterArray(IntPtr param, int offset, int nelements, Matrix4d[] matrices, Order order)
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

        public static void SetMatrixParameterArray(IntPtr param, int offset, int nelements, Matrix4[] matrices, Order order)
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

        public static void SetOptimalOptions(CgProfile profile)
        {
            CgGLNativeMethods.cgGLSetOptimalOptions(profile);
        }

        public static void SetParameter(IntPtr param, double x)
        {
            CgGLNativeMethods.cgGLSetParameter1d(param, x);
        }

        public static void SetParameter(IntPtr param, double[] v)
        {
            switch (v.Length)
            {
                case 1:
                    CgGLNativeMethods.cgGLSetParameter1dv(param, v);
                    break;
                case 2:
                    CgGLNativeMethods.cgGLSetParameter2dv(param, v);
                    break;
                case 3:
                    CgGLNativeMethods.cgGLSetParameter3dv(param, v);
                    break;
                case 4:
                    CgGLNativeMethods.cgGLSetParameter4dv(param, v);
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        public static void SetParameter(IntPtr param, float[] v)
        {
            switch (v.Length)
            {
                case 1:
                    CgGLNativeMethods.cgGLSetParameter1fv(param, v);
                    break;
                case 2:
                    CgGLNativeMethods.cgGLSetParameter2fv(param, v);
                    break;
                case 3:
                    CgGLNativeMethods.cgGLSetParameter3fv(param, v);
                    break;
                case 4:
                    CgGLNativeMethods.cgGLSetParameter4fv(param, v);
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        public static void SetParameter(IntPtr param, float x)
        {
            CgGLNativeMethods.cgGLSetParameter1f(param, x);
        }

        public static void SetParameter(IntPtr param, double x, double y)
        {
            CgGLNativeMethods.cgGLSetParameter2d(param, x, y);
        }

        public static void SetParameter(IntPtr param, float x, float y)
        {
            CgGLNativeMethods.cgGLSetParameter2f(param, x, y);
        }

        public static void SetParameter(IntPtr param, double x, double y, double z)
        {
            CgGLNativeMethods.cgGLSetParameter3d(param, x, y, z);
        }

        public static void SetParameter(IntPtr param, float x, float y, float z)
        {
            CgGLNativeMethods.cgGLSetParameter3f(param, x, y, z);
        }

        public static void SetParameter(IntPtr param, double x, double y, double z, double w)
        {
            CgGLNativeMethods.cgGLSetParameter4d(param, x, y, z, w);
        }

        public static void SetParameter(IntPtr param, float x, float y, float z, float w)
        {
            CgGLNativeMethods.cgGLSetParameter4f(param, x, y, z, w);
        }

        public static void SetParameter(IntPtr param, Vector2 v)
        {
            SetParameter(param, v.X, v.Y);
        }

        public static void SetParameter(IntPtr param, Vector2d v)
        {
            SetParameter(param, v.X, v.Y);
        }

        public static void SetParameter(IntPtr param, Vector3 v)
        {
            SetParameter(param, v.X, v.Y, v.Z);
        }

        public static void SetParameter(IntPtr param, Vector3d v)
        {
            SetParameter(param, v.X, v.Y, v.Z);
        }

        public static void SetParameter(IntPtr param, Vector4 v)
        {
            SetParameter(param, v.X, v.Y, v.Z, v.W);
        }

        public static void SetParameter(IntPtr param, Vector4d v)
        {
            SetParameter(param, v.X, v.Y, v.Z, v.W);
        }

        public static void SetParameterArray(IntPtr param, int offset, int nelements, float[] values)
        {
            switch (values.Length / nelements)
            {
                case 1:
                    CgGLNativeMethods.cgGLSetParameterArray1f(param, offset, nelements, values);
                    break;
                case 2:
                    CgGLNativeMethods.cgGLSetParameterArray2f(param, offset, nelements, values);
                    break;
                case 3:
                    CgGLNativeMethods.cgGLSetParameterArray3f(param, offset, nelements, values);
                    break;
                case 4:
                    CgGLNativeMethods.cgGLSetParameterArray4f(param, offset, nelements, values);
                    break;
            }
        }

        public static void SetParameterArray(IntPtr param, int offset, int nelements, double[] values)
        {
            switch (values.Length / nelements)
            {
                case 1:
                    CgGLNativeMethods.cgGLSetParameterArray1d(param, offset, nelements, values);
                    break;
                case 2:
                    CgGLNativeMethods.cgGLSetParameterArray2d(param, offset, nelements, values);
                    break;
                case 3:
                    CgGLNativeMethods.cgGLSetParameterArray3d(param, offset, nelements, values);
                    break;
                case 4:
                    CgGLNativeMethods.cgGLSetParameterArray4d(param, offset, nelements, values);
                    break;
            }
        }

        public static void SetParameterPointer(IntPtr param, int fsize, DataType type, int stride, IntPtr pointer)
        {
            CgGLNativeMethods.cgGLSetParameterPointer(param, fsize, type, stride, pointer);
        }

        public static void SetStateMatrixParameter(IntPtr param, MatrixType matrix, MatrixTransform transform)
        {
            CgGLNativeMethods.cgGLSetStateMatrixParameter(param, matrix, transform);
        }

        public static void SetTextureParameter(IntPtr param, int texobj)
        {
            CgGLNativeMethods.cgGLSetTextureParameter(param, texobj);
        }

        public static void SetupSampler(IntPtr param, int texobj)
        {
            CgGLNativeMethods.cgGLSetupSampler(param, texobj);
        }

        public static void UnbindProgram(CgProfile profile)
        {
            CgGLNativeMethods.cgGLUnbindProgram(profile);
        }

        public static void UnloadProgram(IntPtr program)
        {
            CgGLNativeMethods.cgGLUnloadProgram(program);
        }

        #endregion Public Static Methods

        #endregion Methods
    }
}