using System.IO;
using System.Threading.Tasks;
using HttpPlayback.Shared.Storage.Serialization;

namespace HttpPlayback.Shared.Storage.FileSys
{
    public class FileObjectStore<TData> : AbstractStreamBasedObjectStore<TData> where TData : new()
    {
        public FileObjectStore(ISerializer<TData> serializer)
            : base(serializer)
        {
        }

        protected async override Task WriteStreamAsync(Stream bytes, IObjectLocation writeLocation)
        {
            using (var fileStream = File.Create(writeLocation.ResolveToPath()))
            {
                await bytes.CopyToAsync(fileStream);
            }
        }

        protected override Task<Stream> ReadStreamAsync(IObjectLocation readLocation)
        {
            return Task.Run(() => (Stream)File.OpenRead(readLocation.ResolveToPath()));
        }

        public override bool ObjectExists(IObjectLocation readLocation)
        {
            return File.Exists(readLocation.ResolveToPath());
        }
    }
}