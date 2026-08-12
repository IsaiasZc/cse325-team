using MarketInventoryApplication.Services;

namespace MarketInventoryApplication.Data;

public static class SeedData
{
    public static void Initialize(MarketInventoryContext db)
    {
        // Seed Products
        if (!db.Products.Any())
        {
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
        }

        // Seed Users
        if (!db.Users.Any())
        {
            var users = new User[]
            {
                new User()
                {
                    Name = "Admin",
                    Password = PasswordHasher.Hash("adminpassword"),
                    Level = 2,
                },
                new User()
                {
                    Name = "User",
                    Password = PasswordHasher.Hash("userpassword"),
                    Level = 1,
                },
            };

            db.Users.AddRange(users);
            db.SaveChanges();
        }

        // Seed Locations
        if (!db.Locations.Any())
        {
            var locations = new Location[]
            {
                new Location()
                {
                    Name = "Warehouse"
                },
                new Location()
                {
                    Name = "Front Store"
                },
                new Location()
                {
                    Name = "Storage Room"
                }
            };

            db.Locations.AddRange(locations);
            db.SaveChanges();
        }

        // Seed Transfer List
        if (!db.TransferList.Any())
        {
            var transfers = new TransferList[]
            {
                new TransferList()
                {
                    ProductId = 1,
                    LocationId = 1,
                    ModifiedByUserId = 1,
                    Quantity = 20,
                    ModifiedDate = DateTime.UtcNow
                },
                new TransferList()
                {
                    ProductId = 2,
                    LocationId = 2,
                    ModifiedByUserId = 2,
                    Quantity = 15,
                    ModifiedDate = DateTime.UtcNow
                },
                new TransferList()
                {
                    ProductId = 3,
                    LocationId = 3,
                    ModifiedByUserId = 1,
                    Quantity = 30,
                    ModifiedDate = DateTime.UtcNow
                }
            };

            db.TransferList.AddRange(transfers);
            db.SaveChanges();
        }
    }
}
