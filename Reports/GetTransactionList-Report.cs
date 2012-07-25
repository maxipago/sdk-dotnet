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
				"period", // REQUIRED - Period of search ("today", "yesterday", "range") //
				"pageSize", // Optional - Number of transactions per page. Max of 100 //
				"startDate", // REQUIRED if period=range - Start date for filter //
				"endDate", // REQUIRED if period=range - End date for filter //
				"startTime", // REQUIRED if period=range - Start time for filter //
				"endTime", // REQUIRED if period=range - End time for filter //
				"orderByName", // Optional - Field to order transactions by ("transactionDate", "status", etc) //
				"orderByDirection", // Optional - Direction of order ("asc" or "desc") //
				"startRecordNumber", // Optional - '1' by default //
				"endRecordNumber" // Optional - null by default //
			);

if (response.Header.ErrorCode == "0") {

                if (response.Result.RequestToken == null) {
                    // Success
                }
                else {
                    // If response.Result.RequestToken != null you must check back later with 'checkRequestStatus' 
                }

  }
  else { 
        // Fail
  }
        }
    }
}