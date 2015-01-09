namespace HttpCapture.Shared
{
    /// <summary>
    /// Extension methods for <see cref="IPlaybackObject"/>.
    /// </summary>
    public static class PlaybackObjectExtensions
    {
        /// <summary>
        /// Returns true if this object implements the <see cref="IMissingObject"/> interface, or is null.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsMissing(this IPlaybackObject obj)
        {
            if (obj == null) return true;
            return obj is IMissingObject;
        }
    }
}