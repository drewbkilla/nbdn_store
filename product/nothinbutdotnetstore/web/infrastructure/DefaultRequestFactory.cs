using System.Web;

namespace nothinbutdotnetstore.web.infrastructure
{
    public class DefaultRequestFactory : RequestFactory
    {
        InputModelMapper mapper;

        public DefaultRequestFactory(InputModelMapper mapper)
        {
            this.mapper = mapper;
        }

        public Request create_from(HttpContext the_http_context)
        {
            return new DefaultRequest(mapper,
                                      the_http_context.Request.Params);
        }
    }
}