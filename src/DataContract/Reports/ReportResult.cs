using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Reports {

    [Serializable]
    [XmlRoot(ElementName = "result")]
    public class ReportResult {

        [XmlElement("requestToken")]
        public String RequestToken { get; set; }

        [XmlElement("statusMessage")]
        public String StatusMessage { get; set; }

        [XmlElement("resultSetInfo")]
        public ResultSetInfo ResultSetInfo { get; set; }

        [XmlElement("records")]
        public Records Records { get; set; }

    }
}
