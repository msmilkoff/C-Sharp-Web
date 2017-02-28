namespace SimpleMVC.App.MVC.Interfaces.Generic
{
    public interface IActionResult<T> : IInvokable
    {
        IRenderable<T> Action { get; set; }
    }
}
