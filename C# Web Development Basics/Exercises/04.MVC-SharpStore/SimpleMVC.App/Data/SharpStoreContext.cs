namespace SimpleMVC.App.Data
{
    using System.Data.Entity;
    using Models;

    public class SharpStoreContext : DbContext
    {
        public SharpStoreContext()
            : base("name=SharpStore")
        {
        }

        public IDbSet<Knife> Knives { get; set; }
    }
}