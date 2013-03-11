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

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("authCode")]
        public string AuthorizationCode { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("orderID")]
        public string OrderId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("referenceNum")]
        public string ReferenceNum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("transactionID")]
        public string TransactionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("transactionTimestamp")]
        public string TransactionTimestamp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("responseCode")]
        public string ResponseCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("responseMessage")]
        public string ResponseMessage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("avsResponseCode")]
        public string AvsResponseCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("cvvResponseCode")]
        public string CvvResponseCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("processorCode")]
        public string ProcessorReturnCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("processorMessage")]
        public string ProcessorMessage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("processorReferenceNumber")]
        public string ProcessorReferenceNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("processorTransactionID")]
        public string ProcessorTransactionID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("fraudScore")]
        public string FraudScore { get; set; }


        /// <summary>
        /// 
        /// </summary>
        [XmlElement("errorMessage")]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Url de retorno do boleto, somente usado para transações de boleto.
        /// </summary>
        [XmlElement("boletoUrl")]
        public string BoletoUrl { get; set; }

        [XmlElement("authenticationURL")]
        public string AuthenticationUrl { get; set; }

        [XmlElement("save-on-file")]
        public SaveOnFileResponse SaveOnFile { get; set; }

        /// <summary>
        /// Esse campo tem que ser oculto para os lojistas, pois é somente para o EUA, porém precisamos tratar para não dar erro.
        /// </summary>
        //[XmlElement("partiallyApprovedAmount")]
        //public string PartiallyApprovedAmount { get; set; }

        [XmlElement("onlineDebitUrl")]
        public string OnlineDebitUrl { get; set; }

    }

}
