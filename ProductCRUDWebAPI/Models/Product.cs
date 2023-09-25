

namespace ProductCRUDWebAPI.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Quanity { get; set; }
        public string Description { get; set; }
    }
}
