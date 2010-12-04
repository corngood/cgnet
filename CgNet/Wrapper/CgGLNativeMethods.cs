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
    ///     Binds functions and definitions in cgGL.dll or libcgGL.so.
    /// </remarks>
    internal static class CgGLNativeMethods
    {
        #region Fields

        /// <summary>
        /// Fragment profile (returned by cgGLGetLatestProfile)
        /// </summary>
        /// CG_GL_FRAGMENT = 9
        public const int CG_GL_FRAGMENT = 9;

        /// <summary>
        /// Geometry profile (returned by cgGLGetLatestProfile)
        /// </summary>
        /// CG_GL_GEOMETRY = 9
        public const int CG_GL_GEOMETRY = 10;

        /// <summary>
        /// Identity matrix.
        /// </summary>
        /// CG_GL_MATRIX_IDENTITY = 0
        public const int CG_GL_MATRIX_IDENTITY = 0;

        /// <summary>
        /// Inverse matrix.
        /// </summary>
        /// CG_GL_MATRIX_INVERSE = 2
        public const int CG_GL_MATRIX_INVERSE = 2;

        /// <summary>
        /// Inverse and transpose the matrix.
        /// </summary>
        /// CG_GL_MATRIX_INVERSE_TRANSPOSE = 3
        public const int CG_GL_MATRIX_INVERSE_TRANSPOSE = 3;

        /// <summary>
        /// Transpose matrix.
        /// </summary>
        /// CG_GL_MATRIX_TRANSPOSE = 1
        public const int CG_GL_MATRIX_TRANSPOSE = 1;

        /// <summary>
        /// Modelview matrix.
        /// </summary>
        /// CG_GL_MODELVIEW_MATRIX = 4
        public const int CG_GL_MODELVIEW_MATRIX = 4;

        /// <summary>
        /// Concatenated modelview and projection matrices.
        /// </summary>
        /// CG_GL_MATRIX_INVERSE_TRANSPOSE = 7
        public const int CG_GL_MODELVIEW_PROJECTION_MATRIX = 7;

        /// <summary>
        /// Projection matrix.
        /// </summary>
        /// CG_GL_PROJECTION_MATRIX = 5
        public const int CG_GL_PROJECTION_MATRIX = 5;

        /// <summary>
        /// Texture matrix.
        /// </summary>
        /// CG_GL_TEXTURE_MATRIX = 6
        public const int CG_GL_TEXTURE_MATRIX = 6;

        /// <summary>
        /// Vertex profile (returned by cgGLGetLatestProfile)
        /// </summary>
        /// CG_GL_VERTEX = 8
        public const int CG_GL_VERTEX = 8;

        /// <summary>
        ///     Specifies the calling convention.
        /// </summary>
        /// <remarks>
        ///     Specifies <see cref="CallingConvention.Cdecl" /> for Windows and Linux.
        /// </remarks>
        private const CallingConvention CALLING_CONVENTION = CallingConvention.Cdecl;

        /// <summary>
        ///     Specifies CGGL's native library archive.
        /// </summary>
        /// <remarks>
        ///     Specifies cgGL.dll everywhere; will be mapped via .config for mono.
        /// </remarks>
        private const string CGGL_NATIVE_LIBRARY = "cgGL.dll";

        #endregion Fields

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Bind the program to the current OpenGL API state.
        /// </summary>
        /// <param name="program">
        /// Handle to the program to bind.
        /// </param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLBindProgram(IntPtr program);

        /// <summary>
        ///     Disables a vertex attribute in OpenGL state.
        /// </summary>
        /// <param name="param">Parameter to disable.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLDisableClientState(IntPtr param);

        /// <summary>
        /// Disables the selected profile.
        /// </summary>
        /// <param name="profile">
        /// Profile to disable.
        /// </param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLDisableProfile(int profile);

        /// <summary>
        /// Disables the texture unit associated with the given texture parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLDisableTextureParameter(IntPtr param);

        /// <summary>
        ///     Enables a vertex attribute in OpenGL state.
        /// </summary>
        /// <param name="param">Parameter to enable.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLEnableClientState(IntPtr param);

        /// <summary>
        /// Enables the selected profile.
        /// </summary>
        /// <param name="profile">
        /// Profile to enable.
        /// </param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLEnableProfile(int profile);

        /// <summary>
        /// Enables (binds) the texture unit associated with the given texture parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLEnableTextureParameter(IntPtr param);

        /// <summary>
        /// Returns the best profile available.
        /// </summary>
        /// <param name="profile_type">
        /// CG_GL_VERTEX or CG_GL_FRAGMENT program to look for the best matching profile.
        /// </param>
        /// <returns>
        /// Returns the best profile available.
        /// </returns>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgGLGetLatestProfile(int profile_type);

        /// <summary>
        /// Retreives the manage texture parameters flag from a context 
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgGLGetManageTextureParameters(IntPtr context);

        /// <summary>
        /// Gets an array matrix parameters (double) in column order.
        /// </summary>
        /// <param name="param">Parameter to get data from.</param>
        /// <param name="offset">An offset into the array parameter to start getting from.</param>
        /// <param name="nelements">The number of elements to get. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values retreived from parameter.. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLGetMatrixParameterArraydc(IntPtr param, long offset, long nelements, [Out] double* matrices);

        /// <summary>
        /// Gets an array matrix parameters (double) in column order.
        /// </summary>
        /// <param name="param">Parameter to get data from.</param>
        /// <param name="offset">An offset into the array parameter to start getting from.</param>
        /// <param name="nelements">The number of elements to get. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values retreived from parameter.. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetMatrixParameterArraydc(IntPtr param, long offset, long nelements, [Out] double[] matrices);

        /// <summary>
        /// Gets an array matrix parameters (double) in column order.
        /// </summary>
        /// <param name="param">Parameter to get data from.</param>
        /// <param name="offset">An offset into the array parameter to start getting from.</param>
        /// <param name="nelements">The number of elements to get. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values retreived from parameter.. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetMatrixParameterArraydc(IntPtr param, long offset, long nelements, [Out] IntPtr matrices);

        /// <summary>
        /// Gets an array matrix parameters (double) in row order.
        /// </summary>
        /// <param name="param">Parameter to get data from.</param>
        /// <param name="offset">An offset into the array parameter to start getting from.</param>
        /// <param name="nelements">The number of elements to get. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values retreived from parameter.. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLGetMatrixParameterArraydr(IntPtr param, long offset, long nelements, [Out] double* matrices);

        /// <summary>
        /// Gets an array matrix parameters (double) in row order.
        /// </summary>
        /// <param name="param">Parameter to get data from.</param>
        /// <param name="offset">An offset into the array parameter to start getting from.</param>
        /// <param name="nelements">The number of elements to get. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values retreived from parameter.. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetMatrixParameterArraydr(IntPtr param, long offset, long nelements, [Out] double[] matrices);

        /// <summary>
        /// Gets an array matrix parameters (double) in row order.
        /// </summary>
        /// <param name="param">Parameter to get data from.</param>
        /// <param name="offset">An offset into the array parameter to start getting from.</param>
        /// <param name="nelements">The number of elements to get. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values retreived from parameter.. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetMatrixParameterArraydr(IntPtr param, long offset, long nelements, [Out] IntPtr matrices);

        /// <summary>
        /// Gets an array matrix parameters (float) in column order.
        /// </summary>
        /// <param name="param">Parameter to get data from.</param>
        /// <param name="offset">An offset into the array parameter to start getting from.</param>
        /// <param name="nelements">The number of elements to get. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values retreived from parameter.. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLGetMatrixParameterArrayfc(IntPtr param, long offset, long nelements, [Out] float* matrices);

        /// <summary>
        /// Gets an array matrix parameters (float) in column order.
        /// </summary>
        /// <param name="param">Parameter to get data from.</param>
        /// <param name="offset">An offset into the array parameter to start getting from.</param>
        /// <param name="nelements">The number of elements to get. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values retreived from parameter.. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetMatrixParameterArrayfc(IntPtr param, long offset, long nelements, [Out] float[] matrices);

        /// <summary>
        /// Gets an array matrix parameters (float) in column order.
        /// </summary>
        /// <param name="param">Parameter to get data from.</param>
        /// <param name="offset">An offset into the array parameter to start getting from.</param>
        /// <param name="nelements">The number of elements to get. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values retreived from parameter.. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetMatrixParameterArrayfc(IntPtr param, long offset, long nelements, [Out] IntPtr matrices);

        /// <summary>
        /// Gets an array matrix parameters (float) in row order.
        /// </summary>
        /// <param name="param">Parameter to get data from.</param>
        /// <param name="offset">An offset into the array parameter to start getting from.</param>
        /// <param name="nelements">The number of elements to get. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values retreived from parameter.. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLGetMatrixParameterArrayfr(IntPtr param, long offset, long nelements, [Out] float* matrices);

        /// <summary>
        /// Gets an array matrix parameters (float) in row order.
        /// </summary>
        /// <param name="param">Parameter to get data from.</param>
        /// <param name="offset">An offset into the array parameter to start getting from.</param>
        /// <param name="nelements">The number of elements to get. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values retreived from parameter.. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetMatrixParameterArrayfr(IntPtr param, long offset, long nelements, [Out] float[] matrices);

        /// <summary>
        /// Gets an array matrix parameters (float) in row order.
        /// </summary>
        /// <param name="param">Parameter to get data from.</param>
        /// <param name="offset">An offset into the array parameter to start getting from.</param>
        /// <param name="nelements">The number of elements to get. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values retreived from parameter.. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetMatrixParameterArrayfr(IntPtr param, long offset, long nelements, [Out] IntPtr matrices);

        /// <summary>
        /// Gets the value of matrix parameters in column order.
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLGetMatrixParameterdc(IntPtr param, [In] double* matrix);

        /// <summary>
        /// Gets the value of matrix parameters in column order.
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetMatrixParameterdc(IntPtr param, [In] double[] matrix);

        /// <summary>
        /// Gets the value of matrix parameters in column order.
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetMatrixParameterdc(IntPtr param, [In] IntPtr matrix);

        /// <summary>
        /// Gets the value of matrix parameters in row order.
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLGetMatrixParameterdr(IntPtr param, [In] double* matrix);

        /// <summary>
        /// Gets the value of matrix parameters in row order.
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetMatrixParameterdr(IntPtr param, [In] double[] matrix);

        /// <summary>
        /// Gets the value of matrix parameters in row order.
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetMatrixParameterdr(IntPtr param, [In] IntPtr matrix);

        /// <summary>
        /// Gets the value of matrix parameters in row order.
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLGetMatrixParameterdr(IntPtr param, [In] float* matrix);

        /// <summary>
        /// Gets the value of matrix parameters in column order.
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLGetMatrixParameterfc(IntPtr param, [In] float* matrix);

        /// <summary>
        /// Gets the value of matrix parameters in column order.
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetMatrixParameterfc(IntPtr param, [In] float[] matrix);

        /// <summary>
        /// Gets the value of matrix parameters in column order.
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetMatrixParameterfc(IntPtr param, [In] IntPtr matrix);

        /// <summary>
        /// Gets the value of matrix parameters in row order.
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetMatrixParameterfr(IntPtr param, [In] float[] matrix);

        /// <summary>
        /// Gets the value of matrix parameters in row order.
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetMatrixParameterfr(IntPtr param, [In] IntPtr matrix);

        /// <summary>
        /// Gets the double value to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLGetParameter1d(IntPtr param, [Out] double* values);

        /// <summary>
        /// Gets the double value to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameter1d(IntPtr param, [Out] double[] values);

        /// <summary>
        /// Gets the double value to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameter1d(IntPtr param, [Out] IntPtr values);

        /// <summary>
        /// Gets the float value to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLGetParameter1f(IntPtr param, [Out] float* values);

        /// <summary>
        /// Gets the float value to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameter1f(IntPtr param, [Out] float[] values);

        /// <summary>
        /// Gets the float value to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameter1f(IntPtr param, [Out] IntPtr values);

        /// <summary>
        /// Gets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLGetParameter2d(IntPtr param, [Out] double* values);

        /// <summary>
        /// Gets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameter2d(IntPtr param, [Out] double[] values);

        /// <summary>
        /// Gets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameter2d(IntPtr param, [Out] IntPtr values);

        /// <summary>
        /// Gets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLGetParameter2f(IntPtr param, [Out] float* values);

        /// <summary>
        /// Gets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameter2f(IntPtr param, [Out] float[] values);

        /// <summary>
        /// Gets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameter2f(IntPtr param, [Out] IntPtr values);

        /// <summary>
        /// Gets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLGetParameter3d(IntPtr param, [Out] double* values);

        /// <summary>
        /// Gets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameter3d(IntPtr param, [Out] double[] values);

        /// <summary>
        /// Gets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameter3d(IntPtr param, [Out] IntPtr values);

        /// <summary>
        /// Gets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLGetParameter3f(IntPtr param, [Out] float* values);

        /// <summary>
        /// Gets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameter3f(IntPtr param, [Out] float[] values);

        /// <summary>
        /// Gets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameter3f(IntPtr param, [Out] IntPtr values);

        /// <summary>
        /// Gets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLGetParameter4d(IntPtr param, [Out] double* values);

        /// <summary>
        /// Gets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameter4d(IntPtr param, [Out] double[] values);

        /// <summary>
        /// Gets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameter4d(IntPtr param, [Out] IntPtr values);

        /// <summary>
        /// Gets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLGetParameter4f(IntPtr param, [Out] float* values);

        /// <summary>
        /// Gets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameter4f(IntPtr param, [Out] float[] values);

        /// <summary>
        /// Gets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameter4f(IntPtr param, [Out] IntPtr values);

        /// <summary>
        /// Gets the double values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLGetParameterArray1d(IntPtr param, long offset, long nelements, [Out] double* values);

        /// <summary>
        /// Gets the double values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameterArray1d(IntPtr param, long offset, long nelements, [Out] double[] values);

        /// <summary>
        /// Gets the double values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameterArray1d(IntPtr param, long offset, long nelements, [Out] IntPtr values);

        /// <summary>
        /// Gets the float values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLGetParameterArray1f(IntPtr param, long offset, long nelements, [Out] float* values);

        /// <summary>
        /// Gets the float values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameterArray1f(IntPtr param, long offset, long nelements, [Out] float[] values);

        /// <summary>
        /// Gets the float values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameterArray1f(IntPtr param, long offset, long nelements, [Out] IntPtr values);

        /// <summary>
        /// Gets the double values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLGetParameterArray2d(IntPtr param, long offset, long nelements, [Out] double* values);

        /// <summary>
        /// Gets the double values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameterArray2d(IntPtr param, long offset, long nelements, [Out] double[] values);

        /// <summary>
        /// Gets the double values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameterArray2d(IntPtr param, long offset, long nelements, [Out] IntPtr values);

        /// <summary>
        /// Gets the float values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLGetParameterArray2f(IntPtr param, long offset, long nelements, [Out] float* values);

        /// <summary>
        /// Gets the float values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameterArray2f(IntPtr param, long offset, long nelements, [Out] float[] values);

        /// <summary>
        /// Gets the float values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameterArray2f(IntPtr param, long offset, long nelements, [Out] IntPtr values);

        /// <summary>
        /// Gets the double values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLGetParameterArray3d(IntPtr param, long offset, long nelements, [Out] double* values);

        /// <summary>
        /// Gets the double values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameterArray3d(IntPtr param, long offset, long nelements, [Out] double[] values);

        /// <summary>
        /// Gets the double values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameterArray3d(IntPtr param, long offset, long nelements, [Out] IntPtr values);

        /// <summary>
        /// Gets the float values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLGetParameterArray3f(IntPtr param, long offset, long nelements, [Out] float* values);

        /// <summary>
        /// Gets the float values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameterArray3f(IntPtr param, long offset, long nelements, [Out] float[] values);

        /// <summary>
        /// Gets the float values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameterArray3f(IntPtr param, long offset, long nelements, [Out] IntPtr values);

        /// <summary>
        /// Gets the double values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLGetParameterArray4d(IntPtr param, long offset, long nelements, [Out] double* values);

        /// <summary>
        /// Gets the double values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameterArray4d(IntPtr param, long offset, long nelements, [Out] double[] values);

        /// <summary>
        /// Gets the double values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameterArray4d(IntPtr param, long offset, long nelements, [Out] IntPtr values);

        /// <summary>
        /// Gets the float values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLGetParameterArray4f(IntPtr param, long offset, long nelements, [Out] float* values);

        /// <summary>
        /// Gets the float values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameterArray4f(IntPtr param, long offset, long nelements, [Out] float[] values);

        /// <summary>
        /// Gets the float values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameterArray4f(IntPtr param, long offset, long nelements, [Out] IntPtr values);

        /// <summary>
        /// Returns the program's ID.
        /// </summary>
        /// <param name="program">
        /// Handle to the program.
        /// </param>
        /// <returns>
        /// Program's ID.
        /// </returns>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgGLGetProgramID(IntPtr program);

        /// <summary>
        /// Retreives the OpenGL enumeration for the texture unit associated with the texture parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// It can be one of the GL_TEXTURE#_ARB if valid.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgGLGetTextureEnum(IntPtr param);

        /// <summary>
        /// Retreives the value of a texture parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int cgGLGetTextureParameter(IntPtr param);

        /// <summary>
        /// Checks if the profile is supported.
        /// </summary>
        /// <param name="profile">
        /// The profile to check the support of.
        /// </param>
        /// <returns>
        /// Returns true if the profile is supported.
        /// </returns>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern bool cgGLIsProfileSupported(int profile);

        /// <summary>
        /// Returns true if the specified program is loaded.
        /// </summary>
        /// <param name="program">
        /// Handle to the program.
        /// </param>
        /// <returns>
        /// True if the specified program is loaded.
        /// </returns>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern bool cgGLIsProgramLoaded(IntPtr program);

        /// <summary>
        /// Loads program to OpenGL pipeline
        /// </summary>
        /// <param name="program">
        /// Handle to the program to load.
        /// </param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLLoadProgram(IntPtr program);

        /// <summary>
        ///  
        /// </summary>
        // CGGLDLL_API void cgGLRegisterStates(CGcontext);
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLRegisterStates(IntPtr context);

        /// <summary>
        /// Enables or disables the automatic texture management for the given rendering context.
        /// <remarks>
        /// Use CG_TRUE or CG_FALSE to enable/disable automatic texture management.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetManageTextureParameters(IntPtr context, bool flag);

        /// <summary>
        /// Sets an array matrix parameters (double) in column order.
        /// </summary>
        /// <param name="param">Parameter to be set.</param>
        /// <param name="offset">An offset into the array parameter to start setting from.</param>
        /// <param name="nelements">The number of elements to set. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values to set the parameter to. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLSetMatrixParameterArraydc(IntPtr param, long offset, long nelements, [In] double* matrices);

        /// <summary>
        /// Sets an array matrix parameters (double) in column order.
        /// </summary>
        /// <param name="param">Parameter to be set.</param>
        /// <param name="offset">An offset into the array parameter to start setting from.</param>
        /// <param name="nelements">The number of elements to set. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values to set the parameter to. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetMatrixParameterArraydc(IntPtr param, long offset, long nelements, [In] double[] matrices);

        /// <summary>
        /// Sets an array matrix parameters (double) in column order.
        /// </summary>
        /// <param name="param">Parameter to be set.</param>
        /// <param name="offset">An offset into the array parameter to start setting from.</param>
        /// <param name="nelements">The number of elements to set. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values to set the parameter to. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetMatrixParameterArraydc(IntPtr param, long offset, long nelements, [In] IntPtr matrices);

        /// <summary>
        /// Sets an array matrix parameters (double) in row order.
        /// </summary>
        /// <param name="param">Parameter to be set.</param>
        /// <param name="offset">An offset into the array parameter to start setting from.</param>
        /// <param name="nelements">The number of elements to set. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values to set the parameter to. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLSetMatrixParameterArraydr(IntPtr param, long offset, long nelements, [In] double* matrices);

        /// <summary>
        /// Sets an array matrix parameters (double) in row order.
        /// </summary>
        /// <param name="param">Parameter to be set.</param>
        /// <param name="offset">An offset into the array parameter to start setting from.</param>
        /// <param name="nelements">The number of elements to set. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values to set the parameter to. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetMatrixParameterArraydr(IntPtr param, long offset, long nelements, [In] double[] matrices);

        /// <summary>
        /// Sets an array matrix parameters (double) in row order.
        /// </summary>
        /// <param name="param">Parameter to be set.</param>
        /// <param name="offset">An offset into the array parameter to start setting from.</param>
        /// <param name="nelements">The number of elements to set. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values to set the parameter to. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetMatrixParameterArraydr(IntPtr param, long offset, long nelements, [In] IntPtr matrices);

        /// <summary>
        /// Sets an array matrix parameters (float) in column order.
        /// </summary>
        /// <param name="param">Parameter to be set.</param>
        /// <param name="offset">An offset into the array parameter to start setting from.</param>
        /// <param name="nelements">The number of elements to set. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values to set the parameter to. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLSetMatrixParameterArrayfc(IntPtr param, long offset, long nelements, [In] float* matrices);

        /// <summary>
        /// Sets an array matrix parameters (float) in column order.
        /// </summary>
        /// <param name="param">Parameter to be set.</param>
        /// <param name="offset">An offset into the array parameter to start setting from.</param>
        /// <param name="nelements">The number of elements to set. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values to set the parameter to. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetMatrixParameterArrayfc(IntPtr param, long offset, long nelements, [In] float[] matrices);

        /// <summary>
        /// Sets an array matrix parameters (float) in column order.
        /// </summary>
        /// <param name="param">Parameter to be set.</param>
        /// <param name="offset">An offset into the array parameter to start setting from.</param>
        /// <param name="nelements">The number of elements to set. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values to set the parameter to. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetMatrixParameterArrayfc(IntPtr param, long offset, long nelements, [In] IntPtr matrices);

        /// <summary>
        /// Sets an array matrix parameters (float) in row order.
        /// </summary>
        /// <param name="param">Parameter to be set.</param>
        /// <param name="offset">An offset into the array parameter to start setting from.</param>
        /// <param name="nelements">The number of elements to set. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values to set the parameter to. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLSetMatrixParameterArrayfr(IntPtr param, long offset, long nelements, [In] float* matrices);

        /// <summary>
        /// Sets an array matrix parameters (float) in row order.
        /// </summary>
        /// <param name="param">Parameter to be set.</param>
        /// <param name="offset">An offset into the array parameter to start setting from.</param>
        /// <param name="nelements">The number of elements to set. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values to set the parameter to. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetMatrixParameterArrayfr(IntPtr param, long offset, long nelements, [In] float[] matrices);

        /// <summary>
        /// Sets an array matrix parameters (float) in row order.
        /// </summary>
        /// <param name="param">Parameter to be set.</param>
        /// <param name="offset">An offset into the array parameter to start setting from.</param>
        /// <param name="nelements">The number of elements to set. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values to set the parameter to. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetMatrixParameterArrayfr(IntPtr param, long offset, long nelements, [In] IntPtr matrices);

        /// <summary>
        /// Sets the value of matrix parameters in column  order.
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLSetMatrixParameterdc(IntPtr param, [In] double* matrix);

        /// <summary>
        /// Sets the value of matrix parameters in column  order.
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetMatrixParameterdc(IntPtr param, [In] double[] matrix);

        /// <summary>
        /// Sets the value of matrix parameters in column  order.
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetMatrixParameterdc(IntPtr param, [In] IntPtr matrix);

        /// <summary>
        /// Sets the value of matrix parameters in row order.
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLSetMatrixParameterdr(IntPtr param, [In] double* matrix);

        /// <summary>
        /// Sets the value of matrix parameters in row order.
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetMatrixParameterdr(IntPtr param, [In] double[] matrix);

        /// <summary>
        /// Sets the value of matrix parameters in row order.
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetMatrixParameterdr(IntPtr param, [In] IntPtr matrix);

        /// <summary>
        /// Sets the value of matrix parameters in row order.
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLSetMatrixParameterdr(IntPtr param, [In] float* matrix);

        /// <summary>
        /// Sets the value of matrix parameters in column  order.
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLSetMatrixParameterfc(IntPtr param, [In] float* matrix);

        /// <summary>
        /// Sets the value of matrix parameters in column  order.
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetMatrixParameterfc(IntPtr param, [In] float[] matrix);

        /// <summary>
        /// Sets the value of matrix parameters in column  order.
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetMatrixParameterfc(IntPtr param, [In] IntPtr matrix);

        /// <summary>
        /// Sets the value of matrix parameters in row order.
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetMatrixParameterfr(IntPtr param, [In] float[] matrix);

        /// <summary>
        /// Sets the value of matrix parameters in row order.
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetMatrixParameterfr(IntPtr param, [In] IntPtr matrix);

        /// <summary>
        /// Sets the best compiler options available by card, driver and selected profile.
        /// </summary>
        /// <param name="profile">
        /// Profile.
        /// </param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetOptimalOptions(int profile);

        /// <summary>
        /// Sets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameter1d(IntPtr param, double x);

        /// <summary>
        /// Sets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLSetParameter1dv(IntPtr param, [In] double* values);

        /// <summary>
        /// Sets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameter1dv(IntPtr param, [In] double[] values);

        /// <summary>
        /// Sets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameter1dv(IntPtr param, [In] IntPtr values);

        /// <summary>
        /// Sets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameter1f(IntPtr param, float x);

        /// <summary>
        /// Sets the float value to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLSetParameter1fv(IntPtr param, [In] float* values);

        /// <summary>
        /// Sets the float value to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameter1fv(IntPtr param, [In] float[] values);

        /// <summary>
        /// Sets the float value to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameter1fv(IntPtr param, [In] IntPtr values);

        /// <summary>
        /// Sets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameter2d(IntPtr param, double x, double y);

        /// <summary>
        /// Sets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLSetParameter2dv(IntPtr param, [In] double* values);

        /// <summary>
        /// Sets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameter2dv(IntPtr param, [In] double[] values);

        /// <summary>
        /// Sets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameter2dv(IntPtr param, [In] IntPtr values);

        /// <summary>
        /// Sets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameter2f(IntPtr param, float x, float y);

        /// <summary>
        /// Sets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLSetParameter2fv(IntPtr param, [In] float* values);

        /// <summary>
        /// Sets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameter2fv(IntPtr param, [In] float[] values);

        /// <summary>
        /// Sets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameter2fv(IntPtr param, [In] IntPtr values);

        /// <summary>
        /// Sets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameter3d(IntPtr param, double x, double y, double z);

        /// <summary>
        /// Sets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLSetParameter3dv(IntPtr param, [In] double* values);

        /// <summary>
        /// Sets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameter3dv(IntPtr param, [In] double[] values);

        /// <summary>
        /// Sets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameter3dv(IntPtr param, [In] IntPtr values);

        /// <summary>
        /// Sets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameter3f(IntPtr param, float x, float y, float z);

        /// <summary>
        /// Sets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLSetParameter3fv(IntPtr param, [In] float* values);

        /// <summary>
        /// Sets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameter3fv(IntPtr param, [In] float[] values);

        /// <summary>
        /// Sets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameter3fv(IntPtr param, [In] IntPtr values);

        /// <summary>
        /// Sets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameter4d(IntPtr param, double x, double y, double z, double w);

        /// <summary>
        /// Sets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLSetParameter4dv(IntPtr param, [In] double* values);

        /// <summary>
        /// Sets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameter4dv(IntPtr param, [In] double[] values);

        /// <summary>
        /// Sets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameter4dv(IntPtr param, [In] IntPtr values);

        /// <summary>
        /// Sets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameter4f(IntPtr param, float x, float y, float z, float w);

        /// <summary>
        /// Sets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLSetParameter4fv(IntPtr param, [In] float* values);

        /// <summary>
        /// Sets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameter4fv(IntPtr param, [In] float[] values);

        /// <summary>
        /// Sets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameter4fv(IntPtr param, [In] IntPtr values);

        /// <summary>
        /// Sets the double values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLSetParameterArray1d(IntPtr param, long offset, long nelements, [In] double* values);

        /// <summary>
        /// Sets the double values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameterArray1d(IntPtr param, long offset, long nelements, [In] double[] values);

        /// <summary>
        /// Sets the double values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameterArray1d(IntPtr param, long offset, long nelements, [In] IntPtr values);

        /// <summary>
        /// Sets the float values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLSetParameterArray1f(IntPtr param, long offset, long nelements, [In] float* values);

        /// <summary>
        /// Sets the float values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameterArray1f(IntPtr param, long offset, long nelements, [In] float[] values);

        /// <summary>
        /// Sets the float values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameterArray1f(IntPtr param, long offset, long nelements, [In] IntPtr values);

        /// <summary>
        /// Sets the double values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLSetParameterArray2d(IntPtr param, long offset, long nelements, [In] double* values);

        /// <summary>
        /// Sets the double values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameterArray2d(IntPtr param, long offset, long nelements, [In] double[] values);

        /// <summary>
        /// Sets the double values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameterArray2d(IntPtr param, long offset, long nelements, [In] IntPtr values);

        /// <summary>
        /// Sets the float values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLSetParameterArray2f(IntPtr param, long offset, long nelements, [In] float* values);

        /// <summary>
        /// Sets the float values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameterArray2f(IntPtr param, long offset, long nelements, [In] float[] values);

        /// <summary>
        /// Sets the float values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameterArray2f(IntPtr param, long offset, long nelements, [In] IntPtr values);

        /// <summary>
        /// Sets the double values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLSetParameterArray3d(IntPtr param, long offset, long nelements, [In] double* values);

        /// <summary>
        /// Sets the double values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameterArray3d(IntPtr param, long offset, long nelements, [In] double[] values);

        /// <summary>
        /// Sets the double values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameterArray3d(IntPtr param, long offset, long nelements, [In] IntPtr values);

        /// <summary>
        /// Sets the float values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLSetParameterArray3f(IntPtr param, long offset, long nelements, [In] float* values);

        /// <summary>
        /// Sets the float values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameterArray3f(IntPtr param, long offset, long nelements, [In] float[] values);

        /// <summary>
        /// Sets the float values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameterArray3f(IntPtr param, long offset, long nelements, [In] IntPtr values);

        /// <summary>
        /// Sets the double values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLSetParameterArray4d(IntPtr param, long offset, long nelements, [In] double* values);

        /// <summary>
        /// Sets the double values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameterArray4d(IntPtr param, long offset, long nelements, [In] double[] values);

        /// <summary>
        /// Sets the double values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameterArray4d(IntPtr param, long offset, long nelements, [In] IntPtr values);

        /// <summary>
        /// Sets the float values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLSetParameterArray4f(IntPtr param, long offset, long nelements, [In] float* values);

        /// <summary>
        /// Sets the float values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameterArray4f(IntPtr param, long offset, long nelements, [In] float[] values);

        /// <summary>
        /// Sets the float values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameterArray4f(IntPtr param, long offset, long nelements, [In] IntPtr values);

        /// <summary>
        /// Sets parameter with attribute array.
        /// </summary>
        /// <param name="param">Parameter to be set.</param>
        /// <param name="fsize">Number of coordinates per vertex.</param>
        /// <param name="type">Data type of each coordinate.</param>
        /// <param name="stride">Specifies the byte offset between consecutive vertices. If stride is 0 the array is assumed to be tightly packed.</param>
        /// <param name="pointer">The pointer to the first coordinate in the vertex array.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        CLSCompliant(false),
        SuppressUnmanagedCodeSecurity]
        public static unsafe extern void cgGLSetParameterPointer(IntPtr param, int fsize, int type, int stride, [In] void* pointer);

        /// <summary>
        /// Sets parameter with attribute array.
        /// </summary>
        /// <param name="param">Parameter to be set.</param>
        /// <param name="fsize">Number of coordinates per vertex.</param>
        /// <param name="type">Data type of each coordinate.</param>
        /// <param name="stride">Specifies the byte offset between consecutive vertices. If stride is 0 the array is assumed to be tightly packed.</param>
        /// <param name="pointer">The pointer to the first coordinate in the vertex array.</param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameterPointer(IntPtr param, int fsize, int type, int stride, [In] IntPtr pointer);

        /// <summary>
        /// Sets the values of the parameter to a matrix in the OpenGL state.
        /// </summary>
        /// <param name="param">
        /// Parameter that will be set.
        /// </param>
        /// <param name="matrix">
        /// Which matrix should be retreived from the OpenGL state.
        /// </param>
        /// <param name="transform">
        /// Optional transformation that will be aplied to the OpenGL state matrix before it is retreived to the parameter.
        /// </param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetStateMatrixParameter(IntPtr param, int matrix, int transform);

        /// <summary>
        /// Sets texture object to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetTextureParameter(IntPtr param, int texobj);

        /// <summary>
        ///  
        /// </summary>
        // CGGLDLL_API void cgGLSetupSampler(CGparameter param, GLuint texobj);
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetupSampler(IntPtr param, int texobj);

        /// <summary>
        /// Unbinds the program bound in a profile.
        /// </summary>
        /// <param name="profile">
        /// Handle to the profile to unbind programs from.
        /// </param>
        [DllImport(CGGL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void cgGLUnbindProgram(int profile);

        #endregion Public Static Methods

        #endregion Methods

        #region Other

        // --- Public Externs ---

        #endregion Other
    }
}