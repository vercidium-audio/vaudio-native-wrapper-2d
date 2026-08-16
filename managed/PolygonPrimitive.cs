using System;
using System.Collections.Generic;

namespace vaudionativewrapper.managed
{
    /// <summary>A flat polygon audio primitive with zero thickness, defined by a list of local-space points. Supports concave and convex shapes</summary>
    public unsafe class PolygonPrimitive : Primitive
    {
        /// <summary>Create a polygon primitive from a list of local-space points. Must contain at least 3 points</summary>
        public PolygonPrimitive(List<Vector> points)
        {
            Vector[] copy = points.ToArray();
            IntPtr outPrimitive;

            fixed (Vector* ptr = copy)
            {
                PolygonPrimitiveBindings.Create(ptr, copy.Length, &outPrimitive).ThrowIfError();
            }

            native = outPrimitive;
            owns = true;
        }

        /// <summary>Create a polygon primitive from an array of local-space points. Must contain at least 3 points</summary>
        public PolygonPrimitive(Vector[] points)
        {
            IntPtr outPrimitive;

            fixed (Vector* ptr = points)
            {
                PolygonPrimitiveBindings.Create(ptr, points.Length, &outPrimitive).ThrowIfError();
            }

            native = outPrimitive;
            owns = true;
        }

        /// <summary>Determines the amount of energy lost when rays bounce off this primitive, permeate through it, and scatter off it</summary>
        public MaterialType material
        {
            get => PolygonPrimitiveBindings.GetMaterial(native);
            set => PolygonPrimitiveBindings.SetMaterial(native, value).ThrowIfError();
        }

        /// <summary>Local-space points of the polygon, before rotation, scale and position are applied. Must contain at least 3 points</summary>
        public Vector[] points
        {
            get
            {
                int count = PolygonPrimitiveBindings.GetPointCount(native);
                var result = new Vector[count];

                for (int i = 0; i < count; i++)
                    result[i] = PolygonPrimitiveBindings.GetPoint(native, i);

                return result;
            }
            set
            {
                fixed (Vector* ptr = value)
                {
                    PolygonPrimitiveBindings.SetPoints(native, ptr, value.Length).ThrowIfError();
                }
            }
        }

        /// <summary>World-space position that local-space points are offset by</summary>
        public Vector position
        {
            get => PolygonPrimitiveBindings.GetPosition(native);
            set => PolygonPrimitiveBindings.SetPosition(native, value).ThrowIfError();
        }

        /// <summary>Rotation of the polygon in radians, applied around its position</summary>
        public float rotation
        {
            get => PolygonPrimitiveBindings.GetRotation(native);
            set => PolygonPrimitiveBindings.SetRotation(native, value).ThrowIfError();
        }

        /// <summary>Uniform scale applied to the local-space points</summary>
        public float scale
        {
            get => PolygonPrimitiveBindings.GetScale(native);
            set => PolygonPrimitiveBindings.SetScale(native, value).ThrowIfError();
        }

        /// <summary>Whether this polygon supports entry/exit permeation raytracing (thickness-based transmission loss through its filled interior). Only enable for polygons known to be convex, or where an approximate entry/exit span is acceptable</summary>
        public bool supportsPermeation
        {
            get => PolygonPrimitiveBindings.GetSupportsPermeation(native);
            set => PolygonPrimitiveBindings.SetSupportsPermeation(native, value).ThrowIfError();
        }

        /// <summary>Whether this polygon is a closed loop (an edge connects the last point back to the first) or just an open sequence of line segments. Defaults to true</summary>
        public bool enclosed
        {
            get => PolygonPrimitiveBindings.GetEnclosed(native);
            set => PolygonPrimitiveBindings.SetEnclosed(native, value).ThrowIfError();
        }

        protected override VAResult DestroyNative(IntPtr native) => PolygonPrimitiveBindings.Destroy(native);

        protected override string DebugInfo => $"material={material}, position={position}, rotation={rotation}, scale={scale}";
    }
}
