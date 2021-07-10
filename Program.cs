using System;
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

            if (!string.IsNullOrWhiteSpace(url))
            {
                src.CheckPing();
                var parser = new ShopParser();
                var info = parser.FilterData(src);

                if (info != null)
                {
                    foreach (var data in info)
                    {
                        Console.WriteLine(data.SerializeData());
                    }
                }
                else
                {
                    debug.Log("No data", MsgLevel.Warning);
                }

                debug.Log("Press any key", MsgLevel.Success);
                _ = Console.ReadKey();
            }
        }
    }
}
