using System;
using System.Runtime.InteropServices;

namespace vaudionativewrapper
{
    public static class BoxPrimitiveBindings
    {
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaBoxPrimitiveCreate")]
        public static extern IntPtr Create();

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaBoxPrimitiveSetPosition")]
        public static extern VAResult SetPosition(IntPtr primitive, Vector position);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaBoxPrimitiveSetSize")]
        public static extern VAResult SetSize(IntPtr primitive, Vector size);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaBoxPrimitiveSetRotation")]
        public static extern VAResult SetRotation(IntPtr primitive, float rotation);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaBoxPrimitiveGetPosition")]
        public static extern Vector GetPosition(IntPtr primitive);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaBoxPrimitiveGetSize")]
        public static extern Vector GetSize(IntPtr primitive);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaBoxPrimitiveGetRotation")]
        public static extern float GetRotation(IntPtr primitive);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaBoxPrimitiveDestroy")]
        public static extern VAResult Destroy(IntPtr primitive);
    }
}
