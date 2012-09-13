using System;
using System.Collections.Generic;
using app.web.app.catalogbrowsing;
using app.web.core.aspnet;

namespace app.web.core.stubs
{
  public class StubWebFormPathRegistry : IFindPathsToWebForms
  {
    public string get_the_path_to_view_for<ReportModel>()
    {
      var views = new Dictionary<Type, string>
      {
        {typeof(IEnumerable<DepartmentItem>), create_path_for("DepartmentBrowser")},
        {typeof(IEnumerable<ProductItem>), create_path_for("ProductBrowser")}
      };
      return views[typeof(ReportModel)];
    }

    string create_path_for(string page)
    {
      return string.Format("~/views/{0}.aspx");
    }
  }
}