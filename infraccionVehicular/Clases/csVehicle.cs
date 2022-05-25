using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace infraccionVehicular.Clases
{
    public class csVehicle
    {
        string connection = "cnConnection";

        public DataSet findAll()
        {
            DataSet ds = new DataSet();

            try
            {
                MySqlConnection cn = new MySqlConnection();
                cn.ConnectionString = ConfigurationManager.ConnectionStrings[connection].ConnectionString;
                cn.Open();

                MySqlDataAdapter dataAdapter;
                dataAdapter = new MySqlDataAdapter("select *from vehicle;", cn);
                dataAdapter.Fill(ds);
                cn.Close();
            }
            catch (Exception ex)
            {

            }

            return ds;
        }

        public DataSet findById(int id)
        {
            DataSet ds = new DataSet();
            try
            {
                MySqlConnection cn = new MySqlConnection();
                cn.ConnectionString = ConfigurationManager.ConnectionStrings[connection].ConnectionString;
                cn.Open();

                MySqlDataAdapter dataAdapter;
                dataAdapter = new MySqlDataAdapter("select *from vehicle where id = " + id, cn);
                dataAdapter.Fill(ds);

                cn.Close();
            }
            catch (Exception ex)
            {

            }

            return ds;
        }

        public Int32 save(string license, string type, string color, string line, string brand, string driverId)
        {
            Int32 result = 0;
            string insert = "insert into vehicle(licensePlate, type, color, line, brand, driverId) value( ";

            try
            {
                MySqlConnection cn = new MySqlConnection();
                cn.ConnectionString = ConfigurationManager.ConnectionStrings[connection].ConnectionString;
                cn.Open();

                MySqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = insert;
                cmd.CommandText += string.Format("'{0}','{1}','{2}','{3}','{4}',{5}); select last_insert_id();", license, type, color, line, brand,"'" + driverId + "'");

                result = Convert.ToInt32(cmd.ExecuteScalar());
                cn.Close();
            }
            catch (Exception ex)
            {

            }

            return result;
        }
        public Int32 update(int id, string license, string type, string color, string line, string brand, string driverId)
        {
            Int32 result = 0;

            try
            {
                MySqlConnection cn = new MySqlConnection();
                cn.ConnectionString = ConfigurationManager.ConnectionStrings[connection].ConnectionString;
                cn.Open();

                MySqlCommand command = new MySqlCommand("update vehicle set licensePlate = '" + license + "', type = '" + type + "', color = '" + color + "', line = '" + line + "', brand = '" + brand + "', driverId  = '" + driverId + "' where id = " + id, cn);
                result = command.ExecuteNonQuery();
                cn.Close();

            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public Int32 delete(int id)
        {
            Int32 respuesta = 0;

            try
            {
                MySqlConnection cn = new MySqlConnection();
                cn.ConnectionString = ConfigurationManager.ConnectionStrings[connection].ConnectionString;
                cn.Open();

                MySqlCommand command = new MySqlCommand("delete from vehicle where id = " + id, cn);
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