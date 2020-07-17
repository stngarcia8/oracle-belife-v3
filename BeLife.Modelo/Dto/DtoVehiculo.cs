using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLife.Dominio.Dto
{
public    class DtoVehiculo
    {

        public string Patente { get; set; }
        public int IdMarca { get; set; }
        public string Marca { get; set; }
        public int IdModelo { get; set; }
        public string Modelo { get; set; }
        public int AnoVehiculo { get; set; }

    }
}
