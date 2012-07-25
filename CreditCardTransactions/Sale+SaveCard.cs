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
                "creditCardNumber", // REQUIRED - Full credit card number //
                "expMonth", // REQUIRED - Credit card expiration month //
                "expYear", // REQUIRED - Credit card expiration year //
                "cvvInd", // Optional - Indicator of absense of CVV code  //
                "cvvNumber", // RECOMMENDED - Credit card verification number //
                "processorId", // REQUIRED - Use '1' for testing. Contact our team for production values //
                "numberOfInstallment", // Optional - Number of installments for credit card purchases ("parcelas") //
                "chargeInterest", // Optional - Charge interest lfag (Y/N) for installment purchase ("com" e "sem" juros) //
                "ipAddress", // Optional //
				"customerToken", // REQUIRED - Customer ID created by maxiPago! //
                "onFileEndDate", // Optional - Date the credit card token will no longer be available for use //
                "onFilePermission", // Optional - Sets period of use of token: 'ongoing' or 'use_once' //
                "onFileComment", // Optional //
                "onFileMaxChargeAmount", // Optional - Maximum amount this card can be charged //
                "billingName", // RECOMMENDED - Customer name //
                "billingAddress", // Optional - Customer address //
                "billingAddress2", // Optional - Customer address //
                "billingCity", // Optional - Customer city //
                "billingState", // Optional - Customer state with 2 characters //
                "billingPostalCode", // Optional - Customer zip code //
                "billingCountry", // Optional - Customer country per ISO 3166-2 //
                "billingPhone", // Optional - Customer phone number //
                "billingEmail" // Optional - Customer email address //
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
a
b
