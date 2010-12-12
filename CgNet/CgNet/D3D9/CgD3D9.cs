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
namespace CgNet.CgNet.D3D9
{
    using System;
    using System.Runtime.InteropServices;

    using ParameterType = global::CgNet.ParameterType;

    using ResourceType = global::CgNet.ResourceType;

    using SlimDX;
    using SlimDX.Direct3D9;

    public static class CgD3D9
    {
        #region Methods

        #region Public Static Methods

        public static int BindProgram(IntPtr program)
        {
            return CgD3D9NativeMethods.cgD3D9BindProgram(program);
        }

        public static void EnableDebugTracing(bool enable)
        {
            CgD3D9NativeMethods.cgD3D9EnableDebugTracing(enable);
        }

        public static int EnableParameterShadowing(IntPtr prog, [MarshalAs(UnmanagedType.Bool)]bool enable)
        {
            return CgD3D9NativeMethods.cgD3D9EnableParameterShadowing(prog, enable);
        }

        public static Device GetDevice()
        {
            return Device.FromPointer(CgD3D9NativeMethods.cgD3D9GetDevice());
        }

        public static int GetLastError()
        {
            return CgD3D9NativeMethods.cgD3D9GetLastError();
        }

        public static ProfileType GetLatestPixelProfile()
        {
            return CgD3D9NativeMethods.cgD3D9GetLatestPixelProfile();
        }

        public static ProfileType GetLatestVertexProfile()
        {
            return CgD3D9NativeMethods.cgD3D9GetLatestVertexProfile();
        }

        public static bool GetManageTextureParameters(IntPtr context)
        {
            return CgD3D9NativeMethods.cgD3D9GetManageTextureParameters(context);
        }

        public static string[] GetOptimalOptions(ProfileType profile)
        {
            return Cg.IntPtrToStringArray(CgD3D9NativeMethods.cgD3D9GetOptimalOptions(profile));
        }

        public static BaseTexture GetTextureParameter(IntPtr param)
        {
            return (BaseTexture)Resource.FromPointer(CgD3D9NativeMethods.cgD3D9GetTextureParameter(param));
        }

        public static VertexElement[] GetVertexDeclaration(IntPtr program)
        {
            var buf = new VertexElement[64];
            return CgD3D9NativeMethods.cgD3D9GetVertexDeclaration(program, buf) ? buf : null;
        }

        public static bool IsParameterShadowingEnabled(IntPtr program)
        {
            return CgD3D9NativeMethods.cgD3D9IsParameterShadowingEnabled(program);
        }

        public static bool IsProfileSupported(ProfileType profile)
        {
            return CgD3D9NativeMethods.cgD3D9IsProfileSupported(profile);
        }

        public static bool IsProgramLoaded(IntPtr program)
        {
            return CgD3D9NativeMethods.cgD3D9IsProgramLoaded(program);
        }

        public static int LoadProgram(IntPtr program, bool paramShadowing, int assemFlags)
        {
            return CgD3D9NativeMethods.cgD3D9LoadProgram(program, paramShadowing, (uint)assemFlags);
        }

        public static void RegisterStates(IntPtr ctx)
        {
            CgD3D9NativeMethods.cgD3D9RegisterStates(ctx);
        }

        public static DeclarationUsage ResourceTypeToDeclarationUsage(ResourceType resourceType)
        {
            return (DeclarationUsage)CgD3D9NativeMethods.cgD3D9ResourceToDeclUsage(resourceType);
        }

        public static int SetDevice(Device device)
        {
            return CgD3D9NativeMethods.cgD3D9SetDevice(device != null ? device.ComPointer : IntPtr.Zero);
        }

        public static void SetManageTextureParameters(IntPtr ctx, bool flag)
        {
            CgD3D9NativeMethods.cgD3D9SetManageTextureParameters(ctx, flag);
        }

        public static int SetSamplerState(IntPtr param, SlimDX.Direct3D9.SamplerState type, int value)
        {
            return CgD3D9NativeMethods.cgD3D9SetSamplerState(param, type, (uint)value);
        }

        public static int SetTexture(IntPtr param, BaseTexture tex)
        {
            return CgD3D9NativeMethods.cgD3D9SetTexture(param, tex.ComPointer);
        }

        public static void SetTextureParameter(IntPtr param, BaseTexture tex)
        {
            CgD3D9NativeMethods.cgD3D9SetTextureParameter(param, tex.ComPointer);
        }

        public static int SetTextureWrapMode(IntPtr param, int value)
        {
            return CgD3D9NativeMethods.cgD3D9SetTextureWrapMode(param, (uint)value);
        }

        public static int SetUniform(IntPtr param, float[] floats)
        {
            return CgD3D9NativeMethods.cgD3D9SetUniform(param, floats);
        }

        public static int SetUniformArray(IntPtr param, int offset, int numItems, IntPtr values)
        {
            return CgD3D9NativeMethods.cgD3D9SetUniformArray(param, (uint)offset, (uint)numItems, values);
        }

        public static int SetUniformMatrix(IntPtr param, SlimDX.Matrix matrix)
        {
            return CgD3D9NativeMethods.cgD3D9SetUniformMatrix(param, matrix);
        }

        public static int SetUniformMatrixArray(IntPtr param, int offset, SlimDX.Matrix[] matrices)
        {
            return CgD3D9NativeMethods.cgD3D9SetUniformMatrixArray(param, (uint)offset, (uint)matrices.Length, matrices);
        }

        public static string TranslateCgError(ErrorType error)
        {
            return Marshal.PtrToStringAnsi(CgD3D9NativeMethods.cgD3D9TranslateCGerror(error));
        }

        public static string TranslateResult(Result result)
        {
            return Marshal.PtrToStringAnsi(CgD3D9NativeMethods.cgD3D9TranslateHRESULT(result.Code));
        }

        public static int TypeToSize(ParameterType type)
        {
            return (int)CgD3D9NativeMethods.cgD3D9TypeToSize(type);
        }

        public static int UnbindProgram(IntPtr prog)
        {
            return CgD3D9NativeMethods.cgD3D9UnbindProgram(prog);
        }

        public static void UnloadAllPrograms()
        {
            CgD3D9NativeMethods.cgD3D9UnloadAllPrograms();
        }

        public static int UnloadProgram(IntPtr program)
        {
            return CgD3D9NativeMethods.cgD3D9UnloadProgram(program);
        }

        public static bool ValidateVertexDeclaration(IntPtr program, VertexElement[] decl)
        {
            return CgD3D9NativeMethods.cgD3D9ValidateVertexDeclaration(program, decl);
        }

        #endregion Public Static Methods

        #endregion Methods
    }
}