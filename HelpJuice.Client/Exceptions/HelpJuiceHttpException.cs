using System;
using System.Net;

namespace HelpJuice.Client.Exceptions
{
    public class HelpJuiceHttpException : Exception
    {
        public HelpJuiceHttpException(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; set; }
    }
}