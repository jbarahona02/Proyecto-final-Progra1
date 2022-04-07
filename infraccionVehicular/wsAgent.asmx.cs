using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace infraccionVehicular
{
    /// <summary>
    /// Descripción breve de wsAgent
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class wsAgent : System.Web.Services.WebService
    {

        [WebMethod]
        public DataSet findAgents()
        {
            return new Clases.csAgent().findAgents();
        }

        [WebMethod]
        public DataSet findAgent(int id)
        {
            return new Clases.csAgent().findAgent(id);
        }

        [WebMethod]
        public Int32 saveAgent(string name, string lastName, string dpi, string age, string phoneNumber)
        {
            return new Clases.csAgent().saveAgent(name, lastName, dpi, age, phoneNumber);
        }

        [WebMethod]
        public Int32 updateAgent(int id, string name, string lastName, string dpi, string age, string phoneNumber)
        {
            return new Clases.csAgent().updateAgent(id, name, lastName, dpi, age, phoneNumber);
        }

        [WebMethod]
        public Int32 deleteAgent(int id)
        {
            return new Clases.csAgent().deleteAgent(id);
        }
    }
}
