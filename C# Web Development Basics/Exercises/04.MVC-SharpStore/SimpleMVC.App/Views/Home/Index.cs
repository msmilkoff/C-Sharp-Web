namespace SimpleMVC.App.Views.Home
{
    using MVC.Interfaces;
    using System.IO;

    public class Index : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../content/home.html");
        }
    }
}
