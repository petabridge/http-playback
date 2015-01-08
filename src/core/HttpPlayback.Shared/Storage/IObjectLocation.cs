namespace HttpPlayback.Shared.Storage
{
    /// <summary>
    /// Describes how this object should be saved and read from the storage system
    /// </summary>
    public interface IObjectLocation
    {
        string ResolveToPath();
    }
}