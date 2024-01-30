using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjectsLayer;
using IDataAccessLayer;
namespace DataAccessLayer
{
    public class ClientAccessor : IClientAccessor
    {
        public ClientAccessor() { }

        public int buyBike(Bike bike, Client client)
        {
            int result = 0;
            SqlConnection conn = DBConnection.getConnection();
            SqlCommand cmd = new SqlCommand("sp_buy_bike", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@client_first_name", client.client_first_name);
            cmd.Parameters.AddWithValue("@client_last_name", client.client_last_name);
            cmd.Parameters.AddWithValue("@email", client.email);
            cmd.Parameters.AddWithValue("@phone_number", client.phone_number);
            cmd.Parameters.AddWithValue("@bike_ID", bike.ID);
            cmd.Parameters.AddWithValue("@Price", bike.Price);
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

        public int Insert(Client client)
        {
            int result = 0;
            SqlConnection conn = DBConnection.getConnection();
            SqlCommand cmd = new SqlCommand("sp_insert_client", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@client_first_name", client.client_first_name);
            cmd.Parameters.AddWithValue("@client_last_name", client.client_last_name);
            cmd.Parameters.AddWithValue("@email", client.email);
            cmd.Parameters.AddWithValue("@phone_number", client.phone_number);
            cmd.Parameters.AddWithValue("@line1", client.line1);
            cmd.Parameters.AddWithValue("@line2", client.line2);
            cmd.Parameters.AddWithValue("@city", client.city);
            cmd.Parameters.AddWithValue("@state", client.state);
            cmd.Parameters.AddWithValue("@county", client.county);
            cmd.Parameters.AddWithValue("@zipcode", client.zipcode);
            cmd.Parameters.AddWithValue("@country", client.country);
            cmd.Parameters.AddWithValue("@routing_number", client.routing_number);
            cmd.Parameters.AddWithValue("@account_number", client.account_number);
            cmd.Parameters.AddWithValue("@bank_name", client.bank_name);
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

        public List<Client> selectAllClients()
        {
            List<Client> clients = new List<Client>();
            SqlConnection conn = DBConnection.getConnection();
            SqlCommand cmd = new SqlCommand("sp_select_all_clients", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Client client = new Client();
                        client.client_id = reader.GetInt32(0);
                        client.client_first_name = reader.GetString(1);
                        client.client_last_name = reader.GetString(2);
                        client.email = reader.GetString(3);
                        client.phone_number = reader.GetString(4);
                        client.line1 = reader.GetString(5);
                        client.line2 = reader.GetString(6);
                        client.city = reader.GetString(7);
                        client.state = reader.GetString(8);
                        client.county = reader.GetString(9);
                        client.zipcode = reader.GetString(10);
                        client.country = reader.GetString(11);
                        client.routing_number = reader.GetString(12);
                        client.account_number = reader.GetString(13);
                        client.bank_name = reader.GetString(14);
                        clients.Add(client);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return clients;
        }

        public int UpdateClient(Client client)
        {
            int result = 0;
            SqlConnection conn = DBConnection.getConnection();
            SqlCommand cmd = new SqlCommand("sp_update_client", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@client_id", client.client_id);
            cmd.Parameters.AddWithValue("@client_first_name", client.client_first_name);
            cmd.Parameters.AddWithValue("@client_last_name", client.client_last_name);
            cmd.Parameters.AddWithValue("@email", client.email);
            cmd.Parameters.AddWithValue("@phone_number", client.phone_number);
            cmd.Parameters.AddWithValue("@line1", client.line1);
            cmd.Parameters.AddWithValue("@line2", client.line2);
            cmd.Parameters.AddWithValue("@city", client.city);
            cmd.Parameters.AddWithValue("@state", client.state);
            cmd.Parameters.AddWithValue("@county", client.county);
            cmd.Parameters.AddWithValue("@zipcode", client.zipcode);
            cmd.Parameters.AddWithValue("@country", client.country);
            cmd.Parameters.AddWithValue("@routing_number", client.routing_number);
            cmd.Parameters.AddWithValue("@account_number", client.account_number);
            cmd.Parameters.AddWithValue("@bank_name", client.bank_name);
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
