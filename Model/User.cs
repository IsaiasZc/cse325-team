using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace MarketInventoryApplication
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Level { get; set; }

        public bool IsAdmin => Level >= 2;

        public string RoleName => IsAdmin ? Roles.Administrator : Roles.User;
        [JsonIgnore]
        public ICollection<TransferList> ModifiedTransfers { get; set; }
    }
}
