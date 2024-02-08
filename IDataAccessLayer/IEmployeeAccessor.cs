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
        int deleteEmployee(Employee employee);
        int insertEmployee(Employee employee);
        string selectEmployeeRole(int employeeId);
        List<Employee> selectEmployees();
        int updateEmployee(Employee employee);
        int verifyUser(string email, string password);
    }
}
