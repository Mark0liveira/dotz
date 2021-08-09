namespace Dotz.ValueObjects
{
    public class ProductValueObject
    {
        public ProductValueObject(
            int id, 
            string title,
            DotzCoin dotzCoin, 
            int categoryId)
        {
            Id = id;
            Title = title;
            DotzCoin = dotzCoin;
            CategoryId = categoryId;
        }

        public int Id { get; private set; }

        public string Title { get; private set; }

        public DotzCoin DotzCoin { get; private set; }

        public int CategoryId { get; private set; }
    }
}
