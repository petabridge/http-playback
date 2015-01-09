using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpPlayback.Shared.Tests.Helpers
{
    /// <summary>
    /// Helper class that ensures that <see cref="TestFilePaths.TestDataPath"/> is clean for each set of tests
    /// </summary>
    public static class TestDataDirectoryHelpers
    {
        public static void EnsureTestDataDirectory()
        {
            if (!Directory.Exists(TestFilePaths.TestDataPath))
                Directory.CreateDirectory(TestFilePaths.TestDataPath);
        }

        public static void DeleteTestDataDirectory()
        {
            if(Directory.Exists(TestFilePaths.TestDataPath))
                Directory.Delete(TestFilePaths.TestDataPath, true);
        }
    }
}
