using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;

namespace infraccionVehicular
{
    /// <summary>
    /// Summary description for wsInfractionDetail
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class wsInfractionDetail : System.Web.Services.WebService
    {

        [WebMethod]
        public DataSet infractionDetailList()
        {
            return new Clases.csInfractionDetail().infractionDetailList();
        }

        [WebMethod]
        public DataSet infractionDetail(int id)
        {
            return new Clases.csInfractionDetail().infractionDetail(id);
        }

        [WebMethod]
        public DataSet infractionDetailsByInfractionId(int infractionID)
        {
            return new Clases.csInfractionDetail().infractionDetailsByInfractionId(infractionID);
        }

        [WebMethod]
        public Int32 insertInfractionDetail(int infractionId, int sanctionId)
        {
            return new Clases.csInfractionDetail().insertInfractionDetail(infractionId, sanctionId);
        }

        [WebMethod]
        public Int32 updateInfractionDetail(int id, int infractionId, int sanctionId)
        {
            return new Clases.csInfractionDetail().updateInfractionDetail(id, infractionId, sanctionId);
        }

        [WebMethod]
        public Int32 deleteInfractionDetail(int id)
        {
            return new Clases.csInfractionDetail().deleteInfractionDetail(id);
        }

        [WebMethod]
        public Int32 deleteInfractionDetailsByInfractionId(int infractionID)
        {
            return new Clases.csInfractionDetail().deleteInfractionDetailsByInfractionId(infractionID);
        }

    }
}
