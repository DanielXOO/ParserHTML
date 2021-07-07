using System.Text.RegularExpressions;

namespace DanielXOO.ShopParser.Controller
{
    class OnlineShopController : IController
    {
        public string ChangePage(ref string url, int pageNum) 
            => url += $"page{pageNum}";
        

        public string GetCatalogName(string url)
        {
            var regex = new Regex(@"[/]\w+[-]\w+[/]");
            return ((regex.Match(url)).Value).Replace('/',' ');
        }

        public string GetRoot(string url)
        {
            var regex = new Regex(@"\w*[:][/]{2}\w*[.]\w*[.]\w*");
            return ((regex.Match(url)).Value).Replace("https://", null);
        }
    }
}
