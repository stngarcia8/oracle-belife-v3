using System;

namespace BeLife.Dominio.Clases
{
    public    class PrimaFactory
    {

        private PrimaFactory() { }


        public static IPrima CrearPrimaSeguroDEVida(double valor, DateTime fecha, string sexo, string estadoCivil)
        {
            return new PrimaSeguroVida(valor, fecha, sexo, estadoCivil);
        }


        public static IPrima CrearPrimaSeguroVehiculo(double valor, DateTime fecha, string sexo, int anoVehiculo)
        {
            return new PrimaVehiculo(valor, fecha, sexo, anoVehiculo);
        }


        public static IPrima CrearPrimaSeguroVivienda(double valor, int antiguedad, int region, double valorVivienda, double valorContenido)
        {
            return new PrimaVivienda(valor, antiguedad, region, valorVivienda, valorContenido);
        }

    }
}
