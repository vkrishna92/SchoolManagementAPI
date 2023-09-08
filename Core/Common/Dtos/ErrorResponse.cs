using System;
using System.Net;

namespace Core.Common.Dtos
{
	public class ErrorResponse
	{
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
    }
}

