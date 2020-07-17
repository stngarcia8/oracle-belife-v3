namespace BeLife.Vista.MetroForms
{
    partial class MetroBeLifeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MetroBeLifeForm));
            this.formularioMetroStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.formularioMetroToolTip = new MetroFramework.Components.MetroToolTip();
            this.darkModeMetroTile = new MetroFramework.Controls.MetroTile();
            this.atencionClientePictureBox = new System.Windows.Forms.PictureBox();
            this.formularioMetroStyleExtender = new MetroFramework.Components.MetroStyleExtender(this.components);
            this.opcionesTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.recuperarMetroTile = new MetroFramework.Controls.MetroTile();
            this.metroTile = new MetroFramework.Controls.MetroTile();
            this.formularioPictureBox = new System.Windows.Forms.PictureBox();
            this.opcionesMetroLabel = new MetroFramework.Controls.MetroLabel();
            this.preferenciasMetroButton = new MetroFramework.Controls.MetroButton();
            this.acercaMetroButton = new MetroFramework.Controls.MetroButton();
            this.imagenTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.clientesTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.maestroClientesMetroTile = new MetroFramework.Controls.MetroTile();
            this.listadoClientesMetroTile = new MetroFramework.Controls.MetroTile();
            this.clientesPictureBox = new System.Windows.Forms.PictureBox();
            this.clientesMetroLabel = new MetroFramework.Controls.MetroLabel();
            this.contratosTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.maestroContratosMetroTile = new MetroFramework.Controls.MetroTile();
            this.listadoContratosMetroTile = new MetroFramework.Controls.MetroTile();
            this.contratosPictureBox = new System.Windows.Forms.PictureBox();
            this.contratosMetroLabel = new MetroFramework.Controls.MetroLabel();
            this.formularioTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.opcionesMetroPanel = new MetroFramework.Controls.MetroPanel();
            this.contratosMetroPanel = new MetroFramework.Controls.MetroPanel();
            this.clientesMetroPanel = new MetroFramework.Controls.MetroPanel();
            ((System.ComponentModel.ISupportInitialize)(this.formularioMetroStyleManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.atencionClientePictureBox)).BeginInit();
            this.opcionesTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.formularioPictureBox)).BeginInit();
            this.imagenTableLayoutPanel.SuspendLayout();
            this.clientesTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientesPictureBox)).BeginInit();
            this.contratosTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contratosPictureBox)).BeginInit();
            this.formularioTableLayoutPanel.SuspendLayout();
            this.opcionesMetroPanel.SuspendLayout();
            this.contratosMetroPanel.SuspendLayout();
            this.clientesMetroPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // formularioMetroStyleManager
            // 
            this.formularioMetroStyleManager.Owner = this;
            // 
            // formularioMetroToolTip
            // 
            this.formularioMetroToolTip.Style = MetroFramework.MetroColorStyle.Blue;
            this.formularioMetroToolTip.StyleManager = null;
            this.formularioMetroToolTip.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // darkModeMetroTile
            // 
            resources.ApplyResources(this.darkModeMetroTile, "darkModeMetroTile");
            this.darkModeMetroTile.ActiveControl = null;
            this.darkModeMetroTile.BackColor = System.Drawing.Color.Transparent;
            this.formularioTableLayoutPanel.SetColumnSpan(this.darkModeMetroTile, 2);
            this.darkModeMetroTile.Name = "darkModeMetroTile";
            this.darkModeMetroTile.TileImage = global::BeLife.Vista.Properties.Resources.sunLightTheme;
            this.formularioMetroToolTip.SetToolTip(this.darkModeMetroTile, resources.GetString("darkModeMetroTile.ToolTip"));
            this.darkModeMetroTile.UseCustomBackColor = true;
            this.darkModeMetroTile.UseCustomForeColor = true;
            this.darkModeMetroTile.UseSelectable = true;
            this.darkModeMetroTile.UseTileImage = true;
            this.darkModeMetroTile.Click += new System.EventHandler(this.darkModeMetroTile_Click);
            // 
            // atencionClientePictureBox
            // 
            resources.ApplyResources(this.atencionClientePictureBox, "atencionClientePictureBox");
            this.atencionClientePictureBox.Image = global::BeLife.Vista.Properties.Resources.AgenteMostrandoPoliza;
            this.atencionClientePictureBox.Name = "atencionClientePictureBox";
            this.atencionClientePictureBox.TabStop = false;
            this.formularioMetroToolTip.SetToolTip(this.atencionClientePictureBox, resources.GetString("atencionClientePictureBox.ToolTip"));
            // 
            // opcionesTableLayoutPanel
            // 
            resources.ApplyResources(this.opcionesTableLayoutPanel, "opcionesTableLayoutPanel");
            this.formularioMetroStyleExtender.SetApplyMetroTheme(this.opcionesTableLayoutPanel, true);
            this.opcionesTableLayoutPanel.Controls.Add(this.recuperarMetroTile, 0, 3);
            this.opcionesTableLayoutPanel.Controls.Add(this.metroTile, 4, 1);
            this.opcionesTableLayoutPanel.Controls.Add(this.formularioPictureBox, 1, 1);
            this.opcionesTableLayoutPanel.Controls.Add(this.opcionesMetroLabel, 3, 0);
            this.opcionesTableLayoutPanel.Controls.Add(this.preferenciasMetroButton, 3, 1);
            this.opcionesTableLayoutPanel.Controls.Add(this.acercaMetroButton, 3, 2);
            this.opcionesTableLayoutPanel.Name = "opcionesTableLayoutPanel";
            this.formularioMetroToolTip.SetToolTip(this.opcionesTableLayoutPanel, resources.GetString("opcionesTableLayoutPanel.ToolTip"));
            // 
            // recuperarMetroTile
            // 
            resources.ApplyResources(this.recuperarMetroTile, "recuperarMetroTile");
            this.recuperarMetroTile.ActiveControl = null;
            this.recuperarMetroTile.BackColor = System.Drawing.Color.Red;
            this.recuperarMetroTile.Name = "recuperarMetroTile";
            this.recuperarMetroTile.Style = MetroFramework.MetroColorStyle.Purple;
            this.recuperarMetroTile.TileImage = global::BeLife.Vista.Properties.Resources._116_512;
            this.recuperarMetroTile.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.recuperarMetroTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.formularioMetroToolTip.SetToolTip(this.recuperarMetroTile, resources.GetString("recuperarMetroTile.ToolTip"));
            this.recuperarMetroTile.UseSelectable = true;
            this.recuperarMetroTile.UseStyleColors = true;
            this.recuperarMetroTile.Click += new System.EventHandler(this.recuperarMetroTile_Click);
            // 
            // metroTile
            // 
            resources.ApplyResources(this.metroTile, "metroTile");
            this.metroTile.ActiveControl = null;
            this.metroTile.Name = "metroTile";
            this.opcionesTableLayoutPanel.SetRowSpan(this.metroTile, 2);
            this.metroTile.Style = MetroFramework.MetroColorStyle.Purple;
            this.metroTile.TileImage = global::BeLife.Vista.Properties.Resources.Exit;
            this.metroTile.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.formularioMetroToolTip.SetToolTip(this.metroTile, resources.GetString("metroTile.ToolTip"));
            this.metroTile.UseSelectable = true;
            this.metroTile.UseStyleColors = true;
            this.metroTile.UseTileImage = true;
            this.metroTile.Click += new System.EventHandler(this.metroTile_Click);
            // 
            // formularioPictureBox
            // 
            resources.ApplyResources(this.formularioPictureBox, "formularioPictureBox");
            this.formularioPictureBox.Image = global::BeLife.Vista.Properties.Resources.Logo_SinFondo_BeLife;
            this.formularioPictureBox.Name = "formularioPictureBox";
            this.opcionesTableLayoutPanel.SetRowSpan(this.formularioPictureBox, 3);
            this.formularioPictureBox.TabStop = false;
            this.formularioMetroToolTip.SetToolTip(this.formularioPictureBox, resources.GetString("formularioPictureBox.ToolTip"));
            // 
            // opcionesMetroLabel
            // 
            resources.ApplyResources(this.opcionesMetroLabel, "opcionesMetroLabel");
            this.opcionesTableLayoutPanel.SetColumnSpan(this.opcionesMetroLabel, 2);
            this.opcionesMetroLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.opcionesMetroLabel.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.opcionesMetroLabel.Name = "opcionesMetroLabel";
            this.formularioMetroToolTip.SetToolTip(this.opcionesMetroLabel, resources.GetString("opcionesMetroLabel.ToolTip"));
            this.opcionesMetroLabel.WrapToLine = true;
            // 
            // preferenciasMetroButton
            // 
            resources.ApplyResources(this.preferenciasMetroButton, "preferenciasMetroButton");
            this.preferenciasMetroButton.DisplayFocus = true;
            this.preferenciasMetroButton.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.preferenciasMetroButton.Name = "preferenciasMetroButton";
            this.formularioMetroToolTip.SetToolTip(this.preferenciasMetroButton, resources.GetString("preferenciasMetroButton.ToolTip"));
            this.preferenciasMetroButton.UseSelectable = true;
            this.preferenciasMetroButton.Click += new System.EventHandler(this.preferenciasMetroButton_Click);
            // 
            // acercaMetroButton
            // 
            resources.ApplyResources(this.acercaMetroButton, "acercaMetroButton");
            this.acercaMetroButton.DisplayFocus = true;
            this.acercaMetroButton.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.acercaMetroButton.Name = "acercaMetroButton";
            this.formularioMetroToolTip.SetToolTip(this.acercaMetroButton, resources.GetString("acercaMetroButton.ToolTip"));
            this.acercaMetroButton.UseSelectable = true;
            this.acercaMetroButton.Click += new System.EventHandler(this.acercaMetroButton_Click);
            // 
            // imagenTableLayoutPanel
            // 
            resources.ApplyResources(this.imagenTableLayoutPanel, "imagenTableLayoutPanel");
            this.formularioMetroStyleExtender.SetApplyMetroTheme(this.imagenTableLayoutPanel, true);
            this.imagenTableLayoutPanel.Controls.Add(this.atencionClientePictureBox, 1, 1);
            this.imagenTableLayoutPanel.Name = "imagenTableLayoutPanel";
            this.formularioTableLayoutPanel.SetRowSpan(this.imagenTableLayoutPanel, 2);
            this.formularioMetroToolTip.SetToolTip(this.imagenTableLayoutPanel, resources.GetString("imagenTableLayoutPanel.ToolTip"));
            // 
            // clientesTableLayoutPanel
            // 
            resources.ApplyResources(this.clientesTableLayoutPanel, "clientesTableLayoutPanel");
            this.formularioMetroStyleExtender.SetApplyMetroTheme(this.clientesTableLayoutPanel, true);
            this.clientesTableLayoutPanel.Controls.Add(this.maestroClientesMetroTile, 2, 1);
            this.clientesTableLayoutPanel.Controls.Add(this.listadoClientesMetroTile, 1, 1);
            this.clientesTableLayoutPanel.Controls.Add(this.clientesPictureBox, 0, 0);
            this.clientesTableLayoutPanel.Controls.Add(this.clientesMetroLabel, 1, 0);
            this.clientesTableLayoutPanel.Name = "clientesTableLayoutPanel";
            this.formularioMetroToolTip.SetToolTip(this.clientesTableLayoutPanel, resources.GetString("clientesTableLayoutPanel.ToolTip"));
            // 
            // maestroClientesMetroTile
            // 
            resources.ApplyResources(this.maestroClientesMetroTile, "maestroClientesMetroTile");
            this.maestroClientesMetroTile.ActiveControl = null;
            this.maestroClientesMetroTile.Name = "maestroClientesMetroTile";
            this.maestroClientesMetroTile.Style = MetroFramework.MetroColorStyle.Purple;
            this.maestroClientesMetroTile.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.maestroClientesMetroTile.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.maestroClientesMetroTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.formularioMetroToolTip.SetToolTip(this.maestroClientesMetroTile, resources.GetString("maestroClientesMetroTile.ToolTip"));
            this.maestroClientesMetroTile.UseSelectable = true;
            this.maestroClientesMetroTile.UseTileImage = true;
            this.maestroClientesMetroTile.Click += new System.EventHandler(this.maestroClientesMetroTile_Click);
            // 
            // listadoClientesMetroTile
            // 
            resources.ApplyResources(this.listadoClientesMetroTile, "listadoClientesMetroTile");
            this.listadoClientesMetroTile.ActiveControl = null;
            this.listadoClientesMetroTile.Name = "listadoClientesMetroTile";
            this.listadoClientesMetroTile.Style = MetroFramework.MetroColorStyle.Purple;
            this.listadoClientesMetroTile.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.listadoClientesMetroTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.formularioMetroToolTip.SetToolTip(this.listadoClientesMetroTile, resources.GetString("listadoClientesMetroTile.ToolTip"));
            this.listadoClientesMetroTile.UseSelectable = true;
            this.listadoClientesMetroTile.UseTileImage = true;
            this.listadoClientesMetroTile.Click += new System.EventHandler(this.listadoClientesMetroTile_Click);
            // 
            // clientesPictureBox
            // 
            resources.ApplyResources(this.clientesPictureBox, "clientesPictureBox");
            this.formularioMetroStyleExtender.SetApplyMetroTheme(this.clientesPictureBox, true);
            this.clientesPictureBox.Name = "clientesPictureBox";
            this.clientesTableLayoutPanel.SetRowSpan(this.clientesPictureBox, 2);
            this.clientesPictureBox.TabStop = false;
            this.formularioMetroToolTip.SetToolTip(this.clientesPictureBox, resources.GetString("clientesPictureBox.ToolTip"));
            // 
            // clientesMetroLabel
            // 
            resources.ApplyResources(this.clientesMetroLabel, "clientesMetroLabel");
            this.clientesTableLayoutPanel.SetColumnSpan(this.clientesMetroLabel, 2);
            this.clientesMetroLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.clientesMetroLabel.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.clientesMetroLabel.Name = "clientesMetroLabel";
            this.formularioMetroToolTip.SetToolTip(this.clientesMetroLabel, resources.GetString("clientesMetroLabel.ToolTip"));
            this.clientesMetroLabel.WrapToLine = true;
            // 
            // contratosTableLayoutPanel
            // 
            resources.ApplyResources(this.contratosTableLayoutPanel, "contratosTableLayoutPanel");
            this.formularioMetroStyleExtender.SetApplyMetroTheme(this.contratosTableLayoutPanel, true);
            this.contratosTableLayoutPanel.Controls.Add(this.maestroContratosMetroTile, 2, 1);
            this.contratosTableLayoutPanel.Controls.Add(this.listadoContratosMetroTile, 1, 1);
            this.contratosTableLayoutPanel.Controls.Add(this.contratosPictureBox, 0, 0);
            this.contratosTableLayoutPanel.Controls.Add(this.contratosMetroLabel, 1, 0);
            this.contratosTableLayoutPanel.Name = "contratosTableLayoutPanel";
            this.formularioMetroToolTip.SetToolTip(this.contratosTableLayoutPanel, resources.GetString("contratosTableLayoutPanel.ToolTip"));
            // 
            // maestroContratosMetroTile
            // 
            resources.ApplyResources(this.maestroContratosMetroTile, "maestroContratosMetroTile");
            this.maestroContratosMetroTile.ActiveControl = null;
            this.maestroContratosMetroTile.Name = "maestroContratosMetroTile";
            this.maestroContratosMetroTile.Style = MetroFramework.MetroColorStyle.Purple;
            this.maestroContratosMetroTile.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.maestroContratosMetroTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.formularioMetroToolTip.SetToolTip(this.maestroContratosMetroTile, resources.GetString("maestroContratosMetroTile.ToolTip"));
            this.maestroContratosMetroTile.UseSelectable = true;
            this.maestroContratosMetroTile.UseTileImage = true;
            this.maestroContratosMetroTile.Click += new System.EventHandler(this.maestroContratosMetroTile_Click);
            // 
            // listadoContratosMetroTile
            // 
            resources.ApplyResources(this.listadoContratosMetroTile, "listadoContratosMetroTile");
            this.listadoContratosMetroTile.ActiveControl = null;
            this.listadoContratosMetroTile.Name = "listadoContratosMetroTile";
            this.listadoContratosMetroTile.Style = MetroFramework.MetroColorStyle.Purple;
            this.listadoContratosMetroTile.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.listadoContratosMetroTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.formularioMetroToolTip.SetToolTip(this.listadoContratosMetroTile, resources.GetString("listadoContratosMetroTile.ToolTip"));
            this.listadoContratosMetroTile.UseSelectable = true;
            this.listadoContratosMetroTile.UseTileImage = true;
            this.listadoContratosMetroTile.Click += new System.EventHandler(this.listadoContratosMetroTile_Click);
            // 
            // contratosPictureBox
            // 
            resources.ApplyResources(this.contratosPictureBox, "contratosPictureBox");
            this.formularioMetroStyleExtender.SetApplyMetroTheme(this.contratosPictureBox, true);
            this.contratosPictureBox.Name = "contratosPictureBox";
            this.contratosPictureBox.TabStop = false;
            this.formularioMetroToolTip.SetToolTip(this.contratosPictureBox, resources.GetString("contratosPictureBox.ToolTip"));
            // 
            // contratosMetroLabel
            // 
            resources.ApplyResources(this.contratosMetroLabel, "contratosMetroLabel");
            this.contratosMetroLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.contratosMetroLabel.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.contratosMetroLabel.Name = "contratosMetroLabel";
            this.formularioMetroToolTip.SetToolTip(this.contratosMetroLabel, resources.GetString("contratosMetroLabel.ToolTip"));
            this.contratosMetroLabel.WrapToLine = true;
            // 
            // formularioTableLayoutPanel
            // 
            resources.ApplyResources(this.formularioTableLayoutPanel, "formularioTableLayoutPanel");
            this.formularioTableLayoutPanel.Controls.Add(this.opcionesMetroPanel, 0, 3);
            this.formularioTableLayoutPanel.Controls.Add(this.contratosMetroPanel, 0, 2);
            this.formularioTableLayoutPanel.Controls.Add(this.clientesMetroPanel, 0, 1);
            this.formularioTableLayoutPanel.Controls.Add(this.darkModeMetroTile, 0, 0);
            this.formularioTableLayoutPanel.Controls.Add(this.imagenTableLayoutPanel, 1, 1);
            this.formularioTableLayoutPanel.Name = "formularioTableLayoutPanel";
            this.formularioMetroToolTip.SetToolTip(this.formularioTableLayoutPanel, resources.GetString("formularioTableLayoutPanel.ToolTip"));
            // 
            // opcionesMetroPanel
            // 
            resources.ApplyResources(this.opcionesMetroPanel, "opcionesMetroPanel");
            this.formularioTableLayoutPanel.SetColumnSpan(this.opcionesMetroPanel, 2);
            this.opcionesMetroPanel.Controls.Add(this.opcionesTableLayoutPanel);
            this.opcionesMetroPanel.HorizontalScrollbarBarColor = true;
            this.opcionesMetroPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.opcionesMetroPanel.HorizontalScrollbarSize = 10;
            this.opcionesMetroPanel.Name = "opcionesMetroPanel";
            this.formularioMetroToolTip.SetToolTip(this.opcionesMetroPanel, resources.GetString("opcionesMetroPanel.ToolTip"));
            this.opcionesMetroPanel.UseStyleColors = true;
            this.opcionesMetroPanel.VerticalScrollbarBarColor = true;
            this.opcionesMetroPanel.VerticalScrollbarHighlightOnWheel = false;
            this.opcionesMetroPanel.VerticalScrollbarSize = 10;
            // 
            // contratosMetroPanel
            // 
            resources.ApplyResources(this.contratosMetroPanel, "contratosMetroPanel");
            this.contratosMetroPanel.Controls.Add(this.contratosTableLayoutPanel);
            this.contratosMetroPanel.HorizontalScrollbarBarColor = true;
            this.contratosMetroPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.contratosMetroPanel.HorizontalScrollbarSize = 10;
            this.contratosMetroPanel.Name = "contratosMetroPanel";
            this.formularioMetroToolTip.SetToolTip(this.contratosMetroPanel, resources.GetString("contratosMetroPanel.ToolTip"));
            this.contratosMetroPanel.UseStyleColors = true;
            this.contratosMetroPanel.VerticalScrollbarBarColor = true;
            this.contratosMetroPanel.VerticalScrollbarHighlightOnWheel = false;
            this.contratosMetroPanel.VerticalScrollbarSize = 10;
            // 
            // clientesMetroPanel
            // 
            resources.ApplyResources(this.clientesMetroPanel, "clientesMetroPanel");
            this.clientesMetroPanel.Controls.Add(this.clientesTableLayoutPanel);
            this.clientesMetroPanel.HorizontalScrollbarBarColor = true;
            this.clientesMetroPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.clientesMetroPanel.HorizontalScrollbarSize = 10;
            this.clientesMetroPanel.Name = "clientesMetroPanel";
            this.formularioMetroToolTip.SetToolTip(this.clientesMetroPanel, resources.GetString("clientesMetroPanel.ToolTip"));
            this.clientesMetroPanel.UseStyleColors = true;
            this.clientesMetroPanel.VerticalScrollbarBarColor = true;
            this.clientesMetroPanel.VerticalScrollbarHighlightOnWheel = false;
            this.clientesMetroPanel.VerticalScrollbarSize = 10;
            // 
            // MetroBeLifeForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackImagePadding = new System.Windows.Forms.Padding(3);
            this.BackMaxSize = 60;
            this.Controls.Add(this.formularioTableLayoutPanel);
            this.Name = "MetroBeLifeForm";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.Theme = MetroFramework.MetroThemeStyle.Default;
            this.formularioMetroToolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MetroBeLifeForm_FormClosing);
            this.Load += new System.EventHandler(this.BeLife_Load);
            ((System.ComponentModel.ISupportInitialize)(this.formularioMetroStyleManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.atencionClientePictureBox)).EndInit();
            this.opcionesTableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.formularioPictureBox)).EndInit();
            this.imagenTableLayoutPanel.ResumeLayout(false);
            this.clientesTableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.clientesPictureBox)).EndInit();
            this.contratosTableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.contratosPictureBox)).EndInit();
            this.formularioTableLayoutPanel.ResumeLayout(false);
            this.opcionesMetroPanel.ResumeLayout(false);
            this.contratosMetroPanel.ResumeLayout(false);
            this.clientesMetroPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Components.MetroStyleManager formularioMetroStyleManager;
        private MetroFramework.Components.MetroToolTip formularioMetroToolTip;
        private MetroFramework.Components.MetroStyleExtender formularioMetroStyleExtender;
        private System.Windows.Forms.TableLayoutPanel formularioTableLayoutPanel;
        private MetroFramework.Controls.MetroPanel opcionesMetroPanel;
        private MetroFramework.Controls.MetroButton acercaMetroButton;
        private MetroFramework.Controls.MetroButton preferenciasMetroButton;
        private MetroFramework.Controls.MetroPanel contratosMetroPanel;
        private MetroFramework.Controls.MetroLabel contratosMetroLabel;
        private System.Windows.Forms.PictureBox contratosPictureBox;
        private MetroFramework.Controls.MetroPanel clientesMetroPanel;
        private MetroFramework.Controls.MetroLabel clientesMetroLabel;
        private System.Windows.Forms.PictureBox clientesPictureBox;
        private MetroFramework.Controls.MetroTile darkModeMetroTile;
        private System.Windows.Forms.TableLayoutPanel opcionesTableLayoutPanel;
        private MetroFramework.Controls.MetroTile metroTile;
        private System.Windows.Forms.PictureBox formularioPictureBox;
        private MetroFramework.Controls.MetroLabel opcionesMetroLabel;
        private System.Windows.Forms.TableLayoutPanel imagenTableLayoutPanel;
        private System.Windows.Forms.PictureBox atencionClientePictureBox;
        private System.Windows.Forms.TableLayoutPanel clientesTableLayoutPanel;
        private MetroFramework.Controls.MetroTile maestroClientesMetroTile;
        private MetroFramework.Controls.MetroTile listadoClientesMetroTile;
        private System.Windows.Forms.TableLayoutPanel contratosTableLayoutPanel;
        private MetroFramework.Controls.MetroTile maestroContratosMetroTile;
        private MetroFramework.Controls.MetroTile listadoContratosMetroTile;
        private MetroFramework.Controls.MetroTile recuperarMetroTile;
    }
}