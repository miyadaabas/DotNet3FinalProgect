using DataObjectsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDataAccessLayer
{
    public interface IEmployeeAccessor
    {
        public int deleteEmployee(Employee employee);
        public int insertEmployee(Employee employee);
        public string selectEmployeeRole(int employeeId);
        public List<Employee> selectEmployees();
        public int updateEmployee(Employee employee);
        public int verifyUser(string email, string password);
    }
}
