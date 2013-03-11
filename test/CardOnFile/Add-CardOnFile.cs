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

            ApiResponse response = api.AddCardOnFile(
                "merchantId", // REQUIRED - Merchant ID assigned by maxiPago! //
                "merchantKey", // REQUIRED - Merchant Key assigned by maxiPago! //
                "customerId", // REQUIRED - Internal merchant customer code //
                "creditCardNumber", // REQUIRED - Full credit card number //
                "expirationMonth", // REQUIRED - Credit card expiration month //
                "expirationYear", // REQUIRED - Credit card expiration year //
                "billingName", // REQUIRED - Customer name //
                "billingAddress1", // REQUIRED - Customer address //
                "billingAddress2", // Optional - Customer address 2 //
                "billingCity", // REQUIRED - Customer city //
                "billingState", // REQUIRED - Customer state with 2 characters //
                "billingZip", // REQUIRED - Customer zip code //
                "billingCountry", // REQUIRED - Customer country code per ISO 3166-2 //
                "billingPhone", // REQUIRED - Customer phone number //
                "billingEmail", // REQUIRED - Customer email address //
				"2015-12-25", // 'onFileEndDate' - Optional: date we no longer accept transactions with this card//
				null, // 'onFilePermissions' - Optional: permission option for this card. Default is 'null' //
				"Card belongs to John Doe", // 'onFileComments' - Optional: comments associated with this card //
				"1000.00" // 'onFileMaxChargeAmount' - Optional: maximum amount this card can be charged //
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