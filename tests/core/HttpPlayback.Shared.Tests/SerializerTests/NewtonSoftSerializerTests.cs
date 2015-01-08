using System;
using System.Globalization;
using System.IO;
using System.Linq;
using Faker;
using HttpCapture.Shared;
using HttpPlayback.Shared.Storage.Serialization;
using Newtonsoft.Json;
using NUnit.Framework;

namespace HttpPlayback.Shared.Tests.SerializerTests
{
    [TestFixture(Description = "Used to verify that the JSON serializer works as intended")]
    public class NewtonSoftSerializerTests
    {
        #region Setup / Teardown

        public Fake<CapturedMessage> FakeCapturedMessage;
        public ISerializer<CapturedMessage> MessageSerializer;

        [SetUp]
        public void Setup()
        {
            MessageSerializer = SerializerFactory.CreateJsonSerializer<CapturedMessage>();
            FakeCapturedMessage = new Fake<CapturedMessage>();
          
        }

        #endregion

        #region Tests

        [Test]
        public void Should_encode_non_null_message_as_JSON()
        {
            //arrange
            var message = FakeCapturedMessage.Generate();
            var expected = JsonConvert.SerializeObject(message);

            //act
            var serializedMessage = MessageSerializer.Serialize(message);
            string actual;
            using (var streamReader = new StreamReader(serializedMessage))
            {
                actual = streamReader.ReadToEnd();
            }

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Should_encode_message_with_null_fields_as_JSON()
        {
            //arrange
            var message = FakeCapturedMessage
                .SetProperty(x => x.Host, () => null)
                .SetProperty(x => x.Body, () => null)
                .Generate();

            var expected = JsonConvert.SerializeObject(message);

            //act
            var serializedMessage = MessageSerializer.Serialize(message);
            string actual;
            using (var streamReader = new StreamReader(serializedMessage))
            {
                actual = streamReader.ReadToEnd();
            }

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Should_decode_message_from_JSON()
        {
            //arrange
            var message = FakeCapturedMessage.Generate();

            //act
            var encodedMessage = MessageSerializer.Serialize(message);
            var decodedMessage = MessageSerializer.Deserialize(encodedMessage);

            //assert
            Assert.AreEqual(message.Body, decodedMessage.Body);
        }

        #endregion
    }
}
