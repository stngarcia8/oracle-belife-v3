using System;

namespace BeLife.Dominio.Clases
{
    public class Cliente
    {

        // Propiedades.
        public String Rut { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime Nacimiento { get; set; }
        public int IdSexo { get; set; }
        public int IdEstadoCivil { get; set; }


        // Constructor.
        private Cliente()
        {
            this.Rut = string.Empty;
            this.Nombre = string.Empty;
            this.Apellido = string.Empty;
            this.Nacimiento = DateTime.Today.AddYears(-18);
            this.IdSexo = 0;
            this.IdEstadoCivil = 0;
        }


        // Metodo creador del objeto.
        public static Cliente CrearCliente()
        {
            return new Cliente();
        }




    }
}
