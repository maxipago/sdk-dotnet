using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional {

    [Serializable]
    [XmlRoot(ElementName = "boleto")]
    public class Boleto {

        [XmlElement(ElementName = "expirationDate")]
        public String ExpirationDate { get; set; }

        [XmlElement(ElementName = "number")]
        public String Number { get; set; }

        [XmlElement(ElementName = "instructions")]
        public String Instructions { get; set; }

    }
}
