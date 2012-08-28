using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional {
    
    [Serializable]
    public class CaptureOrReturn {

        public CaptureOrReturn() {
            this.Payment = new Payment();
        }

        [XmlElement("orderID")]
        public string OrderId { get; set; }

        [XmlElement("referenceNum")]
        public string ReferenceNum { get; set; }

        [XmlElement("payment")]
        public Payment Payment { get; set; }

    }
}
