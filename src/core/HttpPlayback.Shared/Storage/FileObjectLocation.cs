using System.IO;

namespace HttpPlayback.Shared.Storage
{
    public class FileObjectLocation : IObjectLocation
    {
        private string _path;

        public FileObjectLocation(string path)
        {
            _path = path;
        }


        public string ResolveToPath()
        {
            return Path.GetFullPath(_path);
        }
    }
}