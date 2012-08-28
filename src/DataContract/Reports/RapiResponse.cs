using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Reports {
    
    [Serializable]
    [XmlRoot(ElementName = "rapi-response")]
    public class RapiResponse : ResponseBase {

        [XmlElement("header")]
        public HeaderResponse Header { get; set; }

        [XmlElement("result")]
        public ReportResult Result { get; set; }

    }

}
