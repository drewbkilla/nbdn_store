using System;
using System.Collections.Specialized;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.web.infrastructure
{
    public class DefaultInputModelMapper : InputModelMapper
    {
        MapperRegistry mapper_registry;

        public DefaultInputModelMapper(MapperRegistry mapper_registry)
        {
            this.mapper_registry = mapper_registry;
        }

        public InputModel map<InputModel>(NameValueCollection payload)
        {
            var mapper = mapper_registry.get_mapper_to_map<NameValueCollection,InputModel>();
            return mapper.map_from(payload);
        }
    }
}