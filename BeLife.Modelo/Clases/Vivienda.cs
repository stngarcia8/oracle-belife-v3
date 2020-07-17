using System;
using BeLife.Dominio.Enumeraciones;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLife.Dominio.Clases
{
public     class Vivienda 
    {

        public int CodigoPostal { get; set; }
        public int AnoVivienda { get; set; }
        public string Direccion { get; set; }
        public int IdRegion { get; set; }
        public string Region { get; set; }
        public int IdComuna { get; set; }
        public string Comuna { get; set; }
        public double ValorVivienda { get; set; }
        public double ValorContenido { get; set; }


        // Constructor.
        public Vivienda() 
        {
            this.CodigoPostal = 0;
            this.AnoVivienda = 0;
            this.Direccion = string.Empty;
            this.IdRegion = 0;
            this.Region = string.Empty;
            this.IdComuna = 0;
            this.Comuna = string.Empty;
            this.ValorVivienda = 0;
            this.ValorContenido = 0;
        }

    }
}
