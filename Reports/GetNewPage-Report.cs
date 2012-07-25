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

            RapiResponse response = report.GetTransactionDetailReport(
                "merchantId", // REQUIRED - Merchant ID assigned by maxiPago!  //
                "merchantKey", // REQUIRED - Merchant Key assigned by maxiPago! //
				"pageToken", // REQUIRED - Token of the page replied by maxiPago! //
				"pageNumber" // REQUIRED - PAge number you want to view //
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