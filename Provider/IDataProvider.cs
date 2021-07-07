using DanielXOO.ShopParser.Service;

namespace DanielXOO.ShopParser
{
    interface IDataProvider
    {
        string Link { get; set; }
        string GetData();
        void CheckPing();

    }
}
