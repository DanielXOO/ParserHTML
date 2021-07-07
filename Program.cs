
using DanielXOO.ShopParser.Service;

namespace DanielXOO.ShopParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var site = new OpenProvider("https://komp.1k.by/utility-graphicscards/");
            site.CheckPing();
            IDataParser info = new ShopParser();
            var arr = info.FilterData(site);
            IService Service = new ConsoleService();
            foreach(var data in arr)
            {
                Service.Log(data.ToString(), MsgLevel.Info);
            }
        }
    }
}
