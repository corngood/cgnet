/*
MIT License
Copyright ©2003-2006 Tao Framework Team
http://www.taoframework.com
All rights reserved.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
namespace CgNet.Wrapper
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    ///     Cg core runtime binding for .NET, implementing Cg 1.4.1.
    /// </summary>
    /// <remarks>
    ///     Binds functions and definitions in cg.dll or libcg.so.
    /// </remarks>
    internal static class CgNativeMethods
    {
        #region Fields

        internal const int CgFalse = 0;
        internal const int CgTrue = 1;

        private const string CgNativeLibrary = "cg.dll";
        private const CallingConvention Convention = CallingConvention.Cdecl;

        #endregion Fields

        #region Methods

        #region Internal Static Methods

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgAddStateEnumerant(IntPtr state, string name, int value);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool cgCallStateResetCallback(IntPtr stateassignment);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool cgCallStateSetCallback(IntPtr stateassignment);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool cgCallStateValidateCallback(IntPtr stateassignment);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgCombinePrograms(int n, IntPtr[] progs);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgCombinePrograms2(IntPtr exe1, IntPtr exe2);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgCombinePrograms3(IntPtr exe1, IntPtr exe2, IntPtr exe3);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgCombinePrograms4(IntPtr exe1, IntPtr exe2, IntPtr exe3, IntPtr exe4);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgCombinePrograms5(IntPtr exe1, IntPtr exe2, IntPtr exe3, IntPtr exe4, IntPtr exe5);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgCompileProgram(IntPtr prog);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgConnectParameter(IntPtr from, IntPtr to);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgCopyProgram(IntPtr program);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgCreateArraySamplerState(IntPtr context, string name, CgType type, int nelems);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgCreateArrayState(IntPtr context, string name, CgType type, int nelems);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgCreateContext();

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgCreateEffect(IntPtr context, string code, string[] args);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgCreateEffectFromFile(IntPtr context, string filename, string[] args);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgCreateParameter(IntPtr context, CgType type);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgCreateParameterArray(IntPtr context, CgType type, int length);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgCreateParameterMultiDimArray(IntPtr context, CgType type, int dim, [In] int[] lengths);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgCreateProgram(IntPtr context, ProgramType type, string source, CgProfile profile, string entry, string[] args);

        // CG_API CGannotation CGENTRY cgCreateProgramAnnotation(CGprogram program, const char *name, CGtype type);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgCreateProgramAnnotation(IntPtr annotation, string name, CgType type);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgCreateProgramFromEffect(IntPtr effect, CgProfile profile, string entry, string[] args);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgCreateProgramFromFile(IntPtr context, ProgramType type, string file, CgProfile profile, string entry, string[] args);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgCreateSamplerState(IntPtr context, string name, CgType type);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgCreateState(IntPtr context, string name, CgType type);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgDestroyContext(IntPtr context);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgDestroyEffect(IntPtr effect);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgDestroyParameter(IntPtr param);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgDestroyProgram(IntPtr program);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgDisconnectParameter(IntPtr param);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgEvaluateProgram(IntPtr prog, float[] f, int ncomps, int nx, int ny, int nz);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetAnnotationName(IntPtr annotation);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern CgType cgGetAnnotationType(IntPtr annotation);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern int cgGetArrayDimension(IntPtr param);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetArrayParameter(IntPtr aparam, int index);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern int cgGetArraySize(IntPtr param, int dimension);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern int cgGetArrayTotalSize(IntPtr param);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern CgType cgGetArrayType(IntPtr param);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern AutoCompileMode cgGetAutoCompile(IntPtr context);

        // const CGbool * cgGetBoolAnnotationValues( CGannotation ann, int * nvalues );
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetBoolAnnotationValues(IntPtr annotation, out int nvalues);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity,
        Obsolete]
        internal static extern int[] cgGetBooleanAnnotationValues(IntPtr annotation, out int[] nvalues);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetBoolStateAssignmentValues(IntPtr stateassignment, out int nVals);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetConnectedParameter(IntPtr param);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetConnectedToParameter(IntPtr param, int index);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetDependentAnnotationParameter(IntPtr annotation, int index);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetDependentStateAssignmentParameter(IntPtr stateassignment, int index);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetEffectContext(IntPtr effect);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="effect"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        // CGDLL_API CGparameter cgGetEffectParameterBySemantic(CGeffect, const char *);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetEffectParameterBySemantic(IntPtr effect, string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumString"></param>
        /// <returns></returns>
        // CGDLL_API CGenum cgGetEnum(const char *enum_string);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern int cgGetEnum(string enumString);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        // CGDLL_API const char *cgGetEnumString(CGenum en);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern string cgGetEnumString(int en);

        /// <summary>
        ///    Returns an error enum if an error has occured in the last Cg method call.
        /// </summary>
        /// <returns>Error enum.</returns>
        //CGDLL_API CGerror cgGetError(void);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern CgError cgGetError();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // CGDLL_API CGerrorCallbackFunc cgGetErrorCallback(void);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern Cg.CgErrorCallbackFuncDelegate cgGetErrorCallback();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        // CGDLL_API CGerrorHandlerFunc cgGetErrorHandler(void **data);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern Cg.CgErrorHandlerFuncDelegate cgGetErrorHandler(IntPtr data);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetErrorString(CgError error);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        // CGDLL_API CGparameter cgGetFirstDependentParameter(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetFirstDependentParameter(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // CGDLL_API CGeffect cgGetFirstEffect(CGcontext);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetFirstEffect(IntPtr context);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="effect"></param>
        /// <returns></returns>
        // CGDLL_API CGparameter cgGetFirstEffectParameter(CGeffect);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetFirstEffectParameter(IntPtr effect);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // CGDLL_API CGerror cgGetFirstError(void);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern CgError cgGetFirstError();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="effect"></param>
        /// <returns></returns>
        // CGDLL_API CGparameter cgGetFirstLeafEffectParameter(CGeffect);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetFirstLeafEffectParameter(IntPtr effect);

        /// <summary>
        ///    Used to get the first leaf parameter from the specified program.
        /// </summary>
        /// <remarks>
        ///    Leaf params read into params that are structs as well, eliminating the need to explictly 
        ///    determine if the param is a struct or other type.
        /// </remarks>
        /// <param name="program">
        ///    Handle to the program to query.
        /// </param>
        /// <param name="nameSpace">
        ///    Namespace in which to query for the params (usually CG_PROGRAM).
        /// </param>
        /// <returns>
        ///    Handle to the first Cg parameter in the specified program.
        /// </returns>
        // CGDLL_API CGparameter cgGetFirstLeafParameter(CGprogram prog, CGenum name_space);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetFirstLeafParameter(IntPtr program, int nameSpace);

        /// <summary>
        /// Gets the first parameter in specified program.
        /// </summary>
        /// <param name="prog">The program to retreive the first program from.</param>
        /// <param name="nameSpace">Namespace of the parameter to iterate through.</param>
        /// <returns>First parameter in specified program.</returns>
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetFirstParameter(IntPtr prog, int nameSpace);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        // CGDLL_API CGannotation cgGetFirstParameterAnnotation(CGparameter);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetFirstParameterAnnotation(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="technique"></param>
        /// <returns></returns>
        // CGDLL_API CGpass cgGetFirstPass(CGtechnique);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetFirstPass(IntPtr technique);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pass"></param>
        /// <returns></returns>
        // CGDLL_API CGannotation cgGetFirstPassAnnotation(CGpass);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetFirstPassAnnotation(IntPtr pass);

        /// <summary>
        ///     Gets the first program in a context.
        /// </summary>
        /// <param name="context">
        ///     The context to retreive first program from.
        /// </param>
        /// <returns>
        ///     The program or null if no programs available.
        /// </returns>
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetFirstProgram(IntPtr context);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetFirstProgramAnnotation(IntPtr prog);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // CGDLL_API CGstate cgGetFirstSamplerState(CGcontext);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetFirstSamplerState(IntPtr context);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        // CGDLL_API CGstateassignment cgGetFirstSamplerStateAssignment(CGparameter);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetFirstSamplerStateAssignment(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // CGDLL_API CGstate cgGetFirstState(CGcontext);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetFirstState(IntPtr context);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pass"></param>
        /// <returns></returns>
        // CGDLL_API CGstateassignment cgGetFirstStateAssignment(CGpass);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetFirstStateAssignment(IntPtr pass);

        /// <summary>
        /// Gets the first child parameter in a struct parameter.
        /// </summary>
        /// <param name="param">The struct parameter to get child parameter from.</param>
        /// <returns>First child parameter in specified struct parameter.</returns>
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetFirstStructParameter(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="effect"></param>
        /// <returns></returns>
        // CGDLL_API CGtechnique cgGetFirstTechnique(CGeffect);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetFirstTechnique(IntPtr effect);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="technique"></param>
        /// <returns></returns>
        // CGDLL_API CGannotation cgGetFirstTechniqueAnnotation(CGtechnique);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetFirstTechniqueAnnotation(IntPtr technique);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="annotation"></param>
        /// <param name="nvalues"></param>
        /// <returns></returns>
        // CGDLL_API const float *cgGetFloatAnnotationValues(CGannotation, int *nvalues);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern float[] cgGetFloatAnnotationValues(IntPtr annotation, out int nvalues);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateassignment"></param>
        /// <param name="nVals"></param>
        /// <returns></returns>
        // CGDLL_API const float *cgGetFloatStateAssignmentValues(CGstateassignment, int *nVals);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern float[] cgGetFloatStateAssignmentValues(IntPtr stateassignment, int[] nVals);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="annotation"></param>
        /// <param name="nvalues"></param>
        /// <returns></returns>
        // CGDLL_API const int *cgGetIntAnnotationValues(CGannotation, int *nvalues);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern int[] cgGetIntAnnotationValues(IntPtr annotation, out int nvalues);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateassignment"></param>
        /// <param name="nVals"></param>
        /// <returns></returns>
        // CGDLL_API const int *cgGetIntStateAssignmentValues(CGstateassignment, int *nVals);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern int[] cgGetIntStateAssignmentValues(IntPtr stateassignment, int[] nVals);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetLastErrorString(out CgError error);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetLastListing(IntPtr context);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="matrix"></param>
        // CGDLL_API void cgGetMatrixParameterdc(CGparameter param, double *matrix);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgGetMatrixParameterdc(IntPtr param, IntPtr matrix);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="matrix"></param>
        // CGDLL_API void cgGetMatrixParameterdr(CGparameter param, double *matrix);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgGetMatrixParameterdr(IntPtr param, IntPtr matrix);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="matrix"></param>
        // CGDLL_API void cgGetMatrixParameterfc(CGparameter param, float *matrix);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgGetMatrixParameterfc(IntPtr param, IntPtr matrix);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="matrix"></param>
        // CGDLL_API void cgGetMatrixParameterfr(CGparameter param, float *matrix);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgGetMatrixParameterfr(IntPtr param, IntPtr matrix);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="matrix"></param>
        // CGDLL_API void cgGetMatrixParameteric(CGparameter param, int *matrix);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgGetMatrixParameteric(IntPtr param, IntPtr matrix);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="matrix"></param>
        // CGDLL_API void cgGetMatrixParameterir(CGparameter param, int *matrix);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgGetMatrixParameterir(IntPtr param, IntPtr matrix);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="effect"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        // CGDLL_API CGparameter cgGetNamedEffectParameter(CGeffect, const char *);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetNamedEffectParameter(IntPtr effect, string name);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetNamedParameter(IntPtr program, string parameter);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        // CGDLL_API CGannotation cgGetNamedParameterAnnotation(CGparameter, const char *);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetNamedParameterAnnotation(IntPtr param, string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="technique"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        // CGDLL_API CGpass cgGetNamedPass(CGtechnique, const char *name);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetNamedPass(IntPtr technique, string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pass"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        // CGDLL_API CGannotation cgGetNamedPassAnnotation(CGpass, const char *);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetNamedPassAnnotation(IntPtr pass, string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prog"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        // CGDLL_API CGannotation cgGetNamedProgramAnnotation(CGprogram, const char *);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetNamedProgramAnnotation(IntPtr prog, string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prog"></param>
        /// <param name="nameSpace"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        // CGDLL_API CGparameter cgGetNamedProgramParameter(CGprogram prog,  CGenum name_space,  const char *name);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetNamedProgramParameter(IntPtr prog, ProgramNamespace nameSpace, string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        // CGDLL_API CGstate cgGetNamedSamplerState(CGcontext, string name);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetNamedSamplerState(IntPtr context, string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        // CGDLL_API CGstateassignment cgGetNamedSamplerStateAssignment(CGparameter, const char *);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetNamedSamplerStateAssignment(IntPtr param, string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        // CGDLL_API CGstate cgGetNamedState(CGcontext, const char *name);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetNamedState(IntPtr context, string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pass"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        // CGDLL_API CGstateassignment cgGetNamedStateAssignment(CGpass, const char *name);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetNamedStateAssignment(IntPtr pass, string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        // CGDLL_API CGparameter cgGetNamedStructParameter(CGparameter param, const char *name);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetNamedStructParameter(IntPtr param, string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="effect"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        // CGDLL_API CGtechnique cgGetNamedTechnique(CGeffect, const char *name);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetNamedTechnique(IntPtr effect, string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="technique"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        // CGDLL_API CGannotation cgGetNamedTechniqueAnnotation(CGtechnique, const char *);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetNamedTechniqueAnnotation(IntPtr technique, string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        // CGDLL_API CGtype cgGetNamedUserType(CGhandle handle, const char *name);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern CgType cgGetNamedUserType(IntPtr handle, string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="annotation"></param>
        /// <returns></returns>
        // CGDLL_API CGannotation cgGetNextAnnotation(CGannotation);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetNextAnnotation(IntPtr annotation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="effect"></param>
        /// <returns></returns>
        // CGDLL_API CGeffect cgGetNextEffect(CGeffect);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetNextEffect(IntPtr effect);

        /// <summary>
        ///    Gets a handle to the leaf parameter directly following the specified param.
        /// </summary>
        /// <param name="currentParam">Current Cg parameter.</param>
        /// <returns>Handle to the next param after the current program, null if the current is the last param.</returns>
        // CGDLL_API CGparameter cgGetNextLeafParameter(CGparameter current);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetNextLeafParameter(IntPtr currentParam);

        /// <summary>
        /// Iterates to next parameter in program.
        /// </summary>
        /// <param name="currentParam">The current parameter.</param>
        /// <returns>The next parameter in the program's internal sequence of parameters.</returns>
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetNextParameter(IntPtr currentParam);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pass"></param>
        /// <returns></returns>
        // CGDLL_API CGpass cgGetNextPass(CGpass);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetNextPass(IntPtr pass);

        /// <summary>
        ///     Iterate trough programs in a context.
        /// </summary>
        /// <param name="current">
        ///     Current program.
        /// </param>
        /// <returns>
        ///     Next program in context's internal sequence of programs.
        /// </returns>
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetNextProgram(IntPtr current);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        // CGDLL_API CGstate cgGetNextState(CGstate);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetNextState(IntPtr state);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateassignment"></param>
        /// <returns></returns>
        // CGDLL_API CGstateassignment cgGetNextStateAssignment(CGstateassignment);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetNextStateAssignment(IntPtr stateassignment);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="technique"></param>
        /// <returns></returns>
        // CGDLL_API CGtechnique cgGetNextTechnique(CGtechnique);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetNextTechnique(IntPtr technique);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        // CGDLL_API int cgGetNumConnectedToParameters(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern int cgGetNumConnectedToParameters(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="annotation"></param>
        /// <returns></returns>
        // CGDLL_API int cgGetNumDependentAnnotationParameters(CGannotation);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern int cgGetNumDependentAnnotationParameters(IntPtr annotation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateassignment"></param>
        /// <returns></returns>
        // CGDLL_API int cgGetNumDependentStateAssignmentParameters(CGstateassignment);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern int cgGetNumDependentStateAssignmentParameters(IntPtr stateassignment);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        // CGDLL_API int cgGetNumParentTypes(CGtype type);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern int cgGetNumParentTypes(CgType type);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        // CGDLL_API int cgGetNumUserTypes(CGhandle handle);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern int cgGetNumUserTypes(IntPtr handle);

        /// <summary>
        /// Gets a parameter's base resource.
        /// </summary>
        /// <param name="param">Parameter to retreive base resource from</param>
        /// <returns>Base resource of a given parameter.</returns>
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern int cgGetParameterBaseResource(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        // CGDLL_API CGtype cgGetParameterBaseType(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern CgType cgGetParameterBaseType(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        // CGDLL_API CGparameterclass cgGetParameterClass(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern int cgGetParameterClass(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        // CGDLL_API int cgGetParameterColumns(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern int cgGetParameterColumns(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        // CGDLL_API CGcontext cgGetParameterContext(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetParameterContext(IntPtr param);

        /// <summary>
        ///    Gets the direction of this parameter, i.e. CG_IN, CG_OUT, CG_INOUT.
        /// </summary>
        /// <param name="param">Id of the parameter to query.</param>
        /// <returns>Enum value representing the parameter's direction.</returns>
        // CGDLL_API CGenum cgGetParameterDirection(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern int cgGetParameterDirection(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        // CGDLL_API int cgGetParameterIndex(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern int cgGetParameterIndex(IntPtr param);

        /// <summary>
        ///    Gets the name of the specified program.
        /// </summary>
        /// <param name="param">Handle to the program to query.</param>
        /// <returns>IntPtr that must be converted to an Ansi string via Marshal.PtrToStringAnsi.</returns>
        // CGDLL_API const char *cgGetParameterName(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetParameterName(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        // CGDLL_API CGtype cgGetParameterNamedType(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern CgType cgGetParameterNamedType(IntPtr param);

        /// <summary>
        /// Returns an integer that represents the position of a parameter when it was declared within the Cg program.
        /// </summary>
        /// <param name="param">Parameter to retreive it's ordinal number.</param>
        /// <returns>Parameter's ordinal number.</returns>
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern int cgGetParameterOrdinalNumber(IntPtr param);

        /// <summary>
        /// Gets program that specified parameter belongs to.
        /// </summary>
        /// <param name="param">Parameter to retreive it's parent program.</param>
        /// <returns>A program given parameter belongs to.</returns>
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetParameterProgram(IntPtr param);

        /// <summary>
        /// Gets a parameter's resource.
        /// </summary>
        /// <param name="param">Parameter to retreive resource from</param>
        /// <returns>Resource of a given parameter.</returns>
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern int cgGetParameterResource(IntPtr param);

        /// <summary>
        ///    Retrieves the index of the specifed parameter according to its type and variability.
        /// </summary>
        /// <remarks>
        ///    For example, if the resource for a given parameter is CG_TEXCOORD7,
        ///    cgGetParameterResourceIndex() returns 7.  Also, for uniform params, it equates
        ///    to the constant index that will be used in the resulting program.
        /// </remarks>
        /// <param name="param">
        ///    Handle of the param to query.
        /// </param>
        /// <returns>
        ///    Index of the specified parameter according to its type and variability.
        /// </returns>
        // CGDLL_API unsigned long cgGetParameterResourceIndex(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern int cgGetParameterResourceIndex(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        // CGDLL_API int cgGetParameterRows(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern int cgGetParameterRows(IntPtr param);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetParameterSemantic(IntPtr param);

        /// <summary>
        ///    Gets the data type of the specified parameter.
        /// </summary>
        /// <param name="param">Id of the parameter to query.</param>
        /// <returns>Enum value representing the parameter's data type.</returns>
        // CGDLL_API CGtype cgGetParameterType(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern CgType cgGetParameterType(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="n"></param>
        /// <param name="vals"></param>
        /// <returns></returns>
        // CGDLL_API int cgGetParameterValuedc(CGparameter param, int n, double *vals);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern int cgGetParameterValuedc(IntPtr param, int n, IntPtr vals);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="n"></param>
        /// <param name="vals"></param>
        /// <returns></returns>
        // CGDLL_API int cgGetParameterValuedr(CGparameter param, int n, double *vals);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern int cgGetParameterValuedr(IntPtr param, int n, IntPtr vals);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="n"></param>
        /// <param name="vals"></param>
        /// <returns></returns>
        // CGDLL_API int cgGetParameterValuefc(CGparameter param, int n, float *vals);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern int cgGetParameterValuefc(IntPtr param, int n, IntPtr vals);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="n"></param>
        /// <param name="vals"></param>
        /// <returns></returns>
        // CGDLL_API int cgGetParameterValuefr(CGparameter param, int n, float *vals);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern int cgGetParameterValuefr(IntPtr param, int n, IntPtr vals);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="n"></param>
        /// <param name="vals"></param>
        /// <returns></returns>
        // CGDLL_API int cgGetParameterValueic(CGparameter param, int n, int *vals);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern int cgGetParameterValueic(IntPtr param, int n, IntPtr vals);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="n"></param>
        /// <param name="vals"></param>
        /// <returns></returns>
        // CGDLL_API int cgGetParameterValueir(CGparameter param, int n, int *vals);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern int cgGetParameterValueir(IntPtr param, int n, IntPtr vals);

        /// <summary>
        /// Gets a program parameter's values. 
        /// </summary>
        /// <param name="param">Parameter to retreive parameter's values from.</param>
        /// <param name="valueType">CG_CONSTANT or CG?DEFAULT</param>
        /// <param name="nvalues">Array of integers indicating the number of values in parameters.</param>
        /// <returns>Array of double values.</returns>
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity,
        Obsolete]
        internal static unsafe extern double* cgGetParameterValues(IntPtr param, int valueType, int* nvalues);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity,
        Obsolete]
        internal static extern double[] cgGetParameterValues(IntPtr param, int value_type, int[] nvalues);

        /// <summary>
        ///    Gets the variability of the specified param (i.e, uniform, varying, etc).
        /// </summary>
        /// <param name="param">Handle of the program to query.</param>
        /// <returns>Enum stating the variability of the program.</returns>
        // CGDLL_API CGenum cgGetParameterVariability(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern int cgGetParameterVariability(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        // CGDLL_API CGtype cgGetParentType(CGtype type, int index);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern CgType cgGetParentType(CgType type, int index);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pass"></param>
        /// <returns></returns>
        // CGDLL_API const char *cgGetPassName(CGpass);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern string cgGetPassName(IntPtr pass);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pass"></param>
        /// <returns></returns>
        // CGDLL_API CGtechnique cgGetPassTechnique(CGpass);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetPassTechnique(IntPtr pass);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern CgProfile cgGetProfile(string profile);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetProfileString(CgProfile profile);

        /// <summary>
        ///     Gets a programs parent context.
        /// </summary>
        /// <param name="prog">
        ///     Program to retreive context from.
        /// </param>
        /// <returns>
        ///     The context a given program belongs to.
        /// </returns>
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetProgramContext(IntPtr prog);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prog"></param>
        /// <returns></returns>
        // CGDLL_API char const * const *cgGetProgramOptions(CGprogram prog);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern string[] cgGetProgramOptions(IntPtr prog);

        /// <summary>
        ///     Gets the profile enumeration of the program.
        /// </summary>
        /// <param name="prog">
        ///     Specifies the program.
        /// </param>
        /// <returns>
        ///     The profile enumeration or CG_PROFILE_UNKNOWN if compilation failed.
        /// </returns>
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern int cgGetProgramProfile(IntPtr prog);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateassignment"></param>
        /// <returns></returns>
        // CGDLL_API CGprogram cgGetProgramStateAssignmentValue(CGstateassignment);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetProgramStateAssignmentValue(IntPtr stateassignment);

        /// <summary>
        ///     Gets the specified source from the program.
        /// </summary>
        /// <param name="program">
        ///     Handle to the Cg program.
        /// </param>
        /// <param name="sourceType">
        ///     Type of source to pull, whether original or compiled, etc.
        /// </param>
        /// <returns>
        ///     IntPtr to the string data.  Must be converted using Marshal.PtrToStringAnsi.
        /// </returns>
        // CGDLL_API const char *cgGetProgramString(CGprogram prog, CGenum pname);
        [DllImport(CgNativeLibrary, CallingConvention = Convention, CharSet = CharSet.Auto),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetProgramString(IntPtr program, SourceType sourceType);

        /// <summary>
        /// Gets the resource enumerant assigned to a resource name.
        /// </summary>
        /// <param name="resourceName">Resource's name.</param>
        /// <returns>Resource enumerant.</returns>
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern CgResource cgGetResource(string resourceName);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetResourceString(CgResource resource);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateassignment"></param>
        /// <returns></returns>
        // CGDLL_API CGparameter cgGetSamplerStateAssignmentParameter(CGstateassignment);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetSamplerStateAssignmentParameter(IntPtr stateassignment);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateassignment"></param>
        /// <returns></returns>
        // CGDLL_API CGstate cgGetSamplerStateAssignmentState(CGstateassignment);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetSamplerStateAssignmentState(IntPtr stateassignment);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateassignment"></param>
        /// <returns></returns>
        // CGDLL_API CGparameter cgGetSamplerStateAssignmentValue(CGstateassignment);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetSamplerStateAssignmentValue(IntPtr stateassignment);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateassignment"></param>
        /// <returns></returns>
        // CGDLL_API int cgGetStateAssignmentIndex(CGstateassignment);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern int cgGetStateAssignmentIndex(IntPtr stateassignment);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateassignment"></param>
        /// <returns></returns>
        // CGDLL_API CGpass cgGetStateAssignmentPass(CGstateassignment);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetStateAssignmentPass(IntPtr stateassignment);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateassignment"></param>
        /// <returns></returns>
        // CGDLL_API CGstate cgGetStateAssignmentState(CGstateassignment);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetStateAssignmentState(IntPtr stateassignment);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        // CGDLL_API int cgGetStateEnumerantValue(CGstate, const char*)
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern int cgGetStateEnumerantValue(IntPtr state, string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        // CGDLL_API const char *cgGetStateName(CGstate);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern string cgGetStateName(IntPtr state);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        // CGDLL_API CGstatecallback cgGetStateResetCallback(CGstate);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern Cg.CgStateCallbackDelegate cgGetStateResetCallback(IntPtr state);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        // CGDLL_API CGstatecallback cgGetStateSetCallback(CGstate);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern Cg.CgStateCallbackDelegate cgGetStateSetCallback(IntPtr state);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        // CGDLL_API CGtype cgGetStateType(CGstate);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern CgType cgGetStateType(IntPtr state);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        // CGDLL_API CGstatecallback cgGetStateValidateCallback(CGstate);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern Cg.CgStateCallbackDelegate cgGetStateValidateCallback(IntPtr state);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetString(CgEnum sname);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="annotation"></param>
        /// <returns></returns>
        // CGDLL_API const char *cgGetStringAnnotationValue(CGannotation);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern string cgGetStringAnnotationValue(IntPtr annotation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        // CGDLL_API const char *cgGetStringParameterValue(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern string cgGetStringParameterValue(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateassignment"></param>
        /// <returns></returns>
        // CGDLL_API const char *cgGetStringStateAssignmentValue(CGstateassignment);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern string cgGetStringStateAssignmentValue(IntPtr stateassignment);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="technique"></param>
        /// <returns></returns>
        // CGDLL_API CGeffect cgGetTechniqueEffect(CGtechnique);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetTechniqueEffect(IntPtr technique);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="technique"></param>
        /// <returns></returns>
        // CGDLL_API const char *cgGetTechniqueName(CGtechnique);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern string cgGetTechniqueName(IntPtr technique);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateassignment"></param>
        /// <returns></returns>
        // CGDLL_API CGparameter cgGetTextureStateAssignmentValue(CGstateassignment);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetTextureStateAssignmentValue(IntPtr stateassignment);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeString"></param>
        /// <returns></returns>
        // CGDLL_API CGtype cgGetType(const char *type_string);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern CgType cgGetType(string typeString);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        // CGDLL_API const char *cgGetTypeString(CGtype type);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern IntPtr cgGetTypeString(CgType type);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        // CGDLL_API CGtype cgGetUserType(CGhandle handle, int index);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern CgType cgGetUserType(IntPtr handle, int index);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="annotation"></param>
        /// <returns></returns>
        // CGDLL_API CGbool cgIsAnnotation(CGannotation);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool cgIsAnnotation(IntPtr annotation);

        /// <summary>
        ///     Given the specified context handle, returns true if it is a valid Cg context.
        /// </summary>
        /// <param name="context">
        ///     Handle of the context to check.
        /// </param>
        /// <returns>
        ///     CG_TRUE if valid, CG_FALSE otherwise.
        /// </returns>
        // CGDLL_API CGbool cgIsContext(CGcontext context);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool cgIsContext(IntPtr context);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="effect"></param>
        /// <returns></returns>
        // CGDLL_API CGbool cgIsEffect(CGeffect effect);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool cgIsEffect(IntPtr effect);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        // CGDLL_API CGbool cgIsInterfaceType(CGtype type);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool cgIsInterfaceType(CgType type);

        /// <summary>
        /// Determines if parameter is valid Cg parameter object.
        /// </summary>
        /// <param name="param">Parameter.</param>
        /// <returns>CG_TRUE ig parameter is valid Cg parameter object.</returns>
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool cgIsParameter(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        // CGDLL_API CGbool cgIsParameterGlobal(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool cgIsParameterGlobal(IntPtr param);

        /// <summary>
        ///    Queries whether the specified program will be used in the final compiled program.
        /// </summary>
        /// <remarks>
        ///    The compiler may ignore parameters that are not actually used within the program.
        /// </remarks>
        /// <param name="param">Handle to the Cg parameter.</param>
        /// <returns>True if the param is being used, false if not.</returns>
        // CGDLL_API CGbool cgIsParameterReferenced(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool cgIsParameterReferenced(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="handle"></param>
        /// <returns></returns>
        // CGDLL_API CGbool cgIsParameterUsed(CGparameter param, CGhandle handle);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool cgIsParameterUsed(IntPtr param, IntPtr handle);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="child"></param>
        /// <returns></returns>
        // CGDLL_API CGbool cgIsParentType(CGtype parent, CGtype child);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool cgIsParentType(CgType parent, int child);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pass"></param>
        /// <returns></returns>
        // CGDLL_API CGbool cgIsPass(CGpass);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool cgIsPass(IntPtr pass);

        /// <summary>
        ///     Determine if a program handle references a Cg program object.
        /// </summary>
        /// <param name="prog">
        ///     The program handle.
        /// </param>
        /// <returns>
        ///     CG_TRUE if prog references a valid program object.
        /// </returns>
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool cgIsProgram(IntPtr prog);

        /// <summary>
        ///     Determines if a program has been compiled.
        /// </summary>
        /// <param name="prog">
        ///     Specifies the program.
        /// </param>
        /// <returns>
        ///     CG_TRUE if specified program has been compiled.
        /// </returns>
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool cgIsProgramCompiled(IntPtr prog);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        // CGDLL_API CGbool cgIsState(CGstate);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool cgIsState(IntPtr state);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateassignment"></param>
        /// <returns></returns>
        // CGDLL_API CGbool cgIsStateAssignment(CGstateassignment);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool cgIsStateAssignment(IntPtr stateassignment);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="technique"></param>
        /// <returns></returns>
        // CGDLL_API CGbool cgIsTechnique(CGtechnique);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool cgIsTechnique(IntPtr technique);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="technique"></param>
        /// <returns></returns>
        // CGDLL_API CGbool cgIsTechniqueValidated(CGtechnique);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool cgIsTechniqueValidated(IntPtr technique);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pass"></param>
        // CGDLL_API void cgResetPassState(CGpass);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgResetPassState(IntPtr pass);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="size"></param>
        // CGDLL_API void cgSetArraySize(CGparameter param, int size);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetArraySize(IntPtr param, int size);

        /// <summary>
        /// 
        /// </summary>
        // CGDLL_API void cgSetAutoCompile(CGcontext context, CGenum flag);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetAutoCompile(IntPtr context, AutoCompileMode flag);

        //CG_API CGbool CGENTRY cgSetBoolAnnotation(CGannotation ann, CGbool value);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool cgSetBoolAnnotation(IntPtr annotation, [MarshalAs(UnmanagedType.Bool)]bool value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="func"></param>
        // CGDLL_API void cgSetErrorCallback(CGerrorCallbackFunc func);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetErrorCallback(Cg.CgErrorCallbackFuncDelegate func);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="func"></param>
        /// <param name="data"></param>
        // CGDLL_API void cgSetErrorHandler(CGerrorHandlerFunc func, void *data);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetErrorHandler(Cg.CgErrorHandlerFuncDelegate func, IntPtr data);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="listing"></param>
        // CGDLL_API void cgSetLastListing(CGhandle handle, const char *listing);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetLastListing(IntPtr handle, string listing);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="matrix"></param>
        // CGDLL_API void cgSetMatrixParameterdc(CGparameter param, const double *matrix);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetMatrixParameterdc(IntPtr param, [In] double[] matrix);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="matrix"></param>
        // CGDLL_API void cgSetMatrixParameterdr(CGparameter param, const double *matrix);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetMatrixParameterdr(IntPtr param, [In] double[] matrix);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetMatrixParameterfc(IntPtr param, [In] float[] matrix);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetMatrixParameterfr(IntPtr param, [In] float[] matrix);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="matrix"></param>
        // CGDLL_API void cgSetMatrixParameteric(CGparameter param, const int *matrix);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetMatrixParameteric(IntPtr param, [In] int[] matrix);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="matrix"></param>
        // CGDLL_API void cgSetMatrixParameterir(CGparameter param, const int *matrix);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetMatrixParameterir(IntPtr param, [In] int[] matrix);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="sizes"></param>
        // CGDLL_API void cgSetMultiDimArraySize(CGparameter param, const int *sizes);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetMultiDimArraySize(IntPtr param, [In] int[] sizes);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="x"></param>
        // CGDLL_API void cgSetParameter1d(CGparameter param, double x);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetParameter1d(IntPtr param, double x);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="v"></param>
        // CGDLL_API void cgSetParameter1dv(CGparameter param, const double *v);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetParameter1dv(IntPtr param, double[] v);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetParameter1f(IntPtr param, float x);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="v"></param>
        // CGDLL_API void cgSetParameter1fv(CGparameter param, const float *v);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetParameter1fv(IntPtr param, float[] v);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="x"></param>
        // CGDLL_API void cgSetParameter1i(CGparameter param, int x);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetParameter1i(IntPtr param, int x);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="v"></param>
        // CGDLL_API void cgSetParameter1iv(CGparameter param, const int *v);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetParameter1iv(IntPtr param, int[] v);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        // CGDLL_API void cgSetParameter2d(CGparameter param, double x, double y);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetParameter2d(IntPtr param, double x, double y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="v"></param>
        // CGDLL_API void cgSetParameter2dv(CGparameter param, const double *v);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetParameter2dv(IntPtr param, double[] v);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetParameter2f(IntPtr param, float x, float y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="v"></param>
        // CGDLL_API void cgSetParameter2fv(CGparameter param, const float *v);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetParameter2fv(IntPtr param, float[] v);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        // CGDLL_API void cgSetParameter2i(CGparameter param, int x, int y);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetParameter2i(IntPtr param, int x, int y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="v"></param>
        // CGDLL_API void cgSetParameter2iv(CGparameter param, const int *v);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetParameter2iv(IntPtr param, int[] v);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        // CGDLL_API void cgSetParameter3d(CGparameter param, double x, double y, double z);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetParameter3d(IntPtr param, double x, double y, double z);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="v"></param>
        // CGDLL_API void cgSetParameter3dv(CGparameter param, const double *v);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetParameter3dv(IntPtr param, double[] v);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetParameter3f(IntPtr param, float x, float y, float z);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetParameter3fv(IntPtr param, float[] v);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        // CGDLL_API void cgSetParameter3i(CGparameter param, int x, int y, int z);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetParameter3i(IntPtr param, int x, int y, int z);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="v"></param>
        // CGDLL_API void cgSetParameter3iv(CGparameter param, const int *v);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetParameter3iv(IntPtr param, int[] v);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="w"></param>
        // CGDLL_API void cgSetParameter4d(CGparameter param, double x, double y, double z, double w);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetParameter4d(IntPtr param, double x, double y, double z, double w);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="v"></param>
        // CGDLL_API void cgSetParameter4dv(CGparameter param, const double *v);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetParameter4dv(IntPtr param, double[] v);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetParameter4f(IntPtr param, float x, float y, float z, float w);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="v"></param>
        // CGDLL_API void cgSetParameter4fv(CGparameter param, const float *v);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetParameter4fv(IntPtr param, float[] v);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="w"></param>
        // CGDLL_API void cgSetParameter4i(CGparameter param, int x, int y, int z, int w);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetParameter4i(IntPtr param, int x, int y, int z, int w);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="v"></param>
        // CGDLL_API void cgSetParameter4iv(CGparameter param, const int *v);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetParameter4iv(IntPtr param, int[] v);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="semantic"></param>
        // CGDLL_API void cgSetParameterSemantic(CGparameter param, const char *semantic);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetParameterSemantic(IntPtr param, string semantic);

        //CG_API void CGENTRY cgSetParameterSettingMode(CGcontext context, CGenum parameterSettingMode);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetParameterSettingMode(IntPtr context, ParameterSettingMode parameterSettingMode);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="n"></param>
        /// <param name="vals"></param>
        // CGDLL_API void cgSetParameterValuedc(CGparameter param, int n, out double vals);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetParameterValuedc(IntPtr param, int n, double[] vals);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="n"></param>
        /// <param name="vals"></param>
        // CGDLL_API void cgSetParameterValuedr(CGparameter param, int n, const double *vals);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetParameterValuedr(IntPtr param, int n, double[] vals);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="n"></param>
        /// <param name="vals"></param>
        // CGDLL_API void cgSetParameterValuefc(CGparameter param, int n, const float *vals);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetParameterValuefc(IntPtr param, int n, float[] vals);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="n"></param>
        /// <param name="vals"></param>
        // CGDLL_API void cgSetParameterValuefr(CGparameter param, int n, const float *vals);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetParameterValuefr(IntPtr param, int n, float[] vals);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="n"></param>
        /// <param name="vals"></param>
        // CGDLL_API void cgSetParameterValueic(CGparameter param, int n, const int *vals);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetParameterValueic(IntPtr param, int n, int[] vals);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="n"></param>
        /// <param name="vals"></param>
        // CGDLL_API void cgSetParameterValueir(CGparameter param, int n, const int *vals);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetParameterValueir(IntPtr param, int n, int[] vals);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="vary"></param>
        // CGDLL_API void cgSetParameterVariability(CGparameter param, CGenum vary);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetParameterVariability(IntPtr param, int vary);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prog"></param>
        // CGDLL_API void cgSetPassProgramParameters(CGprogram);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetPassProgramParameters(IntPtr prog);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pass"></param>
        // CGDLL_API void cgSetPassState(CGpass);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetPassState(IntPtr pass);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetProgramProfile(IntPtr prog, CgProfile profile);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        // CGDLL_API void cgSetSamplerState(CGparameter);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetSamplerState(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <param name="set"></param>
        /// <param name="reset"></param>
        /// <param name="validate"></param>
        // CGDLL_API void cgSetStateCallbacks(CGstate, CGstatecallback set, CGstatecallback reset, CGstatecallback validate);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetStateCallbacks(IntPtr state, Cg.CgStateCallbackDelegate set, Cg.CgStateCallbackDelegate reset, Cg.CgStateCallbackDelegate validate);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="str"></param>
        // CGDLL_API void cgSetStringParameterValue(CGparameter param, const char *str);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgSetStringParameterValue(IntPtr param, string str);

        //CG_API void CGENTRY cgUpdateProgramParameters(CGprogram program);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        internal static extern void cgUpdateProgramParameters(IntPtr program);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="technique"></param>
        /// <returns></returns>
        // CGDLL_API CGbool cgValidateTechnique(CGtechnique);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool cgValidateTechnique(IntPtr technique);

        #endregion Internal Static Methods

        #endregion Methods
    }
}