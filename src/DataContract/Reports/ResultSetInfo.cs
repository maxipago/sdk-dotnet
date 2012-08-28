using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Reports {

    [Serializable]
    [XmlRoot(ElementName = "resultSetInfo")]
    public class ResultSetInfo {

        [XmlElement("totalNumberOfRecords")]
        public String TotalNumberOfRecords { get; set; }

        [XmlElement("pageToken")]
        public String PageToken { get; set; }

        [XmlElement("numberOfPages")]
        public String NumberOfPages { get; set; }

        [XmlElement("pageNumber")]
        public String PageNumber { get; set; }

        [XmlElement("processedTime")]
        public String ProcessedTime { get; set; }

    }
}
