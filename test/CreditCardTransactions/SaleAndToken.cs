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
                "chargeInterest", // Optional - Charge interest flag (Y/N) for installment purchase ("com" e "sem" juros) //
                "ipAddress", // Optional //
				"customerIdExt", // Optional, Merchant internal customer number //
				"billingName", // RECOMMENDED - Customer name //
				"billingAddress", // Optional - Customer address //
				"billingAddress2", // Optional - Customer address //
				"billingCity", // Optional - Customer city //
				"billingState", // Optional - Customer state with 2 characters //
				"billingPostalCode", // Optional - Customer zip code //
				"billingCountry", // Optional - Customer country per ISO 3166-2 //
				"billingPhone", // Optional - Customer phone number //
				"billingEmail", // Optional - Customer email addres //
				"shippingName", // Optional - Shipping name //
				"shippingAddress", // Optional - Shipping address //
				"shippingAddress2", // Optional - Shipping address //
				"shippingCity", // Optional - Shipping city //
				"shippingState", // Optional - Shipping state with 2 characters //
				"shippingPostalCode", // Optional - Shipping zip code //
				"shippingCountry", // Optional - Shipping country per ISO 3166-2 //
				"shippingPhone", // Optional - Shipping phone number //
				"shippingEmail", // Optional - Shipping email address //
				"currencyCode" // Optional - Currency code. Valid only for ChasePaymentech. Please see full documentation for more info //
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