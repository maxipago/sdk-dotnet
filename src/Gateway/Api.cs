using MaxiPago.DataContract;
using MaxiPago.DataContract.NonTransactional;
using MaxiPago.DataContract.Transactional;
using System;

namespace MaxiPago.Gateway
{

    public class Api : ServiceBase
    {

        public Api()
        {
            this.Environment = "TEST";
        }

        private ApiRequest request;

        public ApiResponse AddConsumer(String merchantId, String merchantKey, String customerIdExt, String firstName, String lastName
                                        , String address1, String address2, String city, String state, String zip, String phone, String email
                                        , String dob, String ssn, String sex)
        {


            this.request = new ApiRequest(merchantId, merchantKey);

            this.request.Command = "add-consumer";
            CommandRequest commandRequest = new CommandRequest();
            this.request.CommandRequest = commandRequest;

            commandRequest.CustomerIdExt = customerIdExt;
            commandRequest.FirstName = firstName;
            commandRequest.LastName = lastName;
            commandRequest.Address1 = address1;
            commandRequest.Address2 = address2;
            commandRequest.City = city;
            commandRequest.State = state;
            commandRequest.Zip = zip;
            commandRequest.Phone = phone;
            commandRequest.Email = email;
            commandRequest.Dob = dob;
            commandRequest.Ssn = ssn;
            commandRequest.Sex = sex;

            return new Utils().SendRequest<ApiRequest>(this.request, this.Environment) as ApiResponse;
        }

        public ApiResponse DeleteConsumer(String merchantId, String merchantKey, String customerId)
        {

            this.request = new ApiRequest(merchantId, merchantKey);

            this.request.Command = "delete-consumer";
            CommandRequest commandRequest = new CommandRequest();
            this.request.CommandRequest = commandRequest;

            commandRequest.CustomerId = customerId;

            return new Utils().SendRequest<ApiRequest>(this.request, this.Environment) as ApiResponse;

        }

        public ApiResponse UpdateConsumer(String merchantId, String merchantKey, String customerId, String customerIdExt, String firstName
                                        , String lastName, String address1, String address2, String city, String state, String zip, String phone
                                        , String email, String dob, String ssn, String sex)
        {

            this.request = new ApiRequest(merchantId, merchantKey);

            this.request.Command = "update-consumer";
            CommandRequest commandRequest = new CommandRequest();
            this.request.CommandRequest = commandRequest;

            commandRequest.CustomerId = customerId;
            commandRequest.CustomerIdExt = customerIdExt;
            commandRequest.FirstName = firstName;
            commandRequest.LastName = lastName;
            commandRequest.Address1 = address1;
            commandRequest.Address2 = address2;
            commandRequest.City = city;
            commandRequest.State = state;
            commandRequest.Zip = zip;
            commandRequest.Phone = phone;
            commandRequest.Email = email;
            commandRequest.Dob = dob;
            commandRequest.Ssn = ssn;
            commandRequest.Sex = sex;

            return new Utils().SendRequest<ApiRequest>(this.request, this.Environment) as ApiResponse;

        }

        public ApiResponse AddCardOnFile(String merchantId, String merchantKey, String customerId, String creditCardNumber, String expirationMonth
                                        , String expirationYear, String billingName, String billingAddress1, String billingAddress2, String billingCity
                                        , String billingState, String billingZip, String billingCountry, String billingPhone, String billingEmail
                                        , String onFileEndDate, String onFilePermission, String onFileComment, String onFileMaxChargeAmount)
        {

            this.request = new ApiRequest(merchantId, merchantKey);

            this.request.Command = "add-card-onfile";
            CommandRequest commandRequest = new CommandRequest();
            this.request.CommandRequest = commandRequest;

            commandRequest.CustomerId = customerId;
            commandRequest.CreditCardNumber = creditCardNumber;
            commandRequest.ExpirationMonth = expirationMonth;
            commandRequest.ExpirationYear = expirationYear;
            commandRequest.BillingName = billingName;
            commandRequest.BillingAddress1 = billingAddress1;
            commandRequest.BillingAddress2 = billingAddress2;
            commandRequest.BillingCity = billingCity;
            commandRequest.BillingState = billingState;
            commandRequest.BillingZip = billingZip;
            commandRequest.BillingCountry = billingCountry;
            commandRequest.BillingPhone = billingPhone;
            commandRequest.BillingEmail = billingEmail;
            commandRequest.OnFileEndDate = onFileEndDate;
            commandRequest.OnFilePermission = onFilePermission;
            commandRequest.OnFileComment = onFileComment;
            commandRequest.OnFileMaxChargeAmount = onFileMaxChargeAmount;

            return new Utils().SendRequest<ApiRequest>(this.request, this.Environment) as ApiResponse;

        }

        public ApiResponse DeleteCardOnFile(String merchantId, String merchantKey, String customerId, String token)
        {

            this.request = new ApiRequest(merchantId, merchantKey);

            this.request.Command = "delete-card-onfile";
            CommandRequest commandRequest = new CommandRequest();
            this.request.CommandRequest = commandRequest;

            commandRequest.CustomerId = customerId;
            commandRequest.Token = token;

            return new Utils().SendRequest<ApiRequest>(this.request, this.Environment) as ApiResponse;

        }

        public ApiResponse CancelRecurring(String merchantId, String merchantKey, String orderID)
        {

            this.request = new ApiRequest(merchantId, merchantKey);

            this.request.Command = "cancel-recurring";
            CommandRequest commandRequest = new CommandRequest();
            commandRequest.orderID = orderID;
            this.request.CommandRequest = commandRequest;

            return new Utils().SendRequest<ApiRequest>(this.request, this.Environment) as ApiResponse;

        }


        public ApiResponse AddPaymentOrder(String merchantId, String merchantKey, String requestReferenceNum, String requestFraudCheck
                                    , String billingAddress, String billingAddress2, String billingDistrict, String billingCity
                                    , String billingState, String billingPostalCode, String billingCountry, String billingEmail
                                    , String billingCustomerIdExt, String billingFirstName, String billingLastName, String billingDob
                                    , String billingSex, String billingPhone, String detailDescription, String detailComments
                                    , String detailEmailSubject, String detailExpirationDate, String creditCardProcessorID, String creditCardOperation
                                    , String creditCardNumberOfInstallments, String creditCardCurrencyCode, String creditCardAmount)
        {
            this.request = new ApiRequest(merchantId, merchantKey);

            this.request.Command = "add-payment-order";

            CommandRequest request = new CommandRequest();

            request.ReferenceNum = requestReferenceNum;
            request.FraudCheck = requestFraudCheck;

            this.request.CommandRequest = request;

            Billing billing = new Billing();

            billing.Address1 = billingAddress;
            billing.Address2 = billingAddress2;
            billing.District = billingDistrict;
            billing.City = billingCity;
            billing.State = billingState;
            billing.Postalcode = billingPostalCode;
            billing.Country = billingCountry;
            billing.Email = billingEmail;
            billing.CustomerIdExt = billingCustomerIdExt;
            billing.FirstName = billingFirstName;
            billing.LastName = billingLastName;
            billing.Dob = billingDob;
            billing.Sex = billingSex;
            billing.Phone = billingPhone;

            request.Billing = billing;

            TransactionDetail detail = new TransactionDetail();

            detail.Description = detailDescription;
            detail.Comments = detailComments;
            detail.EmailSubject = detailEmailSubject;
            detail.ExpirationDate = detailExpirationDate;


            PayType payType = new PayType();

            CreditCard creditCard = new CreditCard();

            creditCard.ProcessorID = creditCardProcessorID;
            creditCard.Operation = creditCardOperation;
            creditCard.NumberOfInstallments = creditCardNumberOfInstallments;
            creditCard.CurrencyCode = creditCardCurrencyCode;
            creditCard.Amount = creditCardAmount;
            creditCard.ECommInd = null;

            payType.CreditCard = creditCard;

            detail.PayType = payType;

            request.TransactionDetail = detail;

            return new Utils().SendRequest<ApiRequest>(this.request, this.Environment) as ApiResponse;
        }

    }
}
