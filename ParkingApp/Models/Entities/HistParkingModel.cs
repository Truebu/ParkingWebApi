using ParkingApp.Models.Dto;
using System.ComponentModel.DataAnnotations;

namespace ParkingApp.Models.entities
{
    public class HistParkingModel
    {
        public int idTrParqueo { get; set; }
        [Required(ErrorMessage = "El tipo de vehiculo es obligatorio")]
        public int idTipoVehiculo { get; set; }
        [Required(ErrorMessage = "El campo Placa es obligatorio")]
        public string placa { get; set; }
        public DateTime fechaIngrso { get; set; }
        public DateTime fechaSalida { get; set; }
        public double vlrPago { get; set; }
        public int tiempoParqueo { get; set; }
        public bool descuento { get; set; }
        public string numeroFactura { get; set; }
        public bool activo { get; set; }

        public HistParkingModel(int idTrParqueo, int idTipoVehiculo,
            string placa, DateTime fechaIngrso, DateTime fechaSalida,
            int vlrPago, int tiempoParqueo, bool descuento, string numeroFactura, bool activo)
        {
            this.idTrParqueo = idTrParqueo;
            this.idTipoVehiculo = idTipoVehiculo;
            this.placa = placa;
            this.fechaIngrso = fechaIngrso;
            this.fechaSalida = fechaSalida;
            this.vlrPago = vlrPago;
            this.tiempoParqueo = tiempoParqueo;
            this.descuento = descuento;
            this.numeroFactura = numeroFactura;
            this.activo = activo;
        }

        public HistParkingModel()
        {
        }

        public HistParkingModel(EntryParkingDto entryParkingDto)
        {
            this.idTipoVehiculo = entryParkingDto.idTipoVehiculo;
            this.placa = entryParkingDto.placa;
            this.fechaIngrso = DateTime.Now;
            this.activo = true;
        }

    }
}
