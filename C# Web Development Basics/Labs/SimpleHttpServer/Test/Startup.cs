namespace Test
{
    using System.Collections.Generic;
    using SimpleHttpServer;
    using SimpleHttpServer.Enums;
    using SimpleHttpServer.Models;

    public class Startup
    {
        public static void Main()
        {
            var routes = new List<Route>
            {
                new Route
                {
                    Name = "Hello Handler",
                    UrlRegex = @"^/hello$",
                    Method = RequestMethod.GET,
                    Callable = request =>
                    {
                        return new HttpResponse
                        {
                            ContentAsUTF8 = "<h3> Hello from SimpleHttpServer :) <h3>",
                            StatusCode = ResponseStatusCode.OK
                        };
                    }
                }
            };

            var server = new HttpServer(8081, routes);
            server.Listen();
        }
    }
}
