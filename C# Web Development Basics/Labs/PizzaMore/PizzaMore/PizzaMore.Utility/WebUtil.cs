namespace PizzaMore.Utility
{
    using Models;
    using Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.IO;

    public static class WebUtil
    {
        public static bool IsPost()
        {
            string method = Environment.GetEnvironmentVariable(Constants.RequestMethod);
            return method?.ToLower() == "get";
        }

        public static bool IsGet()
        {
            string method = Environment.GetEnvironmentVariable(Constants.RequestMethod);
            return method?.ToLower() == "post";
        }

        public static IDictionary<string, string> RetrieveGetParameters()
        {
            var queryString = Environment.GetEnvironmentVariable(Constants.QueryString);
            var parametersString = WebUtility.UrlDecode(queryString);

            return RetrieveRequestParameters(parametersString);
        }

        public static IDictionary<string, string> RetrievePostParameters()
        {
            var parametersString = WebUtility.UrlDecode(Console.ReadLine());

            return RetrieveRequestParameters(parametersString);
        }

        public static ICookieCollection GetCookies()
        {
            var cookieHeader = Environment.GetEnvironmentVariable(Constants.CookieGet);
            if (string.IsNullOrEmpty(cookieHeader))
            {
                return new CookieCollection();
            }

            var cookies = new CookieCollection();
            var cookieSaves = cookieHeader.Split(';');
            foreach (var cookieSave in cookieSaves)
            {
                var cookiePair = cookieSave
                    .Split('=')
                    .Select(c => c.Trim())
                    .ToArray();

                var cookie = new Cookie(cookiePair[0], cookiePair[1]);
                cookies.AddCookie(cookie);
            }

            return cookies;
        }

        public static Session GetSession()
        {
            var cookies = GetCookies();

            if (!cookies.ContainsKey(Constants.SessionId))
            {
                return null;
            }

            var context = new PizzaMoreContext();

            var sessionCookie = cookies[Constants.SessionId];
            var session = context.Sessions
                .FirstOrDefault(s => s.Id == sessionCookie.Value);

            return session;
        }

        private static IDictionary<string, string> RetrieveRequestParameters(string parametersString)
        {
            var resultParameters = new Dictionary<string, string>();

            var parameters = parametersString.Split('&');
            foreach (var parameter in parameters)
            {
                var pair = parameter.Split('=');
                var key = pair[0];
                string value = null;

                if (pair.Length > 1)
                {
                    value = pair[1];
                }

                resultParameters.Add(key, value);
            }

            return resultParameters;
        }

        public static void PageNotAllowed()
        {
            string path = @"C:\wamp64\www\game\index.html";
            PrintFileContent(path);
        }

        public static void PrintFileContent(string path)
        {
            string content = File.ReadAllText(path);
            Console.WriteLine("Content-Type: text/html\r\n");
            Console.WriteLine(content);
        }
    }
}
