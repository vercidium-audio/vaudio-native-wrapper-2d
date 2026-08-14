namespace vaudionativewrapper.managed
{
    /// <summary>A 2D grid of cells</summary>
    public unsafe class GridPrimitive : Primitive
    {
        public readonly int width;
        public readonly int height;

        /// <summary>Create a new grid primitive with the specified grid size</summary>
        public GridPrimitive(int width, int height)
        {
            this.width = width;
            this.height = height;

            native = GridPrimitiveBindings.Create(width, height);
            owns = true;
        }

        /// <summary>Determines the amount of energy lost when rays bounce off this primitive, permeate through it, and scatter off it</summary>
        public MaterialType material
        {
            get => GridPrimitiveBindings.GetMaterial(native);
            set => GridPrimitiveBindings.SetMaterial(native, value).ThrowIfError();
        }

        /// <summary>Position of the grid in world space</summary>
        public Vector position
        {
            get => GridPrimitiveBindings.GetPosition(native);
            set => GridPrimitiveBindings.SetPosition(native, value).ThrowIfError();
        }

        /// <summary>Rotation of the grid in radians, applied around its position</summary>
        public float rotation
        {
            get => GridPrimitiveBindings.GetRotation(native);
            set => GridPrimitiveBindings.SetRotation(native, value).ThrowIfError();
        }

        /// <summary>Scale of the cells</summary>
        public float scale
        {
            get => GridPrimitiveBindings.GetScale(native);
            set => GridPrimitiveBindings.SetScale(native, value).ThrowIfError();
        }

        /// <summary>Helper overload for accessing and editing grid data</summary>
        public MaterialType this[int x, int y]
        {
            get => GridPrimitiveBindings.GetCell(native, x, y);
            set => GridPrimitiveBindings.SetCell(native, x, y, value).ThrowIfError();
        }

        /// <summary>Call this after editing grid data</summary>
        public void SetDataDirty() => GridPrimitiveBindings.SetDataDirty(native).ThrowIfError();

        public void Destroy()
        {
            GridPrimitiveBindings.Destroy(native).ThrowIfError();
            native = System.IntPtr.Zero;
        }

        protected override string DebugInfo => $"material={material}, width={width}, height={height}, position={position}, rotation={rotation}, scale={scale}";
    }
}
