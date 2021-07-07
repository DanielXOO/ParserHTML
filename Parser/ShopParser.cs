using HtmlAgilityPack;

namespace DanielXOO.ShopParser
{
    class ShopParser : IDataParser
    {
        public IData[] FilterData(IDataProvider DOM)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(DOM.GetData());
            
            var nameList = doc.DocumentNode.SelectNodes("//span[@class='prod-tv__name']");
           
            var priceList = doc.DocumentNode.SelectNodes("//div[@class='prod-tv__price']");
            
            var descList = doc.DocumentNode.SelectNodes("//div[@class='prod-line__descr']");

            return null;
        }
    }
}
