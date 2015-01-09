using System.IO;

namespace HttpPlayback.Shared.Storage.Serialization
{
    /// <summary>
    /// Generic serializer implementation, not specific to any <see cref="IObjectStore{T}"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISerializer<T>
    {
        T Deserialize(Stream bytes);

        Stream Serialize(T obj);
    }
}
