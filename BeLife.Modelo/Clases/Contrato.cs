using System;
using BeLife.Aplicacion.Idiomas.Localizacion;
using BeLife.Dominio.Dto;
using BeLife.Dominio.Enumeraciones;

namespace BeLife.Dominio.Clases
{
    public class Contrato 
    {

        // Propiedades.
        public string NumeroContrato { get; set; }
        public DtoCliente Cliente { get; set; }
        public int IdTipoContrato { get; set; }
        public string TipoDeContrato { get; set; }
        public DtoPlan Plan { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public Vivienda Vivienda { get; set; }
        public IPrima Prima { get; set; }
        public DetalleContrato DetalleContrato { get; set; }


        // Constructor.
        public Contrato()
        {
            this.InicializarContrato(this.GeneraNumeroDeContrato());
        }


        private Contrato(string unNumeroDeContrato)
        {
            this.InicializarContrato(unNumeroDeContrato);
        }


        private void InicializarContrato(string unNumeroDeContrato)
        {
            this.NumeroContrato = unNumeroDeContrato;
            InicializarCliente();
            InicializarPlan();
            this.Vehiculo = new Vehiculo();
            this.Vivienda = new Vivienda();
            this.Prima = PrimaFactory.CrearPrimaSeguroDEVida(0, this.Cliente.Fecha, string.Empty, string.Empty);
            this.DetalleContrato = DetalleContrato.CrearDetalleDeContrato();
        }


        private void InicializarCliente()
        {
            this.Cliente = new DtoCliente();
            this.Cliente.Rut = string.Empty;
            this.Cliente.Nombre = string.Empty;
            this.Cliente.Apellido = string.Empty;
            this.Cliente.Fecha = DateTime.Today;
            this.Cliente.IdEstado = 0;
            this.Cliente.EstadoCivil = string.Empty;
            this.Cliente.IdSexo = 0;
            this.Cliente.Sexo = string.Empty;
        }


        private void InicializarPlan()
        {
            this.Plan = new DtoPlan();
            this.IdTipoContrato = 0;
            this.TipoDeContrato = StringResources.ItemInicial_TipoPlan_Correcto;
            this.Plan.IdPlan = "0";
            this.Plan.Nombre = StringResources.ItemInicial_Plan_Correcto;
            this.Plan.PolizaActual = string.Empty;
            this.Plan.PrimaBase = 0;
        }


        // Metodo constructor del objeto.
        public static Contrato CrearContrato()
        {
            return new Contrato();
        }


        public static Contrato CrearContrato(string unNumeroDeContrato)
        {
            return new Contrato(unNumeroDeContrato);
        }


        private string GeneraNumeroDeContrato()
        {
            DateTime fecha = DateTime.Now;
            string year = fecha.Year.ToString();
            string month = fecha.Month.ToString().PadLeft(2, '0');
            string day = fecha.Day.ToString().PadLeft(2,'0');
            string hour = fecha.Hour.ToString().PadLeft(2, '0');
            string minute = fecha.Minute.ToString().PadLeft(2, '0'); ;
            string seconds = fecha.Second.ToString().PadLeft(2, '0');
            return (year + month + day + hour + minute + seconds);
        }


        public void AsignarPrima(TipoSeguro mySeguro)
        {
            if (mySeguro.Equals(TipoSeguro.Ninguno)) this.NingunSeguro();
            if (mySeguro.Equals(TipoSeguro.Vida)) this.SeguroDeVida();
            if (mySeguro.Equals(TipoSeguro.Vehiculo)) this.SeguroVehiculo();
            if (mySeguro.Equals(TipoSeguro.Vivienda)) this.SeguroVivienda();
        }


        private void NingunSeguro()
        {
            this.Prima = PrimaFactory.CrearPrimaSeguroDEVida(0, DateTime.Today, string.Empty, string.Empty);
        }


        private void SeguroDeVida()
        {
            this.Prima = PrimaFactory.CrearPrimaSeguroDEVida(this.Plan.PrimaBase, this.Cliente.Fecha, this.Cliente.Sexo, this.Cliente.EstadoCivil);
        }


        private void SeguroVehiculo()
        {
            this.Prima = PrimaFactory.CrearPrimaSeguroVehiculo(this.Plan.PrimaBase, this.Cliente.Fecha, this.Cliente.Sexo, this.Vehiculo.AnoVehiculo);
        }


        private void SeguroVivienda()
        {
            this.Prima = PrimaFactory.CrearPrimaSeguroVivienda(this.Plan.PrimaBase, this.Vivienda.AnoVivienda, this.Vivienda.IdRegion, this.Vivienda.ValorVivienda, this.Vivienda.ValorContenido);
        }


        public void LimpiarCliente()
        {
            this.InicializarCliente();
        }










    }
}
