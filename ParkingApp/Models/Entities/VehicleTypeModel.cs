using System.ComponentModel.DataAnnotations;

namespace ParkingApp.Models.entities
{
    public class VehicleTypeModel
    {
        public int idTipoVehiculo { get; set; }
        public int vlrTarifa { get; set; }
        public string? nombreTipo { get; set; }

    }
}
