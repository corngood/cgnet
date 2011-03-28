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

    using CgNet;
    using CgNet.GL;

    public static class CgGLProgram
    {
        #region Methods

        #region Public Static Methods

        public static void Bind(this Program program)
        {
            CgGLNativeMethods.cgGLBindProgram(program.Handle);
        }

        public static void DisableProgramProfiles(this Program program)
        {
            CgGLNativeMethods.cgGLDisableProgramProfiles(program.Handle);
        }

        public static void EnableProgramProfiles(this Program program)
        {
            CgGLNativeMethods.cgGLEnableProgramProfiles(program.Handle);
        }

        public static int GetProgramID(this Program program)
        {
            return CgGLNativeMethods.cgGLGetProgramID(program.Handle);
        }

        public static bool IsLoaded(this Program program)
        {
            return CgGLNativeMethods.cgGLIsProgramLoaded(program.Handle);
        }

        public static void Load(this Program program)
        {
            CgGLNativeMethods.cgGLLoadProgram(program.Handle);
        }

        public static void Unload(this Program program)
        {
            CgGLNativeMethods.cgGLUnloadProgram(program.Handle);
        }

        #endregion Public Static Methods

        #endregion Methods
    }
}