using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MaxiPago.DataContract.Reports;
using MaxiPago.DataContract;

namespace MaxiPago.Gateway {
    
    public class Report : ServiceBase {

        public Report() {
            this.Environment = "TEST";
        }

        private RapiRequest request;

        /// Queries a list of transactions
        public RapiResponse GetTransactionDetailReport(String merchantId, String merchantKey, String period, String pageSize, String startDate
                                                     , String endDate, String startTime, String endTime, String orderByName, String orderByDirection
                                                     , String startRecordNumber, String endRecordNumber) {

            this.request = new RapiRequest(merchantId, merchantKey);
            this.request.Command = "transactionDetailReport";

            FilterOptions filter = this.request.ReportRequest.FilterOptions;

            filter.Period = period;
            filter.PageSize = pageSize;
            filter.StartDate = startDate;
            filter.EndDate = endDate;
            filter.StartTime = startTime;
            filter.EndTime = endTime;
            filter.OrderByName = orderByName;
            filter.OrderByDirection = orderByDirection;
            filter.StartRecordNumber = startRecordNumber;
            filter.EndRecordNumber = endRecordNumber;

            return new Utils().SendRequest<RapiRequest>(this.request, this.Environment) as RapiResponse;
        }

        /// Queries one transaction
        public RapiResponse GetTransactionDetailReport(String merchantId, String merchantKey, String transactionId) {

            this.request = new RapiRequest(merchantId, merchantKey);
            this.request.Command = "transactionDetailReport";

            FilterOptions filter = this.request.ReportRequest.FilterOptions;
            filter.TransactionId = transactionId;

            return new Utils().SendRequest<RapiRequest>(this.request, this.Environment) as RapiResponse;
        }

        /// Queries one or more transactions by orderId.
        public RapiResponse GetTransactionDetailReportByOrderId(String merchantId, String merchantKey, String orderId) {

            this.request = new RapiRequest(merchantId, merchantKey);
            this.request.Command = "transactionDetailReport";

            FilterOptions filter = this.request.ReportRequest.FilterOptions;
            filter.OrderId = orderId;

            return new Utils().SendRequest<RapiRequest>(this.request, this.Environment) as RapiResponse;
        }

        /// Flips through report pages
        public RapiResponse GetTransactionDetailReport(String merchantId, String merchantKey, String pageToken, String pageNumber) {

            this.request = new RapiRequest(merchantId, merchantKey);
            this.request.Command = "transactionDetailReport";

            FilterOptions filter = this.request.ReportRequest.FilterOptions;

            filter.PageToken = pageToken;
            filter.PageNumber = pageNumber;

            return new Utils().SendRequest<RapiRequest>(this.request, this.Environment) as RapiResponse;
        }

        /// Queries the status of a pending report
        public RapiResponse CheckRequestStatus(String merchantId, String merchantKey, String requestToken) {

            this.request = new RapiRequest(merchantId, merchantKey);
            this.request.Command = "checkRequestStatus";

            this.request.ReportRequest.RequestToken = requestToken;

            return new Utils().SendRequest<RapiRequest>(this.request, this.Environment) as RapiResponse;

        }

    }
}
