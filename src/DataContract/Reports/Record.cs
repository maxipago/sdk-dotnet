using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Reports {

    [Serializable]
    [XmlRoot(ElementName = "record")]
    public class Record {

        [XmlElement("approvalCode")]
        public String ApprovalCode { get; set; }

        [XmlElement("comments")]
        public String Comments { get; set; }

        [XmlElement("companyName")]
        public String CompanyName { get; set; }

        [XmlElement("creditCardType")]
        public String CreditCardType { get; set; }

        [XmlElement("customerId")]
        public String CustomerId { get; set; }

        [XmlElement("orderId")]
        public String OrderId { get; set; }

        [XmlElement("referenceNumber")]
        public String ReferenceNumber { get; set; }

        [XmlElement("paymentType")]
        public String PaymentType { get; set; }

        [XmlElement("recurringPaymentFlag")]
        public String RecurringPaymentFlag { get; set; }

        [XmlElement("responseCode")]
        public String ResponseCode { get; set; }

        [XmlElement("transactionAmount")]
        public String TransactionAmount { get; set; }

        [XmlElement("transactionId")]
        public String TransactionId { get; set; }

        [XmlElement("transactionStatus")]
        public String TransactionStatus { get; set; }

        [XmlElement("transactionState")]
        public String TransactionState { get; set; }

        [XmlElement("transactionType")]
        public String TransactionType { get; set; }

        [XmlElement("transactionDate")]
        public String TransactionDate { get; set; }

        [XmlElement("avsResponseCode")]
        public String AvsResponseCode { get; set; }

        [XmlElement("billingAddress1")]
        public String BillingAddress1 { get; set; }

        [XmlElement("billingAddress2")]
        public String BillingAddress2 { get; set; }

        [XmlElement("billingCity")]
        public String BillingCity { get; set; }

        [XmlElement("billingCountry")]
        public String BillingCountry { get; set; }

        [XmlElement("billingEmail")]
        public String BillingEmail { get; set; }

        [XmlElement("billingName")]
        public String BillingName { get; set; }

        [XmlElement("billingPhone")]
        public String BillingPhone { get; set; }

        [XmlElement("billingState")]
        public String BillingState { get; set; }

        [XmlElement("billingZip")]
        public String BillingZip { get; set; }

        [XmlElement("boletoNumber")]
        public String BoletoNumber { get; set; }

        [XmlElement("expirationDate")]
        public String ExpirationDate { get; set; }

        [XmlElement("dateOfPayment")]
        public String DateOfPayment { get; set; }

        /// <summary>
        /// Data de liquidação do valor, se o banco a informou. Formato mm/dd/aaaa
        /// </summary>
        [XmlElement("dateOfFunding")]
        public String DateOfFunding { get; set; }

        /// <summary>
        /// Código FEBRABAN do banco onde foi feito o pagamento.
        /// </summary>
        [XmlElement("bankOfPayment")]
        public String BankOfPayment { get; set; }

        /// <summary>
        /// Agência onde foi feito o pagamento.
        /// </summary>
        [XmlElement("branchOfPayment")]
        public String BranchOfPayment { get; set; }

        /// <summary>
        /// Valor pago pelo cliente.
        /// </summary>
        [XmlElement("paidAmount")]
        public String PaidAmount { get; set; }

        /// <summary>
        /// Taxa de cobrança do boleto, se o banco a informou.
        /// </summary>
        [XmlElement("bankFee")]
        public String BankFee { get; set; }

        /// <summary>
        /// Valor líquido a receber (valor pago - taxa)
        /// </summary>
        [XmlElement("netAmount")]
        public String NetAmount { get; set; }

        /// <summary>
        /// Código de pagamento do boleto no banco.
        /// </summary>
        [XmlElement("returnCode")]
        public String ReturnCode { get; set; }

        /// <summary>
        /// Código de liquidação do banco, se informado.
        /// </summary>
        [XmlElement("clearingCode")]
        public String ClearingCode { get; set; }

        /// <summary>
        /// Código do meio de pagamento.
        /// </summary>
        [XmlElement("processorID")]
        public String ProcessorId { get; set; }

        /// <summary>
        /// Campo livre.
        /// </summary>
        [XmlElement("customField1")]
        public String CustomField1 { get; set; }

        /// <summary>
        /// Campo livre.
        /// </summary>
        [XmlElement("customField2")]
        public String CustomField2 { get; set; }

        /// <summary>
        /// Campo livre.
        /// </summary>
        [XmlElement("customField3")]
        public String CustomField3 { get; set; }

        /// <summary>
        /// Campo livre.
        /// </summary>
        [XmlElement("customField4")]
        public String CustomField4 { get; set; }

        /// <summary>
        /// Campo livre.
        /// </summary>
        [XmlElement("customField5")]
        public String CustomField5 { get; set; }
		
		/// <summary>
        /// Url para imprimir o boleto.
        /// </summary>
        [XmlElement("boletoUrl")]
        public String BoletoUrl { get; set; }

        /// <summary>
        /// Número de parcelas.
        /// </summary>
        [XmlElement("numberOfInstallments")]
        public String NumberOfInstallments { get; set; }

        /// <summary>
        /// Juros.
        /// </summary>
        [XmlElement("chargeInterest")]
        public String ChargeInterest { get; set; }




    }
}
