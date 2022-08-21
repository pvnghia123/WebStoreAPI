namespace WebStoreAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
        public string? Color { get; set; }
        public string? UnitPrice { get; set; }
        public int? AvailableQuantity { get; set; }


    }
}
