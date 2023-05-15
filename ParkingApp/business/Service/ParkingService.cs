using ParkingApp.Models.Dto;

namespace ParkingApp.business.Service
{
    public interface ParkingService
    {
        public List<ParkingDto> findRegiterdByHour(DateTime intialDate, DateTime finalDate);
        public List<ParkingDto> findActivePArking();
        public MessageDto newEntry(EntryParkingDto entryParkingDto);
        public MessageDto calculateToPay(VehicleToPayDto vehicleToPayDto);
        public MessageDto payParking(String placa, bool toPay);
    }
}
