using System.Collections.Specialized;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.infrastructure;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    public class RequestSpecs
    {
        public abstract class concern : Observes<Request,
                                            DefaultRequest>
        {
        }

        [Subject(typeof(DefaultRequest))]
        public class when_mapping_an_input_model : concern
        {
            Establish e = () =>
            {
                the_mapped_item = new OurDepartment();
                input_model_mapper = the_dependency<InputModelMapper>();
                payload = new NameValueCollection();
                provide_a_basic_sut_constructor_argument(payload);

                input_model_mapper.Stub(x => x.map<OurDepartment>(payload)).Return(the_mapped_item);
            };

            Because b = () =>
                result = sut.map<OurDepartment>();

            It should_return_the_item_mapped_using_the_payload = () =>
                result.ShouldEqual(the_mapped_item);

            static OurDepartment result;
            static OurDepartment the_mapped_item;
            static InputModelMapper input_model_mapper;
            static NameValueCollection payload;
        }
    }

    public class OurDepartment
    {
        public string name { get; set; }
    }
}