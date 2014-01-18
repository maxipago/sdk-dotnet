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
      
      ResponseBase response = transaction.Auth(
        "100", // 'merchantId' - REQUIRED: Merchant ID assigned by maxiPago!  //
        "merchant-key", // 'merchantKey' - REQUIRED: Merchant Key assigned by maxiPago! //
        "ORD4828381B", // 'referenceNum' - REQUIRED: Merchant internal order number //
        432.31, // 'chargeTotal' - REQUIRED: Transaction amount in US format //
        "1", // 'processorId' - REQUIRED: Acquirer code for routing transactions. Use '1' for testing. //
        "eBUv/SIBJv0=", // 'token' - REQUIRED: Credit card token assigned by maxiPago! //
        "999", // 'customerId' - REQUIRED: Customer ID created by maxiPago! //
        "2", // 'numberOfInstallments' - Optional: Number of installments for credit card purchases ("parcelas") //
        // Send 'null' if no installments are used //
        "N", // 'chargeInterest' - Optional: Charge interest flag (Y/N) for installment purchase ("com" e "sem" juros) //
        "127.0.01", // 'ipAddress' - Optional //
        null, // 'customerIdExt' - Optional: Merchant internal customer number //
        "John Smith", // 'billingName' - RECOMMENDED: Customer name //
        "Rua de Teste, 123", // 'billingAddress' - Optional: Customer address //
        null, // 'billingAddress2' - Optional: Customer address //
        "Rio de Janeiro", // 'billingCity' - Optional: Customer city //
        "RJ", // 'billingState' - Optional: Customer state with 2 characters //
        "20030000", // 'billingPostalCode' - Optional: Customer zip code //
        "BR", // 'billingCountry' - Optional: Customer country per ISO 3166-2 //
        "551140634666", // 'billingPhone' - Optional: Customer phone number //
        "example@exaple.com", // 'billingEmail' - Optional: Customer email addres //
        "Jane Doe", // 'shippingName' - Optional: Shipping name //
        null, // 'shippingAddress' - Optional: Shipping address //
        null, // 'shippingAddress2' - Optional: Shipping address //
        null, // 'shippingCity' - Optional: Shipping city //
        null, // 'shippingState' - Optional: Shipping state with 2 characters //
        null, // 'shippingPostalCode' - Optional: Shipping zip code //
        null, // 'shippingCountry' - Optional: Shipping country per ISO 3166-2 //
        null, // 'shippingPhone' - Optional: Shipping phone number //
        null, // 'shippingEmail' - Optional: Shipping email address //
        "BRL", // 'currencyCode' - Optional: Currency code. Valid only for ChasePaymentech. Please see full documentation for more info //
		null, // 'softDescriptor' - Optional
		null // 'iataFee' - Optional		
      );
      
      if (response.IsTransactionResponse) {
      
        TransactionResponse result = response as TransactionResponse;
        
        if (result.ResponseCode == "0") {
          // Success
        }
        else {
          // Declined
        }
      }
      else if (response.IsErrorResponse) {
        ErrorResponse result = response as ErrorResponse;
        // Fail
      }
    }
  }
}