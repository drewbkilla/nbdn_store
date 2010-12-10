using System.Collections.Specialized;

namespace nothinbutdotnetstore.web.infrastructure
{
    public interface InputModelMapper
    {
        InputModel map<InputModel>(NameValueCollection payload);
    }
}