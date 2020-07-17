using System.Collections.Generic;
using System.Data;
using BeLife.Negocio.Consultas;
using BeLife.Datos.ConsultarDatos;
using BeLife.Dominio.Clases;
using BeLife.Dominio.Dto;

namespace BeLife.Negocio.DAO
{
    public class DaoContrato : IDaoContrato
    {

        // Constructor.
        private DaoContrato()
        { }


        // metodos de creacion de objeto.
        public static DaoContrato Crear()
        {
            return new DaoContrato();
        }


        // Metodo para crear un contrato.
        public int NuevoContrato(Contrato myContrato)
        {
            int registro = 0;
            try
            {
                var nuevoContrato = EjecutarConsultas.Crear(StringResources.queryContrato_Insertar);
                nuevoContrato.AgregarParametro("numero", myContrato.NumeroContrato, DbType.String);
                this.establecerParametros(nuevoContrato, myContrato, true);
                registro = nuevoContrato.Ejecutar();
                nuevoContrato.CerrarConsulta();
                if (myContrato.IdTipoContrato.Equals(20))
                {
                    DaoVehiculo myDaoVehiculo = DaoVehiculo.CrearDao();
                    myDaoVehiculo.Quitar(myContrato.Vehiculo);
                    myDaoVehiculo.QuitarRelacion(myContrato.NumeroContrato, myContrato.Vehiculo);
                    myDaoVehiculo.Agregar(myContrato.Vehiculo);
                    myDaoVehiculo.AgregarRelacion(myContrato.NumeroContrato, myContrato.Vehiculo);
                }
                if (myContrato.IdTipoContrato.Equals(30))
                {
                    DaoVivienda myDaoVivienda = DaoVivienda.CrearDao();
                    myDaoVivienda.Quitar(myContrato.Vivienda);
                    myDaoVivienda.QuitarRelacion(myContrato.NumeroContrato, myContrato.Vivienda);
                    myDaoVivienda.Agregar(myContrato.Vivienda);
                    myDaoVivienda.AgregarRelacion(myContrato.NumeroContrato, myContrato.Vivienda);
                }
            }
            catch
            {
                throw;
            }
            return registro;
        }


        // Metodo para actualizar un contrato.
        public int ActualizarContrato(Contrato myContrato)
        {
            int registro = 0;
            try
            {
                var actualizaContrato = EjecutarConsultas.Crear(StringResources.queryContrato_Actualizar);
                this.establecerParametros(actualizaContrato, myContrato, false);
                actualizaContrato.AgregarParametro("numero", myContrato.NumeroContrato, DbType.String);
                actualizaContrato.AgregarParametro("rutCliente",myContrato.Cliente.Rut, DbType.String);
                registro = actualizaContrato.Ejecutar();
                actualizaContrato.CerrarConsulta();
                if (myContrato.IdTipoContrato.Equals(20))
                {
                    DaoVehiculo myDaoVehiculo = DaoVehiculo.CrearDao();
                    myDaoVehiculo.Quitar(myContrato.Vehiculo);
                    myDaoVehiculo.QuitarRelacion(myContrato.NumeroContrato, myContrato.Vehiculo);
                    myDaoVehiculo.Agregar(myContrato.Vehiculo);
                    myDaoVehiculo.AgregarRelacion(myContrato.NumeroContrato, myContrato.Vehiculo);
                }
                if (myContrato.IdTipoContrato.Equals(30))
                {
                    DaoVivienda myDaoVivienda = DaoVivienda.CrearDao();
                    myDaoVivienda.Quitar(myContrato.Vivienda);
                    myDaoVivienda.QuitarRelacion(myContrato.NumeroContrato, myContrato.Vivienda);
                    myDaoVivienda.Agregar(myContrato.Vivienda);
                    myDaoVivienda.AgregarRelacion(myContrato.NumeroContrato, myContrato.Vivienda);
                }
            }
            catch
            {
                throw;
            }
            return registro;
        }


        // Metodo para agregar los parametros a la consulta.
        private void establecerParametros(EjecutarConsultas ejecutor, Contrato myContrato, bool insertando)
        {
            ejecutor.AgregarParametro("fechaInicioContrato", myContrato.DetalleContrato.FechaInicioContrato, DbType.Date);
            ejecutor.AgregarParametro("fechaTerminoContrato", myContrato.DetalleContrato.FechaTerminoContrato, DbType.Date);
            if (insertando) ejecutor.AgregarParametro("rutCliente", myContrato.Cliente.Rut, DbType.String);
            ejecutor.AgregarParametro("idPlan", myContrato.Plan.IdPlan, DbType.String);
            ejecutor.AgregarParametro("inicioVigencia", myContrato.DetalleContrato.FechaInicioDeVigencia, DbType.Date);
            ejecutor.AgregarParametro("terminoVigencia", myContrato.DetalleContrato.FechaTerminoDeVigencia, DbType.Date);
            ejecutor.AgregarParametro("vigente", myContrato.DetalleContrato.VigenciaContrato, DbType.Int16);
            ejecutor.AgregarParametro("salud", myContrato.DetalleContrato.DeclaracionDeSalud, DbType.Int16);
            ejecutor.AgregarParametro("primaAnual", myContrato.Prima.ValorTotal, DbType.Double);
            ejecutor.AgregarParametro("primaMensual", myContrato.Plan.PrimaBase, DbType.Double);
            ejecutor.AgregarParametro("observaciones", myContrato.DetalleContrato.Observaciones, DbType.String);
        }


        // Metodo para listar los contratos.
        public List<DtoContrato> ObtenerListaContratos()
        {
            try
            {
                var listaContrato = ConsultarDatos.Crear(StringResources.queryContrato_ListarTodo);
                return listaContrato.ObtenerResultadosDeConsulta<DtoContrato>();
            }
            catch
            {
                throw;
            }
        }


        // Metodo para listar los contratos por numero de contrato.
        public List<DtoContrato> ObtenerListaContratosPorNumeroDeContrato(string numero)
        {
            try
            {
                var listaContrato = ConsultarDatos.Crear(StringResources.queryContrato_ListarPorNumeroContrato);
                listaContrato.AgregarParametro("numero", numero, DbType.String);
                return listaContrato.ObtenerResultadosDeConsulta<DtoContrato>();
            }
            catch
            {
                throw;
            }
        }


        // Metodo para listar los contratos por rut.
        public List<DtoContrato> ObtenerListaContratosPorRut(string rutCliente)
        {
            try
            {
                var listaContrato = ConsultarDatos.Crear(StringResources.queryContrato_ListarPorRut);
                listaContrato.AgregarParametro("RutCliente", rutCliente, DbType.String);
                return listaContrato.ObtenerResultadosDeConsulta<DtoContrato>();
            }
            catch
            {
                throw;
            }
        }


        // Metodo para listar los contratos por numero de poliza
        public List<DtoContrato> ObtenerListaContratosPorNumeroDePoliza(string poliza)
        {
            try
            {
                var listaContrato = ConsultarDatos.Crear(StringResources.queryContrato_ListarPorNumeroDePoliza);
                listaContrato.AgregarParametro("poliza", poliza, DbType.String);
                return listaContrato.ObtenerResultadosDeConsulta<DtoContrato>();
            }
            catch
            {
                throw;
            }
        }


        // Metodo para listar el contrato de un cliente con el numero de contrato especificado y que este vigente.
        public List<DtoContrato> VerificarVigenciaDeContratoDeCliente(string rutCliente, string idPlan)
        {
            try
            {
                var listaContrato = ConsultarDatos.Crear(StringResources.queryContrato_VerificarVigenciaDeContrato);
                listaContrato.AgregarParametro("rutCliente", rutCliente, DbType.String);
                listaContrato.AgregarParametro("idPlan", idPlan, DbType.String);
                return listaContrato.ObtenerResultadosDeConsulta<DtoContrato>();
            }
            catch
            {
                throw;
            }
        }


    }
}
