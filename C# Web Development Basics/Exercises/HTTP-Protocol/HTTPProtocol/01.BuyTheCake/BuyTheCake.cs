namespace _01.BuyTheCake
{
    using System;
    using System.IO;

    public class BuyTheCake
    {
        public static void Main()
        {
            string htmlContent = File.ReadAllText("index.html");

            Console.WriteLine("Content-type: text/html\n");
            Console.WriteLine(htmlContent);
        }
    }
}
