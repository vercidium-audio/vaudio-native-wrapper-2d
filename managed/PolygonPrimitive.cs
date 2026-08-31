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

        /// <summary>Per-axis scale applied to the local-space points, before rotation and position</summary>
        public Vector scale
        {
            get => PolygonPrimitiveBindings.GetScale(native);
            set => PolygonPrimitiveBindings.SetScale(native, value).ThrowIfError();
        }

        /// <summary>Whether rays lose a flat percentage of energy the moment they touch this polygon, instead of calculating how long the ray spent inside it. Only meaningful to disable for enclosed polygons - an open sequence of lines has no interior. Defaults to true (concave polygons can be crossed more than twice, so there is no single lengthInside through the shape in general - only set to false for polygons you know are convex, or where an approximate entry/exit span is acceptable)</summary>
        public bool UseFlatTransmission
        {
            get => PolygonPrimitiveBindings.GetUseFlatTransmission(native);
            set => PolygonPrimitiveBindings.SetUseFlatTransmission(native, value).ThrowIfError();
        }

        /// <summary>Whether this polygon is a closed loop (an edge connects the last point back to the first) or just an open sequence of line segments. Defaults to true. Set to false for a polyline with no closing edge</summary>
        public bool enclosed
        {
            get => PolygonPrimitiveBindings.GetEnclosed(native);
            set => PolygonPrimitiveBindings.SetEnclosed(native, value).ThrowIfError();
        }

        protected override VAResult DestroyNative(IntPtr native) => PolygonPrimitiveBindings.Destroy(native);

        protected override string DebugInfo => $"material={material}, position={position}, rotation={rotation}, scale={scale}";
    }
}
