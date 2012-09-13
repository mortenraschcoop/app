using System.Collections.Generic;
using Machine.Specifications;
using app.web.app.catalogbrowsing;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
    [Subject(typeof(ViewTheProductInTheDepartment))]
    public class ViewTheProductInTheDepartmentSpecs
    {
        public abstract class concern : Observes<IImplementAFeature,
                                            ViewTheProductInTheDepartment>
        {
        }

        public class when_run : concern
        {
            Establish c = () =>
                              {
                                  department_repository = depends.on<IFindProducts>();
                                  display_engine = depends.on<IDisplayInformation>();
                                  request = fake.an<IEncapsulateRequestDetails>();
                                  the_products = new List<ProductItem> { new ProductItem() };

                                  department_repository.setup(x => x.get_products(request.map<DepartmentItem>())).Return(the_products);
                              };

            Because b = () =>
                        sut.process(request);


            It should_display_the_products = () =>
                                             display_engine.received(x => x.display(the_products));



            static IEncapsulateRequestDetails request;
            static IFindProducts department_repository;
            static IDisplayInformation display_engine;
            static IEnumerable<ProductItem> the_products;
        }
    }
}