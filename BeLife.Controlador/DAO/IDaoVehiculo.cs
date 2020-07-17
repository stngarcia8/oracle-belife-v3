using System;
using BeLife.Dominio.Dto;
using BeLife.Dominio.Clases;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLife.Negocio.DAO
{
public interface    IDaoVehiculo
    {

        void Agregar(Vehiculo myVehiculo);

        void Quitar(Vehiculo myVehiculo);

        void QuitarRelacion(string nroContrato, Vehiculo myVehiculo);

        void AgregarRelacion(string nroContrato, Vehiculo myVehiculo);



        List<Vehiculo> ObtenerVehiculoPorNroContrato(string unNroContrato);

        List<DtoModelo> ObtenerListaDeModelosPorMarca(int idMarca);

        List<DtoMarca> ObtenerMarcasDeVehiculos();

    }
}
