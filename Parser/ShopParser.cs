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

            var nameList = doc.DocumentNode.SelectNodes("//a[@class='prod__link']");
            var priceList = doc.DocumentNode.SelectNodes("//a[@class='money__val']");

            IEnumerable<Product> res;

            if(nameList != null && priceList != null)
            {
                var data = new List<Product>();
                var prodNames = from name in nameList
                                select new Product()
                                {
                                    Name = name.InnerText,
                                };
                res = prodNames.Zip(priceList,
                    (name, price) => new Product() { Name = name.Name, Price = price.InnerText }
                    );
            }
            else
            {
                res = null;
            }

            return res;
        }
    }
}
