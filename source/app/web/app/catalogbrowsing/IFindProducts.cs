using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.web.app.catalogbrowsing
{
    public interface IFindProducts
    {
        IEnumerable<ProductItem> get_products(DepartmentItem map);
    }
}
