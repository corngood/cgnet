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
                return NativeMethods.cgGetParameterBaseResource(this.Handle);
            }
        }

        public ParameterType BaseType
        {
            get
            {
                return NativeMethods.cgGetParameterBaseType(this.Handle);
            }
        }

        public int BufferIndex
        {
            get
            {
                return NativeMethods.cgGetParameterBufferIndex(this.Handle);
            }
        }

        public int BufferOffset
        {
            get
            {
                return NativeMethods.cgGetParameterBufferOffset(this.Handle);
            }
        }

        public ParameterClass Class
        {
            get
            {
                return NativeMethods.cgGetParameterClass(this.Handle);
            }
        }

        public int Columns
        {
            get
            {
                return NativeMethods.cgGetParameterColumns(this.Handle);
            }
        }

        public Parameter ConnectedParameter
        {
            get
            {
                var ptr = NativeMethods.cgGetConnectedParameter(this.Handle);
                return ptr == IntPtr.Zero ? null : new Parameter(ptr)
                {
                    OwnsHandle = false
                };
            }
        }

        public int ConnectedToParametersCount
        {
            get
            {
                return NativeMethods.cgGetNumConnectedToParameters(this.Handle);
            }
        }

        public Context Context
        {
            get
            {
                var ptr = NativeMethods.cgGetParameterContext(this.Handle);
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
                var ptr = NativeMethods.cgGetParameterEffect(this.Handle);
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
                var ptr = NativeMethods.cgGetFirstParameterAnnotation(this.Handle);
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
                var ptr = NativeMethods.cgGetFirstSamplerStateAssignment(this.Handle);
                return ptr == IntPtr.Zero ? null : new StateAssignment(ptr)
                {
                    OwnsHandle = false
                };
            }
        }

        public Parameter FirstUniformBufferParameter
        {
            get
            {
                var ptr = NativeMethods.cgGetFirstUniformBufferParameter(this.Handle);
                return ptr == IntPtr.Zero ? null : new Parameter(ptr)
                {
                    OwnsHandle = false
                };
            }
        }

        public int Index
        {
            get
            {
                return NativeMethods.cgGetParameterIndex(this.Handle);
            }
        }

        public bool IsGlobal
        {
            get
            {
                return NativeMethods.cgIsParameterGlobal(this.Handle);
            }
        }

        public bool IsParameter
        {
            get
            {
                return NativeMethods.cgIsParameter(this.Handle);
            }
        }

        public bool IsReferenced
        {
            get
            {
                return NativeMethods.cgIsParameterReferenced(this.Handle);
            }
        }

        public string Name
        {
            get
            {
                return Marshal.PtrToStringAnsi(NativeMethods.cgGetParameterName(this.Handle));
            }
        }

        public ParameterType NamedType
        {
            get
            {
                return NativeMethods.cgGetParameterNamedType(this.Handle);
            }
        }

        public Parameter NextLeafParameter
        {
            get
            {
                var ptr = NativeMethods.cgGetNextLeafParameter(this.Handle);
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
                var ptr = NativeMethods.cgGetNextParameter(this.Handle);
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
                return NativeMethods.cgGetParameterOrdinalNumber(this.Handle);
            }
        }

        public ParameterDirection ParameterDirection
        {
            get
            {
                return NativeMethods.cgGetParameterDirection(this.Handle);
            }
        }

        public Program Program
        {
            get
            {
                var ptr = NativeMethods.cgGetParameterProgram(this.Handle);
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
                return NativeMethods.cgGetParameterResource(this.Handle);
            }
        }

        public int ResourceIndex
        {
            get
            {
                return (int)NativeMethods.cgGetParameterResourceIndex(this.Handle);
            }
        }

        public string ResourceName
        {
            get
            {
                return Marshal.PtrToStringAnsi(NativeMethods.cgGetParameterResourceName(this.Handle));
            }
        }

        public int ResourceSize
        {
            get
            {
                return NativeMethods.cgGetParameterResourceSize(this.Handle);
            }
        }

        public ParameterType ResourceType
        {
            get
            {
                return NativeMethods.cgGetParameterResourceType(this.Handle);
            }
        }

        public int Rows
        {
            get
            {
                return NativeMethods.cgGetParameterRows(this.Handle);
            }
        }

        public string Semantic
        {
            get
            {
                return Marshal.PtrToStringAnsi(NativeMethods.cgGetParameterSemantic(this.Handle));
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value");
                }

                NativeMethods.cgSetParameterSemantic(this.Handle, value);
            }
        }

        public ParameterType Type
        {
            get
            {
                return NativeMethods.cgGetParameterType(this.Handle);
            }
        }

        public Buffer UniformBuffer
        {
            get
            {
                var ptr = NativeMethods.cgGetUniformBufferParameter(this.Handle);
                return ptr == IntPtr.Zero ? null : new Buffer(ptr)
                {
                    OwnsHandle = false
                };
            }

            set
            {
                NativeMethods.cgSetUniformBufferParameter(this.Handle, value.Handle);
            }
        }

        public string UniformBufferBlockName
        {
            get
            {
                return NativeMethods.cgGetUniformBufferBlockName(this.Handle);
            }
        }

        public Variability Variability
        {
            get
            {
                return NativeMethods.cgGetParameterVariability(this.Handle);
            }

            set
            {
                if (value != Variability.Literal && value != Variability.Uniform && value != Variability.Default)
                {
                    throw new ArgumentException("value must be CG_UNIFORM, CG_LITERAL, or CG_DEFAULT", "value");
                }

                NativeMethods.cgSetParameterVariability(this.Handle, value);
            }
        }

        #endregion Public Properties

        #endregion Properties

        #region Methods

        #region Public Static Methods

        public static void Connect(Parameter from, Parameter to)
        {
            NativeMethods.cgConnectParameter(from.Handle, to.Handle);
        }

        public static Parameter Create(Context context, ParameterType type)
        {
            return context.CreateParameter(type);
        }

        #endregion Public Static Methods

        #region Public Methods

        public void Connect(Parameter to)
        {
            NativeMethods.cgConnectParameter(this.Handle, to.Handle);
        }

        public Annotation CreateAnnotation(string name, ParameterType type)
        {
            var ptr = NativeMethods.cgCreateParameterAnnotation(this.Handle, name, type);
            return ptr == IntPtr.Zero ? null : new Annotation(ptr);
        }

        public void Disconnect()
        {
            NativeMethods.cgDisconnectParameter(this.Handle);
        }

        public int GetArrayDimension()
        {
            return NativeMethods.cgGetArrayDimension(this.Handle);
        }

        public Parameter GetArrayParameter(int index)
        {
            var ptr = NativeMethods.cgGetArrayParameter(this.Handle, index);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr)
            {
                OwnsHandle = false
            };
        }

        public int GetArraySize(int dimension)
        {
            return NativeMethods.cgGetArraySize(this.Handle, dimension);
        }

        public int GetArrayTotalSize()
        {
            return NativeMethods.cgGetArrayTotalSize(this.Handle);
        }

        public ParameterType GetArrayType()
        {
            return NativeMethods.cgGetArrayType(this.Handle);
        }

        public Parameter GetConnectedToParameter(int index)
        {
            var ptr = NativeMethods.cgGetConnectedToParameter(this.Handle, index);
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
                    return NativeMethods.cgGetParameterDefaultValuedc(param, values.Length, values);
                case Order.RowMajor:
                    return NativeMethods.cgGetParameterDefaultValuedr(param, values.Length, values);
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
                    return NativeMethods.cgGetParameterDefaultValueic(param, values.Length, values);
                case Order.RowMajor:
                    return NativeMethods.cgGetParameterDefaultValueir(param, values.Length, values);
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
                    return NativeMethods.cgGetParameterDefaultValuefc(param, values.Length, values);
                case Order.RowMajor:
                    return NativeMethods.cgGetParameterDefaultValuefr(param, values.Length, values);
                default:
                    throw new ArgumentOutOfRangeException("order");
            }
        }

        public Buffer GetEffectParameterBuffer()
        {
            var ptr = NativeMethods.cgGetEffectParameterBuffer(this.Handle);
            return ptr == IntPtr.Zero ? null : new Buffer(ptr)
            {
                OwnsHandle = false
            };
        }

        public Parameter GetFirstDependentParameter()
        {
            var ptr = NativeMethods.cgGetFirstDependentParameter(this.Handle);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr)
            {
                OwnsHandle = false
            };
        }

        public Parameter GetFirstStructParameter()
        {
            var ptr = NativeMethods.cgGetFirstStructParameter(this.Handle);
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
                            NativeMethods.cgGetMatrixParameterdc(param, handle.AddrOfPinnedObject());
                            break;
                        case Order.RowMajor:
                            NativeMethods.cgGetMatrixParameterdr(param, handle.AddrOfPinnedObject());
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
                            NativeMethods.cgGetMatrixParameterfc(param, handle.AddrOfPinnedObject());
                            break;
                        case Order.RowMajor:
                            NativeMethods.cgGetMatrixParameterfr(param, handle.AddrOfPinnedObject());
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
                            NativeMethods.cgGetMatrixParameteric(param, handle.AddrOfPinnedObject());
                            break;
                        case Order.RowMajor:
                            NativeMethods.cgGetMatrixParameterir(param, handle.AddrOfPinnedObject());
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
            return NativeMethods.cgGetMatrixParameterOrder(this.Handle);
        }

        public Annotation GetNamedAnnotation(string name)
        {
            var ptr = NativeMethods.cgGetNamedParameterAnnotation(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new Annotation(ptr)
            {
                OwnsHandle = false
            };
        }

        public StateAssignment GetNamedStateAssignment(string name)
        {
            var ptr = NativeMethods.cgGetNamedSamplerStateAssignment(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new StateAssignment(ptr)
            {
                OwnsHandle = false
            };
        }

        public Parameter GetNamedStructParameter(string name)
        {
            var ptr = NativeMethods.cgGetNamedStructParameter(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr)
            {
                OwnsHandle = false
            };
        }

        public Parameter GetNamedSubParameter(string name)
        {
            var ptr = NativeMethods.cgGetNamedSubParameter(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr)
            {
                OwnsHandle = false
            };
        }

        public Parameter GetNamedUniformBufferParameter(string name)
        {
            var ptr = NativeMethods.cgGetNamedUniformBufferParameter(this.Handle, name);
            return ptr == IntPtr.Zero ? null : new Parameter(ptr)
            {
                OwnsHandle = false
            };
        }

        public string GetStringValue()
        {
            return Marshal.PtrToStringAnsi(NativeMethods.cgGetStringParameterValue(this.Handle));
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
                        NativeMethods.cgGetParameterValueic(this.Handle, values.Length, handle.AddrOfPinnedObject());
                        break;
                    case Order.RowMajor:
                        NativeMethods.cgGetParameterValueir(this.Handle, values.Length, handle.AddrOfPinnedObject());
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
                        NativeMethods.cgGetParameterValuedc(this.Handle, values.Length, handle.AddrOfPinnedObject());
                        break;
                    case Order.RowMajor:
                        NativeMethods.cgGetParameterValuedr(this.Handle, values.Length, handle.AddrOfPinnedObject());
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
                        NativeMethods.cgGetParameterValuefc(this.Handle, values.Length, handle.AddrOfPinnedObject());
                        break;
                    case Order.RowMajor:
                        NativeMethods.cgGetParameterValuefr(this.Handle, values.Length, handle.AddrOfPinnedObject());
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
                    NativeMethods.cgGetParameterValueir(this.Handle, f.Length, handle.AddrOfPinnedObject());
                }
                else if (typeof(T) == typeof(double))
                {
                    NativeMethods.cgGetParameterValuedr(this.Handle, f.Length, handle.AddrOfPinnedObject());
                }
                else if (typeof(T) == typeof(float))
                {
                    NativeMethods.cgGetParameterValuefr(this.Handle, f.Length, handle.AddrOfPinnedObject());
                }
            }
            finally
            {
                handle.Free();
            }

            return f[0];
        }

        public bool IsUsed(WrapperObject container)
        {
            return NativeMethods.cgIsParameterUsed(this.Handle, container.Handle);
        }

        public void Set(float x)
        {
            NativeMethods.cgSetParameter1f(this.Handle, x);
        }

        public void Set(float x, float y)
        {
            NativeMethods.cgSetParameter2f(this.Handle, x, y);
        }

        public void Set(float x, float y, float z)
        {
            NativeMethods.cgSetParameter3f(this.Handle, x, y, z);
        }

        public void Set(float x, float y, float z, float w)
        {
            NativeMethods.cgSetParameter4f(this.Handle, x, y, z, w);
        }

        public void Set(float[] v)
        {
            IntPtr param = this.Handle;
            switch (v.Length)
            {
                case 1:
                    NativeMethods.cgSetParameter1fv(param, v);
                    break;
                case 2:
                    NativeMethods.cgSetParameter2fv(param, v);
                    break;
                case 3:
                    NativeMethods.cgSetParameter3fv(param, v);
                    break;
                case 4:
                    NativeMethods.cgSetParameter4fv(param, v);
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        public void Set(int x)
        {
            NativeMethods.cgSetParameter1i(this.Handle, x);
        }

        public void Set(int x, int y)
        {
            NativeMethods.cgSetParameter2i(this.Handle, x, y);
        }

        public void Set(int x, int y, int z)
        {
            NativeMethods.cgSetParameter3i(this.Handle, x, y, z);
        }

        public void Set(int x, int y, int z, int w)
        {
            NativeMethods.cgSetParameter4i(this.Handle, x, y, z, w);
        }

        public void Set(int[] v)
        {
            IntPtr param = this.Handle;
            switch (v.Length)
            {
                case 1:
                    NativeMethods.cgSetParameter1iv(param, v);
                    break;
                case 2:
                    NativeMethods.cgSetParameter2iv(param, v);
                    break;
                case 3:
                    NativeMethods.cgSetParameter3iv(param, v);
                    break;
                case 4:
                    NativeMethods.cgSetParameter4iv(param, v);
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        public void Set(double x)
        {
            NativeMethods.cgSetParameter1d(this.Handle, x);
        }

        public void Set(double x, double y)
        {
            NativeMethods.cgSetParameter2d(this.Handle, x, y);
        }

        public void Set(double x, double y, double z)
        {
            NativeMethods.cgSetParameter3d(this.Handle, x, y, z);
        }

        public void Set(double x, double y, double z, double w)
        {
            NativeMethods.cgSetParameter4d(this.Handle, x, y, z, w);
        }

        public void Set(double[] v)
        {
            IntPtr param = this.Handle;
            switch (v.Length)
            {
                case 1:
                    NativeMethods.cgSetParameter1dv(param, v);
                    break;
                case 2:
                    NativeMethods.cgSetParameter2dv(param, v);
                    break;
                case 3:
                    NativeMethods.cgSetParameter3dv(param, v);
                    break;
                case 4:
                    NativeMethods.cgSetParameter4dv(param, v);
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        public void Set1(int[] v)
        {
            NativeMethods.cgSetParameter1iv(this.Handle, v);
        }

        public void Set1(float[] v)
        {
            NativeMethods.cgSetParameter1fv(this.Handle, v);
        }

        public void Set1(double[] v)
        {
            NativeMethods.cgSetParameter1dv(this.Handle, v);
        }

        public void Set2(int[] v)
        {
            NativeMethods.cgSetParameter2iv(this.Handle, v);
        }

        public void Set2(float[] v)
        {
            NativeMethods.cgSetParameter2fv(this.Handle, v);
        }

        public void Set2(double[] v)
        {
            NativeMethods.cgSetParameter2dv(this.Handle, v);
        }

        public void Set3(int[] v)
        {
            NativeMethods.cgSetParameter3iv(this.Handle, v);
        }

        public void Set3(float[] v)
        {
            NativeMethods.cgSetParameter3fv(this.Handle, v);
        }

        public void Set3(double[] v)
        {
            NativeMethods.cgSetParameter3dv(this.Handle, v);
        }

        public void Set4(int[] v)
        {
            NativeMethods.cgSetParameter4iv(this.Handle, v);
        }

        public void Set4(float[] v)
        {
            NativeMethods.cgSetParameter4fv(this.Handle, v);
        }

        public void Set4(double[] v)
        {
            NativeMethods.cgSetParameter4dv(this.Handle, v);
        }

        public void SetArraySize(int size)
        {
            NativeMethods.cgSetArraySize(this.Handle, size);
        }

        public void SetEffectParameterBuffer(Buffer buffer)
        {
            NativeMethods.cgSetEffectParameterBuffer(this.Handle, buffer.Handle);
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
                    NativeMethods.cgSetMatrixParameterfc(param, matrix);
                    break;
                case Order.RowMajor:
                    NativeMethods.cgSetMatrixParameterfr(param, matrix);
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
            switch (order)
            {
                case Order.ColumnMajor:
                    NativeMethods.cgSetMatrixParameterdc(this.Handle, matrix);
                    break;
                case Order.RowMajor:
                    NativeMethods.cgSetMatrixParameterdr(this.Handle, matrix);
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
            switch (order)
            {
                case Order.ColumnMajor:
                    NativeMethods.cgSetMatrixParameteric(this.Handle, matrix);
                    break;
                case Order.RowMajor:
                    NativeMethods.cgSetMatrixParameterir(this.Handle, matrix);
                    break;
                default:
                    throw new InvalidEnumArgumentException("order");
            }
        }

        public void SetMultiDimArraySize(int[] sizes)
        {
            NativeMethods.cgSetMultiDimArraySize(this.Handle, sizes);
        }

        public void SetSamplerState()
        {
            NativeMethods.cgSetSamplerState(this.Handle);
        }

        public void SetStringValue(string str)
        {
            NativeMethods.cgSetStringParameterValue(this.Handle, str);
        }

        public void SetValue(double[] vals)
        {
            this.SetValue(vals, Cg.DefaultOrder);
        }

        public void SetValue(double[] vals, Order order)
        {
            switch (order)
            {
                case Order.ColumnMajor:
                    NativeMethods.cgSetParameterValuedc(this.Handle, vals.Length, vals);
                    break;
                case Order.RowMajor:
                    NativeMethods.cgSetParameterValuedr(this.Handle, vals.Length, vals);
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
            switch (order)
            {
                case Order.ColumnMajor:
                    NativeMethods.cgSetParameterValuefc(this.Handle, vals.Length, vals);
                    break;
                case Order.RowMajor:
                    NativeMethods.cgSetParameterValuefr(this.Handle, vals.Length, vals);
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
            switch (order)
            {
                case Order.ColumnMajor:
                    NativeMethods.cgSetParameterValueic(this.Handle, vals.Length, vals);
                    break;
                case Order.RowMajor:
                    NativeMethods.cgSetParameterValueir(this.Handle, vals.Length, vals);
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
                NativeMethods.cgDestroyParameter(this.Handle);
            }
        }

        #endregion Protected Methods

        #endregion Methods
    }
}