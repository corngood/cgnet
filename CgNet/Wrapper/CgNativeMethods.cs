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
namespace CGNet.Wrapper
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

        private const CallingConvention Convention = CallingConvention.Cdecl;
        private const string CgNativeLibrary = "cg.dll";

        #endregion Fields

        #region Delegates

        /// <summary>
        ///    
        /// </summary>
        // typedef void (*CGerrorCallbackFunc)(void);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CGerrorCallbackFuncDelegate();

        /// <summary>
        ///    
        /// </summary>
        // typedef void (*CGerrorHandlerFunc)(CGcontext context, CGerror err, void *data);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CGerrorHandlerFuncDelegate(IntPtr context, int err, IntPtr data);

        /// <summary>
        ///    
        /// </summary>
        // typedef CGbool (*CGstatecallback)(CGstateassignment);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int CGstatecallbackDelegate(IntPtr cGstateassignment);

        #endregion Delegates

        #region Methods

        #region Public Static Methods

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgAddStateEnumerant(IntPtr state, string name, int value);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgCallStateResetCallback(IntPtr stateassignment);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgCallStateSetCallback(IntPtr stateassignment);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgCallStateValidateCallback(IntPtr stateassignment);

        // CG_API CGprogram CGENTRY cgCombinePrograms( int n, const CGprogram *exeList );
        // CG_API CGprogram CGENTRY cgCombinePrograms2( const CGprogram exe1, const CGprogram exe2 );
        // CG_API CGprogram CGENTRY cgCombinePrograms3( const CGprogram exe1, const CGprogram exe2, const CGprogram exe3 );
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCombinePrograms(int n, IntPtr[] progs);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgCompileProgram(IntPtr prog);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgConnectParameter(IntPtr from, IntPtr to);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCopyProgram(IntPtr program);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCreateArraySamplerState(IntPtr context, string name, int type, int nelems);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCreateArrayState(IntPtr context, string name, int type, int nelems);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCreateContext();

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCreateEffect(IntPtr context, string code, string[] args);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCreateEffectFromFile(IntPtr context, string filename, string[] args);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCreateParameter(IntPtr context, int type);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCreateParameterArray(IntPtr context, int type, int length);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCreateParameterMultiDimArray(IntPtr context, int type, int dim, out int lengths);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCreateProgram(IntPtr context, int type, string source, int profile, string entry, string[] args);

        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCreateProgramFromEffect(IntPtr effect, int profile, string entry, string[] args);

        /// <summary>
        ///     Creates a Cg program from the specified file.
        /// </summary>
        /// <param name="context">
        ///     Current Cg context.
        /// </param>
        /// <param name="type">
        ///     Type of source to use.
        /// </param>
        /// <param name="file">
        ///     Name of the file to load and compile.
        /// </param>
        /// <param name="profile">
        ///     Profile to use for compiling the program.
        /// </param>
        /// <param name="entry">
        ///     Entry point of the specified Cg source.  If null, then 'main' is assumed.
        /// </param>
        /// <param name="args">
        ///     Optional args to pass to the compiler.
        /// </param>
        /// <returns>
        ///     Handle to the newly created Cg program.
        /// </returns>
        // CGDLL_API CGprogram cgCreateProgramFromFile(CGcontext context, CGenum program_type, const char *program_file, CGprofile profile, const char *entry, const char **args);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCreateProgramFromFile(IntPtr context, int type, string file, int profile, string entry, string[] args);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        // CGDLL_API CGstate cgCreateSamplerState(CGcontext, string name, CGtype);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCreateSamplerState(IntPtr context, string name, int type);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        // CGDLL_API CGstate cgCreateState(CGcontext, const char *name, CGtype);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCreateState(IntPtr context, string name, int type);

        /// <summary>
        ///     Destroys the specified Cg context.
        /// </summary>
        /// <param name="context">
        ///     Handle to the Cg context to destroy.
        /// </param>
        // CGDLL_API void cgDestroyContext(CGcontext context);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgDestroyContext(IntPtr context);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="effect"></param>
        // CGDLL_API void cgDestroyEffect(CGeffect);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgDestroyEffect(IntPtr effect);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        // CGDLL_API void cgDestroyParameter(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgDestroyParameter(IntPtr param);

        /// <summary>
        ///     Destroys the specified Cg program.
        /// </summary>
        /// <param name="program">
        ///     Handle to the program to destroy.
        /// </param>
        // CGDLL_API void cgDestroyProgram(CGprogram program);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgDestroyProgram(IntPtr program);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        // CGDLL_API void cgDisconnectParameter(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgDisconnectParameter(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prog"></param>
        /// <param name="f"></param>
        /// <param name="ncomps"></param>
        /// <param name="nx"></param>
        /// <param name="ny"></param>
        /// <param name="nz"></param>
        // CGDLL_API void cgEvaluateProgram(CGprogram, float *, int ncomps, int nx, int ny, int nz);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgEvaluateProgram(IntPtr prog, float[] f, int ncomps, int nx, int ny, int nz);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="annotation"></param>
        /// <returns></returns>
        // CGDLL_API const char *cgGetAnnotationName(CGannotation);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern string cgGetAnnotationName(IntPtr annotation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="annotation"></param>
        /// <returns></returns>
        // CGDLL_API CGtype cgGetAnnotationType(CGannotation);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgGetAnnotationType(IntPtr annotation);

        /// <summary>
        /// Gets the dimension of an array parameter.
        /// </summary>
        /// <param name="param">Parameter.</param>
        /// <returns>Dimension of the specified parameter.</returns>
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgGetArrayDimension(IntPtr param);

        /// <summary>
        /// Gets the parameter from an array.
        /// </summary>
        /// <param name="aparam">Array parameter.</param>
        /// <param name="index">Index into the array.</param>
        /// <returns>Parameter of array param specified by the index.</returns>
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetArrayParameter(IntPtr aparam, int index);

        /// <summary>
        /// Gets the size of an array.
        /// </summary>
        /// <param name="param">Parameter.</param>
        /// <param name="dimension">The dimension whose size will be returned.</param>
        /// <returns>Size of specified parameters dimension.</returns>
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgGetArraySize(IntPtr param, int dimension);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        // CGDLL_API int cgGetArrayTotalSize(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgGetArrayTotalSize(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        // CGDLL_API CGtype cgGetArrayType(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgGetArrayType(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        // CGDLL_API void cgGetAutoCompile(CGcontext context);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgGetAutoCompile(IntPtr context);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="annotation"></param>
        /// <param name="nvalues"></param>
        /// <returns></returns>
        // CGDLL_API const int *cgGetBooleanAnnotationValues(CGannotation, int *nvalues);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int[] cgGetBooleanAnnotationValues(IntPtr annotation, out int nvalues);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateassignment"></param>
        /// <param name="nVals"></param>
        /// <returns></returns>
        // CGDLL_API const CGbool *cgGetBoolStateAssignmentValues(CGstateassignment, int *nVals);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int[] cgGetBoolStateAssignmentValues(IntPtr stateassignment, int[] nVals);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        // CGDLL_API CGparameter cgGetConnectedParameter(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetConnectedParameter(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        // CGDLL_API CGparameter cgGetConnectedToParameter(CGparameter param, int index);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetConnectedToParameter(IntPtr param, int index);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="annotation"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        // CGDLL_API CGparameter cgGetDependentAnnotationParameter(CGannotation, int index);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetDependentAnnotationParameter(IntPtr annotation, int index);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateassignment"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        // CGDLL_API CGparameter cgGetDependentStateAssignmentParameter(CGstateassignment, int index);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetDependentStateAssignmentParameter(IntPtr stateassignment, int index);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="effect"></param>
        /// <returns></returns>
        // CGDLL_API CGcontext cgGetEffectContext(CGeffect);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetEffectContext(IntPtr effect);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="effect"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        // CGDLL_API CGparameter cgGetEffectParameterBySemantic(CGeffect, const char *);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetEffectParameterBySemantic(IntPtr effect, string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enum_string"></param>
        /// <returns></returns>
        // CGDLL_API CGenum cgGetEnum(const char *enum_string);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgGetEnum(string enum_string);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        // CGDLL_API const char *cgGetEnumString(CGenum en);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern string cgGetEnumString(int en);

        /// <summary>
        ///    Returns an error enum if an error has occured in the last Cg method call.
        /// </summary>
        /// <returns>Error enum.</returns>
        //CGDLL_API CGerror cgGetError(void);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgGetError();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // CGDLL_API CGerrorCallbackFunc cgGetErrorCallback(void);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern CGerrorCallbackFuncDelegate cgGetErrorCallback();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        // CGDLL_API CGerrorHandlerFunc cgGetErrorHandler(void **data);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern CGerrorHandlerFuncDelegate cgGetErrorHandler(IntPtr data);

        /// <summary>
        ///    Returns an error description from the specified error enum value.
        /// </summary>
        /// <param name="error">Error enum value.</param>
        /// <returns>String description of the specified error enum value.</returns>
        public static string cgGetErrorString(int error)
        {
            return Marshal.PtrToStringAnsi(cgGetErrorStringA(error));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        // CGDLL_API CGparameter cgGetFirstDependentParameter(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetFirstDependentParameter(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        // CGDLL_API CGeffect cgGetFirstEffect(CGcontext);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetFirstEffect(IntPtr context);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="effect"></param>
        /// <returns></returns>
        // CGDLL_API CGparameter cgGetFirstEffectParameter(CGeffect);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetFirstEffectParameter(IntPtr effect);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // CGDLL_API CGerror cgGetFirstError(void);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgGetFirstError();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="effect"></param>
        /// <returns></returns>
        // CGDLL_API CGparameter cgGetFirstLeafEffectParameter(CGeffect);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetFirstLeafEffectParameter(IntPtr effect);

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
        public static extern IntPtr cgGetFirstLeafParameter(IntPtr program, int nameSpace);

        /// <summary>
        /// Gets the first parameter in specified program.
        /// </summary>
        /// <param name="prog">The program to retreive the first program from.</param>
        /// <param name="name_space">Namespace of the parameter to iterate through.</param>
        /// <returns>First parameter in specified program.</returns>
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetFirstParameter(IntPtr prog, int name_space);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        // CGDLL_API CGannotation cgGetFirstParameterAnnotation(CGparameter);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetFirstParameterAnnotation(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="technique"></param>
        /// <returns></returns>
        // CGDLL_API CGpass cgGetFirstPass(CGtechnique);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetFirstPass(IntPtr technique);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pass"></param>
        /// <returns></returns>
        // CGDLL_API CGannotation cgGetFirstPassAnnotation(CGpass);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetFirstPassAnnotation(IntPtr pass);

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
        public static extern IntPtr cgGetFirstProgram(IntPtr context);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prog"></param>
        /// <returns></returns>
        // CGDLL_API CGannotation cgGetFirstProgramAnnotation(CGprogram);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetFirstProgramAnnotation(IntPtr prog);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        // CGDLL_API CGstate cgGetFirstSamplerState(CGcontext);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetFirstSamplerState(IntPtr context);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        // CGDLL_API CGstateassignment cgGetFirstSamplerStateAssignment(CGparameter);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetFirstSamplerStateAssignment(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        // CGDLL_API CGstate cgGetFirstState(CGcontext);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetFirstState(IntPtr context);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pass"></param>
        /// <returns></returns>
        // CGDLL_API CGstateassignment cgGetFirstStateAssignment(CGpass);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetFirstStateAssignment(IntPtr pass);

        /// <summary>
        /// Gets the first child parameter in a struct parameter.
        /// </summary>
        /// <param name="param">The struct parameter to get child parameter from.</param>
        /// <returns>First child parameter in specified struct parameter.</returns>
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetFirstStructParameter(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="effect"></param>
        /// <returns></returns>
        // CGDLL_API CGtechnique cgGetFirstTechnique(CGeffect);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetFirstTechnique(IntPtr effect);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="technique"></param>
        /// <returns></returns>
        // CGDLL_API CGannotation cgGetFirstTechniqueAnnotation(CGtechnique);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetFirstTechniqueAnnotation(IntPtr technique);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="annotation"></param>
        /// <param name="nvalues"></param>
        /// <returns></returns>
        // CGDLL_API const float *cgGetFloatAnnotationValues(CGannotation, int *nvalues);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern float[] cgGetFloatAnnotationValues(IntPtr annotation, out int nvalues);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateassignment"></param>
        /// <param name="nVals"></param>
        /// <returns></returns>
        // CGDLL_API const float *cgGetFloatStateAssignmentValues(CGstateassignment, int *nVals);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern float[] cgGetFloatStateAssignmentValues(IntPtr stateassignment, int[] nVals);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="annotation"></param>
        /// <param name="nvalues"></param>
        /// <returns></returns>
        // CGDLL_API const int *cgGetIntAnnotationValues(CGannotation, int *nvalues);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int[] cgGetIntAnnotationValues(IntPtr annotation, out int nvalues);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateassignment"></param>
        /// <param name="nVals"></param>
        /// <returns></returns>
        // CGDLL_API const int *cgGetIntStateAssignmentValues(CGstateassignment, int *nVals);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int[] cgGetIntStateAssignmentValues(IntPtr stateassignment, int[] nVals);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        // CGDLL_API const char *cgGetLastErrorString(CGerror *error);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern string cgGetLastErrorString(out int error);

        /// <summary>
        ///     Gets the compiler output from the results of the most recent program compilation for the given Cg context.
        /// </summary>
        /// <param name="context">
        ///     Handle to the context to query.
        /// </param>
        /// <returns>
        ///     String representing compiler output from last program compiled.
        /// </returns>
        public static string cgGetLastListing(IntPtr context)
        {
            return Marshal.PtrToStringAnsi(cgGetLastListingA(context));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="matrix"></param>
        // CGDLL_API void cgGetMatrixParameterdc(CGparameter param, double *matrix);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGetMatrixParameterdc(IntPtr param, out double matrix);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="matrix"></param>
        // CGDLL_API void cgGetMatrixParameterdr(CGparameter param, double *matrix);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGetMatrixParameterdr(IntPtr param, out double matrix);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="matrix"></param>
        // CGDLL_API void cgGetMatrixParameterfc(CGparameter param, float *matrix);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGetMatrixParameterfc(IntPtr param, out float matrix);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="matrix"></param>
        // CGDLL_API void cgGetMatrixParameterfr(CGparameter param, float *matrix);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGetMatrixParameterfr(IntPtr param, out float matrix);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="matrix"></param>
        // CGDLL_API void cgGetMatrixParameteric(CGparameter param, int *matrix);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGetMatrixParameteric(IntPtr param, out int matrix);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="matrix"></param>
        // CGDLL_API void cgGetMatrixParameterir(CGparameter param, int *matrix);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGetMatrixParameterir(IntPtr param, out int matrix);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="effect"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        // CGDLL_API CGparameter cgGetNamedEffectParameter(CGeffect, const char *);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNamedEffectParameter(IntPtr effect, string name);

        /// <summary>
        /// Gets the named parameter from the program.
        /// </summary>
        /// <param name="program">
        /// The program to get parameter from.
        /// </param>
        /// <param name="parameter">
        /// The name of the parameter to return.
        /// </param>
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNamedParameter(IntPtr program, string parameter);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        // CGDLL_API CGannotation cgGetNamedParameterAnnotation(CGparameter, const char *);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNamedParameterAnnotation(IntPtr param, string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="technique"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        // CGDLL_API CGpass cgGetNamedPass(CGtechnique, const char *name);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNamedPass(IntPtr technique, string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pass"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        // CGDLL_API CGannotation cgGetNamedPassAnnotation(CGpass, const char *);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNamedPassAnnotation(IntPtr pass, string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prog"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        // CGDLL_API CGannotation cgGetNamedProgramAnnotation(CGprogram, const char *);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNamedProgramAnnotation(IntPtr prog, string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prog"></param>
        /// <param name="name_space"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        // CGDLL_API CGparameter cgGetNamedProgramParameter(CGprogram prog,  CGenum name_space,  const char *name);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNamedProgramParameter(IntPtr prog, int name_space, string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        // CGDLL_API CGstate cgGetNamedSamplerState(CGcontext, string name);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNamedSamplerState(IntPtr context, string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        // CGDLL_API CGstateassignment cgGetNamedSamplerStateAssignment(CGparameter, const char *);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNamedSamplerStateAssignment(IntPtr param, string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        // CGDLL_API CGstate cgGetNamedState(CGcontext, const char *name);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNamedState(IntPtr context, string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pass"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        // CGDLL_API CGstateassignment cgGetNamedStateAssignment(CGpass, const char *name);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNamedStateAssignment(IntPtr pass, string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        // CGDLL_API CGparameter cgGetNamedStructParameter(CGparameter param, const char *name);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNamedStructParameter(IntPtr param, string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="effect"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        // CGDLL_API CGtechnique cgGetNamedTechnique(CGeffect, const char *name);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNamedTechnique(IntPtr effect, string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="technique"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        // CGDLL_API CGannotation cgGetNamedTechniqueAnnotation(CGtechnique, const char *);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNamedTechniqueAnnotation(IntPtr technique, string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        // CGDLL_API CGtype cgGetNamedUserType(CGhandle handle, const char *name);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgGetNamedUserType(IntPtr handle, string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="annotation"></param>
        /// <returns></returns>
        // CGDLL_API CGannotation cgGetNextAnnotation(CGannotation);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNextAnnotation(IntPtr annotation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="effect"></param>
        /// <returns></returns>
        // CGDLL_API CGeffect cgGetNextEffect(CGeffect);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNextEffect(IntPtr effect);

        /// <summary>
        ///    Gets a handle to the leaf parameter directly following the specified param.
        /// </summary>
        /// <param name="currentParam">Current Cg parameter.</param>
        /// <returns>Handle to the next param after the current program, null if the current is the last param.</returns>
        // CGDLL_API CGparameter cgGetNextLeafParameter(CGparameter current);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNextLeafParameter(IntPtr currentParam);

        /// <summary>
        /// Iterates to next parameter in program.
        /// </summary>
        /// <param name="currentParam">The current parameter.</param>
        /// <returns>The next parameter in the program's internal sequence of parameters.</returns>
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNextParameter(IntPtr currentParam);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pass"></param>
        /// <returns></returns>
        // CGDLL_API CGpass cgGetNextPass(CGpass);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNextPass(IntPtr pass);

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
        public static extern IntPtr cgGetNextProgram(IntPtr current);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        // CGDLL_API CGstate cgGetNextState(CGstate);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNextState(IntPtr state);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateassignment"></param>
        /// <returns></returns>
        // CGDLL_API CGstateassignment cgGetNextStateAssignment(CGstateassignment);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNextStateAssignment(IntPtr stateassignment);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="technique"></param>
        /// <returns></returns>
        // CGDLL_API CGtechnique cgGetNextTechnique(CGtechnique);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNextTechnique(IntPtr technique);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        // CGDLL_API int cgGetNumConnectedToParameters(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgGetNumConnectedToParameters(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="annotation"></param>
        /// <returns></returns>
        // CGDLL_API int cgGetNumDependentAnnotationParameters(CGannotation);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgGetNumDependentAnnotationParameters(IntPtr annotation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateassignment"></param>
        /// <returns></returns>
        // CGDLL_API int cgGetNumDependentStateAssignmentParameters(CGstateassignment);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgGetNumDependentStateAssignmentParameters(IntPtr stateassignment);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        // CGDLL_API int cgGetNumParentTypes(CGtype type);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgGetNumParentTypes(int type);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        // CGDLL_API int cgGetNumUserTypes(CGhandle handle);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgGetNumUserTypes(IntPtr handle);

        /// <summary>
        /// Gets a parameter's base resource.
        /// </summary>
        /// <param name="param">Parameter to retreive base resource from</param>
        /// <returns>Base resource of a given parameter.</returns>
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgGetParameterBaseResource(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        // CGDLL_API CGtype cgGetParameterBaseType(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgGetParameterBaseType(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        // CGDLL_API CGparameterclass cgGetParameterClass(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgGetParameterClass(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        // CGDLL_API int cgGetParameterColumns(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgGetParameterColumns(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        // CGDLL_API CGcontext cgGetParameterContext(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetParameterContext(IntPtr param);

        /// <summary>
        ///    Gets the direction of this parameter, i.e. CG_IN, CG_OUT, CG_INOUT.
        /// </summary>
        /// <param name="param">Id of the parameter to query.</param>
        /// <returns>Enum value representing the parameter's direction.</returns>
        // CGDLL_API CGenum cgGetParameterDirection(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgGetParameterDirection(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        // CGDLL_API int cgGetParameterIndex(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgGetParameterIndex(IntPtr param);

        /// <summary>
        ///    Gets the name of the specified program.
        /// </summary>
        /// <param name="param">Handle to the program to query.</param>
        /// <returns>The name of the specified program as a string.</returns>
        public static string cgGetParameterName(IntPtr param)
        {
            return Marshal.PtrToStringAnsi(cgGetParameterNameA(param));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        // CGDLL_API CGtype cgGetParameterNamedType(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgGetParameterNamedType(IntPtr param);

        /// <summary>
        /// Returns an integer that represents the position of a parameter when it was declared within the Cg program.
        /// </summary>
        /// <param name="param">Parameter to retreive it's ordinal number.</param>
        /// <returns>Parameter's ordinal number.</returns>
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgGetParameterOrdinalNumber(IntPtr param);

        /// <summary>
        /// Gets program that specified parameter belongs to.
        /// </summary>
        /// <param name="param">Parameter to retreive it's parent program.</param>
        /// <returns>A program given parameter belongs to.</returns>
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetParameterProgram(IntPtr param);

        /// <summary>
        /// Gets a parameter's resource.
        /// </summary>
        /// <param name="param">Parameter to retreive resource from</param>
        /// <returns>Resource of a given parameter.</returns>
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgGetParameterResource(IntPtr param);

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
        public static extern int cgGetParameterResourceIndex(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        // CGDLL_API int cgGetParameterRows(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgGetParameterRows(IntPtr param);

        /// <summary>
        /// Gets the parameter's semantic string.
        /// </summary>
        /// <param name="param">Parameter to get semantic from.</param>
        /// <returns>Parameter's semantic string.</returns>
        public static string cgGetParameterSemantic(IntPtr param)
        {
            return Marshal.PtrToStringAnsi(cgGetParameterSemanticA(param));
        }

        /// <summary>
        ///    Gets the data type of the specified parameter.
        /// </summary>
        /// <param name="param">Id of the parameter to query.</param>
        /// <returns>Enum value representing the parameter's data type.</returns>
        // CGDLL_API CGtype cgGetParameterType(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgGetParameterType(IntPtr param);

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
        public static extern int cgGetParameterValuedc(IntPtr param, int n, double[] vals);

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
        public static extern int cgGetParameterValuedr(IntPtr param, int n, double[] vals);

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
        public static extern int cgGetParameterValuefc(IntPtr param, int n, float[] vals);

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
        public static extern int cgGetParameterValuefr(IntPtr param, int n, float[] vals);

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
        public static extern int cgGetParameterValueic(IntPtr param, int n, int[] vals);

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
        public static extern int cgGetParameterValueir(IntPtr param, int n, int[] vals);

        /// <summary>
        /// Gets a program parameter's values. 
        /// </summary>
        /// <param name="param">Parameter to retreive parameter's values from.</param>
        /// <param name="value_type">CG_CONSTANT or CG?DEFAULT</param>
        /// <param name="nvalues">Array of integers indicating the number of values in parameters.</param>
        /// <returns>Array of double values.</returns>
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern double[] cgGetParameterValues(IntPtr param, int value_type, int[] nvalues);

        /// <summary>
        /// Gets a program parameter's values. 
        /// </summary>
        /// <param name="param">Parameter to retreive parameter's values from.</param>
        /// <param name="value_type">CG_CONSTANT or CG?DEFAULT</param>
        /// <param name="nvalues">Array of integers indicating the number of values in parameters.</param>
        /// <returns>Array of double values.</returns>
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern double* cgGetParameterValues(IntPtr param, int value_type, int* nvalues);

        /// <summary>
        /// Gets a program parameter's values. 
        /// </summary>
        /// <param name="param">Parameter to retreive parameter's values from.</param>
        /// <param name="value_type">CG_CONSTANT or CG?DEFAULT</param>
        /// <param name="nvalues">Array of integers indicating the number of values in parameters.</param>
        /// <returns>Array of double values.</returns>
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetParameterValues(IntPtr param, int value_type, IntPtr nvalues);

        /// <summary>
        ///    Gets the variability of the specified param (i.e, uniform, varying, etc).
        /// </summary>
        /// <param name="param">Handle of the program to query.</param>
        /// <returns>Enum stating the variability of the program.</returns>
        // CGDLL_API CGenum cgGetParameterVariability(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgGetParameterVariability(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        // CGDLL_API CGtype cgGetParentType(CGtype type, int index);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgGetParentType(int type, int index);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pass"></param>
        /// <returns></returns>
        // CGDLL_API const char *cgGetPassName(CGpass);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern string cgGetPassName(IntPtr pass);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pass"></param>
        /// <returns></returns>
        // CGDLL_API CGtechnique cgGetPassTechnique(CGpass);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetPassTechnique(IntPtr pass);

        /// <summary>
        ///     Returns a profile enum value based on the string representation of the profile.
        /// </summary>
        /// <param name="profile">
        ///     Name of the profile, i.e. arbvp1, vs_1_1, etc.
        /// </param>
        /// <returns>
        ///     Enum value containing the integral representation of the profile.
        /// </returns>
        // CGDLL_API CGprofile cgGetProfile(const char *profile_string);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgGetProfile(string profile);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        // CGDLL_API const char *cgGetProfileString(CGprofile profile);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern string cgGetProfileString(int profile);

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
        public static extern IntPtr cgGetProgramContext(IntPtr prog);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prog"></param>
        /// <returns></returns>
        // CGDLL_API char const * const *cgGetProgramOptions(CGprogram prog);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern string[] cgGetProgramOptions(IntPtr prog);

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
        public static extern int cgGetProgramProfile(IntPtr prog);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateassignment"></param>
        /// <returns></returns>
        // CGDLL_API CGprogram cgGetProgramStateAssignmentValue(CGstateassignment);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetProgramStateAssignmentValue(IntPtr stateassignment);

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
        ///     String containing the source of the specified type from the program.
        /// </returns>
        public static string cgGetProgramString(IntPtr program, int sourceType)
        {
            return Marshal.PtrToStringAnsi(cgGetProgramStringA(program, sourceType));
        }

        /// <summary>
        /// Gets the resource enumerant assigned to a resource name.
        /// </summary>
        /// <param name="resource_name">Resource's name.</param>
        /// <returns>Resource enumerant.</returns>
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgGetResource(string resource_name);

        /// <summary>
        /// get the resource name associated with a resource enumerant 
        /// </summary>
        /// <param name="resource">Resource ID to get name from.</param>
        /// <returns>Resource's name.</returns>
        public static string cgGetResourceString(int resource)
        {
            return Marshal.PtrToStringAnsi(cgGetResourceStringA(resource));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateassignment"></param>
        /// <returns></returns>
        // CGDLL_API CGparameter cgGetSamplerStateAssignmentParameter(CGstateassignment);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetSamplerStateAssignmentParameter(IntPtr stateassignment);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateassignment"></param>
        /// <returns></returns>
        // CGDLL_API CGstate cgGetSamplerStateAssignmentState(CGstateassignment);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetSamplerStateAssignmentState(IntPtr stateassignment);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateassignment"></param>
        /// <returns></returns>
        // CGDLL_API CGparameter cgGetSamplerStateAssignmentValue(CGstateassignment);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetSamplerStateAssignmentValue(IntPtr stateassignment);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateassignment"></param>
        /// <returns></returns>
        // CGDLL_API int cgGetStateAssignmentIndex(CGstateassignment);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgGetStateAssignmentIndex(IntPtr stateassignment);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateassignment"></param>
        /// <returns></returns>
        // CGDLL_API CGpass cgGetStateAssignmentPass(CGstateassignment);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetStateAssignmentPass(IntPtr stateassignment);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateassignment"></param>
        /// <returns></returns>
        // CGDLL_API CGstate cgGetStateAssignmentState(CGstateassignment);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetStateAssignmentState(IntPtr stateassignment);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        // CGDLL_API int cgGetStateEnumerantValue(CGstate, const char*)
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgGetStateEnumerantValue(IntPtr state, string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        // CGDLL_API const char *cgGetStateName(CGstate);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern string cgGetStateName(IntPtr state);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        // CGDLL_API CGstatecallback cgGetStateResetCallback(CGstate);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern CGstatecallbackDelegate cgGetStateResetCallback(IntPtr state);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        // CGDLL_API CGstatecallback cgGetStateSetCallback(CGstate);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern CGstatecallbackDelegate cgGetStateSetCallback(IntPtr state);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        // CGDLL_API CGtype cgGetStateType(CGstate);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgGetStateType(IntPtr state);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        // CGDLL_API CGstatecallback cgGetStateValidateCallback(CGstate);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern CGstatecallbackDelegate cgGetStateValidateCallback(IntPtr state);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sname"></param>
        /// <returns></returns>
        // CGDLL_API const char *cgGetString(CGenum sname);
        public static string cgGetString(int sname)
        {
            return Marshal.PtrToStringAnsi(_cgGetString(sname));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="annotation"></param>
        /// <returns></returns>
        // CGDLL_API const char *cgGetStringAnnotationValue(CGannotation);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern string cgGetStringAnnotationValue(IntPtr annotation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        // CGDLL_API const char *cgGetStringParameterValue(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern string cgGetStringParameterValue(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateassignment"></param>
        /// <returns></returns>
        // CGDLL_API const char *cgGetStringStateAssignmentValue(CGstateassignment);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern string cgGetStringStateAssignmentValue(IntPtr stateassignment);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="technique"></param>
        /// <returns></returns>
        // CGDLL_API CGeffect cgGetTechniqueEffect(CGtechnique);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetTechniqueEffect(IntPtr technique);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="technique"></param>
        /// <returns></returns>
        // CGDLL_API const char *cgGetTechniqueName(CGtechnique);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern string cgGetTechniqueName(IntPtr technique);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateassignment"></param>
        /// <returns></returns>
        // CGDLL_API CGparameter cgGetTextureStateAssignmentValue(CGstateassignment);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetTextureStateAssignmentValue(IntPtr stateassignment);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type_string"></param>
        /// <returns></returns>
        // CGDLL_API CGtype cgGetType(const char *type_string);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgGetType(string type_string);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        // CGDLL_API const char *cgGetTypeString(CGtype type);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern string cgGetTypeString(int type);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        // CGDLL_API CGtype cgGetUserType(CGhandle handle, int index);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgGetUserType(IntPtr handle, int index);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="annotation"></param>
        /// <returns></returns>
        // CGDLL_API CGbool cgIsAnnotation(CGannotation);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgIsAnnotation(IntPtr annotation);

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
        public static extern int cgIsContext(IntPtr context);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="effect"></param>
        /// <returns></returns>
        // CGDLL_API CGbool cgIsEffect(CGeffect effect);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgIsEffect(IntPtr effect);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        // CGDLL_API CGbool cgIsInterfaceType(CGtype type);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgIsInterfaceType(int type);

        /// <summary>
        /// Determines if parameter is valid Cg parameter object.
        /// </summary>
        /// <param name="param">Parameter.</param>
        /// <returns>CG_TRUE ig parameter is valid Cg parameter object.</returns>
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern bool cgIsParameter(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        // CGDLL_API CGbool cgIsParameterGlobal(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgIsParameterGlobal(IntPtr param);

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
        public static extern int cgIsParameterReferenced(IntPtr param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="handle"></param>
        /// <returns></returns>
        // CGDLL_API CGbool cgIsParameterUsed(CGparameter param, CGhandle handle);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgIsParameterUsed(IntPtr param, IntPtr handle);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="child"></param>
        /// <returns></returns>
        // CGDLL_API CGbool cgIsParentType(CGtype parent, CGtype child);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgIsParentType(int parent, int child);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pass"></param>
        /// <returns></returns>
        // CGDLL_API CGbool cgIsPass(CGpass);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgIsPass(IntPtr pass);

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
        public static extern bool cgIsProgram(IntPtr prog);

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
        public static extern bool cgIsProgramCompiled(IntPtr prog);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        // CGDLL_API CGbool cgIsState(CGstate);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgIsState(IntPtr state);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateassignment"></param>
        /// <returns></returns>
        // CGDLL_API CGbool cgIsStateAssignment(CGstateassignment);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgIsStateAssignment(IntPtr stateassignment);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="technique"></param>
        /// <returns></returns>
        // CGDLL_API CGbool cgIsTechnique(CGtechnique);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgIsTechnique(IntPtr technique);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="technique"></param>
        /// <returns></returns>
        // CGDLL_API CGbool cgIsTechniqueValidated(CGtechnique);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgIsTechniqueValidated(IntPtr technique);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pass"></param>
        // CGDLL_API void cgResetPassState(CGpass);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgResetPassState(IntPtr pass);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="size"></param>
        // CGDLL_API void cgSetArraySize(CGparameter param, int size);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgSetArraySize(IntPtr param, int size);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="flag"></param>
        // CGDLL_API void cgSetAutoCompile(CGcontext context, CGenum flag);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgSetAutoCompile(IntPtr context, int flag);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="func"></param>
        // CGDLL_API void cgSetErrorCallback(CGerrorCallbackFunc func);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgSetErrorCallback(CGerrorCallbackFuncDelegate func);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="func"></param>
        /// <param name="data"></param>
        // CGDLL_API void cgSetErrorHandler(CGerrorHandlerFunc func, void *data);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgSetErrorHandler(CGerrorHandlerFuncDelegate func, IntPtr data);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="listing"></param>
        // CGDLL_API void cgSetLastListing(CGhandle handle, const char *listing);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgSetLastListing(IntPtr handle, string listing);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="matrix"></param>
        // CGDLL_API void cgSetMatrixParameterdc(CGparameter param, const double *matrix);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgSetMatrixParameterdc(IntPtr param, out double matrix);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="matrix"></param>
        // CGDLL_API void cgSetMatrixParameterdr(CGparameter param, const double *matrix);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgSetMatrixParameterdr(IntPtr param, out double matrix);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="matrix"></param>
        // CGDLL_API void cgSetMatrixParameterfc(CGparameter param, const float *matrix);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgSetMatrixParameterfc(IntPtr param, out float matrix);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="matrix"></param>
        // CGDLL_API void cgSetMatrixParameterfr(CGparameter param, const float *matrix);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgSetMatrixParameterfr(IntPtr param, out float matrix);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="matrix"></param>
        // CGDLL_API void cgSetMatrixParameteric(CGparameter param, const int *matrix);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgSetMatrixParameteric(IntPtr param, out int matrix);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="matrix"></param>
        // CGDLL_API void cgSetMatrixParameterir(CGparameter param, const int *matrix);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgSetMatrixParameterir(IntPtr param, out int matrix);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="sizes"></param>
        // CGDLL_API void cgSetMultiDimArraySize(CGparameter param, const int *sizes);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgSetMultiDimArraySize(IntPtr param, out int sizes);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="x"></param>
        // CGDLL_API void cgSetParameter1d(CGparameter param, double x);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameter1d(IntPtr param, double x);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="v"></param>
        // CGDLL_API void cgSetParameter1dv(CGparameter param, const double *v);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameter1dv(IntPtr param, out double v);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="x"></param>
        // CGDLL_API void cgSetParameter1f(CGparameter param, float x);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameter1f(IntPtr param, float x);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="v"></param>
        // CGDLL_API void cgSetParameter1fv(CGparameter param, const float *v);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameter1fv(IntPtr param, out float v);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="x"></param>
        // CGDLL_API void cgSetParameter1i(CGparameter param, int x);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameter1i(IntPtr param, int x);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="v"></param>
        // CGDLL_API void cgSetParameter1iv(CGparameter param, const int *v);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameter1iv(IntPtr param, out int v);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        // CGDLL_API void cgSetParameter2d(CGparameter param, double x, double y);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameter2d(IntPtr param, double x, double y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="v"></param>
        // CGDLL_API void cgSetParameter2dv(CGparameter param, const double *v);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameter2dv(IntPtr param, out double v);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        // CGDLL_API void cgSetParameter2f(CGparameter param, float x, float y);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameter2f(IntPtr param, float x, float y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="v"></param>
        // CGDLL_API void cgSetParameter2fv(CGparameter param, const float *v);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameter2fv(IntPtr param, out float v);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        // CGDLL_API void cgSetParameter2i(CGparameter param, int x, int y);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameter2i(IntPtr param, int x, int y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="v"></param>
        // CGDLL_API void cgSetParameter2iv(CGparameter param, const int *v);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameter2iv(IntPtr param, out int v);

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
        public static extern void cgSetParameter3d(IntPtr param, double x, double y, double z);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="v"></param>
        // CGDLL_API void cgSetParameter3dv(CGparameter param, const double *v);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameter3dv(IntPtr param, out double v);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        // CGDLL_API void cgSetParameter3f(CGparameter param, float x, float y, float z);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameter3f(IntPtr param, float x, float y, float z);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="v"></param>
        // CGDLL_API void cgSetParameter3fv(CGparameter param, const float *v);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameter3fv(IntPtr param, out float v);

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
        public static extern void cgSetParameter3i(IntPtr param, int x, int y, int z);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="v"></param>
        // CGDLL_API void cgSetParameter3iv(CGparameter param, const int *v);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameter3iv(IntPtr param, out int v);

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
        public static extern void cgSetParameter4d(IntPtr param, double x, double y, double z, double w);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="v"></param>
        // CGDLL_API void cgSetParameter4dv(CGparameter param, const double *v);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameter4dv(IntPtr param, out double v);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="w"></param>
        // CGDLL_API void cgSetParameter4f(CGparameter param, float x, float y, float z, float w);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameter4f(IntPtr param, float x, float y, float z, float w);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="v"></param>
        // CGDLL_API void cgSetParameter4fv(CGparameter param, const float *v);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameter4fv(IntPtr param, out float v);

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
        public static extern void cgSetParameter4i(IntPtr param, int x, int y, int z, int w);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="v"></param>
        // CGDLL_API void cgSetParameter4iv(CGparameter param, const int *v);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameter4iv(IntPtr param, out int v);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="semantic"></param>
        // CGDLL_API void cgSetParameterSemantic(CGparameter param, const char *semantic);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameterSemantic(IntPtr param, string semantic);

        //CG_API void CGENTRY cgSetParameterSettingMode(CGcontext context, CGenum parameterSettingMode);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameterSettingMode(IntPtr context, int parameterSettingMode);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="n"></param>
        /// <param name="vals"></param>
        // CGDLL_API void cgSetParameterValuedc(CGparameter param, int n, out double vals);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameterValuedc(IntPtr param, int n, double[] vals);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="n"></param>
        /// <param name="vals"></param>
        // CGDLL_API void cgSetParameterValuedr(CGparameter param, int n, const double *vals);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameterValuedr(IntPtr param, int n, double[] vals);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="n"></param>
        /// <param name="vals"></param>
        // CGDLL_API void cgSetParameterValuefc(CGparameter param, int n, const float *vals);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameterValuefc(IntPtr param, int n, float[] vals);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="n"></param>
        /// <param name="vals"></param>
        // CGDLL_API void cgSetParameterValuefr(CGparameter param, int n, const float *vals);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameterValuefr(IntPtr param, int n, float[] vals);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="n"></param>
        /// <param name="vals"></param>
        // CGDLL_API void cgSetParameterValueic(CGparameter param, int n, const int *vals);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameterValueic(IntPtr param, int n, int[] vals);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="n"></param>
        /// <param name="vals"></param>
        // CGDLL_API void cgSetParameterValueir(CGparameter param, int n, const int *vals);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameterValueir(IntPtr param, int n, int[] vals);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="vary"></param>
        // CGDLL_API void cgSetParameterVariability(CGparameter param, CGenum vary);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgSetParameterVariability(IntPtr param, int vary);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prog"></param>
        // CGDLL_API void cgSetPassProgramParameters(CGprogram);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgSetPassProgramParameters(IntPtr prog);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pass"></param>
        // CGDLL_API void cgSetPassState(CGpass);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgSetPassState(IntPtr pass);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prog"></param>
        /// <param name="profile"></param>
        // CGDLL_API void cgSetProgramProfile(CGprogram prog, CGprofile profile);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgSetProgramProfile(IntPtr prog, int profile);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        // CGDLL_API void cgSetSamplerState(CGparameter);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgSetSamplerState(IntPtr param);

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
        public static extern void cgSetStateCallbacks(IntPtr state, CGstatecallbackDelegate set, CGstatecallbackDelegate reset, CGstatecallbackDelegate validate);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="str"></param>
        // CGDLL_API void cgSetStringParameterValue(CGparameter param, const char *str);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgSetStringParameterValue(IntPtr param, string str);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="technique"></param>
        /// <returns></returns>
        // CGDLL_API CGbool cgValidateTechnique(CGtechnique);
        [DllImport(CgNativeLibrary, CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgValidateTechnique(IntPtr technique);

        #endregion Public Static Methods

        #region Private Static Methods

        /// <summary>
        ///    Returns an error description from the specified error enum value.
        /// </summary>
        /// <param name="error">Error enum value.</param>
        /// <returns>IntPtr that must be converted to Ansi string via Marshal.PtrToStringAnsi.</returns>
        //CGDLL_API const char *cgGetErrorString(CGerror error);
        [DllImport(CgNativeLibrary, CallingConvention = Convention, EntryPoint = "cgGetErrorString"),
        SuppressUnmanagedCodeSecurity]
        private static extern IntPtr cgGetErrorStringA(int error);

        /// <summary>
        ///     Gets the compiler output from the results of the most recent program compilation for the given Cg context.
        /// </summary>
        /// <param name="context">
        ///     Handle to the context to query.
        /// </param>
        /// <returns>
        ///     IntPtr that must be converted to a string with Marshal.PtrToStringAnsi.
        /// </returns>
        // CGDLL_API const char *cgGetLastListing(CGcontext context);
        [DllImport(CgNativeLibrary, CallingConvention = Convention, EntryPoint = "cgGetLastListing"),
        SuppressUnmanagedCodeSecurity]
        private static extern IntPtr cgGetLastListingA(IntPtr context);

        /// <summary>
        ///    Gets the name of the specified program.
        /// </summary>
        /// <param name="param">Handle to the program to query.</param>
        /// <returns>IntPtr that must be converted to an Ansi string via Marshal.PtrToStringAnsi.</returns>
        // CGDLL_API const char *cgGetParameterName(CGparameter param);
        [DllImport(CgNativeLibrary, CallingConvention = Convention, EntryPoint = "cgGetParameterName"),
        SuppressUnmanagedCodeSecurity]
        private static extern IntPtr cgGetParameterNameA(IntPtr param);

        [DllImport(CgNativeLibrary, CallingConvention = Convention, EntryPoint = "cgGetErrorString"),
        SuppressUnmanagedCodeSecurity]
        private static extern IntPtr cgGetParameterSemanticA(IntPtr param);

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
        [DllImport(CgNativeLibrary, CallingConvention = Convention, EntryPoint = "cgGetProgramString", CharSet = CharSet.Auto),
        SuppressUnmanagedCodeSecurity]
        private static extern IntPtr cgGetProgramStringA(IntPtr program, int sourceType);

        [DllImport(CgNativeLibrary, CallingConvention = Convention, EntryPoint = "cgGetErrorString"),
        SuppressUnmanagedCodeSecurity]
        private static extern IntPtr cgGetResourceStringA(int resource);

        [DllImport(CgNativeLibrary, EntryPoint = "cgGetString", CallingConvention = Convention),
        SuppressUnmanagedCodeSecurity]
        private static extern IntPtr _cgGetString(int sname);

        #endregion Private Static Methods

        #endregion Methods

        #region Other

        // --- Public Externs ---

        #endregion Other
    }
}