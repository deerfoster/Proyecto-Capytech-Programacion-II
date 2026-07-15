using System.Windows.Forms.DataVisualization.Charting;

namespace VentanaActivos
{
    public partial class Form1 : Form
    {
        private GestorActivos _gestorActivos;

        public Form1()
        {
            InitializeComponent();
        }

        private bool menuExpandido = false;
        private Chart GraficaPrecios;

        public Form1(GestorActivos gestorRecibido) : this()
        {
            _gestorActivos = gestorRecibido;

            logo.SizeMode = PictureBoxSizeMode.Zoom;
            logo.Dock = DockStyle.Left;

            // colores al fondo de los paneles y botones//
            this.BackColor = Color.FromArgb(248, 249, 252);
            PanelCentral.BackColor = Color.FromArgb(255, 255, 255);
            PanelCabecera.BackColor = Color.FromArgb(44, 24, 82);
            btn_Actualizar.BackColor = Color.FromArgb(0, 184, 110);

            //boton actualizar activos//
            btn_Actualizar.FlatStyle = FlatStyle.Flat;
            btn_Actualizar.FlatAppearance.BorderSize = 0;
            btn_Actualizar.ForeColor = Color.White;
            //TablaActivos.Columns["PrecioActual"].DefaultCellStyle.Format = "N2";

            //boton panel menu//
            btnPanelMenu.BackColor = Color.FromArgb(44, 24, 82);
            btnPanelMenu.BackgroundImage = Image.FromFile("iconohamburguesa.png");
            btnPanelMenu.BackgroundImageLayout = ImageLayout.Zoom;
            btnPanelMenu.Text = "";

            //panel menu//
            PanelMenu.BackColor = Color.FromArgb(44, 24, 82);

            ventanaDashboard.ForeColor = Color.White;
            ventanaDashboard.BackColor = Color.FromArgb(44, 24, 82);
            ventanaDashboard.FlatStyle = FlatStyle.Flat;
            ventanaDashboard.FlatAppearance.BorderSize = 0;

            ventanaActivos.ForeColor = Color.White;
            ventanaActivos.BackColor = Color.FromArgb(44, 24, 82);
            ventanaActivos.FlatStyle = FlatStyle.Flat;
            ventanaActivos.FlatAppearance.BorderSize = 0;

            ventanaCerrarSesion.ForeColor = Color.White;
            ventanaCerrarSesion.BackColor = Color.FromArgb(44, 24, 82);
            ventanaCerrarSesion.FlatStyle = FlatStyle.Flat;
            ventanaCerrarSesion.FlatAppearance.BorderSize = 0;

            //panel central//
            GraficaPrecios = new Chart();
            GraficaPrecios.Width = 1000;
            GraficaPrecios.Height = 250;

            GraficaPrecios.Location = new Point(220, 220);

            ChartArea areaGrafica = new ChartArea("AreaPrincipal");
            GraficaPrecios.ChartAreas.Add(areaGrafica);

            Legend leyenda = new Legend("LeyendaPrincipal");
            leyenda.Docking = Docking.Right;
            GraficaPrecios.Legends.Add(leyenda);
            PanelCentral.Controls.Add(GraficaPrecios);

            PanelCentral.Controls.Add(GraficaPrecios);

            foreach (var activo in _gestorActivos.ObtenerTodosLosActivos())
            {
                if (activo.HistoricoPrecios.Count == 0)
                {
                    activo.HistoricoPrecios.Add(activo.PrecioActual);
                }
            }



            //posicion paneles//
            PanelCentral.Padding = new Padding(0, PanelCabecera.Height, 0, 0);

            //tabla de activos//
            TablaActivos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 24, 82);
            TablaActivos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            TablaActivos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            TablaActivos.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            TablaActivos.EnableHeadersVisualStyles = false;
            TablaActivos.BackgroundColor = Color.White;
            TablaActivos.BorderStyle = BorderStyle.None;
            TablaActivos.DataSource = _gestorActivos.ObtenerTodosLosActivos();
            TablaActivos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;



            ActualizarGrafica();
        }
        private void ActualizarGrafica()
        {
            GraficaPrecios.Series.Clear();
            GraficaPrecios.ChartAreas[0].AxisY.IsStartedFromZero = false;

            foreach (var activo in _gestorActivos.ObtenerTodosLosActivos())
            {

                Series serie = new Series(activo.NombreActivo);

                serie.Legend = "LeyendaPrincipal";

                serie.ChartType = SeriesChartType.Spline;
                serie.BorderWidth = 3;

                for (int i = 0; i < activo.HistoricoPrecios.Count; i++)
                {
                    serie.Points.AddXY(i + 1, (double)activo.HistoricoPrecios[i]);
                }

                GraficaPrecios.Series.Add(serie);
            }
        }
        private void PanelCentral_Paint(object sender, PaintEventArgs e)
        {
        }

        private void TablaActivos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TituloCabecera_Click(object sender, EventArgs e)
        {

        }

        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            try
            {
                _gestorActivos.ActualizarPrecios();
                TablaActivos.DataSource = null;
                TablaActivos.DataSource = _gestorActivos.ObtenerTodosLosActivos();

                ActualizarGrafica();

                if (TablaActivos.Columns["PrecioActual"] != null)
                {
                    TablaActivos.Columns["PrecioActual"].DefaultCellStyle.Format = "N2";
                }

                TablaActivos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al actualizar los precios.");
            }
        }

        private void logo_Click(object sender, EventArgs e)
        {

        }

        private void btnPanelMenu_Click(object sender, EventArgs e)
        {
            timerPanelMenu.Start();
        }

        private void timerPanelMenu_Tick(object sender, EventArgs e)
        {
            if (menuExpandido == false)
            {
                PanelMenu.Width += 10;
                if (PanelMenu.Width >= 200)
                {
                    timerPanelMenu.Stop();
                    menuExpandido = true;
                }
            }
            else
            {
                PanelMenu.Width -= 10;
                if (PanelMenu.Width <= 0)
                {
                    timerPanelMenu.Stop();
                    menuExpandido = false;
                }
            }
        }

        private void PanelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void descripcionCabecera_Click(object sender, EventArgs e)
        {

        }
    }
}
