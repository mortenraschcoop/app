using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using app.web.core;

namespace app.web.app.catalogbrowsing
{
    public class ViewTheProductInTheDepartment : IImplementAFeature
    {
        IFindProducts find_products;
        IDisplayInformation display_engine;

        public ViewTheProductInTheDepartment(IFindProducts findProducts, IDisplayInformation displayEngine)
        {
            display_engine = displayEngine;
            find_products = findProducts;
        }

        public void process(IEncapsulateRequestDetails request)
        {
            var products = find_products.get_products(request.map<DepartmentItem>());
            display_engine.display(products);
        }
    }
}
