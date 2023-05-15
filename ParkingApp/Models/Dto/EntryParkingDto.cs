namespace ParkingApp.Models.Dto
{
    public class EntryParkingDto
    {
        public int idTipoVehiculo { get; set; }
        public string placa { get; set; }

        public EntryParkingDto(int idTipoVehiculo, string placa)
        {
            this.idTipoVehiculo = idTipoVehiculo;
            this.placa = placa;
        }
    }
}