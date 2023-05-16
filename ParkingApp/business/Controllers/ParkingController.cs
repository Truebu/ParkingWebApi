using Microsoft.AspNetCore.Mvc;
using ParkingApp.business.Service;
using ParkingApp.Models.Dto;

namespace ParkingApp.business.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingController : ControllerBase
    {
        private readonly ParkingService _parkingService;

        public ParkingController(ParkingService parkingService)
        {
            _parkingService = parkingService;
        }

        [HttpGet]
        [Route("list")]
        public IActionResult findRegiterdByHour(DateTime intialDate, DateTime finalDate)
        {
            return Ok(_parkingService.findRegiterdByHour(intialDate, finalDate));
        }

        [HttpGet]
        [Route("listActive")]
        public IActionResult findActivePArking()
        {
            return Ok(_parkingService.findActivePArking());
        }

        [HttpPost]
        [Route("newEntry")]
        public IActionResult newEntry(EntryParkingDto entryParkingDto)
        {
            MessageDto dto = _parkingService.newEntry(entryParkingDto);
            if (dto.error)
                return BadRequest(dto.message);
            return Ok(dto.message);
        }

        [HttpPut]
        [Route("calculatePay")]
        public IActionResult calculateToPay(VehicleToPayDto vehicleToPayDto)
        {
            MessageDto dto = _parkingService.calculateToPay(vehicleToPayDto);
            if (dto.error)
                return BadRequest(dto.message);
            return Ok(dto.message);
        }

        [HttpPut]
        [Route("pay")]
        public IActionResult payParking(String placa, bool toPay)
        {
            MessageDto dto = _parkingService.payParking(placa, toPay);
            if (dto.error)
                return BadRequest(dto.message);
            return Ok(dto.message);
        }
    }
}
