using BussinessLayer;
using BussinessLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employees.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeBLL _BLL;
        public EmployeesController(IEmployeeBLL BLL){
            _BLL= BLL;
            }
        [HttpGet]
        public ActionResult GetAllEmployees()
        {
            try
            {
              
                return Ok(_BLL.GetAllEmployees());




            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Error retrieving data from the database");
            }
        }

        [HttpGet]
        [Route("{id:guid}")]

        public ActionResult GetEmploeeById(Guid id)
        {
            try
            {
                var employee = _BLL.GetEmployeeById(id);

                if(employee == null)
                {
                    return NotFound();  
                }
                return Ok(employee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");

            }

        }

        [HttpPost]
        
        public ActionResult AddEmployee(EmployeeData e)
        {
            try
            {
                if (e == null)
                {
                    return BadRequest();
                }
                var employee = _BLL.AddEmployee(e);
                

                return StatusCode(StatusCodes.Status201Created, employee);


            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Error creating new employee record");
            }
        }


        [HttpDelete]
        [Route("{id:guid}")]

        public ActionResult DeleteEmpById (Guid id)
        {

            try
            {
                var employee = _BLL.GetEmployeeById(id);

                if(employee == null)
                {
                    return NotFound($"Employee with id {id} not found");
                }
               var msg= _BLL.DeleteEmpById(id);


                return StatusCode(StatusCodes.Status204NoContent, msg);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }



        }


    }
}
