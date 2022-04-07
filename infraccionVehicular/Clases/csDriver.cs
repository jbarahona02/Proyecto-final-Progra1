using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace infraccionVehicular.Clases
{
    public class csDriver
    {
        String connection = "cnConnection";

        public DataSet findDrivers()
        {
            DataSet ds = new DataSet();

            try
            {
                MySqlConnection cn = new MySqlConnection();
                cn.ConnectionString = ConfigurationManager.ConnectionStrings[connection].ConnectionString;
                cn.Open();

                MySqlDataAdapter dataAdapter;
                dataAdapter = new MySqlDataAdapter("select *from driver;", cn);
                dataAdapter.Fill(ds);
                cn.Close();

            }
            catch (Exception ex)
            {

            }

            return ds;
        }

        public DataSet findDriver(int id)
        {
            DataSet ds = new DataSet();
            try
            {
                MySqlConnection cn = new MySqlConnection();
                cn.ConnectionString = ConfigurationManager.ConnectionStrings[connection].ConnectionString;
                cn.Open();

                MySqlDataAdapter dataAdapter;
                dataAdapter = new MySqlDataAdapter("select *from driver where id = " + id, cn);
                dataAdapter.Fill(ds);

                cn.Close();

            }
            catch (Exception ex)
            {

            }

            return ds;
        }

        public Int32 saveDriver(string driverLicense, string name, string lastName, string age)
        {
            Int32 result = 0;
            string insert = "insert into driver(driverLicense, name, lastName, age) value( ";

            try
            {
                MySqlConnection cn = new MySqlConnection();
                cn.ConnectionString = ConfigurationManager.ConnectionStrings[connection].ConnectionString;
                cn.Open();

                MySqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = insert;
                cmd.CommandText += string.Format("'{0}','{1}',{2}); select last_insert_id();", driverLicense, name, lastName, age);

                result = Convert.ToInt32(cmd.ExecuteScalar());
                cn.Close();
            }
            catch (Exception ex)
            {

            }

            return result;
        }
        public Int32 updateDriver(string driverLicense, string name, string lastName, string age)
        {
            Int32 result = 0;

            try
            {
                MySqlConnection cn = new MySqlConnection();
                cn.ConnectionString = ConfigurationManager.ConnectionStrings[connection].ConnectionString;
                cn.Open();

                MySqlCommand command = new MySqlCommand("update driver set name = '" + name + "', lastName = '" + lastName + "', age= '" + age + "' where driverLicense = " + driverLicense, cn);
                result = command.ExecuteNonQuery();
                cn.Close();

            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public Int32 deleteDriver(string driverLicense)
        {
            Int32 respuesta = 0;

            try
            {
                MySqlConnection cn = new MySqlConnection();
                cn.ConnectionString = ConfigurationManager.ConnectionStrings[connection].ConnectionString;
                cn.Open();

                MySqlCommand command = new MySqlCommand("delete from driver where driverLicense = " + driverLicense, cn);
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