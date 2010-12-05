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

    using CgNet.Wrapper;

    public static class CgGL
    {
        #region Methods

        #region Public Static Methods

        public static void BindProgram(IntPtr program)
        {
            CgGLNativeMethods.cgGLBindProgram(program);
        }

        public static void DisableProfile(CgProfile profile)
        {
            CgGLNativeMethods.cgGLDisableProfile(profile);
        }

        public static void DisableTextureParameter(IntPtr param)
        {
            CgGLNativeMethods.cgGLDisableTextureParameter(param);
        }

        public static void EnableProfile(CgProfile profile)
        {
            CgGLNativeMethods.cgGLEnableProfile(profile);
        }

        public static void EnableTextureParameter(IntPtr param)
        {
            CgGLNativeMethods.cgGLEnableTextureParameter(param);
        }

        public static CgProfile GetLatestProfile(ProfileClass profileClass)
        {
            return CgGLNativeMethods.cgGLGetLatestProfile(profileClass);
        }

        public static void LoadProgram(IntPtr program)
        {
            CgGLNativeMethods.cgGLLoadProgram(program);
        }

        public static void SetDebugMode(bool debug)
        {
            CgGLNativeMethods.cgGLSetDebugMode(debug ? CgNativeMethods.CgTrue : CgNativeMethods.CgFalse);
        }

        public static void SetOptimalOptions(CgProfile profile)
        {
            CgGLNativeMethods.cgGLSetOptimalOptions(profile);
        }

        public static void SetTextureParameter(IntPtr param, int texobj)
        {
            CgGLNativeMethods.cgGLSetTextureParameter(param, texobj);
        }

        #endregion Public Static Methods

        #endregion Methods
    }
}