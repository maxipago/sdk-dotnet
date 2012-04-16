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

            ResponseBase response = transaction.Sale("merchantId", "merchantKey", "referenceNum", "chargeTotal", "creditCardNumber", "expMonth", "expYear", "cvvInd",  "cvvNumber", "processorId", "numberOfInstallments", "chargeInterest", "ipAddress", "customerToken", "onFileEndDate", "onFilePermission", "onFileComment", "onFileMaxChargeAmount", "billingName", "billingAddress", "billingAddress2", "billingCity", "billingState", "billingPostalCode", "billingCountry", "billingPhone", "billingEmail");

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
