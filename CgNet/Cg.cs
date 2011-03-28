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
    using System.Text;

    /// <summary>
    /// 
    /// </summary>
    public static class Cg
    {
        #region Delegates

        /// <summary>
        ///    
        /// </summary>
        // typedef void (*CGerrorCallbackFunc)(void);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CgErrorCallbackFuncDelegate();

        /// <summary>
        ///    
        /// </summary>
        // typedef void (*CGerrorHandlerFunc)(CGcontext context, CGerror err, void *data);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CgErrorHandlerFuncDelegate(IntPtr context, ErrorType err, IntPtr data);

        /// <summary>
        /// 
        /// </summary>
        // typedef void (*CGIncludeCallbackFunc)( CGcontext context, const char *filename );
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CgIncludeCallbackFunc(IntPtr context, string filename);

        /// <summary>
        /// 
        /// </summary>
        // typedef CGbool (*CGstatecallback)(CGstateassignment);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool CgStateCallbackDelegate(IntPtr cGstateassignment);

        #endregion Delegates

        #region Methods

        #region Public Static Methods

        public static Behavior GetBehavior(string behaviorString)
        {
            return CgNativeMethods.cgGetBehavior(behaviorString);
        }

        public static string GetBehaviorString(Behavior behavior)
        {
            return Marshal.PtrToStringAnsi(CgNativeMethods.cgGetBehaviorString(behavior));
        }

        public static Domain GetDomain(string domainString)
        {
            return CgNativeMethods.cgGetDomain(domainString);
        }

        public static string GetDomainString(Domain domain)
        {
            return Marshal.PtrToStringAnsi(CgNativeMethods.cgGetDomainString(domain));
        }

        public static int GetEnum(string enumString)
        {
            return CgNativeMethods.cgGetEnum(enumString);
        }

        public static string GetEnumString(int en)
        {
            return Marshal.PtrToStringAnsi(CgNativeMethods.cgGetEnumString(en));
        }

        public static ErrorType GetError()
        {
            return CgNativeMethods.cgGetError();
        }

        public static CgErrorCallbackFuncDelegate GetErrorCallback()
        {
            return CgNativeMethods.cgGetErrorCallback();
        }

        public static CgErrorHandlerFuncDelegate GetErrorHandler(IntPtr data)
        {
            return CgNativeMethods.cgGetErrorHandler(data);
        }

        public static IntPtr GetErrorString(ErrorType error)
        {
            return CgNativeMethods.cgGetErrorString(error);
        }

        public static ErrorType GetFirstError()
        {
            return CgNativeMethods.cgGetFirstError();
        }

        public static string GetLastErrorString(out ErrorType error)
        {
            return Marshal.PtrToStringAnsi(CgNativeMethods.cgGetLastErrorString(out error));
        }

        public static LockingPolicy GetLockingPolicy()
        {
            return CgNativeMethods.cgGetLockingPolicy();
        }

        public static ParameterType GetMatrixSize(ParameterType type, out int nrows, out int ncols)
        {
            return CgNativeMethods.cgGetMatrixSize(type, out nrows, out ncols);
        }

        public static int GetNumParentTypes(ParameterType type)
        {
            return CgNativeMethods.cgGetNumParentTypes(type);
        }

        public static int GetNumSupportedProfiles()
        {
            return CgNativeMethods.cgGetNumSupportedProfiles();
        }

        public static ParameterClass GetParameterClassEnum(string pString)
        {
            return CgNativeMethods.cgGetParameterClassEnum(pString);
        }

        public static string GetParameterClassString(ParameterClass pc)
        {
            return Marshal.PtrToStringAnsi(CgNativeMethods.cgGetParameterClassString(pc));
        }

        public static ParameterType GetParentType(ParameterType type, int index)
        {
            return CgNativeMethods.cgGetParentType(type, index);
        }

        public static ProfileType GetProfile(string profile)
        {
            return CgNativeMethods.cgGetProfile(profile);
        }

        public static Domain GetProfileDomain(ProfileType profile)
        {
            return CgNativeMethods.cgGetProfileDomain(profile);
        }

        public static bool GetProfileProperty(ProfileType profile, Query query)
        {
            return CgNativeMethods.cgGetProfileProperty(profile, query);
        }

        public static string GetProfileString(ProfileType profile)
        {
            return Marshal.PtrToStringAnsi(CgNativeMethods.cgGetProfileString(profile));
        }

        public static int GetProgramBufferMaxIndex(ProfileType profile)
        {
            return CgNativeMethods.cgGetProgramBufferMaxIndex(profile);
        }

        public static int GetProgramBufferMaxSize(ProfileType profile)
        {
            return CgNativeMethods.cgGetProgramBufferMaxSize(profile);
        }

        public static ResourceType GetResource(string resourceName)
        {
            return CgNativeMethods.cgGetResource(resourceName);
        }

        public static string GetResourceString(ResourceType resource)
        {
            return Marshal.PtrToStringAnsi(CgNativeMethods.cgGetResourceString(resource));
        }

        public static CasePolicy GetSemanticCasePolicy()
        {
            return CgNativeMethods.cgGetSemanticCasePolicy();
        }

        public static string GetString(CgAll sname)
        {
            return Marshal.PtrToStringAnsi(CgNativeMethods.cgGetString(sname));
        }

        public static ProfileType GetSupportedProfile(int index)
        {
            return CgNativeMethods.cgGetSupportedProfile(index);
        }

        public static ParameterType GetType(string typeString)
        {
            return CgNativeMethods.cgGetType(typeString);
        }

        public static ParameterType GetTypeBase(ParameterType type)
        {
            return CgNativeMethods.cgGetTypeBase(type);
        }

        public static ParameterClass GetTypeClass(ParameterType type)
        {
            return CgNativeMethods.cgGetTypeClass(type);
        }

        public static bool GetTypeSizes(ParameterType type, out int nrows, out int ncols)
        {
            return CgNativeMethods.cgGetTypeSizes(type, out nrows, out ncols);
        }

        public static string GetTypeString(ParameterType type)
        {
            return Marshal.PtrToStringAnsi(CgNativeMethods.cgGetTypeString(type));
        }

        public static bool IsInterfaceType(ParameterType type)
        {
            return CgNativeMethods.cgIsInterfaceType(type);
        }

        public static bool IsParentType(ParameterType parent, int child)
        {
            return CgNativeMethods.cgIsParentType(parent, child);
        }

        public static bool IsProfileSupported(ProfileType profile)
        {
            return CgNativeMethods.cgIsProfileSupported(profile);
        }

        public static void SetErrorCallback(CgErrorCallbackFuncDelegate func)
        {
            CgNativeMethods.cgSetErrorCallback(func);
        }

        public static void SetErrorHandler(CgErrorHandlerFuncDelegate func, IntPtr data)
        {
            CgNativeMethods.cgSetErrorHandler(func, data);
        }

        public static LockingPolicy SetLockingPolicy(LockingPolicy lockingPolicy)
        {
            return CgNativeMethods.cgSetLockingPolicy(lockingPolicy);
        }

        public static CasePolicy SetSemanticCasePolicy(CasePolicy casePolicy)
        {
            return CgNativeMethods.cgSetSemanticCasePolicy(casePolicy);
        }

        #endregion Public Static Methods

        #region Internal Static Methods

        internal static T[] GetMatrixParameter<T>(IntPtr param, Order order)
            where T : struct
        {
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

        internal static int GetParameterDefaultValue(IntPtr param, ref double[] values, Order order)
        {
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

        internal static int GetParameterDefaultValue(IntPtr param, ref int[] values, Order order)
        {
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

        internal static int GetParameterDefaultValue(IntPtr param, ref float[] values, Order order)
        {
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

        internal static T GetParameterValue<T>(IntPtr param)
            where T : struct
        {
            var f = new T[1];
            GetParameterValue(param, ref f);
            return f[0];
        }

        internal static void GetParameterValue<T>(IntPtr param, ref T[] values)
            where T : struct
        {
            GetParameterValue(param, ref values, Order.RowMajor);
        }

        internal static void GetParameterValue<T>(IntPtr param, ref T[] values, Order order)
            where T : struct
        {
            GCHandle handle = GCHandle.Alloc(values, GCHandleType.Pinned);
            try
            {
                if (typeof(T) == typeof(int))
                {
                    switch (order)
                    {
                        case Order.ColumnMajor:
                            CgNativeMethods.cgGetParameterValueic(param, values.Length, handle.AddrOfPinnedObject());
                            break;
                        case Order.RowMajor:
                            CgNativeMethods.cgGetParameterValueir(param, values.Length, handle.AddrOfPinnedObject());
                            break;
                        default:
                            throw new InvalidEnumArgumentException("order");
                    }
                }
                else if (typeof(T) == typeof(double))
                {
                    switch (order)
                    {
                        case Order.ColumnMajor:
                            CgNativeMethods.cgGetParameterValuedc(param, values.Length, handle.AddrOfPinnedObject());
                            break;
                        case Order.RowMajor:
                            CgNativeMethods.cgGetParameterValuedr(param, values.Length, handle.AddrOfPinnedObject());
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
                            CgNativeMethods.cgGetParameterValuefc(param, values.Length, handle.AddrOfPinnedObject());
                            break;
                        case Order.RowMajor:
                            CgNativeMethods.cgGetParameterValuefr(param, values.Length, handle.AddrOfPinnedObject());
                            break;
                        default:
                            throw new InvalidEnumArgumentException("order");
                    }
                }
            }
            finally
            {
                handle.Free();
            }
        }

        internal static bool[] IntPtrToBoolArray(IntPtr values, int count)
        {
            if (count > 0)
            {
                var retValue = new bool[count];
                unsafe
                {
                    var ii = (int*)values;
                    for (int i = 0; i < count; i++)
                    {
                        retValue[i] = ii[i] == CgNativeMethods.CgTrue;
                    }
                }

                return retValue;
            }

            return null;
        }

        internal static unsafe string[] IntPtrToStringArray(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
            {
                return null;
            }

            var byteArray = (byte**)ptr;
            var lines = new List<string>();
            var buffer = new List<byte>();

            for (; ; )
            {
                byte* b = *byteArray;
                for (; ; )
                {
                    if (b == null || *b == '\0')
                    {
                        if (buffer.Count > 0)
                        {
                            char[] cc = Encoding.ASCII.GetChars(buffer.ToArray());
                            lines.Add(new string(cc));
                            buffer.Clear();
                        }
                        break;
                    }

                    buffer.Add(*b);
                    b++;
                }

                byteArray++;

                if (b == null)
                {
                    break;
                }
            }

            return lines.Count == 0 ? null : lines.ToArray();
        }

        internal static void SetMatrixParameter(IntPtr param, float[] matrix, Order order)
        {
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

        internal static void SetMatrixParameter(IntPtr param, double[] matrix, Order order)
        {
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

        internal static void SetMatrixParameter(IntPtr param, int[] matrix, Order order)
        {
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

        internal static void SetParameterValue(IntPtr param, double[] vals, Order order)
        {
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

        internal static void SetParameterValue(IntPtr param, float[] vals, Order order)
        {
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

        internal static void SetParameterValue(IntPtr param, int[] vals, Order order)
        {
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

        #endregion Internal Static Methods

        #endregion Methods
    }
}