using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjectsLayer;
namespace ILogicLayer
{
    public interface IEmployeeManager
    {
        int addEmployee(Employee employee);
        int deleteEmployee(Employee employee);
        int editEmployee(Employee employee);
        List<Employee> getAllEmployees();
        string getEmployeeRole(int employeeId);
        int verifyUser(string email, string password);
    }
}
