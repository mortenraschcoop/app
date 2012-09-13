using System.Web;

namespace app.web.core.aspnet
{
  public class WebFormDisplayEngine : IDisplayInformation
  {
    ICreateWebFormViews web_form_view_registry;
    GetTheCurrentContext_Behaviour current_context_resolution;

    public WebFormDisplayEngine(ICreateWebFormViews web_form_view_registry,
                                GetTheCurrentContext_Behaviour current_context_resolution)
    {
      this.web_form_view_registry = web_form_view_registry;
      this.current_context_resolution = current_context_resolution;
    }

    public WebFormDisplayEngine():this(new WebFormViewFactory(),() => HttpContext.Current)
    {
    }

    public void display<ReportModel>(ReportModel model)
    {
      web_form_view_registry.create_view_to_display(model).ProcessRequest(current_context_resolution());
    }
  }
}