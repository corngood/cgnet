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

    public sealed class CgStateAssignment : WrapperObject
    {
        #region Constructors

        internal CgStateAssignment(IntPtr handle)
            : base(handle)
        {
        }

        #endregion Constructors

        #region Properties

        #region Public Properties

        public CgParameter ConnectedParameter
        {
            get
            {
                var ptr = Cg.GetConnectedStateAssignmentParameter(this.Handle);
                return ptr == IntPtr.Zero ? null : new CgParameter(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public int DependentParametersCount
        {
            get
            {
                return Cg.GetNumDependentStateAssignmentParameters(this.Handle);
            }
        }

        public int DependentProgramArrayParametersCount
        {
            get
            {
                return Cg.GetNumDependentProgramArrayStateAssignmentParameters(this.Handle);
            }
        }

        public int Index
        {
            get
            {
                return Cg.GetStateAssignmentIndex(this.Handle);
            }
        }

        public bool IsStateAssignment
        {
            get
            {
                return Cg.IsStateAssignment(this.Handle);
            }
        }

        public CgStateAssignment NextStateAssignment
        {
            get
            {
                var ptr = Cg.GetNextStateAssignment(this.Handle);
                return ptr == IntPtr.Zero ? null : new CgStateAssignment(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public CgPass Pass
        {
            get
            {
                var ptr = Cg.GetStateAssignmentPass(this.Handle);
                return ptr == IntPtr.Zero ? null : new CgPass(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public CgState State
        {
            get
            {
                var ptr = Cg.GetStateAssignmentState(this.Handle);
                return ptr == IntPtr.Zero ? null : new CgState(ptr)
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
            return Cg.GetBoolStateAssignmentValues(this.Handle);
        }

        public CgParameter GetDependentParameter(int index)
        {
            var ptr = Cg.GetDependentStateAssignmentParameter(this.Handle, index);
            return ptr == IntPtr.Zero ? null : new CgParameter(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public CgParameter GetDependentProgramArrayParameter(int index)
        {
            var ptr = Cg.GetDependentProgramArrayStateAssignmentParameter(this.Handle, index);
            return ptr == IntPtr.Zero ? null : new CgParameter(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public float[] GetFloatValues()
        {
            return Cg.GetFloatStateAssignmentValues(this.Handle);
        }

        public int[] GetIntValues()
        {
            return Cg.GetIntStateAssignmentValues(this.Handle);
        }

        public CgProgram GetProgramValue()
        {
            var ptr = Cg.GetProgramStateAssignmentValue(this.Handle);
            return ptr == IntPtr.Zero ? null : new CgProgram(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public CgParameter GetSamplerParameter()
        {
            var ptr = Cg.GetSamplerStateAssignmentParameter(this.Handle);
            return ptr == IntPtr.Zero ? null : new CgParameter(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public CgState GetSamplerState()
        {
            var ptr = Cg.GetSamplerStateAssignmentState(this.Handle);
            return ptr == IntPtr.Zero ? null : new CgState(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public CgParameter GetSamplerStateAssignmentValue()
        {
            var ptr = Cg.GetSamplerStateAssignmentValue(this.Handle);
            return ptr == IntPtr.Zero ? null : new CgParameter(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public string GetStringValue()
        {
            return Cg.GetStringStateAssignmentValue(this.Handle);
        }

        public CgParameter GetTextureStateAssignmentValue()
        {
            var ptr = Cg.GetTextureStateAssignmentValue(this.Handle);
            return ptr == IntPtr.Zero ? null : new CgParameter(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public bool Set(float value)
        {
            return Cg.SetStateAssignment(this.Handle, value);
        }

        public bool Set(int value)
        {
            return Cg.SetStateAssignment(this.Handle, value);
        }

        public bool Set(bool value)
        {
            return Cg.SetStateAssignment(this.Handle, value);
        }

        public bool Set(string value)
        {
            return Cg.SetStateAssignment(this.Handle, value);
        }

        public bool Set(float[] value)
        {
            return Cg.SetStateAssignment(this.Handle, value);
        }

        public bool Set(int[] value)
        {
            return Cg.SetStateAssignment(this.Handle, value);
        }

        public bool Set(bool[] value)
        {
            return Cg.SetStateAssignment(this.Handle, value);
        }

        public bool SetProgram(CgProgram program)
        {
            return Cg.SetProgramStateAssignment(this.Handle, program.Handle);
        }

        public bool SetSampler(CgParameter param)
        {
            return Cg.SetSamplerStateAssignment(this.Handle, param.Handle);
        }

        public bool SetTexture(CgParameter param)
        {
            return Cg.SetTextureStateAssignment(this.Handle, param.Handle);
        }

        #endregion Public Methods

        #endregion Methods
    }
}