using System;
using BeLife.Dominio.Enumeraciones;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLife.Dominio.Clases
{
public    class Vehiculo 
    {

        public string Patente { get; set; }
        public int IdMarca { get; set; }
        public string Marca { get; set; }
        public int IdModelo { get; set; }
        public string Modelo { get; set; }
        public int AnoVehiculo { get; set; }


        public Vehiculo() 
        {
            this.Patente = string.Empty;
            this.AnoVehiculo = 0;
            this.IdMarca = 0;
            this.Marca = string.Empty;
            this.IdModelo = 0;
            this.Modelo = string.Empty;
        }


    }
}
