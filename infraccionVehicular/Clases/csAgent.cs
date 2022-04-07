using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace infraccionVehicular.Clases
{
    public class csAgent
    {
        String connection = "cnConnection";

        public DataSet findAgents()
        {
            DataSet ds = new DataSet();

            try
            {
                MySqlConnection cn = new MySqlConnection();
                cn.ConnectionString = ConfigurationManager.ConnectionStrings[connection].ConnectionString;
                cn.Open();

                MySqlDataAdapter dataAdapter;
                dataAdapter = new MySqlDataAdapter("select *from agent;", cn);
                dataAdapter.Fill(ds);
                cn.Close();

            }
            catch(Exception ex)
            {

            }

            return ds;
        }

        public DataSet findAgent(int id)
        {
            DataSet ds = new DataSet();
            try
            {
                MySqlConnection cn = new MySqlConnection();
                cn.ConnectionString = ConfigurationManager.ConnectionStrings[connection].ConnectionString;
                cn.Open();

                MySqlDataAdapter dataAdapter;
                dataAdapter = new MySqlDataAdapter("select *from agent where id = " + id, cn);
                dataAdapter.Fill(ds);

                cn.Close();

            }
            catch (Exception ex)
            {

            }

            return ds;
        }

        public Int32 saveAgent(string name, string lastName, string dpi, string age, string phoneNumber)
        {
            Int32 result = 0;
            string insert = "insert into agent(name, lastName, dpi, age, phoneNumber) value( ";

            try
            {
                MySqlConnection cn = new MySqlConnection();
                cn.ConnectionString = ConfigurationManager.ConnectionStrings[connection].ConnectionString;
                cn.Open();

                MySqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = insert;
                cmd.CommandText += string.Format("'{0}','{1}',{2}); select last_insert_id();", name, lastName, dpi, age, phoneNumber);

                result = Convert.ToInt32(cmd.ExecuteScalar());
                cn.Close();
            }
            catch (Exception ex)
            {

            }

            return result;
        }
        public Int32 updateAgent(int id, string name, string lastName, string dpi, string age, string phoneNumber)
        {
            Int32 result = 0;

            try
            {
                MySqlConnection cn = new MySqlConnection();
                cn.ConnectionString = ConfigurationManager.ConnectionStrings[connection].ConnectionString;
                cn.Open();

                MySqlCommand command = new MySqlCommand("update agent set name = '" + name + "', lastName = '" + lastName + "', dpi = '" + dpi + "', age= '" + age + "', phoneNumber = '" + phoneNumber + "' where id = " + id, cn);
                result = command.ExecuteNonQuery();
                cn.Close();

            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public Int32 deleteAgent(int id)
        {
            Int32 respuesta = 0;

            try
            {
                MySqlConnection cn = new MySqlConnection();
                cn.ConnectionString = ConfigurationManager.ConnectionStrings[connection].ConnectionString;
                cn.Open();

                MySqlCommand command = new MySqlCommand("delete from agent where id = " + id, cn);
                respuesta = command.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {

            }

            return respuesta;
        }
    }
}