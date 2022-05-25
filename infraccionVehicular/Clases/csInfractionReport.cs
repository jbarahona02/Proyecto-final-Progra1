using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace infraccionVehicular.Clases
{
    public class csInfractionReport
    {
        public DataSet infractionReport(int idInfraction)
        {
            DataSet dsi = new DataSet();

            try
            {
                MySqlConnection cn = new MySqlConnection();

                cn.ConnectionString = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
                cn.Open();

                MySqlDataAdapter da;

                da = new MySqlDataAdapter("SELECT i.createdAt as infractionDate, " +
                                            "i.total as totalInfraction, v.licensePlate as vehicle, s.description as sanction, " +
                                            "a.name as agent, p.paidAt as datePaid, p.amount as paidAmount FROM infraction i " +
                                            "LEFT JOIN payment p on i.id = p.infractionId INNER JOIN infractionDetailId id on i.id = id.infractionId " +
                                            "LEFT JOIN sanction s on id.sanctionId = s.id LEFT JOIN vehicle v on i.vehicleId = v.id " +
                                            "INNER JOIN driver d on v.driverId = d.driverLicense INNER JOIN agent a on i.agentId = a.id " +
                                            "WHERE i.id =" + idInfraction, cn);

                da.Fill(dsi);
                cn.Close();

            }
            catch (Exception ex)
            {

            }

            return dsi;

        }

    }
}