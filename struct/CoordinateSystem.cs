namespace vaudionativewrapper
{
    /// <summary>
    /// Coordinate system used for the debug window and for calculating listener-relative reverb directionality.
    /// Internally, this SDK always computes in a space with Y+ up and X+ right
    /// </summary>
    public enum CoordinateSystem
    {
        /// <summary>
        /// Y+ up, X+ right. Same as this SDK's internal space (no conversion applied). Matches Box2D "world" layer convention.
        /// </summary>
        Default = 0,

        /// <summary>
        /// Y+ down, X+ right. Matches Godot's 2D canvas/node convention (origin top-left).
        /// Mathematically identical to <see cref="YDown"/>.
        /// </summary>
        Godot2D,

        /// <summary>
        /// Y+ down, X+ right. Matches Unity's 2D/UI screen-space convention (origin top-left).
        /// Mathematically identical to <see cref="YDown"/>.
        /// </summary>
        Unity2D,

        /// <summary>
        /// Y+ down, X+ right. Generic screen-space convention (origin top-left, Y increases downward).
        /// </summary>
        YDown,
    }
}
