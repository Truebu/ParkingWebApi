using Microsoft.AspNetCore.Mvc;
using ParkingApp.business.Service;
using ParkingApp.Models.Dto;

namespace ParkingApp.business.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingController : ControllerBase
    {
        private ParkingService _parkingService;

        public ParkingController(ParkingService parkingService)
        {
            this._parkingService = parkingService;
        }

        [HttpGet]
        [Route("list")]
        public  List<ParkingDto> findRegiterdByHour(DateTime intialDate, DateTime finalDate)
        {
            return _parkingService.findRegiterdByHour(intialDate, finalDate);
        }

        [HttpGet]
        [Route("listActive")]
        public List<ParkingDto> findActivePArking()
        {
            return _parkingService.findActivePArking();
        }
        
        [HttpPost]
        [Route("newEntry")]
        public MessageDto newEntry(EntryParkingDto entryParkingDto)
        {
            return _parkingService.newEntry(entryParkingDto);
        }

        [HttpPut]
        [Route("calculatePay")]
        public MessageDto calculateToPay(VehicleToPayDto vehicleToPayDto)
        {
            return _parkingService.calculateToPay(vehicleToPayDto);
        }
        
        [HttpPut]
        [Route("pay")]
        public MessageDto payParking(String placa, bool toPay)
        {
            return _parkingService.payParking(placa, toPay);
        }
    }
}
