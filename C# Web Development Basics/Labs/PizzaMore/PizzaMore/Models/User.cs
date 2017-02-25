namespace Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        private ICollection<Pizza> pizzas;

        public User()
        {
            this.pizzas = new HashSet<Pizza>();
        }
        
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public virtual ICollection<Pizza> PizzaSuggestions
        {
            get { return this.pizzas; }
            set { this.pizzas = value; }
        }
    }
}
