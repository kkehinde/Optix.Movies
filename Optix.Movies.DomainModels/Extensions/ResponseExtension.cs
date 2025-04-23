using System.Net;

namespace Optix.Movies.DomainModels
{
    public static class ResponseExtension
    {
        public static Response<string> ToErrorMessage(this string message)
        {

            Response<string> response = new Response<string>
            {
                ErrorMessage = message,
                HasError = true,
                HttpStatusCode = HttpStatusCode.InternalServerError
            };

            return response;
        }
        public static Response<T> ToResponse<T>(this T obj) where T : class
        {
            Response<T> response = new Response<T>
            {
                ErrorMessage = "",
                HasError = false,
                HttpStatusCode = HttpStatusCode.OK,
                Value = obj
            };

            return response;
        }


    }

}
