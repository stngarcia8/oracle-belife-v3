using System.Collections.Generic;
using System;
using BeLife.Dominio.Clases;
using BeLife.Negocio.Consultas;
using BeLife.Datos.ConsultarDatos;
using BeLife.Dominio.Dto;

namespace BeLife.Negocio.DAO
{
    public class DaoVehiculo : IDaoVehiculo
    {

        // Constructor
        private DaoVehiculo()
        { }


        // Metodo de construccion.
        public static DaoVehiculo CrearDao()
        {
            return new DaoVehiculo();
        }


        // Metodo para crear los vehiculos.
        public void Agregar(Vehiculo myVehiculo)
        {
            try
            {
                var myQuery =EjecutarConsultas.Crear(StringResources.queryVehiculo_Insertar);
                myQuery.AgregarParametro("pPatente", myVehiculo.Patente, System.Data.DbType.String);
                myQuery.AgregarParametro("pIdModelo", myVehiculo.IdModelo, System.Data.DbType.Int32);
                myQuery.AgregarParametro("pAno", myVehiculo.AnoVehiculo, System.Data.DbType.Int32);
                myQuery.Ejecutar();
                myQuery.CerrarConsulta();
            }
            catch
            {
                throw;
            }
        }

        public void Quitar( Vehiculo myVehiculo)
        {
            try
            {
                var myQuery = EjecutarConsultas.Crear(StringResources.queryVehiculo_eliminaVehiculo);
                myQuery.AgregarParametro("pPatente", myVehiculo.Patente, System.Data.DbType.String);
                myQuery.Ejecutar();
                myQuery.CerrarConsulta();
            }
            catch
            {
                throw;
            }
        }


        public void QuitarRelacion(string nroContrato, Vehiculo myVehiculo)
        {
            try
            {
                var myQuery = EjecutarConsultas.Crear(StringResources.queryVehiculo_QuitarRelacion);
                myQuery.AgregarParametro("pNroContrato", nroContrato, System.Data.DbType.String);
                myQuery.AgregarParametro("pPatente", myVehiculo.Patente, System.Data.DbType.String);
                myQuery.Ejecutar();
                myQuery.CerrarConsulta();
            }
            catch
            {
                throw;
            }
        }


        public void AgregarRelacion(string nroContrato, Vehiculo myVehiculo)
        {
            try
            {
                var myQuery = EjecutarConsultas.Crear(StringResources.queryVehiculo_RelacionarContratoVehiculo);
                myQuery.AgregarParametro("pNroContrato", nroContrato, System.Data.DbType.String);
                myQuery.AgregarParametro("pPatente", myVehiculo.Patente, System.Data.DbType.String);
                myQuery.Ejecutar();
                myQuery.CerrarConsulta();
            }
            catch
            {
                throw;
            }
        }








        // Metodo para buscar un vehiculo
        public List<Vehiculo> ObtenerVehiculoPorNroContrato(string unNroContrato)
        {
            try
            {
                var myQuery = ConsultarDatos.Crear(StringResources.queryVehiculo_BuscarPorNroContrato);
                myQuery.AgregarParametro(":pNroContrato", unNroContrato, System.Data.DbType.String);
                return myQuery.ObtenerResultadosDeConsulta<Vehiculo>();
            }
            catch
            {
                throw;
            }
        }






        // Metodo para listar los modelos
        public List<DtoModelo> ObtenerListaDeModelosPorMarca(int idMarca)
        {
            try
            {
                var listaModelos = ConsultarDatos.Crear(StringResources.queryVehiculo_ListarModelosPorMarca);
                listaModelos.AgregarParametro(":pIdMarca", idMarca, System.Data.DbType.Int32);
                return listaModelos.ObtenerResultadosDeConsulta<DtoModelo>();
            }
            catch
            {
                throw;
            }
        }


        // Metodo para listar las marcas.
        public List<DtoMarca> ObtenerMarcasDeVehiculos()
        {
            try
            {
                var listaMarcas = ConsultarDatos.Crear(StringResources.queryVehiculo_ListarMarcas);
                return listaMarcas.ObtenerResultadosDeConsulta<DtoMarca>();
            }
            catch
            {
                throw;
            }
        }

    }
}
