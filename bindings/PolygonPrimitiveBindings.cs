using System;
using System.Runtime.InteropServices;

namespace vaudionativewrapper
{
    public static class PolygonPrimitiveBindings
    {
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaPolygonPrimitiveCreate")]
        public static extern unsafe VAResult Create(Vector* points, int pointCount, IntPtr* outPrimitive);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaPolygonPrimitiveSetPoints")]
        public static extern unsafe VAResult SetPoints(IntPtr primitive, Vector* points, int pointCount);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaPolygonPrimitiveGetPointCount")]
        public static extern int GetPointCount(IntPtr primitive);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaPolygonPrimitiveGetPoint")]
        public static extern Vector GetPoint(IntPtr primitive, int index);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaPolygonPrimitiveSetPosition")]
        public static extern VAResult SetPosition(IntPtr primitive, Vector position);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaPolygonPrimitiveSetRotation")]
        public static extern VAResult SetRotation(IntPtr primitive, float rotation);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaPolygonPrimitiveSetScale")]
        public static extern VAResult SetScale(IntPtr primitive, float scale);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaPolygonPrimitiveGetPosition")]
        public static extern Vector GetPosition(IntPtr primitive);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaPolygonPrimitiveGetRotation")]
        public static extern float GetRotation(IntPtr primitive);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaPolygonPrimitiveGetScale")]
        public static extern float GetScale(IntPtr primitive);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaPolygonPrimitiveGetSupportsPermeation")]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool GetSupportsPermeation(IntPtr primitive);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaPolygonPrimitiveSetSupportsPermeation")]
        public static extern VAResult SetSupportsPermeation(IntPtr primitive, bool supportsPermeation);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaPolygonPrimitiveGetEnclosed")]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool GetEnclosed(IntPtr primitive);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaPolygonPrimitiveSetEnclosed")]
        public static extern VAResult SetEnclosed(IntPtr primitive, bool enclosed);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaPolygonPrimitiveGetMaterial")]
        public static extern MaterialType GetMaterial(IntPtr primitive);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaPolygonPrimitiveSetMaterial")]
        public static extern VAResult SetMaterial(IntPtr primitive, MaterialType material);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaPolygonPrimitiveDestroy")]
        public static extern VAResult Destroy(IntPtr primitive);
    }
}
