namespace DanielXOO.ShopParser.Controller
{
    interface IController
    {
        string GetRoot(string url);
        string GetCatalogName(string url);
        string ChangePage(string url, int pageNum);
    }
}
