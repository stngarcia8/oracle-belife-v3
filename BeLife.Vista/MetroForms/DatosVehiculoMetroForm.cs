using System;
using BeLife.Vista.Controles.MsgBox;
using BeLife.Aplicacion.Idiomas.Localizacion;
    using BeLife.Vista.Comandos;
using BeLife.Dominio.Clases;
using MetroFramework;
using MetroFramework.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeLife.Vista.MetroForms
{
    public partial class DatosVehiculoMetroForm : MetroForm
    {

        // Propiedades.
        public Vehiculo Vehiculo { get; set; }


        public DatosVehiculoMetroForm(MetroThemeStyle myStyle)
        {
            InitializeComponent();
            this.formularioMetroStyleManager.Theme = myStyle;
            this.StyleManager = formularioMetroStyleManager;
        }

        private void DatosVehiculoMetroForm_Load(object sender, EventArgs e)
        {
            CmdCargarComboMarcaVehiculo myCommand = CmdCargarComboMarcaVehiculo.crear(this, this.marcaMetroComboBox);
            myCommand.Ejecutar();
            this.CargarModelos(0);
            if (!string.IsNullOrEmpty(this.Vehiculo.Patente))
            {
                this.patenteMetroTextBox.Text = this.Vehiculo.Patente;
                this.anoMetroTextBox.Text = this.Vehiculo.AnoVehiculo.ToString();
                this.marcaMetroComboBox.Text = this.Vehiculo.Marca;
                this.modeloMetroComboBox.Text = this.Vehiculo.Modelo;
            }
            else
            {
                this.patenteMetroTextBox.Text= string.Empty;
                this.anoMetroTextBox.Text = string.Empty;
                this.marcaMetroComboBox.SelectedIndex = 0;
            }
            this.patenteMetroTextBox.Focus();
        }

        private void aceptarMetroButton_Click(object sender, EventArgs e)
        {
            if (!ValidarControles()) return;
            this.Vehiculo.Patente = this.patenteMetroTextBox.Text;
            this.Vehiculo.IdMarca = int.Parse(this.marcaMetroComboBox.SelectedValue.ToString());
            this.Vehiculo.Marca = this.marcaMetroComboBox.Text;
            this.Vehiculo.IdModelo = int.Parse(this.modeloMetroComboBox.SelectedValue.ToString());
            this.Vehiculo.Modelo = this.modeloMetroComboBox.Text;
            this.Vehiculo.AnoVehiculo = int.Parse(this.anoMetroTextBox.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelarMetroButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void marcaMetroComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idMarca = int.Parse(this.marcaMetroComboBox.SelectedValue.ToString());
                this.CargarModelos(idMarca);
            }
            catch {  }
        }


        private void CargarModelos(int idMarca)
        {
            CmdCargarComboModelo myCommand = CmdCargarComboModelo.Crear(this, this.modeloMetroComboBox,idMarca);
            myCommand.Ejecutar();
        }


        private bool ValidarControles()
        {
            var myCommand = CmdValidarEntradas.crear(this);
            myCommand.ValidarVacio(this.patenteMetroTextBox, "patente");
            if (!myCommand.FalloValidacion) myCommand.ValidarVacio(this.anoMetroTextBox, "año");
            if (!myCommand.FalloValidacion) myCommand.ValidarSeleccionComboBox(this.marcaMetroComboBox, "marca");
            if (!myCommand.FalloValidacion) myCommand.ValidarSeleccionComboBox(this.modeloMetroComboBox, "modelo");
            return !myCommand.FalloValidacion;
        }

        private void anoMetroTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int valor = int.Parse(this.anoMetroTextBox.Text);
                e.Cancel = false;
            }
            catch
            {
                MsgBox.Show(this, string.Format(StringResources.MensajeValidacion_CampoSoloNumeros, "año"), StringResources.TituloMensajes_Error, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
        }

        private void patenteMetroTextBox_Validating(object sender, CancelEventArgs e)
        {
            CmdValidarEntradas myCommand = CmdValidarEntradas.crear(this);
            myCommand.ValidarPatente(this.patenteMetroTextBox);
            e.Cancel = myCommand.FalloValidacion;
        }
    }
}
