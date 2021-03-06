using MaxiPago.Gateway;
using MaxiPago.DataContract.NonTransactional;

namespace MaxiPagoExample 
{
  class Program 
  {
    static void Main(string[] args) 
    {
      Api api = new Api();
      api.Environment = "TEST";
      
      ApiResponse response = api.DeleteConsumer(
        "100", // 'merchantId' - REQUIRED: Merchant ID assigned by maxiPago! //
        "merchant-key", // 'merchantKey' - REQUIRED: Merchant Key assigned by maxiPago! //
        "2938293" // 'customerId'- REQUIRED: Customer ID create by maxiPago! after the "add-customer" command //
      );
      
      if (response.ErrorCode == "0") {
        // Success
      }
      else {
        // Fail
      }
    }
  }
}