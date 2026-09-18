using System;
using System.Collections.Generic;

namespace vaudionativewrapper.managed
{
    /// <summary>A polygon primitive constructed from a list of points</summary>
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

        /// <summary>Local-space points, before rotation, scale and position are applied. Must contain at least 3 points</summary>
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

        /// <summary>Position of the polygon in world space</summary>
        public Vector position
        {
            get => PolygonPrimitiveBindings.GetPosition(native);
            set => PolygonPrimitiveBindings.SetPosition(native, value).ThrowIfError();
        }

        /// <summary>Rotation of the polygon in radians</summary>
        public float rotation
        {
            get => PolygonPrimitiveBindings.GetRotation(native);
            set => PolygonPrimitiveBindings.SetRotation(native, value).ThrowIfError();
        }

        /// <summary>Scale applied to the local-space points, before rotation and position</summary>
        public Vector scale
        {
            get => PolygonPrimitiveBindings.GetScale(native);
            set => PolygonPrimitiveBindings.SetScale(native, value).ThrowIfError();
        }

        /// <summary>Whether rays lose a flat percentage of energy the moment they touch this primitive, instead of calculating how long the ray spent inside it. Flat primitives (e.g. Disk, Plane, Triangle, Line) force this to true and throw if set to false.</summary>
        public bool UseFlatTransmission
        {
            get => PolygonPrimitiveBindings.GetUseFlatTransmission(native);
            set => PolygonPrimitiveBindings.SetUseFlatTransmission(native, value).ThrowIfError();
        }

        /// <summary>Whether the last point should connect back to the first</summary>
        public bool enclosed
        {
            get => PolygonPrimitiveBindings.GetEnclosed(native);
            set => PolygonPrimitiveBindings.SetEnclosed(native, value).ThrowIfError();
        }

        protected override VAResult DestroyNative(IntPtr native) => PolygonPrimitiveBindings.Destroy(native);

        protected override string DebugInfo => $"material={material}, position={position}, rotation={rotation}, scale={scale}";
    }
}
