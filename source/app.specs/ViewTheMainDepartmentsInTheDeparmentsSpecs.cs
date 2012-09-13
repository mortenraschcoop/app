using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Rhino.Mocks.Constraints;
using app.web.app.catalogbrowsing;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
    [Subject(typeof(ViewTheMainDepartmentsInTheDeparments))]
    public class ViewTheMainDepartmentsInTheDeparmentsSpecs
    {

        public abstract class concern : Observes<IImplementAFeature, ViewTheMainDepartmentsInTheDeparments>
        {
            Establish context = () => { };
        }


        public class when_run : concern
        {
            Establish context = () =>
                                    {
                                        department_repository = depends.on<IFindDepartments>();
                                        display_engine = depends.on<IDisplayInformation>();
                                        request = fake.an<IEncapsulateRequestDetails>();
                                        the_child_departments = new List<DepartmentItem> { new DepartmentItem() };
                                        department_repository.setup(x => x.get_child_departments(request.department_id)).Return(the_child_departments);
                                    };

            Because b = () => sut.process(request);

            It should_display_a_list_of_departments_from_a_department = () => display_engine.received(x=>x.display(the_child_departments));


            static IDisplayInformation display_engine;
            static IEncapsulateRequestDetails request;
            static IFindDepartments department_repository;
            static IEnumerable<DepartmentItem> the_child_departments;
        }
    }
}
