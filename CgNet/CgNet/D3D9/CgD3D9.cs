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

        public static Result BindProgram(IntPtr program)
        {
            return FromHResult(CgD3D9NativeMethods.cgD3D9BindProgram(program));
        }

        public static Device GetDevice()
        {
            return Device.FromPointer(CgD3D9NativeMethods.cgD3D9GetDevice());
        }

        public static ProfileType GetLatestPixelProfile()
        {
            return CgD3D9NativeMethods.cgD3D9GetLatestPixelProfile();
        }

        public static ProfileType GetLatestVertexProfile()
        {
            return CgD3D9NativeMethods.cgD3D9GetLatestVertexProfile();
        }

        public static string[] GetOptimalOptions(ProfileType profile)
        {
            return Cg.IntPtrToStringArray(CgD3D9NativeMethods.cgD3D9GetOptimalOptions(profile));
        }

        public static VertexElement[] GetVertexDeclaration(IntPtr program)
        {
            var buf = new VertexElement[64];
            return CgD3D9NativeMethods.cgD3D9GetVertexDeclaration(program, buf) ? buf : null;
        }

        public static Result LoadProgram(IntPtr program, bool paramShadowing, int assemFlags)
        {
            return FromHResult(CgD3D9NativeMethods.cgD3D9LoadProgram(program, paramShadowing, (uint)assemFlags));
        }

        public static DeclarationUsage ResourceTypeToDeclarationUsage(ResourceType resourceType)
        {
            return (DeclarationUsage)CgD3D9NativeMethods.cgD3D9ResourceToDeclUsage(resourceType);
        }

        public static Result SetDevice(Device device)
        {
            return FromHResult(CgD3D9NativeMethods.cgD3D9SetDevice(device != null ? device.ComPointer : IntPtr.Zero));
        }

        public static int TypeToSize(ParameterType type)
        {
            return (int)CgD3D9NativeMethods.cgD3D9TypeToSize(type);
        }

        public static bool ValidateVertexDeclaration(IntPtr program, VertexElement[] decl)
        {
            return CgD3D9NativeMethods.cgD3D9ValidateVertexDeclaration(program, decl);
        }

        #endregion Public Static Methods

        #region Private Static Methods

        private static Result FromHResult(int h)
        {
            unsafe
            {
                IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(Result)));
                try
                {
                    Marshal.StructureToPtr(new Result(), ptr, true);
                    *(int*)ptr = h;
                    var retValue = (Result)Marshal.PtrToStructure(ptr, typeof(Result));
                    return retValue;
                }
                finally
                {
                    Marshal.FreeHGlobal(ptr);
                }
            }
        }

        #endregion Private Static Methods

        #endregion Methods
    }
}