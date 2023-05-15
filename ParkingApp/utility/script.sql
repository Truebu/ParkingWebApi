USE ParkingDB

CREATE TABLE VEHICLETYPE(
idTipoVehiculo int identity primary key,
vlrTarifa int NOT NULL,
nombreTipo varchar(50)
)


CREATE TABLE HISTPARKING(
idTrParqueo int identity primary key,
idTipoVehiculo int REFERENCES VEHICLETYPE(idTipoVehiculo),
placa varchar(50) NOT NULL,
fechaIngrso DATETIME NOT NULL,
fechaSalida DATETIME NOT NULL,
vlrPago int,
tiempoParqueo int,
descuento bit,
numeroFactura varchar(50),
activo bit,
)

INSERT VEHICLETYPE (vlrTarifa, nombreTipo) VALUES (110, 'CARRO')
INSERT VEHICLETYPE (vlrTarifa, nombreTipo) VALUES (50, 'MOTOCICLETA')
INSERT VEHICLETYPE (vlrTarifa, nombreTipo) VALUES (10, 'BICICLETA')

create procedure sp_find_vehicle_type(
	@idTipoVehiculo int
)
as
begin
	select * from VEHICLETYPE WHERE idTipoVehiculo = @idTipoVehiculo
end

create procedure sp_find_placa_active(
@placa varchar(50)
)
as
begin
	select * from HISTPARKING where  placa = @placa AND activo = 1
end

create procedure sp_find_bill_number_exists(
@numeroFactura varchar(50)
)
as
begin
	select descuento as exixtsBill from HISTPARKING where  numeroFactura = @numeroFactura
end

create procedure sp_list_by_hour(
@intialDate DATETIME,
@finalDate DATETIME
)
as
begin
	select * from HISTPARKING where  fechaIngrso >= @intialDate AND fechaIngrso <= @finalDate
end

create procedure sp_list_active
as
begin
	select * from HISTPARKING where activo = 1
end

create procedure sp_save_parking(
@idTipoVehiculo int,
@placa varchar(50),
@fechaIngrso DATETIME,
@activo bit
)
as
begin
	insert into HISTPARKING(idTipoVehiculo,placa,fechaIngrso,activo) values (@idTipoVehiculo,@placa,@fechaIngrso,@activo)
end

create procedure sp_update_parking(
@idTrParqueo int,
@idTipoVehiculo int,
@placa varchar(50),
@fechaIngrso DATETIME,
@fechaSalida DATETIME,
@vlrPago int,
@tiempoParqueo int,
@descuento bit,
@numeroFactura varchar(50),
@activo bit
)
as
begin
	update HISTPARKING set idTipoVehiculo = @idTipoVehiculo, placa = @placa , fechaIngrso = @fechaIngrso , fechaSalida = @fechaSalida , vlrPago = @vlrPago , tiempoParqueo = @tiempoParqueo , descuento = @descuento , numeroFactura = @numeroFactura , activo = @activo where idTrParqueo = @idTrParqueo
end