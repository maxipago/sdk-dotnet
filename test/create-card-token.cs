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
        "100", // 'merchantId' - REQUIRED: Merchant ID assigned by maxiPago! //
        "merchant-key", // 'merchantKey' - REQUIRED: Merchant Key assigned by maxiPago! //
        "29387292", // 'customerId' - REQUIRED and UNIQUE: Internal merchant customer code //
        "4111111111111111", // 'creditCardNumber' - REQUIRED: Full credit card number //
        "10", // 'expirationMonth' - REQUIRED: Credit card expiration month with 2 digits //
        "2012", // 'expirationYear' - REQUIRED: Credit card expiration year with 4 digits //
        "John Doe", // 'billingName' -  REQUIRED: Customer name //
        "Rua de Teste, 123", // 'billingAddress1' - REQUIRED: Customer address //
        "Sala 12", // 'billingAddress2' - Optional: Customer address 2 //
        "Rio de Janeiro", // 'billingCity' - REQUIRED: Customer city //
        "RJ", // 'billingState' - REQUIRED: Customer state with 2 characters //
        "20030000", // 'billingZip' - REQUIRED: Customer zip code //
        "BR", // 'billingCountry' - REQUIRED: Customer country code per ISO 3166-2 //
        "551140634666", // 'billingPhone' - REQUIRED: Customer phone number //
        "example@example.com", // 'billingEmail' - REQUIRED: Customer email address //
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