using System;
using System.Text;
using BeLife.Aplicacion.Idiomas.Localizacion;

namespace BeLife.Dominio.Clases
{
    public    class PrimaVehiculo:Prima
    {


        // Miembros privados.
        private readonly double valor;
        private readonly DateTime fecha;
        private readonly string sexo;
        private int anoVehiculo;


        // Constructor.
        public PrimaVehiculo(double valor, DateTime fecha, string sexo, int anoVehiculo)
        {
            this.valor = valor;
            this.fecha = fecha;
            this.sexo = sexo.ToString().ToLower().Trim();
            this.anoVehiculo = anoVehiculo;
            this.CalcularSeguro();
        }


        private void CalcularSeguro()
        {
            double recargoEdad = this.calculaRecargoEdad();
            double recargoSexo = this.calculaRecargoSexo();
            double recargoAno = this.CalculaRecargoPorAntiguedad();
            this.Recargo = (recargoEdad + recargoSexo + recargoAno);
            this.ValorTotal = (this.valor + this.Recargo);
        }


        // Calcular recargo por fecha de nacimiento.
        private double calculaRecargoEdad()
        {
            int year = DateTime.Now.Year - this.fecha.Year;
            if (year >= 18 && year <= 25) return 1.2;
            if (year >= 26 && year <= 45) return 2.4;
            if (year > 45) return 3.2;
            return 0;
        }


        // Calcular el recargo por sexo.
        private double calculaRecargoSexo()
        {
            if (string.IsNullOrEmpty(this.sexo)) return 0;
            return (this.sexo.Equals("hombre") ? 0.8 : 0.4);
        }


        // Calcular el recargo por año del vehiculo.
        private double CalculaRecargoPorAntiguedad()
        {
            int myYear  = DateTime.Now.Year - this.anoVehiculo;
            if (myYear == 0) return 1.2;
            if (myYear>0 && myYear<=5) return 0.8;
            if (myYear > 5) return 0.4;
            return 0;
        }


        public override string ToString()
        {
            StringBuilder myBuilder = new StringBuilder();
            myBuilder.Append(StringResources.TextoPrima_Recargo);
            myBuilder.Append(StringResources.TextoPrima_Edad + this.calculaRecargoEdad().ToString() + " UF |");
            myBuilder.Append(StringResources.TextoPrima_Sexo + this.calculaRecargoSexo().ToString() + " UF |");
            myBuilder.Append(StringResources.TextoPrima_Antiguedad + this.CalculaRecargoPorAntiguedad().ToString() + " UF");
            return myBuilder.ToString();
        }





    }
}
