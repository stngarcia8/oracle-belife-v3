using System;
using BeLife.Aplicacion.Idiomas.Localizacion;
using BeLife.Dominio.Clases;
using BeLife.Dominio.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace BeLife.Negocio.Cache
{
    public class Cache
    {

        private readonly string nombreArchivoCache;


        private Cache()
        {
            this.nombreArchivoCache = Path.Combine(Environment.CurrentDirectory, "xCache.stn");
        }


        public static Cache CrearCache()
        {
            return new Cache();
        }


        public void GrabarInformacion(Contrato myContrato)
        {
            using (TextWriter writer = new StreamWriter(this.nombreArchivoCache))
            {
                writer.WriteLine(myContrato.NumeroContrato.ToString());
                writer.WriteLine(myContrato.Cliente.Rut.ToString());
                writer.WriteLine(myContrato.Cliente.Nombre.ToString());
                writer.WriteLine(myContrato.Cliente.Apellido.ToString());
                writer.WriteLine(myContrato.Cliente.Fecha.ToShortDateString());
                writer.WriteLine(myContrato.Cliente.IdSexo.ToString());
                writer.WriteLine(myContrato.Cliente.Sexo.ToString());
                writer.WriteLine(myContrato.Cliente.IdEstado.ToString());
                writer.WriteLine(myContrato.Cliente.EstadoCivil.ToString());

                writer.WriteLine(myContrato.IdTipoContrato.ToString());
                writer.WriteLine(myContrato.TipoDeContrato.ToString());

                writer.WriteLine(myContrato.Plan.IdPlan.ToString());
                writer.WriteLine(myContrato.Plan.Nombre.ToString());
                writer.WriteLine(myContrato.Plan.PolizaActual.ToString());
                writer.WriteLine(myContrato.Plan.PrimaBase.ToString());

                writer.WriteLine(myContrato.Vehiculo.Patente.ToString());
                writer.WriteLine(myContrato.Vehiculo.AnoVehiculo.ToString());
                writer.WriteLine(myContrato.Vehiculo.IdMarca.ToString());
                writer.WriteLine(myContrato.Vehiculo.Marca.ToString());
                writer.WriteLine(myContrato.Vehiculo.IdModelo.ToString());
                writer.WriteLine(myContrato.Vehiculo.Modelo.ToString());

                writer.WriteLine(myContrato.Vivienda.CodigoPostal.ToString());
                writer.WriteLine(myContrato.Vivienda.Direccion.ToString());
                writer.WriteLine(myContrato.Vivienda.IdComuna.ToString());
                writer.WriteLine(myContrato.Vivienda.Comuna.ToString());
                writer.WriteLine(myContrato.Vivienda.IdRegion.ToString());
                writer.WriteLine(myContrato.Vivienda.Region.ToString());
                writer.WriteLine(myContrato.Vivienda.ValorVivienda.ToString());
                writer.WriteLine(myContrato.Vivienda.ValorContenido.ToString());
                writer.WriteLine(myContrato.Vivienda.AnoVivienda.ToString());

                writer.WriteLine(myContrato.DetalleContrato.FechaInicioContrato.ToShortDateString());
                writer.WriteLine(myContrato.DetalleContrato.FechaTerminoContrato.ToShortDateString());
                writer.WriteLine(myContrato.DetalleContrato.FechaInicioDeVigencia.ToShortDateString());
                writer.WriteLine(myContrato.DetalleContrato.FechaTerminoDeVigencia.ToShortDateString());
                writer.WriteLine(myContrato.DetalleContrato.VigenciaContrato.ToString());
                writer.WriteLine(myContrato.DetalleContrato.DeclaracionDeSalud.ToString());
                writer.WriteLine(myContrato.DetalleContrato.Observaciones.ToString());
            }
        }



        public Contrato CargarInformacion()
        {
            Contrato myContrato = Contrato.CrearContrato("-");
            List<string> contenido =this.ObtenerContenido();

            return myContrato;
        }


        private  List<string> ObtenerContenido()
        {
            List<string> myContenido = (from contenido in File.ReadAllLines(this.nombreArchivoCache, Encoding.GetEncoding(1252))
                                   select contenido).ToList();
            return myContenido;
        }


    }
}
