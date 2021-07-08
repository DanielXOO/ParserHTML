using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;

namespace DanielXOO.ShopParser
{
    class ShopParser : IDataParser
    {
        public IEnumerable<IData> FilterData(IDataProvider DOM)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(DOM.GetData());

            var nameList = doc.DocumentNode.SelectNodes("//span[@class='prod-tv__name']");
            var priceList = doc.DocumentNode.SelectNodes("//div[@class='prod-tv__price']");

            var data = new List<Product>();
            var prodNames = from name in nameList
                            select new Product()
                            {
                                Name = name.InnerText,
                            };
            var res = prodNames.Zip(priceList,
                (name, price) => new Product() { Name = name.Name, Price = price.InnerText }
                );
            return res;
        }
    }
}
