 using System.Collections.Specialized;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.infrastructure;
 using nothinbutdotnetstore.web.infrastructure;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{   
    public class InputModelMapperSpecs
    {
        public abstract class concern : Observes<InputModelMapper,
                                            DefaultInputModelMapper>
        {
        
        }

        [Subject(typeof(DefaultInputModelMapper))]
        public class when_mapping_an_input_model_from_a_payload : concern
        {
            Establish c = () =>
            {
                the_payload = new NameValueCollection();
                the_mapped_item = new OurItem();
                mapper_registry = the_dependency<MapperRegistry>();
                mapper = an<Mapper<NameValueCollection,OurItem>>();

                mapper_registry.Stub(x => x.get_mapper_to_map<NameValueCollection, OurItem>()).Return(mapper);
                mapper.Stub(x => x.map_from(the_payload)).Return(the_mapped_item);
            };

            Because b = () =>
                result = sut.map<OurItem>(the_payload);


            It should_return_the_item_mapped_using_the_appropriate_mapper = () =>
                result.ShouldEqual(the_mapped_item);

            static OurItem result;
            static OurItem the_mapped_item;
            static NameValueCollection the_payload;
            static MapperRegistry mapper_registry;
            static Mapper<NameValueCollection, OurItem> mapper;
        }

        public class OurItem
    {
    }
    }

}
