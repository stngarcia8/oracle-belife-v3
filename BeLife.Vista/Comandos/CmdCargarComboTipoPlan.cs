using System;
using BeLife.Aplicacion.Idiomas.Localizacion;
using System.Collections.Generic;
using System.Windows.Forms;
using BeLife.Negocio.DAO;
using BeLife.Dominio.Dto;

namespace BeLife.Vista.Comandos
{
    public class CmdCargarComboTipoPlan : CmdCargarComboBox, IComando
    {

        // Propiedades.
        public IList<DtoTipoPlan> TipoPlanList { get; set; }

        // Constructor.
        private CmdCargarComboTipoPlan(Form myForm, ComboBox myComboBox)
            : base(myForm, myComboBox)
        {
            this.TipoPlanList= new List<DtoTipoPlan>();
        }


        // Metodo creador del objeto.
        public static CmdCargarComboTipoPlan crear(Form myForm, ComboBox myComboBox)
        {
            return new CmdCargarComboTipoPlan(myForm, myComboBox);
        }


        // Metodo que ejecuta el comando.
        public void Ejecutar()
        {
            this.myComboBox.BeginUpdate();
            this.ObtenerDatos();
            this.PrepararControl("DESCRIPCION", "IDTIPOCONTRATO");
        }


        // metodo que carga la lista de tipos de planes.
        protected override void ObtenerDatos()
        {
            try
            {
                var myDao = DaoPlan.Crear();
                this.TipoPlanList= myDao.ObtenerTiposDePlanes();
                this.InsertarValorInicial(false);
                this.myComboBox.DataSource = this.TipoPlanList;
            }
            catch (Exception ex)
            {
                this.InsertarValorInicial(true);
                this.MostrarMensajeDeError(ex);
            }
        }


        private void InsertarValorInicial(bool hayError)
        {
            DtoTipoPlan myDto = new DtoTipoPlan();
            myDto.IdTipoContrato= 0;
            myDto.Descripcion= (hayError ? StringResources.ItemInicial_TipoPlan_Error: StringResources.ItemInicial_TipoPlan_Correcto);
            this.TipoPlanList.Insert(0, myDto);
        }


    }
}
