using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DIA_GestionFlota;
using GestionFlota.Core;

namespace GestionFlota.UI
{
    public partial class MainWindowViewReservas : Form
    {
        public MainWindowViewReservas()
        {
            this.Build();
        }

        public TextBox tbReservas { get; private set; }
        public TextBox tbIdTransp { get; private set; }
        public TextBox tbCliente { get; private set; }
        public TextBox tbTipoTrans { get; private set; }
        public TextBox tbFcontra { get; private set; }
        public TextBox tbFsalida { get; private set; }
        public TextBox tbFentrega { get; private set; }
        public TextBox tbEDia { get; private set; }
        public TextBox tbEkm { get; private set; }
        public TextBox tbKmRecorridos { get; private set; }
        public TextBox tbGas { get; private set; }
        public TextBox tbSuplencia { get; private set; }
        public TextBox tbIVA { get; private set; }
        public TextBox tbPrecioFactura { get; set; }
        public Button CreateReserva { get; private set; }
        public Button RemoveReserva { get; private set; }
        public Button EditFindReserva { get; private set; }
        public Button EditReserva { get; private set; }
        public TextBox EdMsg { get; private set; }

        public DataGridView grdEventsList;

        private Panel pnlInfo;
        private Panel pnlEventsContainer;
        public DataGridViewCellEventArgs evt { get; private set; }

        void Build()
        {
            this.inicializarBotones();
            this.dialogos = new Panel() { Dock = DockStyle.Right };
            this.dialogosGrande = new Panel() { Dock = DockStyle.Right };


            BoxAdd = new TableLayoutPanel() { Dock = DockStyle.Right };
            BoxMsg = new TableLayoutPanel() { Dock = DockStyle.Bottom };
            this.BuildMenu();
            this.buildPanelReservas();

            panelAdd1 = this.buildPanelAdd1();
            panelAdd2 = this.buildPanelAdd2();
            panelAdd3 = this.buildPanelAdd3();
            panelAdd4 = this.buildPanelAdd4();
            panelAdd5 = this.buildPanelAdd5();
            panelAdd6 = this.buildPanelAdd6();
            panelAdd7 = this.buildPanelAdd7();
            panelAdd8 = this.buildPanelAdd8();
            panelAdd9 = this.buildPanelAdd9();
            panelAdd10 = this.buildPanelAdd10();
            panelAdd11 = this.buildPanelAdd11();
            panelAdd12 = this.buildPanelAdd12();
            panelAdd13 = this.buildPanelAdd13();

            var panelMsg = this.buildPanelMsg();

            BoxAdd.Controls.Add(panelAdd1);
            BoxAdd.Controls.Add(panelAdd2);
            BoxAdd.Controls.Add(panelAdd3);
            BoxAdd.Controls.Add(panelAdd4);
            BoxAdd.Controls.Add(panelAdd5);
            BoxAdd.Controls.Add(panelAdd6);
            BoxAdd.Controls.Add(panelAdd7);
            BoxAdd.Controls.Add(panelAdd8);
            BoxAdd.Controls.Add(panelAdd9);
            BoxAdd.Controls.Add(panelAdd10);
            BoxAdd.Controls.Add(panelAdd11);
            BoxAdd.Controls.Add(panelAdd12);
            BoxAdd.Controls.Add(panelAdd13);


            BoxAdd.BorderStyle = BorderStyle.FixedSingle;

            BoxMsg.Controls.Add(panelMsg);


            this.Controls.Add(this.grdEventsList);
        
            this.dialogosGrande.Controls.Add(this.dialogos); 
            this.Controls.Add(this.dialogosGrande);

            this.Controls.Add(BoxMsg);

            this.Resize += (obj, args) => this.OnResizeWindow(obj, args);

            BoxMsg.Height -= 75;
            BoxAdd.Width += 100;
            this.dialogosGrande.Width = BoxAdd.Width;
            this.MinimumSize = new Size(1500, 600);
            this.Text = "Gestion Reservas";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.CenterToScreen();
            this.Show();
        }

        private void buildPanelReservas()
        {

            RemoveReserva = new Button();
            EditFindReserva = new Button();

            this.grdEventsList = new DataGridView();

            this.grdEventsList.Dock = DockStyle.Fill;
            this.grdEventsList.AllowUserToResizeRows = false;
            this.grdEventsList.RowHeadersVisible = false;
            this.grdEventsList.AutoGenerateColumns = false;
            this.grdEventsList.MultiSelect = false;
            this.grdEventsList.AllowUserToAddRows = false;

            var textCellTemplate = new DataGridViewTextBoxCell();
            var imageEditTemplate = new DataGridViewButtonCell();
            var imageDeleteTemplate = new DataGridViewButtonCell();
            textCellTemplate.Style.BackColor = Color.Wheat;
            imageEditTemplate.UseColumnTextForButtonValue = true;
            imageDeleteTemplate.UseColumnTextForButtonValue = true;

            var column0 = new DataGridViewTextBoxColumn();
            var column1 = new DataGridViewTextBoxColumn();
            var column2 = new DataGridViewTextBoxColumn();
            var column3 = new DataGridViewTextBoxColumn();
            var column4 = new DataGridViewTextBoxColumn();
            var column5 = new DataGridViewTextBoxColumn();
            var column6 = new DataGridViewTextBoxColumn();
            var column7 = new DataGridViewTextBoxColumn();
            var column8 = new DataGridViewTextBoxColumn();
            var column9 = new DataGridViewTextBoxColumn();
            var column10 = new DataGridViewTextBoxColumn();
            var column11 = new DataGridViewTextBoxColumn();
            var column12 = new DataGridViewTextBoxColumn();
            var column13 = new DataGridViewButtonColumn();
            var column14 = new DataGridViewButtonColumn();


            column0.CellTemplate = textCellTemplate;
            column1.CellTemplate = textCellTemplate;
            column2.CellTemplate = textCellTemplate;
            column3.CellTemplate = textCellTemplate;
            column4.CellTemplate = textCellTemplate;
            column5.CellTemplate = textCellTemplate;
            column6.CellTemplate = textCellTemplate;
            column7.CellTemplate = textCellTemplate;
            column8.CellTemplate = textCellTemplate;
            column9.CellTemplate = textCellTemplate;
            column10.CellTemplate = textCellTemplate;
            column11.CellTemplate = textCellTemplate;
            column12.CellTemplate = textCellTemplate;
            column13.CellTemplate = imageDeleteTemplate;
            column14.CellTemplate = imageEditTemplate;

            column13.Text = "Eliminar";
            column14.Text = "Editar";

            column0.HeaderText = "IDTransporte";
            column0.Width = 75;
            column0.SortMode = DataGridViewColumnSortMode.Automatic;
            column1.HeaderText = "Cliente";
            column1.Width = 150;
            column1.SortMode = DataGridViewColumnSortMode.Automatic;
            column2.HeaderText = "TipoTransporte";
            column2.Width = 75;
            column2.SortMode = DataGridViewColumnSortMode.NotSortable;
            column3.HeaderText = "FechaContratacion";
            column3.Width = 150;
            column3.SortMode = DataGridViewColumnSortMode.NotSortable;
            column4.HeaderText = "Fecha salida";
            column4.Width = 150;
            column4.SortMode = DataGridViewColumnSortMode.NotSortable;

            column5.HeaderText = "Fecha entrega";
            column5.Width = 150;
            column5.SortMode = DataGridViewColumnSortMode.NotSortable;
            column6.HeaderText = "Importe dia";
            column6.Width = 150;
            column6.SortMode = DataGridViewColumnSortMode.NotSortable;

            column7.HeaderText = "Importe km";
            column7.Width = 150;
            column7.SortMode = DataGridViewColumnSortMode.NotSortable;
            column8.HeaderText = "KmRecorridos";
            column8.Width = 150;
            column8.SortMode = DataGridViewColumnSortMode.NotSortable;
            column9.HeaderText = "Gas";
            column9.Width = 150;
            column9.SortMode = DataGridViewColumnSortMode.NotSortable;
            column10.HeaderText = "IVA";
            column10.Width = 150;
            column10.SortMode = DataGridViewColumnSortMode.NotSortable;
            column11.HeaderText = "NumeroConductores";
            column11.Width = 150;
            column11.SortMode = DataGridViewColumnSortMode.NotSortable;
            column12.HeaderText = "PrecioFactura";
            column12.Width = 150;
            column12.SortMode = DataGridViewColumnSortMode.NotSortable;
            column13.HeaderText = "";
            column14.HeaderText = "";
            column13.Width = 50;
            column13.SortMode = DataGridViewColumnSortMode.NotSortable;
            column14.Width = 50;
            column14.SortMode = DataGridViewColumnSortMode.NotSortable;
            column13.ReadOnly = true;
            column14.ReadOnly = true;

            this.grdEventsList.Columns.AddRange(new DataGridViewColumn[] {
                column0,
                column1,
                column2,
                column3,
                column4,
                column5,
                column6,
                column7,
                column8,
                column9,
                column10,
                column11,
                column12,
                column13,
                column14
            });

            this.grdEventsList.CellContentClick += this.OnCellClicked;
            this.grdEventsList.Dock = DockStyle.Fill;
            this.grdEventsList.TabIndex = 3;
            this.grdEventsList.AllowUserToOrderColumns = false;
            this.pnlInfo = new Panel();
            this.pnlInfo.SuspendLayout();
            this.pnlInfo.Dock = DockStyle.Fill;
            this.pnlEventsContainer = new Panel();
            this.pnlEventsContainer.Dock = DockStyle.Fill;
            this.pnlEventsContainer.Controls.Add(this.grdEventsList);
            this.pnlInfo.Controls.Add(this.pnlEventsContainer);
        }

        protected void OnResizeWindow(object sender, System.EventArgs e)
        {
            Control control = (Control)sender;
            int width = control.Size.Width - 417;

            this.grdEventsList.Width = width;


            this.grdEventsList.Columns[0].Width = (int)Math.Floor(width * .20);      // IDTransporte
            this.grdEventsList.Columns[1].Width = (int)Math.Floor(width * .20);      // Cliente
            this.grdEventsList.Columns[2].Width = (int)Math.Floor(width * .20);      // TipoTransporte
            this.grdEventsList.Columns[3].Width = (int)Math.Floor(width * .20);      // Fcontratacion
            this.grdEventsList.Columns[4].Width = (int)Math.Floor(width * .20);      // Fsalida
            this.grdEventsList.Columns[5].Width = (int)Math.Floor(width * .20);      // Fentrega
            this.grdEventsList.Columns[6].Width = (int)Math.Floor(width * .20);      // Importedia
            this.grdEventsList.Columns[7].Width = (int)Math.Floor(width * .20);      // importekm
            this.grdEventsList.Columns[8].Width = (int)Math.Floor(width * .20);      // kmrecorridos
            this.grdEventsList.Columns[9].Width = (int)Math.Floor(width * .20);      // iva
            this.grdEventsList.Columns[10].Width = (int)Math.Floor(width * .20);      // gas
            this.grdEventsList.Columns[11].Width = (int)Math.Floor(width * .20);      // suplencia
            this.grdEventsList.Columns[12].Width = (int)Math.Floor(width * .20);      // precioFactura

        }

        private void OnCellClicked(object sender, DataGridViewCellEventArgs evt)
        {
            if (evt.ColumnIndex == (this.grdEventsList.Columns.Count - 2))
            {
                this.evt = evt;
                RemoveReserva.PerformClick();
            }
            else
            if (evt.ColumnIndex == (this.grdEventsList.Columns.Count - 1))
            {
                this.evt = evt;
                EditFindReserva.PerformClick();
            }
        }

        private void BuildMenu()
        {
            this.menuPrincipal = new MainMenu();

            this.menuArchivo = new MenuItem("&Archivo");
            this.menuEditar = new MenuItem("&Buscar");
            this.menuGenerar = new MenuItem("&Generar");
            this.menuClientes = new MenuItem("&Clientes");
            this.menuReservas = new MenuItem("&Reservas");
            this.menuAtras = new MenuItem("&Atras");

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


            //Operaciones clientes
            this.operacionGestionarClientes = new MenuItem("&Gestion Clientes");

            //Operaciones Reservas
            this.operacionGestionarReservas = new MenuItem("&Gestion Reservas");
            this.operacionGestionarReservasForm = new MenuItem("&Formulario reservas");

            //Menú superior
            this.menuArchivo.MenuItems.Add(this.operacionSalir);
            this.menuPrincipal.MenuItems.Add(this.menuArchivo);
            this.menuPrincipal.MenuItems.Add(this.menuEditar);
            this.menuPrincipal.MenuItems.Add(this.menuGenerar);
            this.menuPrincipal.MenuItems.Add(this.menuClientes);
            this.menuPrincipal.MenuItems.Add(this.menuReservas);
            this.menuPrincipal.MenuItems.Add(this.menuAtras);
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
            //Submenú clientes
            this.menuClientes.MenuItems.Add(this.operacionGestionarClientes);
            //Submenú Reservas
            this.menuReservas.MenuItems.Add(this.operacionGestionarReservas);
            this.menuReservas.MenuItems.Add(this.operacionGestionarReservasForm);

        }


        //Items del menú
        private MainMenu menuPrincipal;
        private MenuItem menuArchivo;
        private MenuItem menuEditar;
        private MenuItem menuGenerar;
        private MenuItem menuClientes;
        private MenuItem menuReservas;
        public MenuItem menuAtras;

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

        //Operaciones clientes
        public MenuItem operacionGestionarClientes { get; private set; }

        // Operaciones Reservas
        public MenuItem operacionGestionarReservas { get; private set; }
        public MenuItem operacionGestionarReservasForm { get; private set; }

        Panel buildPanelMsg()
        {
            var panel = new Panel() { Dock = DockStyle.Top };

            this.EdMsg = new TextBox() { Dock = DockStyle.Fill, MaximumSize = new Size(int.MaxValue, 20), MinimumSize = new Size(50, 10), ReadOnly = true, ForeColor = Color.Red, BackColor = Color.LightGray };

            panel.Controls.Add(this.EdMsg);
            panel.MaximumSize = new Size(int.MaxValue, this.EdMsg.Height);

            return panel;
        }

        Panel buildPanelAdd1()
        {
            var panel = new Panel() { Dock = DockStyle.Fill };
            var lblReserva = new Label() { Text = "Nueva Reserva", Dock = DockStyle.Top };

            var lblIdTransp = new Label() { Text = "IdTransporte: (ÚNICO)", Dock = DockStyle.Left };
            this.tbIdTransp = new TextBox() { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Fill };

            panel.Controls.Add(this.tbIdTransp);
            panel.Controls.Add(lblIdTransp);

            panel.Controls.Add(lblReserva);
            panel.MaximumSize = new Size(this.Width, this.tbIdTransp.Height + lblReserva.Height);

            return panel;
        }

        Panel buildPanelAdd2()
        {
            var panel = new Panel() { Dock = DockStyle.Fill };

            var lblCliente = new Label() { Text = "Cliente: ", Dock = DockStyle.Left };
            this.tbCliente = new TextBox() { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Fill };

            panel.Controls.Add(this.tbCliente);
            panel.Controls.Add(lblCliente);

            panel.MaximumSize = new Size(this.Width, this.tbCliente.Height);

            return panel;
        }

        Panel buildPanelAdd3()
        {
            var panel = new Panel() { Dock = DockStyle.Fill };

            var lblTipoTransp = new Label() { Text = "TipoTransporte: ", Dock = DockStyle.Left };
            this.tbTipoTrans = new TextBox() { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Fill };

            panel.Controls.Add(this.tbTipoTrans);
            panel.Controls.Add(lblTipoTransp);

            panel.MaximumSize = new Size(this.Width, this.tbTipoTrans.Height);

            return panel;
        }

        Panel buildPanelAdd4()
        {
            var panel = new Panel() { Dock = DockStyle.Fill };

            var lblFcontra = new Label() { Text = "FechaContratacion: ", Dock = DockStyle.Left };
            this.tbFcontra = new TextBox() { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Fill };

            panel.Controls.Add(this.tbFcontra);
            panel.Controls.Add(lblFcontra);

            panel.MaximumSize = new Size(this.Width, this.tbFcontra.Height);

            return panel;
        }

        Panel buildPanelAdd5()
        {
            var panel = new Panel() { Dock = DockStyle.Fill };

            var lblFsalida = new Label() { Text = "FechaSalida: ", Dock = DockStyle.Left };
            this.tbFsalida = new TextBox() { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Fill };

            panel.Controls.Add(this.tbFsalida);
            panel.Controls.Add(lblFsalida);

            panel.MaximumSize = new Size(this.Width, this.tbFsalida.Height);

            return panel;
        }

        Panel buildPanelAdd6()
        {
            var panel = new Panel() { Dock = DockStyle.Fill };

            var lblFentrega = new Label() { Text = "FechaEntrega: ", Dock = DockStyle.Left };
            this.tbFentrega = new TextBox() { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Fill };

            panel.Controls.Add(this.tbFentrega);
            panel.Controls.Add(lblFentrega);

            panel.MaximumSize = new Size(this.Width, this.tbFentrega.Height);

            return panel;
        }

        Panel buildPanelAdd7()
        {
            var panel = new Panel() { Dock = DockStyle.Fill };

            var lblEdia = new Label() { Text = "ImporteDia: ", Dock = DockStyle.Left };
            this.tbEDia = new TextBox() { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Fill };

            panel.Controls.Add(this.tbEDia);
            panel.Controls.Add(lblEdia);

            panel.MaximumSize = new Size(this.Width, this.tbEDia.Height);

            return panel;
        }
        Panel buildPanelAdd8()
        {
            var panel = new Panel() { Dock = DockStyle.Fill };

            var lblEkm = new Label() { Text = "ImporteKm: ", Dock = DockStyle.Left };
            this.tbEkm = new TextBox() { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Fill };

            panel.Controls.Add(this.tbEkm);
            panel.Controls.Add(lblEkm);

            panel.MaximumSize = new Size(this.Width, this.tbEkm.Height);

            return panel;
        }
        Panel buildPanelAdd9()
        {
            var panel = new Panel() { Dock = DockStyle.Fill };

            var lblKmRecorridos = new Label() { Text = "KilometrosRecorridos: ", Dock = DockStyle.Left };
            this.tbKmRecorridos = new TextBox() { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Fill };

            panel.Controls.Add(this.tbKmRecorridos);
            panel.Controls.Add(lblKmRecorridos);

            panel.MaximumSize = new Size(this.Width, this.tbKmRecorridos.Height);

            return panel;
        }
        Panel buildPanelAdd10()
        {
            var panel = new Panel() { Dock = DockStyle.Fill };

            var lblGas = new Label() { Text = "Gas: ", Dock = DockStyle.Left };
            this.tbGas = new TextBox() { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Fill };

            panel.Controls.Add(this.tbGas);
            panel.Controls.Add(lblGas);

            panel.MaximumSize = new Size(this.Width, this.tbGas.Height);


            return panel;
        }
        Panel buildPanelAdd11()
        {
            var panel = new Panel() { Dock = DockStyle.Fill };

            var lblIVA = new Label() { Text = "IVA: ", Dock = DockStyle.Left };
            this.tbIVA = new TextBox() { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Fill };

            panel.Controls.Add(this.tbIVA);
            panel.Controls.Add(lblIVA);

            panel.MaximumSize = new Size(this.Width, this.tbIVA.Height);

            return panel;
        }
        Panel buildPanelAdd12()
        {
            var panel = new Panel() { Dock = DockStyle.Fill };

            var lblSuplencia = new Label() { Text = "NumeroConductores: ", Dock = DockStyle.Left };
            this.tbSuplencia = new TextBox() { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Fill };

            panel.Controls.Add(this.tbSuplencia);
            panel.Controls.Add(lblSuplencia);

            panel.MaximumSize = new Size(this.Width, this.tbSuplencia.Height);

            return panel;
        }
        Panel buildPanelAdd13()
        {
            var panel = new Panel() { Dock = DockStyle.Fill };

            this.EditReserva = new Button() { Text = "Editar", Dock = DockStyle.Left };

            this.CreateReserva = new Button() { Text = "Crear", Dock = DockStyle.Right };

            panel.Controls.Add(EditReserva);
            panel.Controls.Add(CreateReserva);

            panel.MaximumSize = new Size(this.Width, this.tbCliente.Height + 20);

            return panel;
        }

        /*------------------------------------------------------------------*/
        /*------------------TransportesPendientes---------------------------*/
        /*------------------------------------------------------------------*/

        public Panel buildPanelTransportesPendientes()
        {
            var panelSearch = new Panel { Dock = DockStyle.Fill };

            var pnlBotones = this.BuildPanelBotones();
            panelSearch.Controls.Add(pnlBotones);

            var panelMatriculaCamion = this.BuildPanelMatriculaCamion();
            panelSearch.Controls.Add(panelMatriculaCamion);

            panelSearch.MinimumSize = new Size(this.Width, this.tbCliente.Height + 20);
            return panelSearch;
        }

        private Panel BuildPanelBotones()
        {
            var toret = new TableLayoutPanel()
            {
                ColumnCount = 2,
                RowCount = 1
            };



            this.AcceptButton = this.btSearchCamiones;
            toret.Controls.Add(this.btSearchCamiones);     
            toret.Dock = DockStyle.Top;
            return toret;
        }
        public Panel BuildPanelMatriculaCamion()
        {
            var toret = new Panel { Dock = DockStyle.Top };
            Text = "ComboBox";
            Size = new Size(240, 240);

            escogerCamion = new ComboBox();
            escogerCamion.Parent = this;
            escogerCamion.DropDownStyle = ComboBoxStyle.DropDownList;
            List<object> Camiones = new List<object>();
            Camiones.Add("Todos");
            foreach (Flota d in MainWindow.flotas)
            {
                Camiones.Add(d.Matricula);
            }

            escogerCamion.Items.AddRange(Camiones.ToArray());

            escogerCamion.SelectedItem = Camiones.First();
            escogerCamion.Text = Camiones.First().ToString();
            toret.Controls.Add(this.escogerCamion);
            toret.MaximumSize = new Size(int.MaxValue, escogerCamion.Height * 2);

            return toret;

        }

        private ComboBox escogerCamion { get; set; }
        public string Matricula { get => this.escogerCamion.Text.Trim(); set => Matricula = value.ToString(); }
        public Button btSearchCamiones { get; private set; }

        /*------------------------------------------------------------------*/
        /*------------------------------------------------------------------*/
        /*------------------------------------------------------------------*/

        /*------------------------------------------------------------------*/
        /*------------------Transporte Cliente------------------------------*/
        /*------------------------------------------------------------------*/

        private Panel BuildPanelBotones3()
        {
            var toret = new TableLayoutPanel()
            {
                ColumnCount = 2,
                RowCount = 1
            };


            this.AcceptButton = this.btSearchTransporteCliente;       
            toret.Controls.Add(this.btSearchTransporteCliente);
            toret.Dock = DockStyle.Top;
            return toret;
        }

        public Panel BuildPanelTipoCamion()
        {

            var toret = new Panel { Dock = DockStyle.Top };
            Text = "ComboBox";
            Size = new Size(240, 240);

            escogerCliente = new ComboBox();
            escogerCliente.Parent = this;
            escogerCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            List<object> NIFs = new List<object>();

            foreach (Cliente c in MainWindow.RegClientes)
            {
                NIFs.Add(c.Nif);
            }

            escogerCliente.Items.AddRange(NIFs.ToArray());

            if (NIFs.Count() > 0)
            {
                escogerCliente.SelectedItem = NIFs.First();
                escogerCliente.Text = NIFs.First().ToString();
            }

            toret.Controls.Add(this.escogerCliente);
            toret.MaximumSize = new Size(int.MaxValue, escogerCliente.Height * 2);
            return toret;

        }

        public Panel BuildPanelPasadasOPendientes2()
        {
            var toret = new Panel { Dock = DockStyle.Top };
            Text = "ComboBox";
            Size = new Size(240, 240);

            escogerPeriodo2 = new ComboBox();
            escogerPeriodo2.Parent = this;
            escogerPeriodo2.DropDownStyle = ComboBoxStyle.DropDownList;

            escogerPeriodo2.Items.AddRange(new object[] {
            "Transportes pasados",
            "Transportes pendientes"});

            escogerPeriodo2.SelectedItem = "Transportes pasados";
            escogerPeriodo2.Text = "Transportes pasados";
            toret.Controls.Add(this.escogerPeriodo2);
            toret.MaximumSize = new Size(int.MaxValue, escogerPeriodo2.Height * 2);
            return toret;

        }

        public Panel BuildPanelEscogerAnho2()
        {

            var toret = new Panel { Dock = DockStyle.Top };
            Text = "ComboBox";
            Size = new Size(240, 240);

            escogerAnho2 = new ComboBox();
            escogerAnho2.Parent = this;
            escogerAnho2.DropDownStyle = ComboBoxStyle.DropDownList;
            List<object> anhos = new List<object>();
            anhos.Add("");
            foreach (Reservas t in MainWindow.RegReservas)
            {
                if (!anhos.Contains(t.Fentrega.Year))
                {
                    anhos.Add(t.Fentrega.Year);
                }
            }

            escogerAnho2.Items.AddRange(anhos.ToArray());

            escogerAnho2.SelectedItem = anhos.First();
            escogerAnho2.Text = anhos.First().ToString();
            toret.Controls.Add(this.escogerAnho2);
            toret.MaximumSize = new Size(int.MaxValue, escogerAnho2.Height * 2);
            return toret;

        }

        public Panel buildPanelTransporteCliente()
        {
            var panelSearch = new Panel { Dock = DockStyle.Fill };
            var pnlBotones = this.BuildPanelBotones3();
            panelSearch.Controls.Add(pnlBotones);

            var panelAnhos = this.BuildPanelEscogerAnho2();
            panelSearch.Controls.Add(panelAnhos);

            var panelPeriodo = this.BuildPanelPasadasOPendientes2();
            panelSearch.Controls.Add(panelPeriodo);

            var panelCliente = this.BuildPanelTipoCamion();
            panelSearch.Controls.Add(panelCliente);

            panelSearch.MinimumSize = new Size(this.Width, this.tbCliente.Height + 20);
            return panelSearch;
        }


        private ComboBox escogerCliente { get; set; }
        private ComboBox escogerPeriodo2 { get; set; }
        private ComboBox escogerAnho2 { get; set; }

        public string Anho2 => escogerAnho2.Text;
        public string Cliente => escogerCliente.Text;
        public string Periodo2 => escogerPeriodo2.Text;
        public Button btSearchTransporteCliente { get; private set; }
        /*------------------------------------------------------------------*/
        /*------------------------------------------------------------------*/
        /*------------------------------------------------------------------*/


        /*------------------------------------------------------------------*/
        /*------------------Reservas Camion---------------------------------*/
        /*------------------------------------------------------------------*/
        public Panel buildPanelReservasCamion()
        {

            var panelSearch = new TableLayoutPanel { Dock = DockStyle.Fill };

            var panelMatriculaCamion = this.BuildPanelMatriculaCamion();
            panelSearch.Controls.Add(panelMatriculaCamion);

            var panelPeriodo = this.BuildPanelPasadasOPendientes();
            panelSearch.Controls.Add(panelPeriodo);

            var panelAnhos = this.BuildPanelEscogerAnho();
            panelSearch.Controls.Add(panelAnhos);

            var pnlBotones = this.BuildPanelBotones();
            panelSearch.Controls.Add(pnlBotones);

            panelSearch.MinimumSize = new Size(this.Width, this.tbCliente.Height + 20);

            return panelSearch;
        }

        private Panel BuildPanelBotones2()
        {
            var toret = new TableLayoutPanel()
            {
                ColumnCount = 2,
                RowCount = 1
            };



            this.AcceptButton = this.btSearchCamiones2;

            toret.Controls.Add(this.btSearchCamiones2);
            toret.Dock = DockStyle.Top;
            return toret;
        }
        public Panel BuildPanelMatriculaCamion2()
        {
            var toret = new Panel { Dock = DockStyle.Top };
            Text = "ComboBox";
            Size = new Size(240, 240);

            escogerCamion2 = new ComboBox();
            escogerCamion2.Parent = this;
            escogerCamion2.DropDownStyle = ComboBoxStyle.DropDownList;
            List<object> Camiones = new List<object>();
            Camiones.Add("Todos");
            foreach (Flota d in MainWindow.flotas)
            {
                Camiones.Add(d.Matricula);
            }

            escogerCamion2.Items.AddRange(Camiones.ToArray());

            escogerCamion2.SelectedItem = Camiones.First();
            escogerCamion2.Text = Camiones.First().ToString();
            toret.Controls.Add(this.escogerCamion2);
            toret.MaximumSize = new Size(int.MaxValue, escogerCamion2.Height * 2);

            return toret;

        }
        public Panel BuildPanelPasadasOPendientes()
        {
            var toret = new Panel { Dock = DockStyle.Top };
            Text = "ComboBox";
            Size = new Size(240, 240);

            escogerPeriodo = new ComboBox();
            escogerPeriodo.Parent = this;
            escogerPeriodo.DropDownStyle = ComboBoxStyle.DropDownList;

            escogerPeriodo.Items.AddRange(new object[] {
                "Transportes pasados",
                "Transportes pendientes"});

            escogerPeriodo.SelectedItem = "Transportes pasados";
            escogerPeriodo.Text = "Transportes pasados";
            toret.Controls.Add(this.escogerPeriodo);
            toret.MaximumSize = new Size(int.MaxValue, escogerPeriodo.Height * 2);
            return toret;

        }
        public Panel BuildPanelEscogerAnho()
        {
            var toret = new Panel { Dock = DockStyle.Top };
            Text = "ComboBox";
            Size = new Size(240, 240);

            escogerAnho = new ComboBox();
            escogerAnho.Parent = this;
            escogerAnho.DropDownStyle = ComboBoxStyle.DropDownList;
            List<object> anhos = new List<object>();
            anhos.Add("");
            foreach (Reservas t in MainWindow.RegReservas)
            {
                if (!anhos.Contains(t.Fentrega.Year))
                {
                    anhos.Add(t.Fentrega.Year);
                }
            }

            escogerAnho.Items.AddRange(anhos.ToArray());
            escogerAnho.SelectedItem = anhos.First();
            escogerAnho.Text = anhos.First().ToString();
            toret.Controls.Add(this.escogerAnho);
            toret.MaximumSize = new Size(int.MaxValue, escogerAnho.Height * 2);
            return toret;

        }


        private ComboBox escogerCamion2 { get; set; }
        private ComboBox escogerPeriodo { get; set; }
        private ComboBox escogerAnho { get; set; }

        public string Anho => escogerAnho.Text;
        public string Matricula2 { get => this.escogerCamion2.Text.Trim(); set => Matricula2 = value.ToString(); }
        public string Periodo => escogerPeriodo.Text;

        public Button btSearchCamiones2 { get; set; }

        /*------------------------------------------------------------------*/
        /*------------------------------------------------------------------*/
        /*------------------------------------------------------------------*/

        /*------------------------------------------------------------------*/
        /*------------------Reservas Cliente---------------------------------*/
        /*------------------------------------------------------------------*/

        public Panel buildPanelReservasCliente()
        {
            var panelSearch = new TableLayoutPanel { Dock = DockStyle.Fill };

            var panelIdDni = this.BuildPanelIdTransporte4();
            panelSearch.Controls.Add(panelIdDni);

            var panelAnhos = this.BuildPanelEscogerAnho4();
            panelSearch.Controls.Add(panelAnhos);

            var pnlBotones = this.BuildPanelBotones4();
            panelSearch.Controls.Add(pnlBotones);

            panelSearch.MinimumSize = new Size(this.Width, this.tbCliente.Height + 20);

            return panelSearch;

        }

        private Panel BuildPanelIdTransporte4()
        {
            var toret = new Panel { Dock = DockStyle.Top };
            Text = "ComboBox";
            Size = new Size(240, 240);

            escogerCliente4 = new ComboBox();
            escogerCliente4.Parent = this;
            escogerCliente4.DropDownStyle = ComboBoxStyle.DropDownList;
            List<object> NIFs = new List<object>();

            foreach (Cliente c in MainWindow.RegClientes)
            {
                NIFs.Add(c.Nif);
            }

            escogerCliente4.Items.AddRange(NIFs.ToArray());

            if (NIFs.Count() > 0)
            {
                escogerCliente4.SelectedItem = NIFs.First();
                escogerCliente4.Text = NIFs.First().ToString();
            }
            toret.Controls.Add(this.escogerCliente4);
            toret.MaximumSize = new Size(int.MaxValue, escogerCliente4.Height * 2);
            return toret;
        }

        public Panel BuildPanelEscogerAnho4()
        {

            var toret = new Panel { Dock = DockStyle.Top };
            Text = "ComboBox";
            Size = new Size(240, 240);

            escogerAnho4 = new ComboBox();
            escogerAnho4.Parent = this;
            escogerAnho4.DropDownStyle = ComboBoxStyle.DropDownList;
            List<object> anhos = new List<object>();
            anhos.Add("");
            foreach (Reservas t in MainWindow.RegReservas)
            {
                if (!anhos.Contains(t.Fentrega.Year))
                {
                    anhos.Add(t.Fentrega.Year);
                }
            }

            escogerAnho4.Items.AddRange(anhos.ToArray());

            escogerAnho4.SelectedItem = anhos.First();
            escogerAnho4.Text = anhos.First().ToString();
            toret.Controls.Add(this.escogerAnho4);
            toret.MaximumSize = new Size(int.MaxValue, escogerAnho4.Height * 2);
            return toret;

        }

        private Panel BuildPanelBotones4()
        {
            var toret = new TableLayoutPanel()
            {
                ColumnCount = 2,
                RowCount = 1
            };


            this.AcceptButton = this.btSearchCliente4;
            toret.Controls.Add(this.btSearchCliente4);

            toret.Dock = DockStyle.Top;
            return toret;
        }

        public ComboBox escogerCliente4 { get; set; }
        private ComboBox escogerAnho4 { get; set; }

        public string Anho4 => escogerAnho4.Text;
        public string idDni { get => this.escogerCliente4.Text.Trim(); set => idDni = value.ToString(); }
        public Button btSearchCliente4 { get; set; }

        /*------------------------------------------------------------------*/
        /*------------------------------------------------------------------*/
        /*------------------------------------------------------------------*/

        /*------------------------------------------------------------------*/
        /*--------------------Ocupacion-------------------------------------*/
        /*------------------------------------------------------------------*/

        private Panel BuildPanelFecha5()
        {
            var toret = new Panel { Dock = DockStyle.Top };

            Text = "Month Calendar";
            Size = new Size(240, 240);
            

            calendar.Parent = this;
            calendar.Location = new Point(10, 10);
            calendar.DateSelected += new DateRangeEventHandler(OnSelected);
            calendar.DateSelected += (sender, e) => this.Close();
            date = new Label();
            date.Parent = this;
            date.Location = new Point(40, 170);
            Fecha5 = calendar.SelectionStart;
            date.Text = Fecha5.Month + "/" + Fecha5.Day + "/" + Fecha5.Year;

            toret.Controls.Add(this.calendar);
            toret.Controls.Add(this.date);

            toret.MinimumSize = new Size(int.MaxValue, calendar.Height + date.Height + 50);
            return toret;
        }

        void OnSelected(object sender, EventArgs e)
        {
            Fecha5 = calendar.SelectionStart;
            date.Text = Fecha5.Day + "/" + Fecha5.Month + "/" + Fecha5.Year;
        }

        public Panel BuildPanelEscogerAnho5()
        {
            var toret = new FlowLayoutPanel { Dock = DockStyle.Top, };
            Text = "ComboBox";
            Size = new Size(240, 240);

            escogerAnho5 = new ComboBox();
            escogerAnho5.Parent = this;
            escogerAnho5.DropDownStyle = ComboBoxStyle.DropDownList;
            List<object> anhos = new List<object>();
            anhos.Add("");
            foreach (Reservas t in MainWindow.RegReservas)
            {
                if (!anhos.Contains(t.Fentrega.Year))
                {
                    anhos.Add(t.Fentrega.Year);
                }
            }

            escogerAnho5.Items.AddRange(anhos.ToArray());

            escogerAnho5.SelectedItem = anhos.First();
            escogerAnho5.Text = anhos.First().ToString();



            this.AcceptButton = this.btSearchOcupacionAnho5;
            toret.Controls.Add(this.escogerAnho5);
            toret.Controls.Add(this.btSearchOcupacionAnho5);

            toret.MaximumSize = new Size(int.MaxValue, escogerAnho5.Height * 2);
            return toret;

        }

        public Panel buildPanelOcupacion()
        {
            var panelSearch = new TableLayoutPanel { Dock = DockStyle.Fill };

            var panelIdFecha = this.BuildPanelFecha5();
            panelSearch.Controls.Add(panelIdFecha);

            var panelAnhos = this.BuildPanelEscogerAnho5();
            panelSearch.Controls.Add(panelAnhos);

            panelSearch.MinimumSize = new Size(this.Width, this.tbCliente.Height + 20);

            return panelSearch;
        }

        public MonthCalendar calendar { get; set; }
        public Label date { get; set; }
        private ComboBox escogerAnho5 { get; set; }

        public string Anho5 => escogerAnho5.Text;
        public DateTime Fecha5 { get; set; }

        public Button btSearchOcupacionAnho5 { get; set; }


        /*------------------------------------------------------------------*/
        /*------------------------------------------------------------------*/
        /*------------------------------------------------------------------*/


        Panel panelAdd1;
        Panel panelAdd2;
        Panel panelAdd3;
        Panel panelAdd4;
        Panel panelAdd5;
        Panel panelAdd6;
        Panel panelAdd7;
        Panel panelAdd8;
        Panel panelAdd9;
        Panel panelAdd10;
        Panel panelAdd11;
        Panel panelAdd12;
        Panel panelAdd13;

        public Panel BoxAdd { get; set; }

        public Panel BoxMsg { get; set; }

        public Panel dialogos { get; set; }
        public Panel dialogosGrande { get; set; }

        public void inicializarBotones()
        {
            this.btSearchCliente4 = new Button()
            {
                DialogResult = DialogResult.OK,
                Text = "&Buscar"
            };
            this.btSearchCamiones2 = new Button()
            {
                DialogResult = DialogResult.OK,
                Text = "&Buscar"
            };


            this.btSearchTransporteCliente = new Button()
            {
                DialogResult = DialogResult.OK,
                Text = "&Buscar"
            };

            this.btSearchCamiones = new Button()
            {
                DialogResult = DialogResult.OK,
                Text = "&Buscar"
            };

            calendar = new MonthCalendar();
            this.btSearchOcupacionAnho5 = new Button()
            {
                DialogResult = DialogResult.OK,
                Text = "&Buscar por anhos",
                Size = new Size(100, 20)
            };
        }
    }
}