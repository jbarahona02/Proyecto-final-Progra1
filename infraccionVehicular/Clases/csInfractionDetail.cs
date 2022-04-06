using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace infraccionVehicular.Clases
{
    public class csInfractionDetail
    {

        public DataSet infractionDetailList() {

            DataSet ds = new DataSet();

            try {

                MySqlConnection cn = new MySqlConnection();

                cn.ConnectionString = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
                cn.Open();

                MySqlDataAdapter da = new MySqlDataAdapter("select * from infractiondetailid", cn);

                da.Fill(ds);

                cn.Close();

            } catch (Exception e) { }

            return ds;
        
        }

        public DataSet infractionDetail(string id) {

            DataSet ds = new DataSet();

            try {

                MySqlConnection cn = new MySqlConnection();

                cn.ConnectionString = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
                cn.Open();

                MySqlDataAdapter da = new MySqlDataAdapter("select * from infractiondetailid where id = " + id, cn);

                da.Fill(ds);

                cn.Close();

            } catch (Exception e) { }

            return ds;

        }

        public Int32 insertInfractionDetail(int infractionId, int sanctionId) {

            Int32 respuesta = 0;

            try {

                MySqlConnection cn = new MySqlConnection();
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
                cn.Open();

                MySqlCommand cmd = new MySqlCommand("insert into infractiondetailid (infractionId, sanctionId)" +
                    " values (" + infractionId + ", " + sanctionId + ")", cn);

                respuesta = cmd.ExecuteNonQuery();

                cn.Close();

            } catch (Exception e) { }

            return respuesta;
        
        }

        public Int32 updateInfractionDetail(int id, int infractionId, int sanctionId) {

            Int32 respuesta = 0;

            try {

                MySqlConnection cn = new MySqlConnection();
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
                cn.Open();

                MySqlCommand cmd = new MySqlCommand("update infractiondetailid set infractionId = " + infractionId + 
                    ", sanctionId = " + sanctionId + " where id = " + id, cn);

                respuesta = cmd.ExecuteNonQuery();

                cn.Close();

            } catch(Exception e) { }

            return respuesta;
        
        }

        public Int32 deleteInfractionDetail(int id) {

            Int32 respuesta = 0;

            try {

                MySqlConnection cn = new MySqlConnection();
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
                cn.Open();

                MySqlCommand cmd = new MySqlCommand("delete from infractiondetailid where id = " + id, cn);

                respuesta = cmd.ExecuteNonQuery();

                cn.Close();

            } catch(Exception e) { }

            return respuesta;
        
        }

    }
}