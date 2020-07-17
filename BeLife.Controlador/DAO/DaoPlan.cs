using System.Collections.Generic;
using BeLife.Negocio.Consultas;
using BeLife.Datos.ConsultarDatos;
using BeLife.Dominio.Dto;

namespace BeLife.Negocio.DAO
{
    public class DaoPlan : IDaoPlan
    {

        // Constructor
        private DaoPlan()
        { }


        // Metodo de construccion.
        public static DaoPlan Crear()
        {
            return new DaoPlan();
        }


        // Metodo para listar los planes.
        public List<DtoPlan> ObtenerListaDePlanes()
        {
            try
            {
                var listaPlan = ConsultarDatos.Crear(StringResources.queryPlan_ListarTodo);
                return listaPlan.ObtenerResultadosDeConsulta<DtoPlan>();
            }
            catch
            {
                throw;
            }
        }


        // Metodo para listar los planes por tipo de plan.
        public List<DtoPlan> ObtenerListaDePlanesPorTipo(int idTipo)
        {
            try
            {
                var listaPlan = ConsultarDatos.Crear(StringResources.queryPlan_ListarPorTipoPlan);
                listaPlan.AgregarParametro(":idTipo", idTipo, System.Data.DbType.Int32);
                return listaPlan.ObtenerResultadosDeConsulta<DtoPlan>();
            }
            catch
            {
                throw;
            }
        }


        // Metodo para listar los tipos de planes.
        public List<DtoTipoPlan> ObtenerTiposDePlanes()
        {
            try
            {
                var listaPlan = ConsultarDatos.Crear(StringResources.queryPlan_ListarTiposDePlan);
                return listaPlan.ObtenerResultadosDeConsulta<DtoTipoPlan>();
            }
            catch
            {
                throw;
            }
        }

    }
}
