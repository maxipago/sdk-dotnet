using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional {

    [Serializable]
    [XmlRoot(ElementName="payType")]
    public class PayType {

        [XmlElement("creditCard")]
        public CreditCard CreditCard { get; set; }
        public bool ShouldSerializeCreditCard() { return this.CreditCard != null; }

        [XmlElement("onFile")]
        public OnFile OnFile { get; set; }
        public bool ShouldSerializeOnFile() { return this.OnFile != null; }

        [XmlElement("boleto")]
        public Boleto Boleto { get; set; }
        public bool ShouldSerializeBoleto() { return this.Boleto != null; }

        [XmlElement("onlineDebit")]
        public OnlineDebit OnlineDebit { get; set; }
        public bool ShouldSerializeOnlineDebit() { return this.OnlineDebit != null; }

    }
}
