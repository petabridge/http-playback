using System.IO;
using System.Reflection;

namespace HttpPlayback.Shared.Tests.Helpers
{
    /// <summary>
    /// Helper class that provides root directories for working with files
    /// </summary>
    public static class TestFilePaths
    {
        private static string _selfDirectory = null;

        public static string RootFolderPath
        {
            get
            {
                if (string.IsNullOrEmpty(_selfDirectory))
                {
                    _selfDirectory = Path.GetDirectoryName(typeof (TestFilePaths).Assembly.Location);
                }
                return _selfDirectory;
            }
        }

        /// <summary>
        /// Name of the directory where we'll write test data
        /// </summary>
        public const string TestDataFolderName = "TestData";

        private static string _testDataFolder = null;

        /// <summary>
        /// Full path to where test data is written on disk
        /// </summary>
        public static string TestDataPath
        {
            get
            {
                if (string.IsNullOrEmpty(_testDataFolder))
                {
                    _testDataFolder = Path.Combine(RootFolderPath, TestDataFolderName);
                }
                return _testDataFolder;
            }
        }
    }
}
