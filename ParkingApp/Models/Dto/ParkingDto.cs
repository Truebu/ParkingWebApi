using ParkingApp.Models.entities;

namespace ParkingApp.Models.Dto
{
    public class ParkingDto
    {
        public int idTrParqueo { get; set; }
        public String tipoVehiculo { get; set; }
        public String placa { get; set; }
        public DateTime fechaIngrso { get; set; }
        public int tiempoParqueo { get; set; }
        private double vlrPago { get; set; }

        public ParkingDto(HistParkingModel parkingModel, String tipoVehiculo)
        {
            this.idTrParqueo = parkingModel.idTrParqueo;
            this.tipoVehiculo = tipoVehiculo;
            this.placa = parkingModel.placa;
            this.fechaIngrso = parkingModel.fechaIngrso;
            this.tiempoParqueo = parkingModel.tiempoParqueo;
            this.vlrPago = parkingModel.vlrPago;
        }

    }
}