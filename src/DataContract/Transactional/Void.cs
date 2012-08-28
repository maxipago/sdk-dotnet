using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional {
    
    [Serializable]
    [XmlRoot(ElementName="void")]
    public class Void {

        [XmlElement("transactionID")]
        public string TransactionId { get; set; }

        [XmlElement("ipAddress")]
        public string IpAddress{ get; set; }

    }
}
