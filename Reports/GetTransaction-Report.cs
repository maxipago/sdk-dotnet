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

            RapiResponse response = report.GetTransactionDetailReport("merchantId", "merchantKey", "transactionId");

            if (response.Header.ErrorCode == "0") {
                // Success
            }
            else { 
                // Fail
            }
        }
    }
}