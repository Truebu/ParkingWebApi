﻿using ParkingApp.Config;
using ParkingApp.Models.entities;
using System.Data.SqlClient;
using System.Data;

namespace ParkingApp.Models.Repositories
{
    public class ParkingRepository
    {
        public HistParkingModel findVehicleByPlacaActive(String placa)
        {
            HistParkingModel histParking = new HistParkingModel();
            var cn = new ConnectorSql();

            using (var conection = new SqlConnection(cn.getStringSQL()))
            {
                conection.Open();
                SqlCommand cmd = new SqlCommand("sp_find_placa_active", conection);
                cmd.Parameters.AddWithValue("placa", placa);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        histParking.idTrParqueo = Convert.ToInt32(dr["idTrParqueo"]);
                        histParking.idTipoVehiculo = Convert.ToInt32(dr["idTipoVehiculo"]);
                        histParking.placa = dr["placa"].ToString();
                        histParking.fechaIngrso = Convert.ToDateTime(dr["fechaIngrso"]);
                        histParking.fechaSalida = Convert.ToDateTime(dr["fechaSalida"]);
                        histParking.vlrPago = Convert.ToInt32(dr["vlrPago"]);
                        histParking.tiempoParqueo = Convert.ToInt32(dr["tiempoParqueo"]);
                        histParking.descuento = Convert.ToBoolean(dr["descuento"]);
                        histParking.numeroFactura = dr["numeroFactura"].ToString();
                        histParking.activo = Convert.ToBoolean(dr["activo"]);
                    }
                }
            }

            return histParking;
        }

        public bool findBillNumber(String numeroFactura)
        {
            bool exixts = false;
            var cn = new ConnectorSql();

            using (var conection = new SqlConnection(cn.getStringSQL()))
            {
                conection.Open();
                SqlCommand cmd = new SqlCommand("sp_find_bill_number_exists", conection);
                cmd.Parameters.AddWithValue("numeroFactura", numeroFactura);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        exixts = Convert.ToBoolean(dr["exixtsBill"]);
                    }
                }
            }

            return exixts;
        }

        public List<HistParkingModel> findRegiterdByHour(DateTime intialDate, DateTime finalDate)
        {
            List<HistParkingModel> histParkingModels = new List<HistParkingModel>();
            var cn = new ConnectorSql();

            using (var conection = new SqlConnection(cn.getStringSQL()))
            {
                conection.Open();
                SqlCommand cmd = new SqlCommand("sp_list_by_hour", conection);
                cmd.Parameters.AddWithValue("intialDate", intialDate);
                cmd.Parameters.AddWithValue("finalDate", finalDate);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        histParkingModels.Add(new HistParkingModel(
                            Convert.ToInt32(dr["idTrParqueo"]),
                            Convert.ToInt32(dr["idTipoVehiculo"]),
                            dr["placa"].ToString(),
                            Convert.ToDateTime(dr["fechaIngrso"]),
                            Convert.ToDateTime(dr["fechaSalida"]),
                            Convert.ToInt32(dr["vlrPago"]),
                            Convert.ToInt32(dr["tiempoParqueo"]),
                            Convert.ToBoolean(dr["descuento"]),
                            dr["numeroFactura"].ToString(),
                            Convert.ToBoolean(dr["activo"])
                        ));
                    }
                }
            }
            return histParkingModels;
        }

        public List<HistParkingModel> findActivePArking()
        {
            List<HistParkingModel> histParkingModels = new List<HistParkingModel>();
            var cn = new ConnectorSql();

            using (var conection = new SqlConnection(cn.getStringSQL()))
            {
                conection.Open();
                SqlCommand cmd = new SqlCommand("sp_list_active", conection);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        histParkingModels.Add(new HistParkingModel(
                            Convert.ToInt32(dr["idTrParqueo"]),
                            Convert.ToInt32(dr["idTipoVehiculo"]),
                            dr["placa"].ToString(),
                            Convert.ToDateTime(dr["fechaIngrso"]),
                            Convert.ToDateTime(dr["fechaSalida"]),
                            Convert.ToInt32(dr["vlrPago"]),
                            Convert.ToInt32(dr["tiempoParqueo"]),
                            Convert.ToBoolean(dr["descuento"]),
                            dr["numeroFactura"].ToString(),
                            Convert.ToBoolean(dr["activo"])
                        ));
                    }
                }
            }

            return histParkingModels;
        }

        public bool newEntry(HistParkingModel model)
        {
            try
            {
                var cn = new ConnectorSql();

                using (var conection = new SqlConnection(cn.getStringSQL()))
                {
                    conection.Open();
                    SqlCommand cmd = new SqlCommand("sp_save_parking", conection);
                    cmd.Parameters.AddWithValue("idTipoVehiculo", model.idTipoVehiculo);
                    cmd.Parameters.AddWithValue("placa", model.placa);
                    cmd.Parameters.AddWithValue("fechaIngrso", model.fechaIngrso);
                    cmd.Parameters.AddWithValue("activo", model.activo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                return false;
            }
        }

        public bool updateParking(HistParkingModel model)
        {
            try
            {
                var cn = new ConnectorSql();

                using (var conection = new SqlConnection(cn.getStringSQL()))
                {
                    conection.Open();
                    SqlCommand cmd = new SqlCommand("sp_update_parking", conection);
                    cmd.Parameters.AddWithValue("idTrParqueo", model.idTrParqueo);
                    cmd.Parameters.AddWithValue("idTipoVehiculo", model.idTipoVehiculo);
                    cmd.Parameters.AddWithValue("placa", model.placa);
                    cmd.Parameters.AddWithValue("fechaIngrso", model.fechaIngrso);
                    cmd.Parameters.AddWithValue("fechaSalida", model.fechaSalida);
                    cmd.Parameters.AddWithValue("vlrPago", model.vlrPago);
                    cmd.Parameters.AddWithValue("tiempoParqueo", model.tiempoParqueo);
                    cmd.Parameters.AddWithValue("descuento", model.descuento);
                    cmd.Parameters.AddWithValue("numeroFactura", model.numeroFactura);
                    cmd.Parameters.AddWithValue("activo", model.activo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                return false;
            }
        }
    }
}
