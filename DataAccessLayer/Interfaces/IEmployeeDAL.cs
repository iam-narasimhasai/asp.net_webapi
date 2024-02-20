using DataAccessLayer.DataContext;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IEmployeeDAL
    {
        public IEnumerable<EmployeeData> GetAllEmployees();
        public EmployeeData AddEmployee(EmployeeData e);
        public EmployeeData GetEmployeeById(Guid id);
        public string DeleteEmpById(Guid id);


    }
}
