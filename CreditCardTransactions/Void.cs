using MaxiPago.DataContract;
using MaxiPago.Gateway; 
using MaxiPago.DataContract.Transactional;

namespace MaxiPagoExample 
{
    class Program 
    {
        static void Main(string[] args) 
        {
            Transaction transaction = new Transaction();
            transaction.Environment = "TEST";

            ResponseBase response = transaction.Void(
                "merchantId", // REQUIRED - Merchant ID assigned by maxiPago!  //
                "merchantKey", // REQUIRED - Merchant Key assigned by maxiPago! //
				"transactionID", // REQUIRED - Transaction ID created by maxiPago! //
				"ipAddress" // Optional //
			);

            if (response.IsTransactionResponse)   {
                TransactionResponse result = response as TransactionResponse;

                if (result.ResponseCode == "0")  {
                    // Success
                }
                else { 
                    // Declined
                }
            }
            else if (response.IsErrorResponse)   {
                ErrorResponse result = response as ErrorResponse;
                // Fail
            }
        }
    }
}