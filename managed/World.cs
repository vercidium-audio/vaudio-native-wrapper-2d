namespace vaudionativewrapper.managed
{
    /// <summary>A standalone world with its own primitives, emitters, materials and settings. Manages its own raytracing and multithreading</summary>
    public partial class World
    {
        /// <summary>The rotation of the camera in the debug window (dev build only)</summary>
        public float CameraRotation
        {
            get => WorldBindings.GetCameraRotation(native);
            set => WorldBindings.SetCameraRotation(native, value).ThrowIfError();
        }

        /// <summary>The camera zoom factor in the debug window (dev build only)</summary>
        public float CameraZoom
        {
            get => WorldBindings.GetCameraZoom(native);
            set => WorldBindings.SetCameraZoom(native, value).ThrowIfError();
        }

        /// <summary>Converts a world-space direction to a listener-space direction, for use in EFX reflections/late reverb pan (X, 0, Y).</summary>
        public Vector CalculateListenerRelativePan(Vector worldVector, float listenerRotation)
        {
            return WorldBindings.CalculateListenerRelativePan(native, worldVector, listenerRotation);
        }

        /// <summary>
        /// Converts a world-space direction (in the world's <see cref="CoordinateSystem"/>) to a listener-space direction, based on the listener's rotation (in the world's <see cref="CoordinateSystem"/>).<br/>
        /// A listener with rotation 0 faces the <see cref="CoordinateSystem"/>'s up direction. Listener space is always X+ right and Y+ forward relative to the listener, regardless of <see cref="CoordinateSystem"/>, so it maps directly onto EFX reflections/late reverb pan as (X, 0, Y).<br/>
        /// </summary>
        public Vector ConvertWorldToListenerDirection(Vector worldDirection, float listenerRotation)
        {
            return WorldBindings.ConvertWorldToListenerDirection(native, worldDirection, listenerRotation);
        }

        /// <summary>
        /// Converts a listener-space direction (X+ right, Y+ forward relative to the listener) to a world-space direction (in the world's <see cref="CoordinateSystem"/>), based on the listener's rotation.<br/>
        /// Inverse of <see cref="ConvertWorldToListenerDirection"/>.
        /// </summary>
        public Vector ConvertListenerToWorldDirection(Vector listenerDirection, float listenerRotation)
        {
            return WorldBindings.ConvertListenerToWorldDirection(native, listenerDirection, listenerRotation);
        }

    }
}
