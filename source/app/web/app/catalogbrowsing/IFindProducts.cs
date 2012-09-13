using System.Collections.Generic;

namespace app.web.app.catalogbrowsing
{
  public interface IFindProducts
  {
    IEnumerable<ProductItem> get_products_in(CurrentDepartment department);
  }
}