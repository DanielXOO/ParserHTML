using System;
using DanielXOO.ShopParser.Controller;
using DanielXOO.ShopParser.Service;

namespace DanielXOO.ShopParser
{
    class Program
    {
        static void Main(string[] args)
        {
            IService debug = new ConsoleService();

            string url;
            debug.Log("Input URL: ", MsgLevel.Success);
            url = Console.ReadLine();
            var src = new OpenProvider(url);
            src.CheckPing();
            var parser = new ShopParser();
            foreach (var data in parser.FilterData(src))
            {
                Console.WriteLine(data.SerializeData());
            }
            debug.Log("Press any key", MsgLevel.Success);
            _ = Console.ReadKey();


        }
    }
}
