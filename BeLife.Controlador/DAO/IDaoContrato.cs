using System.Collections.Generic;
using BeLife.Dominio.Clases;
using BeLife.Dominio.Dto;

namespace BeLife.Negocio.DAO
{
    public interface IDaoContrato
    {

        int NuevoContrato(Contrato myContrato);

        int ActualizarContrato(Contrato myContrato);

        List<DtoContrato> ObtenerListaContratos();

        List<DtoContrato> ObtenerListaContratosPorNumeroDeContrato(string numero);

        List<DtoContrato> ObtenerListaContratosPorRut(string rutCliente);

        List<DtoContrato> ObtenerListaContratosPorNumeroDePoliza(string poliza);

        List<DtoContrato> VerificarVigenciaDeContratoDeCliente(string rutCliente, string idPlan);

    }
}
