using NUnit.Framework;

namespace HttpCapture.Shared.Tests
{
    [TestFixture(Description = "Tests to ensure objects that implement the IPlaybackObject interface behave as expected.")]
    public class ObjectTests
    {
        #region Setup/teardown
        #endregion

        #region Tests

        [Test]
        public void IPlaybackObject_IsMissing_should_return_true_when_object_is_null()
        {
            CapturedHttpRequest req = null;
            Assert.IsTrue(req.IsMissing());
        }

        [Test]
        public void IPlaybackObject_IsMissing_should_return_true_if_IMissingObject_is_implemented()
        {
            Assert.IsTrue(MissingCapturedHttpRequest.Instance.IsMissing());
        }

        [Test]
        public void IPlaybackObject_IsMissing_should_return_false_if_IMissingObject_is_not_implemented()
        {
            Assert.IsFalse(new CapturedHttpRequest().IsMissing());
        }

        #endregion
    }
}
