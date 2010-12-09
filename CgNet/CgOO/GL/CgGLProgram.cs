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
    using CgNet.GL;

    using CgOO;

    public static class CgGLProgram
    {
        #region Methods

        #region Public Static Methods

        public static void BindProgram(this CgProgram program)
        {
            CgGL.BindProgram(program.Handle);
        }

        public static void DisableProgramProfiles(this CgProgram program)
        {
            CgGL.DisableProgramProfiles(program.Handle);
        }

        public static void EnableProgramProfiles(this CgProgram program)
        {
            CgGL.EnableProgramProfiles(program.Handle);
        }

        public static int GetProgramID(this CgProgram program)
        {
            return CgGL.GetProgramID(program.Handle);
        }

        public static bool IsLoaded(this CgProgram program)
        {
            return CgGL.IsProgramLoaded(program.Handle);
        }

        public static void Load(this CgProgram program)
        {
            CgGL.LoadProgram(program.Handle);
        }

        public static void Unload(this CgProgram program)
        {
            CgGL.UnloadProgram(program.Handle);
        }

        #endregion Public Static Methods

        #endregion Methods
    }
}