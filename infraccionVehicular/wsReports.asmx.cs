using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace infraccionVehicular
{
    /// <summary>
    /// Descripción breve de wsInfractionReport
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class wsReports : System.Web.Services.WebService
    {

        [WebMethod]
        public DataSet infractionReport(int idInfraction)
        {
            return new Clases.csReports().infractionReport(idInfraction);
        }

        [WebMethod]
        public DataSet vehicleSolvencyReport(string licensePlate)
        {
            return new Clases.csReports().vehicleSolvencyReport(licensePlate);
        }
    }
}
