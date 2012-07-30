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
				"merchantId", // Merchant ID assigned by maxiPago! //
				"merchantKey", // Merchant Key assigned by maxiPago! //
				"OrderID" // OrderID assigned by maxiPago! when creating the transaction //
			);
 
            if (apiResponse.ErrorMessage == "0")
            {
                // Success
            }
            else
            {
                // Fail
            }
               
        }
    }
}