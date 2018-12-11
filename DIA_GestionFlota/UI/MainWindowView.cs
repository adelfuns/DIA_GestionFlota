namespace DIA_GestionFlota
{
    using System.Windows.Forms;
    using System.Drawing;

    class MainWindowView : Form
    {
        public MainWindowView()
        {
            this.Build();
        }

        private void Build()
        {
            this.BuildMenu();
            this.SuspendLayout();
            this.AutoSize = true;
            this.AutoScroll = true;
            this.WindowState = FormWindowState.Normal;
            //this.MinimumSize = new Size(300, 300);
            this.panelPrincipal = new Panel()
            {
                Size = new Size(this.Width,this.Height),
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                AutoScroll = true
            };

            //this.panelPrincipal.MinimumSize = new Size(this.Width, this.Height);
            this.panelPrincipal.ClientSize = this.ClientSize;
            this.panelPrincipal.SuspendLayout();

            this.Controls.Add(this.panelPrincipal);
            this.BuildPanelListaTransporte();
            this.BuildPanelListaCliente();
            this.BuildPanelListaFlota();


            this.panelPrincipal.Controls.Add(this.panelLista);
            this.panelPrincipal.ResumeLayout(false);


            this.CenterToScreen();
            this.MaximizeBox = true;

            this.Dock = DockStyle.Fill;
            this.Text = "Graficos";
            this.ResumeLayout(true);
        }

        private void BuildMenu()
        {
            this.menuPrincipal = new MainMenu();

            this.menuArchivo = new MenuItem("&Archivo");
            this.menuEditar = new MenuItem("&Buscar");
			this.menuGenerar = new MenuItem("&Generar");

            this.operacionSalir = new MenuItem("&Salir") { Shortcut = Shortcut.CtrlQ };

            //Operaciones búsqueda
            this.operacionSearch1 = new MenuItem("&Buscar transportes pendientes: ")
            {
                Shortcut = Shortcut.Ctrl0
            };
            this.operacionSearch2 = new MenuItem("&Disponibilidad: ")
            {
                Shortcut = Shortcut.Ctrl1
            };
            this.operacionSearch3 = new MenuItem("&Transportes por cliente: ")
            {
                Shortcut = Shortcut.Ctrl2
            };
            this.operacionSearch4 = new MenuItem("&Reservas por camion: ")
            {
                Shortcut = Shortcut.Ctrl3
            };
            this.operacionSearch5 = new MenuItem("&Reservas por cliente: ")
            {
                Shortcut = Shortcut.Ctrl4
            };
            this.operacionSearch6 = new MenuItem("&Ocupacion: ")
            {
                Shortcut = Shortcut.Ctrl5
            };

			//Operaciones generar gráfico
			this.operacionActividadGeneral = new MenuItem("&Generar gráfico actvidad general: ")
            {
                Shortcut = Shortcut.Ctrl6
            };
			this.operacionActividadCliente = new MenuItem("&Generar gráfico actvidad cliente: ")
            {
                Shortcut = Shortcut.Ctrl7
            };
			this.operacionActividadCamion = new MenuItem("&Generar gráfico actvidad camión: ")
            {
                Shortcut = Shortcut.Ctrl8
            };
			this.operacionActividadComodidades = new MenuItem("&Generar gráfico comodidades: ")
            {
                Shortcut = Shortcut.Ctrl9
            };


			//Menú superior
			this.menuArchivo.MenuItems.Add(this.operacionSalir);
            this.menuPrincipal.MenuItems.Add(this.menuArchivo);
            this.menuPrincipal.MenuItems.Add(this.menuEditar);
			this.menuPrincipal.MenuItems.Add(this.menuGenerar);
            this.Menu = menuPrincipal;
            //Submenú búsqueda
            this.menuEditar.MenuItems.Add(this.operacionSearch1);
            this.menuEditar.MenuItems.Add(this.operacionSearch2);
            this.menuEditar.MenuItems.Add(this.operacionSearch3);
            this.menuEditar.MenuItems.Add(this.operacionSearch4);
            this.menuEditar.MenuItems.Add(this.operacionSearch5);
            this.menuEditar.MenuItems.Add(this.operacionSearch6);
			//Submenú gráficos
			this.menuGenerar.MenuItems.Add(this.operacionActividadGeneral);
			this.menuGenerar.MenuItems.Add(this.operacionActividadCliente);
			this.menuGenerar.MenuItems.Add(this.operacionActividadCamion);
			this.menuGenerar.MenuItems.Add(this.operacionActividadComodidades);
            

        }  

        private void BuildPanelListaTransporte()
        {
            panelListaTransporte = new Panel();
            panelListaTransporte.SuspendLayout();
            panelListaTransporte.Dock = DockStyle.Fill;

            // Crear gridview
            this.grdListaTransporte = new DataGridView()
            {
                Dock = DockStyle.Fill,
                AllowUserToResizeRows = false,
                RowHeadersVisible = false,
                AutoGenerateColumns = false,
                MultiSelect = false,
                AllowUserToAddRows = false,
                EnableHeadersVisualStyles = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BackgroundColor = Color.White
            };

            this.grdListaTransporte.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            this.grdListaTransporte.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;

            var textCellTemplate0 = new DataGridViewTextBoxCell();
            var textCellTemplate1 = new DataGridViewTextBoxCell();
            var textCellTemplate2 = new DataGridViewTextBoxCell();
            var textCellTemplate3 = new DataGridViewTextBoxCell();
            var textCellTemplate4 = new DataGridViewTextBoxCell();
            var textCellTemplate5 = new DataGridViewTextBoxCell();
            var textCellTemplate6 = new DataGridViewTextBoxCell();
            var textCellTemplate7 = new DataGridViewTextBoxCell();
            var textCellTemplate8 = new DataGridViewTextBoxCell();
            var textCellTemplate9 = new DataGridViewTextBoxCell();

            textCellTemplate0.Style.BackColor = Color.LightGray;
            textCellTemplate0.Style.ForeColor = Color.Black;
            textCellTemplate1.Style.BackColor = Color.Wheat;
            textCellTemplate1.Style.ForeColor = Color.Black;
            textCellTemplate2.Style.BackColor = Color.Wheat;
            textCellTemplate2.Style.ForeColor = Color.Black;
            textCellTemplate3.Style.BackColor = Color.Wheat;
            textCellTemplate3.Style.ForeColor = Color.Black;
            textCellTemplate4.Style.BackColor = Color.Wheat;
            textCellTemplate4.Style.ForeColor = Color.Black;
            textCellTemplate5.Style.BackColor = Color.Wheat;
            textCellTemplate5.Style.ForeColor = Color.Black;
            textCellTemplate6.Style.BackColor = Color.Wheat;
            textCellTemplate6.Style.ForeColor = Color.Black;
            textCellTemplate7.Style.BackColor = Color.Wheat;
            textCellTemplate7.Style.ForeColor = Color.Black;
            textCellTemplate8.Style.BackColor = Color.Wheat;
            textCellTemplate8.Style.ForeColor = Color.Black;
            textCellTemplate9.Style.BackColor = Color.Wheat;
            textCellTemplate9.Style.ForeColor = Color.Black;

            textCellTemplate0.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            textCellTemplate1.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            textCellTemplate2.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            textCellTemplate3.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            textCellTemplate4.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            textCellTemplate5.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            textCellTemplate6.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            textCellTemplate7.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            textCellTemplate8.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            textCellTemplate9.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
  

            var column0 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                CellTemplate = textCellTemplate0,
                HeaderText = "#",
                
                ReadOnly = true
            };

            var column1 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                CellTemplate = textCellTemplate1,
                HeaderText = "IdTransporte",
              
                ReadOnly = true
            };
            var column2 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                CellTemplate = textCellTemplate2,
                HeaderText = "Cliente",
               
                ReadOnly = true
            };

            var column3 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                CellTemplate = textCellTemplate3,
                HeaderText = "FechaDeContratación",
                
                ReadOnly = true
            };

            var column4 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                CellTemplate = textCellTemplate4,
                HeaderText = "KilómetrosRecorridos",
                
                ReadOnly = true
            };
            var column5 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                CellTemplate = textCellTemplate5,
                HeaderText = "FechaDeSalida",
                
                ReadOnly = true
            };
            var column6 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                CellTemplate = textCellTemplate6,
                HeaderText = "FechaDeEntrega",
                
                ReadOnly = true
            };
            var column7 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                CellTemplate = textCellTemplate7,
                HeaderText = "ImportePorDia",
             
                ReadOnly = true
            };
            var column8 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                CellTemplate = textCellTemplate8,
                HeaderText = "ImportePorKilometro",
               
                ReadOnly = true
            };

            var column9 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                CellTemplate = textCellTemplate9,
                HeaderText = "IVAAplicado",
               
                ReadOnly = true
            };

            this.grdListaTransporte.Columns.AddRange(new DataGridViewColumn[] {
                column0, column1,column2,column3,column4,column5,column6,column7,column8,column9
            });


            panelListaTransporte.Controls.Add(this.grdListaTransporte);
            panelListaTransporte.ResumeLayout(false);
            this.panelListaTransporte.Width = column0.Width + column1.Width + column2.Width + column3.Width + column4.Width + column5.Width + column6.Width + column7.Width + column8.Width + column9.Width ;


        }

        private void BuildPanelListaCliente()
        {
            panelListaCliente = new Panel();
            panelListaCliente.SuspendLayout();
            panelListaCliente.Dock = DockStyle.Fill;

            // Crear gridview
            this.grdListaCliente = new DataGridView()
            {
                Dock = DockStyle.Fill,
                AllowUserToResizeRows = false,
                RowHeadersVisible = false,
                AutoGenerateColumns = false,
                MultiSelect = false,
                AllowUserToAddRows = false,
                EnableHeadersVisualStyles = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BackgroundColor = Color.White
            };

            this.grdListaCliente.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            this.grdListaCliente.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;

            var textCellTemplate0 = new DataGridViewTextBoxCell();
            var textCellTemplate1 = new DataGridViewTextBoxCell();
            var textCellTemplate2 = new DataGridViewTextBoxCell();
            var textCellTemplate3 = new DataGridViewTextBoxCell();
            var textCellTemplate4 = new DataGridViewTextBoxCell();
            var textCellTemplate5 = new DataGridViewTextBoxCell();


            textCellTemplate0.Style.BackColor = Color.LightGray;
            textCellTemplate0.Style.ForeColor = Color.Black;
            textCellTemplate1.Style.BackColor = Color.Wheat;
            textCellTemplate1.Style.ForeColor = Color.Black;
            textCellTemplate1.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            textCellTemplate2.Style.BackColor = Color.Wheat;
            textCellTemplate2.Style.ForeColor = Color.Black;
            textCellTemplate3.Style.BackColor = Color.Wheat;
            textCellTemplate3.Style.ForeColor = Color.Black;
            textCellTemplate4.Style.BackColor = Color.Wheat;
            textCellTemplate4.Style.ForeColor = Color.Black;
            textCellTemplate5.Style.BackColor = Color.Wheat;
            textCellTemplate5.Style.ForeColor = Color.Black;

            textCellTemplate0.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            textCellTemplate1.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            textCellTemplate2.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            textCellTemplate3.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            textCellTemplate4.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            textCellTemplate5.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


            var column0 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                CellTemplate = textCellTemplate0,
                HeaderText = "#",
                Width = 30,
                ReadOnly = true
            };

            var column1 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                CellTemplate = textCellTemplate1,
                HeaderText = "NIF",
                Width = 100,
                ReadOnly = true
            };
            var column2 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                CellTemplate = textCellTemplate2,
                HeaderText = "Nombre",
                Width = 100,
                ReadOnly = true
            };

            var column3 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                CellTemplate = textCellTemplate3,
                HeaderText = "Telefono",
                Width = 100,
                ReadOnly = true
            };

            var column4 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                CellTemplate = textCellTemplate4,
                HeaderText = "Email",
                Width = 100,
                ReadOnly = true
            };
            var column5 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                CellTemplate = textCellTemplate5,
                HeaderText = "Direccion postal",
                Width = 100,
                ReadOnly = true
            };
            

            this.grdListaCliente.Columns.AddRange(new DataGridViewColumn[] {
                column0, column1,column2,column3,column4,column5
            });


            panelListaCliente.Controls.Add(this.grdListaCliente);
            panelListaCliente.ResumeLayout(false);
            this.panelListaCliente.Width = column0.Width + column1.Width + column2.Width + column3.Width + column4.Width + column5.Width;


        }

        private void BuildPanelListaFlota()
        {
            panelListaFlota = new Panel();
            panelListaFlota.SuspendLayout();
            panelListaFlota.Dock = DockStyle.Fill;

            // Crear gridview
            this.grdListaFlota = new DataGridView()
            {
                Dock = DockStyle.Fill,
                AllowUserToResizeRows = false,
                RowHeadersVisible = false,
                AutoGenerateColumns = false,
                MultiSelect = false,
                AllowUserToAddRows = false,
                EnableHeadersVisualStyles = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BackgroundColor = Color.White
            };

            this.grdListaFlota.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            this.grdListaFlota.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;

            var textCellTemplate0 = new DataGridViewTextBoxCell();
            var textCellTemplate1 = new DataGridViewTextBoxCell();
            var textCellTemplate2 = new DataGridViewTextBoxCell();
            var textCellTemplate3 = new DataGridViewTextBoxCell();
            var textCellTemplate4 = new DataGridViewTextBoxCell();
            var textCellTemplate5 = new DataGridViewTextBoxCell();
            var textCellTemplate6 = new DataGridViewTextBoxCell();
            var textCellTemplate7 = new DataGridViewTextBoxCell();
            var textCellTemplate8 = new DataGridViewTextBoxCell();

            textCellTemplate0.Style.BackColor = Color.LightGray;
            textCellTemplate0.Style.ForeColor = Color.Black;
            textCellTemplate1.Style.BackColor = Color.Wheat;
            textCellTemplate1.Style.ForeColor = Color.Black;
            textCellTemplate2.Style.BackColor = Color.Wheat;
            textCellTemplate2.Style.ForeColor = Color.Black;
            textCellTemplate3.Style.BackColor = Color.Wheat;
            textCellTemplate3.Style.ForeColor = Color.Black;
            textCellTemplate4.Style.BackColor = Color.Wheat;
            textCellTemplate4.Style.ForeColor = Color.Black;
            textCellTemplate5.Style.BackColor = Color.Wheat;
            textCellTemplate5.Style.ForeColor = Color.Black;
            textCellTemplate6.Style.BackColor = Color.Wheat;
            textCellTemplate6.Style.ForeColor = Color.Black;
            textCellTemplate7.Style.BackColor = Color.Wheat;
            textCellTemplate7.Style.ForeColor = Color.Black;
            textCellTemplate8.Style.BackColor = Color.Wheat;
            textCellTemplate8.Style.ForeColor = Color.Black;

            textCellTemplate0.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            textCellTemplate1.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            textCellTemplate2.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            textCellTemplate3.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            textCellTemplate4.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            textCellTemplate5.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            textCellTemplate6.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            textCellTemplate7.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            textCellTemplate8.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


            var column0 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                CellTemplate = textCellTemplate0,
                HeaderText = "#",
                
                ReadOnly = true
            };

            var column1 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                CellTemplate = textCellTemplate1,
                HeaderText = "Matricula",
                
                ReadOnly = true
            };
            var column2 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                CellTemplate = textCellTemplate2,
                HeaderText = "Tipo",
               
                ReadOnly = true
            };

            var column3 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                CellTemplate = textCellTemplate3,
                HeaderText = "Marca",
                
                ReadOnly = true
            };

            var column4 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                CellTemplate = textCellTemplate4,
                HeaderText = "Modelo",
               
                ReadOnly = true
            };
            var column5 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                CellTemplate = textCellTemplate5,
                HeaderText = "Consumo por km",
                
                ReadOnly = true
            };
            var column6 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                CellTemplate = textCellTemplate6,
                HeaderText = "Fecha de adquisicion",
                
                ReadOnly = true
            };
            var column7 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                CellTemplate = textCellTemplate7,
                HeaderText = "Fecha de fabricacion",
                
                ReadOnly = true
            };
            var column8 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                CellTemplate = textCellTemplate8,
                HeaderText = "Comodidades",
               
                ReadOnly = true
                
            };



            this.grdListaFlota.Columns.AddRange(new DataGridViewColumn[] {
                column0, column1,column2,column3,column4,column5,column6,column7,column8
            });


            panelListaFlota.Controls.Add(this.grdListaFlota);
            panelListaFlota.ResumeLayout(false);

            this.panelListaFlota.Width = column0.Width + column1.Width + column2.Width + column3.Width + column4.Width + column5.Width + column6.Width + column7.Width + column8.Width;

        }
        
        public void BuildPanelGraficoGeneral()
        {
            panelGraficoGeneral = new Panel();
            panelGraficoGeneral.SuspendLayout();
            panelGraficoGeneral.Dock = DockStyle.Fill;

            this.Chart = new Chart(width: CHART_CANVAS_SIZE,
                                    height: CHART_CANVAS_SIZE)
            {
                Dock = DockStyle.Fill,
            };

            //Comprobar si es antes o después del ResumenLayout
            this.MinimumSize = new Size(CHART_CANVAS_SIZE, CHART_CANVAS_SIZE);
            this.Text = this.GetType().Name;
            panelGraficoGeneral.Controls.Add(this.Chart); //Aquí añadir el gráfico a introducir
            panelGraficoGeneral.ResumeLayout(false);
        }

        public void setDataChart(string x, string y, int[] values)
        {
            this.Chart.LegendY = y;
            this.Chart.LegendX = x;
            this.Chart.Values = values;
        }

        public void setDataLegend(string[] a)
        {
            this.Chart.ValuesDraw = a;
        }

        public TextBox lTexto { get; private set; }

        //Menús
        private MainMenu menuPrincipal;
        private MenuItem menuArchivo;
        private MenuItem menuEditar;
        private MenuItem menuGenerar;
        public MenuItem operacionSearch1 { get; private set; } //Busqueda
        public MenuItem operacionSearch2 { get; private set; } //Busqueda
        public MenuItem operacionSearch3 { get; private set; } //Busqueda
        public MenuItem operacionSearch4 { get; private set; } //Busqueda
        public MenuItem operacionSearch5 { get; private set; } //Busqueda
        public MenuItem operacionSearch6 { get; private set; } //Busqueda
		public MenuItem operacionActividadGeneral { get; private set; }       //Gráficos
		public MenuItem operacionActividadCliente { get; private set; }       //Gráficos
		public MenuItem operacionActividadCamion { get; private set; }        //Gráficos
		public MenuItem operacionActividadComodidades { get; private set; }   //Gráficos
        public MenuItem operacionSalir { get; private set; }

        //Representación de datos de las búsquedas
        public DataGridView grdListaTransporte;
        public DataGridView grdListaCliente;
        public DataGridView grdListaFlota;

        //Representación de gráficos
        public const int CHART_CANVAS_SIZE = 624;
        public Chart Chart {get; private set;}

        //Paneles
        public Panel panelPrincipal { get; set; }
        public Panel panelListaTransporte; //Búsqueda
        public Panel panelListaCliente; //Búsqueda
        public Panel panelListaFlota; //Búsqueda
        public Panel panelLista; //Búsqueda
        public Panel panelGraficoGeneral;   //Gráficos

        
    }
}
