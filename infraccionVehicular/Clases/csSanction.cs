using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace infraccionVehicular.Clases
{
    public class csSanction
    {
        String conection = "cnConnection";
        public DataSet findAll()
        {
            DataSet ds = new DataSet();
            try
            {
                MySqlConnection cn = new MySqlConnection();
                cn.ConnectionString = ConfigurationManager.ConnectionStrings[conection].ConnectionString;
                cn.Open();

                MySqlDataAdapter dataAdapter;
                dataAdapter = new MySqlDataAdapter("select * from sanction;", cn);
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
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
                cn.Open();

                MySqlDataAdapter dataAdapter;
                dataAdapter = new MySqlDataAdapter("select * from sanction where id = " + id, cn);
                dataAdapter.Fill(ds);
                cn.Close();
            }
            catch (Exception ex)
            {

            }

            return ds;
        }

        public Int32 save(string description, double amount)
        {
            Int32 result = 0;
            string insert = "insert into sanction(description, amount) values( ";

            try
            {
                MySqlConnection cn = new MySqlConnection();
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
                cn.Open();

                MySqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = insert;
                cmd.CommandText += string.Format("'{0}', {1}); select last_insert_id();", description, amount);

                result = Convert.ToInt32(cmd.ExecuteScalar());
                cn.Close();
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public Int32 update(String description, Double amount, int id)
        {
            Int32 result = 0;

            try
            {
                MySqlConnection cn = new MySqlConnection();
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
                cn.Open();

                MySqlCommand command = new MySqlCommand("update sanction set description='" + description + "',amount=" + amount + " where id=" + id + "", cn);

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
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
                cn.Open();

                MySqlCommand command = new MySqlCommand("delete from sanction where id=" + id + "", cn);

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