using Newtonsoft.Json;
using PAYNLSDK.Utilities;
using PAYNLSDK.Exceptions;

namespace PAYNLSDK.API.PaymentProfile.GetAll
{
	public class Request : RequestBase
    {
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
            get { return "getAll"; }
        }

        public override string Querystring
        {
            get { return ""; }
        }

        public Response Response { get { return (Response)response; } }

        public override void SetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
            {
                throw new ErrorException("rawResponse is empty!");
            }
			Objects.PaymentProfile[] pm = JsonConvert.DeserializeObject<Objects.PaymentProfile[]>(RawResponse);
            Response r = new Response();
            r.PaymentProfiles = pm;
            response = r;
        }
    }
}
