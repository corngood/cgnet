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
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.InteropServices;

    public sealed class Parameter : WrapperObject
    {
        #region Constructors

        internal Parameter(IntPtr handle)
            : base(handle)
        {
        }

        #endregion Constructors

        #region Properties

        #region Public Properties

        public IEnumerable<Annotation> Annotations
        {
            get
            {
                return Enumerate(() => this.FirstAnnotation, t => t.NextAnnotation);
            }
        }

        public ResourceType BaseResource
        {
            get
            {
                return CgNativeMethods.cgGetParameterBaseResource(this.Handle);
            }
        }

        public ParameterType BaseType
        {
            get
            {
                return CgNativeMethods.cgGetParameterBaseType(this.Handle);
            }
        }

        public int BufferIndex
        {
            get
            {
                return CgNativeMethods.cgGetParameterBufferIndex(this.Handle);
            }
        }

        public int BufferOffset
        {
            get
            {
                return CgNativeMethods.cgGetParameterBufferOffset(this.Handle);
            }
        }

        public ParameterClass Class
        {
            get
            {
                return CgNativeMethods.cgGetParameterClass(this.Handle);
            }
        }

        public int Columns
        {
            get
            {
                return CgNativeMethods.cgGetParameterColumns(this.Handle);
            }
        }

        public Parameter ConnectedParameter
        {
            get
            {
                var ptr = CgNativeMethods.cgGetConnectedParameter(this.Handle);
                return ptr == IntPtr.Zero ? null : new Parameter(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public int ConnectedToCount
        {
            get
            {
                return CgNativeMethods.cgGetNumConnectedToParameters(this.Handle);
            }
        }

        public Context Context
        {
            get
            {
                var ptr = CgNativeMethods.cgGetParameterContext(this.Handle);
                return ptr == IntPtr.Zero ? null : new Context(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public Effect Effect
        {
            get
            {
                var ptr = CgNativeMethods.cgGetParameterEffect(this.Handle);
                return ptr == IntPtr.Zero ? null : new Effect(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public Annotation FirstAnnotation
        {
            get
            {
                var ptr = CgNativeMethods.cgGetFirstParameterAnnotation(this.Handle);
                return ptr == IntPtr.Zero ? null : new Annotation(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public StateAssignment FirstStateAssignment
        {
            get
            {
                var ptr = CgNativeMethods.cgGetFirstSamplerStateAssignment(this.Handle);
                return ptr == IntPtr.Zero ? null : new StateAssignment(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public int Index
        {
            get
            {
                return CgNativeMethods.cgGetParameterIndex(this.Handle);
            }
        }

        public bool IsGlobal
        {
            get
            {
                return CgNativeMethods.cgIsParameterGlobal(this.Handle);
            }
        }

        public bool IsParameter
        {
            get
            {
                return CgNativeMethods.cgIsParameter(this.Handle);
            }
        }

        public bool IsReferenced
        {
            get
            {
                return CgNativeMethods.cgIsParameterReferenced(this.Handle);
            }
        }

        public string Name
        {
            get
            {
                return Marshal.PtrToStringAnsi(CgNativeMethods.cgGetParameterName(this.Handle));
            }
        }

        public ParameterType NamedType
        {
            get
            {
                return CgNativeMethods.cgGetParameterNamedType(this.Handle);
            }
        }

        public Parameter NextLeafParameter
        {
            get
            {
                var ptr = CgNativeMethods.cgGetNextLeafParameter(this.Handle);
                return ptr == IntPtr.Zero ? null : new Parameter(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public Parameter NextParameter
        {
            get
            {
                var ptr = CgNativeMethods.cgGetNextParameter(this.Handle);
                return ptr == IntPtr.Zero ? null : new Parameter(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public int OrdinalNumber
        {
            get
            {
                return CgNativeMethods.cgGetParameterOrdinalNumber(this.Handle);
            }
        }

        public ParameterDirection ParameterDirection
        {
            get
            {
                return CgNativeMethods.cgGetParameterDirection(this.Handle);
            }
        }

        public Program Program
        {
            get
            {
                var ptr = CgNativeMethods.cgGetParameterProgram(this.Handle);
                return ptr == IntPtr.Zero ? null : new Program(ptr)
                                                   {
                                                       OwnsHandle = false
                                                   };
            }
        }

        public ResourceType Resource
        {
            get
            {
                return CgNativeMethods.cgGetParameterResource(this.Handle);
            }
        }

        public int ResourceIndex
        {
            get
            {
                return (int)CgNativeMethods.cgGetParameterResourceIndex(this.Handle);
            }
        }

        public string ResourceName
        {
            get
            {
                return Marshal.PtrToStringAnsi(CgNativeMethods.cgGetParameterResourceName(this.Handle));
            }
        }

        public int ResourceSize
        {
            get
            {
                return CgNativeMethods.cgGetParameterResourceSize(this.Handle);
            }
        }

        public ParameterType ResourceType
        {
            get
            {
                return CgNativeMethods.cgGetParameterResourceType(this.Handle);
            }
        }

        public int Rows
        {
            get
            {
                return CgNativeMethods.cgGetParameterRows(this.Handle);
            }
        }

        public string Semantic
        {
            get
            {
                return Marshal.PtrToStringAnsi(CgNativeMethods.cgGetParameterSemantic(this.Handle));
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value");
                }

                CgNativeMethods.cgSetParameterSemantic(this.Handle, value);
            }
        }

        public ParameterType Type
        {
            get
            {
                return CgNativeMethods.cgGetParameterType(this.Handle);
            }
        }

        public Variability Variability
        {
            get
            {
                return CgNativeMethods.cgGetParameterVariability(this.Handle);
            }

            set
            {
                if (value != Variability.Literal && value != Variability.Uniform && value != Variability.Default)
                {
                    throw new ArgumentException("value must be CG_UNIFORM, CG_LITERAL, or CG_DEFAULT", "value");
                }

                CgNativeMethods.cgSetParameterVariability(this.Handle, value);
            }
        }

        #endregion Public Properties

        #endregion Properties

        #region Methods

        #region Public Static Methods

        public static void ConnectParameters(Parameter from, Parameter to)
        {
            CgNativeMethods.cgConnectParameter(from.Handle, to.Handle);
        }

        public static Parameter Create(Context context, ParameterType type)
        {
            return context.CreateParameter(type);
        }

        #endregion Public Static Methods

        #region Public Methods

        public void Connect(Parameter to)
        {
            CgNativeMethods.cgConnectParameter(this.Handle, to.Handle);
        }

        public Annotation CreateAnnotation(string name, ParameterType type)
        {
            var ptr = CgNativeMethods.cgCreateParameterAnnotation(this.Handle, name, type);
            return ptr == IntPtr.Zero ? null : new Annotation(ptr);
        }

        public void Disconnect()
        {
            CgNativeMethods.cgDisconnectParameter(this.Handle);
        }

        public int GetArrayDimension()
        {
            return CgNativeMethods.cgGetArrayDimension(this.Handle);
        }

        public Parameter GetArrayParameter(IntPtr aparam, int index)
        {
            var ptr = CgNativeMethods.cgGetArrayParameter(this.Handle, index);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public int GetArraySize(int dimension)
        {
            return CgNativeMethods.cgGetArraySize(this.Handle, dimension);
        }

        public int GetArrayTotalSize()
        {
            return CgNativeMethods.cgGetArrayTotalSize(this.Handle);
        }

        public ParameterType GetArrayType()
        {
            return CgNativeMethods.cgGetArrayType(this.Handle);
        }

        public Parameter GetConnectedToParameter(int index)
        {
            var ptr = CgNativeMethods.cgGetConnectedToParameter(this.Handle, index);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public int GetDefaultValue(ref double[] values)
        {
            return this.GetDefaultValue(ref values, Cg.DefaultOrder);
        }

        public int GetDefaultValue(ref double[] values, Order order)
        {
            IntPtr param = this.Handle;
            switch (order)
            {
                case Order.ColumnMajor:
                    return CgNativeMethods.cgGetParameterDefaultValuedc(param, values.Length, values);
                case Order.RowMajor:
                    return CgNativeMethods.cgGetParameterDefaultValuedr(param, values.Length, values);
                default:
                    throw new ArgumentOutOfRangeException("order");
            }
        }

        public int GetDefaultValue(ref int[] values)
        {
            return this.GetDefaultValue(ref values, Cg.DefaultOrder);
        }

        public int GetDefaultValue(ref int[] values, Order order)
        {
            IntPtr param = this.Handle;
            switch (order)
            {
                case Order.ColumnMajor:
                    return CgNativeMethods.cgGetParameterDefaultValueic(param, values.Length, values);
                case Order.RowMajor:
                    return CgNativeMethods.cgGetParameterDefaultValueir(param, values.Length, values);
                default:
                    throw new ArgumentOutOfRangeException("order");
            }
        }

        public int GetDefaultValue(ref float[] values)
        {
            return this.GetDefaultValue(ref values, Cg.DefaultOrder);
        }

        public int GetDefaultValue(ref float[] values, Order order)
        {
            IntPtr param = this.Handle;
            switch (order)
            {
                case Order.ColumnMajor:
                    return CgNativeMethods.cgGetParameterDefaultValuefc(param, values.Length, values);
                case Order.RowMajor:
                    return CgNativeMethods.cgGetParameterDefaultValuefr(param, values.Length, values);
                default:
                    throw new ArgumentOutOfRangeException("order");
            }
        }

        public Buffer GetEffectParameterBuffer()
        {
            var ptr = CgNativeMethods.cgGetEffectParameterBuffer(this.Handle);
            return ptr == IntPtr.Zero ? null : new Buffer(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public Parameter GetFirstDependentParameter()
        {
            var ptr = CgNativeMethods.cgGetFirstDependentParameter(this.Handle);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public Parameter GetFirstStructParameter()
        {
            var ptr = CgNativeMethods.cgGetFirstStructParameter(this.Handle);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public void GetMatrix(out int[] values)
        {
            values = this.GetMatrix<int>(Cg.DefaultOrder);
        }

        public void GetMatrix(out float[] values)
        {
            values = this.GetMatrix<float>(Cg.DefaultOrder);
        }

        public void GetMatrix(out double[] values)
        {
            values = this.GetMatrix<double>(Cg.DefaultOrder);
        }

        public T[] GetMatrix<T>()
            where T : struct
        {
            return this.GetMatrix<T>(Cg.DefaultOrder);
        }

        public T[] GetMatrix<T>(Order order)
            where T : struct
        {
            IntPtr param = this.Handle;
            var retValue = new T[16];
            GCHandle handle = GCHandle.Alloc(retValue, GCHandleType.Pinned);

            try
            {
                if (typeof(T) == typeof(double))
                {
                    switch (order)
                    {
                        case Order.ColumnMajor:
                            CgNativeMethods.cgGetMatrixParameterdc(param, handle.AddrOfPinnedObject());
                            break;
                        case Order.RowMajor:
                            CgNativeMethods.cgGetMatrixParameterdr(param, handle.AddrOfPinnedObject());
                            break;
                        default:
                            throw new InvalidEnumArgumentException("order");
                    }
                }
                else if (typeof(T) == typeof(float))
                {
                    switch (order)
                    {
                        case Order.ColumnMajor:
                            CgNativeMethods.cgGetMatrixParameterfc(param, handle.AddrOfPinnedObject());
                            break;
                        case Order.RowMajor:
                            CgNativeMethods.cgGetMatrixParameterfr(param, handle.AddrOfPinnedObject());
                            break;
                        default:
                            throw new InvalidEnumArgumentException("order");
                    }
                }
                else if (typeof(T) == typeof(int))
                {
                    switch (order)
                    {
                        case Order.ColumnMajor:
                            CgNativeMethods.cgGetMatrixParameteric(param, handle.AddrOfPinnedObject());
                            break;
                        case Order.RowMajor:
                            CgNativeMethods.cgGetMatrixParameterir(param, handle.AddrOfPinnedObject());
                            break;
                        default:
                            throw new InvalidEnumArgumentException("order");
                    }
                }
                else
                {
                    throw new ArgumentException();
                }

                return retValue;
            }
            finally
            {
                handle.Free();
            }
        }

        public Order GetMatrixOrder()
        {
            return CgNativeMethods.cgGetMatrixParameterOrder(this.Handle);
        }

        public Annotation GetNamedAnnotation(string name)
        {
            var ptr = CgNativeMethods.cgGetNamedParameterAnnotation(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new Annotation(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public StateAssignment GetNamedStateAssignment(string name)
        {
            var ptr = CgNativeMethods.cgGetNamedSamplerStateAssignment(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new StateAssignment(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public Parameter GetNamedStructParameter(string name)
        {
            var ptr = CgNativeMethods.cgGetNamedStructParameter(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public Parameter GetNamedSubParameter(string name)
        {
            var ptr = CgNativeMethods.cgGetNamedSubParameter(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr)
                                               {
                                                   OwnsHandle = false
                                               };
        }

        public string GetStringValue()
        {
            return Marshal.PtrToStringAnsi(CgNativeMethods.cgGetStringParameterValue(this.Handle));
        }

        public void GetValue(ref int[] values)
        {
            this.GetValue(ref values, Cg.DefaultOrder);
        }

        public void GetValue(ref int[] values, Order order)
        {
            GCHandle handle = GCHandle.Alloc(values, GCHandleType.Pinned);
            try
            {
                switch (order)
                {
                    case Order.ColumnMajor:
                        CgNativeMethods.cgGetParameterValueic(this.Handle, values.Length, handle.AddrOfPinnedObject());
                        break;
                    case Order.RowMajor:
                        CgNativeMethods.cgGetParameterValueir(this.Handle, values.Length, handle.AddrOfPinnedObject());
                        break;
                    default:
                        throw new InvalidEnumArgumentException("order");
                }
            }
            finally
            {
                handle.Free();
            }
        }

        public void GetValue(ref double[] values)
        {
            this.GetValue(ref values, Cg.DefaultOrder);
        }

        public void GetValue(ref double[] values, Order order)
        {
            GCHandle handle = GCHandle.Alloc(values, GCHandleType.Pinned);
            try
            {
                switch (order)
                {
                    case Order.ColumnMajor:
                        CgNativeMethods.cgGetParameterValuedc(this.Handle, values.Length, handle.AddrOfPinnedObject());
                        break;
                    case Order.RowMajor:
                        CgNativeMethods.cgGetParameterValuedr(this.Handle, values.Length, handle.AddrOfPinnedObject());
                        break;
                    default:
                        throw new InvalidEnumArgumentException("order");
                }
            }
            finally
            {
                handle.Free();
            }
        }

        public void GetValue(ref float[] values)
        {
            this.GetValue(ref values, Cg.DefaultOrder);
        }

        public void GetValue(ref float[] values, Order order)
        {
            GCHandle handle = GCHandle.Alloc(values, GCHandleType.Pinned);
            try
            {
                switch (order)
                {
                    case Order.ColumnMajor:
                        CgNativeMethods.cgGetParameterValuefc(this.Handle, values.Length, handle.AddrOfPinnedObject());
                        break;
                    case Order.RowMajor:
                        CgNativeMethods.cgGetParameterValuefr(this.Handle, values.Length, handle.AddrOfPinnedObject());
                        break;
                    default:
                        throw new InvalidEnumArgumentException("order");
                }
            }
            finally
            {
                handle.Free();
            }
        }

        public T GetValue<T>()
            where T : struct
        {
            var f = new T[1];
            GCHandle handle = GCHandle.Alloc(f, GCHandleType.Pinned);
            try
            {
                if (typeof(T) == typeof(int))
                {
                    CgNativeMethods.cgGetParameterValueir(this.Handle, f.Length, handle.AddrOfPinnedObject());
                }
                else if (typeof(T) == typeof(double))
                {
                    CgNativeMethods.cgGetParameterValuedr(this.Handle, f.Length, handle.AddrOfPinnedObject());
                }
                else if (typeof(T) == typeof(float))
                {
                    CgNativeMethods.cgGetParameterValuefr(this.Handle, f.Length, handle.AddrOfPinnedObject());
                }
            }
            finally
            {
                handle.Free();
            }

            return f[0];
        }

        public bool IsParameterUsed(WrapperObject container)
        {
            return CgNativeMethods.cgIsParameterUsed(this.Handle, container.Handle);
        }

        public void Set(float x)
        {
            CgNativeMethods.cgSetParameter1f(this.Handle, x);
        }

        public void Set(float x, float y)
        {
            CgNativeMethods.cgSetParameter2f(this.Handle, x, y);
        }

        public void Set(float x, float y, float z)
        {
            CgNativeMethods.cgSetParameter3f(this.Handle, x, y, z);
        }

        public void Set(float x, float y, float z, float w)
        {
            CgNativeMethods.cgSetParameter4f(this.Handle, x, y, z, w);
        }

        public void Set(float[] v)
        {
            IntPtr param = this.Handle;
            switch (v.Length)
            {
                case 1:
                    CgNativeMethods.cgSetParameter1fv(param, v);
                    break;
                case 2:
                    CgNativeMethods.cgSetParameter2fv(param, v);
                    break;
                case 3:
                    CgNativeMethods.cgSetParameter3fv(param, v);
                    break;
                case 4:
                    CgNativeMethods.cgSetParameter4fv(param, v);
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        public void Set(int x)
        {
            CgNativeMethods.cgSetParameter1i(this.Handle, x);
        }

        public void Set(int x, int y)
        {
            CgNativeMethods.cgSetParameter2i(this.Handle, x, y);
        }

        public void Set(int x, int y, int z)
        {
            CgNativeMethods.cgSetParameter3i(this.Handle, x, y, z);
        }

        public void Set(int x, int y, int z, int w)
        {
            CgNativeMethods.cgSetParameter4i(this.Handle, x, y, z, w);
        }

        public void Set(int[] v)
        {
            IntPtr param = this.Handle;
            switch (v.Length)
            {
                case 1:
                    CgNativeMethods.cgSetParameter1iv(param, v);
                    break;
                case 2:
                    CgNativeMethods.cgSetParameter2iv(param, v);
                    break;
                case 3:
                    CgNativeMethods.cgSetParameter3iv(param, v);
                    break;
                case 4:
                    CgNativeMethods.cgSetParameter4iv(param, v);
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        public void Set(double x)
        {
            CgNativeMethods.cgSetParameter1d(this.Handle, x);
        }

        public void Set(double x, double y)
        {
            CgNativeMethods.cgSetParameter2d(this.Handle, x, y);
        }

        public void Set(double x, double y, double z)
        {
            CgNativeMethods.cgSetParameter3d(this.Handle, x, y, z);
        }

        public void Set(double x, double y, double z, double w)
        {
            CgNativeMethods.cgSetParameter4d(this.Handle, x, y, z, w);
        }

        public void Set(double[] v)
        {
            IntPtr param = this.Handle;
            switch (v.Length)
            {
                case 1:
                    CgNativeMethods.cgSetParameter1dv(param, v);
                    break;
                case 2:
                    CgNativeMethods.cgSetParameter2dv(param, v);
                    break;
                case 3:
                    CgNativeMethods.cgSetParameter3dv(param, v);
                    break;
                case 4:
                    CgNativeMethods.cgSetParameter4dv(param, v);
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        public void Set1(int[] v)
        {
            CgNativeMethods.cgSetParameter1iv(this.Handle, v);
        }

        public void Set1(float[] v)
        {
            CgNativeMethods.cgSetParameter1fv(this.Handle, v);
        }

        public void Set1(double[] v)
        {
            CgNativeMethods.cgSetParameter1dv(this.Handle, v);
        }

        public void Set2(int[] v)
        {
            CgNativeMethods.cgSetParameter2iv(this.Handle, v);
        }

        public void Set2(float[] v)
        {
            CgNativeMethods.cgSetParameter2fv(this.Handle, v);
        }

        public void Set2(double[] v)
        {
            CgNativeMethods.cgSetParameter2dv(this.Handle, v);
        }

        public void Set3(int[] v)
        {
            CgNativeMethods.cgSetParameter3iv(this.Handle, v);
        }

        public void Set3(float[] v)
        {
            CgNativeMethods.cgSetParameter3fv(this.Handle, v);
        }

        public void Set3(double[] v)
        {
            CgNativeMethods.cgSetParameter3dv(this.Handle, v);
        }

        public void Set4(int[] v)
        {
            CgNativeMethods.cgSetParameter4iv(this.Handle, v);
        }

        public void Set4(float[] v)
        {
            CgNativeMethods.cgSetParameter4fv(this.Handle, v);
        }

        public void Set4(double[] v)
        {
            CgNativeMethods.cgSetParameter4dv(this.Handle, v);
        }

        public void SetArraySize(int size)
        {
            CgNativeMethods.cgSetArraySize(this.Handle, size);
        }

        public void SetEffectParameterBuffer(Buffer buffer)
        {
            CgNativeMethods.cgSetEffectParameterBuffer(this.Handle, buffer.Handle);
        }

        public void SetMatrix(float[] matrix)
        {
            this.SetMatrix(matrix, Cg.DefaultOrder);
        }

        public void SetMatrix(float[] matrix, Order order)
        {
            IntPtr param = this.Handle;
            switch (order)
            {
                case Order.ColumnMajor:
                    CgNativeMethods.cgSetMatrixParameterfc(param, matrix);
                    break;
                case Order.RowMajor:
                    CgNativeMethods.cgSetMatrixParameterfr(param, matrix);
                    break;
                default:
                    throw new InvalidEnumArgumentException("order");
            }
        }

        public void SetMatrix(double[] matrix)
        {
            this.SetMatrix(matrix, Cg.DefaultOrder);
        }

        public void SetMatrix(double[] matrix, Order order)
        {
            IntPtr param = this.Handle;
            switch (order)
            {
                case Order.ColumnMajor:
                    CgNativeMethods.cgSetMatrixParameterdc(param, matrix);
                    break;
                case Order.RowMajor:
                    CgNativeMethods.cgSetMatrixParameterdr(param, matrix);
                    break;
                default:
                    throw new InvalidEnumArgumentException("order");
            }
        }

        public void SetMatrix(int[] matrix)
        {
            this.SetMatrix(matrix, Cg.DefaultOrder);
        }

        public void SetMatrix(int[] matrix, Order order)
        {
            IntPtr param = this.Handle;
            switch (order)
            {
                case Order.ColumnMajor:
                    CgNativeMethods.cgSetMatrixParameteric(param, matrix);
                    break;
                case Order.RowMajor:
                    CgNativeMethods.cgSetMatrixParameterir(param, matrix);
                    break;
                default:
                    throw new InvalidEnumArgumentException("order");
            }
        }

        public void SetMultiDimArraySize(int[] sizes)
        {
            CgNativeMethods.cgSetMultiDimArraySize(this.Handle, sizes);
        }

        public void SetSamplerState()
        {
            CgNativeMethods.cgSetSamplerState(this.Handle);
        }

        public void SetStringValue(string str)
        {
            CgNativeMethods.cgSetStringParameterValue(this.Handle, str);
        }

        public void SetValue(double[] vals)
        {
            this.SetValue(vals, Cg.DefaultOrder);
        }

        public void SetValue(double[] vals, Order order)
        {
            IntPtr param = this.Handle;
            switch (order)
            {
                case Order.ColumnMajor:
                    CgNativeMethods.cgSetParameterValuedc(param, vals.Length, vals);
                    break;
                case Order.RowMajor:
                    CgNativeMethods.cgSetParameterValuedr(param, vals.Length, vals);
                    break;
                default:
                    throw new InvalidEnumArgumentException("order");
            }
        }

        public void SetValue(float[] vals)
        {
            this.SetValue(vals, Cg.DefaultOrder);
        }

        public void SetValue(float[] vals, Order order)
        {
            IntPtr param = this.Handle;
            switch (order)
            {
                case Order.ColumnMajor:
                    CgNativeMethods.cgSetParameterValuefc(param, vals.Length, vals);
                    break;
                case Order.RowMajor:
                    CgNativeMethods.cgSetParameterValuefr(param, vals.Length, vals);
                    break;
                default:
                    throw new InvalidEnumArgumentException("order");
            }
        }

        public void SetValue(int[] vals)
        {
            this.SetValue(vals, Cg.DefaultOrder);
        }

        public void SetValue(int[] vals, Order order)
        {
            IntPtr param = this.Handle;
            switch (order)
            {
                case Order.ColumnMajor:
                    CgNativeMethods.cgSetParameterValueic(param, vals.Length, vals);
                    break;
                case Order.RowMajor:
                    CgNativeMethods.cgSetParameterValueir(param, vals.Length, vals);
                    break;
                default:
                    throw new InvalidEnumArgumentException("order");
            }
        }

        #endregion Public Methods

        #region Protected Methods

        protected override void Dispose(bool disposing)
        {
            if (this.OwnsHandle && this.Handle != IntPtr.Zero && this.IsParameter)
            {
                CgNativeMethods.cgDestroyParameter(this.Handle);
            }
        }

        #endregion Protected Methods

        #endregion Methods
    }
}