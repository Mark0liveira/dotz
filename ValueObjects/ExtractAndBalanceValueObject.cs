using Dotz.Models;
using System.Collections.Generic;
using Dotz.Shared;

namespace Dotz.ValueObjects
{
    public class ExtractAndBalanceValueObject : ValueObject
    {
        private List<Extract> _extracts;

        public ExtractAndBalanceValueObject(DotzCoin dotzBalance)
        {
            DotzBalance = dotzBalance;
            _extracts = new List<Extract>();
        }

        public DotzCoin DotzBalance { get; private set; }

        public IReadOnlyCollection<Extract> Extracts
        {
            get
            {
                return _extracts.ToArray();
            }
        }

        public void AddExtract(Extract extract)
        {
            _extracts.Add(extract);
        }
    }
}
