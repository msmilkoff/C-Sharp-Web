namespace SimpleMVC.App.MVC.Controllers
{
    using System.Runtime.CompilerServices;
    using Interfaces;
    using Interfaces.Generic;
    using MVC;
    using ViewEngine;
    using ViewEngine.Generic;

    public class Controller
    {
        protected IActionResult View([CallerMemberName] string callee = "")
        {
            string controllerName = this.GetType()
                .Name
                .Replace(MvcContext.Current.ControllerSuffix, string.Empty);

            string fullQualifiedName = string.Format(
                "{0}.{1}.{2}.{3}",
                    MvcContext.Current.AssemblyName,
                    MvcContext.Current.ViewsFolder,
                    controllerName,
                    callee
                );

            return new ActionResult(fullQualifiedName);
        }

        protected IActionResult View(string controller, string action)
        {
            string fullQualifiedName = string.Format(
                "{0}.{1}.{2}.{3}",
                    MvcContext.Current.AssemblyName,
                    MvcContext.Current.ViewsFolder,
                    controller,
                    action
                );

            return new ActionResult(fullQualifiedName);
        }

        protected IActionResult<T> View<T>(T model, [CallerMemberName]string callee = "")
        {
            string controllerName = this.GetType()
                .Name
                .Replace(MvcContext.Current.ControllerSuffix, string.Empty);

            string fullQualifiedName = string.Format(
                "{0}.{1}.{2}.{3}",
                    MvcContext.Current.AssemblyName,
                    MvcContext.Current.ViewsFolder,
                    controllerName,
                    callee
                );

            return new ActionResult<T>(fullQualifiedName, model);
        }

        protected IActionResult<T> View<T>(T model, string controller, string action)
        {
            string fullQualifiedName = string.Format(
                "{0}.{1}.{2}.{3}",
                    MvcContext.Current.AssemblyName,
                    MvcContext.Current.ViewsFolder,
                    controller,
                    action
                );

            return new ActionResult<T>(fullQualifiedName, model);
        }
    }
}
