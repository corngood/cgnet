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
namespace CgOO.GL
{
    using System;

    using CgNet;
    using CgNet.GL;

    using CgOO;

    using OpenTK;
    using OpenTK.Graphics.OpenGL;

    public static class CgOOGL
    {
        #region Methods

        #region Public Static Methods

        public static void BindProgram(this CgProgram program)
        {
            CgGL.BindProgram(program.Handle);
        }

        public static CgBuffer CreateBuffer(this CgContext context, int size, IntPtr data, BufferUsageHint bufferUsage)
        {
            return new CgBuffer(CgGL.CreateBuffer(context.Handle, size, data, bufferUsage));
        }

        public static void DisableClientState(this CgParameter param)
        {
            CgGL.DisableClientState(param.Handle);
        }

        public static void DisableProgramProfiles(this CgProgram program)
        {
            CgGL.DisableProgramProfiles(program.Handle);
        }

        public static void DisableTextureParameter(this CgParameter param)
        {
            CgGL.DisableTextureParameter(param.Handle);
        }

        public static void EnableClientState(this CgParameter param)
        {
            CgGL.EnableClientState(param.Handle);
        }

        public static void EnableProgramProfiles(this CgProgram program)
        {
            CgGL.EnableProgramProfiles(program.Handle);
        }

        public static void EnableTextureParameter(this CgParameter param)
        {
            CgGL.EnableTextureParameter(param.Handle);
        }

        public static int GetBufferObject(this CgBuffer buffer)
        {
            return CgGL.GetBufferObject(buffer.Handle);
        }

        public static bool GetManageTextureParameters(this CgContext context)
        {
            return CgGL.GetManageTextureParameters(context.Handle);
        }

        public static void GetMatrixParameter(this CgParameter param, out Matrix4 value)
        {
            CgGL.GetMatrixParameter(param.Handle, out value);
        }

        public static void GetMatrixParameter(this CgParameter param, out Matrix4d value)
        {
            CgGL.GetMatrixParameter(param.Handle, out value);
        }

        public static T GetMatrixParameter<T>(this CgParameter param)
            where T : struct
        {
            return CgGL.GetMatrixParameter<T>(param.Handle);
        }

        public static T GetMatrixParameter<T>(this CgParameter param, Order order)
            where T : struct
        {
            return CgGL.GetMatrixParameter<T>(param.Handle, order);
        }

        public static void GetMatrixParameterArray(this CgParameter param, int offset, int nelements, out Matrix4[] values)
        {
            CgGL.GetMatrixParameterArray(param.Handle, offset, nelements, out values);
        }

        public static void GetMatrixParameterArray(this CgParameter param, int offset, int nelements, out Matrix4d[] values)
        {
            CgGL.GetMatrixParameterArray(param.Handle, offset, nelements, out values);
        }

        public static T[] GetMatrixParameterArray<T>(this CgParameter param, int offset, int nelements)
            where T : struct
        {
            return CgGL.GetMatrixParameterArray<T>(param.Handle, offset, nelements, Order.RowMajor);
        }

        public static T[] GetMatrixParameterArray<T>(this CgParameter param, int offset, int nelements, Order order)
            where T : struct
        {
            return CgGL.GetMatrixParameterArray<T>(param.Handle, offset, nelements, order);
        }

        public static T GetParameter<T>(this CgParameter param)
            where T : struct
        {
            return CgGL.GetParameter<T>(param.Handle);
        }

        public static void GetParameter(this CgParameter param, ref float[] values)
        {
            CgGL.GetParameter(param.Handle, ref values);
        }

        public static void GetParameter(this CgParameter param, ref double[] values)
        {
            CgGL.GetParameter(param.Handle, ref values);
        }

        public static void GetParameterArray(this CgParameter param, int offset, int nelements, ref float[] values)
        {
            CgGL.GetParameterArray(param.Handle, offset, nelements, ref values);
        }

        public static void GetParameterArray(this CgParameter param, int offset, int nelements, ref double[] values)
        {
            CgGL.GetParameterArray(param.Handle, offset, nelements, ref values);
        }

        public static int GetProgramID(this CgProgram program)
        {
            return CgGL.GetProgramID(program.Handle);
        }

        public static int GetTextureEnum(this CgParameter param)
        {
            return CgGL.GetTextureEnum(param.Handle);
        }

        public static int GetTextureParameter(this CgParameter param)
        {
            return CgGL.GetTextureParameter(param.Handle);
        }

        public static bool IsLoaded(this CgProgram program)
        {
            return CgGL.IsProgramLoaded(program.Handle);
        }

        public static void Load(this CgProgram program)
        {
            CgGL.LoadProgram(program.Handle);
        }

        public static void RegisterStates(this CgContext context)
        {
            CgGL.RegisterStates(context.Handle);
        }

        public static void Set(this CgParameter param, double x)
        {
            CgGL.SetParameter(param.Handle, x);
        }

        public static void Set(this CgParameter param, double[] v)
        {
            CgGL.SetParameter(param.Handle, v);
        }

        public static void Set(this CgParameter param, float[] v)
        {
            CgGL.SetParameter(param.Handle, v);
        }

        public static void Set(this CgParameter param, float x)
        {
            CgGL.SetParameter(param.Handle, x);
        }

        public static void Set(this CgParameter param, double x, double y)
        {
            CgGL.SetParameter(param.Handle, x, y);
        }

        public static void Set(this CgParameter param, float x, float y)
        {
            CgGL.SetParameter(param.Handle, x, y);
        }

        public static void Set(this CgParameter param, double x, double y, double z)
        {
            CgGL.SetParameter(param.Handle, x, y, z);
        }

        public static void Set(this CgParameter param, float x, float y, float z)
        {
            CgGL.SetParameter(param.Handle, x, y, z);
        }

        public static void Set(this CgParameter param, double x, double y, double z, double w)
        {
            CgGL.SetParameter(param.Handle, x, y, z, w);
        }

        public static void Set(this CgParameter param, float x, float y, float z, float w)
        {
            CgGL.SetParameter(param.Handle, x, y, z, w);
        }

        public static void Set(this CgParameter param, Vector2 v)
        {
            CgGL.SetParameter(param.Handle, v);
        }

        public static void Set(this CgParameter param, Vector2d v)
        {
            CgGL.SetParameter(param.Handle, v);
        }

        public static void Set(this CgParameter param, Vector3 v)
        {
            CgGL.SetParameter(param.Handle, v);
        }

        public static void Set(this CgParameter param, Vector3d v)
        {
            CgGL.SetParameter(param.Handle, v);
        }

        public static void Set(this CgParameter param, Vector4 v)
        {
            CgGL.SetParameter(param.Handle, v);
        }

        public static void Set(this CgParameter param, Vector4d v)
        {
            CgGL.SetParameter(param.Handle, v);
        }

        public static void SetArray(this CgParameter param, int offset, int nelements, float[] values)
        {
            CgGL.SetParameterArray(param.Handle, offset, nelements, values);
        }

        public static void SetArray(this CgParameter param, int offset, int nelements, double[] values)
        {
            CgGL.SetParameterArray(param.Handle, offset, nelements, values);
        }

        public static void SetManageTextureParameters(this CgContext context, bool flag)
        {
            CgGL.SetManageTextureParameters(context.Handle, flag);
        }

        public static void SetMatrixParameter(this CgParameter param, Matrix4 matrix)
        {
            CgGL.SetMatrixParameter(param.Handle, matrix);
        }

        public static void SetMatrixParameter(this CgParameter param, Matrix4 matrix, Order order)
        {
            CgGL.SetMatrixParameter(param.Handle, matrix, order);
        }

        public static void SetMatrixParameter(this CgParameter param, Matrix4d matrix)
        {
            CgGL.SetMatrixParameter(param.Handle, matrix);
        }

        public static void SetMatrixParameter(this CgParameter param, Matrix4d matrix, Order order)
        {
            CgGL.SetMatrixParameter(param.Handle, matrix, order);
        }

        public static void SetMatrixParameterArray(this CgParameter param, int offset, int nelements, Matrix4d[] matrices)
        {
            CgGL.SetMatrixParameterArray(param.Handle, offset, nelements, matrices);
        }

        public static void SetMatrixParameterArray(this CgParameter param, int offset, int nelements, Matrix4[] matrices)
        {
            CgGL.SetMatrixParameterArray(param.Handle, offset, nelements, matrices);
        }

        public static void SetMatrixParameterArray(this CgParameter param, int offset, int nelements, Matrix4d[] matrices, Order order)
        {
            CgGL.SetMatrixParameterArray(param.Handle, offset, nelements, matrices, order);
        }

        public static void SetMatrixParameterArray(this CgParameter param, int offset, int nelements, Matrix4[] matrices, Order order)
        {
            CgGL.SetMatrixParameterArray(param.Handle, offset, nelements, matrices, order);
        }

        public static void SetPointer(this CgParameter param, int fsize, DataType type, int stride, IntPtr pointer)
        {
            CgGL.SetParameterPointer(param.Handle, fsize, type, stride, pointer);
        }

        public static void SetStateMatrix(this CgParameter param, MatrixType matrix, MatrixTransform transform)
        {
            CgGL.SetStateMatrixParameter(param.Handle, matrix, transform);
        }

        public static void SetTexture(this CgParameter param, int texobj)
        {
            CgGL.SetTextureParameter(param.Handle, texobj);
        }

        public static void SetupSampler(this CgParameter param, int texobj)
        {
            CgGL.SetupSampler(param.Handle, texobj);
        }

        public static void Unload(this CgProgram program)
        {
            CgGL.UnloadProgram(program.Handle);
        }

        #endregion Public Static Methods

        #endregion Methods
    }
}