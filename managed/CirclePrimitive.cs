using System;

namespace vaudionativewrapper.managed
{
    /// <summary>A solid circular audio primitive</summary>
    public class CirclePrimitive : Primitive
    {
        public CirclePrimitive()
        {
            native = CirclePrimitiveBindings.Create();
            owns = true;
        }

        /// <summary>Determines the amount of energy lost when rays bounce off this primitive, permeate through it, and scatter off it</summary>
        public MaterialType material
        {
            get => CirclePrimitiveBindings.GetMaterial(native);
            set => CirclePrimitiveBindings.SetMaterial(native, value).ThrowIfError();
        }

        /// <summary>Center position of the circle in world space</summary>
        public Vector center
        {
            get => CirclePrimitiveBindings.GetCenter(native);
            set => CirclePrimitiveBindings.SetCenter(native, value).ThrowIfError();
        }

        /// <summary>Radius of the circle</summary>
        public float radius
        {
            get => CirclePrimitiveBindings.GetRadius(native);
            set => CirclePrimitiveBindings.SetRadius(native, value).ThrowIfError();
        }

        protected override VAResult DestroyNative(IntPtr native) => CirclePrimitiveBindings.Destroy(native);

        protected override string DebugInfo => $"material={material}, center={center}, radius={radius}";
    }
}
