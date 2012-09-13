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
    [Subject(typeof(ViewTheDepartmentsInADepartment))]
    public class ViewTheDepartmentsInADepartmentSpec
    {
        public abstract class concern : Observes<IImplementAFeature, ViewTheDepartmentsInADepartment>
        {
        }


        public class when_run : concern
        {
            Establish c = () =>
            {
                department_repository = depends.on<IFindDepartments>();
                display_engine = depends.on<IDisplayInformation>();
                request = fake.an<IEncapsulateRequestDetails>();
                the_departments_in_a_given_department = new List<DepartmentItem> { new DepartmentItem() };
                DepartmentItem parent_department = new DepartmentItem();
                department_repository.setup(x => x.get_departments_in_a_given_department(parent_department)).Return(the_departments_in_a_given_department);
            };


            Because b = () =>
              sut.process(request);

            It should_display_the_departmenst_in_a_given_department = () =>
              display_engine.received(x => x.display(the_departments_in_a_given_department));



            static IEncapsulateRequestDetails request;
            static IDisplayInformation display_engine;
            private static IEnumerable<DepartmentItem> the_departments_in_a_given_department;
            static IFindDepartments department_repository;

        }
    }

    public class ViewTheDepartmentsInADepartment : IImplementAFeature
    {
        public void process(IEncapsulateRequestDetails request)
        {
            throw new NotImplementedException();
        }
    }
}
