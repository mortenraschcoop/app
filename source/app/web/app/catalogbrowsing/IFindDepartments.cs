using System.Collections.Generic;

namespace app.web.app.catalogbrowsing
{
  public interface IFindDepartments
  {
    IEnumerable<DepartmentItem> get_main_departments();
    IEnumerable<DepartmentItem> get_departments_in_a_given_department(DepartmentItem parent_department);
  }
}