using System;
using BeLife.Aplicacion.Idiomas.Localizacion;
using BeLife.Vista.Controles.MsgBox;
using System.Text.RegularExpressions;
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
    public partial class DatosViviendaMetroForm : MetroForm
    {

        // Propiedades
        public Vivienda Vivienda { get; set; }

        public DatosViviendaMetroForm(MetroThemeStyle myStyle)
        {
            InitializeComponent();
            this.formularioMetroStyleManager.Theme = myStyle;
            this.StyleManager = this.formularioMetroStyleManager; 
        }

        private void DatosViviendaMetroForm_Load(object sender, EventArgs e)
        {
            CmdCargarComboRegion myCommand = CmdCargarComboRegion.crear(this, this.regionMetroComboBox);
            myCommand.Ejecutar();
            this.CargarComunas(0);
            if (this.Vivienda != null)
            {
                this.codigoPostalMetroTextBox.Text = this.Vivienda.CodigoPostal.ToString();
                this.anoMetroTextBox.Text = this.Vivienda.AnoVivienda.ToString();
                this.direccionMetroTextBox.Text = this.Vivienda.Direccion;
                this.regionMetroComboBox.Text = this.Vivienda.Region;
                this.comunaMetroComboBox.Text = this.Vivienda.Comuna;
                this.valorViviendaMetroTextBox.Text = this.Vivienda.ValorVivienda.ToString();
                this.valorContenidoMetroTextBox.Text = this.Vivienda.ValorContenido.ToString();
            } else
            {
                this.codigoPostalMetroTextBox.Text = string.Empty;
                this.anoMetroTextBox.Text = string.Empty;
                this.direccionMetroTextBox.Text = string.Empty;
                this.regionMetroComboBox.SelectedIndex = 0;
                //this.comunaMetroComboBox.SelectedIndex = 0;
                this.valorViviendaMetroTextBox.Text = string.Empty;
                this.valorContenidoMetroTextBox.Text = string.Empty;
            }
            this.codigoPostalMetroTextBox.Focus();
        }

        private void aceptarMetroButton_Click(object sender, EventArgs e)
        {
            if (!ValidarControles()) return;
            this.Vivienda.CodigoPostal = int.Parse(this.codigoPostalMetroTextBox.Text); 
            this.Vivienda.AnoVivienda = int.Parse(this.anoMetroTextBox.Text);
            this.Vivienda.Direccion = this.direccionMetroTextBox.Text;
            this.Vivienda.IdRegion = int.Parse(this.regionMetroComboBox.SelectedValue.ToString());
            this.Vivienda.Region = this.regionMetroComboBox.Text;
            this.Vivienda.IdComuna = int.Parse(this.comunaMetroComboBox.SelectedValue.ToString());
            this.Vivienda.Comuna = this.comunaMetroComboBox.Text;
            this.Vivienda.ValorVivienda = double.Parse(this.valorViviendaMetroTextBox.Text);
            this.Vivienda.ValorContenido = (string.IsNullOrEmpty(this.valorContenidoMetroTextBox.Text)?0: double.Parse(this.valorContenidoMetroTextBox.Text));
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelarMetroButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void regionMetroComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idMarca = int.Parse(this.regionMetroComboBox.SelectedValue.ToString());
                this.CargarComunas(idMarca);
            }
            catch { }
        }


        private void CargarComunas(int idRegion)
        {
            CmdCargarComboComuna myCommand = CmdCargarComboComuna.Crear(this, this.comunaMetroComboBox, idRegion);
            myCommand.Ejecutar();
        }


        private bool ValidarControles()
        {
            var myCommand = CmdValidarEntradas.crear(this);
            myCommand.ValidarVacio(this.codigoPostalMetroTextBox, "código postal");
            if (!myCommand.FalloValidacion) myCommand.ValidarCodigoPostal(this.codigoPostalMetroTextBox);
                if (!myCommand.FalloValidacion) myCommand.ValidarVacio(this.anoMetroTextBox, "año");
            if (!myCommand.FalloValidacion) myCommand.ValidarAntiguedad(this.anoMetroTextBox, 1910, DateTime.Now.Year);
                if (!myCommand.FalloValidacion) myCommand.ValidarVacio(this.direccionMetroTextBox, "dirección");
            if (!myCommand.FalloValidacion) myCommand.ValidarVacio(this.valorViviendaMetroTextBox, "valor vivienda");
            if (!myCommand.FalloValidacion) myCommand.ValidarSeleccionComboBox(this.regionMetroComboBox, "región");
            if (!myCommand.FalloValidacion) myCommand.ValidarSeleccionComboBox(this.comunaMetroComboBox, "comuna");
            return !myCommand.FalloValidacion;
        }

        private void codigoPostalMetroTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int valor= int.Parse(this.codigoPostalMetroTextBox.Text);
                e.Cancel = false;
            } catch
            {
                MsgBox.Show(this,string.Format(  StringResources.MensajeValidacion_CampoSoloNumeros, "código postal"), StringResources.TituloMensajes_Error, MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                e.Cancel = true;
            } 
        }

        private void anoMetroTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int valor = int.Parse(this.anoMetroTextBox.Text);
                e.Cancel = false;
            } catch
            {
                MsgBox.Show(this, string.Format(StringResources.MensajeValidacion_CampoSoloNumeros, "año"), StringResources.TituloMensajes_Error, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
        }

        private void valorViviendaMetroTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                double valor = double.Parse(this.valorViviendaMetroTextBox.Text);
                e.Cancel = false;
            } catch
            {
                MsgBox.Show(this, string.Format(StringResources.MensajeValidacion_CampoSoloNumeros, "valor vivienda"), StringResources.TituloMensajes_Error, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
        }

        private void valorContenidoMetroTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(this.valorContenidoMetroTextBox.Text))
            {
                e.Cancel = false;
                return;
            }
            try
            {
                double valor = double.Parse(this.valorContenidoMetroTextBox.Text);
                e.Cancel = false;
            }
            catch
            {
                MsgBox.Show(this, string.Format(StringResources.MensajeValidacion_CampoSoloNumeros, "valor contenido"), StringResources.TituloMensajes_Error, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
        }


    }
}
