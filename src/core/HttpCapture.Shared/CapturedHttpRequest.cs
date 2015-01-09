using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;

namespace HttpCapture.Shared
{
    /// <summary>
    /// Represents a captured HTTP request - this is the raw format that is used
    /// to send HTTP requests we want to re-use over the wire to our capture server.
    /// </summary>
    public class CapturedHttpRequest : IPlaybackObject
    {
        public CapturedHttpRequest() : this(new Dictionary<string, string>()) { }

        public CapturedHttpRequest(IDictionary<string,string> httpHeaders)
        {
            HttpHeaders = httpHeaders;
        }

        /// <summary>
        /// UTC timestamp expressed as a long integer - recorded at the time of capture
        /// </summary>
        public long TimeCaptured { get; set; }

        /// <summary>
        /// Represents the HTTP verb that was used in this request
        /// </summary>
        public string HttpVerb { get; set; }

        /// <summary>
        /// The full URI of the HTTP request, including host and port.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Contains the path and query string of a given URL
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// The user agent for this request
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// Collection of all of the HTTP headers for this request
        /// </summary>
        public IDictionary<string, string> HttpHeaders { get; private set; }

        /// <summary>
        /// The raw HTTP body of the request
        /// </summary>
        public string Body { get; set; }
    }

    /// <summary>
    /// Used to represent <see cref="CapturedHttpRequest"/> instances that were not found upon lookup.
    /// </summary>
    public class MissingCapturedHttpRequest : CapturedHttpRequest, IMissingObject
    {
        // ReSharper disable once InconsistentNaming
        private static readonly MissingCapturedHttpRequest _instance = new MissingCapturedHttpRequest();

        public static MissingCapturedHttpRequest Instance
        {
            get { return _instance; }
        }

        private MissingCapturedHttpRequest()
        {
        }
    }
}
