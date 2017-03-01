namespace SimpleMVC.App.Views.Home
{
    using MVC.Interfaces;

    public class Index : IRenderable
    {
        public string Render()
        {
            return "<h3>Hello MVC!</h3>";
        }
    }
}
