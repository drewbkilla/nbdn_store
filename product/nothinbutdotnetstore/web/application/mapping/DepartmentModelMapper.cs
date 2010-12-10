using System;
using System.Collections.Specialized;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.web.application.model;

namespace nothinbutdotnetstore.web.application.mapping
{
    public class DepartmentModelMapper : Mapper<NameValueCollection, Department>
    {
        public Department map_from(NameValueCollection input)
        {
            return new Department
            {
                name = input[SchemaConstraints.name],
                address = input[SchemaConstraints.address],
                age = int.Parse(input[SchemaConstraints.age]),
                birthday = DateTime.Parse(input[SchemaConstraints.birthday]),
                is_skilled = bool.Parse(input[SchemaConstraints.is_skilled]),
            };
        }
    }
}