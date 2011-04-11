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
namespace CgNet
{
    using System;
    using System.Runtime.InteropServices;

    public sealed class State : WrapperObject
    {
        #region Constructors

        internal State(IntPtr handle)
            : base(handle)
        {
        }

        #endregion Constructors

        #region Delegates

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool CgStateCallbackDelegate(IntPtr cGstateassignment);

        #endregion Delegates

        #region Properties

        #region Public Properties

        public Context Context
        {
            get
            {
                var ptr = CgNativeMethods.cgGetStateContext(this.Handle);
                return ptr == IntPtr.Zero ? null : new Context(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public int EnumerantsCount
        {
            get
            {
                return CgNativeMethods.cgGetNumStateEnumerants(this.Handle);
            }
        }

        public bool IsState
        {
            get
            {
                return CgNativeMethods.cgIsState(this.Handle);
            }
        }

        public ProfileType LatestProfile
        {
            get
            {
                return CgNativeMethods.cgGetStateLatestProfile(this.Handle);
            }
        }

        public string Name
        {
            get
            {
                return Marshal.PtrToStringAnsi(CgNativeMethods.cgGetStateName(this.Handle));
            }
        }

        public State NextState
        {
            get
            {
                var ptr = CgNativeMethods.cgGetNextState(this.Handle);
                return ptr == IntPtr.Zero ? null : new State(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public CgStateCallbackDelegate ResetCallback
        {
            get
            {
                return CgNativeMethods.cgGetStateResetCallback(this.Handle);
            }
        }

        public CgStateCallbackDelegate SetCallback
        {
            get
            {
                return CgNativeMethods.cgGetStateSetCallback(this.Handle);
            }
        }

        public ParameterType Type
        {
            get
            {
                return CgNativeMethods.cgGetStateType(this.Handle);
            }
        }

        public CgStateCallbackDelegate ValidateCallback
        {
            get
            {
                return CgNativeMethods.cgGetStateValidateCallback(this.Handle);
            }
        }

        #endregion Public Properties

        #endregion Properties

        #region Methods

        #region Public Static Methods

        public static State Create(Context context, string name, ParameterType type)
        {
            return context.CreateState(name, type);
        }

        public static State CreateArrayState(Context context, string name, ParameterType type, int elementCount)
        {
            return context.CreateArrayState(name, type, elementCount);
        }

        #endregion Public Static Methods

        #region Public Methods

        public void AddEnumerant(string name, int value)
        {
            IntPtr state = this.Handle;
            CgNativeMethods.cgAddStateEnumerant(state, name, value);
        }

        public bool CallResetCallback()
        {
            IntPtr stateassignment = this.Handle;
            return CgNativeMethods.cgCallStateResetCallback(stateassignment);
        }

        public bool CallSetCallback()
        {
            IntPtr stateassignment = this.Handle;
            return CgNativeMethods.cgCallStateSetCallback(stateassignment);
        }

        public bool CallValidateCallback()
        {
            IntPtr stateassignment = this.Handle;
            return CgNativeMethods.cgCallStateValidateCallback(stateassignment);
        }

        public string GetEnumerant(int index, out int value)
        {
            return Marshal.PtrToStringAnsi(CgNativeMethods.cgGetStateEnumerant(this.Handle, index, out value));
        }

        public string GetEnumerantName(int index)
        {
            return Marshal.PtrToStringAnsi(CgNativeMethods.cgGetStateEnumerantName(this.Handle, index));
        }

        public int GetEnumerantValue(string name)
        {
            return CgNativeMethods.cgGetStateEnumerantValue(this.Handle, name);
        }

        public void SetCallbacks(CgStateCallbackDelegate set, CgStateCallbackDelegate reset, CgStateCallbackDelegate validate)
        {
            CgNativeMethods.cgSetStateCallbacks(this.Handle, set, reset, validate);
        }

        public void SetLatestProfile(ProfileType profile)
        {
            CgNativeMethods.cgSetStateLatestProfile(this.Handle, profile);
        }

        #endregion Public Methods

        #endregion Methods
    }
}