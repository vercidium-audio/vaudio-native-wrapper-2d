using System;

namespace vaudionativewrapper.managed
{
    /// <summary>A solid rectangular audio primitive</summary>
    public class BoxPrimitive : Primitive
    {
        public BoxPrimitive()
        {
            native = BoxPrimitiveBindings.Create();
            owns = true;
        }

        /// <summary>Determines the amount of energy lost when rays bounce off this primitive, permeate through it, and scatter off it</summary>
        public MaterialType material
        {
            get => BoxPrimitiveBindings.GetMaterial(native);
            set => BoxPrimitiveBindings.SetMaterial(native, value).ThrowIfError();
        }

        /// <summary>Center position of the box in world space</summary>
        public Vector position
        {
            get => BoxPrimitiveBindings.GetPosition(native);
            set => BoxPrimitiveBindings.SetPosition(native, value).ThrowIfError();
        }

        /// <summary>Size of the box along its local X and Y axes</summary>
        public Vector size
        {
            get => BoxPrimitiveBindings.GetSize(native);
            set => BoxPrimitiveBindings.SetSize(native, value).ThrowIfError();
        }

        /// <summary>Rotation of the box in radians, applied around its position</summary>
        public float rotation
        {
            get => BoxPrimitiveBindings.GetRotation(native);
            set => BoxPrimitiveBindings.SetRotation(native, value).ThrowIfError();
        }

        protected override VAResult DestroyNative(IntPtr native) => BoxPrimitiveBindings.Destroy(native);

        protected override string DebugInfo => $"material={material}, position={position}, size={size}, rotation={rotation}";
    }
}
