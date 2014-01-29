using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Reports {
    
    [Serializable]
    [XmlRoot(ElementName = "filterOptions")]
    public class FilterOptions {

        [XmlElement("transactionId")]
        public String TransactionId { get; set; }

        [XmlElement("orderId")]
        public String OrderId { get; set; }

        [XmlElement("period")]
        public String Period { get; set; }

        [XmlElement("pageSize")]
        public String PageSize { get; set; }

        [XmlElement("startDate")]
        public String StartDate { get; set; }

        [XmlElement("endDate")]
        public String EndDate { get; set; }

        [XmlElement("startTime")]
        public String StartTime { get; set; }

        [XmlElement("endTime")]
        public String EndTime { get; set; }

        [XmlElement("orderByName")]
        public String OrderByName { get; set; }

        [XmlElement("orderByDirection")]
        public String OrderByDirection { get; set; }

        [XmlElement("startRecordNumber")]
        public String StartRecordNumber { get; set; }

        [XmlElement("endRecordNumber")]
        public String EndRecordNumber { get; set; }

        [XmlElement("pageNumber")]
        public String PageNumber { get; set; }

        [XmlElement("pageToken")]
        public String PageToken { get; set; }

    }
}
