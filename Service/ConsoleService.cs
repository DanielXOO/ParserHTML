using System;

namespace DanielXOO.ShopParser.Service
{
    class ConsoleService : IService
    {
        public void Log(string msg, MsgLevel lvl)
        {
            switch (lvl)
            {
                case MsgLevel.Info:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{DateTime.Now} | Info | {msg}");
                    break;
                case MsgLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{DateTime.Now} | Warning | {msg}");
                    break;
                case MsgLevel.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{DateTime.Now} | Error | {msg}");
                    break;
            }
            Console.ResetColor();
        }
    }
}
