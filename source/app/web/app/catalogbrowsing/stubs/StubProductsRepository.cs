using System.Collections.Generic;
using System.Linq;

namespace app.web.app.catalogbrowsing.stubs
{
  public class StubProductsRepository : IFindProducts
  {
    public IEnumerable<ProductItem> get_products_in(CurrentDepartment map)
    {
      return Enumerable.Range(1, 100).Select(x => new ProductItem
      {
        
      });
    }
  }
}