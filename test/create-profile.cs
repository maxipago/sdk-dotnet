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
      
      ApiResponse response = api.AddConsumer(
        "100", // 'merchantId' - REQUIRED: Merchant ID assigned by maxiPago! //
        "merchant-key", // 'merchantKey' - REQUIRED: Merchant Key assigned by maxiPago! //
        "2947293", // 'customerIdExt' - Optional: Internal merchant customer code //
        "John", // 'firstName' - REQUIRED: Customer first name //
        "Smith", // 'lastName' - REQUIRED: Customer last name //
        "Rua de Teste, 123", // 'address1' - Optional: Customer address //
        "Sala 13", // 'address2' - Optional: Customer address //
        "Rio de Janeiro", // 'city' - Optional: Customer city //
        "RJ", // 'state' - Optional: Customer state with 2 characters //
        "20030000", // 'zipCode' - Optional: Customer zip code //
        "551140634666", // 'phone' - Optional: Customer phone number //
        "example@example.com", // 'email' - Optional: Customer email address //
        "12/25/1970", //  'dob' - Optional: Customer date of birth (MM/DD/YYYY) //
        "2947392739383", // 'ssn' - Optional: Customer official ID number //
        "M" // 'sex' - Optional: Customer gender (M/F) //
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