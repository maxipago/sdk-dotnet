using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Reports {

    [Serializable]
    [XmlRoot(ElementName = "records")]
    public class Records {

        [XmlElement("record")]
        public List<Record> Record { get; set; }

    }
}
