using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Optix.Movies.DomainModels
{
    public class Response<T> where T : class
    {
        public T? Value { get; set; }
        public string? ErrorMessage { get; set; }
        public bool HasError { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
    }

}
