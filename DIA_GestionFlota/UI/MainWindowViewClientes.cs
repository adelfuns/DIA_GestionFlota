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
    public partial class MainWindowViewClientes : Form
    {
        public MainWindowViewClientes()
        {
            this.Build();
        }

        public TextBox EdClientes { get; private set; }
        public TextBox EdNif { get; private set; }
        public TextBox EdName { get; private set; }
        public TextBox EdTlf { get; private set; }
        public TextBox EdMail { get; private set; }
        public TextBox EdDirec { get; private set; }
        public Button CreateCliente { get; private set; }
        public Button RemoveCliente { get; private set; }
        public Button EditFindCliente { get; private set; }
        public Button EditCliente { get; private set; }
        public TextBox EdMsg { get; private set; }

        public DataGridView grdEventsList;

        private Panel pnlInfo;
        private Panel pnlEventsContainer;
        public DataGridViewCellEventArgs evt { get; private set; }
        public Label lblCliente { get; private set; }

        void Build()
        {
            var BoxAdd = new TableLayoutPanel() { Dock = DockStyle.Right };
            var BoxMsg = new TableLayoutPanel() { Dock = DockStyle.Bottom };

            this.buildPanelClientes();

            var panelAdd1 = this.buildPanelAdd1();
            var panelAdd2 = this.buildPanelAdd2();
            var panelAdd3 = this.buildPanelAdd3();
            var panelAdd4 = this.buildPanelAdd4();
            var panelAdd5 = this.buildPanelAdd5();
            var panelAdd6 = this.buildPanelAdd6();

            var panelMsg = this.buildPanelMsg();


            BoxAdd.Controls.Add(panelAdd1);
            BoxAdd.Controls.Add(panelAdd2);
            BoxAdd.Controls.Add(panelAdd3);
            BoxAdd.Controls.Add(panelAdd4);
            BoxAdd.Controls.Add(panelAdd5);
            BoxAdd.Controls.Add(panelAdd6);

            BoxAdd.BorderStyle = BorderStyle.FixedSingle;

            BoxMsg.Controls.Add(panelMsg);

            this.Controls.Add(this.grdEventsList);
            this.Controls.Add(BoxAdd);
            this.Controls.Add(BoxMsg);

            this.Resize += (obj, args) => this.OnResizeWindow(obj, args);

            BoxMsg.Height -= 75;
            BoxAdd.Width += 100;

            this.MinimumSize = new Size(1020, 600);
            this.Text = "Gestion Clientes";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.CenterToScreen();
            this.Show();
        }

        private void buildPanelClientes()
        {
            //Definimos los botones que no se van a mostrar pero usaremos para lanzar los clicks al core
            RemoveCliente = new Button();
            EditFindCliente = new Button();

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
            column1.HeaderText = "Nombre";
            column1.Width = 150;
            column1.SortMode = DataGridViewColumnSortMode.Automatic;
            column2.HeaderText = "Telefono";
            column2.Width = 75;
            column2.SortMode = DataGridViewColumnSortMode.NotSortable;
            column3.HeaderText = "Dirección";
            column3.Width = 150;
            column3.SortMode = DataGridViewColumnSortMode.NotSortable;
            column4.HeaderText = "Email";
            column4.Width = 150;
            column4.SortMode = DataGridViewColumnSortMode.NotSortable;
            column5.HeaderText = "";
            column6.HeaderText = "";
            column5.Width = 50;
            column5.SortMode = DataGridViewColumnSortMode.NotSortable;
            column5.Resizable = DataGridViewTriState.False;
            column6.Width = 50;
            column6.SortMode = DataGridViewColumnSortMode.NotSortable;
            column6.Resizable = DataGridViewTriState.False;
            column5.ReadOnly = true;
            column6.ReadOnly = true;

            this.grdEventsList.Columns.AddRange(new DataGridViewColumn[] {
                column0,
                column1,
                column2,
                column3,
                column4,
                column5,
                column6
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

            //int width = width-415;                              // 40 (fixed cols + margin needed)
            this.grdEventsList.Columns[0].Width = (int)Math.Floor(width * .125);      // Nif
            this.grdEventsList.Columns[1].Width = (int)Math.Floor(width * .25);      // Name
            this.grdEventsList.Columns[2].Width = (int)Math.Floor(width * .125);      // Tlf
            this.grdEventsList.Columns[3].Width = (int)Math.Floor(width * .25);      // Adress
            this.grdEventsList.Columns[4].Width = (int)Math.Floor(width * .25);      // Email

        }

        private void OnCellClicked(object sender, DataGridViewCellEventArgs evt)
        {
            if (evt.ColumnIndex == (this.grdEventsList.Columns.Count - 2))
            {
                this.evt = evt;
                RemoveCliente.PerformClick();
            }
            else
            if (evt.ColumnIndex == (this.grdEventsList.Columns.Count - 1))
            {
                this.evt = evt;
                EditFindCliente.PerformClick();
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
            this.lblCliente = new Label() { Text = "Nuevo Cliente", Dock = DockStyle.Top };

            var lblNif = new Label() { Text = "Nif: (ÚNICO)", Dock = DockStyle.Left };
            this.EdNif = new TextBox() { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Fill };

            panel.Controls.Add(this.EdNif);
            panel.Controls.Add(lblNif);

            panel.Controls.Add(lblCliente);
            panel.MaximumSize = new Size(this.Width, this.EdNif.Height + lblCliente.Height);

            return panel;
        }

        Panel buildPanelAdd2()
        {
            var panel = new Panel() { Dock = DockStyle.Fill };

            var lblName = new Label() { Text = "Nombre: ", Dock = DockStyle.Left };
            this.EdName = new TextBox() { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Fill };

            panel.Controls.Add(this.EdName);
            panel.Controls.Add(lblName);

            panel.MaximumSize = new Size(this.Width, this.EdName.Height);

            return panel;
        }

        Panel buildPanelAdd3()
        {
            var panel = new Panel() { Dock = DockStyle.Fill };

            var lblTlf = new Label() { Text = "Tlf: ", Dock = DockStyle.Left };
            this.EdTlf = new TextBox() { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Fill };

            panel.Controls.Add(this.EdTlf);
            panel.Controls.Add(lblTlf);

            panel.MaximumSize = new Size(this.Width, this.EdTlf.Height);

            return panel;
        }

        Panel buildPanelAdd4()
        {
            var panel = new Panel() { Dock = DockStyle.Fill };

            var lblMail = new Label() { Text = "Email: ", Dock = DockStyle.Left };
            this.EdMail = new TextBox() { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Fill };

            panel.Controls.Add(this.EdMail);
            panel.Controls.Add(lblMail);

            panel.MaximumSize = new Size(this.Width, this.EdMail.Height);

            return panel;
        }

        Panel buildPanelAdd5()
        {
            var panel = new Panel() { Dock = DockStyle.Fill };

            var lblDirec = new Label() { Text = "Direccion: ", Dock = DockStyle.Left };
            this.EdDirec = new TextBox() { TextAlign = HorizontalAlignment.Left, Dock = DockStyle.Fill };

            panel.Controls.Add(this.EdDirec);
            panel.Controls.Add(lblDirec);

            panel.MaximumSize = new Size(this.Width, this.EdDirec.Height);

            return panel;
        }

        Panel buildPanelAdd6()
        {
            var panel = new Panel() { Dock = DockStyle.Fill };

            this.EditCliente = new Button() { Text = "Editar", Dock = DockStyle.Left };

            this.CreateCliente = new Button() { Text = "Crear", Dock = DockStyle.Right };

            panel.Controls.Add(EditCliente);
            panel.Controls.Add(CreateCliente);

            panel.MaximumSize = new Size(this.Width, this.EdName.Height + 20);

            return panel;
        }

    }
}
