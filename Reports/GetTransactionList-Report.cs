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

RapiResponse response = report.GetTransactionDetailReport("merchantId", "merchantKey", "period", "pageSize", "startDate", "endDate",  "startTime", "endTime" , "orderByName", "orderByDirection", "startRecordNumber", "endRecordNumber");

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