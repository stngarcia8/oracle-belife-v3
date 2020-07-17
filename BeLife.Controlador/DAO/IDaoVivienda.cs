using System;
using BeLife.Dominio.Clases;
using BeLife.Dominio.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLife.Negocio.DAO
{
    public interface IDaoVivienda
    {

        void Agregar(Vivienda myVivienda);

        void Quitar(Vivienda myVivienda);

        void QuitarRelacion(string nroContrato, Vivienda myVivienda);

        void AgregarRelacion(string nroContrato, Vivienda myVivienda);


        List<Vivienda> ObtenerViviendaPorNroContrato(string unNroContrato);

        List<DtoRegion> ObtenerRegiones();

        List<DtoComuna> ObtenerListaDeComunasPorRegion(int idRegion);

    }
}
