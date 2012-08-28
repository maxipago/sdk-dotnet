using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional {
    
    [Serializable]
    [XmlRoot(ElementName = "transactionDetail")]
    public class TransactionDetail {

        public TransactionDetail() {
            this.PayType = new PayType();
        }

        [XmlElement("payType")]
        public PayType PayType { get; set; }

    }
}
