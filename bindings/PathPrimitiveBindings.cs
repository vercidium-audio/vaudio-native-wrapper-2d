using System;
using System.Runtime.InteropServices;

namespace vaudionativewrapper
{
    public static class PathPrimitiveBindings
    {
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaPathPrimitiveCreate")]
        public static extern unsafe VAResult Create([MarshalAs(UnmanagedType.LPStr)] string svgPath, IntPtr* outPrimitive);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaPathPrimitiveSetSvgPath")]
        public static extern VAResult SetSvgPath(IntPtr primitive, [MarshalAs(UnmanagedType.LPStr)] string svgPath);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaPathPrimitiveGetSvgPath")]
        private static extern IntPtr GetSvgPathRaw(IntPtr primitive);
        public static string GetSvgPath(IntPtr primitive) => Marshal.PtrToStringAnsi(GetSvgPathRaw(primitive));

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaPathPrimitiveSetPosition")]
        public static extern VAResult SetPosition(IntPtr primitive, Vector position);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaPathPrimitiveSetRotation")]
        public static extern VAResult SetRotation(IntPtr primitive, float rotation);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaPathPrimitiveSetScale")]
        public static extern VAResult SetScale(IntPtr primitive, float scale);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaPathPrimitiveGetPosition")]
        public static extern Vector GetPosition(IntPtr primitive);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaPathPrimitiveGetRotation")]
        public static extern float GetRotation(IntPtr primitive);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaPathPrimitiveGetScale")]
        public static extern float GetScale(IntPtr primitive);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaPathPrimitiveGetSupportsPermeation")]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool GetSupportsPermeation(IntPtr primitive);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaPathPrimitiveSetSupportsPermeation")]
        public static extern VAResult SetSupportsPermeation(IntPtr primitive, bool supportsPermeation);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaPathPrimitiveGetMaterial")]
        public static extern MaterialType GetMaterial(IntPtr primitive);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaPathPrimitiveSetMaterial")]
        public static extern VAResult SetMaterial(IntPtr primitive, MaterialType material);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaPathPrimitiveDestroy")]
        public static extern VAResult Destroy(IntPtr primitive);
    }
}
