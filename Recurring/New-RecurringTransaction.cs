using MaxiPago.Gateway;
using MaxiPago.DataContract;
using MaxiPago.DataContract.Transactional;

namespace MaxiPagoExample 
{
    class Program 
    {
        static void Main(string[] args)   
        {
            Transaction transaction = new Transaction();
            transaction.Environment = "TEST";

ResponseBase response = transaction.Recurring("merchantId", "merchantKey", "referenceNum",  "chargeTotal", "creditCardNumber", "expMonth", "expYear", "cvvInd", "cvvNumber", "processorId", "numberOfInstallments", "chargeInterest", "ipAddress", "customerIdExt", "action" , "startDate", "frequency", "period", "installments", "failureThreshold");

            if (response.IsTransactionResponse) {
                
                TransactionResponse result = response as TransactionResponse;

                if (result.ResponseCode == "0") {
                    // Success
                }
                else {
                    // Declined
                }
            }
            else if (response.IsErrorResponse) {
                ErrorResponse result = response as ErrorResponse;
                // Fail
            }
        }
    }
}