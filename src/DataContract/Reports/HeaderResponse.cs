using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Reports {

    [Serializable]
    [XmlRoot(ElementName = "header")]
    public class HeaderResponse {

        [XmlElement("errorCode")]
        public String ErrorCode { get; set; }

        [XmlElement("errorMsg")]
        public String ErrorMsg { get; set; }

        [XmlElement("command")]
        public String Command { get; set; }

        [XmlElement("time")]
        public String Time { get; set; }

    }
}
