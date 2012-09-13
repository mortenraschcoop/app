using System.Collections.Generic;
using System.Linq;

namespace app.web.app.catalogbrowsing.stubs
{
  public class StubDepartmentRepository : IFindDepartments
  {
    public IEnumerable<DepartmentItem> get_main_departments()
    {
      return Enumerable.Range(1, 100).Select(x => new DepartmentItem {name = x.ToString("Department 0")});
    }

    public IEnumerable<DepartmentItem> get_child_departments(CurrentDepartment departmentId)
    {
      return Enumerable.Range(1, 100).Select(x => new DepartmentItem {name = x.ToString("Sub Department 0")});
    }
  }


  public class StubProductsRepository : IFindProducts
  {
      public IEnumerable<ProductItem> get_products(DepartmentItem map)
      {
          return Enumerable.Range(1, 100).Select(x => new ProductItem {});
      }
  }
}