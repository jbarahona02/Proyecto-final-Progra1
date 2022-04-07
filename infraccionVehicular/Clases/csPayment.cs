using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;


namespace infraccionVehicular.Clases
{
    public class csPayment
    {
        string conection = "cnConnection";

        public DataSet findAll()
        {
            DataSet ds = new DataSet();
            try
            {
                MySqlConnection cn = new MySqlConnection();
                cn.ConnectionString = ConfigurationManager.ConnectionStrings[conection].ConnectionString;
                cn.Open();

                MySqlDataAdapter dataAdapter;
                dataAdapter = new MySqlDataAdapter("select * from payment;", cn);
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
                dataAdapter = new MySqlDataAdapter("select * from payment where id = " + id, cn);
                dataAdapter.Fill(ds);
                cn.Close();
            }
            catch (Exception ex)
            {

            }
            return ds;
        }

        public Int32 save(double amount, DateTime paidAt , Int32 infractionId)
        {
            Int32 result = 0;
            string insert = "insert into payment(amount, paidAt , infractionId) values( ";

            try
            {
                MySqlConnection cn = new MySqlConnection();
                cn.ConnectionString = ConfigurationManager.ConnectionStrings[conection].ConnectionString;
                cn.Open();

                MySqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = insert;
                cmd.CommandText += string.Format(" {0} , '{1}' , {2}); select last_insert_id();", amount, paidAt, infractionId);

                result = Convert.ToInt32(cmd.ExecuteScalar());
                cn.Close();
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public Int32 update(double amount, DateTime paidAt, Int32 infractionId, int id)
        {
            Int32 result = 0;

            try
            {
                MySqlConnection cn = new MySqlConnection();
                cn.ConnectionString = ConfigurationManager.ConnectionStrings[conection].ConnectionString;
                cn.Open();

                MySqlCommand command = new MySqlCommand("update payment set amount=" + amount + ",paidAt='" + paidAt + "',infractionId=" + infractionId + "where id=" + id + "", cn);

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
            Int32 result = 0;

            try
            {
                MySqlConnection cn = new MySqlConnection();
                cn.ConnectionString = ConfigurationManager.ConnectionStrings[conection].ConnectionString;
                cn.Open();

                MySqlCommand command = new MySqlCommand("delete from payment where id=" + id + "", cn);

                result = command.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {

            }
            return result;
        }

    }
}