using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaxiCab_WebHooksApi.Models;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Transactions;

namespace TaxiCab_WebHooksApi.Repository
{
    public class TaxiCabVehicleRepository : ITaxiCabVehicleRepository
    {
        DbConnection conn;

        public TaxiCabVehicleRepository() {

            var connectionString = ConfigurationManager.ConnectionStrings["TaxyCabDb2"];
                DbProviderFactory factory =
                DbProviderFactories.GetFactory(connectionString.ProviderName);
            conn = factory.CreateConnection();
            conn.ConnectionString = connectionString.ConnectionString;
        }

        public ResultTransactionModel UpdateLocation(UpdateLocationModel model)
        {

            var result= new ResultTransactionModel() { numAffactedRows = 0, Description = "" };
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    conn.Open();
                    model.locations.ForEach(l =>
                    {
                        var command = conn.CreateCommand();
                        command.CommandText = "[UpdateVehicleLocation]";
                        command.CommandType = CommandType.StoredProcedure;

                        DbParameter vehicleId = command.CreateParameter();
                        vehicleId.ParameterName = "@vehicleId";
                        vehicleId.Value = model.vehicle.vehicleId;


                        DbParameter location = command.CreateParameter();
                        location.ParameterName = "@location";
                        location.Value = $"POINT({l.latitud} {l.longitud})";


                        DbParameter datetime = command.CreateParameter();
                        datetime.ParameterName = "@datetime";
                        datetime.Value = l.datetime;


                        command.Parameters.Add(vehicleId);
                        command.Parameters.Add(location);
                        command.Parameters.Add(datetime);
                        result.numAffactedRows += command.ExecuteNonQuery();

                    });
                }
                finally
                {
                    conn.Close();
                }
                scope.Complete();
                return result;
            }


            

        }


        public ResultTransactionModel GetLocations(Vehicle vehicle, out GetLocationModel model)
        {
            try
            {
                GetLocationModel modelTem = new GetLocationModel();
                modelTem.locations = new List<Location>();
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText = "[GetVehicleLocation]";
                command.CommandType = CommandType.StoredProcedure;
                DbParameter vehicleId = command.CreateParameter();
                vehicleId.ParameterName = "@vehicleId";
                vehicleId.Value = vehicle.vehicleId;
                command.Parameters.Add(vehicleId);
                DbDataReader reader=  command.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read()) {

                    DateTime datetime = Convert.ToDateTime(reader["datetime"]);
                    string[] location = Convert.ToString(reader["location"]).Split(' ');
                    modelTem.locations.Add(new Location() { datetime =  datetime, latitud= location[0], longitud=location[1] });
                }
                model = modelTem;
                return new ResultTransactionModel() { numAffactedRows = null, Description = null };
            }
            finally {

                conn.Close();
            }
        }
    }
}