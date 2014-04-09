using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MaxiPago.DataContract;
using System.Xml.Serialization;
using System.IO;
using System.Net;
using System.Threading;
using MaxiPago.DataContract.Transactional;

namespace MaxiPago.Gateway {

    public class Transaction : ServiceBase {

        public Transaction() {
            this.Environment = "TEST";
        }

        private TransactionRequest request;

        /// <summary>
        /// Faz uma autorização com captura.
        /// </summary>
        public ResponseBase Sale(String merchantId, String merchantKey, String referenceNum, decimal chargeTotal, String creditCardNumber
                , String expMonth, String expYear, String cvvInd, String cvvNumber, String authentication, String processorId
                , String numberOfInstallments, String chargeInterest, String ipAddress, String customerIdExt, String currencyCode
                , String fraudCheck, String softDescriptor, decimal? iataFee) {

            this.FillRequestBase("sale", merchantId, merchantKey, referenceNum, chargeTotal, creditCardNumber, expMonth, expYear
                , cvvInd, cvvNumber, authentication, processorId, numberOfInstallments, chargeInterest
                , ipAddress, customerIdExt, currencyCode, fraudCheck, softDescriptor, iataFee);

            return new Utils().SendRequest<TransactionRequest>(this.request, this.Environment);

        }

        /// <summary>
        /// Popula o objeto RequestBase em comum a todos.
        /// </summary>
        private void FillRequestBase(String operation, String merchantId, String merchantKey, String referenceNum, decimal chargeTotal, String creditCardNumber
                , String expMonth, String expYear, String cvvInd, String cvvNumber, String authentication, String processorId
                , String numberOfInstallments, String chargeInterest, String ipAddress, String customerIdExt, String currencyCode
                , String fraudCheck, String softDescriptor, decimal? iataFee) {

            this.request = new TransactionRequest(merchantId, merchantKey);

            Order order = this.request.Order;
            RequestBase rBase = new RequestBase();

            if (operation.Equals("sale"))
                order.Sale = rBase;
            else if (operation.Equals("auth"))
                order.Auth = rBase;

            rBase.ReferenceNum = referenceNum;
            rBase.ProcessorId = processorId;
            rBase.Authentication = authentication;
            rBase.IpAddress = ipAddress;
            rBase.CustomerIdExt = customerIdExt;
            rBase.FraudCheck = fraudCheck;

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Payment payment = new Payment();
            rBase.Payment = payment;
            payment.ChargeTotal = chargeTotal;
            payment.CurrencyCode = currencyCode;
            payment.SoftDescriptor = softDescriptor;
            payment.IataFee = iataFee;

            if (String.IsNullOrEmpty(numberOfInstallments))
                numberOfInstallments = "0";

            int tranInstallments = int.Parse(numberOfInstallments);

            //Verifica se vai precisar criar o nó de parcelas e juros.
            if (!String.IsNullOrEmpty(chargeInterest) && tranInstallments > 1) {
                payment.CreditInstallment = new CreditInstallment();
                payment.CreditInstallment.ChargeInterest = chargeInterest.ToUpper();
                payment.CreditInstallment.NumberOfInstallments = numberOfInstallments;
            }

            TransactionDetail detail = rBase.TransactionDetail;
            PayType payType = detail.PayType;

            CreditCard creditCard = new CreditCard();
            payType.CreditCard = creditCard;

            creditCard.CvvInd = cvvInd;
            creditCard.CvvNumber = cvvNumber;
            creditCard.ExpMonth = expMonth;
            creditCard.ExpYear = expYear;
            creditCard.Number = creditCardNumber;

        }

        /// <summary>
        /// Faz uma autorização com captura.
        /// </summary>
        public ResponseBase Sale(String merchantId, String merchantKey, String referenceNum, decimal chargeTotal, String creditCardNumber
                , String expMonth, String expYear, String cvvInd, String cvvNumber, String authentication, String processorId
                , String numberOfInstallments, String chargeInterest, String ipAddress, String customerIdExt, String billingName
                , String billingAddress, String billingAddress2, String billingCity, String billingState, String billingPostalCode
                , String billingCountry, String billingPhone, String billingEmail, String shippingName, String shippingAddress
                , String shippingAddress2, String shippingCity, String shippingState, String shippingPostalCode
                , String shippingCountry, String shippingPhone, String shippingEmail, String currencyCode, String fraudCheck
                , String softDescriptor, decimal? iataFee) {


            this.FillRequestBase("sale", merchantId, merchantKey, referenceNum, chargeTotal, creditCardNumber, expMonth, expYear
                    , cvvInd, cvvNumber, authentication, processorId, numberOfInstallments, chargeInterest
                    , ipAddress, customerIdExt, currencyCode, fraudCheck, softDescriptor, iataFee);

            RequestBase sale = this.request.Order.Sale;

            Billing billing = new Billing();
            sale.Billing = billing;

            billing.Address1 = billingAddress;
            billing.Address2 = billingAddress2;
            billing.City = billingCity;
            billing.Country = billingCountry;
            billing.Email = billingEmail;
            billing.Name = billingName;
            billing.Phone = billingPhone;
            billing.Postalcode = billingPostalCode;
            billing.State = billingState;

            Shipping shipping = new Shipping();
            sale.Shipping = shipping;

            shipping.Address1 = shippingAddress;
            shipping.Address2 = shippingAddress2;
            shipping.City = shippingCity;
            shipping.Country = shippingCountry;
            shipping.Email = shippingEmail;
            shipping.Name = shippingName;
            shipping.Phone = shippingPhone;
            shipping.Postalcode = shippingPostalCode;
            shipping.State = shippingState;

            return new Utils().SendRequest<TransactionRequest>(this.request, this.Environment);

        }

        /// <summary>
        /// Faz uma autorização com captura passando o token do cartão já salvo na base.
        /// </summary>
        public ResponseBase Sale(String merchantId, String merchantKey, String referenceNum, decimal chargeTotal, String processorId
                                , String token, String customerId, String numberOfInstallments, String chargeInterest, String ipAddress, String currencyCode
                                , String fraudCheck, String softDescriptor, decimal? iataFee) {


            return this.PayWithToken("sale", merchantId, merchantKey, referenceNum, chargeTotal, processorId, token, customerId
                                    , numberOfInstallments, chargeInterest, ipAddress, currencyCode, fraudCheck, softDescriptor, iataFee);

        }

        /// <summary>
        /// Faz uma autorização com captura salvando o número de cartão automaticamente.
        /// </summary>
        public ResponseBase Sale(String merchantId, String merchantKey, String referenceNum, decimal chargeTotal
                                   , String creditCardNumber, String expMonth, String expYear, String cvvInd, String cvvNumber
                                   , String processorId, String numberOfInstallments, String chargeInterest, String ipAddress
                                   , String customerToken, String onFileEndDate, String onFilePermission, String onFileComment
                                   , String onFileMaxChargeAmount, String billingName, String billingAddress, String billingAddress2
                                   , String billingCity, String billingState, String billingPostalCode, String billingCountry
                                   , String billingPhone, String billingEmail, String currencyCode, String fraudCheck
                                   , String softDescriptor, decimal? iataFee) {

            return PaySavingCreditCardAutomatically("sale", merchantId, merchantKey, referenceNum, chargeTotal, creditCardNumber, expMonth, expYear
                                                    , cvvInd, cvvNumber, processorId, numberOfInstallments, chargeInterest, ipAddress, customerToken
                                                    , onFileEndDate, onFilePermission, onFileComment, onFileMaxChargeAmount, billingName, billingAddress
                                                    , billingAddress2, billingCity, billingState, billingPostalCode, billingCountry, billingPhone, billingEmail
                                                    , currencyCode, fraudCheck, softDescriptor, iataFee);

        }

        /// <summary>
        /// Faz uma Autorização.
        /// </summary>
        public ResponseBase Auth(String merchantId, String merchantKey, String referenceNum, decimal chargeTotal, String creditCardNumber
                , String expMonth, String expYear, String cvvInd, String cvvNumber, String authentication, String processorId
                , String numberOfInstallments, String chargeInterest, String ipAddress, String customerIdExt, String currencyCode
                , String fraudCheck, String softDescriptor, decimal? iataFee) {

            this.FillRequestBase("auth", merchantId, merchantKey, referenceNum, chargeTotal, creditCardNumber, expMonth, expYear
                    , cvvInd, cvvNumber, authentication, processorId, numberOfInstallments
                    , chargeInterest, ipAddress, customerIdExt, currencyCode, fraudCheck, softDescriptor, iataFee);

            return new Utils().SendRequest<TransactionRequest>(this.request, this.Environment);

        }

        /// <summary>
        /// Faz uma Autorização.
        /// </summary>
        public ResponseBase Auth(String merchantId, String merchantKey, String referenceNum, decimal chargeTotal, String creditCardNumber
                , String expMonth, String expYear, String cvvInd, String cvvNumber, String authentication, String processorId
                , String numberOfInstallments, String chargeInterest, String ipAddress, String customerIdExt, String billingName
                , String billingAddress, String billingAddress2, String billingCity, String billingState, String billingPostalCode
                , String billingCountry, String billingPhone, String billingEmail, String shippingName, String shippingAddress
                , String shippingAddress2, String shippingCity, String shippingState, String shippingPostalCode, String shippingCountry
                , String shippingPhone, String shippingEmail, String currencyCode, String fraudCheck, String softDescriptor, decimal? iataFee) {

            this.FillRequestBase("auth", merchantId, merchantKey, referenceNum, chargeTotal, creditCardNumber, expMonth, expYear
                    , cvvInd, cvvNumber, authentication, processorId, numberOfInstallments
                    , chargeInterest, ipAddress, customerIdExt, currencyCode, fraudCheck, softDescriptor, iataFee);

            RequestBase auth = this.request.Order.Auth;

            Billing billing = new Billing();
            auth.Billing = billing;

            billing.Address1 = billingAddress;
            billing.Address2 = billingAddress2;
            billing.City = billingCity;
            billing.Country = billingCountry;
            billing.Email = billingEmail;
            billing.Name = billingName;
            billing.Phone = billingPhone;
            billing.Postalcode = billingPostalCode;
            billing.State = billingState;

            Shipping shipping = new Shipping();
            auth.Shipping = shipping;

            shipping.Address1 = shippingAddress;
            shipping.Address2 = shippingAddress2;
            shipping.City = shippingCity;
            shipping.Country = shippingCountry;
            shipping.Email = shippingEmail;
            shipping.Name = shippingName;
            shipping.Phone = shippingPhone;
            shipping.Postalcode = shippingPostalCode;
            shipping.State = shippingState;

            return new Utils().SendRequest<TransactionRequest>(this.request, this.Environment);

        }

        /// <summary>
        /// Faz uma autorização passando o token do cartão já salvo na base.
        /// </summary>
        public ResponseBase Auth(String merchantId, String merchantKey, String referenceNum, decimal chargeTotal, String processorId
                                , String token, String customerId, String numberOfInstallments, String chargeInterest, String ipAddress, String currencyCode
                                , String fraudCheck, String softDescriptor, decimal? iataFee) {


            return this.PayWithToken("auth", merchantId, merchantKey, referenceNum, chargeTotal, processorId, token, customerId
                                    , numberOfInstallments, chargeInterest, ipAddress, currencyCode, fraudCheck, softDescriptor, iataFee);

        }

        /// <summary>
        /// Faz uma autorização salvando o número de cartão automaticamente.
        /// </summary>
        public ResponseBase Auth(String merchantId, String merchantKey, String referenceNum, decimal chargeTotal
                                   , String creditCardNumber, String expMonth, String expYear, String cvvInd, String cvvNumber
                                   , String processorId, String numberOfInstallments, String chargeInterest, String ipAddress
                                   , String customerToken, String onFileEndDate, String onFilePermission, String onFileComment
                                   , String onFileMaxChargeAmount, String billingName, String billingAddress, String billingAddress2
                                   , String billingCity, String billingState, String billingPostalCode, String billingCountry
                                   , String billingPhone, String billingEmail, String currencyCode, String fraudCheck
                                   , String softDescriptor, decimal? iataFee) {

            return PaySavingCreditCardAutomatically("auth", merchantId, merchantKey, referenceNum, chargeTotal, creditCardNumber, expMonth, expYear
                                                    , cvvInd, cvvNumber, processorId, numberOfInstallments, chargeInterest, ipAddress, customerToken
                                                    , onFileEndDate, onFilePermission, onFileComment, onFileMaxChargeAmount, billingName, billingAddress
                                                    , billingAddress2, billingCity, billingState, billingPostalCode, billingCountry, billingPhone, billingEmail
                                                    , currencyCode, fraudCheck, softDescriptor, iataFee);

        }

        /// <summary>
        /// Faz uma requisição de boleto.
        /// </summary>
        public ResponseBase Boleto(String merchantId, String merchantKey, String referenceNum, decimal chargeTotal, String processorId
                                 , String ipAddress, String customerIdExt, String expirationDate, String number, String instructions
                                 , String billingName, String billingAddress, String billingAddress2, String billingCity, String billingState
                                 , String billingPostalCode, String billingCountry, String billingPhone, String billingEmail) {

            this.request = new TransactionRequest(merchantId, merchantKey);

            Order order = this.request.Order;
            RequestBase sale = new RequestBase();
            order.Sale = sale;
            sale.ReferenceNum = referenceNum;
            sale.ProcessorId = processorId;
            sale.IpAddress = ipAddress;
            sale.CustomerIdExt = customerIdExt;

            Billing billing = new Billing();
            sale.Billing = billing;

            billing.Address1 = billingAddress;
            billing.Address2 = billingAddress2;
            billing.City = billingCity;
            billing.Country = billingCountry;
            billing.Email = billingEmail;
            billing.Name = billingName;
            billing.Phone = billingPhone;
            billing.Postalcode = billingPostalCode;
            billing.State = billingState;

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Payment payment = new Payment();
            sale.Payment = payment;
            payment.ChargeTotal = chargeTotal;

            TransactionDetail detail = sale.TransactionDetail;
            PayType payType = detail.PayType;

            Boleto boleto = new Boleto();
            payType.Boleto = boleto;

            boleto.ExpirationDate = expirationDate;
            boleto.Instructions = instructions;
            boleto.Number = number;

            return new Utils().SendRequest<TransactionRequest>(this.request, this.Environment);

        }

        /// <summary>
        /// Faz a transação passando o token do cartão já salvo na base.
        /// </summary>
        private ResponseBase PayWithToken(String operation, String merchantId, String merchantKey, String referenceNum, decimal chargeTotal, String processorId
                                , String token, String customerId, String numberOfInstallments, String chargeInterest, String ipAddress, String currencyCode
                                , String fraudCheck, String softDescriptor, decimal? iataFee) {

            this.request = new TransactionRequest(merchantId, merchantKey);

            Order order = this.request.Order;
            RequestBase rBase = new RequestBase();

            if (operation.Equals("sale"))
                order.Sale = rBase;
            else if (operation.Equals("auth"))
                order.Auth = rBase;

            rBase.ReferenceNum = referenceNum;
            rBase.ProcessorId = processorId;
            rBase.IpAddress = ipAddress;
            rBase.FraudCheck = fraudCheck;

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Payment payment = new Payment();
            rBase.Payment = payment;
            payment.ChargeTotal = chargeTotal;
            payment.CurrencyCode = currencyCode;
            payment.SoftDescriptor = softDescriptor;
            payment.IataFee = iataFee;

            if (String.IsNullOrEmpty(numberOfInstallments))
                numberOfInstallments = "0";

            int tranInstallments = int.Parse(numberOfInstallments);

            //Verifica se vai precisar criar o nó de parcelas e juros.
            if (!String.IsNullOrEmpty(chargeInterest) && tranInstallments > 1)
            {
                payment.CreditInstallment = new CreditInstallment();
                payment.CreditInstallment.ChargeInterest = chargeInterest.ToUpper();
                payment.CreditInstallment.NumberOfInstallments = numberOfInstallments;
            }

            TransactionDetail detail = rBase.TransactionDetail;
            PayType payType = detail.PayType;

            payType.OnFile = new OnFile();
            payType.OnFile.CustomerId = customerId;
            payType.OnFile.Token = token;

            return new Utils().SendRequest<TransactionRequest>(this.request, this.Environment);

        }

        /// <summary>
        /// Passa uma transação salvando o número de cartão automaticamente.
        /// </summary>
        private ResponseBase PaySavingCreditCardAutomatically(String operation, String merchantId, String merchantKey, String referenceNum, decimal chargeTotal
                                                            , String creditCardNumber, String expMonth, String expYear, String cvvInd, String cvvNumber
                                                            , String processorId, String numberOfInstallments, String chargeInterest, String ipAddress
                                                            , String customerToken, String onFileEndDate, String onFilePermission, String onFileComment
                                                            , String onFileMaxChargeAmount, String billingName, String billingAddress, String billingAddress2
                                                            , String billingCity, String billingState, String billingPostalCode, String billingCountry
                                                            , String billingPhone, String billingEmail, String currencyCode, String fraudCheck, String softDescriptor
                                                            , decimal? iataFee) {

            this.request = new TransactionRequest(merchantId, merchantKey);

            Order order = this.request.Order;
            RequestBase rBase = new RequestBase();

            if (operation.Equals("sale"))
                order.Sale = rBase;
            else if (operation.Equals("auth"))
                order.Auth = rBase;

            rBase.ReferenceNum = referenceNum;
            rBase.ProcessorId = processorId;
            rBase.IpAddress = ipAddress;
            rBase.FraudCheck = fraudCheck;

            Billing billing = new Billing();
            rBase.Billing = billing;

            billing.Address1 = billingAddress;
            billing.Address2 = billingAddress2;
            billing.City = billingCity;
            billing.Country = billingCountry;
            billing.Email = billingEmail;
            billing.Name = billingName;
            billing.Phone = billingPhone;
            billing.Postalcode = billingPostalCode;
            billing.State = billingState;

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Payment payment = new Payment();
            rBase.Payment = payment;
            payment.ChargeTotal = chargeTotal;
            payment.CurrencyCode = currencyCode;
            payment.SoftDescriptor = softDescriptor;
            payment.IataFee = iataFee;

            if (String.IsNullOrEmpty(numberOfInstallments))
                numberOfInstallments = "0";

            int tranInstallments = int.Parse(numberOfInstallments);

            //Verifica se vai precisar criar o nó de parcelas e juros.
            if (!String.IsNullOrEmpty(chargeInterest) && tranInstallments > 1)
            {
                payment.CreditInstallment = new CreditInstallment();
                payment.CreditInstallment.ChargeInterest = chargeInterest.ToUpper();
                payment.CreditInstallment.NumberOfInstallments = numberOfInstallments;
            }

            TransactionDetail detail = rBase.TransactionDetail;
            PayType payType = detail.PayType;

            CreditCard creditCard = new CreditCard();
            payType.CreditCard = creditCard;

            creditCard.CvvInd = cvvInd;
            creditCard.CvvNumber = cvvNumber;
            creditCard.ExpMonth = expMonth;
            creditCard.ExpYear = expYear;
            creditCard.Number = creditCardNumber;

            rBase.SaveOnFile = new SaveOnFile();
            rBase.SaveOnFile.CustomerToken = customerToken;
            rBase.SaveOnFile.OnFileComment = onFileComment;
            rBase.SaveOnFile.OnFileEndDate = onFileEndDate;
            rBase.SaveOnFile.OnFileMaxChargeAmount = onFileMaxChargeAmount;
            rBase.SaveOnFile.OnFilePermission = onFilePermission;

            return new Utils().SendRequest<TransactionRequest>(this.request, this.Environment);

        }

        /// <summary>
        /// Faz uma Captura.
        /// </summary>
        public ResponseBase Capture(String merchantId, String merchantKey, String orderID, String referenceNum, decimal chargeTotal) {

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            this.request = new TransactionRequest(merchantId, merchantKey);

            CaptureOrReturn capture = new CaptureOrReturn();
            this.request.Order.Capture = capture;

            capture.OrderId = orderID;
            capture.ReferenceNum = referenceNum;
            capture.Payment.ChargeTotal = chargeTotal;

            return new Utils().SendRequest<TransactionRequest>(this.request, this.Environment);

        }

        /// <summary>
        /// Faz um Estorno.
        /// </summary>
        public ResponseBase Return(String merchantId, String merchantKey, String orderID, String referenceNum, decimal chargeTotal) {

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            this.request = new TransactionRequest(merchantId, merchantKey);

            CaptureOrReturn _return = new CaptureOrReturn();
            this.request.Order.Return = _return;

            _return.OrderId = orderID;
            _return.ReferenceNum = referenceNum;
            _return.Payment.ChargeTotal = chargeTotal;

            return new Utils().SendRequest<TransactionRequest>(this.request, this.Environment);

        }

        /// <summary>
        /// Faz um Cancelamento.
        /// </summary>
        public ResponseBase Void(String merchantId, String merchantKey, String transactionID, String ipAddress) {

            this.request = new TransactionRequest(merchantId, merchantKey);

            MaxiPago.DataContract.Transactional.Void _void = new MaxiPago.DataContract.Transactional.Void();
            this.request.Order.Void = _void;

            _void.IpAddress = ipAddress;
            _void.TransactionId = transactionID;

            return new Utils().SendRequest<TransactionRequest>(this.request, this.Environment);

        }

        /// <summary>
        /// Faz uma recorrência.
        /// </summary>
        public ResponseBase Recurring(String merchantId, String merchantKey, String referenceNum, decimal chargeTotal
            , String creditCardNumber, String expMonth, String expYear, String cvvInd, String cvvNumber, String processorId
            , String numberOfInstallments, String chargeInterest, String ipAddress, String action
            , String startDate, String frequency, String period, String installments, String failureThreshold
            , String currencyCode) {

            FillRecurringBase(merchantId, merchantKey, referenceNum, chargeTotal, processorId, numberOfInstallments
                , chargeInterest, ipAddress, action, startDate, frequency, period, installments
                , failureThreshold, currencyCode);
                            //ATENCAO: installments é o campo a ser usado (numberOfInstallments é referente ao Parcelamento)

            TransactionDetail detail = this.request.Order.RecurringPayment.TransactionDetail;

            PayType payType = detail.PayType;

            CreditCard creditCard = new CreditCard();
            payType.CreditCard = creditCard;

            creditCard.CvvInd = cvvInd;
            creditCard.CvvNumber = cvvNumber;
            creditCard.ExpMonth = expMonth;
            creditCard.ExpYear = expYear;
            creditCard.Number = creditCardNumber;

            return new Utils().SendRequest<TransactionRequest>(this.request, this.Environment);
        }

        /// <summary>
        /// Faz uma recorrência com token.
        /// </summary>
        public ResponseBase Recurring(String merchantId, String merchantKey, String referenceNum, decimal chargeTotal
            , String customerId, String token, String processorId, String numberOfInstallments
            , String chargeInterest, String ipAddress, String action, String startDate
            , String frequency, String period, String installments, String failureThreshold
            , String currencyCode) {

            FillRecurringBase(merchantId, merchantKey, referenceNum, chargeTotal, processorId, numberOfInstallments
                    , chargeInterest, ipAddress, action, startDate, frequency, period, installments
                    , failureThreshold, currencyCode);

            TransactionDetail detail = this.request.Order.RecurringPayment.TransactionDetail;
            PayType payType = detail.PayType;

            OnFile onFile = new OnFile();
            payType.OnFile = onFile;

            onFile.CustomerId = customerId;
            onFile.Token = token;

            return new Utils().SendRequest<TransactionRequest>(this.request, this.Environment);
        }

        /// <summary>
        /// Efetua o preenchimento comum aos métodos de Recorrente
        /// </summary>
        private void FillRecurringBase(String merchantId, String merchantKey, String referenceNum, decimal chargeTotal
            , String processorId, String numberOfInstallments, String chargeInterest
            , String ipAddress, String action, String startDate
            , String frequency, String period, String installments, String failureThreshold
            , String currencyCode) {

            this.request = new TransactionRequest(merchantId, merchantKey);

            Order order = this.request.Order;
            RequestBase recurringPayment = new RequestBase();
            order.RecurringPayment = recurringPayment;

            recurringPayment.ReferenceNum = referenceNum;
            recurringPayment.ProcessorId = processorId;
            recurringPayment.IpAddress = ipAddress;

            Payment payment = new Payment();
            recurringPayment.Payment = payment;
            payment.ChargeTotal = chargeTotal;
            payment.CurrencyCode = currencyCode;

            if (String.IsNullOrEmpty(numberOfInstallments))
                numberOfInstallments = "0";

            int tranInstallments = int.Parse(numberOfInstallments);

            //Verifica se vai precisar criar o nó de parcelas e juros.
            if (!String.IsNullOrEmpty(chargeInterest) && tranInstallments > 1)
            {
                payment.CreditInstallment = new CreditInstallment();
                payment.CreditInstallment.ChargeInterest = chargeInterest.ToUpper();
                payment.CreditInstallment.NumberOfInstallments = numberOfInstallments;
            }

            Recurring recurring = new Recurring();
            recurringPayment.Recurring = recurring;

            recurring.Action = action;
            recurring.FailureThreshold = failureThreshold;
            recurring.Frequency = frequency;
            recurring.Installments = installments;
            recurring.Period = period;
            recurring.StartDate = startDate;

        }

        public ResponseBase OnlineDebit(String merchantId, String merchantKey, String referenceNum, decimal chargeTotal
                                    , String processorId, String parametersUrl, String ipAddress, String customerIdExt) {

            this.request = new TransactionRequest(merchantId, merchantKey);

            Order order = this.request.Order;
            RequestBase sale = new RequestBase();
            order.Sale = sale;

            sale.ReferenceNum = referenceNum;
            sale.ProcessorId = processorId;
            sale.IpAddress = ipAddress;
            sale.CustomerIdExt = customerIdExt;

            Payment payment = new Payment();
            sale.Payment = payment;
            payment.ChargeTotal = chargeTotal;

            TransactionDetail detail = sale.TransactionDetail;
            PayType payType = detail.PayType;

            OnlineDebit debit = new OnlineDebit();
            payType.OnlineDebit = debit;

            if (parametersUrl == null)
                parametersUrl = String.Empty;

            debit.ParametersURL = parametersUrl;

            return new Utils().SendRequest<TransactionRequest>(this.request, this.Environment);

        }


    }
}
