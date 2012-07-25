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

            ApiResponse response = api.UpdateConsumer(
            "merchantId", // REQUIRED - Merchant ID assigned by maxiPago! //
                "merchantKey", // REQUIRED - Merchant Key assigned by maxiPago! //
                "customerIdExt", // Optional - Internal merchant customer code //
                "firstName", // REQUIRED - Customer first name //
                "lastName", // REQUIRED - Customer last name //
                "address1", // Optional - Customer address //
                "address2", // Optional - Customer address //
                "city", // Optional - Customer city //
                "state", // Optional - Customer state with 2 characters //
                "zipCode", // Optional - Customer zip code //
                "phone", // Optional - Customer phone number //
                "email", // Optional - Customer email address //
                "dob", // Optional - Customer date of birth (MM-DD-YYYY) //
                "ssn", // Optional - Customer official ID number //
                "sex" // Optional - Customer gender (M/F) //
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