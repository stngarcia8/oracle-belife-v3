using System;
using System.Text;
using BeLife.Aplicacion.Idiomas.Localizacion;

namespace BeLife.Dominio.Clases
{
    public class PrimaVivienda : Prima
    {

        // Miembros privados.
        private readonly double valor;
        private readonly int antiguedad;
        private readonly string sexo;
        private readonly int region;
        private readonly double valorVivienda;
        private readonly double valorContenido;

        // Constructor.
        public PrimaVivienda(double valor, int antiguedad, int region, double valorVivienda, double valorContenido)
        {
            this.valor = valor;
            this.antiguedad = antiguedad;
            this.region = region;
            this.valorVivienda = valorVivienda;
            this.valorContenido = valorContenido;
            this.CalcularSeguro();
        }


        // Calcular total del seguro.
        private void CalcularSeguro()
        {
            double recargoAntiguedad = this.calculaRecargoAntiguedad();
            double recargoRegion = this.calculaRecargoRegion();
            double recargoValorVivienda = this.calculaRecargoPorValorVivienda();
            double recargoValorContenido = this.calculaRecargoPorValorContenido();
            this.Recargo = (recargoAntiguedad + recargoRegion + recargoValorVivienda + recargoValorContenido);
            this.ValorTotal = (this.valor + this.Recargo);
        }


        // Calcular recargo por antiguedad de la vivienda
        private double calculaRecargoAntiguedad()
        {
            int year = DateTime.Now.Year - this.antiguedad;
            if (year <= 5) return 1;
            if (year > 5 && year <= 10) return 0.8;
            if (year > 10 && year <= 30) return 0.4;
            if (year > 30) return 0.2;
            return 0;
        }


        // Calcular recargo por region
        private double calculaRecargoRegion()
        {
            if (this.region.Equals(0)) return 0;
            return (this.region.Equals(13) ? 3.2 : 2.8);
        }


        // Calcular recargo por valor de la vivienda.
        private double calculaRecargoPorValorVivienda()
        {
            if (this.valorVivienda.Equals(0)) return 0;
            return (this.valorVivienda * 0.03) / 100;
        }


        // Calcular recargo por valor del contenido.
        private double calculaRecargoPorValorContenido()
        {
            if (this.valorContenido.Equals(0)) return 0;
            return (this.valorContenido * 0.07) / 100;
        }


        public override string ToString()
        {
            StringBuilder myBuilder = new StringBuilder();
            myBuilder.Append(StringResources.TextoPrima_Recargo);
            myBuilder.Append(StringResources.TextoPrima_Antiguedad + this.calculaRecargoAntiguedad().ToString() + " UF |");
            myBuilder.Append(StringResources.TextoPrima_Region + this.calculaRecargoRegion().ToString() + " UF |");
            myBuilder.Append(StringResources.TextoPrima_ValorVivienda + this.calculaRecargoPorValorVivienda().ToString() + " UF");
            myBuilder.Append(StringResources.TextoPrima_ValorContenido + this.calculaRecargoPorValorContenido().ToString() + " UF");
            return myBuilder.ToString();
        }

    }
}

