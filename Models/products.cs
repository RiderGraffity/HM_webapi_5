namespace HM_webapi_5.Models
{
    public class products
    {
        public Guid Id { get; } = Guid.NewGuid(); 
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty; 
        public decimal Price { get; set; }



        public products(string name, string description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

    }

}
