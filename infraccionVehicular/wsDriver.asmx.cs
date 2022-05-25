using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace infraccionVehicular
{
    /// <summary>
    /// Descripción breve de wsDriver
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class wsDriver : System.Web.Services.WebService
    {

        [WebMethod]
        public DataSet findDrivers()
        {
            return new Clases.csDriver().findDrivers();
        }

        [WebMethod]
        public DataSet findDriver(string driverLicense)
        {
            return new Clases.csDriver().findDriver(driverLicense);
        }

        [WebMethod]
        public Int32 insertDriver(string driverLicense, string name, string lastName, string age)
        {
            return new Clases.csDriver().saveDriver(driverLicense, name, lastName, age);
        }

        [WebMethod]
        public Int32 updateDriver(string driverLicense, string name, string lastName, string age)
        {
            return new Clases.csDriver().updateDriver(driverLicense, name, lastName, age);
        }

        [WebMethod]
        public Int32 deleteDriver(string driverLicense)
        {
            return new Clases.csDriver().deleteDriver(driverLicense);
        }
    }
}
