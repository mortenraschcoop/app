using System.Collections.Generic;
using app.web.core;

namespace app.web.app.catalogbrowsing
{
  public interface IFindDepartments
  {
    IEnumerable<DepartmentItem> get_main_departments();
    IEnumerable<DepartmentItem> get_child_departments(CurrentDepartment departmentId);
  }
}