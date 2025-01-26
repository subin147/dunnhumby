namespace ProductManagment.Api.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public  decimal Price { get; set; } 
        public  string SKU { get; set; } = null!;
        public int StockQuantity { get; set; }
        public DateTime DateAdded { get; set; }

        public virtual Category Category { get; set; } = null!;
    }
}
