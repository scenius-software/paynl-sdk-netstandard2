using PAYNLSDK.Net;

namespace PAYNLSDK
{
	public class Banktransfer
    {
        static public API.Banktransfer.Add.Response Add(API.Banktransfer.Add.Request request)
        {
            Client c = new Client("", "");
            c.PerformRequest(request);
            return request.Response;
        }

        static public API.Banktransfer.Add.Response Add(int amount, string bankAccountHolder, string bankAccountNumber, string bankAccountBic)
        {
            Client c = new Client("", "");
            var request = new API.Banktransfer.Add.Request(amount, bankAccountHolder, bankAccountNumber, bankAccountBic);
            c.PerformRequest(request);
            return request.Response;
        }
    }
}
