using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional {
    public class Recurring {

        [XmlElement("action")]
        public string Action { get; set; }

        [XmlElement("startDate")]
        public string StartDate { get; set; }

        [XmlElement("period")]
        public string Period { get; set; }

        [XmlElement("frequency")]
        public string Frequency { get; set; }

        [XmlElement("installments")]
        public string Installments { get; set; }

        [XmlElement("failureThreshold")]
        public string FailureThreshold { get; set; }

    }
}
