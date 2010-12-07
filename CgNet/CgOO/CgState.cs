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

    public sealed class CgState : WrapperObject
    {
        #region Constructors

        internal CgState(IntPtr handle)
            : base(handle)
        {
        }

        #endregion Constructors

        #region Properties

        #region Public Properties

        public CgContext Context
        {
            get
            {
                var ptr = Cg.GetStateContext(this.Handle);
                return ptr == IntPtr.Zero ? null : new CgContext(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public int EnumerantsCount
        {
            get
            {
                return Cg.GetNumStateEnumerants(this.Handle);
            }
        }

        public bool IsState
        {
            get
            {
                return Cg.IsState(this.Handle);
            }
        }

        public ProfileType LatestProfile
        {
            get
            {
                return Cg.GetStateLatestProfile(this.Handle);
            }
        }

        public string Name
        {
            get
            {
                return Cg.GetStateName(this.Handle);
            }
        }

        public CgState NextState
        {
            get
            {
                var ptr = Cg.GetNextState(this.Handle);
                return ptr == IntPtr.Zero ? null : new CgState(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public Cg.CgStateCallbackDelegate ResetCallback
        {
            get
            {
                return Cg.GetStateResetCallback(this.Handle);
            }
        }

        public Cg.CgStateCallbackDelegate SetCallback
        {
            get
            {
                return Cg.GetStateSetCallback(this.Handle);
            }
        }

        public ParameterType Type
        {
            get
            {
                return Cg.GetStateType(this.Handle);
            }
        }

        public Cg.CgStateCallbackDelegate ValidateCallback
        {
            get
            {
                return Cg.GetStateValidateCallback(this.Handle);
            }
        }

        #endregion Public Properties

        #endregion Properties

        #region Methods

        #region Public Static Methods

        public static CgState Create(CgContext context, string name, ParameterType type)
        {
            return new CgState(Cg.CreateState(context.Handle, name, type));
        }

        public static CgState CreateArrayState(CgContext context, string name, ParameterType type, int elementCount)
        {
            return new CgState(Cg.CreateArrayState(context.Handle, name, type, elementCount));
        }

        #endregion Public Static Methods

        #region Public Methods

        public void AddEnumerant(string name, int value)
        {
            Cg.AddStateEnumerant(this.Handle, name, value);
        }

        public bool CallResetCallback()
        {
            return Cg.CallStateResetCallback(this.Handle);
        }

        public bool CallSetCallback()
        {
            return Cg.CallStateSetCallback(this.Handle);
        }

        public bool CallValidateCallback()
        {
            return Cg.CallStateValidateCallback(this.Handle);
        }

        public string GetEnumerant(int index, out int value)
        {
            return Cg.GetStateEnumerant(this.Handle, index, out value);
        }

        public string GetEnumerantName(int index)
        {
            return Cg.GetStateEnumerantName(this.Handle, index);
        }

        public int GetEnumerantValue(string name)
        {
            return Cg.GetStateEnumerantValue(this.Handle, name);
        }

        public void SetCallbacks(Cg.CgStateCallbackDelegate set, Cg.CgStateCallbackDelegate reset, Cg.CgStateCallbackDelegate validate)
        {
            Cg.SetStateCallbacks(this.Handle, set, reset, validate);
        }

        public void SetLatestProfile(ProfileType profile)
        {
            Cg.SetStateLatestProfile(this.Handle, profile);
        }

        #endregion Public Methods

        #endregion Methods
    }
}