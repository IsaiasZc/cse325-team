namespace MarketInventoryApplication.Data;

public static class SeedData
{
    public static void Initialize(MarketInventoryContext db)
    {
        var products = new Product[]
        {
            new Product()
            {
                Name = "Bacon",
                Description = "Is Bacon",
                Price = 8.8,
                ImageUrl = "img/products/bacon.jpg",
            },
            new Product()
            {
                Id = 2,
                Name = "Chicken",
                Description = "Is chicken",
                Price = 99.8,
                ImageUrl = "img/products/chicken.jpg",
            },
            new Product()
            {
                Id = 3,
                Name = "Box",
                Description = "Is a Box",
                Price = 45.6,
                ImageUrl = "img/products/box.jpg",
            },
            new Product()
            {
                Id = 4,
                Name = "Butter",
                Description = "Is Butter",
                Price = 12,
                ImageUrl = "img/products/butter.jpg",
            },
            new Product()
            {
                Id = 5,
                Name = "Mushroom",
                Description = "Is a Mushroom",
                Price = 342,
                ImageUrl = "img/products/mushroom.jpg",
            },
            new Product()
            {
                Id = 6,
                Name = "Cheese",
                Description = "Is Cheese",
                Price = 321,
                ImageUrl = "img/products/cheese.jpg",
            },
            new Product()
            {
                Id = 7,
                Name = "Pepperoni",
                Description = "Is Pepperony",
                Price = 12,
                ImageUrl = "img/products/pepperoni.jpg",
            },
        };
        db.Products.AddRange(products);
        db.SaveChanges();

        var users = new User[]
        {
            new User()
            {
                Name = "Admin",
                Password = "adminpassword",
                Level = 2,
            },
            new User()
            {
                Name = "User",
                Password = "userpassword",
                Level = 1,
            },
        };
        db.Users.AddRange(users);
        db.SaveChanges();
    }
}