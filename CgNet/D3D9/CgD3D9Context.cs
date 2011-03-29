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
namespace CgNet.D3D9
{
    public static class CgD3D9Context
    {
        #region Methods

        #region Public Static Methods

        public static bool GetManageTextureParameters(this Context context)
        {
            return CgD3D9NativeMethods.cgD3D9GetManageTextureParameters(context.Handle);
        }

        public static void RegisterStates(this Context ctx)
        {
            CgD3D9NativeMethods.cgD3D9RegisterStates(ctx.Handle);
        }

        public static void SetManageTextureParameters(this Context ctx, bool flag)
        {
            CgD3D9NativeMethods.cgD3D9SetManageTextureParameters(ctx.Handle, flag);
        }

        #endregion Public Static Methods

        #endregion Methods
    }
}