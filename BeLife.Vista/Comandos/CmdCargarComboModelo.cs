using System;
using BeLife.Aplicacion.Idiomas.Localizacion;
using System.Collections.Generic;
using System.Windows.Forms;
using BeLife.Negocio.DAO;
using BeLife.Dominio.Dto;

namespace BeLife.Vista.Comandos
{
    public class CmdCargarComboModelo: CmdCargarComboBox, IComando
    {

        // Miembros.
        private readonly int idMarca;

        // Propiedades.
        public IList<DtoModelo> ModeloList { get; set; }

        // Constructores.
        private CmdCargarComboModelo(Form myForm, ComboBox myComboBox)
            : base(myForm, myComboBox)
        {
            this.ModeloList = new List<DtoModelo>();
            this.idMarca = -1;
        }


        private CmdCargarComboModelo(Form myForm, ComboBox myComboBox, int idMarca)
    : base(myForm, myComboBox)
        {
            this.ModeloList = new List<DtoModelo>();
            this.idMarca = idMarca;
        }


        // Metodos creadores del objeto.
        public static CmdCargarComboModelo Crear(Form myForm, ComboBox myComboBox)
        {
            return new CmdCargarComboModelo(myForm, myComboBox);
        }


        public static CmdCargarComboModelo Crear(Form myForm, ComboBox myComboBox, int idMarca)
        {
            return new CmdCargarComboModelo(myForm, myComboBox, idMarca);
        }


        // Metodo que ejecuta el comando.
        public void Ejecutar()
        {
            this.myComboBox.BeginUpdate();
            this.ObtenerDatos();
            this.PrepararControl("DESCRIPCION", "IDMODELO");
        }


        // Metodo que carga la lista de modelos
        protected override void ObtenerDatos()
        {
            try
            {
                var myDao = DaoVehiculo.CrearDao();
                this.ModeloList = myDao.ObtenerListaDeModelosPorMarca(this.idMarca);
                this.InsertarValorInicial(false);
                this.myComboBox.DataSource = this.ModeloList;
            }
            catch (Exception ex)
            {
                this.ModeloList = new List<DtoModelo>();
                this.InsertarValorInicial(true);
                this.MostrarMensajeDeError(ex);
            }
        }


        private void InsertarValorInicial(bool hayError)
        {
            DtoModelo myDto = new DtoModelo();
            myDto.IdModelo= 0;
            myDto.Descripcion= (hayError ? StringResources.ItemInicial_Vehiculo_ModeloError: StringResources.ItemInicial_Vehiculo_ModeloCorrecto);
            this.ModeloList.Insert(0, myDto);
        }

    }
}
