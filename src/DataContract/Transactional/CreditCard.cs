using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional {
    
    [Serializable]
    [XmlRoot("creditCard")]
    public class CreditCard {

        public CreditCard() {
            this.ecommInd = "eci";
        }

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

        private string ecommInd;

        [XmlElement("eCommInd")]
        public string ECommInd { 
            get { return this.ecommInd; }
            set { }
        }

    }
}
