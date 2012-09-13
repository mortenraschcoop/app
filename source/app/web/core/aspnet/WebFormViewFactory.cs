using System.Web;
using System.Web.Compilation;
using app.web.core.stubs;

namespace app.web.core.aspnet
{
  public class WebFormViewFactory : ICreateWebFormViews
  {
    IFindPathsToWebForms find_path;
    CreatePage_Behaviour raw_page_factory;

    public WebFormViewFactory(IFindPathsToWebForms find_path, CreatePage_Behaviour raw_page_factory)
    {
      this.find_path = find_path;
      this.raw_page_factory = raw_page_factory;
    }

    public WebFormViewFactory():this(new StubWebFormPathRegistry(),BuildManager.CreateInstanceFromVirtualPath)
    {
    }

    public IHttpHandler create_view_to_display<ReportModel>(ReportModel info)
    {
      var path = find_path.get_the_path_to_view_for<ReportModel>();
      var view = (IDisplayA<ReportModel>)raw_page_factory(path,typeof(IDisplayA<ReportModel>));
      view.report_model = info;
      return view;
    }
  }
}