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

        public static IntPtr CopyEffect(IntPtr effect)
        {
            return CgNativeMethods.cgCopyEffect(effect);
        }

        public static IntPtr CopyProgram(IntPtr program)
        {
            return CgNativeMethods.cgCopyProgram(program);
        }

        public static IntPtr CreateArraySamplerState(IntPtr context, string name, ParameterType type, int elementCount)
        {
            return CgNativeMethods.cgCreateArraySamplerState(context, name, type, elementCount);
        }

        public static IntPtr CreateArrayState(IntPtr context, string name, ParameterType type, int elementCount)
        {
            return CgNativeMethods.cgCreateArrayState(context, name, type, elementCount);
        }

        public static IntPtr CreateBuffer(IntPtr context, int size, IntPtr data, BufferUsage bufferUsage)
        {
            return CgNativeMethods.cgCreateBuffer(context, size, data, bufferUsage);
        }

        public static IntPtr CreateContext()
        {
            return CgNativeMethods.cgCreateContext();
        }

        public static IntPtr CreateEffect(IntPtr context, string code, params string[] args)
        {
            return CgNativeMethods.cgCreateEffect(context, code, args);
        }

        public static IntPtr CreateEffectAnnotation(IntPtr effect, string name, ParameterType type)
        {
            return CgNativeMethods.cgCreateEffectAnnotation(effect, name, type);
        }

        public static IntPtr CreateEffectFromFile(IntPtr context, string filename, params string[] args)
        {
            return CgNativeMethods.cgCreateEffectFromFile(context, filename, args);
        }

        public static IntPtr CreateEffectParameter(IntPtr context, string name, ParameterType type)
        {
            return CgNativeMethods.cgCreateEffectParameter(context, name, type);
        }

        public static IntPtr CreateEffectParameterArray(IntPtr effect, string name, ParameterType type, int length)
        {
            return CgNativeMethods.cgCreateEffectParameterArray(effect, name, type, length);
        }

        public static IntPtr CreateEffectParameterMultiDimArray(IntPtr effect, string name, ParameterType type, int dim, int[] lengths)
        {
            return CgNativeMethods.cgCreateEffectParameterMultiDimArray(effect, name, type, dim, lengths);
        }

        public static IntPtr CreateObj(IntPtr context, ProgramType programType, string source, ProfileType profile, params string[] args)
        {
            return CgNativeMethods.cgCreateObj(context, programType, source, profile, args);
        }

        public static IntPtr CreateObjFromFile(IntPtr context, ProgramType programType, string sourceFile, ProfileType profile, params string[] args)
        {
            return CgNativeMethods.cgCreateObjFromFile(context, programType, sourceFile, profile, args);
        }

        public static IntPtr CreateParameter(IntPtr context, ParameterType type)
        {
            return CgNativeMethods.cgCreateParameter(context, type);
        }

        public static IntPtr CreateParameterAnnotation(IntPtr param, string name, ParameterType type)
        {
            return CgNativeMethods.cgCreateParameterAnnotation(param, name, type);
        }

        public static IntPtr CreateParameterArray(IntPtr context, ParameterType type, int length)
        {
            return CgNativeMethods.cgCreateParameterArray(context, type, length);
        }

        public static IntPtr CreateParameterMultiDimArray(IntPtr context, ParameterType type, int dim, int[] lengths)
        {
            return CgNativeMethods.cgCreateParameterMultiDimArray(context, type, dim, lengths);
        }

        public static IntPtr CreatePass(IntPtr tech, string name)
        {
            return CgNativeMethods.cgCreatePass(tech, name);
        }

        public static IntPtr CreatePassAnnotation(IntPtr pass, string name, ParameterType type)
        {
            return CgNativeMethods.cgCreatePassAnnotation(pass, name, type);
        }

        public static IntPtr CreateProgram(IntPtr context, ProgramType type, string source, ProfileType profile, string entry, params string[] args)
        {
            return CgNativeMethods.cgCreateProgram(context, type, source, profile, entry, args);
        }

        public static IntPtr CreateProgramAnnotation(IntPtr prog, string name, ParameterType type)
        {
            return CgNativeMethods.cgCreateProgramAnnotation(prog, name, type);
        }

        public static IntPtr CreateProgramFromEffect(IntPtr effect, ProfileType profile, string entry, params string[] args)
        {
            return CgNativeMethods.cgCreateProgramFromEffect(effect, profile, entry, args);
        }

        public static IntPtr CreateProgramFromFile(IntPtr context, ProgramType type, string file, ProfileType profile, string entry, params string[] args)
        {
            return CgNativeMethods.cgCreateProgramFromFile(context, type, file, profile, entry, args);
        }

        public static IntPtr CreateSamplerState(IntPtr context, string name, ParameterType type)
        {
            return CgNativeMethods.cgCreateSamplerState(context, name, type);
        }

        public static IntPtr CreateSamplerStateAssignment(IntPtr pass, IntPtr state)
        {
            return CgNativeMethods.cgCreateSamplerStateAssignment(pass, state);
        }

        public static IntPtr CreateState(IntPtr context, string name, ParameterType type)
        {
            return CgNativeMethods.cgCreateState(context, name, type);
        }

        public static IntPtr CreateStateAssignment(IntPtr pass, IntPtr state)
        {
            return CgNativeMethods.cgCreateStateAssignment(pass, state);
        }

        public static IntPtr CreateStateAssignmentIndex(IntPtr pass, IntPtr state, int index)
        {
            return CgNativeMethods.cgCreateStateAssignmentIndex(pass, state, index);
        }

        public static IntPtr CreateTechnique(IntPtr effect, string name)
        {
            return CgNativeMethods.cgCreateTechnique(effect, name);
        }

        public static IntPtr CreateTechniqueAnnotation(IntPtr tech, string name, ParameterType type)
        {
            return CgNativeMethods.cgCreateTechniqueAnnotation(tech, name, type);
        }

        public static void DestroyBuffer(IntPtr buffer)
        {
            CgNativeMethods.cgDestroyBuffer(buffer);
        }

        public static void DestroyContext(IntPtr context)
        {
            CgNativeMethods.cgDestroyContext(context);
        }

        public static void DestroyEffect(IntPtr effect)
        {
            CgNativeMethods.cgDestroyEffect(effect);
        }

        public static void DestroyObj(IntPtr obj)
        {
            CgNativeMethods.cgDestroyObj(obj);
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

        public static ParameterType GetAnnotationType(IntPtr annotation)
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

        public static ParameterType GetArrayType(IntPtr param)
        {
            return CgNativeMethods.cgGetArrayType(param);
        }

        public static AutoCompileMode GetAutoCompile(IntPtr context)
        {
            return CgNativeMethods.cgGetAutoCompile(context);
        }

        public static Behavior GetBehavior(string behaviorString)
        {
            return CgNativeMethods.cgGetBehavior(behaviorString);
        }

        public static string GetBehaviorString(Behavior behavior)
        {
            return Marshal.PtrToStringAnsi(CgNativeMethods.cgGetBehaviorString(behavior));
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

        public static int GetBufferSize(IntPtr buffer)
        {
            return CgNativeMethods.cgGetBufferSize(buffer);
        }

        public static CgIncludeCallbackFunc GetCompilerIncludeCallback(IntPtr context)
        {
            return CgNativeMethods.cgGetCompilerIncludeCallback(context);
        }

        public static IntPtr GetConnectedParameter(IntPtr param)
        {
            return CgNativeMethods.cgGetConnectedParameter(param);
        }

        public static IntPtr GetConnectedStateAssignmentParameter(IntPtr sa)
        {
            return CgNativeMethods.cgGetConnectedStateAssignmentParameter(sa);
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

        public static IntPtr GetDependentProgramArrayStateAssignmentParameter(IntPtr sa, int index)
        {
            return CgNativeMethods.cgGetDependentProgramArrayStateAssignmentParameter(sa, index);
        }

        public static IntPtr GetDependentStateAssignmentParameter(IntPtr stateassignment, int index)
        {
            return CgNativeMethods.cgGetDependentStateAssignmentParameter(stateassignment, index);
        }

        public static Domain GetDomain(string domainString)
        {
            return CgNativeMethods.cgGetDomain(domainString);
        }

        public static string GetDomainString(Domain domain)
        {
            return Marshal.PtrToStringAnsi(CgNativeMethods.cgGetDomainString(domain));
        }

        public static IntPtr GetEffectContext(IntPtr effect)
        {
            return CgNativeMethods.cgGetEffectContext(effect);
        }

        public static string GetEffectName(IntPtr effect)
        {
            return Marshal.PtrToStringAnsi(CgNativeMethods.cgGetEffectName(effect));
        }

        public static IntPtr GetEffectParameterBuffer(IntPtr param)
        {
            return CgNativeMethods.cgGetEffectParameterBuffer(param);
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

        public static IntPtr GetFirstDependentParameter(IntPtr param)
        {
            return CgNativeMethods.cgGetFirstDependentParameter(param);
        }

        public static IntPtr GetFirstEffect(IntPtr context)
        {
            return CgNativeMethods.cgGetFirstEffect(context);
        }

        public static IntPtr GetFirstEffectAnnotation(IntPtr effect)
        {
            return CgNativeMethods.cgGetFirstEffectAnnotation(effect);
        }

        public static IntPtr GetFirstEffectParameter(IntPtr effect)
        {
            return CgNativeMethods.cgGetFirstEffectParameter(effect);
        }

        public static ErrorType GetFirstError()
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

        public static int[] GetIntAnnotationValues(IntPtr annotation, out int nvalues)
        {
            return CgNativeMethods.cgGetIntAnnotationValues(annotation, out nvalues);
        }

        public static int[] GetIntStateAssignmentValues(IntPtr stateassignment, int[] nVals)
        {
            return CgNativeMethods.cgGetIntStateAssignmentValues(stateassignment, nVals);
        }

        public static string GetLastErrorString(out ErrorType error)
        {
            return Marshal.PtrToStringAnsi(CgNativeMethods.cgGetLastErrorString(out error));
        }

        public static string GetLastListing(IntPtr context)
        {
            return Marshal.PtrToStringAnsi(CgNativeMethods.cgGetLastListing(context));
        }

        public static LockingPolicy GetLockingPolicy()
        {
            return CgNativeMethods.cgGetLockingPolicy();
        }

        public static void GetMatrixParameter(IntPtr param, out int[] values)
        {
            values = GetMatrixParameter<int>(param, Order.RowMajor);
        }

        public static void GetMatrixParameter(IntPtr param, out float[] values)
        {
            values = GetMatrixParameter<float>(param, Order.RowMajor);
        }

        public static void GetMatrixParameter(IntPtr param, out double[] values)
        {
            values = GetMatrixParameter<double>(param, Order.RowMajor);
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

        public static Order GetMatrixParameterOrder(IntPtr param)
        {
            return CgNativeMethods.cgGetMatrixParameterOrder(param);
        }

        public static ParameterType GetMatrixSize(ParameterType type, out int nrows, out int ncols)
        {
            return CgNativeMethods.cgGetMatrixSize(type, out nrows, out ncols);
        }

        public static IntPtr GetNamedEffect(IntPtr context, string name)
        {
            return CgNativeMethods.cgGetNamedEffect(context, name);
        }

        public static IntPtr GetNamedEffectAnnotation(IntPtr effect, string name)
        {
            return CgNativeMethods.cgGetNamedEffectAnnotation(effect, name);
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

        public static IntPtr GetNamedSubParameter(IntPtr param, string name)
        {
            return CgNativeMethods.cgGetNamedSubParameter(param, name);
        }

        public static IntPtr GetNamedTechnique(IntPtr effect, string name)
        {
            return CgNativeMethods.cgGetNamedTechnique(effect, name);
        }

        public static IntPtr GetNamedTechniqueAnnotation(IntPtr technique, string name)
        {
            return CgNativeMethods.cgGetNamedTechniqueAnnotation(technique, name);
        }

        public static ParameterType GetNamedUserType(IntPtr handle, string name)
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

        public static int GetNumDependentProgramArrayStateAssignmentParameters(IntPtr sa)
        {
            return CgNativeMethods.cgGetNumDependentProgramArrayStateAssignmentParameters(sa);
        }

        public static int GetNumDependentStateAssignmentParameters(IntPtr stateassignment)
        {
            return CgNativeMethods.cgGetNumDependentStateAssignmentParameters(stateassignment);
        }

        public static int GetNumParentTypes(ParameterType type)
        {
            return CgNativeMethods.cgGetNumParentTypes(type);
        }

        public static int GetNumProgramDomains(IntPtr program)
        {
            return CgNativeMethods.cgGetNumProgramDomains(program);
        }

        public static int GetNumStateEnumerants(IntPtr state)
        {
            return CgNativeMethods.cgGetNumStateEnumerants(state);
        }

        public static int GetNumSupportedProfiles()
        {
            return CgNativeMethods.cgGetNumSupportedProfiles();
        }

        public static int GetNumUserTypes(IntPtr handle)
        {
            return CgNativeMethods.cgGetNumUserTypes(handle);
        }

        public static int GetParameterBaseResource(IntPtr param)
        {
            return CgNativeMethods.cgGetParameterBaseResource(param);
        }

        public static ParameterType GetParameterBaseType(IntPtr param)
        {
            return CgNativeMethods.cgGetParameterBaseType(param);
        }

        public static int GetParameterBufferIndex(IntPtr param)
        {
            return CgNativeMethods.cgGetParameterBufferIndex(param);
        }

        public static int GetParameterBufferOffset(IntPtr param)
        {
            return CgNativeMethods.cgGetParameterBufferOffset(param);
        }

        public static int GetParameterClass(IntPtr param)
        {
            return CgNativeMethods.cgGetParameterClass(param);
        }

        public static ParameterClass GetParameterClassEnum(string pString)
        {
            return CgNativeMethods.cgGetParameterClassEnum(pString);
        }

        public static string GetParameterClassString(ParameterClass pc)
        {
            return Marshal.PtrToStringAnsi(CgNativeMethods.cgGetParameterClassString(pc));
        }

        public static int GetParameterColumns(IntPtr param)
        {
            return CgNativeMethods.cgGetParameterColumns(param);
        }

        public static IntPtr GetParameterContext(IntPtr param)
        {
            return CgNativeMethods.cgGetParameterContext(param);
        }

        public static int GetParameterDefaultValue(IntPtr param, ref double[] values)
        {
            return GetParameterDefaultValue(param, ref values, Order.RowMajor);
        }

        public static int GetParameterDefaultValue(IntPtr param, ref double[] values, Order order)
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

        public static int GetParameterDefaultValue(IntPtr param, ref int[] values)
        {
            return GetParameterDefaultValue(param, ref values, Order.RowMajor);
        }

        public static int GetParameterDefaultValue(IntPtr param, ref int[] values, Order order)
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

        public static int GetParameterDefaultValue(IntPtr param, ref float[] values)
        {
            return GetParameterDefaultValue(param, ref values, Order.RowMajor);
        }

        public static int GetParameterDefaultValue(IntPtr param, ref float[] values, Order order)
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

        public static int GetParameterDirection(IntPtr param)
        {
            return CgNativeMethods.cgGetParameterDirection(param);
        }

        public static IntPtr GetParameterEffect(IntPtr param)
        {
            return CgNativeMethods.cgGetParameterEffect(param);
        }

        public static int GetParameterIndex(IntPtr param)
        {
            return CgNativeMethods.cgGetParameterIndex(param);
        }

        public static string GetParameterName(IntPtr param)
        {
            return Marshal.PtrToStringAnsi(CgNativeMethods.cgGetParameterName(param));
        }

        public static ParameterType GetParameterNamedType(IntPtr param)
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

        public static string GetParameterResourceName(IntPtr param)
        {
            return Marshal.PtrToStringAnsi(CgNativeMethods.cgGetParameterResourceName(param));
        }

        public static int GetParameterResourceSize(IntPtr param)
        {
            return CgNativeMethods.cgGetParameterResourceSize(param);
        }

        public static ParameterType GetParameterResourceType(IntPtr param)
        {
            return CgNativeMethods.cgGetParameterResourceType(param);
        }

        public static int GetParameterRows(IntPtr param)
        {
            return CgNativeMethods.cgGetParameterRows(param);
        }

        public static string GetParameterSemantic(IntPtr param)
        {
            return Marshal.PtrToStringAnsi(CgNativeMethods.cgGetParameterSemantic(param));
        }

        public static ParameterSettingMode GetParameterSettingMode(IntPtr context)
        {
            return CgNativeMethods.cgGetParameterSettingMode(context);
        }

        public static ParameterType GetParameterType(IntPtr param)
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

        public static void GetParameterValue(IntPtr param, ref float[] values)
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

        public static ParameterType GetParentType(ParameterType type, int index)
        {
            return CgNativeMethods.cgGetParentType(type, index);
        }

        public static string GetPassName(IntPtr pass)
        {
            return CgNativeMethods.cgGetPassName(pass);
        }

        public static IntPtr GetPassProgram(IntPtr pass, Domain domain)
        {
            return CgNativeMethods.cgGetPassProgram(pass, domain);
        }

        public static IntPtr GetPassTechnique(IntPtr pass)
        {
            return CgNativeMethods.cgGetPassTechnique(pass);
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

        public static IntPtr GetProgramBuffer(IntPtr program, int bufferIndex)
        {
            return CgNativeMethods.cgGetProgramBuffer(program, bufferIndex);
        }

        public static int GetProgramBufferMaxIndex(ProfileType profile)
        {
            return CgNativeMethods.cgGetProgramBufferMaxIndex(profile);
        }

        public static int GetProgramBufferMaxSize(ProfileType profile)
        {
            return CgNativeMethods.cgGetProgramBufferMaxSize(profile);
        }

        public static IntPtr GetProgramContext(IntPtr prog)
        {
            return CgNativeMethods.cgGetProgramContext(prog);
        }

        public static Domain GetProgramDomain(IntPtr program)
        {
            return CgNativeMethods.cgGetProgramDomain(program);
        }

        public static ProfileType GetProgramDomainProfile(IntPtr program, int index)
        {
            return CgNativeMethods.cgGetProgramDomainProfile(program, index);
        }

        public static IntPtr GetProgramDomainProgram(IntPtr program, int index)
        {
            return CgNativeMethods.cgGetProgramDomainProgram(program, index);
        }

        public static ProgramInput GetProgramInput(IntPtr program)
        {
            return CgNativeMethods.cgGetProgramInput(program);
        }

        public static string[] GetProgramOptions(IntPtr prog)
        {
            return CgNativeMethods.cgGetProgramOptions(prog);
        }

        public static ProgramOutput GetProgramOutput(IntPtr program)
        {
            return CgNativeMethods.cgGetProgramOutput(program);
        }

        public static ProfileType GetProgramProfile(IntPtr prog)
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

        public static ResourceType GetResource(string resourceName)
        {
            return CgNativeMethods.cgGetResource(resourceName);
        }

        public static string GetResourceString(ResourceType resource)
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

        public static IntPtr GetStateContext(IntPtr state)
        {
            return CgNativeMethods.cgGetStateContext(state);
        }

        public static string GetStateEnumerant(IntPtr state, int index, out int value)
        {
            return Marshal.PtrToStringAnsi(CgNativeMethods.cgGetStateEnumerant(state, index, out value));
        }

        public static string GetStateEnumerantName(IntPtr state, int index)
        {
            return Marshal.PtrToStringAnsi(CgNativeMethods.cgGetStateEnumerantName(state, index));
        }

        public static int GetStateEnumerantValue(IntPtr state, string name)
        {
            return CgNativeMethods.cgGetStateEnumerantValue(state, name);
        }

        public static ProfileType GetStateLatestProfile(IntPtr state)
        {
            return CgNativeMethods.cgGetStateLatestProfile(state);
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

        public static ParameterType GetStateType(IntPtr state)
        {
            return CgNativeMethods.cgGetStateType(state);
        }

        public static CgStateCallbackDelegate GetStateValidateCallback(IntPtr state)
        {
            return CgNativeMethods.cgGetStateValidateCallback(state);
        }

        public static string GetString(CgAll sname)
        {
            return Marshal.PtrToStringAnsi(CgNativeMethods.cgGetString(sname));
        }

        public static string GetStringAnnotationValue(IntPtr annotation)
        {
            return CgNativeMethods.cgGetStringAnnotationValue(annotation);
        }

        public static string[] GetStringAnnotationValues(IntPtr ann)
        {
            int nvalues;
            var ptr = CgNativeMethods.cgGetStringAnnotationValues(ann, out nvalues);
            if (nvalues == 0)
            {
                return null;
            }

            unsafe
            {
                var byteArray = (byte**)ptr;
                var lines = new List<string>();
                var buffer = new List<byte>();

                for (int i = 0; i < nvalues; i++)
                {
                    byte* b = *byteArray;
                    for (; ; )
                    {
                        if (*b == '\0')
                        {
                            char[] cc = Encoding.ASCII.GetChars(buffer.ToArray());
                            lines.Add(new string(cc));
                            buffer.Clear();
                            break;
                        }

                        buffer.Add(*b);
                        b++;
                    }

                    byteArray++;
                }

                return lines.ToArray();
            }
        }

        public static string GetStringParameterValue(IntPtr param)
        {
            return CgNativeMethods.cgGetStringParameterValue(param);
        }

        public static string GetStringStateAssignmentValue(IntPtr stateassignment)
        {
            return CgNativeMethods.cgGetStringStateAssignmentValue(stateassignment);
        }

        public static ProfileType GetSupportedProfile(int index)
        {
            return CgNativeMethods.cgGetSupportedProfile(index);
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

        public static ParameterType GetUserType(IntPtr handle, int index)
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

        public static bool IsInterfaceType(ParameterType type)
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

        public static bool IsParentType(ParameterType parent, int child)
        {
            return CgNativeMethods.cgIsParentType(parent, child);
        }

        public static bool IsPass(IntPtr pass)
        {
            return CgNativeMethods.cgIsPass(pass);
        }

        public static bool IsProfileSupported(ProfileType profile)
        {
            return CgNativeMethods.cgIsProfileSupported(profile);
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

        public static IntPtr MapBuffer(IntPtr buffer, BufferAccess access)
        {
            return CgNativeMethods.cgMapBuffer(buffer, access);
        }

        public static void ResetPassState(IntPtr pass)
        {
            CgNativeMethods.cgResetPassState(pass);
        }

        public static bool SetAnnotation(IntPtr ann, int value)
        {
            return CgNativeMethods.cgSetIntAnnotation(ann, value);
        }

        public static bool SetAnnotation(IntPtr ann, float value)
        {
            return CgNativeMethods.cgSetFloatAnnotation(ann, value);
        }

        public static bool SetAnnotation(IntPtr ann, string value)
        {
            return CgNativeMethods.cgSetStringAnnotation(ann, value);
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

        public static void SetBufferData(IntPtr buffer, int size, IntPtr data)
        {
            CgNativeMethods.cgSetBufferData(buffer, size, data);
        }

        public static void SetBufferSubData(IntPtr buffer, int offset, int size, IntPtr data)
        {
            CgNativeMethods.cgSetBufferSubData(buffer, offset, size, data);
        }

        public static void SetCompilerIncludeCallback(IntPtr context, CgIncludeCallbackFunc func)
        {
            CgNativeMethods.cgSetCompilerIncludeCallback(context, func);
        }

        public static void SetCompilerIncludeFile(IntPtr context, string name, string filename)
        {
            CgNativeMethods.cgSetCompilerIncludeFile(context, name, filename);
        }

        public static void SetCompilerIncludeString(IntPtr context, string name, string source)
        {
            CgNativeMethods.cgSetCompilerIncludeString(context, name, source);
        }

        public static void SetContextBehavior(IntPtr context, Behavior behavior)
        {
            CgNativeMethods.cgSetContextBehavior(context, behavior);
        }

        public static bool SetEffectName(IntPtr effect, string name)
        {
            return CgNativeMethods.cgSetEffectName(effect, name);
        }

        public static void SetEffectParameterBuffer(IntPtr param, IntPtr buffer)
        {
            CgNativeMethods.cgSetEffectParameterBuffer(param, buffer);
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

        public static void SetProgramBuffer(IntPtr program, int bufferIndex, IntPtr buffer)
        {
            CgNativeMethods.cgSetProgramBuffer(program, bufferIndex, buffer);
        }

        public static void SetProgramProfile(IntPtr prog, ProfileType profile)
        {
            CgNativeMethods.cgSetProgramProfile(prog, profile);
        }

        public static bool SetProgramStateAssignment(IntPtr stateassignment, IntPtr program)
        {
            return CgNativeMethods.cgSetProgramStateAssignment(stateassignment, program);
        }

        public static void SetSamplerState(IntPtr param)
        {
            CgNativeMethods.cgSetSamplerState(param);
        }

        public static bool SetSamplerStateAssignment(IntPtr stateassignment, IntPtr param)
        {
            return CgNativeMethods.cgSetSamplerStateAssignment(stateassignment, param);
        }

        public static CasePolicy SetSemanticCasePolicy(CasePolicy casePolicy)
        {
            return CgNativeMethods.cgSetSemanticCasePolicy(casePolicy);
        }

        public static bool SetStateAssignment(IntPtr stateassignment, float value)
        {
            return CgNativeMethods.cgSetFloatStateAssignment(stateassignment, value);
        }

        public static bool SetStateAssignment(IntPtr stateassignment, int value)
        {
            return CgNativeMethods.cgSetIntStateAssignment(stateassignment, value);
        }

        public static bool SetStateAssignment(IntPtr stateassignment, bool value)
        {
            return CgNativeMethods.cgSetBoolStateAssignment(stateassignment, value);
        }

        public static bool SetStateAssignment(IntPtr stateassignment, string value)
        {
            return CgNativeMethods.cgSetStringStateAssignment(stateassignment, value);
        }

        public static bool SetStateAssignment(IntPtr stateassignment, float[] value)
        {
            return CgNativeMethods.cgSetFloatArrayStateAssignment(stateassignment, value);
        }

        public static bool SetStateAssignment(IntPtr stateassignment, int[] value)
        {
            return CgNativeMethods.cgSetIntArrayStateAssignment(stateassignment, value);
        }

        public static bool SetStateAssignment(IntPtr stateassignment, bool[] value)
        {
            return CgNativeMethods.cgSetBoolArrayStateAssignment(stateassignment, value);
        }

        public static void SetStateCallbacks(IntPtr state, CgStateCallbackDelegate set, CgStateCallbackDelegate reset, CgStateCallbackDelegate validate)
        {
            CgNativeMethods.cgSetStateCallbacks(state, set, reset, validate);
        }

        public static void SetStateLatestProfile(IntPtr state, ProfileType profile)
        {
            CgNativeMethods.cgSetStateLatestProfile(state, profile);
        }

        public static void SetStringParameterValue(IntPtr param, string str)
        {
            CgNativeMethods.cgSetStringParameterValue(param, str);
        }

        public static bool SetTextureStateAssignment(IntPtr stateassignment, IntPtr param)
        {
            return CgNativeMethods.cgSetTextureStateAssignment(stateassignment, param);
        }

        public static void UnmapBuffer(IntPtr buffer)
        {
            CgNativeMethods.cgUnmapBuffer(buffer);
        }

        public static void UpdatePassParameters(IntPtr pass)
        {
            CgNativeMethods.cgUpdatePassParameters(pass);
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