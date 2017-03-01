namespace SimpleMVC.App.Data.Models
{
    using System.Collections.Generic;

    public class User
    {
        private ICollection<Note> notes;

        public User()
        {
            this.notes = new HashSet<Note>();
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Note> Notes
        {
            get { return this.notes; }
            set { this.notes = value; }
        }
    }
}
