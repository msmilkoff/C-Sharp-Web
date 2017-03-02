namespace SimpleMVC.App.Views.Home
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using MVC.Interfaces.Generic;
    using ViewModels;

    public class Products : IRenderable<IEnumerable<ProductViewModel>>
    {
        public IEnumerable<ProductViewModel> Model { get; set; }

        public string Render()
        {
            string template = File.ReadAllText("../../content/products.html");

            var sb = new StringBuilder();
            foreach (var viewModel in this.Model)
            {
                sb.Append(viewModel);
            }

            return string.Format(template, sb);
        }
    }
}
