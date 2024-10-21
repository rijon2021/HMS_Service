﻿using System;

namespace DotNet.ApplicationCore.DTOs
{
    public class TokenResult
    {
        public string Access_token { get; set; }
        public DateTime? Expiration { get; set; }
        public string UserEmail { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
