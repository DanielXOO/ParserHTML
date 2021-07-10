using System;

namespace DanielXOO.ShopParser
{
    interface IDataProvider
    {
        Uri Link { get; set; }
        string GetData();
        void CheckPing();

    }
}
