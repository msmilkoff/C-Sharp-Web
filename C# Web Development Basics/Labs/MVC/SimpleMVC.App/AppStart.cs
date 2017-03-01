namespace SimpleMVC.App
{
    using SimpleHttpServer;
    using MVC;

    public class AppStart
    {
        public static void Main()
        {
            var server = new HttpServer(8081, RouteTable.Routes);
            MvcEngine.Run(server);
        }
    }
}
