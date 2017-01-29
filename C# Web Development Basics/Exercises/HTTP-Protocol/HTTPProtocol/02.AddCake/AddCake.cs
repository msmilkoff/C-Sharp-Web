namespace _02.AddCake
{
    using System;
    using System.IO;

    public class AddCake
    {
        public static void Main()
        {
            var htmlContent = File.ReadAllText("add-cake.html");

            Console.WriteLine("Content-type: text/html\n");
            Console.WriteLine(htmlContent);

            var cakeInfo = Console.ReadLine();
            var keyValuePairs = cakeInfo.Split('&');
            string cakeName = keyValuePairs[0].Split('=')[1];
            string cakePrice = keyValuePairs[1].Split('=')[1];

            File.AppendAllText("database.csv", $"{cakeName},{cakePrice}" + Environment.NewLine);
        }
    }
}
