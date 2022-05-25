using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;

namespace infraccionVehicular
{
    /// <summary>
    /// Descripción breve de wsSanction
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class wsSanction : System.Web.Services.WebService
    {

        [WebMethod]
        public DataSet findSanctions()
        {
            return new Clases.csSanction().findAll();
        }

        [WebMethod]
        public DataSet findSanction(int id)
        {
            return new Clases.csSanction().findById(id);
        }

        [WebMethod]
        public Int32 insertSanction(string description, double amount)
        {
            return new Clases.csSanction().save(description, amount);
        }

        [WebMethod]
        public Int32 updateSanction(string description, double amount, int id)
        {
            return new Clases.csSanction().update(description, amount, id);
        }

        [WebMethod]
        public Int32 deleteSanction(int id)
        {
            return new Clases.csSanction().delete(id);
        }
    }
}
