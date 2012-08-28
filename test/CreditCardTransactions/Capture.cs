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

            ResponseBase response = transaction.Capture(
                "merchantId", // REQUIRED - Merchant ID assigned by maxiPago!  //
                "merchantKey", // REQUIRED - Merchant Key assigned by maxiPago! //
				"orderID", // REQUIRED - Order ID replied by maxiPago! after authorization //
                "referenceNum", // REQUIRED - Merchant internal order number //
                "chargeTotal" // REQUIRED - Transaction amount in US format //
			);		

            if (response.IsTransactionResponse)  {
                TransactionResponse result = response as TransactionResponse;

                if (result.ResponseCode == "0")  {
                    // Success
                }
                else { 
                    // Decline
                }
            }
            else if (response.IsErrorResponse)  {
                ErrorResponse result = response as ErrorResponse;
                // Fail
            }
        }
    }
}