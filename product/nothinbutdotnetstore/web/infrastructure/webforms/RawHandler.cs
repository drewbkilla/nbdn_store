using System.Web;
using nothinbutdotnetstore.stubs;
using nothinbutdotnetstore.web.infrastructure.stubs;

namespace nothinbutdotnetstore.web.infrastructure.webforms
{
    public class RawHandler : IHttpHandler
    {
        FrontController front_controller;
        RequestFactory request_factory;

        public RawHandler():this(new DefaultFrontController(),
            Stub.with<StubRequestFactory>())
        {
        }

        public RawHandler(FrontController front_controller, RequestFactory request_factory)
        {
            this.front_controller = front_controller;
            this.request_factory = request_factory;
        }

        public void ProcessRequest(HttpContext context)
        {
            front_controller.process(request_factory.create_from(context));
        }

        public bool IsReusable
        {
            get { return false;}
        }
    }
}