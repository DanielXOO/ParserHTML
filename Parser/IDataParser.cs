using System.Collections.Generic;

namespace DanielXOO.ShopParser
{
    interface IDataParser
    {
        IEnumerable<IData> FilterData(IDataProvider DOM);
    }
}
