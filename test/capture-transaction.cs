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
        "100", // 'merchantId' - REQUIRED: Merchant ID assigned by maxiPago!  //
        "merchant-key", // 'merchantKey' - REQUIRED: Merchant Key assigned by maxiPago! //
        "7F000001:013829A1C09E:8DE9:016891F0", // 'orderID'- REQUIRED: Order ID replied by maxiPago! after authorization //
        "ORD12397372", // 'referenceNum' - REQUIRED: Merchant internal order number //
        "23.33" // 'chargeTotal' - REQUIRED: Transaction amount in US format //
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