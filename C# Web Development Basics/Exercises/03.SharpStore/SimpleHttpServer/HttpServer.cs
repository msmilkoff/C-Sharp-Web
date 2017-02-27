namespace SimpleHttpServer
{
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;
    using Models;

    public class HttpServer
    {
        public HttpServer(int port, IEnumerable<Route> routes)
        {
            this.Port = port;
            this.Processor = new HttpProcessor(routes);
            this.IsActive = true;
        }

        public TcpListener Listener { get; private set; }

        public int Port { get; private set; }

        public HttpProcessor Processor { get; private set; }

        public bool IsActive { get; private set; }

        public void Listen()
        {
            this.Listener = new TcpListener(IPAddress.Any, this.Port);
            this.Listener.Start();

            while (this.IsActive)
            {
                var client = this.Listener.AcceptTcpClient();
                var thread = new Thread(() =>
                {
                    using (var stream = client.GetStream())
                    {
                        this.Processor.HandleClient(client);
                    }
                });

                thread.Start();
                Thread.Sleep(1);
            }
        }
    }
}
