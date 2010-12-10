 using System;
 using System.Collections.Specialized;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.infrastructure;
 using nothinbutdotnetstore.web.application.mapping;
 using nothinbutdotnetstore.web.application.model;

namespace nothinbutdotnetstore.specs.web
{   
    public class DepartmentModelMapperSpecs
    {
        public abstract class concern : Observes<Mapper<NameValueCollection,Department>,
                                            DepartmentModelMapper>
        {
        
        }

        [Subject(typeof(DepartmentModelMapper))]
        public class when_mapping_a_department_and_all_the_information_is_present : concern
        {
            Establish c = () =>
            {
                prototype = new Department
                {
                    name = "This is the name of the item",
                    address = "This is the address",
                    age = 32,
                    birthday = new DateTime(1978, 8, 27),
                    is_skilled =  false
                };
                    
                payload = new NameValueCollection();
                payload.Add(SchemaConstraints.name,prototype.name);
                payload.Add(SchemaConstraints.address,prototype.address);
                payload.Add(SchemaConstraints.age,prototype.age.ToString());
                payload.Add(SchemaConstraints.birthday,prototype.birthday.ToString());
                payload.Add(SchemaConstraints.is_skilled,prototype.is_skilled.ToString());
            };

            Because b = () =>
                result = sut.map_from(payload);


            It should_return_a_department_with_all_details_correct = () =>
            {
                result.name.ShouldEqual(prototype.name);
                result.is_skilled.ShouldEqual(prototype.is_skilled);
                result.age.ShouldEqual(prototype.age);
                result.birthday.ShouldEqual(prototype.birthday);

            };

            static Department result;
            static Department prototype;
            static NameValueCollection payload;
        }
    }
}
