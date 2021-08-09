using Dotz.Data;
using Dotz.Enums;
using Dotz.Exceptions;
using Dotz.Models;
using Dotz.Shared;
using Dotz.ValueObjects;
using System;
using System.Linq;

namespace Dotz.Services
{
    public class ExtractService : ServiceBase
    {
        public ExtractAndBalanceValueObject GetExtractByUserId(int id, DataContext context)
        {
            var user = context.Users.FirstOrDefault(x => x.Id == id);

            if (user is null)
                throw new CustomException("Usuário não encontrado!");

            var extracts = context.Extract
                .Where(x => x.UserId == user.Id)
                .ToList();

            var valueObject = new ExtractAndBalanceValueObject(new DotzCoin(user.DotzCoin));

            foreach (var extract in extracts)
            {
                valueObject.AddExtract(extract);
            }

            return valueObject;
        }

        public async void CreateLogExtract(User user, Product product, DataContext context)
        {
            var extractOutput = new Extract()
            {
                Date = new DateTime(),
                DotzCoin = product.DotzCoin,
                ExtractType = ExtractType.OUTPUT,
                UserId = user.Id
            };
            context.Extract.Add(extractOutput);

            var extractInput = new Extract()
            {
                Date = new DateTime(),
                DotzCoin = product.DotzCoinReturned,
                ExtractType = ExtractType.INPUT,
                UserId = user.Id
            };
            context .Extract.Add(extractInput);
            context.SaveChanges();
        }
    }
}
