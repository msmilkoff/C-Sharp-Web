namespace SimpleMVC.App.Migrations
{
    using System.Data.Entity.Migrations;
    using Data;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<SharpStoreContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SharpStoreContext context)
        {
            context.Knives.AddOrUpdate(
                new Knife
                {
                    Name = "Ultimate 2000",
                    ImageUrl = "https://placehold.it/300x150",
                    Price = 20m
                },
                new Knife
                {
                    Name = "Mega 100",
                    ImageUrl = "https://placehold.it/300x150",
                    Price = 30m
                },
                new Knife
                {
                    Name = "Tera 500sx",
                    ImageUrl = "https://placehold.it/300x150",
                    Price = 150m
                },
                new Knife
                {
                    Name = "Tera 500",
                    ImageUrl = "https://placehold.it/300x150",
                    Price = 49.99m
                },
                new Knife
                {
                    Name = "Femta 150",
                    ImageUrl = "https://placehold.it/300x150",
                    Price = 114.59m
                }
            );
        }
    }
}
