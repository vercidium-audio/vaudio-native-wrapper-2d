using System;

namespace vaudionativewrapper.managed
{
    /// <summary>A straight line audio primitive with zero thickness</summary>
    public class LinePrimitive : Primitive
    {
        public LinePrimitive()
        {
            native = LinePrimitiveBindings.Create();
            owns = true;
        }

        /// <summary>Determines the amount of energy lost when rays bounce off this primitive, permeate through it, and scatter off it</summary>
        public MaterialType material
        {
            get => LinePrimitiveBindings.GetMaterial(native);
            set => LinePrimitiveBindings.SetMaterial(native, value).ThrowIfError();
        }

        /// <summary>Start point of the line</summary>
        public Vector start
        {
            get => LinePrimitiveBindings.GetStart(native);
            set => LinePrimitiveBindings.SetStart(native, value).ThrowIfError();
        }

        /// <summary>End point of the line</summary>
        public Vector end
        {
            get => LinePrimitiveBindings.GetEnd(native);
            set => LinePrimitiveBindings.SetEnd(native, value).ThrowIfError();
        }

        public void Destroy()
        {
            LinePrimitiveBindings.Destroy(native).ThrowIfError();
            native = IntPtr.Zero;
        }

        protected override string DebugInfo => $"material={material}, start={start}, end={end}";
    }
}
