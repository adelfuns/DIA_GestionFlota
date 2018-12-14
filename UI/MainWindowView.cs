namespace ProyectoFlota.UI
{
    using System.Windows.Forms;
    using System.Drawing;
    class MainWindowView: Form
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
            this.MinimumSize = new Size(300, 400);
            this.panelPrincipal = new Panel()
            {
                Size = new Size(this.Width, this.Height),
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                AutoScroll = true
            };
            this.panelOpciones = new Panel()
            {
                // Size = new Size(this.Width, this.Height),
                Dock = DockStyle.Bottom,
                BackColor = Color.White,
                AutoScroll = true
            };

            this.panelPrincipal.SuspendLayout();
            this.panelOpciones.SuspendLayout();

            this.Controls.Add(this.panelPrincipal);
            
            this.BuildPanelListaFlota();
           
            this.panelPrincipal.Controls.Add(this.panelOpciones);
           

            this.panelPrincipal.ResumeLayout(false);
            this.panelOpciones.ResumeLayout(false);

            this.CenterToScreen();
            this.MaximizeBox = true;

            this.Dock = DockStyle.Fill;
            this.Text = "Lista de flotas";
            this.ResumeLayout(true);
        }
        private void BuildMenu()
        {
            this.menuPrincipal = new MainMenu();

            this.menuArchivo = new MenuItem("&Archivo");
            this.menuFlota = new MenuItem("&Flota");
            this.menuAtras = new MenuItem("&Actualizar");

            this.operacionSalir = new MenuItem("&Salir") { Shortcut = Shortcut.CtrlQ };
            //Operaciones de flota
            this.añadirFlota = new MenuItem("&Añadir vehículo a la flota")
            {
                Shortcut = Shortcut.Ctrl0
            };
            this.eliminarFlota = new MenuItem("&Eliminar vehículo de flota")
            {
                Shortcut = Shortcut.Ctrl1
            };
            this.modificarFlota = new MenuItem("&Modificar vehículo de flota")
            {
                Shortcut = Shortcut.Ctrl2
            };
            //Menú superior
            this.menuArchivo.MenuItems.Add(this.operacionSalir);
            this.menuPrincipal.MenuItems.Add(this.menuArchivo);
            this.menuPrincipal.MenuItems.Add(this.menuFlota);
            this.menuPrincipal.MenuItems.Add(this.menuAtras);
            this.Menu = menuPrincipal;
            //Submenú flota
            this.menuFlota.MenuItems.Add(this.añadirFlota);
            this.menuFlota.MenuItems.Add(this.eliminarFlota);
            this.menuFlota.MenuItems.Add(this.modificarFlota);
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
            var column9 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                CellTemplate = textCellTemplate7,
                HeaderText = "Carga",
                ReadOnly = true
            };


            this.grdListaFlota.Columns.AddRange(new DataGridViewColumn[] {
                column0,column9,column1,column2,column3,column4,column5,column6,column7,column8
            });

            this.panelListaFlota.Width = column0.Width + column9.Width + column1.Width + column2.Width + column3.Width + column4.Width + column5.Width + column6.Width + column7.Width + column8.Width;

            panelListaFlota.Controls.Add(this.grdListaFlota);
            panelListaFlota.ResumeLayout(false);

        }
        //Items del menú
        private MainMenu menuPrincipal;
        private MenuItem menuArchivo;
        private MenuItem menuFlota;
       
        public MenuItem menuAtras;

        public Panel panelPrincipal { get; set; }
        public Panel panelOpciones { get; set; }

        public DataGridView grdListaFlota;
        public MenuItem operacionSalir { get; private set; }
        //Operaciones flota
        public MenuItem añadirFlota { get; private set; }
        public MenuItem eliminarFlota { get; private set; }
        public MenuItem modificarFlota { get; private set; }
        

        public TextBox Texto { get; private set; }
        public Panel panelListaFlota;
        public Button btSearchFlota { get; set; }
        public ComboBox escogerBusquedaFlota { get; set; }
    }
}
