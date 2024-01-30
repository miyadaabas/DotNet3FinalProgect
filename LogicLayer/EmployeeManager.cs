using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ILogicLayer;
using IDataAccessLayer;
using DataAccessLayer;
using DataObjectsLayer;

namespace LogicLayer
{
    public class EmployeeManager : IEmployeeManager
    {
        private IEmployeeAccessor employeeAccessor  ;

        public EmployeeManager()
        {
            employeeAccessor = new EmployeeAccessor();
        }

        public EmployeeManager(IEmployeeAccessor employeeAccessor)
        {
            this.employeeAccessor = employeeAccessor;
        }

        public int addEmployee(Employee employee)
        {
            int result = 0;
            employee.passwordHash = hashSHA256(employee.passwordHash);
            result = employeeAccessor.insertEmployee(employee);
            return result;
        }

        public int deleteEmployee(Employee employee)
        {
            int result = 0;
            result = employeeAccessor.deleteEmployee(employee);
            return result;
        }

        public int editEmployee(Employee employee)
        {
            int result = 0;
            employee.passwordHash = hashSHA256(employee.passwordHash);
            result = employeeAccessor.updateEmployee(employee);
            return result;
        }

        

        public List<Employee> getAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees = employeeAccessor.selectEmployees();
            return employees;
        }

        public string getEmployeeRole(int employeeId)
        {
            string role = employeeAccessor.selectEmployeeRole(employeeId);
            return role;
        }

        public int verifyUser(string email, string password)
        {
            int result = 0;
            result = employeeAccessor.verifyUser(email,hashSHA256(password));
            return result;
        }
        private string hashSHA256(string? source)
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
    }
}
