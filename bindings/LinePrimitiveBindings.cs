using System;
using System.Runtime.InteropServices;

namespace vaudionativewrapper
{
    public static class LinePrimitiveBindings
    {
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaLinePrimitiveCreate")]
        public static extern IntPtr Create();

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaLinePrimitiveSetStart")]
        public static extern VAResult SetStart(IntPtr primitive, Vector start);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaLinePrimitiveSetEnd")]
        public static extern VAResult SetEnd(IntPtr primitive, Vector end);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaLinePrimitiveGetStart")]
        public static extern Vector GetStart(IntPtr primitive);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaLinePrimitiveGetEnd")]
        public static extern Vector GetEnd(IntPtr primitive);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaLinePrimitiveDestroy")]
        public static extern VAResult Destroy(IntPtr primitive);
    }
}
