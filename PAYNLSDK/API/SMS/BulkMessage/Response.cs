﻿using Newtonsoft.Json;
using PAYNLSDK.Converters;

namespace PAYNLSDK.API.SMS.BulkMessage
{
	public class Response : ResponseBase
    {
        [JsonProperty("result"),JsonConverter(typeof(BooleanConverter))]
        public bool result { get; protected set; }
    }
}
