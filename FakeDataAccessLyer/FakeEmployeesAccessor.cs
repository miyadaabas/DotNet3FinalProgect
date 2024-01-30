using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDataAccessLayer;
using DataObjectsLayer;

namespace FakeDataAccessLayer
{
    public class FakeEmployeesAccessor : IEmployeeAccessor
    {
        private List<Employee> _employees;
        public FakeEmployeesAccessor() {
            _employees = new List<Employee>();        
        }

        public FakeEmployeesAccessor(List<Employee> employees)
        {
            _employees = employees;
        }

        public int deleteEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public int insertEmployee(Employee employee)
        {
            int result = _employees.Count;
            _employees.Add(employee);
            return _employees.Count - result;
        }

        public string selectEmployeeRole(int employeeId)
        {
            foreach (Employee employee in _employees)
            {
                if (employee.Employee_id == employeeId)
                {
                    if (employee.Role_id != null)
                    {
                        return employee.Role_id;
                    }
                    else
                    {
                        return "";
                    }
                    
                }
            }
            return "";
        }

        public List<Employee> selectEmployees()
        {
            return _employees;
        }

        public int updateEmployee(Employee employee)
        {
            int result = _employees.Count;
            _employees.Add(employee);
            return _employees.Count - result;
        }

        public int verifyUser(string email, string password)
        {
            int result = 0;
            foreach (Employee employee in _employees)
            {
                if (employee.email == email && employee.passwordHash == password) 
                {
                    result = 1;
                    break;
                }
            }
            return result;
        }
    }
}
