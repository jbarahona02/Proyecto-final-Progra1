using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;

namespace infraccionVehicular
{
    /// <summary>
    /// Descripción breve de wsVehicle
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class wsVehicle : System.Web.Services.WebService
    {

        [WebMethod]
        public DataSet findVehicles()
        {
            return new Clases.csVehicle().findAll();
        }

        [WebMethod]
        public DataSet findVehicle(int id)
        {
            return new Clases.csVehicle().findById(id);
        }

        [WebMethod]
        public Int32 insertVehicle(string licensePlate, string type, string color, string line, string brand, string driverId)
        {
            return new Clases.csVehicle().save(licensePlate, type, color, line, brand, driverId);
        }

        [WebMethod]
        public Int32 updateVehicle(int id, string licensePlate, string type, string color, string line, string brand, string driverId)
        {
            return new Clases.csVehicle().update(id, licensePlate, type, color, line, brand, driverId);
        }

        [WebMethod]
        public Int32 deleteVehicle(int id)
        {
            return new Clases.csVehicle().delete(id);
        }
    }
}
