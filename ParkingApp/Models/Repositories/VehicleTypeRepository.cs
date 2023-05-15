using ParkingApp.Config;
using ParkingApp.Models.entities;
using System.Data.SqlClient;
using System.Data;
using System.Numerics;

namespace ParkingApp.Models.Repositories
{
    public class VehicleTypeRepository
    {
        public VehicleTypeModel findVehicleTypeById(int idTipoVehiculo)
        {
            VehicleTypeModel vehicleTypeModel = new VehicleTypeModel();
            var cn = new ConnectorSql();

            using (var conection = new SqlConnection(cn.getStringSQL()))
            {
                conection.Open();
                SqlCommand cmd = new SqlCommand("sp_find_vehicle_type", conection);
                cmd.Parameters.AddWithValue("idTipoVehiculo", idTipoVehiculo);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        vehicleTypeModel.idTipoVehiculo = Convert.ToInt32(dr["idTipoVehiculo"]);
                        vehicleTypeModel.vlrTarifa = Convert.ToInt32(dr["vlrTarifa"]);
                        vehicleTypeModel.nombreTipo = dr["nombreTipo"].ToString();
                    }
                }
            }

            return vehicleTypeModel;
        }
    }
}
