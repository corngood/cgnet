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
    using System.Runtime.InteropServices;
    using System.Text;

    /// <summary>
    /// 
    /// </summary>
    public static class Cg
    {
        #region Fields

        private static readonly object PadLock = new object();

        #endregion Fields

        #region Constructors

        static Cg()
        {
            DefaultOrder = Order.RowMajor;
        }

        #endregion Constructors

        #region Delegates

        /// <summary>
        ///    
        /// </summary>
        // typedef void (*CGerrorHandlerFunc)(CGcontext context, CGerror err, void *data);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CgErrorHandlerFuncDelegate(IntPtr context, ErrorType err, IntPtr data);

        #endregion Delegates

        #region Events

        public static event EventHandler<ErrorEventArgs> Error
        {
            add
            {
                lock (PadLock)
                {
                    if (error == null)
                    {
                        CgNativeMethods.cgSetErrorCallback(OnError);
                    }

                    error += value;
                }
            }

            remove
            {
                lock (PadLock)
                {
                    error -= value;

                    if (error == null)
                    {
                        CgNativeMethods.cgSetErrorCallback(null);
                    }
                }
            }
        }

        private static event EventHandler<ErrorEventArgs> error;

        #endregion Events

        #region Properties

        #region Public Static Properties

        public static Order DefaultOrder
        {
            get;
            set;
        }

        public static LockingPolicy LockingPolicy
        {
            get
            {
                return CgNativeMethods.cgGetLockingPolicy();
            }

            set
            {
                CgNativeMethods.cgSetLockingPolicy(value);
            }
        }

        public static CasePolicy SemanticCasePolicy
        {
            get
            {
                return CgNativeMethods.cgGetSemanticCasePolicy();
            }

            set
            {
                CgNativeMethods.cgSetSemanticCasePolicy(value);
            }
        }

        public static IEnumerable<ProfileType> SupportedProfiles
        {
            get
            {
                int count = Cg.SupportedProfilesCount;
                for (int i = 0; i < count; i++)
                {
                    yield return Cg.GetSupportedProfile(i);
                }
            }
        }

        public static int SupportedProfilesCount
        {
            get
            {
                return CgNativeMethods.cgGetNumSupportedProfiles();
            }
        }

        #endregion Public Static Properties

        #endregion Properties

        #region Methods

        #region Public Static Methods

        public static ErrorType GetError()
        {
            return CgNativeMethods.cgGetError();
        }

        public static CgErrorHandlerFuncDelegate GetErrorHandler(IntPtr data)
        {
            return CgNativeMethods.cgGetErrorHandler(data);
        }

        public static ErrorType GetFirstError()
        {
            return CgNativeMethods.cgGetFirstError();
        }

        public static string GetLastErrorString(out ErrorType error)
        {
            return Marshal.PtrToStringAnsi(CgNativeMethods.cgGetLastErrorString(out error));
        }

        public static ParameterType GetMatrixSize(ParameterType type, out int nrows, out int ncols)
        {
            return CgNativeMethods.cgGetMatrixSize(type, out nrows, out ncols);
        }

        public static ParameterType GetParentType(ParameterType type, int index)
        {
            return CgNativeMethods.cgGetParentType(type, index);
        }

        public static int GetParentTypesCount(ParameterType type)
        {
            return CgNativeMethods.cgGetNumParentTypes(type);
        }

        public static Domain GetProfileDomain(ProfileType profile)
        {
            return CgNativeMethods.cgGetProfileDomain(profile);
        }

        public static bool GetProfileProperty(ProfileType profile, Query query)
        {
            return CgNativeMethods.cgGetProfileProperty(profile, query);
        }

        public static int GetProgramBufferMaxIndex(ProfileType profile)
        {
            return CgNativeMethods.cgGetProgramBufferMaxIndex(profile);
        }

        public static int GetProgramBufferMaxSize(ProfileType profile)
        {
            return CgNativeMethods.cgGetProgramBufferMaxSize(profile);
        }

        public static ProfileType GetSupportedProfile(int index)
        {
            return CgNativeMethods.cgGetSupportedProfile(index);
        }

        public static bool GetTypeSizes(ParameterType type, out int nrows, out int ncols)
        {
            return CgNativeMethods.cgGetTypeSizes(type, out nrows, out ncols);
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

        public static void SetErrorHandler(CgErrorHandlerFuncDelegate func, IntPtr data)
        {
            CgNativeMethods.cgSetErrorHandler(func, data);
        }

        #endregion Public Static Methods

        #region Internal Static Methods

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

        #endregion Internal Static Methods

        #region Private Static Methods

        private static void OnError()
        {
            if (error != null)
            {
                error(null, new ErrorEventArgs(Cg.GetError()));
            }
        }

        #endregion Private Static Methods

        #endregion Methods
    }
}