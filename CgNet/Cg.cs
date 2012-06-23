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
            DefaultMatrixOrder = MatrixOrder.RowMajor;
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
                        NativeMethods.cgSetErrorCallback(OnError);
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
                        NativeMethods.cgSetErrorCallback(null);
                    }
                }
            }
        }

        private static event EventHandler<ErrorEventArgs> error;

        #endregion Events

        #region Properties

        #region Public Static Properties

        public static MatrixOrder DefaultMatrixOrder
        {
            get;
            set;
        }

        public static LockingPolicy LockingPolicy
        {
            get
            {
                return NativeMethods.cgGetLockingPolicy();
            }

            set
            {
                NativeMethods.cgSetLockingPolicy(value);
            }
        }

        public static CasePolicy SemanticCasePolicy
        {
            get
            {
                return NativeMethods.cgGetSemanticCasePolicy();
            }

            set
            {
                NativeMethods.cgSetSemanticCasePolicy(value);
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
                return NativeMethods.cgGetNumSupportedProfiles();
            }
        }

        #endregion Public Static Properties

        #endregion Properties

        #region Methods

        #region Public Static Methods

        public static ErrorType GetError()
        {
            return NativeMethods.cgGetError();
        }

        public static CgErrorHandlerFuncDelegate GetErrorHandler(IntPtr data)
        {
            return NativeMethods.cgGetErrorHandler(data);
        }

        public static ErrorType GetFirstError()
        {
            return NativeMethods.cgGetFirstError();
        }

        public static string GetLastErrorString(out ErrorType error)
        {
            return Marshal.PtrToStringAnsi(NativeMethods.cgGetLastErrorString(out error));
        }

        public static ParameterType GetMatrixSize(ParameterType type, out int nrows, out int ncols)
        {
            return NativeMethods.cgGetMatrixSize(type, out nrows, out ncols);
        }

        public static ParameterType GetParentType(ParameterType type, int index)
        {
            return NativeMethods.cgGetParentType(type, index);
        }

        public static int GetParentTypesCount(ParameterType type)
        {
            return NativeMethods.cgGetNumParentTypes(type);
        }

        public static Domain GetProfileDomain(ProfileType profile)
        {
            return NativeMethods.cgGetProfileDomain(profile);
        }

        public static bool GetProfileProperty(ProfileType profile, Query query)
        {
            return NativeMethods.cgGetProfileProperty(profile, query);
        }

        public static int GetProgramBufferMaxIndex(ProfileType profile)
        {
            return NativeMethods.cgGetProgramBufferMaxIndex(profile);
        }

        public static int GetProgramBufferMaxSize(ProfileType profile)
        {
            return NativeMethods.cgGetProgramBufferMaxSize(profile);
        }

        public static ProfileType GetSupportedProfile(int index)
        {
            return NativeMethods.cgGetSupportedProfile(index);
        }

        public static bool GetTypeSizes(ParameterType type, out int nrows, out int ncols)
        {
            return NativeMethods.cgGetTypeSizes(type, out nrows, out ncols);
        }

        public static bool IsInterfaceType(ParameterType type)
        {
            return NativeMethods.cgIsInterfaceType(type);
        }

        public static bool IsParentType(ParameterType parent, int child)
        {
            return NativeMethods.cgIsParentType(parent, child);
        }

        public static bool IsProfileSupported(ProfileType profile)
        {
            return NativeMethods.cgIsProfileSupported(profile);
        }

        public static void SetErrorHandler(CgErrorHandlerFuncDelegate func, IntPtr data)
        {
            NativeMethods.cgSetErrorHandler(func, data);
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
                        retValue[i] = ii[i] == NativeMethods.CgTrue;
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