using System.Collections.Generic;
using BeLife.Negocio.Consultas;
using BeLife.Datos.ConsultarDatos;
using BeLife.Dominio.Dto;

namespace BeLife.Negocio.DAO
{
    public class DaoEstadoCivil : IDaoEstadoCivil
    {
        // Constructor
        private DaoEstadoCivil()
        { }


        // Metodo de construccion.
        public static DaoEstadoCivil crear()
        {
            return new DaoEstadoCivil();
        }


        // Metodo para listar estado civil.
        public List<DtoEstadoCivil> ObtenerListaEstadoCivil()
        {
            try
            {
                var listaEstadoCivil = ConsultarDatos.Crear(StringResources.queryEstadoCivil_ListarTodo);
                return listaEstadoCivil.ObtenerResultadosDeConsulta<DtoEstadoCivil>();
            }
            catch
            {
                throw;
            }
        }


    }
}
