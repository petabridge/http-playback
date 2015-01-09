using HttpPlayback.Shared.Storage.Serialization.Json;

namespace HttpPlayback.Shared.Storage.Serialization
{
    /// <summary>
    /// A factory for creating <see cref="ISerializer{T}"/> instances
    /// </summary>
    public static class SerializerFactory
    {
        public static ISerializer<TData> CreateJsonSerializer<TData>()
        {
            return new NewtonsoftJsonSerializer<TData>();
        }

        public static ISerializer<TData> CreateDefaultSerializer<TData>()
        {
            return CreateJsonSerializer<TData>();
        }
    }
}
