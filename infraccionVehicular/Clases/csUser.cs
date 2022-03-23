using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace infraccionVehicular.Clases
{
    public class csUser
    {
        //Creación de método que retorna todos los datos de la tabla user
        public DataSet listaDeUsuarios()
        {
            DataSet dsi = new DataSet();
            try
            {
                MySqlConnection cn = new MySqlConnection();

                cn.ConnectionString = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
                cn.Open();

                MySqlDataAdapter dataAdapter;
                dataAdapter = new MySqlDataAdapter("select * from user", cn);
                dataAdapter.Fill(dsi);
                cn.Close();

            } catch (Exception ex)
            {

            }

            return dsi;
        }

        public DataSet usuarioLogin(string username, string password)
        {
            DataSet dataSet = new DataSet();

            try
            {
                MySqlConnection cn = new MySqlConnection();
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
                cn.Open();

                MySqlDataAdapter dataAdapter;
                dataAdapter = new MySqlDataAdapter("select * from user where username ='" + username + "' and password ='" + password + "'", cn);
                dataAdapter.Fill(dataSet);
                cn.Close();
            } catch (Exception ex)
            {

            }
           
            return dataSet;

        }

        public Int32 insertarUsuario(string username, string password, int agenteID)
        {
            Int32 respuesta = 0;

            try
            {
                MySqlConnection cn = new MySqlConnection();
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
                cn.Open();

                MySqlCommand command = new MySqlCommand("insert into user(username,password,agentId) values ('" + username + "','" + password + "'," + agenteID + ")", cn);

                respuesta = command.ExecuteNonQuery();
                cn.Close();
            } catch (Exception ex)
            {

            }

            return respuesta;
        }

        public Int32 actualizarUsuario(int id,string username, string password)
        {
            Int32 respuesta = 0;

            try
            {
                MySqlConnection cn = new MySqlConnection();
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
                cn.Open();

                MySqlCommand command = new MySqlCommand("update user set username='" + username + "',password='" + password + "' where id=" + id + "", cn);

                respuesta = command.ExecuteNonQuery();
                cn.Close();
            } catch (Exception ex)
            {

            }

            return respuesta;
        }

        public Int32 eliminarUsuario(int userId)
        {
            Int32 respuesta = 0;

            try
            {
                MySqlConnection cn = new MySqlConnection();
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
                cn.Open();

                MySqlCommand command = new MySqlCommand("delete from user where id=" + userId + "", cn);

                respuesta = command.ExecuteNonQuery();
                cn.Close();
            } catch (Exception ex)
            {

            }

            return respuesta;
        }
    }
}