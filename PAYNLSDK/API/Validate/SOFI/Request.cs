﻿using Newtonsoft.Json;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;
using System.Collections.Specialized;

namespace PAYNLSDK.API.Validate.SOFI
{
	public class Request : RequestBase
    {
        [JsonProperty("sofi")]
        public string SOFI { get; set; }

        public override bool RequiresApiToken
        {
            get
            {
                return false;// base.RequiresApiToken;
            }
        }

        public override int Version
        {
            get { return 1; }
        }

        public override string Controller
        {
            get { return "Validate"; }
        }

        public override string Method
        {
            get { return "SOFI"; }
        }

        public override string Querystring
        {
            get { return ""; }
        }

        public override NameValueCollection GetParameters()
        {
            NameValueCollection nvc = base.GetParameters();

            ParameterValidator.IsNotEmpty(SOFI, "sofi");
            nvc.Add("sofi", SOFI);

            return nvc;
        }

        public Response Response { get { return (Response)response; } }

        public override void SetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
            {
                throw new ErrorException("rawResponse is empty!");
            }
            response = JsonConvert.DeserializeObject<Response>(RawResponse);
        }
    }
}
