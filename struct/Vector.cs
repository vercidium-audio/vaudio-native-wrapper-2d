using System.Runtime.InteropServices;

namespace vaudionativewrapper
{
    /// <summary>A 2D vector with single-precision floating-point components</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector
    {
        /// <summary>Creates a vector with all components set to <paramref name="v"/></summary>
        public Vector(float v)
        {
            X = v;
            Y = v;
        }

        /// <summary>Creates a vector with the specified components</summary>
        public Vector(float x, float y)
        {
            X = x;
            Y = y;
        }

        /// <summary>The X component</summary>
        public float X;

        /// <summary>The Y component</summary>
        public float Y;
    }
}
