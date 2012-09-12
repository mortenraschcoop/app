using System.Web;

namespace app.web
{
    public class BasicHandler : IHttpHandler
    {
        IProcessWebRequests front_controller;
        private readonly ICreateRequests _createRequests;

        public BasicHandler(IProcessWebRequests front_controller, ICreateRequests createRequests)
        {
            this.front_controller = front_controller;
            _createRequests = createRequests;
        }

        public void ProcessRequest(HttpContext context)
        {
            front_controller.process(_createRequests.create_request_from(context));
        }

        public bool IsReusable
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}