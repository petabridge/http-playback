using System;
using System.IO;
using System.Reflection;
using Faker;
using HttpCapture.Shared;
using HttpPlayback.Shared.Storage;
using HttpPlayback.Shared.Storage.FileSys;
using HttpPlayback.Shared.Tests.Helpers;
using NUnit.Framework;

namespace HttpPlayback.Shared.Tests.StorageTests
{
    [TestFixture(Description = "Tests to ensure that we can persist objects to disk and read them back")]
    public class FileStoreWithPreExistingDirectoryTests
    {
        #region Setup / Teardown

        private IObjectStore<CapturedHttpRequest> _messageStore;
        private Fake<CapturedHttpRequest> _fakeMessage;

        [TestFixtureSetUp]
        public void SetUpOnce()
        {
            _messageStore = ObjectStoreFactory.CreateFileSystemObjectStore<CapturedHttpRequest>();
            _fakeMessage = new Fake<CapturedHttpRequest>();
        }

        [SetUp]
        public void SetUp()
        {
            TestDataDirectoryHelpers.EnsureTestDataDirectory();
        }

        [TearDown]
        public void TearDown()
        {
            TestDataDirectoryHelpers.DeleteTestDataDirectory();
        }

        #endregion

        #region Helpers
        private void GenerateAndSaveCapturedMessage(out CapturedHttpRequest msg, out FileObjectLocation path)
        {
            msg = _fakeMessage.Generate();
            path = (FileObjectLocation)Path.Combine(TestFilePaths.TestDataPath, String.Format("{0}.dat", Faker.Generators.Strings.GenerateAlphaNumericString()));
            _messageStore.Write(msg, path);
        }

        #endregion

        #region Tests

        [Test]
        public void Should_write_to_disk()
        {
            //arrange
            CapturedHttpRequest msg;
            FileObjectLocation path;
            GenerateAndSaveCapturedMessage(out msg, out path);

            //assert
            Assert.IsTrue(File.Exists(path));
        }

        [Test]
        public void Should_read_from_disk()
        {
            //arrange
            CapturedHttpRequest expectedHttpRequest;
            FileObjectLocation path;
            GenerateAndSaveCapturedMessage(out expectedHttpRequest, out path);

            //act
            var actualMessage = _messageStore.Read(path);

            //assert
            Assert.AreEqual(expectedHttpRequest.Body, actualMessage.Body);
        }

        [Test]
        public void Should_overrwite_existing_file_on_disk()
        {
            //arrange
            CapturedHttpRequest initialHttpRequest;
            FileObjectLocation path;
            GenerateAndSaveCapturedMessage(out initialHttpRequest, out path);

            //act
            var expectedMessage = _fakeMessage.Generate();
            _messageStore.Write(expectedMessage, path);
            var actualMessage = _messageStore.Read(path);

            //assert
            Assert.AreNotEqual(actualMessage.Body, initialHttpRequest.Body);
            Assert.AreEqual(actualMessage.Body, expectedMessage.Body);
        }

        [Test]
        public void Should_read_nonexistent_file_from_disk()
        {
            //arrange

            //act

            //assert
        }

        #endregion
    }
}
