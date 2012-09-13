using app.web.app.catalogbrowsing.stubs;
using app.web.core;
using app.web.core.aspnet;

namespace app.web.app.catalogbrowsing
{
  public class ViewTheDepartmentsInADeparment : IImplementAFeature
  {
    IDisplayInformation engine;
    IFindDepartments departments;

    public ViewTheDepartmentsInADeparment(IDisplayInformation engine, IFindDepartments departments)
    {
      this.engine = engine;
      this.departments = departments;
    }

    public ViewTheDepartmentsInADeparment():this(new WebFormDisplayEngine(),
      new StubDepartmentRepository())
    {
    }

    public void process(IEncapsulateRequestDetails request)
    {
      engine.display(departments.get_child_departments(request.map<CurrentDepartment>()));
    }
  }
}