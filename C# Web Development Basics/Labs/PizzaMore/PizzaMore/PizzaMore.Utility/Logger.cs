namespace PizzaMore.Utility
{
    using System;
    using System.IO;

    public static class Logger
    {
        public static void Log(string message)
        {
            string path = "../../log.txt";
            File.AppendAllText(path, message + Environment.NewLine);
        }
    }
}
