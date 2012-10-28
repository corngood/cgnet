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
namespace CgNet.GL
{
    using System;

    using Buffer = CgNet.Buffer;

    using OpenTK.Graphics.OpenGL;

    public static class CgGLContext
    {
        #region Methods

        #region Public Static Methods

        public static Buffer CreateBuffer(this Context context, int size, IntPtr data, BufferUsageHint bufferUsage)
        {
            return new Buffer(NativeMethods.cgGLCreateBuffer(context.Handle, size, data, bufferUsage));
        }

        public static Buffer CreateBufferFromObject(this Context context, OpenTK.Graphics.OpenGL.BufferUsageHint flags, bool manageObject)
        {
            var retValue = new Buffer(NativeMethods.cgGLCreateBufferFromObject(context.Handle, flags, manageObject));
            retValue.OwnsHandle = !manageObject;
            return retValue;
        }

        public static GlslVersion GetGlslVersion(this Context context)
        {
            return NativeMethods.cgGLGetContextGLSLVersion(context.Handle);
        }

        public static bool GetManageTextureParameters(this Context context)
        {
            return NativeMethods.cgGLGetManageTextureParameters(context.Handle);
        }

        public static string[] GetOptimalOptions(this Context context, ProfileType profile)
        {
            return Cg.IntPtrToStringArray(NativeMethods.cgGLGetContextOptimalOptions(context.Handle, profile));
        }

        public static void RegisterStates(this Context context)
        {
            NativeMethods.cgGLRegisterStates(context.Handle);
        }

        public static void SetGlslVersion(this Context context, GlslVersion version)
        {
            NativeMethods.cgGLSetContextGLSLVersion(context.Handle, version);
        }

        public static void SetManageTextureParameters(this Context context, bool flag)
        {
            NativeMethods.cgGLSetManageTextureParameters(context.Handle, flag);
        }

        public static void SetOptimalOptions(this Context context, ProfileType profile)
        {
            NativeMethods.cgGLSetContextOptimalOptions(context.Handle, profile);
        }

        #endregion Public Static Methods

        #endregion Methods
    }
}