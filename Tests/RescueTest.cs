using Dotz.Data;
using Dotz.Services;
using Dotz.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotz.Tests
{
    [TestClass]
    public class RescueTest
    {
        private readonly RescueService _rescueService;

        public RescueTest()
        {
            _rescueService = new RescueService();
        }

        [TestMethod]
        public void CreateRescue([FromServices] DataContext context)
        {
            RescueProductValueObject valueObject = new RescueProductValueObject
            {
                UserId = 1,
                ProductId = 1,
            };

            var result = _rescueService.RescueProduct(valueObject, context).Result;

            Assert.AreEqual(result.ProductId, 2);
        }
    }
}
