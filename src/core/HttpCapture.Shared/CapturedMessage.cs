using System.Collections.Specialized;

namespace HttpCapture.Shared
{
    /// <summary>
    /// Represents a captured HTTP request - this is the raw format that is used
    /// to send HTTP requests we want to re-use over the wire to our capture server.
    /// </summary>
    public sealed class CapturedMessage
    {
        public CapturedMessage() : this(new NameValueCollection()) { }

        public CapturedMessage(NameValueCollection httpHeaders)
        {
            HttpHeaders = httpHeaders;
        }

        /// <summary>
        /// Represents the HTTP verb that was used in this request
        /// </summary>
        public string HttpVerb { get; set; }

        /// <summary>
        /// The full URI of the HTTP request, including host and port.
        /// </summary>
        public string AbsoluteUri { get; set; }

        /// <summary>
        /// The user agent for this request
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// Collection of all of the HTTP headers for this request
        /// </summary>
        public NameValueCollection HttpHeaders { get; private set; }

        /// <summary>
        /// The raw HTTP body of the request
        /// </summary>
        public string Body { get; set; }
    }
}
