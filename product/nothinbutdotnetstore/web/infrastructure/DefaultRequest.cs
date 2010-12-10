using System.Collections.Specialized;

namespace nothinbutdotnetstore.web.infrastructure
{
    public class DefaultRequest : Request
    {
        public InputModelMapper input_model_mapper;
        public NameValueCollection payload;

        public DefaultRequest(InputModelMapper input_model_mapper, NameValueCollection payload)
        {
            this.input_model_mapper = input_model_mapper;
            this.payload = payload;
        }

        public InputModel map<InputModel>()
        {
            return input_model_mapper.map<InputModel>(payload);
        }
    }
}