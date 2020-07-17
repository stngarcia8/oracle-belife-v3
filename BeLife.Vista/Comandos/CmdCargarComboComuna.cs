using System;
using BeLife.Aplicacion.Idiomas.Localizacion;
using System.Collections.Generic;
using System.Windows.Forms;
using BeLife.Negocio.DAO;
using BeLife.Dominio.Dto;

namespace BeLife.Vista.Comandos
{
    public class CmdCargarComboComuna : CmdCargarComboBox, IComando
    {

        // Miembros.
        private readonly int idRegion;

        // Propiedades.
        public IList<DtoComuna> ComunaList { get; set; }

        // Constructores.
        private CmdCargarComboComuna(Form myForm, ComboBox myComboBox)
            : base(myForm, myComboBox)
        {
            this.ComunaList = new List<DtoComuna>();
            this.idRegion = -1;
        }


        private CmdCargarComboComuna(Form myForm, ComboBox myComboBox, int idRegion)
    : base(myForm, myComboBox)
        {
            this.ComunaList = new List<DtoComuna>();
            this.idRegion = idRegion;
        }


        // Metodos creadores del objeto.
        public static CmdCargarComboComuna Crear(Form myForm, ComboBox myComboBox)
        {
            return new CmdCargarComboComuna(myForm, myComboBox);
        }


        public static CmdCargarComboComuna Crear(Form myForm, ComboBox myComboBox, int idRegion)
        {
            return new CmdCargarComboComuna(myForm, myComboBox, idRegion);
        }


        // Metodo que ejecuta el comando.
        public void Ejecutar()
        {
            this.myComboBox.BeginUpdate();
            this.ObtenerDatos();
            this.PrepararControl("NOMBRECOMUNA", "IDCOMUNA");
        }


        // Metodo que carga la lista de comunas
        protected override void ObtenerDatos()
        {
            try
            {
                var myDao = DaoVivienda.CrearDao();
                this.ComunaList = myDao.ObtenerListaDeComunasPorRegion(this.idRegion);
                this.InsertarValorInicial(false);
                this.myComboBox.DataSource = this.ComunaList;
            }
            catch (Exception ex)
            {
                this.ComunaList = new List<DtoComuna>();
                this.InsertarValorInicial(true);
                this.MostrarMensajeDeError(ex);
            }
        }


        private void InsertarValorInicial(bool hayError)
        {
            DtoComuna myDto = new DtoComuna();
            myDto.IdComuna= 0;
            myDto.NombreComuna= (hayError ? StringResources.ItemInicial_ComunaError: StringResources.ItemInicial_ComunaCorrecta);
            this.ComunaList.Insert(0, myDto);
        }

    }
}
