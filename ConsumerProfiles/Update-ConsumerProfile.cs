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

ApiResponse response = api.UpdateConsumer("merchantId", "merchantKey", "customerId", "customerIdExt", "firstName", "lastName", "address1", "address2", "city", "state", "zipCode", "phone", "email", "dob", "ssn", "sex");

            if (response.ErrorCode == "0") {
                // Success
            }
            else {
                // Fail
            }
        }
    }
}