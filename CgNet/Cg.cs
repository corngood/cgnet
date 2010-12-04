namespace CGNet
{
    using System;

    using CGNet.Wrapper;

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
            return CgNativeMethods.cgCreateArraySamplerState(context, name, (int)type, elementCount);
        }

        public static IntPtr CreateArrayState(IntPtr context, string name, CgType type, int elementCount)
        {
            return CgNativeMethods.cgCreateArrayState(context, name, (int)type, elementCount);
        }

        public static IntPtr CreateProgramFromEffect(IntPtr effect, int profile, string entry, params string[] args)
        {
            return CgNativeMethods.cgCreateProgramFromEffect(effect, profile, entry, args);
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
            return CgNativeMethods.cgCreateParameter(context, (int)type);
        }

        public static IntPtr CreateParameterArray(IntPtr context, CgType type, int length)
        {
            return CgNativeMethods.cgCreateParameterArray(context, (int)type, length);
        }

        public static IntPtr CreateParameterMultiDimArray(IntPtr context, CgType type, int dim, out int lengths)
        {
            return CgNativeMethods.cgCreateParameterMultiDimArray(context, (int)type, dim, out lengths);
        }

        public static IntPtr CreateProgram(IntPtr context, ProgramType type, string source, int profile, string entry, params string[] args)
        {
            return CgNativeMethods.cgCreateProgram(context, (int)type, source, profile, entry, args);
        }

        public static IntPtr CreateProgramFromFile(IntPtr context, ProgramType type, string file, int profile, string entry, params string[] args)
        {
            return CgNativeMethods.cgCreateProgramFromFile(context, (int)type, file, profile, entry, args);
        }

        public static void SetParameterSettingMode(IntPtr context, ParameterSettingMode parameterSettingMode)
        {
            CgNativeMethods.cgSetParameterSettingMode(context, (int)parameterSettingMode);
        }

        #endregion Public Static Methods

        #endregion Methods
    }
}