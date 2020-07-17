using System.Collections.Generic;
using System;
using BeLife.Dominio.Clases;
using BeLife.Negocio.Consultas;
using BeLife.Datos.ConsultarDatos;
using BeLife.Dominio.Dto;

namespace BeLife.Negocio.DAO
{
    public class DaoVivienda : IDaoVivienda
    {

        // Constructor
        private DaoVivienda()
        { }


        // Metodo de construccion.
        public static DaoVivienda CrearDao()
        {
            return new DaoVivienda();
        }


        // Metodo para crear la vivienda
        public void Agregar(Vivienda myVivienda)
        {
            try
            {
                var myQuery = EjecutarConsultas.Crear(StringResources.queryVivienda_Agregar);
                myQuery.AgregarParametro("pCodigoPostal", myVivienda.CodigoPostal, System.Data.DbType.Int32);
                myQuery.AgregarParametro("pAno", myVivienda.AnoVivienda, System.Data.DbType.Int32);
                myQuery.AgregarParametro("pDireccion", myVivienda.Direccion, System.Data.DbType.String);
                myQuery.AgregarParametro("pValorInmueble", myVivienda.ValorVivienda, System.Data.DbType.Double);
                myQuery.AgregarParametro("pValorContenido", myVivienda.ValorContenido, System.Data.DbType.Double);
                myQuery.AgregarParametro("pIdComuna", myVivienda.IdComuna, System.Data.DbType.Int32);
                myQuery.Ejecutar();
                myQuery.CerrarConsulta();
            }
            catch
            {
                throw;
            }
        }



        public void Quitar(Vivienda myVivienda)
        {
            try
            {
                var myQuery = EjecutarConsultas.Crear(StringResources.queryVivienda_QuitarVivienda);
                myQuery.AgregarParametro("pCodigoPostal", myVivienda.CodigoPostal, System.Data.DbType.Int32);
                myQuery.Ejecutar();
                myQuery.CerrarConsulta();
            }
            catch
            {
                throw;
            }
        }



        public void QuitarRelacion(string nroContrato, Vivienda myVivienda)
        {
            try
            {
                var myQuery = EjecutarConsultas.Crear(StringResources.queryVivienda_QuitarRelacion);
                myQuery.AgregarParametro("pNroContrato", nroContrato, System.Data.DbType.String);
                myQuery.AgregarParametro("pCodigoPostal", myVivienda.CodigoPostal, System.Data.DbType.Int32);
                myQuery.Ejecutar();
                myQuery.CerrarConsulta();
            }
            catch
            {
                throw;
            }
        }



        public void AgregarRelacion(string nroContrato, Vivienda myVivienda)
        {
            try
            {
                var myQuery = EjecutarConsultas.Crear(StringResources.queryVivienda_AgregarRelacion);
                myQuery.AgregarParametro("pNroContrato", nroContrato, System.Data.DbType.String);
                myQuery.AgregarParametro("pCodigoPostal", myVivienda.CodigoPostal, System.Data.DbType.Int32);
                myQuery.Ejecutar();
                myQuery.CerrarConsulta();
            }
            catch
            {
                throw;
            }
        }








        // Metodo para buscar una vivienda
        public List<Vivienda> ObtenerViviendaPorNroContrato(string unNroContrato)
        {
            try
            {
                var myQuery = ConsultarDatos.Crear(StringResources.queryVivienda_BuscarPorNroContrato);
                myQuery.AgregarParametro(":pNroContrato", unNroContrato, System.Data.DbType.String);
                return myQuery.ObtenerResultadosDeConsulta<Vivienda>();
            }
            catch
            {
                throw;
            }
        }



        // Metodo para listar las comunas
        public List<DtoComuna> ObtenerListaDeComunasPorRegion(int idRegion)
        {
            try
            {
                var listaComunas = ConsultarDatos.Crear(StringResources.queryComuna_ListarPorRegion);
                listaComunas.AgregarParametro(":pIdRegion", idRegion, System.Data.DbType.Int32);
                return listaComunas.ObtenerResultadosDeConsulta<DtoComuna>();
            }
            catch
            {
                throw;
            }
        }


        // Metodo para listar las regiones.
        public List<DtoRegion> ObtenerRegiones()
        {
            try
            {
                var listaRegiones = ConsultarDatos.Crear(StringResources.queryRegion_ListarTodo);
                return listaRegiones.ObtenerResultadosDeConsulta<DtoRegion>();
            }
            catch
            {
                throw;
            }
        }

    }
}
