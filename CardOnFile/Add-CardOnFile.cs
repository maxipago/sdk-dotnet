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

ApiResponse response = api.AddCardOnFile("merchantId", "merchantKey", "customerId", "creditCardNumber", "expirationMonth", "expirationYear", "billingName", "billingAddress1", "billingAddress2", "billingCity", "billingState", "billingZip", "billingCountry", "billingPhone", "billingEmail");

            if (response.ErrorCode == "0") {
                // Success
            }
            else {
                // Fail
            }
        }
    }
}