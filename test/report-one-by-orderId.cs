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
      
      RapiResponse response = report.GetTransactionDetailReportByOrderId(
        "100", // 'merchantId' - REQUIRED: Merchant ID assigned by maxiPago!  //
        "merchant-key", // 'merchantKey' - REQUIRED: Merchant Key assigned by maxiPago! //
        "C0A8016E:0143DF410A35:33D0:01A30706" // 'orderId' - REQUIRED:  Order ID created by maxiPago! //
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