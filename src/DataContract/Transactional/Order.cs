using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional
{
    [Serializable]
    [XmlRoot(ElementName = "order")]
    public class Order
    {
        public Order() {
            this.ClientData = new ClientData();
        }

        [XmlElement("sale")]
        public RequestBase Sale { get; set; }

        [XmlElement("auth")]
        public RequestBase Auth { get; set; }

        [XmlElement("capture")]
        public CaptureOrReturn Capture { get; set; }

        [XmlElement("return")]
        public CaptureOrReturn Return { get; set; }

        [XmlElement("void")]
        public Void Void { get; set; }

        [XmlElement("recurringPayment")]
        public RequestBase RecurringPayment { get; set; }
        
        [XmlElement("clientData")]
        public ClientData ClientData { get; set; }

    }
}
