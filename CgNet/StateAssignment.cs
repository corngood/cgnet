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

    public sealed class StateAssignment : WrapperObject
    {
        #region Constructors

        internal StateAssignment(IntPtr handle)
            : base(handle)
        {
        }

        #endregion Constructors

        #region Properties

        #region Public Properties

        public Parameter ConnectedParameter
        {
            get
            {
                var ptr = CgNativeMethods.cgGetConnectedStateAssignmentParameter(this.Handle);
                return ptr == IntPtr.Zero ? null : new Parameter(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public int DependentParametersCount
        {
            get
            {
                return CgNativeMethods.cgGetNumDependentStateAssignmentParameters(this.Handle);
            }
        }

        public int DependentProgramArrayParametersCount
        {
            get
            {
                return CgNativeMethods.cgGetNumDependentProgramArrayStateAssignmentParameters(this.Handle);
            }
        }

        public int Index
        {
            get
            {
                return CgNativeMethods.cgGetStateAssignmentIndex(this.Handle);
            }
        }

        public bool IsStateAssignment
        {
            get
            {
                return CgNativeMethods.cgIsStateAssignment(this.Handle);
            }
        }

        public StateAssignment NextStateAssignment
        {
            get
            {
                var ptr = CgNativeMethods.cgGetNextStateAssignment(this.Handle);
                return ptr == IntPtr.Zero ? null : new StateAssignment(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public Pass Pass
        {
            get
            {
                var ptr = CgNativeMethods.cgGetStateAssignmentPass(this.Handle);
                return ptr == IntPtr.Zero ? null : new Pass(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public State State
        {
            get
            {
                var ptr = CgNativeMethods.cgGetStateAssignmentState(this.Handle);
                return ptr == IntPtr.Zero ? null : new State(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        #endregion Public Properties

        #endregion Properties

        #region Methods

        #region Public Methods

        public bool[] GetBoolValues()
        {
            int count;
            var values = CgNativeMethods.cgGetBoolStateAssignmentValues(this.Handle, out count);
            return Cg.IntPtrToBoolArray(values, count);
        }

        public Parameter GetDependentParameter(int index)
        {
            var ptr = CgNativeMethods.cgGetDependentStateAssignmentParameter(this.Handle, index);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public Parameter GetDependentProgramArrayParameter(int index)
        {
            var ptr = CgNativeMethods.cgGetDependentProgramArrayStateAssignmentParameter(this.Handle, index);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public float[] GetFloatValues()
        {
            int nVals;
            return CgNativeMethods.cgGetFloatStateAssignmentValues(this.Handle, out nVals);
        }

        public int[] GetIntValues()
        {
            int nVals;
            return CgNativeMethods.cgGetIntStateAssignmentValues(this.Handle, out nVals);
        }

        public Program GetProgramValue()
        {
            var ptr = CgNativeMethods.cgGetProgramStateAssignmentValue(this.Handle);
            return ptr == IntPtr.Zero ? null : new Program(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public Parameter GetSamplerParameter()
        {
            var ptr = CgNativeMethods.cgGetSamplerStateAssignmentParameter(this.Handle);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public State GetSamplerState()
        {
            var ptr = CgNativeMethods.cgGetSamplerStateAssignmentState(this.Handle);
            return ptr == IntPtr.Zero ? null : new State(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public Parameter GetSamplerStateAssignmentValue()
        {
            var ptr = CgNativeMethods.cgGetSamplerStateAssignmentValue(this.Handle);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public string GetStringValue()
        {
            return Marshal.PtrToStringAnsi(CgNativeMethods.cgGetStringStateAssignmentValue(this.Handle));
        }

        public Parameter GetTextureStateAssignmentValue()
        {
            var ptr = CgNativeMethods.cgGetTextureStateAssignmentValue(this.Handle);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public bool Set(float value)
        {
            return CgNativeMethods.cgSetFloatStateAssignment(this.Handle, value);
        }

        public bool Set(int value)
        {
            return CgNativeMethods.cgSetIntStateAssignment(this.Handle, value);
        }

        public bool Set(bool value)
        {
            return CgNativeMethods.cgSetBoolStateAssignment(this.Handle, value);
        }

        public bool Set(string value)
        {
            return CgNativeMethods.cgSetStringStateAssignment(this.Handle, value);
        }

        public bool Set(float[] value)
        {
            return CgNativeMethods.cgSetFloatArrayStateAssignment(this.Handle, value);
        }

        public bool Set(int[] value)
        {
            return CgNativeMethods.cgSetIntArrayStateAssignment(this.Handle, value);
        }

        public bool Set(bool[] value)
        {
            return CgNativeMethods.cgSetBoolArrayStateAssignment(this.Handle, value);
        }

        public bool SetProgram(Program program)
        {
            return CgNativeMethods.cgSetProgramStateAssignment(this.Handle, program.Handle);
        }

        public bool SetSampler(Parameter param)
        {
            return CgNativeMethods.cgSetSamplerStateAssignment(this.Handle, param.Handle);
        }

        public bool SetTexture(Parameter param)
        {
            return CgNativeMethods.cgSetTextureStateAssignment(this.Handle, param.Handle);
        }

        #endregion Public Methods

        #endregion Methods
    }
}