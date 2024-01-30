using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjectsLayer;
using DataAccessLayer;
using IDataAccessLayer;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class BikeAccessor : IBikeAccessor
    {
        
        

        public int insertBike(Bike bike)
        {
            int result = 0;
            SqlConnection conn = DBConnection.getConnection();
            SqlCommand cmd = new SqlCommand("sp_insert_bike", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", bike.Name);
            cmd.Parameters.AddWithValue("@Type", bike.Type);
            cmd.Parameters.AddWithValue("@Price", bike.Price);
            cmd.Parameters.AddWithValue("@Quality", bike.Quality);
            cmd.Parameters.AddWithValue("@Model", bike.Model);
            cmd.Parameters.AddWithValue("@Total", bike.Total);
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

        public List<Bike> selectAllBikes()
        {
            List<Bike> bikes = new List<Bike>();
            SqlConnection conn = DBConnection.getConnection();
            SqlCommand cmd = new SqlCommand("sp_select_all_bikes", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Bike bike = new Bike();
                        bike.ID = reader.GetInt32(0);
                        bike.Name = reader.GetString(1);
                        bike.Type = reader.GetString(2);
                        bike.Price = reader.GetDecimal(3).ToString();
                        bike.Quality = reader.GetInt32(4).ToString();
                        bike.Model = reader.GetString(5);
                        bike.Total = reader.GetInt32(6);
                        bikes.Add(bike);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return bikes;
        }

        public int update(Bike bike)
        {
            int result = 0;
            SqlConnection conn = DBConnection.getConnection();
            SqlCommand cmd = new SqlCommand("sp_update_bike", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", bike.ID);
            cmd.Parameters.AddWithValue("@Name", bike.Name);
            cmd.Parameters.AddWithValue("@Type", bike.Type);
            cmd.Parameters.AddWithValue("@Price", bike.Price);
            cmd.Parameters.AddWithValue("@Quality", bike.Quality);
            cmd.Parameters.AddWithValue("@Model", bike.Model);
            cmd.Parameters.AddWithValue("@Total", bike.Total);
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
    }
}
