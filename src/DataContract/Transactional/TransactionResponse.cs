using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using MaxiPago.DataContract;

namespace MaxiPago.DataContract.Transactional {

    [Serializable]
    [XmlRoot(ElementName="transaction-response")]
    public class TransactionResponse : ResponseBase {

        [XmlElement("authCode")]
        public string AuthorizationCode { get; set; }
        
        [XmlElement("orderID")]
        public string OrderId { get; set; }

        [XmlElement("referenceNum")]
        public string ReferenceNum { get; set; }

        [XmlElement("transactionID")]
        public string TransactionId { get; set; }

        [XmlElement("transactionTimestamp")]
        public string TransactionTimestamp { get; set; }

        [XmlElement("responseCode")]
        public string ResponseCode { get; set; }

        [XmlElement("responseMessage")]
        public string ResponseMessage { get; set; }

        [XmlElement("avsResponseCode")]
        public string AvsResponseCode { get; set; }

        [XmlElement("cvvResponseCode")]
        public string CvvResponseCode { get; set; }

        [XmlElement("processorCode")]
        public string ProcessorReturnCode { get; set; }

        [XmlElement("processorMessage")]
        public string ProcessorMessage { get; set; }

        [XmlElement("processorReferenceNumber")]
        public string ProcessorReferenceNumber { get; set; }

        [XmlElement("processorTransactionID")]
        public string ProcessorTransactionID { get; set; }

        [XmlElement("errorMessage")]
        public string ErrorMessage { get; set; }

        [XmlElement("boletoUrl")]
        public string BoletoUrl { get; set; }

        [XmlElement("authenticationURL")]
        public string AuthenticationUrl { get; set; }

        [XmlElement("save-on-file")]
        public SaveOnFileResponse SaveOnFile { get; set; }

    }

}
