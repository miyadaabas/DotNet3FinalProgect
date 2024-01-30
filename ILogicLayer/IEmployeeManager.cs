using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjectsLayer;
namespace ILogicLayer
{
    public interface IEmployeeManager
    {
        public int addEmployee(Employee employee);
        public int deleteEmployee(Employee employee);
        public int editEmployee(Employee employee);
        public List<Employee> getAllEmployees();
        public string getEmployeeRole(int employeeId);
        public int verifyUser(string email, string password);
    }
}
