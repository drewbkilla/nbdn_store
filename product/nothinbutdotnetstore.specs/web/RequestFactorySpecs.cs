using System.Web;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.web.infrastructure;

namespace nothinbutdotnetstore.specs.web
{
    public class RequestFactorySpecs
    {
        public abstract class concern : Observes<RequestFactory,
                                            DefaultRequestFactory>
        {
        }

        [Subject(typeof(DefaultRequestFactory))]
        public class when_creating_a_request : concern
        {
            Establish c = () =>
            {
                the_context = ObjectFactory.create_http_context();
                model_mapper = the_dependency<InputModelMapper>();
            };

            Because b = () =>
                result = sut.create_from(the_context);

            It should_return_a_request_with_the_correct_information = () =>
            {
                var actual = result.ShouldBeAn<DefaultRequest>();
                actual.payload.ShouldEqual(the_context.Request.Params);
                actual.input_model_mapper.ShouldEqual(model_mapper);
            };

            static Request result;
            static HttpContext the_context;
            static InputModelMapper model_mapper;
        }
    }
}