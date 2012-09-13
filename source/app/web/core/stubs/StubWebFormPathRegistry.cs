using app.web.core.aspnet;

namespace app.web.core.stubs
{
  public class StubWebFormPathRegistry : IFindPathsToWebForms
  {
    public string get_the_path_to_view_for<ReportModel>()
    {
      return "~/views/DepartmentBrowser.aspx";
    }
  }
}