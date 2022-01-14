using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace POSOfferBox.Repo.Core.DTO
{
    public class ResponseDTO
    {
        public bool OperationSuccess { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public Exception ExceptionError { get; set; }
    }
}
