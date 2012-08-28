using MaxiPago.Gateway;
using MaxiPago.DataContract.Reports;

namespace MaxiPagoExample 
{
    class Program 
    {
        static void Main(string[] args) 
        {
            Report report = new Report();
            report.Environment = "TEST";

            RapiResponse response = report.CheckRequestStatus(
                "merchantId", // REQUIRED - Merchant ID assigned by maxiPago!  //
                "merchantKey", // REQUIRED - Merchant Key assigned by maxiPago! //
				"requestToken" // REQUIRED - Request token created by maxiPago! //
			);

            if (response.Header.ErrorCode == "0") {
                // Success
            }
            else { 
                // Fail
            }
        }
    }
}