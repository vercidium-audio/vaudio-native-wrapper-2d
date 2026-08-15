using System;

namespace vaudionativewrapper.managed
{
    /// <summary>A solid elliptical audio primitive</summary>
    public class OvalPrimitive : Primitive
    {
        public OvalPrimitive()
        {
            native = OvalPrimitiveBindings.Create();
            owns = true;
        }

        /// <summary>Determines the amount of energy lost when rays bounce off this primitive, permeate through it, and scatter off it</summary>
        public MaterialType material
        {
            get => OvalPrimitiveBindings.GetMaterial(native);
            set => OvalPrimitiveBindings.SetMaterial(native, value).ThrowIfError();
        }

        /// <summary>Center position of the oval in world space</summary>
        public Vector center
        {
            get => OvalPrimitiveBindings.GetCenter(native);
            set => OvalPrimitiveBindings.SetCenter(native, value).ThrowIfError();
        }

        /// <summary>Radius of the oval along its local X axis</summary>
        public float radiusX
        {
            get => OvalPrimitiveBindings.GetRadiusX(native);
            set => OvalPrimitiveBindings.SetRadiusX(native, value).ThrowIfError();
        }

        /// <summary>Radius of the oval along its local Y axis</summary>
        public float radiusY
        {
            get => OvalPrimitiveBindings.GetRadiusY(native);
            set => OvalPrimitiveBindings.SetRadiusY(native, value).ThrowIfError();
        }

        /// <summary>Rotation of the oval in radians, applied around its center</summary>
        public float rotation
        {
            get => OvalPrimitiveBindings.GetRotation(native);
            set => OvalPrimitiveBindings.SetRotation(native, value).ThrowIfError();
        }

        protected override VAResult DestroyNative(IntPtr native) => OvalPrimitiveBindings.Destroy(native);

        protected override string DebugInfo => $"material={material}, center={center}, radiusX={radiusX}, radiusY={radiusY}, rotation={rotation}";
    }
}
