namespace SimpleMVC.App.MVC.Interfaces
{
    public interface IActionResult : IInvokable
    {
        IRenderable Action { get; set; }
    }
}
