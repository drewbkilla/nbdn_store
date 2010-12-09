using System.Collections.Generic;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.application.model;
using nothinbutdotnetstore.web.infrastructure;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    public class ViewDepartmentInTheDepartmentsListSpecs
    {
        public abstract class concern : Observes<ApplicationCommand,
                                            ViewDepartmentInTheDepartmentsList>
        {
        }

        [Subject(typeof(ViewDepartmentInTheDepartmentsListSpecs))]
        public class when_selecting_a_department : concern
        {
            Establish c = () =>
            {
                response_engine = the_dependency<ResponseEngine>();
                department_repository = the_dependency<Repository>();
                the_sub_department = new Department();
                request = an<Request>();

                department_repository.Stub(x => x.get_department_from_department_list_in_the_store()).Return(
                    the_sub_department);
            };

            Because b = () =>
                sut.process(request);

            It should_tell_the_response_to_display_the_sub_department = () =>
                response_engine.received(x => x.prepare(the_sub_department));

            static Repository department_repository;
            static Request request;
            static Department the_sub_department;
            static ResponseEngine response_engine;
        }
    }
}