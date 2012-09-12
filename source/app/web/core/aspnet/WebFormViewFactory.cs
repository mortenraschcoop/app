using System.Web;

namespace app.web.core.aspnet
{
    public class WebFormViewFactory : IFindWebFormViews
    {
        readonly IFindPathsToWebForms find_path;

        public WebFormViewFactory(IFindPathsToWebForms find_path)
        {
            this.find_path = find_path;
        }

        public IHttpHandler create_view_to_display<TheData>(TheData info)
        {
            var path = find_path.get_the_path_to_view_for<TheData>();

            return null;
        }
    }
}