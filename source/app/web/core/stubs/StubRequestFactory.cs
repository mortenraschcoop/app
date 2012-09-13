using System;
using System.Web;
using app.web.app.catalogbrowsing;

namespace app.web.core.stubs
{
  public class StubRequestFactory : ICreateRequests
  {
    public IEncapsulateRequestDetails create_request_from(HttpContext http_context)
    {
      return new StubRequest();
    }

    class StubRequest : IEncapsulateRequestDetails
    {
      public int department_id { get; set; }

      public InputModel map<InputModel>()
      {
        object item = new CurrentDepartment();
        return (InputModel) item;
      }
    }
  }
}