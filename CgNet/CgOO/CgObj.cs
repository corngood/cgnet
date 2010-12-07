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
namespace CgOO
{
    using System;

    using CgNet;

    public sealed class CgObj : WrapperObject
    {
        #region Constructors

        internal CgObj(IntPtr handle)
            : base(handle)
        {
        }

        #endregion Constructors

        #region Methods

        #region Public Static Methods

        public static CgObj Create(CgContext context, ProgramType programType, string source, ProfileType profile, params string[] args)
        {
            return new CgObj(Cg.CreateObj(context.Handle, programType, source, profile, args));
        }

        public static CgObj CreateFromFile(CgContext context, ProgramType programType, string sourceFile, ProfileType profile, params string[] args)
        {
            return new CgObj(Cg.CreateObjFromFile(context.Handle, programType, sourceFile, profile, args));
        }

        #endregion Public Static Methods

        #region Protected Methods

        protected override void Dispose(bool disposing)
        {
            if (this.Handle != IntPtr.Zero)
            {
                Cg.DestroyObj(this.Handle);
            }
        }

        #endregion Protected Methods

        #endregion Methods
    }
}