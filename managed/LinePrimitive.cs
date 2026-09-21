using System;

namespace vaudionativewrapper.managed
{
    /// <summary>A straight line primitive with zero thickness</summary>
    public class LinePrimitive : Primitive
    {
        /// <summary>Create a line primitive</summary>
        public LinePrimitive()
        {
            native = LinePrimitiveBindings.Create();
            owns = true;
        }

        /// <summary>Start position of the line in world space</summary>
        public Vector start
        {
            get => LinePrimitiveBindings.GetStart(native);
            set => LinePrimitiveBindings.SetStart(native, value).ThrowIfError();
        }

        /// <summary>End position of the line in world space</summary>
        public Vector end
        {
            get => LinePrimitiveBindings.GetEnd(native);
            set => LinePrimitiveBindings.SetEnd(native, value).ThrowIfError();
        }

        protected override VAResult DestroyNative(IntPtr native) => LinePrimitiveBindings.Destroy(native);

        protected override string DebugInfo => $"material={material}, start={start}, end={end}";
    }
}
