using app.web.app.catalogbrowsing.stubs;
using app.web.core;
using app.web.core.aspnet;

namespace app.web.app.catalogbrowsing
{
  public class ViewTheProductInTheDepartment : IImplementAFeature
  {
    IFindProducts products;
    IDisplayInformation display_engine;

    public ViewTheProductInTheDepartment(IFindProducts products, IDisplayInformation display_engine)
    {
      this.display_engine = display_engine;
      this.products = products;
    }

    public ViewTheProductInTheDepartment():this(new StubProductsRepository(),
      new WebFormDisplayEngine())

    {
    }

    public void process(IEncapsulateRequestDetails request)
    {
      display_engine.display(products.get_products_in(request.map<CurrentDepartment>()));
    }
  }
}