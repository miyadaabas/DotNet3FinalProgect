using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDataAccessLayer;
using DataObjectsLayer;
using System.Data.SqlClient;
using System.Data;
namespace DataAccessLayer
{
    public class EmployeeAccessor : IEmployeeAccessor
    {
        public int deleteEmployee(Employee employee)
        {
            int result = 0;
            SqlConnection conn = DBConnection.getConnection();
            SqlCommand cmd = new SqlCommand("sp_delete_employee", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Employee_id", employee.Employee_id);
            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return result;
        }

        public int insertEmployee(Employee employee)
        {
            int result = 0;
            SqlConnection conn = DBConnection.getConnection();
            SqlCommand cmd = new SqlCommand("sp_insert_employees", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Firstname", employee.Firstname);
            cmd.Parameters.AddWithValue("@Lastname", employee.Lastname);
            cmd.Parameters.AddWithValue("@SSN", employee.SSN);
            cmd.Parameters.AddWithValue("@Line1", employee.Line1);
            cmd.Parameters.AddWithValue("@Line2", employee.Line2);
            cmd.Parameters.AddWithValue("@City", employee.City);
            cmd.Parameters.AddWithValue("@State", employee.State);
            cmd.Parameters.AddWithValue("@County", employee.County);
            cmd.Parameters.AddWithValue("@Zipcode", employee.Zipcode);
            cmd.Parameters.AddWithValue("@Role_id", employee.Role_id);
            cmd.Parameters.AddWithValue("@AccountNumber", employee.AccountNumber);
            cmd.Parameters.AddWithValue("@RoutinNumber", employee.RoutinNumber);
            cmd.Parameters.AddWithValue("@bankName", employee.bankName);
            cmd.Parameters.AddWithValue("@salaryType", employee.salaryType);
            cmd.Parameters.AddWithValue("@salaryAmount", employee.salaryAmount);
            cmd.Parameters.AddWithValue("@email", employee.email);
            cmd.Parameters.AddWithValue("@passwordHash", employee.passwordHash);
            try
            {
                conn.Open();
                result= cmd.ExecuteNonQuery();
                
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return result;
        }

        public string selectEmployeeRole(int employeeId)
        {
            string role = string.Empty;
            SqlConnection conn = DBConnection.getConnection();
            SqlCommand cmd = new SqlCommand("sp_select_employee_roles", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@employee_id", employeeId);
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        role = reader.GetString(0);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return role;
        }

        public List<Employee> selectEmployees()
        {
           List<Employee> employees = new List<Employee>();
            SqlConnection conn = DBConnection.getConnection();
            SqlCommand cmd = new SqlCommand("sp_select_all_employees", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Employee employee = new Employee();
                        employee.Employee_id = reader.GetInt32(0); 
                        employee.Firstname = reader.GetString(1);
                        employee.Lastname = reader.GetString(2);
                        employee.SSN = reader.GetString(3);
                        employee.Line1 = reader.GetString(4);
                        employee.Line2 = reader.GetString(5);
                        employee.City = reader.GetString(6);
                        employee.State = reader.GetString(7);
                        employee.County = reader.GetString(8);
                        employee.Zipcode = reader.GetString(9);
                        employee.bankName = reader.GetString(10);
                        employee.AccountNumber = reader.GetString(11);
                        employee.RoutinNumber = reader.GetString(12);
                        employee.Role_id = reader.GetString(13);
                        employee.salaryAmount = reader.GetString(14);
                        employee.salaryType = reader.GetString(15);
                        employee.email = reader.GetString(16);
                        employee.passwordHash = reader.GetString(17);
                        employees.Add(employee);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return employees;
        }

        public int updateEmployee(Employee employee)
        {
            int result = 0;
            SqlConnection conn = DBConnection.getConnection();
            SqlCommand cmd = new SqlCommand("sp_update_employee", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Employee_id", employee.Employee_id);
            cmd.Parameters.AddWithValue("@Firstname", employee.Firstname);
            cmd.Parameters.AddWithValue("@Lastname", employee.Lastname);
            cmd.Parameters.AddWithValue("@SSN", employee.SSN);
            cmd.Parameters.AddWithValue("@Line1", employee.Line1);
            cmd.Parameters.AddWithValue("@Line2", employee.Line2);
            cmd.Parameters.AddWithValue("@City", employee.City);
            cmd.Parameters.AddWithValue("@State", employee.State);
            cmd.Parameters.AddWithValue("@County", employee.County);
            cmd.Parameters.AddWithValue("@Zipcode", employee.Zipcode);
            cmd.Parameters.AddWithValue("@Role_id", employee.Role_id);
            cmd.Parameters.AddWithValue("@AccountNumber", employee.AccountNumber);
            cmd.Parameters.AddWithValue("@RoutinNumber", employee.RoutinNumber);
            cmd.Parameters.AddWithValue("@bankName", employee.bankName);
            cmd.Parameters.AddWithValue("@salaryType", employee.salaryType);
            cmd.Parameters.AddWithValue("@salaryAmount", employee.salaryAmount);
            cmd.Parameters.AddWithValue("@email", employee.email);
            cmd.Parameters.AddWithValue("@passwordHash", employee.passwordHash);
            try
            {
               conn.Open();
               result = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
            return result;
        }

        public int verifyUser(string email, string password)
        {
            int result = 0;
            SqlConnection conn = DBConnection.getConnection();
            SqlCommand cmd = new SqlCommand("sp_verify_employee", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@passwordHash", password);
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result = reader.GetInt32(0);
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return result;
        }
    }
}
