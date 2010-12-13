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
namespace CgOO.D3D9
{
    using System;

    using CgNet.D3D9;

    using SlimDX.Direct3D9;

    public static class CgD3D9Parameter
    {
        #region Methods

        #region Public Static Methods

        public static BaseTexture GetTextureParameter(this CgParameter param)
        {
            return (BaseTexture)Resource.FromPointer(CgD3D9NativeMethods.cgD3D9GetTextureParameter(param.Handle));
        }

        public static int SetSamplerState(this CgParameter param, SlimDX.Direct3D9.SamplerState type, int value)
        {
            return CgD3D9NativeMethods.cgD3D9SetSamplerState(param.Handle, type, (uint)value);
        }

        public static int SetTexture(this CgParameter param, BaseTexture tex)
        {
            return CgD3D9NativeMethods.cgD3D9SetTexture(param.Handle, tex.ComPointer);
        }

        public static void SetTextureParameter(this CgParameter param, BaseTexture tex)
        {
            CgD3D9NativeMethods.cgD3D9SetTextureParameter(param.Handle, tex.ComPointer);
        }

        public static int SetTextureWrapMode(this CgParameter param, int value)
        {
            return CgD3D9NativeMethods.cgD3D9SetTextureWrapMode(param.Handle, (uint)value);
        }

        public static int SetUniform(this CgParameter param, float[] floats)
        {
            return CgD3D9NativeMethods.cgD3D9SetUniform(param.Handle, floats);
        }

        public static int SetUniformArray(this CgParameter param, int offset, int numItems, IntPtr values)
        {
            return CgD3D9NativeMethods.cgD3D9SetUniformArray(param.Handle, (uint)offset, (uint)numItems, values);
        }

        public static int SetUniformMatrix(this CgParameter param, SlimDX.Matrix matrix)
        {
            return CgD3D9NativeMethods.cgD3D9SetUniformMatrix(param.Handle, matrix);
        }

        public static int SetUniformMatrixArray(this CgParameter param, int offset, SlimDX.Matrix[] matrices)
        {
            return CgD3D9NativeMethods.cgD3D9SetUniformMatrixArray(param.Handle, (uint)offset, (uint)matrices.Length, matrices);
        }

        #endregion Public Static Methods

        #endregion Methods
    }
}