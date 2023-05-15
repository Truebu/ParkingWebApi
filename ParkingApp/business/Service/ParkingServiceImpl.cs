using ParkingApp.Models.Dto;
using ParkingApp.Models.entities;
using ParkingApp.Models.Repositories;

namespace ParkingApp.business.Service
{
    public class ParkingServiceImpl : ParkingService
    {
        ParkingRepository parkingRepository = new ParkingRepository();
        VehicleTypeRepository vehicleTypeRepository = new VehicleTypeRepository();

        public List<ParkingDto> findRegiterdByHour(DateTime intialDate, DateTime finalDate)
        {
            List<HistParkingModel> histParkingModels = parkingRepository.findRegiterdByHour(intialDate, finalDate);
            List<ParkingDto> parkingList = new List<ParkingDto>();
            foreach (HistParkingModel parkingModel in histParkingModels)
            {
                parkingList.Add(new ParkingDto(parkingModel, vehicleTypeRepository.findVehicleTypeById(parkingModel.idTipoVehiculo).nombreTipo));
            }
            return parkingList;
        }

        public List<ParkingDto> findActivePArking()
        {
            List<HistParkingModel> histParkingModels = parkingRepository.findActivePArking();
            List<ParkingDto> parkingList = new List<ParkingDto>();
            foreach (HistParkingModel parkingModel in histParkingModels)
            {
                parkingList.Add(new ParkingDto(parkingModel, vehicleTypeRepository.findVehicleTypeById(parkingModel.idTipoVehiculo).nombreTipo));
            }
            return parkingList;
        }

        public MessageDto newEntry(EntryParkingDto entryParkingDto)
        {
            if (parkingRepository.findVehicleByPlacaActive(entryParkingDto.placa) != null)
            {
                return new MessageDto("El vehiculo tiene parqueadero activo");
            }
            try
            {
                parkingRepository.newEntry(new HistParkingModel(entryParkingDto));
                return new MessageDto("Registro exitoso");
            }
            catch (Exception e)
            {
                string error = e.Message;
                return new MessageDto("Hubo un error al conectar con la base de datos");
            }
        }

        public MessageDto calculateToPay(VehicleToPayDto vehicleToPayDto)
        {
            if (vehicleToPayDto.descuento)
                if (parkingRepository.findBillNumber(vehicleToPayDto.numeroFactura))
                    return new MessageDto("La factura ya se ha usado");
            HistParkingModel parkingModel = parkingRepository.findVehicleByPlacaActive(vehicleToPayDto.placa);
            if (parkingModel != null)
            {
                return new MessageDto("No se encontró el vehiculo");
            }
            parkingModel.fechaSalida = DateTime.Now;
            parkingModel.tiempoParqueo = (int)parkingModel.fechaIngrso.Subtract((DateTime)parkingModel.fechaSalida).TotalMinutes;
            parkingModel.vlrPago = parkingModel.tiempoParqueo * vehicleTypeRepository.findVehicleTypeById(parkingModel.idTipoVehiculo).vlrTarifa;
            if (vehicleToPayDto.descuento)
                parkingModel.vlrPago = parkingModel.vlrPago * 0.7;
            return parkingRepository.updateParking(parkingModel) ? new MessageDto("El valor a pagar es: ", parkingModel.vlrPago) : new MessageDto("Hubo un error, vuelva a intentar");
        }

        public MessageDto payParking(String placa, bool toPay)
        {
            try
            {
                HistParkingModel parkingModel = parkingRepository.findVehicleByPlacaActive(placa);
                if (toPay)
                {
                    parkingModel.activo = false;
                    return parkingRepository.updateParking(parkingModel) ? new MessageDto("Actualización exitosa") : new MessageDto("Hubo un error, vuelva a intentar");

                }
                return new MessageDto("Pago cancelado");
            }
            catch (Exception e)
            {
                string error = e.Message;
                return new MessageDto("Hubo un error al conectar con la base de datos");
            }
        }
    }
}
