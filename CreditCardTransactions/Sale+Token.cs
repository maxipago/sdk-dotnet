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

            ResponseBase response = transaction.Sale(
                "merchantId", // REQUIRED - Merchant ID assigned by maxiPago!  //
                "merchantKey", // REQUIRED - Merchant Key assigned by maxiPago! //
                "referenceNum", // REQUIRED - Merchant internal order number //
                "chargeTotal", // REQUIRED - Transaction amount in US format //
                "processorId", // REQUIRED - Use '1' for testing. Contact our team for production values //
				"token", // REQUIRED - Credit card token assigned by maxiPago! //
				"customerId", // REQUIRED - Customer ID created by maxiPago! //
                "numberOfInstallment", // Optional - Number of installments for credit card purchases ("parcelas") //
                "chargeInterest", // Optional - Charge interest lfag (Y/N) for installment purchase ("com" e "sem" juros) //
                "ipAddress", // Optional //
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