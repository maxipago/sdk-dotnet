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
        "100", // 'merchantId' - REQUIRED: Merchant ID assigned by maxiPago!  //
        "merchant-key", // 'merchantKey' - REQUIRED: Merchant Key assigned by maxiPago! //
        "293823", // 'transactionID' - REQUIRED: Transaction ID created by maxiPago! //
        "127.0.0.1" // 'ipAddress' - Optional //
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