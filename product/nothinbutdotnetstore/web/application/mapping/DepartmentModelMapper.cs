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
                name = input["name"],
                address = input["address"],
                age = int.Parse(input["age"]),
                birthday = DateTime.Parse(input["birthday"]),
                is_skilled = bool.Parse(input["is_skilled"]),
            };
        }
    }
}