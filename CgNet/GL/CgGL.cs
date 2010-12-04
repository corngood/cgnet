namespace CGNet.GL
{
    using System;

    using CGNet.Wrapper;

    public static class CgGL
    {
        #region Methods

        #region Public Static Methods

        public static void BindProgram(IntPtr program)
        {
            CgGLNativeMethods.cgGLBindProgram(program);
        }

        public static void DisableProfile(int profile)
        {
            CgGLNativeMethods.cgGLDisableProfile(profile);
        }

        public static void EnableProfile(int profile)
        {
            CgGLNativeMethods.cgGLEnableProfile(profile);
        }

        public static int GetLatestProfile(ProfileClass profileClass)
        {
            return CgGLNativeMethods.cgGLGetLatestProfile((int)profileClass);
        }

        public static void LoadProgram(IntPtr program)
        {
            CgGLNativeMethods.cgGLLoadProgram(program);
        }

        public static void SetOptimalOptions(int profile)
        {
            CgGLNativeMethods.cgGLSetOptimalOptions(profile);
        }

        #endregion Public Static Methods

        #endregion Methods
    }
}