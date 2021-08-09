using System.ComponentModel.DataAnnotations;

namespace Dotz.Models
{
    public class DeliveryAddress
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "CEP é obrigatório!")]
        public string ZipCode { get; set; }

        public string Street { get; set; }

        public int? Number { get; set; }

        public string Complement { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public bool Enabled { get; set; } = true;

        [Required(ErrorMessage = "Id do usuário é obrigatório!")]
        public int? UserId { get; set; }

        public User User { get; set; }
    }
}
