using System;
using BeLife.Aplicacion.Idiomas.Localizacion;
using System.Collections.Generic;
using System.Windows.Forms;
using BeLife.Negocio.DAO;
using BeLife.Dominio.Dto;

namespace BeLife.Vista.Comandos
{
    public class CmdCargarComboMarcaVehiculo : CmdCargarComboBox, IComando
    {

        // Propiedades.
        public IList<DtoMarca> MarcaList { get; set; }

        // Constructor.
        private CmdCargarComboMarcaVehiculo(Form myForm, ComboBox myComboBox)
            : base(myForm, myComboBox)
        {
            this.MarcaList= new List<DtoMarca>();
        }


        // Metodo creador del objeto.
        public static CmdCargarComboMarcaVehiculo crear(Form myForm, ComboBox myComboBox)
        {
            return new CmdCargarComboMarcaVehiculo(myForm, myComboBox);
        }


        // Metodo que ejecuta el comando.
        public void Ejecutar()
        {
            this.myComboBox.BeginUpdate();
            this.ObtenerDatos();
            this.PrepararControl("DESCRIPCION", "idMarca");
        }


        // metodo que carga la lista de marcas.
        protected override void ObtenerDatos()
        {
            try
            {
                var myDao = DaoVehiculo.CrearDao();
                this.MarcaList= myDao.ObtenerMarcasDeVehiculos();
                this.InsertarValorInicial(false);
                this.myComboBox.DataSource = this.MarcaList;
            }
            catch (Exception ex)
            {
                this.InsertarValorInicial(true);
                this.MostrarMensajeDeError(ex);
            }
        }


        private void InsertarValorInicial(bool hayError)
        {
            DtoMarca myDto = new DtoMarca();
            myDto.IdMarca= 0;
            myDto.Descripcion = (hayError ? StringResources.ItemInicial_Vehiculo_MarcaError: StringResources.ItemInicial_Vehiculo_MarcaCorrecto);
            this.MarcaList.Insert(0, myDto);
        }


    }
}
