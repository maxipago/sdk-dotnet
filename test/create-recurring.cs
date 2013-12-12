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
      
      ResponseBase response = transaction.Recurring(
        "100", // 'merchantId' - REQUIRED: Merchant ID assigned by maxiPago!  //
        "merchant-key", // 'merchantKey' - REQUIRED: Merchant Key assigned by maxiPago! //
        "ORD22382820", // 'referenceNum' - REQUIRED: Merchant internal order number //
        150.00, // 'chargeTotal' - REQUIRED: Transaction amount in US format //
        "5555555555554444", // 'creditCardNumber' - REQUIRED: Full credit card number //
        "10", // 'expMonth' - REQUIRED: Credit card expiration month with 2 digits //
        "2020", // 'expYear' - REQUIRED: Credit card expiration year with 4 digits //
        null, // 'cvvInd' - Optional: Indicator of absense of CVV code  //
        "123", // 'cvvNumber' - RECOMMENDED: Credit card verification number //
        "1", // 'processorId' - REQUIRED: Acquirer code to route transaction. Use '1' for testing. //
        "2", // 'numberOfInstallments' - Optional: Number of installments for credit card purchases ("parcelas") //
        "N", // 'chargeInterest' - Optional: Charge interest flag (Y/N) for installment purchase ("com" e "sem" juros) //
        "127.0.0.1", // 'ipAddress' - Optional //
        null // 'customerIdExt' - Optional, Merchant internal customer number // 
        "new", // 'action' - REQUIRED for this command - Always 'new' //
        "2013-12-25", // 'startDate' - REQUIRED: Date of the 1st purchase (YYYY-MM-DD format) //
        "1", // 'frequency' - REQUIRED: Billing frequency ("1", "3", "6", ...) //
        "monthly", // 'period' - REQUIRED: Period of billing ("daily", "weekly" or "monthly") //
        "12", // 'installments' - REQUIRED: Number of payments to be executed //
        "2" // 'failureThreshold' - REQUIRED: Number of retries if transaction fails //
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