using System;
using BeLife.Aplicacion.Idiomas.Localizacion;
using System.Collections.Generic;
using System.Windows.Forms;
using BeLife.Negocio.DAO;
using BeLife.Dominio.Dto;

namespace BeLife.Vista.Comandos
{
    public class CmdCargarComboPlan : CmdCargarComboBox, IComando
    {

        // Miembros.
        private readonly int tipoPlan;

        // Propiedades.
        public IList<DtoPlan> PlanList { get; set; }

        // Constructores.
        private CmdCargarComboPlan(Form myForm, ComboBox myComboBox)
            : base(myForm, myComboBox)
        {
            this.PlanList = new List<DtoPlan>();
            this.tipoPlan = -1;
        }


        private CmdCargarComboPlan(Form myForm, ComboBox myComboBox, int tipoPlan)
    : base(myForm, myComboBox)
        {
            this.PlanList = new List<DtoPlan>();
            this.tipoPlan = tipoPlan;
        }


        // Metodos creadores del objeto.
        public static CmdCargarComboPlan Crear(Form myForm, ComboBox myComboBox)
        {
            return new CmdCargarComboPlan(myForm, myComboBox);
        }


        public static CmdCargarComboPlan Crear(Form myForm, ComboBox myComboBox, int tipoPlan)
        {
            return new CmdCargarComboPlan(myForm, myComboBox, tipoPlan);
        }


        // Metodo que ejecuta el comando.
        public void Ejecutar()
        {
            this.myComboBox.BeginUpdate();
                this.ObtenerDatos();
            this.PrepararControl("Nombre", "IDPlan");
        }


        // Metodo que carga la lista de planes.
        protected override void ObtenerDatos()
        {
            try
            {
                IDaoPlan myDao = DaoPlan.Crear();
                this.PlanList = (this.tipoPlan.Equals(-1) ? myDao.ObtenerListaDePlanes() : myDao.ObtenerListaDePlanesPorTipo(this.tipoPlan));
                this.InsertarValorInicial(false);
                this.myComboBox.DataSource = this.PlanList;
            }
            catch (Exception ex)
            {
                this.PlanList = new List<DtoPlan>();
                this.InsertarValorInicial(true);
                this.MostrarMensajeDeError(ex);
            }
        }


        private void InsertarValorInicial(bool hayError)
        {
            DtoPlan myDto = new DtoPlan();
            myDto.IdPlan = "0";
            myDto.Nombre = (hayError?StringResources.ItemInicial_Plan_Error:StringResources.ItemInicial_Plan_Correcto);
            myDto.PolizaActual = string.Empty;
            myDto.PrimaBase = 0;
            this.PlanList.Insert(0, myDto);
        }

    }
}
