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
            this.MinimumSize = new Size(300, 300);
            this.panelPrincipal = new Panel()
            {
                Dock = DockStyle.Fill,
                AutoSize = true,
                AutoScroll = true
            };

            this.panelPrincipal.MinimumSize = new Size(this.Width, this.Height);
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
            this.Text = "Lista de reparaciones";
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
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
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
            textCellTemplate1.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
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


            var column0 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate0,
                HeaderText = "#",
                Width = 50,
                ReadOnly = true
            };

            var column1 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate1,
                HeaderText = "IdTransporte",
                Width = 50,
                ReadOnly = true
            };
            var column2 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate1,
                HeaderText = "Clien",
                Width = 50,
                ReadOnly = true
            };

            var column3 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate1,
                HeaderText = "FechaDeContratación",
                Width = 50,
                ReadOnly = true
            };

            var column4 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate1,
                HeaderText = "KilómetrosRecorridos",
                Width = 50,
                ReadOnly = true
            };
            var column5 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate1,
                HeaderText = "FechaDeSalida",
                Width = 50,
                ReadOnly = true
            };
            var column6 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate1,
                HeaderText = "FechaDeEntrega",
                Width = 50,
                ReadOnly = true
            };
            var column7 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate1,
                HeaderText = "ImportePorDia",
                Width = 50,
                ReadOnly = true
            };
            var column8 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate1,
                HeaderText = "ImportePorKilometro",
                Width = 50,
                ReadOnly = true
            };

            var column9 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate1,
                HeaderText = "IVAAplicado",
                Width = 50,
                ReadOnly = true
            };

            this.grdListaTransporte.Columns.AddRange(new DataGridViewColumn[] {
                column0, column1,column2,column3,column4,column5,column6,column7,column8,column9
            });


            panelListaTransporte.Controls.Add(this.grdListaTransporte);
            panelListaTransporte.ResumeLayout(false);
            

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
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
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



            var column0 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate0,
                HeaderText = "#",
                Width = 50,
                ReadOnly = true
            };

            var column1 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate1,
                HeaderText = "NIF",
                Width = 50,
                ReadOnly = true
            };
            var column2 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate1,
                HeaderText = "Nombre",
                Width = 50,
                ReadOnly = true
            };

            var column3 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate1,
                HeaderText = "Telefono",
                Width = 50,
                ReadOnly = true
            };

            var column4 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate1,
                HeaderText = "Email",
                Width = 50,
                ReadOnly = true
            };
            var column5 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate1,
                HeaderText = "Direccion postal",
                Width = 50,
                ReadOnly = true
            };
            

            this.grdListaCliente.Columns.AddRange(new DataGridViewColumn[] {
                column0, column1,column2,column3,column4,column5
            });


            panelListaCliente.Controls.Add(this.grdListaCliente);
            panelListaCliente.ResumeLayout(false);


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
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
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
            textCellTemplate1.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
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


            var column0 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate0,
                HeaderText = "#",
                Width = 50,
                ReadOnly = true
            };

            var column1 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate1,
                HeaderText = "Matricula",
                Width = 50,
                ReadOnly = true
            };
            var column2 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate1,
                HeaderText = "Tipo",
                Width = 50,
                ReadOnly = true
            };

            var column3 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate1,
                HeaderText = "Marca",
                Width = 50,
                ReadOnly = true
            };

            var column4 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate1,
                HeaderText = "Modelo",
                Width = 50,
                ReadOnly = true
            };
            var column5 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate1,
                HeaderText = "Consumo por km",
                Width = 50,
                ReadOnly = true
            };
            var column6 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate1,
                HeaderText = "Fecha de adquisicion",
                Width = 50,
                ReadOnly = true
            };
            var column7 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate1,
                HeaderText = "Fecha de fabricacion",
                Width = 50,
                ReadOnly = true
            };
            var column8 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate1,
                HeaderText = "Comodidades",
                Width = 50,
                ReadOnly = true
            };



            this.grdListaFlota.Columns.AddRange(new DataGridViewColumn[] {
                column0, column1,column2,column3,column4,column5,column6,column7,column8
            });


            panelListaFlota.Controls.Add(this.grdListaFlota);
            panelListaFlota.ResumeLayout(false);


        }


        //Items del menú
        private MainMenu menuPrincipal;
        private MenuItem menuArchivo;
        private MenuItem menuEditar;
		private MenuItem menuGenerar;
        public Panel panelPrincipal { get; set; }

        public DataGridView grdListaTransporte;
        public DataGridView grdListaCliente;
        public DataGridView grdListaFlota;

        public MenuItem operacionSalir { get; private set; }

        //Operaciones búsqueda
        public MenuItem operacionSearch1 { get; private set; }
        public MenuItem operacionSearch2 { get; private set; }
        public MenuItem operacionSearch3 { get; private set; }
        public MenuItem operacionSearch4 { get; private set; }
        public MenuItem operacionSearch5 { get; private set; }
        public MenuItem operacionSearch6 { get; private set; }
        //Operaciones generar gráficos
		public MenuItem operacionActividadGeneral { get; private set; }
		public MenuItem operacionActividadCliente { get; private set; }
		public MenuItem operacionActividadCamion { get; private set; }
		public MenuItem operacionActividadComodidades { get; private set; }


        public TextBox lTexto { get; private set; }
        public Panel panelListaTransporte;
        public Panel panelListaCliente;
        public Panel panelListaFlota;
        public Panel panelLista;
    }
}
