using System;

namespace BeLife.Dominio.Clases
{
    public class DetalleContrato
    {

        public DateTime FechaInicioContrato { get; set; }
        public DateTime FechaTerminoContrato { get; set; }
        public DateTime FechaInicioDeVigencia { get; set; }
        public DateTime FechaTerminoDeVigencia { get; set; }
        public int VigenciaContrato { get; set; }
        public int DeclaracionDeSalud { get; set; }
        public string Observaciones { get; set; }


        private DetalleContrato()
        {
            this.AsignaFechaContrato(DateTime.Today);
            this.VigenciaContrato = 0;
            this.DeclaracionDeSalud = 0;
            this.Observaciones = string.Empty;
        }


        public static DetalleContrato CrearDetalleDeContrato()
        {
            return new DetalleContrato();
        }


        public void AsignaFechaContrato(DateTime unaFechaDeContrato)
        {
            this.FechaInicioContrato = unaFechaDeContrato;
            this.FechaTerminoContrato = unaFechaDeContrato.AddYears(1);
            this.FechaInicioDeVigencia = unaFechaDeContrato;
            this.FechaTerminoDeVigencia = unaFechaDeContrato.AddYears(1); ;
        }





    }
}
