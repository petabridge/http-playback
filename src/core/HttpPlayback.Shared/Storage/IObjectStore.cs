using System.Net;
using System.Threading.Tasks;

namespace HttpPlayback.Shared.Storage
{
    /// <summary>
    /// Defines methods for saving and retreiving objects of type <typeparam name="TData"/>
    /// from a persistent store.
    /// </summary>
    public interface IObjectStore<TData> where TData:new()
    {
        void Write(TData data, IObjectLocation writeLocation);

        Task WriteAsync(TData data, IObjectLocation writeLocation);

        TData Read(IObjectLocation readLocation);

        Task<TData> ReadAsync(IObjectLocation readLocation);
    }
}
