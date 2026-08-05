namespace MarketInventoryApplication.Data;

public static class SeedData
{
    public static void Initialize(MarketInventoryContext db)
    {
        if(db.Products.Any())
            {
                return;
            }
        var products = new Product[]
        {
            new Product()
            {
                Name = "Bacon",
                Description = "Is Bacon",
                Price = 8.8,
                ImageUrl = "https://images.unsplash.com/photo-1742859052497-f8bbc8366a32?q=80&w=870&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
            },
            new Product()
            {
                Id = 2,
                Name = "Chicken",
                Description = "Is chicken",
                Price = 99.8,
                ImageUrl = "https://images.unsplash.com/photo-1587593810167-a84920ea0781?q=80&w=870&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
            },
            new Product()
            {
                Id = 3,
                Name = "Box",
                Description = "Is a Box",
                Price = 45.6,
                ImageUrl = "https://images.unsplash.com/photo-1656543802898-41c8c46683a7?q=80&w=871&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
            },
            new Product()
            {
                Id = 4,
                Name = "Butter",
                Description = "Is Butter",
                Price = 12,
                ImageUrl = "https://images.unsplash.com/photo-1589985270826-4b7bb135bc9d?q=80&w=870&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
            },
            new Product()
            {
                Id = 5,
                Name = "Mushroom",
                Description = "Is a Mushroom",
                Price = 342,
                ImageUrl = "https://images.unsplash.com/photo-1552825897-bb5efa86eab1?q=80&w=870&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
            },
            new Product()
            {
                Id = 6,
                Name = "Cheese",
                Description = "Is Cheese",
                Price = 321,
                ImageUrl = "https://images.unsplash.com/photo-1683314573424-b0da0c795a07?q=80&w=870&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
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