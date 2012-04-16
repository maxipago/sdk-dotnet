using MaxiPago.DataContract;
using MaxiPago.Gateway;

namespace MaxiPagoExample 
{
    class Program 
    {
        static void Main(string[] args) 
        {
            Transaction transaction = new Transaction();
            transaction.Environment = "TEST";

              ResponseBase response = transaction.Auth("merchantId", "merchantKey", "referenceNum", "chargeTotal", "creditCardNumber", "expMonth", "expYear", "cvvInd", "cvvNumber", "authentication", "processorId", "numberOfInstallment", "chargeInterest", "ipAddress", "customerIdExt"); 

            if (response.IsTransactionResponse) {
                TransactionResponse result = response as TransactionResponse;

                if (result.ResponseCode == "0") {
                    // Success
                }
                else { 
                    // Decline
                }
            }
            else if (response.IsErrorResponse) {
                ErrorResponse result = response as ErrorResponse;
                // Fail
            }
        }
    }
}