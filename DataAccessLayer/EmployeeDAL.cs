
using DataAccessLayer.DataContext;
using DataAccessLayer.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer
{
    public class EmployeeDAL: IEmployeeDAL
    {

        private readonly EmpDbContext _EmpDbContext;

        public EmployeeDAL(EmpDbContext EmpDbContext)
        {
            _EmpDbContext = EmpDbContext;
        }

        public IEnumerable<EmployeeData> GetAllEmployees()
        {
            return _EmpDbContext.Employees.ToList();
        }

        public EmployeeData AddEmployee(EmployeeData e)
        {
            try
            {
                e.EmpId = new Guid();

                _EmpDbContext.Employees.Add(e);
                _EmpDbContext.SaveChanges();
                return e;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public EmployeeData GetEmployeeById(Guid id)
        {
            try
            {
                var emp = _EmpDbContext.Employees.FirstOrDefault(e => e.EmpId == id);


                return emp;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string DeleteEmpById(Guid id)
        {
            try
            {
                var emp = _EmpDbContext.Employees.FirstOrDefault(e => e.EmpId == id);
                _EmpDbContext.Employees.Remove(emp);
                _EmpDbContext.SaveChanges();
                return "DELETED";
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}