namespace SimpleHttpServer
{
    using System.IO;
    using Enums;
    using Models;

    public static class HttpResponseBuilder
    {
        public static HttpResponse InternalServerError()
        {
            string path = "../../../SimpleHttpServer/Resources/Pages/505.html";
            string content = File.ReadAllText(path);

            return new HttpResponse
            {
                StatusCode = ResponseStatusCode.InternalServerError,
                ContentAsUTF8 = content
            };
        }

        public static HttpResponse NotFound()
        {
            string path = "../../../SimpleHttpServer/Resources/Pages/404.html";
            string content = File.ReadAllText(path);

            return new HttpResponse
            {
                StatusCode = ResponseStatusCode.NotFound,
                ContentAsUTF8 = content
            };
        }
    }
}
