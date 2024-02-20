using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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

namespace ApiTests
{
    [TestClass]

    public class EmployeeControllerTests
    {
        private Mock<IEmployeeBLL> _employeeRepoMock;
        private Fixture _fixture;
        private EmployeesController _controller;

        public EmployeeControllerTests()
        {
            _fixture = new Fixture();
            _employeeRepoMock = new Mock<IEmployeeBLL>();
        }

        [TestMethod]
        public async Task Get_Employee_ReturnsOk()
        {
            var emplist = _fixture.CreateMany<EmployeeData>(3).ToList();

            _employeeRepoMock.Setup(a => a.GetAllEmployees()).Returns(emplist);

            _controller = new EmployeesController(_employeeRepoMock.Object);

            var res =  _controller.GetAllEmployees();

           var obj = res as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);

        }
        
   
        [TestMethod]
        public async Task Get_Employee_ThrowsException()
        {

            _employeeRepoMock.Setup(a => a.GetAllEmployees()).Throws(new Exception());

            _controller = new EmployeesController(_employeeRepoMock.Object);

            var res = _controller.GetAllEmployees();

            var obj = res as ObjectResult;

            Assert.AreEqual(500, obj.StatusCode);

        }

        

        [TestMethod]
        public async Task Get_Employee_By_Id()
        {
            var empid = _fixture.Create<Guid>();
            var emp = _fixture.Create<EmployeeData>();

            _employeeRepoMock.Setup(a => a.GetEmployeeById(It.IsAny<Guid>())).Returns(emp);

            _controller = new EmployeesController(_employeeRepoMock.Object);

            var res = _controller.GetEmploeeById(empid);

            var obj = res as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);

        }

        
        [TestMethod]
        public async Task Get_Employee_By_Id_ThrowsException()
        {
            var empid = _fixture.Create<Guid>();

            _employeeRepoMock.Setup(a => a.GetEmployeeById(It.IsAny<Guid>())).Throws(new Exception());

            _controller = new EmployeesController(_employeeRepoMock.Object);

            var res = _controller.GetEmploeeById(empid);

            var obj = res as ObjectResult;

            Assert.AreEqual(500, obj.StatusCode);

        }


        [TestMethod]
        public async Task Add_Employee_ReturnsOk()
        {
            var emp = _fixture.Create<EmployeeData>();

            _employeeRepoMock.Setup(a => a.AddEmployee(It.IsAny<EmployeeData>())).Returns(emp);


            _controller = new EmployeesController(_employeeRepoMock.Object);


            var res = _controller.AddEmployee(emp);    


            var obj = res as ObjectResult; 

            Assert.AreEqual(201, obj.StatusCode);

        }


        [TestMethod]
        public async Task Add_Employee_ThrowsException()
        {
            var emp = _fixture.Create<EmployeeData>();

            _employeeRepoMock.Setup(a => a.AddEmployee(It.IsAny<EmployeeData>())).Throws(new Exception());


            _controller = new EmployeesController(_employeeRepoMock.Object);


            var res = _controller.AddEmployee(emp);


            var obj = res as ObjectResult;

            Assert.AreEqual(500, obj.StatusCode);

        }
  

        


    }
}
