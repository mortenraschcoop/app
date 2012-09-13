using System.Collections.Generic;
using Machine.Specifications;
using app.web.app.catalogbrowsing;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(ViewTheDepartmentsInADeparment))]
  public class ViewTheDepartmentsInADeparmentsSpecs
  {
    public abstract class concern : Observes<IImplementAFeature, ViewTheDepartmentsInADeparment>
    {
      Establish context = () =>
      {
      };
    }

    public class when_run : concern
    {
      Establish context = () =>
      {
        department_repository = depends.on<IFindDepartments>();
        display_engine = depends.on<IDisplayInformation>();
        request = fake.an<IEncapsulateRequestDetails>();
        the_child_departments = new List<DepartmentItem> {new DepartmentItem()};
        request.setup(x => x.map<CurrentDepartment>()).Return(the_parent);
        department_repository.setup(x => x.get_child_departments(the_parent)).Return(the_child_departments);
      };

      Because b = () => sut.process(request);

      It should_display_a_list_of_departments_from_a_department =
        () => display_engine.received(x => x.display(the_child_departments));

      static IDisplayInformation display_engine;
      static IEncapsulateRequestDetails request;
      static IFindDepartments department_repository;
      static IEnumerable<DepartmentItem> the_child_departments;
      static CurrentDepartment the_parent;
    }
  }
}