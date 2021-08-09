using Dotz.Enums;
using Dotz.Models;
using Dotz.Utils;
using System;
using System.Collections.Generic;

namespace Dotz.ValueObjects
{
    public class OrderValueObject
    {
        private List<Product> _products;

        public OrderValueObject(
            Guid code,
            DeliveryStatus deliveryStatus,
            DateTime createdDate, 
            DateTime lastUpdateDate, 
            decimal total)
        {
            Code = GenerateHashCodeOrder(code);
            DeliveryStatus = deliveryStatus;
            CreatedDate = createdDate;
            LastUpdateDate = lastUpdateDate;
            Total = total;
            _products = new List<Product>();
        }

        public string Code { get; private set; }

        public IReadOnlyCollection<Product> Products { 
            get {
                return _products.ToArray();
            }
        }

        public DeliveryStatus DeliveryStatus { get; set; }

        public DateTime CreatedDate { get; private set; }

        public DateTime LastUpdateDate { get; private set; }

        public decimal Total { get; private set; }

        public void AddProduct(Product product)
        {
           _products.Add(product);
        }

        public string GenerateHashCodeOrder(Guid code)
        {
            return code == Guid.Empty ? GenerateHash.build() : code.ToString();
        }
    }
}
