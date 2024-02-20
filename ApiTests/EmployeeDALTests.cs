using AutoFixture;
using BussinessLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Employees.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTests
{
    [TestClass]

    public class EmployeeDALTests
    {
        private Mock<IEmployeeDAL> _employeeRepoMock;
        private Fixture _fixture;
        
        public EmployeeDALTests()
        {
            _fixture = new Fixture();
            _employeeRepoMock = new Mock<IEmployeeDAL>();
        }

        [TestMethod]
        public async Task Get_Employees_DAL_Tests()
        {
            var emplist = _fixture.CreateMany<EmployeeData>(3).ToList();

            _employeeRepoMock.Setup(a => a.GetAllEmployees()).Returns(emplist);

            var _DAL = _employeeRepoMock.Object;

            var res = _DAL.GetAllEmployees();

            Assert.AreEqual(emplist, res);

           

        }
        

        [TestMethod]

        public async Task GetEmployeeById_DAL_Tests()
        {
            var empid = _fixture.Create<Guid>();
            var emp = _fixture.Create<EmployeeData>();

            _employeeRepoMock.Setup(a => a.GetEmployeeById(It.IsAny<Guid>())).Returns(emp);

            var _DAL = _employeeRepoMock.Object;

            var res=_DAL.GetEmployeeById(empid);

            Assert.AreEqual(emp, res);

        }
        [TestMethod]
        public async Task AddEmployee_DAL_Tests()
        {
            var emp = _fixture.Create<EmployeeData>();

            _employeeRepoMock.Setup(a => a.AddEmployee(It.IsAny<EmployeeData>())).Returns(emp);


            var _DAL = _employeeRepoMock.Object;


            var res = _DAL.AddEmployee(emp);


            

            Assert.AreEqual(emp, res);
        }









    }
}
