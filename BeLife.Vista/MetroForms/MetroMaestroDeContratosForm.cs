using System;
using System.IO;
using System.Xml;
using BeLife.Negocio.Cache;
using BeLife.Dominio.Enumeraciones;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BeLife.Aplicacion.Configuracion;
using BeLife.Aplicacion.Idiomas.Localizacion;
using BeLife.Negocio.Comandos;
using BeLife.Negocio.Enumeraciones;
using BeLife.Dominio.Clases;
using BeLife.Dominio.Dto;
using BeLife.Vista.Comandos;
using BeLife.Vista.Controles.MsgBox;
using MetroFramework;
using MetroFramework.Forms;

namespace BeLife.Vista.MetroForms
{
    public partial class MetroMaestroDeContratosForm : MetroForm
    {

        // Miembros y propiedades.
        #region "Miembros y propiedades."

        private TipoGrabacion accionGrabar;
        private TipoSeguro myTipoSeguro;
        private IList<DtoPlan> myPlanList;
        private Contrato myContrato;

        public string NumeroContratoExterno { get; set; }
        public string RutClienteExterno { get; set; }
        public bool IsChildForm { get; set; }
        public bool HayCambios { get; set; }
        public EstadoFormulario EstadoForm { get; set; }
        public TipoGrabacion AccionGrabar { get { return this.accionGrabar; } set { this.accionGrabar = value; } }

        #endregion



        // Manejo del formulario.
        #region "Manejo del formulario."


        public MetroMaestroDeContratosForm(MetroThemeStyle myStyle)
        {
            InitializeComponent();
            this.formularioMetroStyleManager.Theme = myStyle;
            this.StyleManager = formularioMetroStyleManager;
            Configurador myConfigurador = Configurador.Crear();
            this.ayudaMetroLabel.Visible = (myConfigurador.ModoVisualizacion.AyudaLateral.Equals("True") ? true : false);
            this.ayudaMetroLabel.Text = StringResources.Ayuda_MaestroDeContratos;
        }




        private void MetroMaestroDeContratosForm_Load(object sender, EventArgs e)
        {
            this.cargarComboDeTiposDePlanes();
            this.tipoPlanComboBox.SelectedIndex = 0;
            this.cargarComboDePlanes(0);
            this.ActivarControles();
            this.formularioMetroToolTip.SetToolTip(this.formularioPictureBox, StringResources.ToolTip_MaestroDeContratos);
            this.myContrato = Contrato.CrearContrato("");
            if (this.IsChildForm && !string.IsNullOrEmpty(this.NumeroContratoExterno))
            {
                this.myContrato = Contrato.CrearContrato("");
                this.ReinicializarControles();
                this.nuevoButton.Visible = false;
                this.numeroContratoTextBox.Text = this.NumeroContratoExterno;
                this.BuscarInformacionDeContrato();
            }
            this.VisualizarInformacionDeContrato();
        }

        #endregion



        // Manejo de los botones de accion.
        #region "Manejo de los botones de accion."

        private void nuevoButton_Click(object sender, EventArgs e)
        {
            this.cacheTimer.Start();
            this.NuevoContrato();
            this.rutTextBox.Focus();
        }


        private void editarButton_Click(object sender, EventArgs e)
        {
            this.cacheTimer.Start();
            this.EditarContrato();
        }


        private void eliminarButton_Click(object sender, EventArgs e)
        {
            this.cacheTimer.Stop();
            this.QuitarArchivoDeCache();
            this.TerminarContrato();
        }


        private void cerrarButton_Click(object sender, EventArgs e)
        {
            this.cacheTimer.Stop();
            this.QuitarArchivoDeCache();
            this.Close();
        }

        #endregion



        //  Manejo de los botones.
        #region "Manejo de los botones."

        private void numeroContratoButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.numeroContratoTextBox.Text))
            {
                this.AbrirListaDeContratos(true);
                if (string.IsNullOrEmpty(this.numeroContratoTextBox.Text)) return;
            }
            this.BuscarInformacionDeContrato();
        }


        private void limpiarButton_Click(object sender, EventArgs e)
        {
            this.ReinicializarControles();
            this.myContrato = Contrato.CrearContrato("");
            this.VisualizarInformacionDeContrato();
            this.EstadoForm = EstadoFormulario.Buscar;
            this.ActivarControles();
            this.numeroContratoTextBox.Focus();
        }


        private void rutButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.rutTextBox.Text))
            {
                this.AbrirListaDeClientes(true);
                if (string.IsNullOrEmpty(this.rutTextBox.Text)) return;
            }
            if (!this.ValidaRut())
            {
                this.myContrato.LimpiarCliente();
                this.MostrarDatosCliente();
                return;
            }
            this.BuscarInformacionDeCliente();
        }


        private void grabarButton_Click(object sender, EventArgs e)
        {
            this.cacheTimer.Stop();
            this.QuitarArchivoDeCache();
            this.HayCambios = false;
            if (!this.ValidarEntradasDeControles()) return;
            if (!this.GrabarContrato()) return;
            if (this.IsChildForm)
            {
                this.HayCambios = true;
                this.Close();
                return;
            }
            this.ReinicializarControles();
            this.numeroContratoTextBox.Text = string.Empty;
            this.EstadoForm = EstadoFormulario.Buscar;
            this.ActivarControles();
            this.numeroContratoTextBox.Focus();
        }


        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.cacheTimer.Stop();
            this.QuitarArchivoDeCache();
            if (this.IsChildForm)
            {
                this.HayCambios = false;
                this.Close();
                return;
            }
            this.myContrato = Contrato.CrearContrato("");
            this.ReinicializarControles();
            this.numeroContratoTextBox.Text = string.Empty;
            this.EstadoForm = EstadoFormulario.Buscar;
            this.ActivarControles();
            this.numeroContratoTextBox.Focus();
        }

        #endregion



        // Manejo de planes.
        #region "Manejo de planes."


        private void tipoPlanComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.tipoPlanComboBox.Items.Count.Equals(0)) return;
                if (int.Parse(this.tipoPlanComboBox.SelectedValue.ToString()).Equals(0)) this.myTipoSeguro = TipoSeguro.Ninguno;
                if (int.Parse(this.tipoPlanComboBox.SelectedValue.ToString()).Equals(10)) this.myTipoSeguro = TipoSeguro.Vida;
                if (int.Parse(this.tipoPlanComboBox.SelectedValue.ToString()).Equals(20)) this.myTipoSeguro = TipoSeguro.Vehiculo;
                if (int.Parse(this.tipoPlanComboBox.SelectedValue.ToString()).Equals(30)) this.myTipoSeguro = TipoSeguro.Vivienda;
                this.detallePlanLinkLabel.Visible = (int.Parse(this.tipoPlanComboBox.SelectedValue.ToString()) <= 10 ? false : true);
                this.myContrato.IdTipoContrato = int.Parse(this.tipoPlanComboBox.SelectedValue.ToString());
                this.myContrato.TipoDeContrato = this.tipoPlanComboBox.Text;
                this.cargarComboDePlanes(int.Parse(this.tipoPlanComboBox.SelectedValue.ToString()));
                this.planComboBox.SelectedItem = 0;
                this.myContrato.AsignarPrima(myTipoSeguro);
            }
            catch
            {
            }
        }


        private void planComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CargarValorDePrimas();
            this.myContrato.AsignarPrima(myTipoSeguro);
        }


        private void detallePlanLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.myTipoSeguro.Equals(TipoSeguro.Ninguno)) return;
            if (this.myTipoSeguro.Equals(TipoSeguro.Vehiculo))
            {
                DatosVehiculoMetroForm myForm = new DatosVehiculoMetroForm(this.formularioMetroStyleManager.Theme);
                myForm.Vehiculo = this.myContrato.Vehiculo;
                var myCommand = CmdAbrirFormulario.Crear(myForm);
                myCommand.Ejecutar();
                if (myForm.DialogResult.Equals(DialogResult.OK))
                {
                    this.myContrato.Vehiculo = myForm.Vehiculo;
                    this.myContrato.AsignarPrima(myTipoSeguro);
                    this.MostrarValoresSeguro();
                }
            }
            if (this.myTipoSeguro.Equals(TipoSeguro.Vivienda))
            {
                DatosViviendaMetroForm myForm = new DatosViviendaMetroForm(this.formularioMetroStyleManager.Theme);
                myForm.Vivienda = this.myContrato.Vivienda;
                var myCommand = CmdAbrirFormulario.Crear(myForm);
                myCommand.Ejecutar();
                if (myForm.DialogResult.Equals(DialogResult.OK))
                {
                    this.myContrato.Vivienda = myForm.Vivienda;
                    this.myContrato.AsignarPrima(myTipoSeguro);
                    this.MostrarValoresSeguro();
                }
            }
        }

        #endregion



        // Manejo del control de inicio de vigencia.
        #region "Manejo del control de inicio de vigencia."

        private void inicioVigenciaDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            this.CalcularTerminoVigencia();
        }

        #endregion



        // Metodos del formulario.
        #region "Metodos del formulario."

        private void NuevoContrato()
        {
            this.myContrato = Contrato.CrearContrato();
            this.EstadoForm = EstadoFormulario.Crear;
            this.accionGrabar = TipoGrabacion.Agregar;
            this.ActivarControles();
        }


        private void EditarContrato()
        {
            this.EstadoForm = EstadoFormulario.Editar;
            this.accionGrabar = TipoGrabacion.Actualizar;
            this.ActivarControles();
        }


        private void cargarComboDeTiposDePlanes()
        {
            CmdCargarComboTipoPlan myCommand = CmdCargarComboTipoPlan.crear(this, this.tipoPlanComboBox);
            myCommand.Ejecutar();
        }


        private void cargarComboDePlanes(int tipoPlan)
        {
            this.planComboBox.SelectedIndexChanged -= this.planComboBox_SelectedIndexChanged;
            var myCommand = CmdCargarComboPlan.Crear(this, this.planComboBox, tipoPlan);
            myCommand.Ejecutar();
            myPlanList = myCommand.PlanList;
            this.planComboBox.SelectedIndexChanged += this.planComboBox_SelectedIndexChanged;
        }


        private void restringirFechas()
        {
            DateTime fecha = DateTime.Now;
            this.inicioVigenciaDateTimePicker.Value = fecha;
            this.inicioVigenciaDateTimePicker.MinDate = fecha;
            this.inicioVigenciaDateTimePicker.MaxDate = fecha.AddMonths(1);
        }


        private void AjustarTiemposDeControlInicioDeVigencia(DateTime minFechaReferencia, DateTime maxFechaReferencia)
        {
            DateTimePicker myPicker = new DateTimePicker();
            myPicker.Value = maxFechaReferencia;
            this.inicioVigenciaDateTimePicker.MinDate = myPicker.MinDate;
            this.inicioVigenciaDateTimePicker.MaxDate = myPicker.MaxDate;
            this.inicioVigenciaDateTimePicker.Value = DateTime.Now;
            this.inicioVigenciaDateTimePicker.MinDate = minFechaReferencia;
            this.inicioVigenciaDateTimePicker.MaxDate = myPicker.Value.AddMonths(1);
        }


        private void CalcularTerminoVigencia()
        {
            string myDay = this.inicioVigenciaDateTimePicker.Value.Day.ToString().PadLeft(2, '0');
            string myMonth = this.inicioVigenciaDateTimePicker.Value.Month.ToString().PadLeft(2, '0');
            string myYear = (this.inicioVigenciaDateTimePicker.Value.Year + 1).ToString();
            this.terminoVigenciaTextBox.Text = myDay + "/" + myMonth + "/" + myYear;
            this.terminoContratoTextBox.Text = this.terminoVigenciaTextBox.Text;
        }





        private void ActivarControles()
        {
            if (this.EstadoForm == EstadoFormulario.Buscar) this.controlesModoBusqueda();
            if (this.EstadoForm == EstadoFormulario.Crear) this.controlesModoCrear();
            if (this.EstadoForm == EstadoFormulario.Editar) this.controlesModoEditar();
        }


        private void controlesModoBusqueda()
        {
            this.cacheTimer.Stop();
            this.QuitarArchivoDeCache();
            this.myContrato = Contrato.CrearContrato("");
            this.VisualizarInformacionDeContrato();
            this.accionGrabar = TipoGrabacion.Nada;
            this.habilitarControles(false);
            this.HabilitarBotonesLaterales(false);
            this.numeroContratoTextBox.Enabled = true;
            this.numeroContratoButton.Enabled = true;
            this.nuevoButton.Visible = true;
            this.grabarButton.Visible = false;
            this.cancelarButton.Visible = false;
            this.FijarImagen(Properties.Resources.ContractSearch, StringResources.MaestroContratos_MensajeModoBusqueda);
            this.textoMetroLabel.Text = StringResources.MaestroContratos_MensajeModoBusqueda;
            this.numeroContratoTextBox.Focus();
        }


        private void FijarImagen(Image myImagen, string myToolTip)
        {
            this.accionPictureBox.Image = myImagen;
            this.formularioMetroToolTip.SetToolTip(this.accionPictureBox, myToolTip);
        }


        private void controlesModoCrear()
        {
            this.myContrato = Contrato.CrearContrato();
            this.VisualizarInformacionDeContrato();
            this.habilitarControles(true);
            this.contratoVigenteCheckBox.Checked = true;
            this.numeroContratoTextBox.Enabled = false;
            this.numeroContratoButton.Enabled = false;
            this.HabilitarBotonesLaterales(false);
            this.grabarButton.Visible = true;
            this.grabarButton.Enabled = true;
            this.cancelarButton.Visible = true;
            this.FijarImagen(Properties.Resources.ContractAdd, StringResources.MaestroContratos_MensajeModoNuevoContrato);
            this.textoMetroLabel.Text = StringResources.MaestroContratos_MensajeModoNuevoContrato;
            this.restringirFechas();
        }


        private void controlesModoEditar()
        {
            this.VisualizarInformacionDeContrato();
            this.habilitarControles(true);
            this.HabilitarBotonesLaterales(false);
            this.numeroContratoTextBox.Enabled = false;
            this.detallePlanLinkLabel.Visible = false;
            this.grabarButton.Visible = true;
            this.grabarButton.Enabled = true;
            this.cancelarButton.Visible = true;
            this.FijarImagen(Properties.Resources.ContractUpdate, string.Format(StringResources.MaestroContratos_MensajeModoEdicion, this.nombreTextBox.Text + " " + this.apellidoTextBox.Text));
            this.textoMetroLabel.Text = string.Format(StringResources.MaestroContratos_MensajeModoEdicion, this.nombreTextBox.Text + " " + this.apellidoTextBox.Text);
            this.AjustarTiemposDeControlInicioDeVigencia(this.inicioVigenciaDateTimePicker.Value, DateTime.Today);
            this.inicioVigenciaDateTimePicker.Focus();
        }


        private void habilitarControles(bool estado)
        {
            this.HabilitarControlesDeUsuario(estado);
            this.HabilitarControlesDePlan(estado);
            this.HabilitarControlesDeContratos(estado);
        }


        private void HabilitarControlesDeUsuario(bool estado)
        {
            this.rutTextBox.Enabled = estado;
            this.nombreTextBox.Enabled = estado;
            this.apellidoTextBox.Enabled = estado;
            this.nacimientoTextBox.Enabled = estado;
            this.sexoTextBox.Enabled = estado;
            this.estadoCivilTextBox.Enabled = estado;
            this.rutButton.Enabled = estado;
        }


        private void HabilitarControlesDePlan(bool estado)
        {
            this.tipoPlanComboBox.Enabled = estado;
            this.tipoPlanTextBox.Enabled = estado;
            this.planComboBox.Enabled = estado;
            this.planTextBox.Enabled = estado;
            this.numeroDePolizaTextBox.Enabled = estado;
            this.valorPlanTextBox.Enabled = estado;
        }


        private void HabilitarControlesDeContratos(bool estado)
        {
            this.inicioContratoTextBox.Enabled = estado;
            this.inicioVigenciaDateTimePicker.Enabled = estado;
            this.terminoContratoTextBox.Enabled = estado;
            this.terminoVigenciaTextBox.Enabled = estado;
            this.valorBaseContratoTextBox.Enabled = estado;
            this.recargoTextBox.Enabled = estado;
            this.primaAnualTextBox.Enabled = estado;
            this.explicacionRecargoTextBox.Enabled = estado;
            this.declaracionDeSaludCheckBox.Enabled = estado;
            this.observacionesTextBox.Enabled = estado;
        }


        private void HabilitarBotonesLaterales(bool estado)
        {
            this.nuevoButton.Visible = estado;
            this.editarButton.Visible = estado;
            this.eliminarButton.Visible = estado;
        }


        private void CargarValorDePrimas()
        {
            if (this.myPlanList == null) return;
            foreach (DtoPlan plan in myPlanList)
            {
                if (plan.IdPlan.Equals(this.planComboBox.SelectedValue.ToString()))
                {
                    this.myContrato.Plan.IdPlan = plan.IdPlan;
                    this.myContrato.Plan.Nombre = plan.Nombre;
                    this.myContrato.Plan.PolizaActual = plan.PolizaActual;
                    this.myContrato.Plan.PrimaBase = plan.PrimaBase;
                }
            }
            this.MostrarValoresSeguro();
        }


        private void AbrirListaDeClientes(bool esUnaBusqueda)
        {
            MetroListadoDeClientesForm myForm = new MetroListadoDeClientesForm(formularioMetroStyleManager.Theme);
            myForm.IsSearch = esUnaBusqueda;
            CmdAbrirFormulario myCommand = CmdAbrirFormulario.Crear(myForm);
            myCommand.Ejecutar();
            if (esUnaBusqueda) this.rutTextBox.Text = myForm.RutCliente;
        }


        private bool ValidaRut()
        {
            var myCommand = CmdValidarEntradas.crear(this);
            myCommand.ValidarVacio(this.rutTextBox, "rut cliente");
            myCommand.ValidarRut(this.rutTextBox);
            return !myCommand.FalloValidacion;
        }


        private void BuscarInformacionDeCliente()
        {
            DtoCliente myCliente = new DtoCliente();
            var myCommand = CmdBuscarCliente.Crear(this.rutTextBox.Text.ToString().Trim().ToUpper());
            myCommand.Ejecutar();
            if (!myCommand.fueEncontrado)
            {
                MsgBox.Show(this, StringResources.MaestroClientes_MensajeRutNoExiste, StringResources.TituloMensajes_Atencion, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.myContrato.LimpiarCliente();
                myCliente = this.myContrato.Cliente;
            }
            else
            {
                myCliente = myCommand.MyCliente;
            }
            this.AsignarValorEnControlesDeCliente(myCliente);
            this.myContrato.AsignarPrima(myTipoSeguro);
            this.rutTextBox.Focus();
        }


        private void AsignarValorEnControlesDeCliente(DtoCliente myCliente)
        {
            this.myContrato.Cliente.Rut = myCliente.Rut;
            this.myContrato.Cliente.Nombre = myCliente.Nombre;
            this.myContrato.Cliente.Apellido = myCliente.Apellido;
            this.myContrato.Cliente.Fecha = myCliente.Fecha;
            this.myContrato.Cliente.Sexo = myCliente.Sexo;
            this.myContrato.Cliente.EstadoCivil = myCliente.EstadoCivil;
            this.MostrarDatosCliente();
        }


        private void ReinicializarControles()
        {
            DateTime fecha = DateTime.Now;
            this.AjustarTiemposDeControlInicioDeVigencia(DateTime.Today, DateTime.Today);
            this.CalcularTerminoVigencia();
        }


        private void AbrirListaDeContratos(bool esUnaBusqueda)
        {
            MetroListadoDeContratosForm myForm = new MetroListadoDeContratosForm(formularioMetroStyleManager.Theme);
            myForm.IsSearch = esUnaBusqueda;
            CmdAbrirFormulario myCommand = CmdAbrirFormulario.Crear(myForm);
            myCommand.Ejecutar();
            if (esUnaBusqueda) this.numeroContratoTextBox.Text = myForm.NumeroContrato;
        }


        private void BuscarInformacionDeContrato()
        {
            var myCommand = CmdBuscarContrato.Crear(this.numeroContratoTextBox.Text.ToString().Trim());
            myCommand.Ejecutar();
            if (myCommand.OcurrioError)
            {
                MsgBox.Show(this, myCommand.MensajeError.ToString(), StringResources.TituloMensajes_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.EstadoForm == EstadoFormulario.Crear)
            {
                if (myCommand.fueEncontrado)
                {
                    MsgBox.Show(this, myCommand.MensajeBusqueda.ToString(), StringResources.TituloMensajes_Atencion, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.grabarButton.Enabled = false;
                    this.numeroContratoTextBox.Focus();
                    return;
                }
                else
                {
                    this.grabarButton.Enabled = true;
                    return;
                }
            }
            if (!myCommand.fueEncontrado)
            {
                MsgBox.Show(this, myCommand.MensajeBusqueda.ToString(), StringResources.TituloMensajes_Atencion, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //this.AsignarValorEnControlesDeContrato(myCommand.Contrato);
            this.myContrato = myCommand.Contrato;
            this.VisualizarInformacionDeContrato();
            this.habilitarControles(true);
            this.rutButton.Enabled = false;
            this.rutTextBox.ReadOnly = true;
            this.HabilitarBotonesLaterales(this.contratoVigenteCheckBox.Checked);
            this.nuevoButton.Visible = true;
        }


        private bool ValidarEntradasDeControles()
        {
            var myCommand = CmdValidarEntradas.crear(this);
            myCommand.ValidarVacio(this.numeroContratoTextBox, "número de contrato");
            if (!myCommand.FalloValidacion) myCommand.ValidarVacio(this.rutTextBox, "rut cliente");
            if (!myCommand.FalloValidacion) myCommand.ValidarRut(this.rutTextBox);
            if (string.IsNullOrEmpty(this.nombreTextBox.Text))
            {
                MsgBox.Show(this, StringResources.MaestroContratos_MensajeDatosClienteSinConfirmar, StringResources.TituloMensajes_Atencion, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.rutTextBox.Focus();
                return false;
            }
            if (!myCommand.FalloValidacion) myCommand.ValidarSeleccionComboBox(this.planComboBox, "plan");
            if (this.accionGrabar == TipoGrabacion.Agregar && !myCommand.FalloValidacion)
            {
                myCommand.ValidarExistenciaDeVigenciaDePlan(this.rutTextBox.Text, this.planComboBox.SelectedValue.ToString());
            }
            return !myCommand.FalloValidacion;
        }


        private bool GrabarContrato()
        {
            try
            {
                if (this.accionGrabar == TipoGrabacion.Nada) return false;
                Contrato nuevoContrato = this.RecolectarInformacionDeContrato();
                CmdGrabarContrato myCommand = CmdGrabarContrato.Crear(nuevoContrato, this.accionGrabar);
                myCommand.Ejecutar();
                if (myCommand.OcurrioError)
                {
                    MsgBox.Show(this, myCommand.MensajeError.ToString(), StringResources.TituloMensajes_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MsgBox.Show(this, myCommand.MensajeGrabacion.ToString(), StringResources.TituloMensajes_Atencion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return myCommand.fueAlmacenado;
            }
            catch (Exception ex)
            {
                MsgBox.Show(this, ex.Message.ToString(), StringResources.TituloMensajes_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }


        private Contrato RecolectarInformacionDeContrato()
        {
            Contrato unContrato = Contrato.CrearContrato(this.numeroContratoTextBox.Text.Trim());
            unContrato.Cliente = this.myContrato.Cliente;
            unContrato.IdTipoContrato = this.myContrato.IdTipoContrato;
            unContrato.TipoDeContrato = this.myContrato.TipoDeContrato;
            unContrato.Plan = this.myContrato.Plan;
            unContrato.Prima = this.myContrato.Prima;
            unContrato.Vehiculo = this.myContrato.Vehiculo;
            unContrato.Vivienda = this.myContrato.Vivienda;
            unContrato.DetalleContrato.AsignaFechaContrato(this.inicioVigenciaDateTimePicker.Value);
            unContrato.DetalleContrato.VigenciaContrato = (this.contratoVigenteCheckBox.Checked ? 1 : 0);
            unContrato.DetalleContrato.DeclaracionDeSalud = (this.declaracionDeSaludCheckBox.Checked ? 1 : 0);
            unContrato.DetalleContrato.Observaciones = this.observacionesTextBox.Text.Trim();
            return unContrato;
        }


        private void TerminarContrato()
        {
            DialogResult myResult = MsgBox.Show(this, string.Format(StringResources.MaestroContratos_MensajePreguntaDETerminoDeContrato, this.numeroContratoTextBox.Text, this.nombreTextBox.Text + " " + this.apellidoTextBox.Text, this.planComboBox.Text), StringResources.TituloMensajes_Atencion, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (myResult == DialogResult.No) return;
            DateTime fecha = DateTime.Today;
            this.terminoContratoTextBox.Text = fecha.ToShortDateString().ToString();
            this.contratoVigenteCheckBox.Checked = false;
            this.grabarButton.Visible = true;
            this.cancelarButton.Visible = true;
            this.accionGrabar = TipoGrabacion.Actualizar;
            MsgBox.Show(this, string.Format(StringResources.MaestroContratos_MensajeCambioFechaDETerminoDeContrato, fecha.ToShortDateString().ToString()), StringResources.TituloMensajes_Atencion, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void QuitarArchivoDeCache()
        {
            string myNombreDeArchivo = Path.Combine(Environment.CurrentDirectory, "xCache.stn");
            FileInfo myFile = new FileInfo(myNombreDeArchivo);
            if (myFile.Exists) myFile.Delete();
            myFile = null;
        }















        #endregion






        private void VisualizarInformacionDeContrato()
        {
            this.MostrarDatosContrato();
            this.MostrarDatosCliente();
            this.MostrarDatosSeguro();
            this.MostrarValoresSeguro();
            this.MostrarDetalleContrato();
        }


        private void MostrarDatosContrato()
        {
            if (this.myContrato == null) return;
            this.numeroContratoTextBox.Text = this.myContrato.NumeroContrato.ToString();
        }


        private void MostrarDatosCliente()
        {
            if (this.myContrato == null) return;
            this.rutTextBox.Text = this.myContrato.Cliente.Rut.ToString();
            this.nombreTextBox.Text = this.myContrato.Cliente.Nombre.ToString();
            this.apellidoTextBox.Text = this.myContrato.Cliente.Apellido.ToString();
            this.nacimientoTextBox.Text = (this.myContrato.Cliente.Fecha.ToShortDateString().Equals(DateTime.Today.ToShortDateString()) ? string.Empty : this.myContrato.Cliente.Fecha.ToShortDateString());
            this.estadoCivilTextBox.Text = this.myContrato.Cliente.EstadoCivil.ToString();
            this.sexoTextBox.Text = this.myContrato.Cliente.Sexo.ToString();
        }


        private void MostrarDatosSeguro()
        {
            if (this.myContrato == null) return;
            this.tipoPlanComboBox.Text = this.myContrato.TipoDeContrato.ToString();
            this.tipoPlanTextBox.Text = (this.myContrato.TipoDeContrato.Equals(StringResources.ItemInicial_TipoPlan_Correcto) ? string.Empty : this.myContrato.TipoDeContrato);
            this.planComboBox.Text = this.myContrato.Plan.Nombre.ToString();
            this.planTextBox.Text = (this.myContrato.Plan.Nombre.Equals(StringResources.ItemInicial_Plan_Correcto) ? string.Empty : this.myContrato.Plan.Nombre);
            this.planComboBox.Visible = (this.EstadoForm.Equals(EstadoFormulario.Buscar) ? false : true);
            this.tipoPlanComboBox.Visible = (this.EstadoForm.Equals(EstadoFormulario.Buscar) ? false : true);
            this.planTextBox.Visible = (this.EstadoForm.Equals(EstadoFormulario.Buscar) ? true : false);
            this.tipoPlanTextBox.Visible = (this.EstadoForm.Equals(EstadoFormulario.Buscar) ? true : false);
        }


        private void MostrarValoresSeguro()
        {
            if (this.myContrato == null) return;
            this.numeroDePolizaTextBox.Text = this.myContrato.Plan.PolizaActual.ToString();
            this.valorPlanTextBox.Text = this.myContrato.Plan.PrimaBase.ToString();
            this.detallePlanLinkLabel.Visible = (this.myContrato.IdTipoContrato > 10 ? true : false);
            this.valorBaseContratoTextBox.Text = this.myContrato.Plan.PrimaBase.ToString();
            this.recargoTextBox.Text = this.myContrato.Prima.Recargo.ToString();
            this.primaAnualTextBox.Text = this.myContrato.Prima.ValorTotal.ToString();
            this.explicacionRecargoTextBox.Text = this.myContrato.Prima.ToString();
        }


        private void MostrarDetalleContrato()
        {
            if (this.myContrato == null) return;
            this.inicioContratoTextBox.Text = this.myContrato.DetalleContrato.FechaInicioContrato.ToShortDateString();
            this.terminoContratoTextBox.Text = this.myContrato.DetalleContrato.FechaTerminoContrato.ToShortDateString();
            this.inicioVigenciaDateTimePicker.Value = this.myContrato.DetalleContrato.FechaInicioDeVigencia;
            this.terminoVigenciaTextBox.Text = this.myContrato.DetalleContrato.FechaTerminoDeVigencia.ToShortDateString();
            this.contratoVigenteCheckBox.Checked = (this.myContrato.DetalleContrato.VigenciaContrato.Equals(1) ? true : false);
            this.declaracionDeSaludCheckBox.Checked = (this.myContrato.DetalleContrato.DeclaracionDeSalud.Equals(1) ? true : false);
            this.observacionesTextBox.Text = (string.IsNullOrEmpty(this.myContrato.DetalleContrato.Observaciones) ? string.Empty : this.myContrato.DetalleContrato.Observaciones.ToString());
        }

        private void cacheTimer_Tick(object sender, EventArgs e)
        {
            Cache myCache = Cache.CrearCache();
            myCache.GrabarInformacion(this.RecolectarInformacionDeContrato());
        }
    }
}
