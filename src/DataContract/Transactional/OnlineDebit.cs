using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional {

    [Serializable]
    [XmlRoot(ElementName = "onlineDebit")]
    public class OnlineDebit {

        [XmlElement("parametersURL")]
        public string ParametersURL { get; set; }

    }
}
