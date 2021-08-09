using Dotz.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Dotz.Models
{
    public class Extract
    {
        [Key]
        public int Id { get; set; }

        public ExtractType ExtractType { get; set; }

        public decimal DotzCoin { get; set; }

        public DateTime Date { get; set; }

        public int UserId { get; set; }
    }
}
