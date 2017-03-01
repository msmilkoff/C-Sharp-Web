namespace SimpleMVC.App.Views.Users
{
    using System.Text;
    using MVC.Interfaces.Generic;
    using ViewModels;

    public class All : IRenderable<AllUsernamesViewModel>
    {
        public AllUsernamesViewModel Model { get; set; }

        public string Render()
        {
            var sb = new StringBuilder();
            sb.AppendLine("<h3>All users</h3>");
            sb.AppendLine("<ul>");

            foreach (var username in this.Model.Usernames)
            {
                sb.AppendLine($"<li><a href=\"users/profile?id={username.Key}\">{username.Value}</a></li>");
            }

            sb.AppendLine("</ul>");
            return sb.ToString();
        }
    }
}
