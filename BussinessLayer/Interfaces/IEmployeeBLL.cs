using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Interfaces
{
    public interface IEmployeeBLL
    {
        public IEnumerable<EmployeeData> GetAllEmployees();
        public EmployeeData GetEmployeeById(Guid id);



        public EmployeeData AddEmployee(EmployeeData e);

       public string DeleteEmpById(Guid id);



    }
}
