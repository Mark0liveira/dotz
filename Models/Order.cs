using Dotz.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dotz.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public Guid Code { get; set; }

        public List<Product> Products { get; set; }

        public DeliveryStatus DeliveryStatus { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdateDate { get; set; }

        public decimal Total { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
