namespace vaudionativewrapper.managed
{
    public partial class World
    {
        /// <summary>The rotation of the camera in the debug window (dev build only)</summary>
        public float CameraRotation
        {
            get => WorldBindings.GetCameraRotation(native);
            set => WorldBindings.SetCameraRotation(native, value).ThrowIfError();
        }

        /// <summary>The zoom of the camera in the debug window (dev build only)</summary>
        public float CameraZoom
        {
            get => WorldBindings.GetCameraZoom(native);
            set => WorldBindings.SetCameraZoom(native, value).ThrowIfError();
        }

        /// <summary>Helper function that converts a world-space direction to a listener-space direction</summary>
        public Vector CalculateListenerRelativePan(Vector worldVector, float listenerYaw)
        {
            return WorldBindings.CalculateListenerRelativePan(native, worldVector, listenerYaw);
        }

    }
}
