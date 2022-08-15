using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace FlagLibraryDemo
{
    public class Dataprovider
    {
        SqlConnection connection = null;
        SqlCommand command = null;
        SqlDataReader reader = null;
        public  Dataprovider(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }
        public List<Continent> getCountryflag(string name)
        {
            try
            {
                string query = "select * from country where countryname=@country";
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("country", name);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                reader = command.ExecuteReader();
                List<Continent> list = new List<Continent>();
                while(reader.Read())
                {
                    Continent continent = new Continent();
                    continent.countryId = reader["countryId"].ToString();
                    continent.capital = reader["capital"].ToString();
                    continent.flag = (byte[])(reader["flag"]);
                    list.Add(continent);
                }
                return list;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        public List<Continent> getState(string id)
        {
            try
            {
                string query = "select * from state where countryid=@id";
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                reader = command.ExecuteReader();
                List<Continent> list = new List<Continent>();
                    while (reader.Read())
                    {
                        Continent continent = new Continent();
                        continent.statename = reader["statename"].ToString();
                        list.Add(continent);
                    }
                    return list;               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        public string getcapital(string name)
        {
            try
            {
                string query = "select statecapital from state where statename=@name";
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("name", name);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Continent continent = new Continent();
                    while (reader.Read())
                    {
                        continent.statecapital = reader["statecapital"].ToString();
                    }
                    return continent.statecapital;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }
}
