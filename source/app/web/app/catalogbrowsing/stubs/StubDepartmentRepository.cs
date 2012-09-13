using System.Collections.Generic;
using System.Linq;

namespace app.web.app.catalogbrowsing.stubs
{
  public class StubDepartmentRepository : IFindDepartments
  {
    public IEnumerable<DepartmentItem> get_main_departments()
    {
      return Enumerable.Range(1, 100).Select(x => new DepartmentItem{name = x.ToString("Department 0")});
    }

      public IEnumerable<DepartmentItem> get_departments_in_a_given_department(DepartmentItem parent_department)
      {
          throw new System.NotImplementedException();
      }
  }
}