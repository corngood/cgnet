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
    using System.ComponentModel;
    using System.Runtime.InteropServices;

    using CgNet.Wrapper;

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
        public delegate void CgErrorHandlerFuncDelegate(IntPtr context, CgError err, IntPtr data);

        /// <summary>
        ///    
        /// </summary>
        // typedef CGbool (*CGstatecallback)(CGstateassignment);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int CgStateCallbackDelegate(IntPtr cGstateassignment);

        #endregion Delegates

        #region Methods

        #region Public Static Methods

        public static void AddStateEnumerant(IntPtr state, string name, int value)
        {
            CgNativeMethods.cgAddStateEnumerant(state, name, value);
        }

        public static bool CallStateResetCallback(IntPtr stateassignment)
        {
            return CgNativeMethods.cgCallStateResetCallback(stateassignment);
        }

        public static bool CallStateSetCallback(IntPtr stateassignment)
        {
            return CgNativeMethods.cgCallStateSetCallback(stateassignment);
        }

        public static bool CallStateValidateCallback(IntPtr stateassignment)
        {
            return CgNativeMethods.cgCallStateValidateCallback(stateassignment);
        }

        public static IntPtr CombinePrograms(IntPtr exe1, IntPtr exe2)
        {
            return CgNativeMethods.cgCombinePrograms2(exe1, exe2);
        }

        public static IntPtr CombinePrograms(IntPtr exe1, IntPtr exe2, IntPtr exe3)
        {
            return CgNativeMethods.cgCombinePrograms3(exe1, exe2, exe3);
        }

        public static IntPtr CombinePrograms(IntPtr exe1, IntPtr exe2, IntPtr exe3, IntPtr exe4)
        {
            return CgNativeMethods.cgCombinePrograms4(exe1, exe2, exe3, exe4);
        }

        public static IntPtr CombinePrograms(IntPtr exe1, IntPtr exe2, IntPtr exe3, IntPtr exe4, IntPtr exe5)
        {
            return CgNativeMethods.cgCombinePrograms5(exe1, exe2, exe3, exe4, exe5);
        }

        public static IntPtr CombinePrograms(params IntPtr[] programs)
        {
            return CgNativeMethods.cgCombinePrograms(programs.Length, programs);
        }

        public static void CompileProgram(IntPtr program)
        {
            CgNativeMethods.cgCompileProgram(program);
        }

        public static void ConnectParameter(IntPtr from, IntPtr to)
        {
            CgNativeMethods.cgConnectParameter(from, to);
        }

        public static IntPtr CopyProgram(IntPtr program)
        {
            return CgNativeMethods.cgCopyProgram(program);
        }

        public static IntPtr CreateArraySamplerState(IntPtr context, string name, CgType type, int elementCount)
        {
            return CgNativeMethods.cgCreateArraySamplerState(context, name, type, elementCount);
        }

        public static IntPtr CreateArrayState(IntPtr context, string name, CgType type, int elementCount)
        {
            return CgNativeMethods.cgCreateArrayState(context, name, type, elementCount);
        }

        public static IntPtr CreateContext()
        {
            return CgNativeMethods.cgCreateContext();
        }

        public static IntPtr CreateEffect(IntPtr context, string code, params string[] args)
        {
            return CgNativeMethods.cgCreateEffect(context, code, args);
        }

        public static IntPtr CreateEffectFromFile(IntPtr context, string filename, params string[] args)
        {
            return CgNativeMethods.cgCreateEffectFromFile(context, filename, args);
        }

        public static IntPtr CreateParameter(IntPtr context, CgType type)
        {
            return CgNativeMethods.cgCreateParameter(context, type);
        }

        public static IntPtr CreateParameterArray(IntPtr context, CgType type, int length)
        {
            return CgNativeMethods.cgCreateParameterArray(context, type, length);
        }

        public static IntPtr CreateParameterMultiDimArray(IntPtr context, CgType type, int dim, int[] lengths)
        {
            return CgNativeMethods.cgCreateParameterMultiDimArray(context, type, dim, lengths);
        }

        public static IntPtr CreateProgram(IntPtr context, ProgramType type, string source, CgProfile profile, string entry, params string[] args)
        {
            return CgNativeMethods.cgCreateProgram(context, type, source, profile, entry, args);
        }

        public static IntPtr CreateProgramAnnotation(IntPtr prog, string name, CgType type)
        {
            return CgNativeMethods.cgCreateProgramAnnotation(prog, name, type);
        }

        public static IntPtr CreateProgramFromEffect(IntPtr effect, CgProfile profile, string entry, params string[] args)
        {
            return CgNativeMethods.cgCreateProgramFromEffect(effect, profile, entry, args);
        }

        public static IntPtr CreateProgramFromFile(IntPtr context, ProgramType type, string file, CgProfile profile, string entry, params string[] args)
        {
            return CgNativeMethods.cgCreateProgramFromFile(context, type, file, profile, entry, args);
        }

        public static IntPtr CreateSamplerState(IntPtr context, string name, CgType type)
        {
            return CgNativeMethods.cgCreateSamplerState(context, name, type);
        }

        public static IntPtr CreateState(IntPtr context, string name, CgType type)
        {
            return CgNativeMethods.cgCreateState(context, name, type);
        }

        public static void DestroyContext(IntPtr context)
        {
            CgNativeMethods.cgDestroyContext(context);
        }

        public static void DestroyEffect(IntPtr effect)
        {
            CgNativeMethods.cgDestroyEffect(effect);
        }

        public static void DestroyParameter(IntPtr param)
        {
            CgNativeMethods.cgDestroyParameter(param);
        }

        public static void DestroyProgram(IntPtr program)
        {
            CgNativeMethods.cgDestroyProgram(program);
        }

        public static void DisconnectParameter(IntPtr param)
        {
            CgNativeMethods.cgDisconnectParameter(param);
        }

        public static float[] EvaluateProgram(IntPtr prog, int ncomps, int nx, int ny, int nz)
        {
            var retValue = new float[ncomps * nx * ny * nz];
            CgNativeMethods.cgEvaluateProgram(prog, retValue, ncomps, nx, ny, nz);
            return retValue;
        }

        public static string GetAnnotationName(IntPtr annotation)
        {
            return Marshal.PtrToStringAnsi(CgNativeMethods.cgGetAnnotationName(annotation));
        }

        public static CgType GetAnnotationType(IntPtr annotation)
        {
            return CgNativeMethods.cgGetAnnotationType(annotation);
        }

        public static int GetArrayDimension(IntPtr param)
        {
            return CgNativeMethods.cgGetArrayDimension(param);
        }

        public static IntPtr GetArrayParameter(IntPtr aparam, int index)
        {
            return CgNativeMethods.cgGetArrayParameter(aparam, index);
        }

        public static int GetArraySize(IntPtr param, int dimension)
        {
            return CgNativeMethods.cgGetArraySize(param, dimension);
        }

        public static int GetArrayTotalSize(IntPtr param)
        {
            return CgNativeMethods.cgGetArrayTotalSize(param);
        }

        public static CgType GetArrayType(IntPtr param)
        {
            return CgNativeMethods.cgGetArrayType(param);
        }

        public static AutoCompileMode GetAutoCompile(IntPtr context)
        {
            return CgNativeMethods.cgGetAutoCompile(context);
        }

        public static bool[] GetBoolAnnotationValues(IntPtr annotation)
        {
            int count;
            var values = CgNativeMethods.cgGetBoolAnnotationValues(annotation, out count);
            return IntPtrToBoolArray(values, count);
        }

        public static bool[] GetBoolStateAssignmentValues(IntPtr stateassignment)
        {
            int count;
            var values = CgNativeMethods.cgGetBoolStateAssignmentValues(stateassignment, out count);
            return IntPtrToBoolArray(values, count);
        }

        public static IntPtr GetConnectedParameter(IntPtr param)
        {
            return CgNativeMethods.cgGetConnectedParameter(param);
        }

        public static IntPtr GetConnectedToParameter(IntPtr param, int index)
        {
            return CgNativeMethods.cgGetConnectedToParameter(param, index);
        }

        public static Behavior GetContextBehavior(IntPtr context)
        {
            return CgNativeMethods.cgGetContextBehavior(context);
        }

        public static IntPtr GetDependentAnnotationParameter(IntPtr annotation, int index)
        {
            return CgNativeMethods.cgGetDependentAnnotationParameter(annotation, index);
        }

        public static IntPtr GetDependentStateAssignmentParameter(IntPtr stateassignment, int index)
        {
            return CgNativeMethods.cgGetDependentStateAssignmentParameter(stateassignment, index);
        }

        public static IntPtr GetEffectContext(IntPtr effect)
        {
            return CgNativeMethods.cgGetEffectContext(effect);
        }

        public static IntPtr GetEffectParameterBySemantic(IntPtr effect, string name)
        {
            return CgNativeMethods.cgGetEffectParameterBySemantic(effect, name);
        }

        public static int GetEnum(string enumString)
        {
            return CgNativeMethods.cgGetEnum(enumString);
        }

        public static string GetEnumString(int en)
        {
            return CgNativeMethods.cgGetEnumString(en);
        }

        public static CgError GetError()
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

        public static IntPtr GetErrorString(CgError error)
        {
            return CgNativeMethods.cgGetErrorString(error);
        }

        public static IntPtr GetFirstDependentParameter(IntPtr param)
        {
            return CgNativeMethods.cgGetFirstDependentParameter(param);
        }

        public static IntPtr GetFirstEffect(IntPtr context)
        {
            return CgNativeMethods.cgGetFirstEffect(context);
        }

        public static IntPtr GetFirstEffectParameter(IntPtr effect)
        {
            return CgNativeMethods.cgGetFirstEffectParameter(effect);
        }

        public static CgError GetFirstError()
        {
            return CgNativeMethods.cgGetFirstError();
        }

        public static IntPtr GetFirstLeafEffectParameter(IntPtr effect)
        {
            return CgNativeMethods.cgGetFirstLeafEffectParameter(effect);
        }

        public static IntPtr GetFirstLeafParameter(IntPtr program, int nameSpace)
        {
            return CgNativeMethods.cgGetFirstLeafParameter(program, nameSpace);
        }

        public static IntPtr GetFirstParameter(IntPtr prog, int nameSpace)
        {
            return CgNativeMethods.cgGetFirstParameter(prog, nameSpace);
        }

        public static IntPtr GetFirstParameterAnnotation(IntPtr param)
        {
            return CgNativeMethods.cgGetFirstParameterAnnotation(param);
        }

        public static IntPtr GetFirstPass(IntPtr technique)
        {
            return CgNativeMethods.cgGetFirstPass(technique);
        }

        public static IntPtr GetFirstPassAnnotation(IntPtr pass)
        {
            return CgNativeMethods.cgGetFirstPassAnnotation(pass);
        }

        public static IntPtr GetFirstProgram(IntPtr context)
        {
            return CgNativeMethods.cgGetFirstProgram(context);
        }

        public static IntPtr GetFirstProgramAnnotation(IntPtr prog)
        {
            return CgNativeMethods.cgGetFirstProgramAnnotation(prog);
        }

        public static IntPtr GetFirstSamplerState(IntPtr context)
        {
            return CgNativeMethods.cgGetFirstSamplerState(context);
        }

        public static IntPtr GetFirstSamplerStateAssignment(IntPtr param)
        {
            return CgNativeMethods.cgGetFirstSamplerStateAssignment(param);
        }

        public static IntPtr GetFirstState(IntPtr context)
        {
            return CgNativeMethods.cgGetFirstState(context);
        }

        public static IntPtr GetFirstStateAssignment(IntPtr pass)
        {
            return CgNativeMethods.cgGetFirstStateAssignment(pass);
        }

        public static IntPtr GetFirstStructParameter(IntPtr param)
        {
            return CgNativeMethods.cgGetFirstStructParameter(param);
        }

        public static IntPtr GetFirstTechnique(IntPtr effect)
        {
            return CgNativeMethods.cgGetFirstTechnique(effect);
        }

        public static IntPtr GetFirstTechniqueAnnotation(IntPtr technique)
        {
            return CgNativeMethods.cgGetFirstTechniqueAnnotation(technique);
        }

        public static float[] GetFloatAnnotationValues(IntPtr annotation, out int nvalues)
        {
            return CgNativeMethods.cgGetFloatAnnotationValues(annotation, out nvalues);
        }

        public static float[] GetFloatStateAssignmentValues(IntPtr stateassignment, int[] nVals)
        {
            return CgNativeMethods.cgGetFloatStateAssignmentValues(stateassignment, nVals);
        }

        public static string GetGetParameterSemantic(IntPtr param)
        {
            return Marshal.PtrToStringAnsi(CgNativeMethods.cgGetParameterSemantic(param));
        }

        public static int[] GetIntAnnotationValues(IntPtr annotation, out int nvalues)
        {
            return CgNativeMethods.cgGetIntAnnotationValues(annotation, out nvalues);
        }

        public static int[] GetIntStateAssignmentValues(IntPtr stateassignment, int[] nVals)
        {
            return CgNativeMethods.cgGetIntStateAssignmentValues(stateassignment, nVals);
        }

        public static string GetLastErrorString(out CgError error)
        {
            return Marshal.PtrToStringAnsi(CgNativeMethods.cgGetLastErrorString(out error));
        }

        public static IntPtr GetLastListing(IntPtr context)
        {
            return CgNativeMethods.cgGetLastListing(context);
        }

        public static LockingPolicy GetLockingPolicy()
        {
            return CgNativeMethods.cgGetLockingPolicy();
        }

        public static T[] GetMatrixParameter<T>(IntPtr param)
            where T : struct
        {
            return GetMatrixParameter<T>(param, Order.RowMajor);
        }

        public static T[] GetMatrixParameter<T>(IntPtr param, Order order)
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

        public static IntPtr GetNamedEffectParameter(IntPtr effect, string name)
        {
            return CgNativeMethods.cgGetNamedEffectParameter(effect, name);
        }

        public static IntPtr GetNamedParameter(IntPtr program, string parameter)
        {
            return CgNativeMethods.cgGetNamedParameter(program, parameter);
        }

        public static IntPtr GetNamedParameterAnnotation(IntPtr param, string name)
        {
            return CgNativeMethods.cgGetNamedParameterAnnotation(param, name);
        }

        public static IntPtr GetNamedPass(IntPtr technique, string name)
        {
            return CgNativeMethods.cgGetNamedPass(technique, name);
        }

        public static IntPtr GetNamedPassAnnotation(IntPtr pass, string name)
        {
            return CgNativeMethods.cgGetNamedPassAnnotation(pass, name);
        }

        public static IntPtr GetNamedProgramAnnotation(IntPtr prog, string name)
        {
            return CgNativeMethods.cgGetNamedProgramAnnotation(prog, name);
        }

        public static IntPtr GetNamedProgramParameter(IntPtr prog, ProgramNamespace nameSpace, string name)
        {
            return CgNativeMethods.cgGetNamedProgramParameter(prog, nameSpace, name);
        }

        public static IntPtr GetNamedSamplerState(IntPtr context, string name)
        {
            return CgNativeMethods.cgGetNamedSamplerState(context, name);
        }

        public static IntPtr GetNamedSamplerStateAssignment(IntPtr param, string name)
        {
            return CgNativeMethods.cgGetNamedSamplerStateAssignment(param, name);
        }

        public static IntPtr GetNamedState(IntPtr context, string name)
        {
            return CgNativeMethods.cgGetNamedState(context, name);
        }

        public static IntPtr GetNamedStateAssignment(IntPtr pass, string name)
        {
            return CgNativeMethods.cgGetNamedStateAssignment(pass, name);
        }

        public static IntPtr GetNamedStructParameter(IntPtr param, string name)
        {
            return CgNativeMethods.cgGetNamedStructParameter(param, name);
        }

        public static IntPtr GetNamedTechnique(IntPtr effect, string name)
        {
            return CgNativeMethods.cgGetNamedTechnique(effect, name);
        }

        public static IntPtr GetNamedTechniqueAnnotation(IntPtr technique, string name)
        {
            return CgNativeMethods.cgGetNamedTechniqueAnnotation(technique, name);
        }

        public static CgType GetNamedUserType(IntPtr handle, string name)
        {
            return CgNativeMethods.cgGetNamedUserType(handle, name);
        }

        public static IntPtr GetNextAnnotation(IntPtr annotation)
        {
            return CgNativeMethods.cgGetNextAnnotation(annotation);
        }

        public static IntPtr GetNextEffect(IntPtr effect)
        {
            return CgNativeMethods.cgGetNextEffect(effect);
        }

        public static IntPtr GetNextLeafParameter(IntPtr currentParam)
        {
            return CgNativeMethods.cgGetNextLeafParameter(currentParam);
        }

        public static IntPtr GetNextParameter(IntPtr currentParam)
        {
            return CgNativeMethods.cgGetNextParameter(currentParam);
        }

        public static IntPtr GetNextPass(IntPtr pass)
        {
            return CgNativeMethods.cgGetNextPass(pass);
        }

        public static IntPtr GetNextProgram(IntPtr current)
        {
            return CgNativeMethods.cgGetNextProgram(current);
        }

        public static IntPtr GetNextState(IntPtr state)
        {
            return CgNativeMethods.cgGetNextState(state);
        }

        public static IntPtr GetNextStateAssignment(IntPtr stateassignment)
        {
            return CgNativeMethods.cgGetNextStateAssignment(stateassignment);
        }

        public static IntPtr GetNextTechnique(IntPtr technique)
        {
            return CgNativeMethods.cgGetNextTechnique(technique);
        }

        public static int GetNumConnectedToParameters(IntPtr param)
        {
            return CgNativeMethods.cgGetNumConnectedToParameters(param);
        }

        public static int GetNumDependentAnnotationParameters(IntPtr annotation)
        {
            return CgNativeMethods.cgGetNumDependentAnnotationParameters(annotation);
        }

        public static int GetNumDependentStateAssignmentParameters(IntPtr stateassignment)
        {
            return CgNativeMethods.cgGetNumDependentStateAssignmentParameters(stateassignment);
        }

        public static int GetNumParentTypes(CgType type)
        {
            return CgNativeMethods.cgGetNumParentTypes(type);
        }

        public static int GetNumUserTypes(IntPtr handle)
        {
            return CgNativeMethods.cgGetNumUserTypes(handle);
        }

        public static int GetParameterBaseResource(IntPtr param)
        {
            return CgNativeMethods.cgGetParameterBaseResource(param);
        }

        public static CgType GetParameterBaseType(IntPtr param)
        {
            return CgNativeMethods.cgGetParameterBaseType(param);
        }

        public static int GetParameterClass(IntPtr param)
        {
            return CgNativeMethods.cgGetParameterClass(param);
        }

        public static int GetParameterColumns(IntPtr param)
        {
            return CgNativeMethods.cgGetParameterColumns(param);
        }

        public static IntPtr GetParameterContext(IntPtr param)
        {
            return CgNativeMethods.cgGetParameterContext(param);
        }

        public static int GetParameterDirection(IntPtr param)
        {
            return CgNativeMethods.cgGetParameterDirection(param);
        }

        public static int GetParameterIndex(IntPtr param)
        {
            return CgNativeMethods.cgGetParameterIndex(param);
        }

        public static string GetParameterName(IntPtr param)
        {
            return Marshal.PtrToStringAnsi(CgNativeMethods.cgGetParameterName(param));
        }

        public static CgType GetParameterNamedType(IntPtr param)
        {
            return CgNativeMethods.cgGetParameterNamedType(param);
        }

        public static int GetParameterOrdinalNumber(IntPtr param)
        {
            return CgNativeMethods.cgGetParameterOrdinalNumber(param);
        }

        public static IntPtr GetParameterProgram(IntPtr param)
        {
            return CgNativeMethods.cgGetParameterProgram(param);
        }

        public static int GetParameterResource(IntPtr param)
        {
            return CgNativeMethods.cgGetParameterResource(param);
        }

        public static int GetParameterResourceIndex(IntPtr param)
        {
            return CgNativeMethods.cgGetParameterResourceIndex(param);
        }

        public static int GetParameterRows(IntPtr param)
        {
            return CgNativeMethods.cgGetParameterRows(param);
        }

        public static CgType GetParameterType(IntPtr param)
        {
            return CgNativeMethods.cgGetParameterType(param);
        }

        public static void GetParameterValue(IntPtr param, ref int[] values)
        {
            GetParameterValue(param, ref values, Order.RowMajor);
        }

        public static void GetParameterValue(IntPtr param, ref double[] values)
        {
            GetParameterValue(param, ref values, Order.RowMajor);
        }

        public static T GetParameterValue<T>(IntPtr param)
            where T : struct
        {
            var f = new T[1];
            GetParameterValue(param, ref f);
            return f[0];
        }

        public static void GetParameterValue<T>(IntPtr param, ref T[] values)
            where T : struct
        {
            GetParameterValue(param, ref values, Order.RowMajor);
        }

        public static void GetParameterValue<T>(IntPtr param, ref T[] values, Order order)
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

        public static int GetParameterVariability(IntPtr param)
        {
            return CgNativeMethods.cgGetParameterVariability(param);
        }

        public static CgType GetParentType(CgType type, int index)
        {
            return CgNativeMethods.cgGetParentType(type, index);
        }

        public static string GetPassName(IntPtr pass)
        {
            return CgNativeMethods.cgGetPassName(pass);
        }

        public static IntPtr GetPassTechnique(IntPtr pass)
        {
            return CgNativeMethods.cgGetPassTechnique(pass);
        }

        public static CgProfile GetProfile(string profile)
        {
            return CgNativeMethods.cgGetProfile(profile);
        }

        public static IntPtr GetProfileString(CgProfile profile)
        {
            return CgNativeMethods.cgGetProfileString(profile);
        }

        public static IntPtr GetProgramContext(IntPtr prog)
        {
            return CgNativeMethods.cgGetProgramContext(prog);
        }

        public static string[] GetProgramOptions(IntPtr prog)
        {
            return CgNativeMethods.cgGetProgramOptions(prog);
        }

        public static int GetProgramProfile(IntPtr prog)
        {
            return CgNativeMethods.cgGetProgramProfile(prog);
        }

        public static IntPtr GetProgramStateAssignmentValue(IntPtr stateassignment)
        {
            return CgNativeMethods.cgGetProgramStateAssignmentValue(stateassignment);
        }

        public static string GetProgramString(IntPtr program, SourceType sourceType)
        {
            return Marshal.PtrToStringAnsi(CgNativeMethods.cgGetProgramString(program, sourceType));
        }

        public static CgResource GetResource(string resourceName)
        {
            return CgNativeMethods.cgGetResource(resourceName);
        }

        public static string GetResourceString(CgResource resource)
        {
            return Marshal.PtrToStringAnsi(CgNativeMethods.cgGetResourceString(resource));
        }

        public static IntPtr GetSamplerStateAssignmentParameter(IntPtr stateassignment)
        {
            return CgNativeMethods.cgGetSamplerStateAssignmentParameter(stateassignment);
        }

        public static IntPtr GetSamplerStateAssignmentState(IntPtr stateassignment)
        {
            return CgNativeMethods.cgGetSamplerStateAssignmentState(stateassignment);
        }

        public static IntPtr GetSamplerStateAssignmentValue(IntPtr stateassignment)
        {
            return CgNativeMethods.cgGetSamplerStateAssignmentValue(stateassignment);
        }

        public static CasePolicy GetSemanticCasePolicy()
        {
            return CgNativeMethods.cgGetSemanticCasePolicy();
        }

        public static int GetStateAssignmentIndex(IntPtr stateassignment)
        {
            return CgNativeMethods.cgGetStateAssignmentIndex(stateassignment);
        }

        public static IntPtr GetStateAssignmentPass(IntPtr stateassignment)
        {
            return CgNativeMethods.cgGetStateAssignmentPass(stateassignment);
        }

        public static IntPtr GetStateAssignmentState(IntPtr stateassignment)
        {
            return CgNativeMethods.cgGetStateAssignmentState(stateassignment);
        }

        public static int GetStateEnumerantValue(IntPtr state, string name)
        {
            return CgNativeMethods.cgGetStateEnumerantValue(state, name);
        }

        public static string GetStateName(IntPtr state)
        {
            return CgNativeMethods.cgGetStateName(state);
        }

        public static CgStateCallbackDelegate GetStateResetCallback(IntPtr state)
        {
            return CgNativeMethods.cgGetStateResetCallback(state);
        }

        public static CgStateCallbackDelegate GetStateSetCallback(IntPtr state)
        {
            return CgNativeMethods.cgGetStateSetCallback(state);
        }

        public static CgType GetStateType(IntPtr state)
        {
            return CgNativeMethods.cgGetStateType(state);
        }

        public static CgStateCallbackDelegate GetStateValidateCallback(IntPtr state)
        {
            return CgNativeMethods.cgGetStateValidateCallback(state);
        }

        public static string GetString(CgEnum sname)
        {
            return Marshal.PtrToStringAnsi(CgNativeMethods.cgGetString(sname));
        }

        public static string GetStringAnnotationValue(IntPtr annotation)
        {
            return CgNativeMethods.cgGetStringAnnotationValue(annotation);
        }

        public static string GetStringParameterValue(IntPtr param)
        {
            return CgNativeMethods.cgGetStringParameterValue(param);
        }

        public static string GetStringStateAssignmentValue(IntPtr stateassignment)
        {
            return CgNativeMethods.cgGetStringStateAssignmentValue(stateassignment);
        }

        public static IntPtr GetTechniqueEffect(IntPtr technique)
        {
            return CgNativeMethods.cgGetTechniqueEffect(technique);
        }

        public static string GetTechniqueName(IntPtr technique)
        {
            return CgNativeMethods.cgGetTechniqueName(technique);
        }

        public static IntPtr GetTextureStateAssignmentValue(IntPtr stateassignment)
        {
            return CgNativeMethods.cgGetTextureStateAssignmentValue(stateassignment);
        }

        public static CgType GetType(string typeString)
        {
            return CgNativeMethods.cgGetType(typeString);
        }

        public static string GetTypeString(CgType type)
        {
            return Marshal.PtrToStringAnsi(CgNativeMethods.cgGetTypeString(type));
        }

        public static CgType GetUserType(IntPtr handle, int index)
        {
            return CgNativeMethods.cgGetUserType(handle, index);
        }

        public static bool IsAnnotation(IntPtr annotation)
        {
            return CgNativeMethods.cgIsAnnotation(annotation);
        }

        public static bool IsContext(IntPtr context)
        {
            return CgNativeMethods.cgIsContext(context);
        }

        public static bool IsEffect(IntPtr effect)
        {
            return CgNativeMethods.cgIsEffect(effect);
        }

        public static bool IsInterfaceType(CgType type)
        {
            return CgNativeMethods.cgIsInterfaceType(type);
        }

        public static bool IsParameter(IntPtr param)
        {
            return CgNativeMethods.cgIsParameter(param);
        }

        public static bool IsParameterGlobal(IntPtr param)
        {
            return CgNativeMethods.cgIsParameterGlobal(param);
        }

        public static bool IsParameterReferenced(IntPtr param)
        {
            return CgNativeMethods.cgIsParameterReferenced(param);
        }

        public static bool IsParameterUsed(IntPtr param, IntPtr handle)
        {
            return CgNativeMethods.cgIsParameterUsed(param, handle);
        }

        public static bool IsParentType(CgType parent, int child)
        {
            return CgNativeMethods.cgIsParentType(parent, child);
        }

        public static bool IsPass(IntPtr pass)
        {
            return CgNativeMethods.cgIsPass(pass);
        }

        public static bool IsProgram(IntPtr prog)
        {
            return CgNativeMethods.cgIsProgram(prog);
        }

        public static bool IsProgramCompiled(IntPtr prog)
        {
            return CgNativeMethods.cgIsProgramCompiled(prog);
        }

        public static bool IsState(IntPtr state)
        {
            return CgNativeMethods.cgIsState(state);
        }

        public static bool IsStateAssignment(IntPtr stateassignment)
        {
            return CgNativeMethods.cgIsStateAssignment(stateassignment);
        }

        public static bool IsTechnique(IntPtr technique)
        {
            return CgNativeMethods.cgIsTechnique(technique);
        }

        public static bool IsTechniqueValidated(IntPtr technique)
        {
            return CgNativeMethods.cgIsTechniqueValidated(technique);
        }

        public static void ResetPassState(IntPtr pass)
        {
            CgNativeMethods.cgResetPassState(pass);
        }

        public static void SetArraySize(IntPtr param, int size)
        {
            CgNativeMethods.cgSetArraySize(param, size);
        }

        public static void SetAutoCompile(IntPtr context, AutoCompileMode flag)
        {
            CgNativeMethods.cgSetAutoCompile(context, flag);
        }

        public static bool SetBoolAnnotation(IntPtr annotation, bool value)
        {
            return CgNativeMethods.cgSetBoolAnnotation(annotation, value);
        }

        public static void SetContextBehavior(IntPtr context, Behavior behavior)
        {
            CgNativeMethods.cgSetContextBehavior(context, behavior);
        }

        public static void SetErrorCallback(CgErrorCallbackFuncDelegate func)
        {
            CgNativeMethods.cgSetErrorCallback(func);
        }

        public static void SetErrorHandler(CgErrorHandlerFuncDelegate func, IntPtr data)
        {
            CgNativeMethods.cgSetErrorHandler(func, data);
        }

        public static void SetLastListing(IntPtr handle, string listing)
        {
            CgNativeMethods.cgSetLastListing(handle, listing);
        }

        public static LockingPolicy SetLockingPolicy(LockingPolicy lockingPolicy)
        {
            return CgNativeMethods.cgSetLockingPolicy(lockingPolicy);
        }

        public static void SetMatrixParameter(IntPtr param, float[] matrix)
        {
            SetMatrixParameter(param, matrix, Order.RowMajor);
        }

        public static void SetMatrixParameter(IntPtr param, float[] matrix, Order order)
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

        public static void SetMatrixParameter(IntPtr param, double[] matrix)
        {
            SetMatrixParameter(param, matrix, Order.RowMajor);
        }

        public static void SetMatrixParameter(IntPtr param, double[] matrix, Order order)
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

        public static void SetMatrixParameter(IntPtr param, int[] matrix)
        {
            SetMatrixParameter(param, matrix, Order.RowMajor);
        }

        public static void SetMatrixParameter(IntPtr param, int[] matrix, Order order)
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

        public static void SetMultiDimArraySize(IntPtr param, int[] sizes)
        {
            CgNativeMethods.cgSetMultiDimArraySize(param, sizes);
        }

        public static void SetParameter(IntPtr param, float x)
        {
            CgNativeMethods.cgSetParameter1f(param, x);
        }

        public static void SetParameter(IntPtr param, float x, float y, float z)
        {
            CgNativeMethods.cgSetParameter3f(param, x, y, z);
        }

        public static void SetParameter(IntPtr param, int[] v)
        {
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

        public static void SetParameter(IntPtr param, double[] v)
        {
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

        public static void SetParameter(IntPtr param, float[] v)
        {
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

        public static void SetParameter(IntPtr param, float x, float y)
        {
            CgNativeMethods.cgSetParameter2f(param, x, y);
        }

        public static void SetParameter(IntPtr param, float x, float y, float z, float w)
        {
            CgNativeMethods.cgSetParameter4f(param, x, y, z, w);
        }

        public static void SetParameter(IntPtr param, double x)
        {
            CgNativeMethods.cgSetParameter1d(param, x);
        }

        public static void SetParameter(IntPtr param, int x)
        {
            CgNativeMethods.cgSetParameter1i(param, x);
        }

        public static void SetParameter(IntPtr param, double x, double y)
        {
            CgNativeMethods.cgSetParameter2d(param, x, y);
        }

        public static void SetParameter(IntPtr param, int x, int y)
        {
            CgNativeMethods.cgSetParameter2i(param, x, y);
        }

        public static void SetParameter(IntPtr param, double x, double y, double z)
        {
            CgNativeMethods.cgSetParameter3d(param, x, y, z);
        }

        public static void SetParameter(IntPtr param, int x, int y, int z)
        {
            CgNativeMethods.cgSetParameter3i(param, x, y, z);
        }

        public static void SetParameter(IntPtr param, double x, double y, double z, double w)
        {
            CgNativeMethods.cgSetParameter4d(param, x, y, z, w);
        }

        public static void SetParameter(IntPtr param, int x, int y, int z, int w)
        {
            CgNativeMethods.cgSetParameter4i(param, x, y, z, w);
        }

        public static void SetParameterSemantic(IntPtr param, string semantic)
        {
            CgNativeMethods.cgSetParameterSemantic(param, semantic);
        }

        public static void SetParameterSettingMode(IntPtr context, ParameterSettingMode parameterSettingMode)
        {
            CgNativeMethods.cgSetParameterSettingMode(context, parameterSettingMode);
        }

        public static void SetParameterValue(IntPtr param, double[] vals)
        {
            SetParameterValue(param, vals, Order.RowMajor);
        }

        public static void SetParameterValue(IntPtr param, double[] vals, Order order)
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

        public static void SetParameterValue(IntPtr param, float[] vals)
        {
            SetParameterValue(param, vals, Order.RowMajor);
        }

        public static void SetParameterValue(IntPtr param, float[] vals, Order order)
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

        public static void SetParameterValue(IntPtr param, int[] vals)
        {
            SetParameterValue(param, vals, Order.RowMajor);
        }

        public static void SetParameterValue(IntPtr param, int[] vals, Order order)
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

        public static void SetParameterVariability(IntPtr param, int vary)
        {
            CgNativeMethods.cgSetParameterVariability(param, vary);
        }

        public static void SetPassProgramParameters(IntPtr prog)
        {
            CgNativeMethods.cgSetPassProgramParameters(prog);
        }

        public static void SetPassState(IntPtr pass)
        {
            CgNativeMethods.cgSetPassState(pass);
        }

        public static void SetProgramProfile(IntPtr prog, CgProfile profile)
        {
            CgNativeMethods.cgSetProgramProfile(prog, profile);
        }

        public static void SetSamplerState(IntPtr param)
        {
            CgNativeMethods.cgSetSamplerState(param);
        }

        public static CasePolicy SetSemanticCasePolicy(CasePolicy casePolicy)
        {
            return CgNativeMethods.cgSetSemanticCasePolicy(casePolicy);
        }

        public static void SetStateCallbacks(IntPtr state, CgStateCallbackDelegate set, CgStateCallbackDelegate reset, CgStateCallbackDelegate validate)
        {
            CgNativeMethods.cgSetStateCallbacks(state, set, reset, validate);
        }

        public static void SetStringParameterValue(IntPtr param, string str)
        {
            CgNativeMethods.cgSetStringParameterValue(param, str);
        }

        public static void UpdateProgramParameters(IntPtr program)
        {
            CgNativeMethods.cgUpdateProgramParameters(program);
        }

        public static bool ValidateTechnique(IntPtr technique)
        {
            return CgNativeMethods.cgValidateTechnique(technique);
        }

        #endregion Public Static Methods

        #region Private Static Methods

        private static bool[] IntPtrToBoolArray(IntPtr values, int count)
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

        #endregion Private Static Methods

        #endregion Methods
    }
}