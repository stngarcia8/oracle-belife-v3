using System.Collections.Generic;
using BeLife.Dominio.Dto;

namespace BeLife.Negocio.DAO
{
    public interface IDaoPlan
    {

        List<DtoPlan> ObtenerListaDePlanes();

        List<DtoPlan> ObtenerListaDePlanesPorTipo(int idTipo);

        List<DtoTipoPlan> ObtenerTiposDePlanes();

    }
}
