using MaxiPago.Gateway;
using MaxiPago.DataContract.NonTransactional;


namespace MaxiPagoExample
{
  class Program
  {
    static void Main(string[] args)
    {
    
      Api api = new Api();
      ApiResponse apiResponse = api.CancelRecurring(
        "100", // 'merchantId' - REQUIRED: Merchant ID assigned by maxiPago! //
        "merchant-key", // 'merchantKey' - REQUIRED: Merchant Key assigned by maxiPago! //
        "C0A8C866:0119C7CF0530:3B39:009770A3" // 'OrderID' - REQUIRED: OrderID assigned by maxiPago! when creating the transaction //
      );
      
      if (apiResponse.ErrorMessage == "0") {
        // Success
      }
      else {
        // Fail
      }
    
    }
  }
}