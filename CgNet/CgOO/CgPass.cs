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
namespace CgNet.CgOO
{
    using System;

    public sealed class CgPass : WrapperObject
    {
        #region Constructors

        internal CgPass(IntPtr handle)
            : base(handle)
        {
        }

        #endregion Constructors

        #region Properties

        #region Public Properties

        public bool IsPass
        {
            get
            {
                return Cg.IsPass(this.Handle);
            }
        }

        public string Name
        {
            get
            {
                return Cg.GetPassName(this.Handle);
            }
        }

        public CgPass NextPass
        {
            get
            {
                var ptr = Cg.GetNextPass(this.Handle);

                return ptr == IntPtr.Zero ? null : new CgPass(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public CgTechnique Technique
        {
            get
            {
                var ptr = Cg.GetPassTechnique(this.Handle);

                return ptr == IntPtr.Zero ? null : new CgTechnique(ptr)
                {
                    OwnsHandle = false
                };
            }
        }

        #endregion Public Properties

        #endregion Properties

        #region Methods

        #region Public Static Methods

        public static CgPass Create(CgTechnique technique, string name)
        {
            return new CgPass(Cg.CreatePass(technique.Handle, name));
        }

        #endregion Public Static Methods

        #region Public Methods

        public CgProgram GetProgram(Domain domain)
        {
            var ptr = Cg.GetPassProgram(this.Handle, domain);

            return ptr == IntPtr.Zero ? null : new CgProgram(ptr)
            {
                OwnsHandle = false
            };
        }

        public void ResetState()
        {
            Cg.ResetPassState(this.Handle);
        }

        public void SetState()
        {
            Cg.SetPassState(this.Handle);
        }

        public void UpdateParameters(CgPass pass)
        {
            Cg.UpdatePassParameters(this.Handle);
        }

        #endregion Public Methods

        #endregion Methods
    }
}