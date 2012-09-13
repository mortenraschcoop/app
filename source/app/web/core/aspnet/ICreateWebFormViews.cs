using System.Web;

namespace app.web.core.aspnet
{
  public interface ICreateWebFormViews
  {
    IHttpHandler create_view_to_display<TheData>(TheData info);
  }
}