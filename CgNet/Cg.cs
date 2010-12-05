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
    using System.Runtime.InteropServices;

    using CgNet.Wrapper;

    public static class Cg
    {
        #region Methods

        #region Public Static Methods

        public static void AddStateEnumerant(IntPtr state, string name, int value)
        {
            CgNativeMethods.cgAddStateEnumerant(state, name, value);
        }

        public static bool CallStateResetCallback(IntPtr stateassignment)
        {
            return CgNativeMethods.cgCallStateResetCallback(stateassignment) == CgNativeMethods.CgTrue;
        }

        public static bool CallStateSetCallback(IntPtr stateassignment)
        {
            return CgNativeMethods.cgCallStateSetCallback(stateassignment) == CgNativeMethods.CgTrue;
        }

        public static bool CallStateValidateCallback(IntPtr stateassignment)
        {
            return CgNativeMethods.cgCallStateValidateCallback(stateassignment) == CgNativeMethods.CgTrue;
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
            return CgNativeMethods.cgCreateProgram(context, (int)type, source, profile, entry, args);
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

        public static string GetErrorString(CgError error)
        {
            return Marshal.PtrToStringAnsi(CgNativeMethods.cgGetErrorString(error));
        }

        public static IntPtr GetFirstProgramAnnotation(IntPtr prog)
        {
            return CgNativeMethods.cgGetFirstProgramAnnotation(prog);
        }

        public static string GetLastErrorString(out CgError error)
        {
            return Marshal.PtrToStringAnsi(CgNativeMethods.cgGetLastErrorString(out error));
        }

        public static string GetLastListing(IntPtr context)
        {
            return Marshal.PtrToStringAnsi(CgNativeMethods.cgGetLastListing(context));
        }

        public static IntPtr GetNamedParameter(IntPtr program, string parameter)
        {
            return CgNativeMethods.cgGetNamedParameter(program, parameter);
        }

        public static CgProfile GetProfile(string profile)
        {
            return CgNativeMethods.cgGetProfile(profile);
        }

        public static string GetProfileString(CgProfile profile)
        {
            return Marshal.PtrToStringAnsi(CgNativeMethods.cgGetProfileString(profile));
        }

        public static void SetMatrixParameter(IntPtr param, float[] matrix)
        {
            CgNativeMethods.cgSetMatrixParameterfr(param, matrix);
        }

        public static void SetMatrixParameterColumnMajor(IntPtr param, float[] matrix)
        {
            CgNativeMethods.cgSetMatrixParameterfc(param, matrix);
        }

        public static void SetParameter(IntPtr param, float x)
        {
            CgNativeMethods.cgSetParameter1f(param, x);
        }

        public static void SetParameter(IntPtr param, float x, float y, float z)
        {
            CgNativeMethods.cgSetParameter3f(param, x, y, z);
        }

        public static void SetParameter(IntPtr param, float[] f)
        {
            CgNativeMethods.cgSetParameter3fv(param, f);
        }

        public static void SetParameter(IntPtr param, float x, float y)
        {
            CgNativeMethods.cgSetParameter2f(param, x, y);
        }

        public static void SetParameter(IntPtr param, float x, float y, float z, float w)
        {
            CgNativeMethods.cgSetParameter4f(param, x, y, z, w);
        }

        public static void SetParameterSettingMode(IntPtr context, ParameterSettingMode parameterSettingMode)
        {
            CgNativeMethods.cgSetParameterSettingMode(context, parameterSettingMode);
        }

        public static void SetProgramProfile(IntPtr prog, CgProfile profile)
        {
            CgNativeMethods.cgSetProgramProfile(prog, profile);
        }

        public static void UpdateProgramParameters(IntPtr program)
        {
            CgNativeMethods.cgUpdateProgramParameters(program);
        }

        #endregion Public Static Methods

        #endregion Methods
    }
}