namespace SimpleHttpServer.Models
{
    using System;
    using System.Text;
    using Enums;

    public class HttpResponse
    {
        public HttpResponse()
        {
            this.Header = new Header(HeaderType.HttpResponse);
        }

        public ResponseStatusCode StatusCode { get; set; }

        public string StatusMesage
        {
            get
            {
                return Enum.GetName(typeof(ResponseStatusCode), this.StatusCode);
            }
        }

        public Header Header { get; set; }

        public byte[] Content { get; set; }

        public string ContentAsUTF8
        {
            set
            {
                this.Content = Encoding.UTF8.GetBytes(value);
            }
        }

        public override string ToString()
        {
            var response = new StringBuilder();

            response.AppendLine($"HTTP/1.0 {this.StatusCode} {this.StatusMesage}");
            response.AppendLine(this.Header.ToString());

            return response.ToString();
        }
    }
}
