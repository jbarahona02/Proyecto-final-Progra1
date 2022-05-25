using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;

namespace infraccionVehicular
{
    /// <summary>
    /// Summary description for wsInfraction
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class wsInfraction : System.Web.Services.WebService
    {

        [WebMethod]
        public DataSet findInfractions()
        {
            return new Clases.csInfraction().infractionList();
        }

        [WebMethod]
        public DataSet findInfraction(int id)
        {
            return new Clases.csInfraction().infraction(id);
        }

        [WebMethod]
        public Int32 insertInfraction(double total, int agentId, int vehicleId)
        {
            return new Clases.csInfraction().insertInfraction(total, agentId, vehicleId);
        }

        [WebMethod]
        public Int32 updateInfraction(int id, string status, double total, int agentId, int vehicleId)
        {
            return new Clases.csInfraction().updateInfraction(id, status, total, agentId, vehicleId);
        }

        [WebMethod]
        public Int32 deleteInfraction(int id)
        {
            return new Clases.csInfraction().deleteInfraction(id);
        }

    }
}
