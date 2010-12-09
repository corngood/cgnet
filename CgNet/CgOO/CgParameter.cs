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
    using System.Collections.Generic;

    using CgNet;

    public sealed class CgParameter : WrapperObject
    {
        #region Constructors

        internal CgParameter(IntPtr handle)
            : base(handle)
        {
        }

        #endregion Constructors

        #region Properties

        #region Public Properties

        public IEnumerable<CgAnnotation> Annotations
        {
            get
            {
                return Enumerate(() => this.FirstAnnotation, t => t.NextAnnotation);
            }
        }

        public ResourceType BaseResourceType
        {
            get
            {
                return Cg.GetParameterBaseResource(this.Handle);
            }
        }

        public ParameterType BaseType
        {
            get
            {
                return Cg.GetParameterBaseType(this.Handle);
            }
        }

        public int BufferIndex
        {
            get
            {
                return Cg.GetParameterBufferIndex(this.Handle);
            }
        }

        public int BufferOffset
        {
            get
            {
                return Cg.GetParameterBufferOffset(this.Handle);
            }
        }

        public ParameterClass Class
        {
            get
            {
                return Cg.GetParameterClass(this.Handle);
            }
        }

        public int Columns
        {
            get
            {
                return Cg.GetParameterColumns(this.Handle);
            }
        }

        public CgParameter ConnectedParameter
        {
            get
            {
                var ptr = Cg.GetConnectedParameter(this.Handle);
                return ptr == IntPtr.Zero ? null : new CgParameter(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public int ConnectedToCount
        {
            get
            {
                return Cg.GetNumConnectedToParameters(this.Handle);
            }
        }

        public CgContext Context
        {
            get
            {
                var ptr = Cg.GetParameterContext(this.Handle);
                return ptr == IntPtr.Zero ? null : new CgContext(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public CgEffect Effect
        {
            get
            {
                var ptr = Cg.GetParameterEffect(this.Handle);
                return ptr == IntPtr.Zero ? null : new CgEffect(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public CgAnnotation FirstAnnotation
        {
            get
            {
                var ptr = Cg.GetFirstParameterAnnotation(this.Handle);
                return ptr == IntPtr.Zero ? null : new CgAnnotation(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public CgStateAssignment FirstStateAssignment
        {
            get
            {
                var ptr = Cg.GetFirstSamplerStateAssignment(this.Handle);
                return ptr == IntPtr.Zero ? null : new CgStateAssignment(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public int Index
        {
            get
            {
                return Cg.GetParameterIndex(this.Handle);
            }
        }

        public bool IsGlobal
        {
            get
            {
                return Cg.IsParameterGlobal(this.Handle);
            }
        }

        public bool IsParameter
        {
            get
            {
                return Cg.IsParameter(this.Handle);
            }
        }

        public bool IsReferenced
        {
            get
            {
                return Cg.IsParameterReferenced(this.Handle);
            }
        }

        public string Name
        {
            get
            {
                return Cg.GetParameterName(this.Handle);
            }
        }

        public ParameterType NamedType
        {
            get
            {
                return Cg.GetParameterNamedType(this.Handle);
            }
        }

        public CgParameter NextLeafParameter
        {
            get
            {
                var ptr = Cg.GetNextLeafParameter(this.Handle);
                return ptr == IntPtr.Zero ? null : new CgParameter(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public CgParameter NextParameter
        {
            get
            {
                var ptr = Cg.GetNextParameter(this.Handle);
                return ptr == IntPtr.Zero ? null : new CgParameter(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public int OrdinalNumber
        {
            get
            {
                return Cg.GetParameterOrdinalNumber(this.Handle);
            }
        }

        public ParameterDirection ParameterDirection
        {
            get
            {
                return Cg.GetParameterDirection(this.Handle);
            }
        }

        public CgProgram Program
        {
            get
            {
                var ptr = Cg.GetParameterProgram(this.Handle);
                return ptr == IntPtr.Zero ? null : new CgProgram(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public ResourceType Resource
        {
            get
            {
                return Cg.GetParameterResource(this.Handle);
            }
        }

        public int ResourceIndex
        {
            get
            {
                return Cg.GetParameterResourceIndex(this.Handle);
            }
        }

        public string ResourceName
        {
            get
            {
                return Cg.GetParameterResourceName(this.Handle);
            }
        }

        public int ResourceSize
        {
            get
            {
                return Cg.GetParameterResourceSize(this.Handle);
            }
        }

        public ParameterType ResourceType
        {
            get
            {
                return Cg.GetParameterResourceType(this.Handle);
            }
        }

        public int Rows
        {
            get
            {
                return Cg.GetParameterRows(this.Handle);
            }
        }

        public string Semantic
        {
            get
            {
                return Cg.GetParameterSemantic(this.Handle);
            }

            set
            {
                Cg.SetParameterSemantic(this.Handle, value);
            }
        }

        public ParameterType Type
        {
            get
            {
                return Cg.GetParameterType(this.Handle);
            }
        }

        public int Variability
        {
            get
            {
                return Cg.GetParameterVariability(this.Handle);
            }

            set
            {
                Cg.SetParameterVariability(this.Handle, value);
            }
        }

        #endregion Public Properties

        #endregion Properties

        #region Methods

        #region Public Static Methods

        public static void ConnectParameters(CgParameter from, CgParameter to)
        {
            Cg.ConnectParameter(from.Handle, to.Handle);
        }

        public static CgParameter Create(CgContext context, ParameterType type)
        {
            return context.CreateParameter(type);
        }

        #endregion Public Static Methods

        #region Public Methods

        public void Connect(CgParameter to)
        {
            Cg.ConnectParameter(this.Handle, to.Handle);
        }

        public CgAnnotation CreateAnnotation(string name, ParameterType type)
        {
            var ptr = Cg.CreateParameterAnnotation(this.Handle, name, type);
            return ptr == IntPtr.Zero ? null : new CgAnnotation(ptr);
        }

        public void Disconnect()
        {
            Cg.DisconnectParameter(this.Handle);
        }

        public int GetArrayDimension()
        {
            return Cg.GetArrayDimension(this.Handle);
        }

        public CgParameter GetArrayParameter(IntPtr aparam, int index)
        {
            var ptr = Cg.GetArrayParameter(this.Handle, index);
            return ptr == IntPtr.Zero ? null : new CgParameter(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public int GetArraySize(int dimension)
        {
            return Cg.GetArraySize(this.Handle, dimension);
        }

        public int GetArrayTotalSize()
        {
            return Cg.GetArrayTotalSize(this.Handle);
        }

        public ParameterType GetArrayType()
        {
            return Cg.GetArrayType(this.Handle);
        }

        public CgParameter GetConnectedToParameter(int index)
        {
            var ptr = Cg.GetConnectedToParameter(this.Handle, index);
            return ptr == IntPtr.Zero ? null : new CgParameter(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public int GetDefaultValue(ref double[] values)
        {
            return Cg.GetParameterDefaultValue(this.Handle, ref values, Order.RowMajor);
        }

        public int GetDefaultValue(ref double[] values, Order order)
        {
            return Cg.GetParameterDefaultValue(this.Handle, ref values, order);
        }

        public int GetDefaultValue(ref int[] values)
        {
            return Cg.GetParameterDefaultValue(this.Handle, ref values, Order.RowMajor);
        }

        public int GetDefaultValue(ref int[] values, Order order)
        {
            return Cg.GetParameterDefaultValue(this.Handle, ref values, order);
        }

        public int GetDefaultValue(ref float[] values)
        {
            return Cg.GetParameterDefaultValue(this.Handle, ref values, Order.RowMajor);
        }

        public int GetDefaultValue(ref float[] values, Order order)
        {
            return Cg.GetParameterDefaultValue(this.Handle, ref values, order);
        }

        public CgBuffer GetEffectParameterBuffer()
        {
            var ptr = Cg.GetEffectParameterBuffer(this.Handle);
            return ptr == IntPtr.Zero ? null : new CgBuffer(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public CgParameter GetFirstDependentParameter()
        {
            var ptr = Cg.GetFirstDependentParameter(this.Handle);
            return ptr == IntPtr.Zero ? null : new CgParameter(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public CgParameter GetFirstStructParameter()
        {
            var ptr = Cg.GetFirstStructParameter(this.Handle);
            return ptr == IntPtr.Zero ? null : new CgParameter(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public void GetMatrixParameter(out int[] values)
        {
            Cg.GetMatrixParameter(this.Handle, out values);
        }

        public void GetMatrixParameter(out float[] values)
        {
            Cg.GetMatrixParameter(this.Handle, out values);
        }

        public void GetMatrixParameter(out double[] values)
        {
            Cg.GetMatrixParameter(this.Handle, out values);
        }

        public T[] GetMatrixParameter<T>()
            where T : struct
        {
            return Cg.GetMatrixParameter<T>(this.Handle);
        }

        public T[] GetMatrixParameter<T>(Order order)
            where T : struct
        {
            return Cg.GetMatrixParameter<T>(this.Handle, order);
        }

        public Order GetMatrixParameterOrder()
        {
            return Cg.GetMatrixParameterOrder(this.Handle);
        }

        public CgAnnotation GetNamedAnnotation(string name)
        {
            var ptr = Cg.GetNamedParameterAnnotation(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new CgAnnotation(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public CgStateAssignment GetNamedStateAssignment(string name)
        {
            var ptr = Cg.GetNamedSamplerStateAssignment(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new CgStateAssignment(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public CgParameter GetNamedStructParameter(string name)
        {
            var ptr = Cg.GetNamedStructParameter(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new CgParameter(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public CgParameter GetNamedSubParameter(string name)
        {
            var ptr = Cg.GetNamedSubParameter(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new CgParameter(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public string GetStringValue()
        {
            return Cg.GetStringParameterValue(this.Handle);
        }

        public void GetValue(ref int[] values)
        {
            Cg.GetParameterValue(this.Handle, ref values, Order.RowMajor);
        }

        public void GetValue(ref double[] values)
        {
            Cg.GetParameterValue(this.Handle, ref values, Order.RowMajor);
        }

        public void GetValue(ref float[] values)
        {
            Cg.GetParameterValue(this.Handle, ref values, Order.RowMajor);
        }

        public T GetValue<T>()
            where T : struct
        {
            return Cg.GetParameterValue<T>(this.Handle);
        }

        public void GetValue<T>(ref T[] values)
            where T : struct
        {
            Cg.GetParameterValue(this.Handle, ref values, Order.RowMajor);
        }

        public void GetValue<T>(ref T[] values, Order order)
            where T : struct
        {
            Cg.GetParameterValue(this.Handle, ref values, order);
        }

        public bool IsParameterUsed(WrapperObject container)
        {
            return Cg.IsParameterUsed(this.Handle, container.Handle);
        }

        public void Set(float x)
        {
            Cg.SetParameter(this.Handle, x);
        }

        public void Set(float x, float y, float z)
        {
            Cg.SetParameter(this.Handle, x, y, z);
        }

        public void Set(int[] v)
        {
            Cg.SetParameter(this.Handle, v);
        }

        public void Set(double[] v)
        {
            Cg.SetParameter(this.Handle, v);
        }

        public void Set(float[] v)
        {
            Cg.SetParameter(this.Handle, v);
        }

        public void Set(float x, float y)
        {
            Cg.SetParameter(this.Handle, x, y);
        }

        public void Set(float x, float y, float z, float w)
        {
            Cg.SetParameter(this.Handle, x, y, z, w);
        }

        public void Set(double x)
        {
            Cg.SetParameter(this.Handle, x);
        }

        public void Set(int x)
        {
            Cg.SetParameter(this.Handle, x);
        }

        public void Set(double x, double y)
        {
            Cg.SetParameter(this.Handle, x, y);
        }

        public void Set(int x, int y)
        {
            Cg.SetParameter(this.Handle, x, y);
        }

        public void Set(double x, double y, double z)
        {
            Cg.SetParameter(this.Handle, x, y, z);
        }

        public void Set(int x, int y, int z)
        {
            Cg.SetParameter(this.Handle, x, y, z);
        }

        public void Set(double x, double y, double z, double w)
        {
            Cg.SetParameter(this.Handle, x, y, z, w);
        }

        public void Set(int x, int y, int z, int w)
        {
            Cg.SetParameter(this.Handle, x, y, z, w);
        }

        public void SetArraySize(int size)
        {
            Cg.SetArraySize(this.Handle, size);
        }

        public void SetEffectParameterBuffer(CgBuffer buffer)
        {
            Cg.SetEffectParameterBuffer(this.Handle, buffer.Handle);
        }

        public void SetMatrixParameter(float[] matrix)
        {
            Cg.SetMatrixParameter(this.Handle, matrix, Order.RowMajor);
        }

        public void SetMatrixParameter(float[] matrix, Order order)
        {
            Cg.SetMatrixParameter(this.Handle, matrix, order);
        }

        public void SetMatrixParameter(double[] matrix)
        {
            Cg.SetMatrixParameter(this.Handle, matrix, Order.RowMajor);
        }

        public void SetMatrixParameter(double[] matrix, Order order)
        {
            Cg.SetMatrixParameter(this.Handle, matrix, order);
        }

        public void SetMatrixParameter(int[] matrix)
        {
            Cg.SetMatrixParameter(this.Handle, matrix, Order.RowMajor);
        }

        public void SetMatrixParameter(int[] matrix, Order order)
        {
            Cg.SetMatrixParameter(this.Handle, matrix, order);
        }

        public void SetMultiDimArraySize(int[] sizes)
        {
            Cg.SetMultiDimArraySize(this.Handle, sizes);
        }

        public void SetSamplerState()
        {
            Cg.SetSamplerState(this.Handle);
        }

        public void SetStringValue(string str)
        {
            Cg.SetStringParameterValue(this.Handle, str);
        }

        public void SetValue(double[] vals)
        {
            Cg.SetParameterValue(this.Handle, vals, Order.RowMajor);
        }

        public void SetValue(double[] vals, Order order)
        {
            Cg.SetParameterValue(this.Handle, vals, order);
        }

        public void SetValue(float[] vals)
        {
            Cg.SetParameterValue(this.Handle, vals, Order.RowMajor);
        }

        public void SetValue(float[] vals, Order order)
        {
            Cg.SetParameterValue(this.Handle, vals, order);
        }

        public void SetValue(int[] vals)
        {
            Cg.SetParameterValue(this.Handle, vals, Order.RowMajor);
        }

        public void SetValue(int[] vals, Order order)
        {
            Cg.SetParameterValue(this.Handle, vals, order);
        }

        #endregion Public Methods

        #region Protected Methods

        protected override void Dispose(bool disposing)
        {
            if (this.Handle != IntPtr.Zero)
            {
                Cg.DestroyParameter(this.Handle);
            }
        }

        #endregion Protected Methods

        #endregion Methods
    }
}