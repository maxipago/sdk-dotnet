using MaxiPago.DataContract;
using MaxiPago.Gateway;

namespace MaxiPagoExample 
{
    class Program 
    {
        static void Main(string[] args) 
        {
            Transaction transaction = new Transaction();
            transaction.Environment = "TEST";

              ResponseBase response = transaction.Auth(
                "merchantId", // REQUIRED - Merchant ID assigned by maxiPago!  //
                "merchantKey", // REQUIRED - Merchant Key assigned by maxiPago! //
                "referenceNum", // REQUIRED - Merchant internal order number //
                "chargeTotal", // REQUIRED - Transaction amount in US format //
                "creditCardNumber", // REQUIRED - Full credit card number //
                "expMonth", // REQUIRED - Credit card expiration month //
                "expYear", // REQUIRED - Credit card expiration year //
                "cvvInd", // Optional - Indicator of absense of CVV code  //
                "cvvNumber", // RECOMMENDED - Credit card verification number //
                "authentication", // Optional - Valid only for Cielo. Please see full documentation for more info //
                "processorId", // REQUIRED - Use '1' for testing. Contact our team for production values //
                "numberOfInstallment", // Optional - Number of installments for credit card purchases ("parcelas") //
                "chargeInterest", // Optional - Charge interest lfag (Y/N) for installment purchase ("com" e "sem" juros) //
                "ipAddress", // Optional //
                "customerIdExt" // Optional, Merchant internal customer number //
            );

			// FULL WORKING EXAMPLE
			//
			//	ResponseBase response = transaction.Auth(
			//	merchantId: "100",
			//	merchantKey: "secret-key",
			//	referenceNum: "TestTransaction123",
			//	chargeTotal: 1.00,
			//	creditCardNumber: "5555555555554444",
			//	expMonth: "10",
			//	expYear: "2020",
			//	cvvInd: "",
			//	cvvNumber: "123",
			//	authentication: "noAuthentication",
			//	processorID: "1",
			//	numberOfInstallments: "2",
			//	chargeInterest: "N",
			//	ipAddress: "123.123.123.123",
			//	customerIdExt: ""
			//	);

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