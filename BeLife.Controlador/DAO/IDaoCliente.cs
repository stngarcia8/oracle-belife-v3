using System.Collections.Generic;
using BeLife.Dominio.Clases;
using BeLife.Dominio.Dto;


namespace BeLife.Negocio.DAO
{
    public interface IDaoCliente
    {

        int NuevoCliente(Cliente myCliente);

        int ActualizarCliente(Cliente myCliente);

        int eliminarCliente(string rutCliente);

        List<DtoCliente> ObtenerListaClientes();

        List<DtoCliente> ObtenerListaClientesPorRut(string rutCliente);

        List<DtoCliente> ObtenerListaClientesPorEstadoCivil(int idEstadoCivil);

        List<DtoCliente> ObtenerListaClientesPorSexo(int idSexo);

        List<DtoContratoCliente> ObtenerListaContratossPorRut(string rutCliente);

    }
}
