using Newtonsoft.Json;
using PAYNLSDK.Utilities;
using System.Collections.Specialized;
using PAYNLSDK.Exceptions;

namespace PAYNLSDK.API.PaymentProfile.Get
{
	public class Request : RequestBase
    {
        [JsonProperty("paymentProfileId")]
        public int PaymentProfileId { get; set; }

        public override int Version
        {
            get { return 1; }
        }

        public override string Controller
        {
            get { return "PaymentProfile"; }
        }

        public override string Method
        {
            get { return "get"; }
        }

        public override string Querystring
        {
            get { return ""; }
        }

        public override NameValueCollection GetParameters()
        {
            NameValueCollection nvc = base.GetParameters();

            ParameterValidator.IsNotNull(PaymentProfileId, "PaymentProfileId");
            nvc.Add("paymentProfileId", PaymentProfileId.ToString());

            return nvc;
        }

        public Response Response { get { return (Response)response; } }


        public override void SetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
            {
                throw new ErrorException("rawResponse is empty!");
            }
			Objects.PaymentProfile pm = JsonConvert.DeserializeObject<Objects.PaymentProfile>(RawResponse);
            Response r = new Response();
            r.PaymentProfile = pm;
            response = r;
        }
    }
}
