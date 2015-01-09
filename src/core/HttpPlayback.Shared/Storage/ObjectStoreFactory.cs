using HttpCapture.Shared;
using HttpPlayback.Shared.Storage.FileSys;
using HttpPlayback.Shared.Storage.Serialization;

namespace HttpPlayback.Shared.Storage
{
    /// <summary>
    /// Factory class used for instantiating <see cref="IObjectStore{TData}"/> instances
    /// </summary>
    public static class ObjectStoreFactory
    {
        public static IObjectStore<TData> CreateFileSystemObjectStore<TData>() where TData : IPlaybackObject
        {
            return new FileObjectStore<TData>(SerializerFactory.CreateDefaultSerializer<TData>());
        } 
    }
}
