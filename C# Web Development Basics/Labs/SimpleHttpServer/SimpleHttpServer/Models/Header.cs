namespace SimpleHttpServer.Models
{
    using Enums;
    using System.Collections.Generic;
    using System.Text;

    public class Header
    {
        public Header(HeaderType type)
        {
            this.Type = type;
            this.ContentType = "text/html";
            this.Cookies = new CookieCollection();
            this.OtherParameters = new Dictionary<string, string>();
        }

        public HeaderType Type { get; set; }

        public string ContentType { get; set; }

        // Change to long if neccesary.
        public string ContentLength { get; set; }

        public Dictionary<string, string> OtherParameters { get; set; }

        public CookieCollection Cookies { get; set; }

        public override string ToString()
        {
            var header = new StringBuilder();

            header.AppendLine($"Content-Type {this.ContentType}");
            if (this.ContentLength != null)
            {
                header.AppendLine($"Content-Length: {this.ContentLength}");
            }

            if (this.Cookies.Count > 0)
            {
                if (this.Type == HeaderType.HttpRequest)
                {
                    header.AppendLine($"Cookie: {this.Cookies.ToString()}");
                }
                else if (this.Type == HeaderType.HttpResponse)
                {
                    foreach (var cookie in this.Cookies)
                    {
                        header.AppendLine($"Set-Cookie: {cookie}");
                    }
                }
            }

            foreach (var parameter in this.OtherParameters)
            {
                header.AppendLine($"{parameter.Key}: {parameter.Value}");
            }

            header.AppendLine();
            header.AppendLine();

            return header.ToString();
        }
    }
}
