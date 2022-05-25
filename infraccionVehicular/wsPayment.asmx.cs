using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;

namespace infraccionVehicular
{
    /// <summary>
    /// Descripción breve de wsPayment
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class wsPayment : System.Web.Services.WebService
    {

        [WebMethod]
        public DataSet findPayments()
        {
            return new Clases.csPayment().findAll();
        }

        [WebMethod]
        public DataSet findPayment(int id)
        {
            return new Clases.csPayment().findById(id);
        }

        [WebMethod]
        public Int32 insertPayment(double amount, DateTime paidAt, int infractionId)
        {
            return new Clases.csPayment().save(amount, paidAt, infractionId);
        }

        [WebMethod]
        public Int32 updatePayment(double amount, DateTime paidAt, int infractionId, int id)
        {
            return new Clases.csPayment().update(amount, paidAt, infractionId, id);
        }


        [WebMethod]
        public Int32 deletePayment(int id)
        {
            return new Clases.csPayment().delete(id);
        }
    }
}