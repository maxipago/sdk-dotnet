using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional {

    [Serializable]
    [XmlRoot(ElementName = "saveOnFile")]
    public class SaveOnFile {

        /// <summary>
        /// ID único do cadastro, retornado quando o cliente foi adicionado à base (customerId).
        /// </summary>
        [XmlElement(ElementName="customerToken")]
        public String CustomerToken { get; set; }

        /// <summary>
        /// Data limite para manter o cartão na base, Formato MM/DD/AAAA.
        /// </summary>
        [XmlElement(ElementName = "onFileEndDate")]
        public String OnFileEndDate { get; set; }

        /// <summary>
        /// Duração limite do uso do cartão salvo, ongoing = indefinidamente, use_once = apenas uma vez após a 1a. cobrança
        /// </summary>
        [XmlElement(ElementName = "onFilePermissions")]
        public String OnFilePermission { get; set; }

        /// <summary>
        /// Comentários adicionais sobre este cartão
        /// </summary>
        [XmlElement(ElementName = "onFileComment")]
        public String OnFileComment { get; set; }

        /// <summary>
        /// Valor máximo que é permitido cobrar deste cartão
        /// </summary>
        [XmlElement(ElementName = "onFileMaxChargeAmount")]
        public String OnFileMaxChargeAmount { get; set; }

    }
}
