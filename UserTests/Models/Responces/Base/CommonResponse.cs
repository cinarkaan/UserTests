using System.Net;

namespace UserTests.Models.Responces.Base
{
    public class CommonResponse<T>
    {
        public HttpStatusCode Status;

        public string Content;

        public T[] BodyArr;

        public T Body;

        public static implicit operator CommonResponse<T>(Task<CommonResponse<object>> v)
        {
            throw new NotImplementedException();
        }
    }
}
