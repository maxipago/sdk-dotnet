using MaxiPago.Gateway;
using MaxiPago.DataContract;
using MaxiPago.DataContract.Transactional;

namespace MaxiPagoExample
{
  class Program
  {
    static void Main(string[] args)
    {
      Transaction transaction = new Transaction();
      transaction.Environment = "TEST";
      
      ResponseBase response = transaction.Boleto(
        "100", // 'merchantId' - REQUIRED: Merchant ID assigned by maxiPago! //
        "merchant-key", // 'merchantKey' - REQUIRED: Merchant Key assigned by maxiPago! //
        "ORD238937282", // 'referenceNum' - REQUIRED: Merchant internal order number //
        10.00, // 'chargeTotal' - REQUIRED: Transaction amount in US format //
        "12", // 'processorId' - REQUIRED: Bank chosen to process transaction. Use '12' for Boleto testing. //
        "127.0.0.1", // 'ipAddress' - Optional //
        "CUST12739", // 'customerIdExt' - Optional: Merchant code for customer //
        "2013-12-25", // 'expirationDate' - REQUIRED: Boleto expiration date (YYYY-MM-DD format) //
        "01020304", // 'number' - REQUIRED and UNIQUE - Boleto ID number with maximum of 8 numbers //
        "Sr. Caixa, não aceitar pagamento em cheques;Boleto referente ao pedido 238937282", // Optional: Instructions printed in the boleto slip. Use ";" to break lines //
        "John Smith", // 'billingName' - REQUIRED: Customer name //
        "Rua de Teste, 123", // 'billingAddress' - Optional: Customer address //
        "Sala 13", // 'billingAddress2' - Optional: Customer address //
        "Rio de Janeiro", // 'billingCity' - Optional: Customer city //
        "RJ", // 'billingState' - Optional: Customer state with 2 characters //
        "20030000", // 'billingPostalCode' - Optional: Customer zip code //
        "BR", // 'billingCountry' - Optional: Customer country code per ISO 3166-2 //
        "551140634666", // 'billingPhone' - Optional: Customer phone number //
        "example@example.com" // 'billingEmail' - Optional: Customer email address //
      );
      
      if (response.IsTransactionResponse) {
      
        TransactionResponse result = response as TransactionResponse;
        
        if (result.ResponseCode == "0") {
          // Success
        }
        else {
          // Decline
        }
      }
      else if (response.IsErrorResponse) {
        ErrorResponse result = response as ErrorResponse;
        // Fail
      }
    }
  }
}