using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional {

    [Serializable]
    [XmlRoot(ElementName = "saveOnFile")]
    public class SaveOnFile {

        [XmlElement(ElementName="customerToken")]
        public String CustomerToken { get; set; }

        [XmlElement(ElementName = "onFileEndDate")]
        public String OnFileEndDate { get; set; }

        [XmlElement(ElementName = "onFilePermission")]
        public String OnFilePermission { get; set; }

        [XmlElement(ElementName = "onFileComment")]
        public String OnFileComment { get; set; }

        [XmlElement(ElementName = "onFileMaxChargeAmount")]
        public String OnFileMaxChargeAmount { get; set; }

    }
}
