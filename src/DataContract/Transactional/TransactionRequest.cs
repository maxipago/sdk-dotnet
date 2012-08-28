using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional
{
    [Serializable]
    [XmlRoot(ElementName = "transaction-request")]
    public class TransactionRequest
    {

        public TransactionRequest() {
            this.Verification = new Verification();
            this.Order = new Order();
            this.Version = "3.1.1.15";
        }


        public TransactionRequest(string merchantId, string merchantKey) {
            this.Verification = new Verification(merchantId, merchantKey);
            this.Order = new Order();
            this.Version = "3.1.1.15";
        }

        [XmlElement("version")]
        public string Version { get; set; }

        [XmlElement("verification")]
        public Verification Verification { get; set; }

        [XmlElement("order")]
        public Order Order { get; set; }

    }
}
