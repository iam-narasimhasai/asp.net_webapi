using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

using AutoFixture;
using Employees.API.Controllers;

using System.Collections.Immutable;
using Microsoft.AspNetCore.Mvc;
using BussinessLayer.Interfaces;
using DataAccessLayer.Models;
using BussinessLayer;
using Microsoft.OpenApi.Writers;

namespace ApiTests
{
    [TestClass]
    public class EmployeeBLLTests
    {
        private Mock<IEmployeeBLL> _employeeRepoMock;
        private Fixture _fixture;
        public EmployeeBLLTests()
        {
            _fixture = new Fixture();
            _employeeRepoMock = new Mock<IEmployeeBLL>();
        }


        [TestMethod]
        public async Task Get_Employees_BLLVerify()
        {

            _employeeRepoMock.Setup(a => a.GetAllEmployees()).Verifiable();


            
            var _ebll = _employeeRepoMock.Object;
            _ebll.GetAllEmployees();


            _employeeRepoMock.VerifyAll();


        }

        [TestMethod]
        public async Task Get_EmployeesById_BLL_Verify()
        {
            _employeeRepoMock.Setup(a => a.GetEmployeeById(It.IsAny<Guid>())).Verifiable();



            var _ebll = _employeeRepoMock.Object;
            _ebll.GetEmployeeById(It.IsAny<Guid>());


            _employeeRepoMock.VerifyAll();


        }
        [TestMethod]
        public async Task AddEmployee_BLL_Verify()
        {
            _employeeRepoMock.Setup(a => a.AddEmployee(It.IsAny<EmployeeData>())).Verifiable();



            var _ebll = _employeeRepoMock.Object;
            _ebll.AddEmployee(It.IsAny<EmployeeData>());


            _employeeRepoMock.VerifyAll();

        }

        [TestMethod]
        public async Task DeleteEmpById_BLL_Verify()
        {
            _employeeRepoMock.Setup(a => a.DeleteEmpById(It.IsAny<Guid>())).Verifiable();



            var _ebll = _employeeRepoMock.Object;
            _ebll.DeleteEmpById(It.IsAny<Guid>());


            _employeeRepoMock.VerifyAll();
        }





    }
}
