using System;
using System.Text;
using BeLife.Aplicacion.Idiomas.Localizacion;

namespace BeLife.Dominio.Clases
{
    public class PrimaSeguroVida:Prima
    {

        // Miembros privados.
        private readonly double valor;
        private readonly DateTime fecha;
        private readonly string sexo;
        private readonly string estadoCivil;


        // Constructor.
        public PrimaSeguroVida(double valor, DateTime fecha, string sexo, string estadoCivil)
        {
            this.valor = valor;
            this.fecha = fecha;
            this.sexo = sexo.ToString().ToLower().Trim();
            this.estadoCivil = estadoCivil.ToString().ToLower().Trim();
            this.CalcularSeguro();
        }


        // Calcular total del seguro.
        private void CalcularSeguro()
        {
            double recargoEdad = this.calculaRecargoEdad();
            double recargoSexo = this.calculaRecargoSexo();
            double recargoEstadoCivil = this.calculaRecargoEstadoCivil();
            this.Recargo = (recargoEdad + recargoSexo + recargoEstadoCivil);
            this.ValorTotal = (this.valor + this.Recargo);
        }


        // Calcular recargo por fecha de nacimiento.
        private double calculaRecargoEdad()
        {
            int year = DateTime.Now.Year - this.fecha.Year;
            if (year >= 18 && year <= 25) return 3.6;
            if (year >= 26 && year <= 45) return 2.4;
            if (year > 45) return 6;
            return 0;
        }


        // Calcular el recargo por sexo.
        private double calculaRecargoSexo()
        {
            if (string.IsNullOrEmpty(this.sexo)) return 0;
            return (this.sexo.Equals("hombre") ? 2.4 : 1.2);
        }


        // Calcular recargo por estado civil.
        private double calculaRecargoEstadoCivil()
        {
            if (string.IsNullOrEmpty(this.estadoCivil)) return 0;
            if (this.estadoCivil.Equals("soltero")) return 4.8;
            if (this.estadoCivil.Equals("casado")) return 2.4;
            return 3.6;
        }


        public override string ToString()
        {
            StringBuilder myBuilder = new StringBuilder();
            myBuilder.Append(StringResources.TextoPrima_Recargo);
            myBuilder.Append(StringResources.TextoPrima_Edad + this.calculaRecargoEdad().ToString() + " UF |");
            myBuilder.Append(StringResources.TextoPrima_Sexo + this.calculaRecargoSexo().ToString() + " UF |");
            myBuilder.Append(StringResources.TextoPrima_EstadoCivil + this.calculaRecargoEstadoCivil().ToString() + " UF");
            return myBuilder.ToString();
        }

    }
}
