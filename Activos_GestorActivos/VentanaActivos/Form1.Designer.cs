namespace VentanaActivos
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            PanelCabecera = new Panel();
            descripcionMenu = new Label();
            btnPanelMenu = new Button();
            logo = new PictureBox();
            PanelCentral = new Panel();
            btn_Actualizar = new Button();
            TablaActivos = new DataGridView();
            timerPanelMenu = new System.Windows.Forms.Timer(components);
            PanelMenu = new Panel();
            ventanaActivos = new Button();
            ventanaDashboard = new Button();
            ventanaCerrarSesion = new Button();
            PanelCabecera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            PanelCentral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TablaActivos).BeginInit();
            PanelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // PanelCabecera
            // 
            PanelCabecera.Controls.Add(descripcionMenu);
            PanelCabecera.Controls.Add(btnPanelMenu);
            PanelCabecera.Controls.Add(logo);
            PanelCabecera.Dock = DockStyle.Top;
            PanelCabecera.Location = new Point(0, 0);
            PanelCabecera.Name = "PanelCabecera";
            PanelCabecera.Size = new Size(1265, 60);
            PanelCabecera.TabIndex = 1;
            // 
            // descripcionMenu
            // 
            descripcionMenu.AutoSize = true;
            descripcionMenu.Font = new Font("Segoe UI", 10F);
            descripcionMenu.ForeColor = SystemColors.Control;
            descripcionMenu.Location = new Point(1117, 18);
            descripcionMenu.Name = "descripcionMenu";
            descripcionMenu.Size = new Size(54, 23);
            descripcionMenu.TabIndex = 7;
            descripcionMenu.Text = "Menú";
            descripcionMenu.Click += descripcionCabecera_Click;
            // 
            // btnPanelMenu
            // 
            btnPanelMenu.BackColor = SystemColors.Control;
            btnPanelMenu.BackgroundImageLayout = ImageLayout.Zoom;
            btnPanelMenu.FlatAppearance.BorderSize = 0;
            btnPanelMenu.FlatStyle = FlatStyle.Flat;
            btnPanelMenu.Image = Properties.Resources.iconohamburguesa;
            btnPanelMenu.Location = new Point(1171, 3);
            btnPanelMenu.Name = "btnPanelMenu";
            btnPanelMenu.Size = new Size(88, 54);
            btnPanelMenu.TabIndex = 6;
            btnPanelMenu.UseVisualStyleBackColor = false;
            btnPanelMenu.Click += btnPanelMenu_Click;
            // 
            // logo
            // 
            logo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            logo.Image = (Image)resources.GetObject("logo.Image");
            logo.Location = new Point(3, 6);
            logo.Name = "logo";
            logo.Size = new Size(250, 51);
            logo.TabIndex = 0;
            logo.TabStop = false;
            logo.Click += logo_Click;
            // 
            // PanelCentral
            // 
            PanelCentral.Controls.Add(btn_Actualizar);
            PanelCentral.Controls.Add(TablaActivos);
            PanelCentral.Dock = DockStyle.Fill;
            PanelCentral.Location = new Point(0, 0);
            PanelCentral.Name = "PanelCentral";
            PanelCentral.Size = new Size(1265, 725);
            PanelCentral.TabIndex = 0;
            PanelCentral.Paint += PanelCentral_Paint;
            // 
            // btn_Actualizar
            // 
            btn_Actualizar.Location = new Point(448, 646);
            btn_Actualizar.Name = "btn_Actualizar";
            btn_Actualizar.Size = new Size(375, 29);
            btn_Actualizar.TabIndex = 2;
            btn_Actualizar.Text = "Actualizar";
            btn_Actualizar.UseVisualStyleBackColor = true;
            btn_Actualizar.Click += btn_Actualizar_Click;
            // 
            // TablaActivos
            // 
            TablaActivos.BorderStyle = BorderStyle.None;
            TablaActivos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TablaActivos.EnableHeadersVisualStyles = false;
            TablaActivos.Location = new Point(12, 63);
            TablaActivos.Name = "TablaActivos";
            TablaActivos.RowHeadersVisible = false;
            TablaActivos.RowHeadersWidth = 51;
            TablaActivos.Size = new Size(1241, 139);
            TablaActivos.TabIndex = 1;
            TablaActivos.CellContentClick += TablaActivos_CellContentClick;
            // 
            // timerPanelMenu
            // 
            timerPanelMenu.Interval = 10;
            timerPanelMenu.Tick += timerPanelMenu_Tick;
            // 
            // PanelMenu
            // 
            PanelMenu.Controls.Add(ventanaActivos);
            PanelMenu.Controls.Add(ventanaDashboard);
            PanelMenu.Controls.Add(ventanaCerrarSesion);
            PanelMenu.Dock = DockStyle.Right;
            PanelMenu.Location = new Point(1265, 60);
            PanelMenu.Name = "PanelMenu";
            PanelMenu.Size = new Size(0, 665);
            PanelMenu.TabIndex = 4;
            // 
            // ventanaActivos
            // 
            ventanaActivos.Dock = DockStyle.Top;
            ventanaActivos.Location = new Point(0, 30);
            ventanaActivos.Name = "ventanaActivos";
            ventanaActivos.Size = new Size(0, 30);
            ventanaActivos.TabIndex = 6;
            ventanaActivos.Text = "Activos";
            ventanaActivos.UseVisualStyleBackColor = true;
            // 
            // ventanaDashboard
            // 
            ventanaDashboard.Dock = DockStyle.Top;
            ventanaDashboard.Location = new Point(0, 0);
            ventanaDashboard.Name = "ventanaDashboard";
            ventanaDashboard.Size = new Size(0, 30);
            ventanaDashboard.TabIndex = 5;
            ventanaDashboard.Text = "Dashboard";
            ventanaDashboard.UseVisualStyleBackColor = true;
            // 
            // ventanaCerrarSesion
            // 
            ventanaCerrarSesion.Dock = DockStyle.Bottom;
            ventanaCerrarSesion.Location = new Point(0, 635);
            ventanaCerrarSesion.Name = "ventanaCerrarSesion";
            ventanaCerrarSesion.Size = new Size(0, 30);
            ventanaCerrarSesion.TabIndex = 8;
            ventanaCerrarSesion.Text = "Cerrar Sesion";
            ventanaCerrarSesion.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1265, 725);
            Controls.Add(PanelMenu);
            Controls.Add(PanelCabecera);
            Controls.Add(PanelCentral);
            Name = "Form1";
            Text = "Form1";
            PanelCabecera.ResumeLayout(false);
            PanelCabecera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)logo).EndInit();
            PanelCentral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)TablaActivos).EndInit();
            PanelMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelCabecera;
        private Panel PanelCabecera;
        private Panel PanelCentral;
        private DataGridView TablaActivos;
        private Button btn_Actualizar;
        private PictureBox logo;
        private System.Windows.Forms.Timer timerPanelMenu;
        private Button btnPanelMenu;
        private Panel PanelMenu;
        private Button ventanaDashboard;
        private Button ventanaActivos;
        private Button ventanaCerrarSesion;
        private Label descripcionMenu;
    }
}
