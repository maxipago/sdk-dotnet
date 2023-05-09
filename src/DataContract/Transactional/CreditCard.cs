using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional
{

    [Serializable]
    [XmlRoot("creditCard")]
    public class CreditCard
    {               

        [XmlElement("number")]
        public string Number { get; set; }

        [XmlElement("expMonth")]
        public string ExpMonth { get; set; }

        [XmlElement("expYear")]
        public string ExpYear { get; set; }

        [XmlElement("cvvInd")]
        public string CvvInd { get; set; }

        [XmlElement("cvvNumber")]
        public string CvvNumber { get; set; }
                
        [XmlElement("eCommInd")]
        public string ECommInd  { get; set; } = "eci";

        [XmlElement("processorID")]
        public string ProcessorID { get; set; }
        public bool ShouldSerializeProcessorID() { return !string.IsNullOrEmpty(this.ProcessorID); }

        [XmlElement("operation")]
        public string Operation { get; set; }
        public bool ShouldSerializeOperation() { return !string.IsNullOrEmpty(this.Operation); }

        [XmlElement("numberOfInstallments")]
        public string NumberOfInstallments { get; set; }
        public bool ShouldSerializeNumberOfInstallments() { return !string.IsNullOrEmpty(this.NumberOfInstallments); }

        [XmlElement("currencyCode")]
        public string CurrencyCode { get; set; }
        public bool ShouldSerializeCurrencyCode() { return !string.IsNullOrEmpty(this.CurrencyCode); }

        [XmlElement("amount")]
        public string Amount { get; set; }
        public bool ShouldSerializeAmount() { return !string.IsNullOrEmpty(this.Amount); }

    }
}
