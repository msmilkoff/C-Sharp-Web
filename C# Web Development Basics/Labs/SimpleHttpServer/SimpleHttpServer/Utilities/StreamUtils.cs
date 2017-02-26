namespace SimpleHttpServer.Utilities
{
    using System.IO;
    using System.Text;
    using System.Threading;
    using Models;

    public static class StreamUtils
    {
        public static string ReadLine(Stream stream)
        {
            int nextChar;
            var data = new StringBuilder();

            while (true)
            {
                nextChar = stream.ReadByte();
                if (nextChar == '\n')
                {
                    break;
                }

                if (nextChar == '\r')
                {
                    continue;
                }

                if (nextChar == -1)
                {
                    Thread.Sleep(1);
                    continue;
                }

                data.Append((char)nextChar);
            }

            return data.ToString();
        }

        public static void WriteResponse(Stream stream, HttpResponse response)
        {
            var responseHeader = Encoding.UTF8.GetBytes(response.ToString());

            stream.Write(responseHeader, 0, responseHeader.Length);
            stream.Write(response.Content, 0, response.Content.Length);
        }
    }
}
