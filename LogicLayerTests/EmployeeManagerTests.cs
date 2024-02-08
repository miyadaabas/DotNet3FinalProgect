using LogicLayer;
using ILogicLayer;
using IDataAccessLayer;
using DataObjectsLayer;
using FakeDataAccessLayer;
using System.Text;
using System.Security.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LogicLayerTests
{
    [TestClass]
    public class EmployeeManagerTests
    {
        private IEmployeeManager _employeeManager;
        private IEmployeeAccessor _employeeAccessor;
        private List<Employee> employees;

        [TestInitialize]
        public void Setup()
        {
            employees = new List<Employee>();
            employees.Add(generateEmployee("test1"));
            employees.Add(generateEmployee("test2"));
            employees.Add(generateEmployee("test3"));
            employees.Add(generateEmployee("test4"));
            employees.Add(generateEmployee("test5"));
            employees.Add(generateEmployee("test6"));
            employees.Add(generateEmployee("test7"));
            employees.Add(generateEmployee("test8"));
            employees.Add(generateEmployee("test9"));
            employees.Add(generateEmployee("test10"));
            _employeeAccessor = new FakeEmployeesAccessor(employees);
            _employeeManager = new EmployeeManager(_employeeAccessor);
        }

        private Employee generateEmployee(string value)
        {
            Employee employee = new Employee();
            employee.Employee_id = 1;
            employee.Firstname = value;
            employee.Lastname = value;
            employee.SSN = value;
            employee.Line1 = value;
            employee.Line2 = value;
            employee.City = value;
            employee.State = value;
            employee.County = value;
            employee.Zipcode = value;
            employee.Role_id = value;
            employee.AccountNumber = value;
            employee.RoutinNumber = value;
            employee.bankName = value;
            employee.salaryType = value;
            employee.email = value;
            employee.passwordHash = hashSHA256(value);
            return employee;
        }

        private string hashSHA256(string source)
        {
            string result = "";
            byte[] data;
            using (SHA256 sha256sha = SHA256.Create())
            {
                data = sha256sha.ComputeHash(Encoding.UTF8.GetBytes(source));
            }
            var s = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                s.Append(data[i].ToString("x2"));
            }
            result = s.ToString();
            return result;
        }

        [TestMethod]
        public void TestAddEmployee()
        {
            Employee employee = generateEmployee("testing");
            int expected = 1;
            int actual = _employeeManager.addEmployee(employee);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestEditEmployee()
        {
            Employee employee = employees[0];
            employees[0].Firstname = "testing";
            int expected = 1;
            int actual = _employeeManager.editEmployee(employee);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetAllEmployees()
        {
            int expected = 10;
            int actual = _employeeManager.getAllEmployees().Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestEmployeeRole()
        {
            int employeeId = employees[0].Employee_id;
            string expected = "test1";
            string actual = _employeeManager.getEmployeeRole(employeeId);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestVerifyUser()
        {
            int expected = 1;
            int actual = _employeeManager.verifyUser("test1", "test1");
            Assert.AreEqual(expected, actual);
        }
    }
}