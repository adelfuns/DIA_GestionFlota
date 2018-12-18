using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using GestionFlota.Core;

namespace GestionFlota.UI
{
    public class MainWindowViewReservas : Form
    {
        /*------------------------------------------------------------------*/
        /*---------------------------Constructor----------------------------*/
        /*------------------------------------------------------------------*/

        public MainWindowViewReservas()
        {
            this.Build();
        }
        void Build()
        {
            this.inicializarBotones();
            this.dialogos = new Panel() { Dock = DockStyle.Right };
            this.dialogosGrande = new Panel() { Dock = DockStyle.Right };
            this.grdEventsList = new DataGridView() { Dock = DockStyle.Left };
            this.grdEventsListAux = new DataGridView() { Dock = DockStyle.Left };

            this.opcionesFijo = new Panel() { Dock = DockStyle.Bottom };
            this.opcionesPoner = new Panel() { Dock = DockStyle.Bottom };

            BoxMsg = new TableLayoutPanel() { Dock = DockStyle.Bottom };

            this.BuildMenu();
            this.buildPanelReservas();
            this.buildPanelClientes();
            this.BuildPanelListaFlota();
            var panelMsg = this.buildPanelMsg();

            crearPanelesPequenosReserva();
            crearPanelesPequenosClientes();

            BuildPanelAddFlota();
            BuildPanelModificar();

            //Paneles busquedas
            buildPanelReservasCamion();
            buildPanelTransporteCliente();
            buildPanelReservasCliente();

            this.grdEventsListAux = this.grdEventsListReservas;
            this.grdEventsList.Controls.Add(this.grdEventsListAux);
            this.dialogosGrande.Controls.Add(this.dialogos);
            this.opcionesPoner = buildPanelOpcionesReservas();
            this.opcionesFijo.Controls.Add(this.opcionesPoner);
            this.BoxMsg.Controls.Add(panelMsg);

            this.Controls.Add(this.grdEventsList);
            this.Controls.Add(this.dialogosGrande);
            this.Controls.Add(opcionesFijo);
            this.Controls.Add(BoxMsg);
            
            this.Resize += (obj, args) => this.OnResizeWindow(obj, args);
            this.Resize += (obj, args) => this.OnResizeWindowClientes(obj, args);
            this.Resize += (obj, args) => this.OnResizeWindowFlota(obj, args);

            // this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            BoxMsg.Height -= 75;

            this.dialogosGrande.Width = 410;

            this.MinimumSize = new Size(1500, 600);


            this.grdEventsList.Width = this.Width - this.dialogosGrande.Width;
            this.grdEventsListAux.Width = this.Width - this.dialogosGrande.Width; 

            this.Text = "Gestion Reservas";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.CenterToScreen();
            this.Show();
        }

        /*------------------------------------------------------------------*/
        /*-------------------------Propiedades------------------------------*/
        /*------------------------------------------------------------------*/
        public Panel opcionesFijo { get; set; }
        public Panel opcionesPoner { get; set; }
        public Panel PanelGrafico { get; set; } //Panel grafico
        public TextBox tbReservas { get;  set; } 
        public TextBox tbIdTransp { get;  set; }
        public TextBox tbCliente { get;  set; }
        public TextBox tbTipoTrans { get;  set; }
        public TextBox tbFcontra { get;  set; }
        public TextBox tbFsalida { get;  set; }
        public TextBox tbFentrega { get;  set; }
        public TextBox tbEDia {  get; set; }
        public TextBox tbEkm { get;  set; }
        public TextBox tbKmRecorridos { get;  set; }
        public TextBox tbGas { get;  set; }
        public TextBox tbSuplencia { get;  set; }
        public TextBox tbIVA { get;  set; }
        public TextBox tbPrecioFactura { get; set; }
        public Button CreateReserva { get;  set; }
        public Button RemoveReserva { get;  set; }
        public Button EditFindReserva { get;  set; }
        public Button EditReserva { get;  set; }
        public TextBox EdMsg { get;  set; }
        //ClienteView
        public TextBox EdClientes { get;  set; }
        public TextBox EdNif { get;  set; }
        public TextBox EdName { get;  set; }
        public TextBox EdTlf { get;  set; }
        public TextBox EdMail { get;  set; }
        public TextBox EdDirec { get;  set; }
        public Button CreateCliente { get;  set; }
        public Button RemoveCliente { get;  set; }
        public Button EditFindCliente { get;  set; }
        public Button EditCliente { get;  set; }
        public Label lblCliente { get;  set; }
        //Tabla
        public DataGridView grdEventsList; //Tabla
        public DataGridView grdEventsListFlota; //Tabla
        public DataGridView grdEventsListReservas; //Tabla
        public DataGridView grdEventsListClientes; //Tabla
        public DataGridView grdEventsListAux; //Tabla
        // Propiedades PanelDerechoReservas
        public Panel PanelAdd1Reservas { get; set; }
        public Panel PanelAdd2Reservas { get; set; }
        public Panel PanelAdd3Reservas { get; set; }
        public Panel PanelAdd4Reservas { get; set; }
        public Panel PanelAdd5Reservas { get; set; }
        public Panel PanelAdd6Reservas { get; set; }
        public Panel PanelAdd7Reservas { get; set; }
        public Panel PanelAdd8Reservas { get; set; }
        public Panel PanelAdd9Reservas { get; set; }
        public Panel PanelAdd10Reservas { get; set; }
        public Panel PanelAdd11Reservas { get; set; }
        public Panel PanelAdd12Reservas { get; set; }
        public Panel PanelAdd13Reservas { get; set; }
        // Propiedades PanelDerechoClientes
        public Panel PanelAdd1Clientes { get; set; }
        public Panel PanelAdd2Clientes { get; set; }
        public Panel PanelAdd3Clientes { get; set; }
        public Panel PanelAdd4Clientes { get; set; }
        public Panel PanelAdd5Clientes { get; set; }
        public Panel PanelAdd6Clientes { get; set; }
        // Propiedades PanelInferiorMensajes
        private Panel pnlInfo;
        private Panel pnlEventsContainer;
        public DataGridViewCellEventArgs evt { get; private set; }
        // Items del menú
        private MainMenu menuPrincipal;
        private MenuItem menuArchivo;
        private MenuItem menuGenerar;
        public MenuItem menuAtras;
        // Operacion salida
        public MenuItem operacionSalir { get; private set; }
        // Operaciones búsqueda
        // Operaciones generar gráficos
        public MenuItem operacionActividadGeneral { get; private set; }
        public MenuItem operacionActividadCliente { get; private set; }
        public MenuItem operacionActividadCamion { get; private set; }
        public MenuItem operacionActividadComodidades { get; private set; }
        // Operaciones clientes
        public MenuItem operacionGestionarClientes { get; private set; }
        // Operaciones Reservas
        public MenuItem operacionGestionarReservas { get; private set; }
        // Operaciones Flota
        public MenuItem operacionGestionarFlota { get; private set; }
        //Búsquedas
        public Label escogerCliente { get; set; }
        private ComboBox escogerPeriodo2 { get; set; }
        private ComboBox escogerAnho2 { get; set; }
        public string Anho2 => escogerAnho2.Text;
        public string Cliente => escogerCliente.Text;
        public string Periodo2 => escogerPeriodo2.Text;
        public Button btSearchTransporteCliente { get; private set; }
        private ComboBox escogerCamion { get; set; }
        public string Matricula { get => this.escogerCamion.Text.Trim(); set => Matricula = value.ToString(); }
        public Button btSearchCamiones { get; private set; }
        private ComboBox escogerCamion2 { get; set; }
        private ComboBox escogerPeriodo { get; set; }
        private ComboBox escogerAnho { get; set; }
        public string Anho => escogerAnho.Text;
        public string Matricula2 { get => this.escogerCamion2.Text.Trim(); set => Matricula2 = value.ToString(); }
        public string Periodo => escogerPeriodo.Text;
        public Label escogerCliente4 { get; set; }
        private ComboBox escogerAnho4 { get; set; }
        public string Anho4 => escogerAnho4.Text;
        public string idDni { get => this.escogerCliente4.Text.Trim(); set => idDni = value.ToString(); }
        public Button btSearchCliente4 { get; set; }
        public Button btSearchCamiones2 { get; set; }
        public MonthCalendar calendar { get; set; }
        public Label date { get; set; }
        private ComboBox escogerAnho5 { get; set; }
        public string Anho5 => escogerAnho5.Text;
        public DateTime Fecha5 { get; set; }
        public Button btSearchOcupacionAnho5 { get; set; }
        public Panel BoxAddReservas { get; set; }
        public Panel BoxAddClientes { get; set; }
        public Panel BoxAddFlota { get; set; }
        public Panel BoxMsg { get; set; }
        public Panel dialogos { get; set; }
        public Panel dialogosGrande { get; set; }
        public const int CHART_CANVAS_SIZE = 624;
        public Chart Chart { get; private set; }
        public Panel panelGraficoGeneral { get; set; }
        public Button btSearchDisponibilidad { get; set; }
        public ComboBox  escogerTipoDis { get; set; }
        public string Tipo => escogerTipoDis.Text;
        //Botones panel inferior
        public Button btGestionReservas { get; set; }
        public Button operacionSearch1 { get; set; }
        public Button operacionSearch3 { get; set; }
        public Button operacionSearch4 { get; set; }
        public Button operacionSearch5 { get; set; }
        public Button operacionSearch6 { get; set; }
        public Button operacionSearch7 { get; set; }
        public Button btGestionClientes { get; set; }
        public Button AnhadirFlota { get; set; }
        public Button operacionSearch2 { get; set; }
        public ComboBox escogerComodidades { get; set; }
        public string comodidad => escogerComodidades.Text;
        public Button btSearchComodidad { get; private set; }
        public Button operacionGraficoCamion { get; set; } //Boton generar graficos en panel derecho
        public Button operacionGraficoCliente { get; set; } //Boton generar graficos en panel derecho
        public Button operacionGraficoCliente2 { get; set; } //Boton generar graficos en panel derecho
        public Button operacionGraficoComodidades { get; set; } //Boton generar graficos en panel derecho
        public Button operacionGraficoGeneral { get; set; } //Boton generar graficos general en panel inferior

        //Flota
        public Panel panelAnhadir { get; set; }
        public Panel panelModificar { get; set; }
        public ComboBox escogerTipo2 { get; set; }
        public string Tipo2 => escogerTipo2.Text;
        private ComboBox escogerCamion3;
        public string Matricula3 => escogerCamion3.Text;
        public Button btCierra { get; set; }
        public Button btAñadir { get; set; }
        public Button btModificar { get; set; }
        public Button EditFindFlota { get; set; }
        public Button DeleteFlota { get; set; }
        public TextBox edLetrasMatricula { get; set; }
        public TextBox edDigitosMatricula { get; set; }
        public TextBox edCarga { get; set; }
        public TextBox edMarca { get; set; }
        public TextBox edModelo { get; set; }
        public TextBox edConsumoKm { get; set; }
        public TextBox edFechaAdquisicion { get; set; }
        public TextBox edFechaFabricacion { get; set; }
        public CheckBox ComodidadWifi { get; set; }
        public CheckBox ComodidadBlue { get; set; }
        public CheckBox ComodidadAire { get; set; }
        public CheckBox ComodidadLitera { get; set; }
        public CheckBox ComodidadTv { get; set; }

        public ComboBox escogerTipo2M { get; set; }
        public string Tipo2M => escogerTipo2M.Text;
        public TextBox edMatricula { get; set; }
        public TextBox edCargaM { get; set; }
        public TextBox edMarcaM { get; set; }
        public TextBox edModeloM { get; set; }
        public TextBox edConsumoKmM { get; set; }
        public TextBox edFechaAdquisicionM { get; set; }
        public TextBox edFechaFabricacionM { get; set; }
        public CheckBox ComodidadWifiM { get; set; }
        public CheckBox ComodidadBlueM { get; set; }
        public CheckBox ComodidadAireM { get; set; }
        public CheckBox ComodidadLiteraM { get; set; }
        public CheckBox ComodidadTvM { get; set; }

        public MenuItem añadirFlota { get; private set; }
        public MenuItem eliminarFlota { get; private set; }
        public MenuItem modificarFlota { get; private set; }


        public TextBox Texto { get; private set; }
        public Panel panelListaFlota;
        public Button btSearchFlota { get; set; }
        public ComboBox escogerBusquedaFlota { get; set; }
        /*------------------------------------------------------------------*/
        /*---------------------------Métodos--------------------------------*/
        /*------------------------------------------------------------------*/

        private void buildPanelReservas()
        {

            RemoveReserva = new Button();
            EditFindReserva = new Button();

            this.grdEventsListReservas = new DataGridView();

            this.grdEventsListReservas.Dock = DockStyle.Fill;
            this.grdEventsListReservas.AllowUserToResizeRows = false;
            this.grdEventsListReservas.RowHeadersVisible = false;
            this.grdEventsListReservas.AutoGenerateColumns = false;
            this.grdEventsListReservas.MultiSelect = false;
            this.grdEventsListReservas.AllowUserToAddRows = false;

            var textCellTemplate = new DataGridViewTextBoxCell();
            var imageEditTemplate = new DataGridViewButtonCell();
            var imageDeleteTemplate = new DataGridViewButtonCell();
            textCellTemplate.Style.BackColor = Color.Wheat;
            textCellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; 
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
            column0.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column1.HeaderText = "Cliente";
            column1.Width = 150;
            column1.SortMode = DataGridViewColumnSortMode.Automatic;
            column1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column2.HeaderText = "TipoTransporte";
            column2.Width = 75;
            column2.SortMode = DataGridViewColumnSortMode.NotSortable;
            column2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column3.HeaderText = "FechaContratacion";
            column3.Width = 150;
            column3.SortMode = DataGridViewColumnSortMode.NotSortable;
            column3.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column4.HeaderText = "Fecha salida";
            column4.Width = 150;
            column4.SortMode = DataGridViewColumnSortMode.NotSortable;
            column4.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column5.HeaderText = "Fecha entrega";
            column5.Width = 150;
            column5.SortMode = DataGridViewColumnSortMode.NotSortable;
            column5.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column6.HeaderText = "Importe dia";
            column6.Width = 150;
            column6.SortMode = DataGridViewColumnSortMode.NotSortable;
            column6.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column7.HeaderText = "Importe km";
            column7.Width = 150;
            column7.SortMode = DataGridViewColumnSortMode.NotSortable;
            column7.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column8.HeaderText = "KmRecorridos";
            column8.Width = 150;
            column8.SortMode = DataGridViewColumnSortMode.NotSortable;
            column8.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column9.HeaderText = "Gas";
            column9.Width = 150;
            column9.SortMode = DataGridViewColumnSortMode.NotSortable;
            column9.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column10.HeaderText = "IVA";
            column10.Width = 150;
            column10.SortMode = DataGridViewColumnSortMode.NotSortable;
            column10.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column11.HeaderText = "NumeroConductores";
            column11.Width = 150;
            column11.SortMode = DataGridViewColumnSortMode.NotSortable;
            column11.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column12.HeaderText = "PrecioFactura";
            column12.Width = 150;
            column12.SortMode = DataGridViewColumnSortMode.NotSortable;
            column12.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column13.HeaderText = "";
            column14.HeaderText = "";
            column13.Width = 50;
            column13.SortMode = DataGridViewColumnSortMode.NotSortable;
            column13.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column14.Width = 50;
            column14.SortMode = DataGridViewColumnSortMode.NotSortable;
            column14.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column13.ReadOnly = true;
            column14.ReadOnly = true;

            this.grdEventsListReservas.Columns.AddRange(new DataGridViewColumn[] {
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
            this.grdEventsListReservas.ReadOnly = true;
            this.grdEventsListReservas.CellContentClick += this.OnCellClicked;
            this.grdEventsListReservas.Dock = DockStyle.Fill;
            this.grdEventsListReservas.TabIndex = 3;
            this.grdEventsListReservas.AllowUserToOrderColumns = false;
            this.pnlInfo = new Panel();
            this.pnlInfo.SuspendLayout();
            this.pnlInfo.Dock = DockStyle.Fill;
            this.pnlEventsContainer = new Panel();
            this.pnlEventsContainer.Dock = DockStyle.Fill;
            this.pnlEventsContainer.Controls.Add(this.grdEventsListReservas);
            this.pnlInfo.Controls.Add(this.pnlEventsContainer);
        }

        protected void OnResizeWindow(object sender, System.EventArgs e)
        {
            Control control = (Control)sender;
            int width = control.Size.Width - 150;

            this.grdEventsListReservas.Width = width;
            this.grdEventsListClientes.Width = width;
            this.grdEventsList.Width = this.Width - 410;


            this.grdEventsListReservas.Columns[0].Width = (int)Math.Floor(width * .20);      // IDTransporte
            this.grdEventsListReservas.Columns[1].Width = (int)Math.Floor(width * .20);      // Cliente
            this.grdEventsListReservas.Columns[2].Width = (int)Math.Floor(width * .20);      // TipoTransporte
            this.grdEventsListReservas.Columns[3].Width = (int)Math.Floor(width * .20);      // Fcontratacion
            this.grdEventsListReservas.Columns[4].Width = (int)Math.Floor(width * .20);      // Fsalida
            this.grdEventsListReservas.Columns[5].Width = (int)Math.Floor(width * .20);      // Fentrega
            this.grdEventsListReservas.Columns[6].Width = (int)Math.Floor(width * .20);      // Importedia
            this.grdEventsListReservas.Columns[7].Width = (int)Math.Floor(width * .20);      // importekm
            this.grdEventsListReservas.Columns[8].Width = (int)Math.Floor(width * .20);      // kmrecorridos
            this.grdEventsListReservas.Columns[9].Width = (int)Math.Floor(width * .20);      // iva
            this.grdEventsListReservas.Columns[10].Width = (int)Math.Floor(width * .20);      // gas
            this.grdEventsListReservas.Columns[11].Width = (int)Math.Floor(width * .20);      // suplencia
            this.grdEventsListReservas.Columns[12].Width = (int)Math.Floor(width * .20);      // precioFactura


            //int width = width-415;                              // 40 (fixed cols + margin needed)
            this.grdEventsListClientes.Columns[0].Width = (int)Math.Floor(width * .125);      // Nif
            this.grdEventsListClientes.Columns[1].Width = (int)Math.Floor(width * .25);      // Name
            this.grdEventsListClientes.Columns[2].Width = (int)Math.Floor(width * .125);      // Tlf
            this.grdEventsListClientes.Columns[3].Width = (int)Math.Floor(width * .25);      // Adress
            this.grdEventsListClientes.Columns[4].Width = (int)Math.Floor(width * .25);      // Email

        }

        private void OnCellClicked(object sender, DataGridViewCellEventArgs evt)
        {
            if (evt.ColumnIndex == (this.grdEventsListReservas.Columns.Count - 2))
            {
                this.evt = evt;
                RemoveReserva.PerformClick();
            }
            else
            if (evt.ColumnIndex == (this.grdEventsListReservas.Columns.Count - 1))
            {
                this.evt = evt;
                EditFindReserva.PerformClick();
            }
        }

        private void buildPanelClientes()
        {
            //Definimos los botones que no se van a mostrar pero usaremos para lanzar los clicks al core
            RemoveCliente = new Button();
            EditFindCliente = new Button();

            this.grdEventsListClientes = new DataGridView();

            this.grdEventsListClientes.Dock = DockStyle.Fill;
            this.grdEventsListClientes.AllowUserToResizeRows = false;
            this.grdEventsListClientes.RowHeadersVisible = false;
            this.grdEventsListClientes.AutoGenerateColumns = false;
            this.grdEventsListClientes.MultiSelect = false;
            this.grdEventsListClientes.AllowUserToAddRows = false;

            var textCellTemplate = new DataGridViewTextBoxCell();
            var imageEditTemplate = new DataGridViewButtonCell();
            var imageDeleteTemplate = new DataGridViewButtonCell();
            textCellTemplate.Style.BackColor = Color.Wheat;
            textCellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            imageEditTemplate.UseColumnTextForButtonValue = true;
            imageDeleteTemplate.UseColumnTextForButtonValue = true;

            var column0 = new DataGridViewTextBoxColumn();
            var column1 = new DataGridViewTextBoxColumn();
            var column2 = new DataGridViewTextBoxColumn();
            var column3 = new DataGridViewTextBoxColumn();
            var column4 = new DataGridViewTextBoxColumn();
            var column5 = new DataGridViewButtonColumn();
            var column6 = new DataGridViewButtonColumn();

            column0.CellTemplate = textCellTemplate;
            column1.CellTemplate = textCellTemplate;
            column2.CellTemplate = textCellTemplate;
            column3.CellTemplate = textCellTemplate;
            column4.CellTemplate = textCellTemplate;
            column5.CellTemplate = imageEditTemplate;
            column6.CellTemplate = imageDeleteTemplate;

            column5.Text = "Eliminar";
            column6.Text = "Editar";

            column0.HeaderText = "NIF";
            column0.Width = 75;
            column0.SortMode = DataGridViewColumnSortMode.Automatic;
            column0.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column1.HeaderText = "Nombre";
            column1.Width = 150;
            column1.SortMode = DataGridViewColumnSortMode.Automatic;
            column1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column2.HeaderText = "Telefono";
            column2.Width = 75;
            column2.SortMode = DataGridViewColumnSortMode.NotSortable;
            column2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column3.HeaderText = "Dirección";
            column3.Width = 150;
            column3.SortMode = DataGridViewColumnSortMode.NotSortable;
            column3.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column4.HeaderText = "Email";
            column4.Width = 150;
            column4.SortMode = DataGridViewColumnSortMode.NotSortable;
            column4.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column5.HeaderText = "";
            column6.HeaderText = "";
            column5.Width = 50;
            column5.SortMode = DataGridViewColumnSortMode.NotSortable;
            column5.Resizable = DataGridViewTriState.False;
            column5.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column6.Width = 50;
            column6.SortMode = DataGridViewColumnSortMode.NotSortable;
            column6.Resizable = DataGridViewTriState.False;
            column6.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column5.ReadOnly = true;
            column6.ReadOnly = true;

            this.grdEventsListClientes.Columns.AddRange(new DataGridViewColumn[] {
                column0,
                column1,
                column2,
                column3,
                column4,
                column5,
                column6
            });
            this.grdEventsListClientes.ReadOnly = true;

            this.grdEventsListClientes.CellContentClick += this.OnCellClickedClientes;
            this.grdEventsListClientes.Dock = DockStyle.Fill;
            this.grdEventsListClientes.TabIndex = 3;
            this.grdEventsListClientes.AllowUserToOrderColumns = false;
            this.pnlInfo = new Panel();
            this.pnlInfo.SuspendLayout();
            this.pnlInfo.Dock = DockStyle.Fill;
            this.pnlEventsContainer = new Panel();
            this.pnlEventsContainer.Dock = DockStyle.Fill;
            this.pnlEventsContainer.Controls.Add(this.grdEventsListClientes);
            this.pnlInfo.Controls.Add(this.pnlEventsContainer);
        }

        protected void OnResizeWindowClientes(object sender, System.EventArgs e)
        {
            Control control = (Control)sender;
            int width = control.Size.Width - 417;

            this.grdEventsList.Width = width;



        }

        private void OnCellClickedClientes(object sender, DataGridViewCellEventArgs evt)
        {
            if (evt.ColumnIndex == (this.grdEventsListClientes.Columns.Count - 2))
            {
                this.evt = evt;
                RemoveCliente.PerformClick();
            }
            else
            if (evt.ColumnIndex == (this.grdEventsListClientes.Columns.Count - 1))
            {
                this.evt = evt;
                EditFindCliente.PerformClick();
            }
        }

        private void BuildPanelListaFlota()
        {
            DeleteFlota = new Button();
            EditFindFlota = new Button();
            panelListaFlota = new Panel();
            panelListaFlota.SuspendLayout();
            panelListaFlota.Dock = DockStyle.Fill;

            // Crear gridview
            this.grdEventsListFlota = new DataGridView()
            {
                Dock = DockStyle.Fill,
                AllowUserToResizeRows = false,
                RowHeadersVisible = false,
                AutoGenerateColumns = false,
                MultiSelect = false,
                AllowUserToAddRows = false,
                EnableHeadersVisualStyles = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            };
            var textCellTemplate = new DataGridViewTextBoxCell();
            var imageEditTemplate = new DataGridViewButtonCell();
            var imageDeleteTemplate = new DataGridViewButtonCell();
            textCellTemplate.Style.BackColor = Color.Wheat;
            imageEditTemplate.UseColumnTextForButtonValue = true;
            imageDeleteTemplate.UseColumnTextForButtonValue = true;
            this.grdEventsListFlota.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            this.grdEventsListFlota.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            textCellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var column0 = new DataGridViewTextBoxColumn();
            var column1 = new DataGridViewTextBoxColumn();
            var column2 = new DataGridViewTextBoxColumn();
            var column3 = new DataGridViewTextBoxColumn();
            var column4 = new DataGridViewTextBoxColumn();
            var column5 = new DataGridViewTextBoxColumn();
            var column6 = new DataGridViewTextBoxColumn();
            var column7 = new DataGridViewTextBoxColumn();
            var column8 = new DataGridViewTextBoxColumn();

            var column9 = new DataGridViewButtonColumn();
            var column10 = new DataGridViewButtonColumn();

            column0.CellTemplate = textCellTemplate;
            column1.CellTemplate = textCellTemplate;
            column2.CellTemplate = textCellTemplate;
            column3.CellTemplate = textCellTemplate;
            column4.CellTemplate = textCellTemplate;
            column5.CellTemplate = textCellTemplate;
            column6.CellTemplate = textCellTemplate;
            column7.CellTemplate = textCellTemplate;
            column8.CellTemplate = textCellTemplate;
            column9.CellTemplate = imageEditTemplate;
            column10.CellTemplate = imageDeleteTemplate;

            column9.Text = "Eliminar";
            column10.Text = "Editar";

            column0.HeaderText = "Matricula";
            column0.Width = 75;
            column0.SortMode = DataGridViewColumnSortMode.NotSortable;
            column0.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column1.HeaderText = "Tipo";
            column1.Width = 75;
            column1.SortMode = DataGridViewColumnSortMode.NotSortable;
            column1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column2.HeaderText = "Marca";
            column2.Width = 75;
            column2.SortMode = DataGridViewColumnSortMode.NotSortable;
            column2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column3.HeaderText = "Modelo";
            column3.Width = 75;
            column3.SortMode = DataGridViewColumnSortMode.NotSortable;
            column3.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column4.HeaderText = "Consumo por Km";
            column4.Width = 150;
            column4.SortMode = DataGridViewColumnSortMode.NotSortable;
            column4.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column5.HeaderText = "Fecha de adquisición";
            column5.Width = 150;
            column5.SortMode = DataGridViewColumnSortMode.NotSortable;
            column6.HeaderText = "Fecha de fabricación";
            column6.Width = 150;
            column6.SortMode = DataGridViewColumnSortMode.NotSortable;
            column6.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column7.HeaderText = "Carga";
            column7.Width = 75;
            column7.SortMode = DataGridViewColumnSortMode.NotSortable;
            column7.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column8.HeaderText = "Comodidades";
            column8.Width = 150;
            column8.SortMode = DataGridViewColumnSortMode.NotSortable;
            column8.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column9.HeaderText = "";
            column10.HeaderText = "";
            column9.Width = 50;
            column9.SortMode = DataGridViewColumnSortMode.NotSortable;
            column9.Resizable = DataGridViewTriState.False;
            column9.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column10.Width = 50;
            column10.SortMode = DataGridViewColumnSortMode.NotSortable;
            column10.Resizable = DataGridViewTriState.False;
            column9.ReadOnly = true;
            column10.ReadOnly = true;
            column10.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.grdEventsListFlota.Columns.AddRange(new DataGridViewColumn[] {
                column0,
                column7,
                column1,
                column2,
                column3,
                column4,
                column5,
                column6,
                column8,
                column9,
                column10
            });

            this.grdEventsListFlota.ReadOnly = true;
            this.grdEventsListFlota.CellContentClick += this.OnCellClickedFlota;
            this.grdEventsListFlota.Dock = DockStyle.Fill;
            this.grdEventsListFlota.TabIndex = 3;
            this.grdEventsListFlota.AllowUserToOrderColumns = false;
            this.pnlInfo = new Panel();
            this.pnlInfo.SuspendLayout();
            this.pnlInfo.Dock = DockStyle.Fill;
            this.pnlEventsContainer = new Panel();
            this.pnlEventsContainer.Dock = DockStyle.Fill;
            this.pnlEventsContainer.Controls.Add(this.grdEventsListFlota);
            this.pnlInfo.Controls.Add(this.pnlEventsContainer);

        }
        protected void OnResizeWindowFlota(object sender, System.EventArgs e)
        {
            Control control = (Control)sender;
            int width = control.Size.Width - 417;

            this.grdEventsListFlota.Width = width;

            this.grdEventsListFlota.Columns[0].Width = (int)Math.Floor(width * .20);      // Matricula
            this.grdEventsListFlota.Columns[1].Width = (int)Math.Floor(width * .20);      // Tipo
            this.grdEventsListFlota.Columns[2].Width = (int)Math.Floor(width * .20);      // Marca
            this.grdEventsListFlota.Columns[3].Width = (int)Math.Floor(width * .20);      // Modelo
            this.grdEventsListFlota.Columns[4].Width = (int)Math.Floor(width * .20);      // Consumo Km
            this.grdEventsListFlota.Columns[5].Width = (int)Math.Floor(width * .20);      // Fadquisicion
            this.grdEventsListFlota.Columns[6].Width = (int)Math.Floor(width * .20);      // Ffabricacion
            this.grdEventsListFlota.Columns[7].Width = (int)Math.Floor(width * .20);      // Carga
            this.grdEventsListFlota.Columns[8].Width = (int)Math.Floor(width * .20);      // Comodidades


        }

        private void OnCellClickedFlota(object sender, DataGridViewCellEventArgs evt)
        {
            if (evt.ColumnIndex == (this.grdEventsListFlota.Columns.Count - 2))
            {
                this.evt = evt;
                DeleteFlota.PerformClick();
            }
            else
            if (evt.ColumnIndex == (this.grdEventsListFlota.Columns.Count - 1))
            {
                this.evt = evt;
                EditFindFlota.PerformClick();
            }
        }



        /*------------------------------------------------------------------*/
        /*------------------InicializarPanelDerecha-------------------------*/
        /*------------------------------------------------------------------*/
        //Reservas

        Panel buildPanelMsg()
        {
            var panel = new Panel() { Dock = DockStyle.Top };

            this.EdMsg = new TextBox() { Dock = DockStyle.Fill, MaximumSize = new Size(int.MaxValue, 20), MinimumSize = new Size(50, 10), ReadOnly = true, ForeColor = Color.Red, BackColor = Color.LightGray };

            panel.Controls.Add(this.EdMsg);
            panel.MaximumSize = new Size(int.MaxValue, this.EdMsg.Height);

            return panel;
        }
        public void crearPanelesPequenosReserva()
        {

            BoxAddReservas = new TableLayoutPanel() { Dock = DockStyle.Right };

            PanelAdd1Reservas = this.buildPanelAdd1Reservas();
            PanelAdd2Reservas = this.buildPanelAdd2Reservas();
            PanelAdd3Reservas = this.buildPanelAdd3Reservas();
            PanelAdd4Reservas = this.buildPanelAdd4Reservas();
            PanelAdd5Reservas = this.buildPanelAdd5Reservas();
            PanelAdd6Reservas = this.buildPanelAdd6Reservas();
            PanelAdd7Reservas = this.buildPanelAdd7Reservas();
            PanelAdd8Reservas = this.buildPanelAdd8Reservas();
            PanelAdd9Reservas = this.buildPanelAdd9Reservas();
            PanelAdd10Reservas = this.buildPanelAdd10Reservas();
            PanelAdd11Reservas = this.buildPanelAdd11Reservas();
            PanelAdd12Reservas = this.buildPanelAdd12Reservas();
            PanelAdd13Reservas = this.buildPanelAdd13Reservas();

            BoxAddReservas.Controls.Add(PanelAdd1Reservas);
            BoxAddReservas.Controls.Add(PanelAdd2Reservas);
            BoxAddReservas.Controls.Add(PanelAdd3Reservas);
            BoxAddReservas.Controls.Add(PanelAdd4Reservas);
            BoxAddReservas.Controls.Add(PanelAdd5Reservas);
            BoxAddReservas.Controls.Add(PanelAdd6Reservas);
            BoxAddReservas.Controls.Add(PanelAdd7Reservas);
            BoxAddReservas.Controls.Add(PanelAdd8Reservas);
            BoxAddReservas.Controls.Add(PanelAdd9Reservas);
            BoxAddReservas.Controls.Add(PanelAdd10Reservas);
            BoxAddReservas.Controls.Add(PanelAdd11Reservas);
            BoxAddReservas.Controls.Add(PanelAdd12Reservas);
            BoxAddReservas.Controls.Add(PanelAdd13Reservas);

            BoxAddReservas.Width += 200;
        }
        Panel buildPanelAdd1Reservas()
        {
            var panel = new Panel() { Dock = DockStyle.Fill };
            var lblReserva = new Label() { Text = "Nueva Reserva", Dock = DockStyle.Top };

            var lblIdTransp = new Label() { Text = "IdTransporte: (ÚNICO)", Dock = DockStyle.Left, Width = 130 };
            this.tbIdTransp = new TextBox() { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Fill, Visible=false };

            panel.Controls.Add(this.tbIdTransp);
            panel.Controls.Add(lblIdTransp);

            panel.Controls.Add(lblReserva);
            panel.MaximumSize = new Size(this.Width, this.tbIdTransp.Height + lblReserva.Height);

            return panel;
        }
        Panel buildPanelAdd2Reservas()
        {
            var panel = new Panel() { Dock = DockStyle.Fill };

            var lblCliente = new Label() { Text = "Cliente: (NIF)", Dock = DockStyle.Left, Width = 130 };
            this.tbCliente = new TextBox() { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Fill };

            panel.Controls.Add(this.tbCliente);
            panel.Controls.Add(lblCliente);

            panel.MaximumSize = new Size(this.Width, this.tbCliente.Height);

            return panel;
        }
        Panel buildPanelAdd3Reservas()
        {
            var panel = new Panel() { Dock = DockStyle.Fill };

            var lblTipoTransp = new Label() { Text = "TipoTransporte: (Matrícula)", Dock = DockStyle.Left, Width = 130 };
            this.tbTipoTrans = new TextBox() { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Fill };

            panel.Controls.Add(this.tbTipoTrans);
            panel.Controls.Add(lblTipoTransp);

            panel.MaximumSize = new Size(this.Width, this.tbTipoTrans.Height);

            return panel;
        }
        Panel buildPanelAdd4Reservas()
        {
            var panel = new Panel() { Dock = DockStyle.Fill };

            var lblFcontra = new Label() { Text = "FechaContratacion: ", Dock = DockStyle.Left, Width = 130 };
            this.tbFcontra = new TextBox() { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Fill };

            panel.Controls.Add(this.tbFcontra);
            panel.Controls.Add(lblFcontra);

            panel.MaximumSize = new Size(this.Width, this.tbFcontra.Height);

            return panel;
        }
        Panel buildPanelAdd5Reservas()
        {
            var panel = new Panel() { Dock = DockStyle.Fill };

            var lblFsalida = new Label() { Text = "FechaSalida: ", Dock = DockStyle.Left, Width = 130 };
            this.tbFsalida = new TextBox() { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Fill };

            panel.Controls.Add(this.tbFsalida);
            panel.Controls.Add(lblFsalida);

            panel.MaximumSize = new Size(this.Width, this.tbFsalida.Height);

            return panel;
        }
        Panel buildPanelAdd6Reservas()
        {
            var panel = new Panel() { Dock = DockStyle.Fill };

            var lblFentrega = new Label() { Text = "FechaEntrega: ", Dock = DockStyle.Left, Width = 130 };
            this.tbFentrega = new TextBox() { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Fill };

            panel.Controls.Add(this.tbFentrega);
            panel.Controls.Add(lblFentrega);

            panel.MaximumSize = new Size(this.Width, this.tbFentrega.Height);

            return panel;
        }
        Panel buildPanelAdd7Reservas()
        {
            var panel = new Panel() { Dock = DockStyle.Fill };

            var lblEdia = new Label() { Text = "ImporteDia: ", Dock = DockStyle.Left, Width = 130 };
            this.tbEDia = new TextBox() { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Fill };

            panel.Controls.Add(this.tbEDia);
            panel.Controls.Add(lblEdia);

            panel.MaximumSize = new Size(this.Width, this.tbEDia.Height);

            return panel;
        }
        Panel buildPanelAdd8Reservas()
        {
            var panel = new Panel() { Dock = DockStyle.Fill };

            var lblEkm = new Label() { Text = "ImporteKm: ", Dock = DockStyle.Left, Width = 130 };
            this.tbEkm = new TextBox() { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Fill };

            panel.Controls.Add(this.tbEkm);
            panel.Controls.Add(lblEkm);

            panel.MaximumSize = new Size(this.Width, this.tbEkm.Height);

            return panel;
        }
        Panel buildPanelAdd9Reservas()
        {
            var panel = new Panel() { Dock = DockStyle.Fill };

            var lblKmRecorridos = new Label() { Text = "KilometrosRecorridos: ", Dock = DockStyle.Left, Width = 130 };
            this.tbKmRecorridos = new TextBox() { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Fill };

            panel.Controls.Add(this.tbKmRecorridos);
            panel.Controls.Add(lblKmRecorridos);

            panel.MaximumSize = new Size(this.Width, this.tbKmRecorridos.Height);

            return panel;
        }
        Panel buildPanelAdd10Reservas()
        {
            var panel = new Panel() { Dock = DockStyle.Fill };

            var lblGas = new Label() { Text = "Gas: ", Dock = DockStyle.Left, Width = 130 };
            this.tbGas = new TextBox() { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Fill };

            panel.Controls.Add(this.tbGas);
            panel.Controls.Add(lblGas);

            panel.MaximumSize = new Size(this.Width, this.tbGas.Height);


            return panel;
        }
        Panel buildPanelAdd11Reservas()
        {
            var panel = new Panel() { Dock = DockStyle.Fill };

            var lblIVA = new Label() { Text = "IVA: ", Dock = DockStyle.Left, Width = 130 };
            this.tbIVA = new TextBox() { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Fill };

            panel.Controls.Add(this.tbIVA);
            panel.Controls.Add(lblIVA);

            panel.MaximumSize = new Size(this.Width, this.tbIVA.Height);

            return panel;
        }
        Panel buildPanelAdd12Reservas()
        {
            var panel = new Panel() { Dock = DockStyle.Fill };

            var lblSuplencia = new Label() { Text = "NumeroConductores: ", Dock = DockStyle.Left, Width = 130 };
            this.tbSuplencia = new TextBox() { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Fill };

            panel.Controls.Add(this.tbSuplencia);
            panel.Controls.Add(lblSuplencia);

            panel.MaximumSize = new Size(this.Width, this.tbSuplencia.Height);

            return panel;
        }
        Panel buildPanelAdd13Reservas()
        {
            var panel = new Panel() { Dock = DockStyle.Fill };

            this.EditReserva = new Button() { Text = "Editar", Dock = DockStyle.Left };

            this.CreateReserva = new Button() { Text = "Crear", Dock = DockStyle.Right };

            panel.Controls.Add(EditReserva);
            panel.Controls.Add(CreateReserva);

            panel.MaximumSize = new Size(this.Width, this.tbCliente.Height + 20);

            return panel;
        }
        public void crearPanelesPequenosClientes()
        {

            BoxAddClientes = new TableLayoutPanel() { Dock = DockStyle.Right };

            PanelAdd1Clientes = this.buildPanelAdd1Clientes();
            PanelAdd2Clientes = this.buildPanelAdd2Clientes();
            PanelAdd3Clientes = this.buildPanelAdd3Clientes();
            PanelAdd4Clientes = this.buildPanelAdd4Clientes();
            PanelAdd5Clientes = this.buildPanelAdd5Clientes();
            PanelAdd6Clientes = this.buildPanelAdd6Clientes();



            BoxAddClientes.Controls.Add(PanelAdd1Clientes);
            BoxAddClientes.Controls.Add(PanelAdd2Clientes);
            BoxAddClientes.Controls.Add(PanelAdd3Clientes);
            BoxAddClientes.Controls.Add(PanelAdd4Clientes);
            BoxAddClientes.Controls.Add(PanelAdd5Clientes);
            BoxAddClientes.Controls.Add(PanelAdd6Clientes);


            BoxAddClientes.Width += 100;
        }

        //Clientes
        Panel buildPanelAdd1Clientes()
        {
            var panel = new Panel() { Dock = DockStyle.Fill };
            this.lblCliente = new Label() { Text = "Nuevo Cliente", Dock = DockStyle.Top };

            var lblNif = new Label() { Text = "Nif: (ÚNICO)", Dock = DockStyle.Left ,Width = 100};
            this.EdNif = new TextBox() { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Fill };

            panel.Controls.Add(this.EdNif);
            panel.Controls.Add(lblNif);

            panel.Controls.Add(lblCliente);
            panel.MaximumSize = new Size(this.Width, this.EdNif.Height + lblCliente.Height);

            return panel;
        }
        Panel buildPanelAdd2Clientes()
        {
            var panel = new Panel() { Dock = DockStyle.Fill };

            var lblName = new Label() { Text = "Nombre: ", Dock = DockStyle.Left };
            this.EdName = new TextBox() { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Fill };

            panel.Controls.Add(this.EdName);
            panel.Controls.Add(lblName);

            panel.MaximumSize = new Size(this.Width, this.EdName.Height);

            return panel;
        }
        Panel buildPanelAdd3Clientes()
        {
            var panel = new Panel() { Dock = DockStyle.Fill };

            var lblTlf = new Label() { Text = "Tlf: ", Dock = DockStyle.Left };
            this.EdTlf = new TextBox() { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Fill };

            panel.Controls.Add(this.EdTlf);
            panel.Controls.Add(lblTlf);

            panel.MaximumSize = new Size(this.Width, this.EdTlf.Height);

            return panel;
        }
        Panel buildPanelAdd4Clientes()
        {
            var panel = new Panel() { Dock = DockStyle.Fill };

            var lblMail = new Label() { Text = "Email: ", Dock = DockStyle.Left };
            this.EdMail = new TextBox() { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Fill };

            panel.Controls.Add(this.EdMail);
            panel.Controls.Add(lblMail);

            panel.MaximumSize = new Size(this.Width, this.EdMail.Height);

            return panel;
        }
        Panel buildPanelAdd5Clientes()
        {
            var panel = new Panel() { Dock = DockStyle.Fill };

            var lblDirec = new Label() { Text = "Direccion: ", Dock = DockStyle.Left };
            this.EdDirec = new TextBox() { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Fill };

            panel.Controls.Add(this.EdDirec);
            panel.Controls.Add(lblDirec);

            panel.MaximumSize = new Size(this.Width, this.EdDirec.Height);

            return panel;
        }
        Panel buildPanelAdd6Clientes()
        {
            var panel = new Panel() { Dock = DockStyle.Fill };

            panel.Controls.Add(EditCliente);
            panel.Controls.Add(CreateCliente);

            panel.MaximumSize = new Size(this.Width, this.EdName.Height + 20);

            return panel;
        }


        //Flota
        Panel BuildPanelBotonesAnhadir()
        {
            var toret = new Panel() { Dock = DockStyle.Fill };

            this.AcceptButton = this.btAñadir;

            toret.Controls.Add(this.btAñadir);
            toret.MaximumSize = new Size(this.Width, this.btAñadir.Height + 20);

            return toret;
        }
        Panel BuildPanelBotonesModificar()
        {
            var toret = new Panel() { Dock = DockStyle.Fill };

            this.AcceptButton = this.btModificar;

            toret.Controls.Add(this.btModificar);

            toret.MaximumSize = new Size(this.Width, this.btModificar.Height + 20);

            return toret;
        }
        Panel BuildPanelTipoCamionFlota()
        {
            var toret = new Panel { Dock = DockStyle.Fill };

            escogerTipo2 = new ComboBox();
            escogerTipo2.Parent = this;
            escogerTipo2.DropDownStyle = ComboBoxStyle.DropDownList;


            escogerTipo2.Items.AddRange(new object[] {"Furgoneta",
                "Camion",
                "Camion articulado"});

            escogerTipo2.SelectedItem = Tipo2;
            escogerTipo2.Text = Tipo2;
            toret.Controls.Add(this.escogerTipo2);

            toret.MaximumSize = new Size(int.MaxValue, escogerTipo2.Height * 2);
            return toret;

        }
        Panel buildPanelCarga()
        {
            var panel = new Panel { Dock = DockStyle.Fill };
            var lbCarga = new Label { Text = " Carga ", Dock = DockStyle.Left };
            this.edCarga = new TextBox { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Left, Width = 200 };
            panel.Controls.Add(edCarga);
            panel.Controls.Add(lbCarga);
         
            panel.Size = new Size(this.edCarga.Width, 20);
            return panel;
        }
        Panel buildPanelLetrasMatricula()
        {
            var panel = new Panel { Dock = DockStyle.Fill };
            var lbLetrasMatricula = new Label { Text = " Letras Matricula ", Dock = DockStyle.Left };
            this.edLetrasMatricula = new TextBox { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Left, Width = 200
            };
            panel.Controls.Add(edLetrasMatricula);
            panel.Controls.Add(lbLetrasMatricula);
            
            panel.Size = new Size(this.edLetrasMatricula.Width, 20);
            
            return panel;
        }
        Panel buildPanelDigitosMatricula()
        {
            var panel = new Panel { Dock = DockStyle.Fill };
            var lbDigitosMatricula = new Label { Text = " Digitos Matricula ", Dock = DockStyle.Left };
            this.edDigitosMatricula = new TextBox { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Left, Width = 200 };
            panel.Controls.Add(edDigitosMatricula);
            panel.Controls.Add(lbDigitosMatricula);

            panel.Size = new Size(this.edDigitosMatricula.Width, 20);
            return panel;
        }
        Panel buildPanelMarca()
        {
            var panel = new Panel { Dock = DockStyle.Fill };
            var lbMarca = new Label { Text = " Marca ", Dock = DockStyle.Left };
            this.edMarca = new TextBox { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Left, Width = 200 };
            panel.Controls.Add(edMarca);
            panel.Controls.Add(lbMarca);
            
            panel.Size = new Size(this.edMarca.Width, 20);
            return panel;
        }
        Panel buildPanelModelo()
        {
            var panel = new Panel { Dock = DockStyle.Fill };
            var lbModelo = new Label { Text = " Modelo ", Dock = DockStyle.Left };
            this.edModelo = new TextBox { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Left, Width = 200 };
            panel.Controls.Add(edModelo);
            panel.Controls.Add(lbModelo);
           
            panel.Size = new Size(this.edModelo.Width, 20);
            return panel;
        }
        Panel buildPanelConsumoKm()
        {
            var panel = new Panel { Dock = DockStyle.Fill };
            var lbConsumoKm = new Label { Text = " Consumo Km ", Dock = DockStyle.Left };
            this.edConsumoKm = new TextBox { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Left, Width = 200 };
            panel.Controls.Add(edConsumoKm);
            panel.Controls.Add(lbConsumoKm);
            panel.Size = new Size(edConsumoKm.Width, 20);
            return panel;
        }
        Panel buildPanelFechaAdquisicion()
        {
            var panel = new Panel { Dock = DockStyle.Fill };
            var lbFechaAdquisicion = new Label { Text = " F.Adquisición (dd/mm/yyyy)", Dock = DockStyle.Left };
            this.edFechaAdquisicion = new TextBox { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Left, Width = 200 };
            panel.Controls.Add(edFechaAdquisicion);
            panel.Controls.Add(lbFechaAdquisicion);
            
            panel.Size = new Size(edFechaAdquisicion.Width, 25);
            return panel;
        }
        Panel buildPanelFechaFabricacion()
        {
            var panel = new Panel { Dock = DockStyle.Fill };
            var lbFechaFabricacion = new Label { Text = " F.Fabricación (dd/mm/yyyy)", Dock = DockStyle.Left };
            this.edFechaFabricacion = new TextBox { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Left, Width = 200 };
            panel.Controls.Add(edFechaFabricacion);
            panel.Controls.Add(lbFechaFabricacion);
           
            panel.Size = new Size(edFechaFabricacion.Width, 25);
            return panel;
        }
        Panel buildPanelComodidadesFlota()
        {
            var panel = new Panel { Dock = DockStyle.Fill };
            var lbComodidades = new Label { Text = " Comodidades", Dock = DockStyle.Top };
            this.ComodidadWifi = new CheckBox { Text = "Wifi", Dock = DockStyle.Left, AutoCheck = true, Width = 50 };
            this.ComodidadBlue = new CheckBox { Text = "Conexion\n Bluetooth", Dock = DockStyle.Left, AutoCheck = true, Width = 80 };
            this.ComodidadAire = new CheckBox { Text = "Aire\n Acondicionado", Dock = DockStyle.Left, AutoCheck = true, Width = 110 };
            this.ComodidadLitera = new CheckBox { Text = "Litera", Dock = DockStyle.Left, AutoCheck = true, Width = 60 };
            this.ComodidadTv = new CheckBox { Text = "Tv", Dock = DockStyle.Left, AutoCheck = true ,Width= 50};

           
            panel.Controls.Add(ComodidadWifi);
            panel.Controls.Add(ComodidadAire);
            panel.Controls.Add(ComodidadLitera);
            panel.Controls.Add(ComodidadBlue);
            panel.Controls.Add(ComodidadTv);
            panel.Controls.Add(lbComodidades);
            panel.Size = new Size(300,50);
            return panel;
        }

        //Builds paneles operaciones
        public void BuildPanelAddFlota()
        {
            var label = new Label
            {
                Text = "Añadir Flota\n-----------------------------------------------------------------------------------",
                Dock = DockStyle.Top
            };
            this.panelAnhadir = new TableLayoutPanel { Dock = DockStyle.Right };

            panelAnhadir.Controls.Add(label);

            var panelTipoCamion = this.BuildPanelTipoCamionFlota();
            this.panelAnhadir.Controls.Add(panelTipoCamion);

            var panelCarga = this.buildPanelCarga();
            this.panelAnhadir.Controls.Add(panelCarga);

            var panelLetrasMatricula = this.buildPanelLetrasMatricula();
            this.panelAnhadir.Controls.Add(panelLetrasMatricula);

            var panelDigitosMatricula = this.buildPanelDigitosMatricula();
            this.panelAnhadir.Controls.Add(panelDigitosMatricula);

            var panelMarca = this.buildPanelMarca();
            this.panelAnhadir.Controls.Add(panelMarca);

            var panelModelo = this.buildPanelModelo();
            this.panelAnhadir.Controls.Add(panelModelo);

            var panelConsumoKm = this.buildPanelConsumoKm();
            this.panelAnhadir.Controls.Add(panelConsumoKm);

            var panelFechaFabricacion = this.buildPanelFechaFabricacion();
            this.panelAnhadir.Controls.Add(panelFechaFabricacion);

            var panelFechaAdquisicion = this.buildPanelFechaAdquisicion();
            this.panelAnhadir.Controls.Add(panelFechaAdquisicion);

            var panelComodidades = this.buildPanelComodidadesFlota();
            this.panelAnhadir.Controls.Add(panelComodidades);

            var pnlBotones = this.BuildPanelBotonesAnhadir();
            this.panelAnhadir.Controls.Add(pnlBotones);

            this.panelAnhadir.MinimumSize = new Size(390, 1000);
            
        }

        Panel BuildPanelTipoCamionFlotaM()
        {
            var toret = new Panel { Dock = DockStyle.Fill };

            escogerTipo2M = new ComboBox();
            escogerTipo2M.Parent = this;
            escogerTipo2M.DropDownStyle = ComboBoxStyle.DropDownList;


            escogerTipo2M.Items.AddRange(new object[] {"Furgoneta",
                "Camion",
                "Camion articulado"});

            escogerTipo2M.SelectedItem = Tipo2M;
            escogerTipo2M.Text = Tipo2M;
            toret.Controls.Add(this.escogerTipo2M);

            toret.MaximumSize = new Size(int.MaxValue, escogerTipo2M.Height * 2);
            return toret;

        }
        Panel buildPanelCargaM()
        {
            var panel = new Panel { Dock = DockStyle.Fill };
            var lbCarga = new Label { Text = " Carga ", Dock = DockStyle.Left };
            this.edCargaM = new TextBox { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Left, Width = 200 };
            panel.Controls.Add(edCargaM);
            panel.Controls.Add(lbCarga);

            panel.Size = new Size(this.edCargaM.Width, 20);
            return panel;
        }
        Panel buildPanelMarcaM()
        {
            var panel = new Panel { Dock = DockStyle.Fill };
            var lbMarca = new Label { Text = " Marca ", Dock = DockStyle.Left };
            this.edMarcaM = new TextBox { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Left, Width = 200 };
            panel.Controls.Add(edMarcaM);
            panel.Controls.Add(lbMarca);

            panel.Size = new Size(this.edMarcaM.Width, 20);
            return panel;
        }
        Panel buildPanelModeloM()
        {
            var panel = new Panel { Dock = DockStyle.Fill };
            var lbModelo = new Label { Text = " Modelo ", Dock = DockStyle.Left };
            this.edModeloM = new TextBox { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Left, Width = 200 };
            panel.Controls.Add(edModeloM);
            panel.Controls.Add(lbModelo);

            panel.Size = new Size(this.edModeloM.Width, 20);
            return panel;
        }
        Panel buildPanelConsumoKmM()
        {
            var panel = new Panel { Dock = DockStyle.Fill };
            var lbConsumoKm = new Label { Text = " Consumo Km ", Dock = DockStyle.Left };
            this.edConsumoKmM = new TextBox { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Left, Width = 200 };
            panel.Controls.Add(edConsumoKmM);
            panel.Controls.Add(lbConsumoKm);
            panel.Size = new Size(edConsumoKmM.Width, 20);
            return panel;
        }
        Panel buildPanelFechaAdquisicionM()
        {
            var panel = new Panel { Dock = DockStyle.Fill };
            var lbFechaAdquisicion = new Label { Text = " F.Adquisición (dd/mm/yyyy)", Dock = DockStyle.Left };
            this.edFechaAdquisicionM = new TextBox { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Left, Width = 200 };
            panel.Controls.Add(edFechaAdquisicionM);
            panel.Controls.Add(lbFechaAdquisicion);

            panel.Size = new Size(edFechaAdquisicionM.Width, 25);
            return panel;
        }
        Panel buildPanelFechaFabricacionM()
        {
            var panel = new Panel { Dock = DockStyle.Fill };
            var lbFechaFabricacion = new Label { Text = " F.Fabricación (dd/mm/yyyy)", Dock = DockStyle.Left };
            this.edFechaFabricacionM = new TextBox { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Left, Width = 200 };
            panel.Controls.Add(edFechaFabricacionM);
            panel.Controls.Add(lbFechaFabricacion);

            panel.Size = new Size(edFechaFabricacionM.Width, 25);
            return panel;
        }
        Panel buildPanelComodidadesFlotaM()
        {
            var panel = new Panel { Dock = DockStyle.Fill };
            var lbComodidades = new Label { Text = " Comodidades", Dock = DockStyle.Top };
            this.ComodidadWifiM = new CheckBox { Text = "Wifi", Dock = DockStyle.Left, AutoCheck = true, Width = 50 };
            this.ComodidadBlueM = new CheckBox { Text = "Conexion\n Bluetooth", Dock = DockStyle.Left, AutoCheck = true, Width = 80 };
            this.ComodidadAireM = new CheckBox { Text = "Aire\n Acondicionado", Dock = DockStyle.Left, AutoCheck = true, Width = 110 };
            this.ComodidadLiteraM = new CheckBox { Text = "Litera", Dock = DockStyle.Left, AutoCheck = true, Width = 60 };
            this.ComodidadTvM= new CheckBox { Text = "Tv", Dock = DockStyle.Left, AutoCheck = true, Width = 50 };


            panel.Controls.Add(ComodidadWifiM);
            panel.Controls.Add(ComodidadAireM);
            panel.Controls.Add(ComodidadLiteraM);
            panel.Controls.Add(ComodidadBlueM);
            panel.Controls.Add(ComodidadTvM);
            panel.Controls.Add(lbComodidades);
            panel.Size = new Size(300, 50);
            return panel;
        }
        Panel buildPanelMatricula()
        {
            var panel = new Panel { Dock = DockStyle.Fill };
            var lbMatricula = new Label { Text = " Matricula ", Dock = DockStyle.Left };
            this.edMatricula = new TextBox { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Left, Width = 200 };
            panel.Controls.Add(edMatricula);
            panel.Controls.Add(lbMatricula);

            panel.Size = new Size(this.edMatricula.Width, 20);
            return panel;
        }

        public void BuildPanelModificar()
        {
            var label = new Label
            {
                Text = "Modificar Flota\n-----------------------------------------------------------------------------------",
                Dock = DockStyle.Top
            };
            this.panelModificar = new TableLayoutPanel { Dock = DockStyle.Right };
            
            panelModificar.Controls.Add(label);

            var panelMatricula = this.buildPanelMatricula();
            this.panelModificar.Controls.Add(panelMatricula);


            var panelTipoCamion = this.BuildPanelTipoCamionFlotaM();
            this.panelModificar.Controls.Add(panelTipoCamion);

            var panelCarga = this.buildPanelCargaM();
            this.panelModificar.Controls.Add(panelCarga);


            var panelMarca = this.buildPanelMarcaM();
            this.panelModificar.Controls.Add(panelMarca);

            var panelModelo = this.buildPanelModeloM();
            this.panelModificar.Controls.Add(panelModelo);

            var panelConsumoKm = this.buildPanelConsumoKmM();
            this.panelModificar.Controls.Add(panelConsumoKm);

            var panelFechaFabricacion = this.buildPanelFechaFabricacionM();
            this.panelModificar.Controls.Add(panelFechaFabricacion);

            var panelFechaAdquisicion = this.buildPanelFechaAdquisicionM();
            this.panelModificar.Controls.Add(panelFechaAdquisicion);

            var panelComodidades = this.buildPanelComodidadesFlotaM();
            this.panelModificar.Controls.Add(panelComodidades);

            var pnlBotones = this.BuildPanelBotonesModificar();
            this.panelModificar.Controls.Add(pnlBotones);

            panelModificar.MinimumSize = new Size(390, 1000);

        }

        /*------------------------------------------------------------------*/
        /*-----------------------BuildMenu----------------------------------*/
        /*------------------------------------------------------------------*/

        private void BuildMenu()
        {
            this.menuPrincipal = new MainMenu();

            this.menuArchivo = new MenuItem("&Archivo");
            this.menuGenerar = new MenuItem("&Generar");
            this.operacionGestionarClientes = new MenuItem("&Clientes");
            this.operacionGestionarReservas = new MenuItem("&Reservas");
            this.operacionGestionarFlota = new MenuItem("&Flota");
            this.menuAtras = new MenuItem("&Atras");
            this.operacionSalir = new MenuItem("&Salir") { Shortcut = Shortcut.CtrlQ };

            /*//Operaciones generar gráfico
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
            };*/


            //Menú superior
            this.menuArchivo.MenuItems.Add(this.operacionSalir);
            this.menuPrincipal.MenuItems.Add(this.menuArchivo);
            //this.menuPrincipal.MenuItems.Add(this.menuGenerar);
            this.menuPrincipal.MenuItems.Add(this.operacionGestionarClientes);
            this.menuPrincipal.MenuItems.Add(this.operacionGestionarReservas);
            this.menuPrincipal.MenuItems.Add(this.operacionGestionarFlota);
            this.menuPrincipal.MenuItems.Add(this.menuAtras);
            this.Menu = menuPrincipal;


            /*//Submenú gráficos
            this.menuGenerar.MenuItems.Add(this.operacionActividadGeneral);
            this.menuGenerar.MenuItems.Add(this.operacionActividadCliente);
            this.menuGenerar.MenuItems.Add(this.operacionActividadCamion);
            this.menuGenerar.MenuItems.Add(this.operacionActividadComodidades);*/
        }

        /*------------------------------------------------------------------*/
        /*------------------TransportesPendientes---------------------------*/
        /*------------------------------------------------------------------*/

        //var label = new Label { Dock = DockStyle.Top };
        //label.Text = "Matricula";
        //panelSearch.Controls.Add(label);
        public Panel buildPanelTransportesPendientes()
        { 
            var label = new Label { Text = "Búsqueda transportes pendientes\n-----------------------------------------------------------------------------------",
                Dock = DockStyle.Top};
            var panelSearch = new Panel { Dock = DockStyle.Fill };
            var pnlBotones = this.BuildPanelBotones();
            panelSearch.Controls.Add(pnlBotones);

            var panelMatriculaCamion = this.BuildPanelMatriculaCamion();
            
            panelSearch.Controls.Add(panelMatriculaCamion);
            panelSearch.Controls.Add(label);

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
            var toret = new TableLayoutPanel { Dock = DockStyle.Top };
            Text = "ComboBox";
            Size = new Size(240, 240);

            escogerCamion = new ComboBox() { Dock = DockStyle.Left };
            escogerCamion.Parent = this;
            escogerCamion.DropDownStyle = ComboBoxStyle.DropDownList;
            List<object> Camiones = new List<object>();
            Camiones.Add("Todos");
            foreach (Flota d in MainWindow.Reg.GetFlotas())
            {
                Camiones.Add(d.Matricula);
            }

            escogerCamion.Items.AddRange(Camiones.ToArray());
            if (Camiones.Count() != 0)
            {
                escogerCamion.SelectedItem = Camiones.First();
                escogerCamion.Text = Camiones.First().ToString();
            }
            toret.Controls.Add(this.escogerCamion);
            toret.MaximumSize = new Size(int.MaxValue, escogerCamion.Height * 2);

            return toret;

        }

        /*------------------------------------------------------------------*/
        /*------------------Disponibilidad---------------------------*/
        /*------------------------------------------------------------------*/
        public Panel buildPanelDisponibilidad()
        {
            var label = new Label
            {
                Text = "Busqueda de Camiones libres\n-----------------------------------------------------------------------------------",
                Dock = DockStyle.Top
            };
            var panelSearch = new Panel { Dock = DockStyle.Fill };

            var pnlBotones = this.BuildPanelBotones5();
            panelSearch.Controls.Add(pnlBotones);

            var panelDisponibilidad = this.BuildPanelTipoCamionDis();

            panelSearch.Controls.Add(panelDisponibilidad);
            panelSearch.Controls.Add(label);

            panelSearch.MinimumSize = new Size(this.Width, this.tbCliente.Height + 20);
            return panelSearch;
        }
        private Panel BuildPanelBotones5()
        {
            var toret = new TableLayoutPanel()
            {
                ColumnCount = 2,
                RowCount = 1
            };

            this.AcceptButton = this.btSearchDisponibilidad;
            toret.Controls.Add(this.btSearchDisponibilidad);
            toret.Dock = DockStyle.Top;
            return toret;
        }
        public Panel BuildPanelTipoCamionDis()
        {
            var toret = new Panel { Dock = DockStyle.Top };
            Text = "ComboBox";
            Size = new Size(240, 240);

            escogerTipoDis = new ComboBox();
            escogerTipoDis.Parent = this;
            escogerTipoDis.DropDownStyle = ComboBoxStyle.DropDownList;

            escogerTipoDis.Items.AddRange(new object[] {"Todos",
            "Furgoneta",
            "Camion",
            "Camion Articulado"});

            escogerTipoDis.SelectedItem = "Todos";
            escogerTipoDis.Text = "Todos";
            toret.Controls.Add(this.escogerTipoDis);
            toret.MaximumSize = new Size(int.MaxValue, escogerTipoDis.Height * 2);
            return toret;

        }

        /*------------------------------------------------------------------*/
        /*------------------Transporte Cliente------------------------------*/
        /*------------------------------------------------------------------*/
        public Panel panelSearchTransporteCLiente { get; set; }

        private Panel BuildPanelBotones3()
        {
            var toret = new TableLayoutPanel()
            {
                ColumnCount = 3,
                RowCount = 1
            };

            this.AcceptButton = this.btSearchTransporteCliente;       
            toret.Controls.Add(this.btSearchTransporteCliente);
            toret.Controls.Add(this.operacionGraficoCliente);
            toret.Dock = DockStyle.Top;
            return toret;
        }
        public Panel BuildPanelCliente()
        {

            var toret = new Panel { Dock = DockStyle.Top };
            Text = "ComboBox";
            Size = new Size(240, 240);

            escogerCliente = new Label();
            escogerCliente.Text = "";
            escogerCliente.Parent = this;
            
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
            foreach (Reservas t in MainWindow.Reg.GetReservas())
            {
                if (!anhos.Contains(t.Fentrega.Year))
                {
                    anhos.Add(t.Fentrega.Year);
                }
            }

            escogerAnho2.Items.AddRange(anhos.ToArray());
            if (anhos.Count() != 0)
            {
                escogerAnho2.SelectedItem = anhos.First();
                escogerAnho2.Text = anhos.First().ToString();
            }
            toret.Controls.Add(this.escogerAnho2);
            toret.MaximumSize = new Size(int.MaxValue, escogerAnho2.Height * 2);
            return toret;

        }
        public void buildPanelTransporteCliente()
        {
            var label = new Label
            {
                Text = "Búsqueda transportes por clientes\n-----------------------------------------------------------------------------------",
                Dock = DockStyle.Top
            };
             panelSearchTransporteCLiente = new Panel { Dock = DockStyle.Fill };
          

            var pnlBotones = this.BuildPanelBotones3();
            panelSearchTransporteCLiente.Controls.Add(pnlBotones);

            var panelAnhos = this.BuildPanelEscogerAnho2();
            panelSearchTransporteCLiente.Controls.Add(panelAnhos);

            var panelPeriodo = this.BuildPanelPasadasOPendientes2();
            panelSearchTransporteCLiente.Controls.Add(panelPeriodo);

            var panelCliente = this.BuildPanelCliente();
            panelSearchTransporteCLiente.Controls.Add(panelCliente);

            panelSearchTransporteCLiente.Controls.Add(label);

            panelSearchTransporteCLiente.MinimumSize = new Size(this.Width, this.tbCliente.Height + 20);
            
        }

        /*------------------------------------------------------------------*/
        /*------------------Reservas Camion---------------------------------*/
        /*------------------------------------------------------------------*/

        public Panel panelSearchReservasCamion { get; set; }

        public void buildPanelReservasCamion()
        {
            var label = new Label
            {
                Text = "Búsqueda reservas por camion\n-----------------------------------------------------------------------------------",
                Dock = DockStyle.Top
            };
            //Panel búsqueda
            panelSearchReservasCamion = new TableLayoutPanel { Dock = DockStyle.Fill };
            panelSearchReservasCamion.Controls.Add(label);
            //Panel Matrícula
            var panelMatriculaCamion = this.BuildPanelMatriculaCamion2();
            panelSearchReservasCamion.Controls.Add(panelMatriculaCamion);
            //Panel período
            var panelPeriodo = this.BuildPanelPasadasOPendientes();
            panelSearchReservasCamion.Controls.Add(panelPeriodo);
            //Panel años
            var panelAnhos = this.BuildPanelEscogerAnho();
            panelSearchReservasCamion.Controls.Add(panelAnhos);
            //Panel botones
            var pnlBotones = this.BuildPanelBotones2();
            panelSearchReservasCamion.Controls.Add(pnlBotones);

            panelSearchReservasCamion.MinimumSize = new Size(this.Width, this.tbCliente.Height + 20);

        }
        private Panel BuildPanelBotones2()
        {
            var toret = new TableLayoutPanel()
            {
                ColumnCount = 3,
                RowCount = 1
            };

            this.AcceptButton = this.btSearchCamiones2;
            toret.Controls.Add(this.btSearchCamiones2);
            toret.Controls.Add(this.operacionGraficoCamion);
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
            foreach (Flota d in MainWindow.Reg.GetFlotas())
            {
                Camiones.Add(d.Matricula);
            }

            escogerCamion2.Items.AddRange(Camiones.ToArray());
            if (Camiones.Count() != 0)
            {
                escogerCamion2.SelectedItem = Camiones.First();
                escogerCamion2.Text = Camiones.First().ToString();
            }
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
            foreach (Reservas t in MainWindow.Reg.GetReservas())
            {
                if (!anhos.Contains(t.Fentrega.Year))
                {
                    anhos.Add(t.Fentrega.Year);
                }
            }

            escogerAnho.Items.AddRange(anhos.ToArray());
            if (anhos.Count() != 0)
            {
                escogerAnho.SelectedItem = anhos.First();
                escogerAnho.Text = anhos.First().ToString();
            }
            toret.Controls.Add(this.escogerAnho);
            toret.MaximumSize = new Size(int.MaxValue, escogerAnho.Height * 2);
            return toret;

        }

        /*------------------------------------------------------------------*/
        /*------------------Reservas Cliente---------------------------------*/
        /*------------------------------------------------------------------*/
        public Panel panelSearchReservasCliente { get; set; }
        public void buildPanelReservasCliente()
        {


            var label = new Label
            {
                Text = "Búsqueda reservas por cliente\n-----------------------------------------------------------------------------------",
                Dock = DockStyle.Top
            };
            panelSearchReservasCliente = new TableLayoutPanel { Dock = DockStyle.Fill };
            panelSearchReservasCliente.Controls.Add(label);
            var panelIdDni = this.BuildPanelIdTransporte4();
            panelSearchReservasCliente.Controls.Add(panelIdDni);

            var panelAnhos = this.BuildPanelEscogerAnho4();
            panelSearchReservasCliente.Controls.Add(panelAnhos);

            var pnlBotones = this.BuildPanelBotones4();
            panelSearchReservasCliente.Controls.Add(pnlBotones);

            panelSearchReservasCliente.MinimumSize = new Size(this.Width, this.tbCliente.Height + 20);

        }
        private Panel BuildPanelIdTransporte4()
        {
            var toret = new Panel { Dock = DockStyle.Top };

            escogerCliente4 = new Label();
            escogerCliente4.Parent = this;

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
            foreach (Reservas t in MainWindow.Reg.GetReservas())
            {
                if (!anhos.Contains(t.Fentrega.Year))
                {
                    anhos.Add(t.Fentrega.Year);
                }
            }

            escogerAnho4.Items.AddRange(anhos.ToArray());
            if (anhos.Count() != 0)
            {
                escogerAnho4.SelectedItem = anhos.First();
                escogerAnho4.Text = anhos.First().ToString();
            }
            toret.Controls.Add(this.escogerAnho4);
            toret.MaximumSize = new Size(int.MaxValue, escogerAnho4.Height * 2);
            return toret;
        }
        private Panel BuildPanelBotones4()
        {
            var toret = new TableLayoutPanel()
            {
                ColumnCount = 3,
                RowCount = 1
            };


            this.AcceptButton = this.btSearchCliente4;
            toret.Controls.Add(this.btSearchCliente4);
            toret.Controls.Add(this.operacionGraficoCliente2);
            toret.Dock = DockStyle.Top;
            return toret;
        }

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
            Fecha5 = calendar.SelectionStart;
           
            date = new Label();
            date.Parent = this;
            date.Location = new Point(40, 170);
          
            date.Text = Fecha5.Month + "/" + Fecha5.Day + "/" + Fecha5.Year;

            toret.Controls.Add(this.calendar);
            toret.Controls.Add(this.date);

            toret.MinimumSize = new Size(int.MaxValue, calendar.Height + date.Height + 50);
            return toret;
        }
        public void OnSelected(object sender, EventArgs e)
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
            foreach (Reservas t in MainWindow.Reg.GetReservas())
            {
                if (!anhos.Contains(t.Fentrega.Year))
                {
                    anhos.Add(t.Fentrega.Year);
                }
            }

            escogerAnho5.Items.AddRange(anhos.ToArray());

            if (anhos.Count() != 0)
            {
                escogerAnho5.SelectedItem = anhos.First();
                escogerAnho5.Text = anhos.First().ToString();
            }


            this.AcceptButton = this.btSearchOcupacionAnho5;
            toret.Controls.Add(this.escogerAnho5);
            toret.Controls.Add(this.btSearchOcupacionAnho5);

            toret.MaximumSize = new Size(int.MaxValue, escogerAnho5.Height * 2);
            return toret;

        }
        public Panel buildPanelOcupacion()
        {
            var label = new Label
            {
                Text = "Búsqueda por ocupación\n-----------------------------------------------------------------------------------",
                Dock = DockStyle.Top
            };
            var panelSearch = new TableLayoutPanel { Dock = DockStyle.Fill };
            panelSearch.Controls.Add(label);
            var panelIdFecha = this.BuildPanelFecha5();
            panelSearch.Controls.Add(panelIdFecha);

            var panelAnhos = this.BuildPanelEscogerAnho5();
            panelSearch.Controls.Add(panelAnhos);

            

            panelSearch.MinimumSize = new Size(this.Width, this.tbCliente.Height + 20);

            return panelSearch;
        }

        /*------------------------------------------------------------------*/
        /*--------------------------Comodidades-----------------------------*/
        /*------------------------------------------------------------------*/
        public Panel buildPanelComodidades()
        {
            var label = new Label
            {
                Text = "Búsqueda comodidades de camión\n-----------------------------------------------------------------------------------",
                Dock = DockStyle.Top
            };
            var panelSearch = new TableLayoutPanel { Dock = DockStyle.Fill };
            panelSearch.Controls.Add(label);

            var pnlComodidades = this.BuildPanelEscogerComodidades();
            panelSearch.Controls.Add(pnlComodidades);

            var pnlBotones = this.BuildPanelBotones7();
            panelSearch.Controls.Add(pnlBotones);


            panelSearch.MinimumSize = new Size(this.Width, this.tbCliente.Height + 20);

            return panelSearch;
        }
        private Panel BuildPanelBotones7()
        {
            var toret = new TableLayoutPanel()
            {
                ColumnCount = 3,
                RowCount = 1
            };

            this.AcceptButton = this.btSearchComodidad;
            toret.Controls.Add(this.btSearchComodidad);
            toret.Controls.Add(this.operacionGraficoComodidades);
            toret.Dock = DockStyle.Top;
            return toret;
        }
        public Panel BuildPanelEscogerComodidades()
        {
            var toret = new FlowLayoutPanel { Dock = DockStyle.Top };
            Text = "ComboBox";
            Size = new Size(240, 240);

            escogerComodidades = new ComboBox();
            escogerComodidades.Parent = this;
            escogerComodidades.DropDownStyle = ComboBoxStyle.DropDownList;
            List<object> comodidades = new List<object>();
            foreach (Flota t in MainWindow.Reg.GetFlotas())
            {
                foreach (String com in t.Comodidades)
                {
                    if (!comodidades.Contains(com))
                    {
                        comodidades.Add(com);
                    }
                }
                
            }

            escogerComodidades.Items.AddRange(comodidades.ToArray());
            if (comodidades.Count() != 0)
            {
                escogerComodidades.SelectedItem = comodidades.First();
                escogerComodidades.Text = comodidades.First().ToString();
            }
            toret.Controls.Add(this.escogerComodidades);

            toret.MaximumSize = new Size(int.MaxValue, escogerComodidades.Height * 2);
            return toret;
        }

        /*------------------------------------------------------------------*/
        /*---------------------------Gráficos-------------------------------*/
        /*------------------------------------------------------------------*/
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
           // this.MinimumSize = new Size(CHART_CANVAS_SIZE, CHART_CANVAS_SIZE);
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

        /*------------------------------------------------------------------*/
        /*-------------------------Panel inferior---------------------------*/
        /*------------------------------------------------------------------*/
        public void inicializarBotones()
        {
            calendar = new MonthCalendar();
            /*Busquedas*/
            this.btSearchCliente4 = new Button()
            {
                DialogResult = DialogResult.OK,
                Text = "&Buscar"
            };
            this.btSearchDisponibilidad = new Button()
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
            this.btSearchOcupacionAnho5 = new Button()
            {
                DialogResult = DialogResult.OK,
                Text = "&Buscar por anhos",
                Size = new Size(100, 20)
            };
            this.btSearchComodidad = new Button()
            {
                DialogResult = DialogResult.OK,
                Text = "&Buscar por comodidad",
                Size = new Size(130, 20)
            };
            this.operacionGraficoCamion = new Button() { Text = "Generar grafico", Size = new Size(100, 20) };
            this.operacionGraficoCliente = new Button() { Text = "Generar grafico", Size = new Size(100, 20) };
            this.operacionGraficoCliente2 = new Button() { Text = "Generar grafico", Size = new Size(100, 20) };
            this.operacionGraficoComodidades = new Button() { Text = "Generar grafico", Size = new Size(100, 20) };

            /*Clientes*/
            this.EditCliente = new Button() { Text = "Editar", Dock = DockStyle.Left };
            this.CreateCliente = new Button() { Text = "Crear", Dock = DockStyle.Right };

            /*Panel opciones reservas */
            this.btGestionReservas = new Button() { Text = "Crear reservas ", Dock = DockStyle.Left };
            this.operacionSearch1 = new Button() { Text = "Transportes pendientes", Dock = DockStyle.Left };
            this.operacionSearch3 = new Button() { Text = "Transportes por cliente", Dock = DockStyle.Left };
            this.operacionSearch4 = new Button() { Text = "Reservas por camion", Dock = DockStyle.Left };
            this.operacionSearch5 = new Button() { Text = "Reservas por cliente", Dock = DockStyle.Left };
            this.operacionSearch6 = new Button() { Text = "Ocupacion", Dock = DockStyle.Left };
            this.operacionSearch7 = new Button() { Text = "Comodidades", Dock = DockStyle.Left, Width = 100 };
            this.operacionGraficoGeneral = new Button() { Text = "Gráfico general", Dock = DockStyle.Left };
            
            /*Panel opciones clientes */
            this.btGestionClientes = new Button() { Text = "Crear cliente ", Dock = DockStyle.Left };


            /*Panel opciones flotas */
            this.AnhadirFlota = new Button() { Text = "Crear flota ", Dock = DockStyle.Left };
            this.operacionSearch2 = new Button() { Text = "Disponibilidad", Dock = DockStyle.Left, Width =100 };


            /*Flota*/
            this.btAñadir = new Button()
            {
                DialogResult = DialogResult.OK,
                Text = "&Añadir",
                Dock = DockStyle.Bottom
            };

            this.btModificar = new Button()
            {
                DialogResult = DialogResult.OK,
                Text = "&Modificar",
                Dock = DockStyle.Bottom
            };

        }
        public Panel buildPanelOpcionesReservas()
        {
            var label = new Label
            {
                Text = "\nOpciones para reservas\n-----------------------------------------------------------------------------------",
                Dock = DockStyle.Top,
                Height = 50
            };
            var panelSearch = new Panel { Dock = DockStyle.Bottom };
            
    
            panelSearch.Controls.Add(this.operacionSearch6);
      
         
           
            
            panelSearch.Controls.Add(this.btGestionReservas);
            panelSearch.Controls.Add(label);

            panelSearch.MinimumSize = new Size(this.Width, this.tbCliente.Height + 20);

            return panelSearch;
        }
        public Panel buildPanelOpcionesClientes()
        {
            var label = new Label
            {
                Text = "\nOpciones para clientes\n-----------------------------------------------------------------------------------",
                Dock = DockStyle.Top,
                Height = 50
            };
            var panelSearch = new Panel { Dock = DockStyle.Bottom };
            panelSearch.Controls.Add(this.operacionSearch5);
            panelSearch.Controls.Add(this.operacionSearch3);
            panelSearch.Controls.Add(this.btGestionClientes);
          
            panelSearch.Controls.Add(label);

            panelSearch.MinimumSize = new Size(this.Width, this.tbCliente.Height + 20);

            return panelSearch;
        }
        public Panel buildPanelOpcionesFlota()
        {
            var label = new Label
            {
                Text = "\nOpciones para flota\n-----------------------------------------------------------------------------------",
                Dock = DockStyle.Top,
                Height = 50
            };
            var panelSearch = new Panel { Dock = DockStyle.Bottom };

            
            panelSearch.Controls.Add(this.AnhadirFlota);
            panelSearch.Controls.Add(this.operacionSearch7);
            panelSearch.Controls.Add(this.operacionSearch2);
            panelSearch.Controls.Add(this.operacionSearch1);
            panelSearch.Controls.Add(this.operacionSearch4);

            panelSearch.Controls.Add(label);

            panelSearch.MinimumSize = new Size(this.Width, this.tbCliente.Height + 20);

            return panelSearch;
        }
    }
}
            

           
