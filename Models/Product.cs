using System.ComponentModel.DataAnnotations;

namespace Dotz.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal DotzCoin { get; set; }

        public decimal DotzCoinReturned { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}