using System;

namespace vaudionativewrapper.managed
{
    /// <summary>A polygon primitive constructed from an SVG path</summary>
    public unsafe class PathPrimitive : Primitive
    {
        /// <summary>Create a path primitive from local-space SVG path data (the contents of an SVG "d" attribute). Supported commands: M/m, L/l, H/h, V/v, C/c, Q/q, A/a, Z/z (absolute and relative forms). Elliptical arcs (A/a) are converted to cubic bezier curves when parsed. Smooth-curve shorthand (S/s, T/t) is not supported</summary>
        public PathPrimitive(string svgPath)
        {
            IntPtr outPrimitive;
            PathPrimitiveBindings.Create(svgPath, &outPrimitive).ThrowIfError();

            native = outPrimitive;
            owns = true;
        }

        /// <summary>The local-space SVG path data (the contents of an SVG "d" attribute), before rotation, scale and position are applied. Supported commands: M/m, L/l, H/h, V/v, C/c, Q/q, A/a, Z/z (absolute and relative forms). Elliptical arcs (A/a) are converted to cubic bezier curves when parsed. Smooth-curve shorthand (S/s, T/t) is not supported. If the path ends with Z/z it is treated as closed.</summary>
        public string svgPath
        {
            get => PathPrimitiveBindings.GetSvgPath(native);
            set => PathPrimitiveBindings.SetSvgPath(native, value).ThrowIfError();
        }

        /// <summary>Position of the primitive in world space</summary>
        public Vector position
        {
            get => PathPrimitiveBindings.GetPosition(native);
            set => PathPrimitiveBindings.SetPosition(native, value).ThrowIfError();
        }

        /// <summary>Rotation of the path in radians</summary>
        public float rotation
        {
            get => PathPrimitiveBindings.GetRotation(native);
            set => PathPrimitiveBindings.SetRotation(native, value).ThrowIfError();
        }

        /// <summary>Scale applied to the local-space path, before rotation and position</summary>
        public Vector scale
        {
            get => PathPrimitiveBindings.GetScale(native);
            set => PathPrimitiveBindings.SetScale(native, value).ThrowIfError();
        }

        /// <summary>Whether rays lose a flat percentage of energy the moment they touch this path, instead of calculating how long the ray spent inside it. Only meaningful to disable for closed paths (svgPath ends with Z/z) as an open path has no interior.</summary>
        public bool UseFlatTransmission
        {
            get => PathPrimitiveBindings.GetUseFlatTransmission(native);
            set => PathPrimitiveBindings.SetUseFlatTransmission(native, value).ThrowIfError();
        }

        protected override VAResult DestroyNative(IntPtr native) => PathPrimitiveBindings.Destroy(native);

        protected override string DebugInfo => $"material={material}, position={position}, rotation={rotation}, scale={scale}";
    }
}
