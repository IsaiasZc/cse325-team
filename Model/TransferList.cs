using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace MarketInventoryApplication
{
    public class TransferList
    {

        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }

        public Product? Product { get; set; }

        public int LocationId { get; set; }

        public Location? Location { get; set; }

        public int ModifiedByUserId { get; set; }

        public User? ModifiedByUser { get; set; }
        public int Quantity { get; set; }
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;

    }
}