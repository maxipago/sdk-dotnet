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
        "100", // 'merchantId' - REQUIRED: Merchant ID assigned by maxiPago!  //
        "merchant-key", // 'merchantKey' - REQUIRED: Merchant Key assigned by maxiPago! //
        "392734" // 'transactionId' - REQUIRED:  Transaction ID created by maxiPago! //
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