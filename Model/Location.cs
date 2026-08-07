using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

 namespace MarketInventoryApplication;

public class Location
{
    [Key]
    public int Id { get; set; }


    [Required]
    public string Name { get; set; }

   [JsonIgnore]
    public ICollection<TransferList> Transfers { get; set; }
}