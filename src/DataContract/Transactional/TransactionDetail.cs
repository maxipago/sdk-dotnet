using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional
{

    [Serializable]
    [XmlRoot(ElementName = "transactionDetail")]
    public class TransactionDetail
    {

        public TransactionDetail()
        {
            this.PayType = new PayType();
        }

        [XmlElement("payType")]
        public PayType PayType { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }
        public bool ShouldSerializeDescription() { return !string.IsNullOrEmpty(this.Description); }

        [XmlElement("comments")]
        public string Comments { get; set; }
        public bool ShouldSerializeComments() { return !string.IsNullOrEmpty(this.Comments); }

        [XmlElement("emailSubject")]
        public string EmailSubject { get; set; }
        public bool ShouldSerializeEmailSubject() { return !string.IsNullOrEmpty(this.EmailSubject); }

        [XmlElement("expirationDate")]
        public string ExpirationDate { get; set; }
        public bool ShouldSerializeExpirationDatet() { return !string.IsNullOrEmpty(this.ExpirationDate); }


    }
}
