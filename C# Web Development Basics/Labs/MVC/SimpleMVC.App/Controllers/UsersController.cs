namespace SimpleMVC.App.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using BindingModels;
    using Data;
    using Data.Models;
    using MVC.Attributes.Methods;
    using MVC.Controllers;
    using MVC.Interfaces;
    using MVC.Interfaces.Generic;
    using ViewModels;

    public class UsersController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserBindingModel model)
        {
            var user = new User
            {
                Username = model.Username,
                Password = model.Password
            };

            using(var context = new NotesContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }

            return View();
        }

        public IActionResult<AllUsernamesViewModel> All()
        {
            Dictionary<int, string> usernames = null;
            using (var context = new NotesContext())
            {
                usernames = context.Users
                    .Select(x => new
                    {
                        Id = x.Id,
                        Username = x.Username
                    })
                    .ToDictionary(x => x.Id, x => x.Username);
            }

            var viewModel = new AllUsernamesViewModel
            {
                Usernames = usernames
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult<UserProfileViewModel> Profile(int id)
        {
            using (var context = new NotesContext())
            {
                var user = context.Users.Find(id);
                var viewModel = new UserProfileViewModel
                {
                    UserId = user.Id,
                    Username = user.Username,
                    Notes = user.Notes
                        .Select(n =>
                        new NoteViewModel
                        {
                            Title = n.Title,
                            Content = n.Content
                        }
                    )
                };

                return View(viewModel);
            }
        }

        [HttpPost]
        public IActionResult<UserProfileViewModel> Profile(AddNoteBindingModel model)
        {
            using (var context = new NotesContext())
            {
                var user = context.Users.Find(model.UserId);
                var note = new Note
                {
                    Title = model.Title,
                    Content = model.Content
                };

                user.Notes.Add(note);
                context.SaveChanges();
            }

            return this.Profile(model.UserId);
        }
    }
}
