using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using app.web.app.catalogbrowsing;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
    [Subject(typeof(ViewTheProductsInADepartment))]
    class ViewTheProductsInADepartmentSpec
    {
        public abstract class concern : Observes<IImplementAFeature, ViewTheProductsInADepartment>
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
                the_child_departments = new List<DepartmentItem> { new DepartmentItem() };
                request.setup(x => x.map<CurrentDepartment>()).Return(the_parent);
                department_repository.setup(x => x.get_child_departments(the_parent)).Return(the_child_departments);
            };

            Because b = () => sut.process(request);

            It should_display_a_list_of_products_in_a_department =
              () => display_engine.received(x => x.display(the_child_departments));

            static IDisplayInformation display_engine;
            static IEncapsulateRequestDetails request;
            static IFindDepartments department_repository;
            static IEnumerable<DepartmentItem> the_child_departments;
            static CurrentDepartment the_parent;
        }
    }

    public class ViewTheProductsInADepartment : IImplementAFeature
    {
        public void process(IEncapsulateRequestDetails request)
        {
            throw new NotImplementedException();
        }
    }
}
