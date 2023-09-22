using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using RITAutomation.Models;
using System.Data;
using System.Windows.Forms;
using RITAutomation.Utils;

namespace RITAutomation.Services
{
    public class TransportCoordinatesService
    {
        private const string connectionString = @"Data Source=MSI;Initial Catalog=RIT_Automation;Integrated Security=True";
        string getTransportUnitsSql = "dbo.GetAllTransportUnits";
        string saveTransportUnitCoordinatesSql = "dbo.SaveTransportCoordinates";

        public List<TransportUnit> GetTransportUnits()
        {
            List<TransportUnit> units = new List<TransportUnit>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(getTransportUnitsSql, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = (int)reader.GetValue(0);
                        string name = (string)reader.GetValue(1);
                        double longtitude = (double)reader.GetValue(2);
                        double latitude = (double)reader.GetValue(3);
                        units.Add(new TransportUnit(id, name, latitude, longtitude));
                    }
                }
                else
                {
                    throw new NoRowsException();
                }
            }

            return units;
        }

        public void SaveTransportUnitCoordinates(string name, double latitude, double longtitude)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(saveTransportUnitCoordinatesSql, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@latitude", latitude);
                command.Parameters.AddWithValue("@longtitude", longtitude);
                command.ExecuteNonQuery();
            }
        }
    }
}