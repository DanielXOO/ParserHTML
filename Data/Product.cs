namespace DanielXOO.ShopParser
{
    class Product : IData
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string Source { get; set; }

        public string SerializeData()
        {
            return $"Name: {Name.Trim()}, Price: {Price.Trim()}";
        }
    }
}
