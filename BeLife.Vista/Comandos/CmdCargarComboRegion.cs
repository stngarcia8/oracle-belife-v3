using System;
using BeLife.Aplicacion.Idiomas.Localizacion;
using System.Collections.Generic;
using System.Windows.Forms;
using BeLife.Negocio.DAO;
using BeLife.Dominio.Dto;

namespace BeLife.Vista.Comandos
{
    public class CmdCargarComboRegion : CmdCargarComboBox, IComando
    {

        // Propiedades.
        public IList<DtoRegion> RegionList { get; set; }

        // Constructor.
        private CmdCargarComboRegion(Form myForm, ComboBox myComboBox)
            : base(myForm, myComboBox)
        {
            this.RegionList = new List<DtoRegion>();
        }


        // Metodo creador del objeto.
        public static CmdCargarComboRegion crear(Form myForm, ComboBox myComboBox)
        {
            return new CmdCargarComboRegion(myForm, myComboBox);
        }


        // Metodo que ejecuta el comando.
        public void Ejecutar()
        {
            this.myComboBox.BeginUpdate();
            this.ObtenerDatos();
            this.PrepararControl("NOMBREREGION", "IDREGION");
        }


        // metodo que carga la lista de marcas.
        protected override void ObtenerDatos()
        {
            try
            {
                var myDao = DaoVivienda.CrearDao();
                this.RegionList = myDao.ObtenerRegiones();
                this.InsertarValorInicial(false);
                this.myComboBox.DataSource = this.RegionList;
            }
            catch (Exception ex)
            {
                this.InsertarValorInicial(true);
                this.MostrarMensajeDeError(ex);
            }
        }


        private void InsertarValorInicial(bool hayError)
        {
            DtoRegion myDto = new DtoRegion();
            myDto.IdRegion= 0;
            myDto.NombreRegion= (hayError ? StringResources.ItemInicial_RegionError: StringResources.ItemInicial_RegionCorrecta);
            this.RegionList.Insert(0, myDto);
        }


    }
}
