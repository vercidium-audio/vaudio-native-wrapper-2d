using System;
using System.Runtime.InteropServices;

namespace vaudionativewrapper
{
    public static class OvalPrimitiveBindings
    {
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaOvalPrimitiveCreate")]
        public static extern IntPtr Create();

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaOvalPrimitiveSetCenter")]
        public static extern VAResult SetCenter(IntPtr primitive, Vector center);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaOvalPrimitiveSetRadiusX")]
        public static extern VAResult SetRadiusX(IntPtr primitive, float radiusX);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaOvalPrimitiveSetRadiusY")]
        public static extern VAResult SetRadiusY(IntPtr primitive, float radiusY);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaOvalPrimitiveSetRotation")]
        public static extern VAResult SetRotation(IntPtr primitive, float rotation);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaOvalPrimitiveGetCenter")]
        public static extern Vector GetCenter(IntPtr primitive);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaOvalPrimitiveGetRadiusX")]
        public static extern float GetRadiusX(IntPtr primitive);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaOvalPrimitiveGetRadiusY")]
        public static extern float GetRadiusY(IntPtr primitive);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaOvalPrimitiveGetRotation")]
        public static extern float GetRotation(IntPtr primitive);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaOvalPrimitiveDestroy")]
        public static extern VAResult Destroy(IntPtr primitive);
    }
}
