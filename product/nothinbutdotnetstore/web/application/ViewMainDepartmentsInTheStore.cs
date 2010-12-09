using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.infrastructure;
using nothinbutdotnetstore.web.infrastructure.stubs;

namespace nothinbutdotnetstore.web.application
{
    public class ViewDepartmentInTheDepartmentsList : ApplicationCommand
    {
        Repository repository;
        ResponseEngine response_engine;

        public ViewDepartmentInTheDepartmentsList():this(new StubRepository(),
            new StubResponseEngine())
        {
        }

        public ViewDepartmentInTheDepartmentsList(Repository repository, ResponseEngine response_engine)
        {
            this.repository = repository;
            this.response_engine = response_engine;
        }

        public void process(Request request)
        {
            response_engine.prepare(repository.get_department_from_department_list_in_the_store());
        }
    }
}