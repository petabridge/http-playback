using System;
using System.Data;

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

        public static IMissingObject GetMissing<TData>() where TData : IPlaybackObject
        {
            if (typeof(TData) == typeof(CapturedHttpRequest)) return MissingCapturedHttpRequest.Instance;
            
            throw new ArgumentException(string.Format("Type {0} is currently unhandled.", typeof(TData)));

        }

        public static TData GetConcrete<TData>(this Object obj) where TData : IPlaybackObject, new()
        {
            var concrete = obj as TData;

        }
    }
}