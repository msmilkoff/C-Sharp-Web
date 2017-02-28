namespace SimpleMVC.App.MVC
{
    public class MvcContext
    {
        public static readonly MvcContext Current = new MvcContext();

        public string AssemblyName { get; set; }

        public string ControllersFolder { get; set; }

        public string ControllerSuffix { get; set; }

        public string ViewsFolder { get; set; }

        public string ModelsFolder { get; set; }
    }
}
