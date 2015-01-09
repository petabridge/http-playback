using System.IO;

namespace HttpPlayback.Shared.Storage.FileSys
{

    /// <summary>
    /// Descriptor object that exposes a file-system path to a file
    /// </summary>
    public class FileObjectLocation : IObjectLocation
    {
        private readonly string _path;

        public FileObjectLocation(string path)
        {
            _path = path;
        }


        public string ResolveToPath()
        {
            return Path.GetFullPath(_path);
        }

        #region Implicit operators

        public static implicit operator string(FileObjectLocation loc)
        {
            return loc == null ? string.Empty : loc.ResolveToPath();
        }

        public static implicit operator FileObjectLocation(string str)
        {
            return new FileObjectLocation(str);
        }

        #endregion
    }
}