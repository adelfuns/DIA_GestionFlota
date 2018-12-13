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
            var BoxAdd = new TableLayoutPanel() { Dock = DockStyle.Right };
            var BoxMsg = new TableLayoutPanel() { Dock = DockStyle.Bottom };

            this.buildPanelReservas();

            var panelAdd1 = this.buildPanelAdd1();
            var panelAdd2 = this.buildPanelAdd2();
            var panelAdd3 = this.buildPanelAdd3();
            var panelAdd4 = this.buildPanelAdd4();
            var panelAdd5 = this.buildPanelAdd5();
            var panelAdd6 = this.buildPanelAdd6();
            var panelAdd7 = this.buildPanelAdd7();
            var panelAdd8 = this.buildPanelAdd8();
            var panelAdd9 = this.buildPanelAdd9();
            var panelAdd10 = this.buildPanelAdd10();
            var panelAdd11 = this.buildPanelAdd11();
            var panelAdd12 = this.buildPanelAdd12();
            var panelAdd13 = this.buildPanelAdd13();

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
            this.Controls.Add(BoxAdd);
            this.Controls.Add(BoxMsg);

            this.Resize += (obj, args) => this.OnResizeWindow(obj, args);

            BoxMsg.Height -= 75;
            BoxAdd.Width += 100;

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


    }
}