namespace DanielXOO.ShopParser
{
    class Product : IData
    {
        public string Source { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string SerializeData()
        {
            return $"Source {Source}, Price {Price}, Description{Description}";
        }
    }
}
