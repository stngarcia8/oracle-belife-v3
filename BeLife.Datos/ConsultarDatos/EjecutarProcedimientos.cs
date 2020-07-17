using System.Data;
using BeLife.Datos.Persistencia;

namespace BeLife.Datos.ConsultarDatos
{
    public class EjecutarProcedimientos : IEjecutarConsultas
    {

        readonly IConectarOracle coneccion;
        readonly IConsultasDeAccion consulta;


        //Constructor.
        private EjecutarProcedimientos(string nombreProcedimiento)
        {
            coneccion = ConectarOracle.crear();
            consulta = coneccion.CrearConsultasSP(nombreProcedimiento);
        }


        //Metodo de creacion de objeto.
        public static EjecutarProcedimientos Crear(string nombreProcedimiento)
        {
            return new EjecutarProcedimientos(nombreProcedimiento);
        }


        public void AgregarParametro(string nombreParametro, object valorParametro, DbType tipoParametro)
        {
            consulta.AgregarParametro(nombreParametro, valorParametro, tipoParametro);
        }


        public int Ejecutar()
        {
            try
            {
                int filasAfectadas = consulta.EjecutarAccion();
                return filasAfectadas;
            }
            catch
            {
                throw;
            }
        }


        public void CerrarConsulta()
        {
            coneccion.Commit();
            coneccion.cerrarConeccion();
        }


    }
}
