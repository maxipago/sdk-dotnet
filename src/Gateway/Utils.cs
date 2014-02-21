using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Net;
using MaxiPago.DataContract;
using MaxiPago.DataContract.Reports;
using MaxiPago.DataContract.Transactional;
using MaxiPago.DataContract.NonTransactional;

namespace MaxiPago.Gateway {
    
    internal class Utils {

        /// Sends the request
        internal ResponseBase SendRequest<T>(T request, string environment) {

            if (request == null)
                throw new Exception("The Request can not be null or empty");

            String xml = ToXml<T>(request);

            // Gets environment URL
            String url = GetUrl(request, environment);

            string responseContent = Post(xml, url);

            // Parses response XML
            return ParseResponse(responseContent);

        }

        /// Parses response XML
        private ResponseBase ParseResponse(string responseContent) {

            if (responseContent.Contains("transaction-response")) {
                return Serialize<TransactionResponse>(responseContent);
            }
            else if (responseContent.Contains("rapi-response")) {
                return Serialize<RapiResponse>(responseContent);
            }
            else if (responseContent.Contains("api-error")) {
                return Serialize<ErrorResponse>(responseContent);
            }
            else if (responseContent.Contains("api-response")) {
                return Serialize<ApiResponse>(responseContent);
            }
            else
                throw new Exception("Unexpected response was received.");

        }

        /// Gets URL
        private String GetUrl<T>(T request, string environment) {

            switch (environment) {
                case "LIVE":

                    if(request is TransactionRequest)
                        return "https://api.maxipago.net/UniversalAPI/postXML";
                    else if (request is ApiRequest)
                        return "https://api.maxipago.net/UniversalAPI/postAPI";
                     else if (request is RapiRequest)
                        return "https://api.maxipago.net/ReportsAPI/servlet/ReportsAPI";
                    break;
                case "TEST":

                    if(request is TransactionRequest)
                        return "https://testapi.maxipago.net/UniversalAPI/postXML";
                    else if (request is ApiRequest)
                        return "https://testapi.maxipago.net/UniversalAPI/postAPI";
                     else if (request is RapiRequest)
                        return "https://testapi.maxipago.net/ReportsAPI/servlet/ReportsAPI";
                    break;

            }

            throw new Exception("You must to inform the environment. (TEST or LIVE)");

        }

        private String ToXml<T>(T request) {

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            using (StringWriter writer = new StringWriter()) {
                serializer.Serialize(writer, request, ns);
                string result = writer.ToString();

                if (result == null)
                    return null;

                result = result.Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", null);

                return result;
            }
        }

        /// Posts data to maxiPago!
        private string Post(string xml, string url) {

            HttpWebRequest req = null;
            WebResponse rsp = null;
            req = (System.Net.HttpWebRequest)HttpWebRequest.Create(url);
            req.Method = "POST";
	    req.ContentType = "text/xml; charset=UTF-8";

            req.Timeout = 99999;

            using (StreamWriter writer = new StreamWriter(req.GetRequestStream())) {
                writer.Write(xml);
            }

            rsp = req.GetResponse();

            string responseContent = null;
            using (System.IO.StreamReader reader = new System.IO.StreamReader(rsp.GetResponseStream())) {
                responseContent = reader.ReadToEnd();
            }

            return responseContent;
        }

        /// Serializes XML
        private T Serialize<T>(string xml) {

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xml)));

        }



    }
}
