using System;
using System.IO;
using System.Threading.Tasks;
using HttpPlayback.Shared.Storage.Serialization;

namespace HttpPlayback.Shared.Storage
{
    /// <summary>
    /// Abstract base class for all <see cref="IObjectStore{T}"/> implementations
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    public abstract class AbstractStreamBasedObjectStore<TData> : IObjectStore<TData> where TData : new()
    {
        protected AbstractStreamBasedObjectStore(ISerializer<TData> serializer)
        {
            Serializer = serializer;
        }

        public ISerializer<TData> Serializer { get; private set; }

        #region IObjectStore<TData> methods

        public void Write(TData data, IObjectLocation writeLocation)
        {
            var streamTask = WriteAsync(data, writeLocation);
            streamTask.Wait();
        }

        public async Task WriteAsync(TData data, IObjectLocation writeLocation)
        {
            using (var stream = Serializer.Serialize(data))
            {
                await WriteStreamAsync(stream, writeLocation);
            }
        }

        public TData Read(IObjectLocation readLocation)
        {
            if (!ObjectExists(readLocation))
                return default(TData);

            var streamTask = ReadAsync(readLocation);
            streamTask.Wait();
            return streamTask.Result;
        }

        public Task<TData> ReadAsync(IObjectLocation readLocation)
        {
            return ReadStreamAsync(readLocation).ContinueWith(rt => Serializer.Deserialize(rt.Result),
                TaskContinuationOptions.AttachedToParent & TaskContinuationOptions.ExecuteSynchronously);
        }

        #endregion

        #region Abstract methods

        /// <summary>
        /// Asynchronously writes <see cref="bytes"/> to the location specified by <see cref="writeLocation"/>.
        /// </summary>
        protected abstract Task WriteStreamAsync(Stream bytes, IObjectLocation writeLocation);

        /// <summary>
        /// Asynchronously read a <see cref="Stream"/> from the location specified by <see cref="readLocation"/>.
        /// </summary>
        /// <param name="readLocation"></param>
        /// <returns></returns>
        protected abstract Task<Stream> ReadStreamAsync(IObjectLocation readLocation);

        /// <summary>
        /// See if the object exists before attemting to read it.
        /// </summary>
        /// <param name="readLocation"></param>
        /// <returns></returns>
        public abstract bool ObjectExists(IObjectLocation readLocation);

        #endregion
    }
}