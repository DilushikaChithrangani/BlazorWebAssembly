
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWebAssembly.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        public static List<Manager> managers = new List<Manager> {
            new Manager {Id = 1, Name ="Ruwini"},
            new Manager {Id = 2, Name ="Kasun"}
        };
        public static List<Employees> employees = new List<Employees> {
            new Employees {
                Id = 1, 
                FirstName = "Dilushika", 
                LastName = "Chithrangani", 
                TelephoneNo = 0278945345,
                Email = "dilu@gmail.com",
                City = "Anuradhapura",
                Manager = managers[0]
            },

            new Employees {
                Id = 2,
                FirstName = "Amal",
                LastName = "Perera",
                TelephoneNo = 0378976457,
                Email = "amal@gmail.com",
                City = "Kekirawa",
                Manager = managers[1]
            },

        };
        [HttpGet]
        public async Task<ActionResult<List<Employees>>> GetEmployees()
        {
            return Ok(employees);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Employees>> GetSingleEmployee(int Id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == Id);
            if(employee == null)
            {
                return NotFound("Sorry, no employee here. ");
            }
            return Ok(employee);
        }
    }
}
