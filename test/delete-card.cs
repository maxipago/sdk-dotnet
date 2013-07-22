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
      
      ApiResponse response = api.DeleteCardOnFile(
        "100", // 'merchantId' - REQUIRED: Merchant ID assigned by maxiPago! //
        "merchant-key", // 'merchantKey' - REQUIRED: Merchant Key assigned by maxiPago! //
        "238292", // 'customerId' - REQUIRED: Customer ID created by maxiPago! after the "add-customer" command //
        "eBUv/SIBJv0=" // 'token' - REQUIRED: Credit card token create by maxiPago! //
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