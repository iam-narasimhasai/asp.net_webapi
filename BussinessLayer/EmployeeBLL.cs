using BussinessLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.DataContext;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;

namespace BussinessLayer
{
    
    public class EmployeeBLL: IEmployeeBLL 
    {
        private readonly IEmployeeDAL _DAL;
       

        public EmployeeBLL(IEmployeeDAL DAL)
        {
            _DAL = DAL;
        }

      
        public IEnumerable<EmployeeData> GetAllEmployees()
        {
            
            try
            {
                return _DAL.GetAllEmployees();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public EmployeeData AddEmployee(EmployeeData e)
        {
            try
            {
                return _DAL.AddEmployee(e);
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public EmployeeData GetEmployeeById(Guid id)
        {
            try
            {
                return _DAL.GetEmployeeById(id);
            }
            catch (Exception)
            {
                throw new NotImplementedException();

            }
        }

        public string DeleteEmpById(Guid id)
        {
            try
            {
                return _DAL.DeleteEmpById(id);
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }
    }
}
