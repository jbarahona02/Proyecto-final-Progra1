using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace infraccionVehicular.Clases
{
    public class csInfraction
    {

        public DataSet infractionList()
        {

            DataSet ds = new DataSet();

            try
            {

                MySqlConnection cn = new MySqlConnection();
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
                cn.Open();

                MySqlDataAdapter da = new MySqlDataAdapter("select * from infraction", cn);

                da.Fill(ds);

                cn.Close();

            }
            catch (Exception e) { }

            return ds;

        }

        public DataSet infraction(int id)
        {

            DataSet ds = new DataSet();

            try
            {

                MySqlConnection cn = new MySqlConnection();

                cn.ConnectionString = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
                cn.Open();

                MySqlDataAdapter da = new MySqlDataAdapter("select * from infraction where id = " + id, cn);

                da.Fill(ds);

                cn.Close();

            }
            catch (Exception e) { }

            return ds;

        }

        public Int32 insertInfraction(double total, int agentId, int vehicleId)
        {

            Int32 respuesta = 0;
            string insert = "insert into infraction (createdAt, status, total, agentId, vehicleId) values( ";

            try
            {

                MySqlConnection cn = new MySqlConnection();
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
                cn.Open();

                MySqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = insert;
                cmd.CommandText += string.Format("'{0}','{1}',{2},{3},{4}); select last_insert_id();",DateTime.Now.ToString("yyyy-MM-dd H:mm:ss"),"N",total,agentId,vehicleId);

                respuesta = Convert.ToInt32(cmd.ExecuteScalar());

                /*MySqlCommand cmd = new MySqlCommand("insert into infraction (createdAt, status, total, agentId, vehicleId)" +
                    " values ('" + DateTime.Now.ToString("yyyy-MM-dd H:mm:ss") + "','" + status + "', " + total + ", " + agentId + ", " + vehicleId + ")", cn);

                respuesta = cmd.ExecuteNonQuery();*/

                cn.Close();

            }
            catch (Exception e) { }

            return respuesta;

        }

        public Int32 updateInfraction(int id, string status, double total, int agentId, int vehicleId)
        {

            Int32 respuesta = 0;

            try
            {

                MySqlConnection cn = new MySqlConnection();
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
                cn.Open();

                MySqlCommand cmd = new MySqlCommand("update infraction set status = '" + status +
                    "', total = " + total + ", agentId = " + agentId + ", vehicleId = " + vehicleId + " where id = " + id, cn);

                respuesta = cmd.ExecuteNonQuery();

                cn.Close();

            }
            catch (Exception e) { }

            return respuesta;

        }

        public Int32 deleteInfraction(int id)
        {

            Int32 respuesta = 0;

            try
            {

                MySqlConnection cn = new MySqlConnection();
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
                cn.Open();

                MySqlCommand cmd = new MySqlCommand("delete from infraction where id = " + id, cn);

                respuesta = cmd.ExecuteNonQuery();

                cn.Close();

            }
            catch (Exception e) { }

            return respuesta;

        }

    }
}