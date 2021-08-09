using System.ComponentModel.DataAnnotations;

namespace Dotz.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
    }
}