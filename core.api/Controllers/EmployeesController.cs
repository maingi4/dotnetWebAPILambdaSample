using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Razor.Chunks.Generators;

namespace core.api.Controllers
{
    //[Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private static readonly List<Employee> AddedEmployees = new List<Employee>();
        [Route("api/employees")]
        public IEnumerable<Employee> Get()
        {
            return GetData();
        }

        [Route("api/employees/getbyname/{name}")]
        public Employee GetByShortName(string name)
        {
            return GetData().FirstOrDefault(x => x.ShortName.Equals(name));
        }

        [Route("api/employees/add")]
        //[HttpPost]
        public Employee Add([FromBody] Employee employee)
        {
            if (employee.Name == null)
                throw new Exception();

            AddedEmployees.Add(employee);

            return employee;
        }

        private static IEnumerable<Employee> GetData()
        {
            return (new []
            {
                new Employee() {
                    Name = "Sumit Maingi",
                    ShortName = "sumit",
                    Reknown = "Media Ocean",
                    Bio = "I recently started working in media ocean, I am an architect here."
                  },
                new Employee() {
                    Name = "Sneha Gokarn",
                    ShortName = "sneha",
                    Reknown = "Xpanxion",
                    Bio = "I work in Xpanxion located in Aundh, I am an associate leader in technology."
                  },
                new Employee() {
                    Name = "Savio Fernandes",
                    ShortName = "savio",
                    Reknown = "General Mills",
                    Bio = "I work in General Mills located in Powai, I am an IT manager here."
                  },
                new Employee() {
                    Name = "Sujit Nair",
                    ShortName = "sujit",
                    Reknown = "General Mills",
                    Bio = "I work in General Mills located in Powai, I am an Architect here."
                  },
                new Employee() {
                    Name = "Rajesh Sharma",
                    ShortName = "rajesh",
                    Reknown = "Tavisca",
                    Bio = "I work in Tavisca located in Viman Nagar, I am a Sr. Developer here."
                  },
                new Employee() {
                    Name = "Divjot Singh",
                    ShortName = "divjot",
                    Reknown = "Tavisca",
                    Bio = "I work in Tavisca located in Viman Nagar, I am a Devop lead here."
                  }
            }).Concat(AddedEmployees);
        }
    }
}
