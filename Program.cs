using DanielXOO.ShopParser.Controller;

namespace DanielXOO.ShopParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var site = new OpenProvider("https://komp.1k.by/mobile-monoblocks/");
            site.CheckPing();
        }
    }
}
