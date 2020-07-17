using System;
using BeLife.Dominio.Clases;
using BeLife.Dominio.Enumeraciones;
using BeLife.Aplicacion.Idiomas.Localizacion;
using System.Collections.Generic;
using System.Linq;
using BeLife.Negocio.DAO;
using BeLife.Dominio.Dto;

namespace BeLife.Negocio.Comandos
{
    public class CmdBuscarContrato : CmdBuscar, IComando
    {

        private DtoContrato DtoContrato;
        public Contrato Contrato { get; set; }
        // Constructor.
        private CmdBuscarContrato(string nroContrato)
            : base(nroContrato)
        {
            DtoContrato = null;
            this.Contrato = null;
        }


        // Metodo creador del comando.
        public static CmdBuscarContrato Crear(string nroContrato)
        {
            return new CmdBuscarContrato(nroContrato);
        }


        // Metodo que ejecuta el comando.
        public void Ejecutar()
        {
            this.fueEncontrado = this.ObtenerDatos();
        }


        // Metodo que busca la informacion del contrato.
        protected override bool ObtenerDatos()
        {
            try
            {
                IDaoContrato myDao = DaoContrato.Crear();
                List<DtoContrato> myList = myDao.ObtenerListaContratosPorNumeroDeContrato(this.textoQueBuscar);
                this.DtoContrato = myList.FirstOrDefault<DtoContrato>();
                if (this.DtoContrato != null) this.CrearContrato();
                this.MensajeBusqueda = (this.DtoContrato != null ?
                    string.Format(StringResources.BuscarContrato_Existente, DtoContrato.Numero) :
                    StringResources.BuscarContrato_NoExiste);
                return (this.DtoContrato != null ? true : false);
            }
            catch (Exception ex)
            {
                this.MarcarError(ex);
                return false;
            }
        }


        private void CrearContrato()
        {
            this.Contrato = Contrato.CrearContrato(this.DtoContrato.Numero);
            this.BuscarCliente();
            this.Contrato.IdTipoContrato = this.DtoContrato.IdTipoContrato;
            this.Contrato.TipoDeContrato = this.DtoContrato.TipoContrato;
            this.Contrato.Plan.IdPlan = this.DtoContrato.IdPlan;
            this.Contrato.Plan.Nombre = this.DtoContrato.Nombre_plan;
            this.Contrato.Plan.PolizaActual = this.DtoContrato.Poliza;
            this.Contrato.Plan.PrimaBase = this.DtoContrato.Prima_base;
            if (this.Contrato.IdTipoContrato.Equals(20))
            {
                this.Contrato.AsignarPrima(TipoSeguro.Vida);
            }
                if (this.Contrato.IdTipoContrato.Equals(20))
            {
                var myDao = DaoVehiculo.CrearDao();
                List<Vehiculo> myVehiculoList = myDao.ObtenerVehiculoPorNroContrato(this.DtoContrato.Numero.ToString());
                this.Contrato.Vehiculo = myVehiculoList.FirstOrDefault<Vehiculo>();
                this.Contrato.AsignarPrima(TipoSeguro.Vehiculo);
            }
            if (this.Contrato.IdTipoContrato.Equals(30))
            {
                DaoVivienda myDao = DaoVivienda.CrearDao();
                List<Vivienda> myViviendaList = myDao.ObtenerViviendaPorNroContrato(this.DtoContrato.Numero.ToString());
                this.Contrato.Vivienda= myViviendaList.FirstOrDefault<Vivienda>();
                this.Contrato.AsignarPrima(TipoSeguro.Vivienda);
            }
            this.Contrato.DetalleContrato.FechaInicioContrato = DateTime.Parse(this.DtoContrato.Inicio_contrato);
            this.Contrato.DetalleContrato.FechaInicioDeVigencia = DateTime.Parse(this.DtoContrato.Inicio_vigencia);
            this.Contrato.DetalleContrato.FechaTerminoContrato = DateTime.Parse(this.DtoContrato.Termino_contrato);
            this.Contrato.DetalleContrato.FechaTerminoDeVigencia = DateTime.Parse(this.DtoContrato.Termino_vigencia);
            this.Contrato.DetalleContrato.DeclaracionDeSalud = (this.DtoContrato.Declaracion_salud.ToString().ToLower().Equals("no") ? 0 : 1);
            this.Contrato.DetalleContrato.VigenciaContrato = (this.DtoContrato.Vigente.ToString().ToLower().Equals("no") ? 0 : 1);
            this.Contrato.DetalleContrato.Observaciones = this.DtoContrato.Observaciones;
        }


        private void BuscarCliente()
        {
            CmdBuscarCliente myCommand = CmdBuscarCliente.Crear(this.DtoContrato.Rut);
            myCommand.Ejecutar();
            if (myCommand.fueEncontrado)
            {
                this.Contrato.Cliente.Rut = myCommand.MyCliente.Rut;
                this.Contrato.Cliente.Nombre = myCommand.MyCliente.Nombre;
                this.Contrato.Cliente.Apellido = myCommand.MyCliente.Apellido;
                this.Contrato.Cliente.Fecha = myCommand.MyCliente.Fecha;
                this.Contrato.Cliente.IdSexo = myCommand.MyCliente.IdSexo;
                this.Contrato.Cliente.Sexo = myCommand.MyCliente.Sexo;
                this.Contrato.Cliente.IdEstado = myCommand.MyCliente.IdEstado;
                this.Contrato.Cliente.EstadoCivil = myCommand.MyCliente.EstadoCivil;
            }
        }








    }
}
