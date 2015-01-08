using System.IO;
using System.Threading.Tasks;
using HttpPlayback.Shared.Storage.Serialization;

namespace HttpPlayback.Shared.Storage.FileSys
{
    public class FileObjectStore<TData> : AbstractStreamBasedObjectStore<TData> where TData : new()
    {
        public FileObjectStore(ISerializer<TData> serializer) : base(serializer)
        {
        }

        protected override Task WriteStreamAsync(Stream bytes, IObjectLocation writeLocation)
        {
            var fileStream = File.Create(writeLocation.ResolveToPath());
            return bytes.CopyToAsync(fileStream);
        }

        protected override Task<Stream> ReadStreamAsync(IObjectLocation readLocation)
        {
            return Task.Run(() => (Stream) File.OpenRead(readLocation.ResolveToPath()));
        }
    }
}