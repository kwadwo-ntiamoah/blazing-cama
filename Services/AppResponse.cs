using System.Net;

namespace Services
{
    public class AppResponse<T>
    {
        public HttpStatusCode Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}