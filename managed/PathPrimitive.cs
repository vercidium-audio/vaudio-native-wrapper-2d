using System;

namespace vaudionativewrapper.managed
{
    /// <summary>A flat audio primitive with zero thickness, defined by an SVG path string (treated as local space). Supports line segments and quadratic/cubic bezier curves</summary>
    public unsafe class PathPrimitive : Primitive
    {
        /// <summary>Create a path primitive from local-space SVG path data (the contents of an SVG "d" attribute). Supported commands: M/m, L/l, H/h, V/v, C/c, Q/q, Z/z (absolute and relative forms). Arcs (A/a) and smooth-curve shorthand (S/s, T/t) are not supported</summary>
        public PathPrimitive(string svgPath)
        {
            IntPtr outPrimitive;
            PathPrimitiveBindings.Create(svgPath, &outPrimitive).ThrowIfError();

            native = outPrimitive;
            owns = true;
        }

        /// <summary>Determines the amount of energy lost when rays bounce off this primitive, permeate through it, and scatter off it</summary>
        public MaterialType material
        {
            get => PathPrimitiveBindings.GetMaterial(native);
            set => PathPrimitiveBindings.SetMaterial(native, value).ThrowIfError();
        }

        /// <summary>The local-space SVG path data, before rotation, scale and position are applied. If the path ends with Z/z it is treated as closed</summary>
        public string svgPath
        {
            get => PathPrimitiveBindings.GetSvgPath(native);
            set => PathPrimitiveBindings.SetSvgPath(native, value).ThrowIfError();
        }

        /// <summary>World-space position that local-space path points are offset by</summary>
        public Vector position
        {
            get => PathPrimitiveBindings.GetPosition(native);
            set => PathPrimitiveBindings.SetPosition(native, value).ThrowIfError();
        }

        /// <summary>Rotation of the path in radians, applied around its position</summary>
        public float rotation
        {
            get => PathPrimitiveBindings.GetRotation(native);
            set => PathPrimitiveBindings.SetRotation(native, value).ThrowIfError();
        }

        /// <summary>Uniform scale applied to the local-space path points</summary>
        public float scale
        {
            get => PathPrimitiveBindings.GetScale(native);
            set => PathPrimitiveBindings.SetScale(native, value).ThrowIfError();
        }

        /// <summary>Whether this path supports entry/exit permeation raytracing (thickness-based transmission loss through its filled interior). Only meaningful for closed paths - set to true for watertight closed shapes</summary>
        public bool supportsPermeation
        {
            get => PathPrimitiveBindings.GetSupportsPermeation(native);
            set => PathPrimitiveBindings.SetSupportsPermeation(native, value).ThrowIfError();
        }

        public void Destroy()
        {
            PathPrimitiveBindings.Destroy(native).ThrowIfError();
            native = IntPtr.Zero;
        }

        protected override string DebugInfo => $"material={material}, position={position}, rotation={rotation}, scale={scale}";
    }
}
