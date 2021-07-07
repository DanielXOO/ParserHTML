using System.Collections.Generic;

namespace DanielXOO.ShopParser
{
    interface IDataParser
    {
        IData[] FilterData(IDataProvider DOM);
    }
}
