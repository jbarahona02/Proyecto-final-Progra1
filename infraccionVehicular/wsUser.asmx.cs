using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;

namespace infraccionVehicular
{
    /// <summary>
    /// Descripción breve de wsUser
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class wsUser : System.Web.Services.WebService
    {

        [WebMethod]
        public DataSet listadoDeUsuarios()
        {
            return new Clases.csUser().listaDeUsuarios();
        }

        [WebMethod]
        public DataSet loginUsuario(string username, string password)
        {
            return new Clases.csUser().usuarioLogin(username, password);
        }

        [WebMethod]
        public Int32 insertarUsuario(string username, string password, int agenteID)
        {
            return new Clases.csUser().insertarUsuario(username, password, agenteID);
        }

        [WebMethod]
        public Int32 actualizarUsuario(int id, string username, string password)
        {
            return new Clases.csUser().actualizarUsuario(id, username, password);
        }

        [WebMethod]
        public Int32 eliminarUsuario(int userID)
        {
            return new Clases.csUser().eliminarUsuario(userID);
        }
    }
}
