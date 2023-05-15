namespace ParkingApp.Models.Dto
{
    public class VehicleToPayDto
    {
        public String placa {get; set;}
        public bool descuento { get; set; }
        public string numeroFactura { get; set; }

        public VehicleToPayDto(string placa, bool descuento, string numeroFactura)
        {
            this.placa = placa;
            this.descuento = descuento;
            this.numeroFactura = numeroFactura;
        }
    }
}