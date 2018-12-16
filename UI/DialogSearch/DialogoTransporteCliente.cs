namespace GestionFlotas.UI.DialogSearch
{
    using DIA_GestionFlota;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Linq;
    class DialogoTransporteCliente : Form
    {
        public DialogoTransporteCliente()
        {

            this.Build();
        }

        public void Reset()
        {
            this.escogerCliente.Text = "";
        }

        private Panel BuildPanelBotones()
        {
            var toret = new TableLayoutPanel()
            {
                ColumnCount = 2,
                RowCount = 1
            };

            this.btCierra = new Button()
            {
                DialogResult = DialogResult.Cancel,
                Text = "&Cancelar"
            };

            this.btSearchTransporteCliente = new Button()
            {
                DialogResult = DialogResult.OK,
                Text = "&Buscar"
            };


            this.AcceptButton = this.btSearchTransporteCliente;
            this.CancelButton = this.btCierra;

            toret.Controls.Add(this.btSearchTransporteCliente);
            toret.Controls.Add(this.btCierra);
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
            
            foreach(Cliente c in MainWindow.clientes)
            {
                NIFs.Add(c.Nif);
            }

            escogerCliente.Items.AddRange(NIFs.ToArray());

            escogerCliente.SelectedItem = NIFs.First();
            escogerCliente.Text = NIFs.First().ToString();
            toret.Controls.Add(this.escogerCliente);
            toret.MaximumSize = new Size(int.MaxValue, escogerCliente.Height * 2);
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
            foreach (Transportes t in MainWindow.transportes)
            {
                if (!anhos.Contains(t.FechaEntrega.Year))
                {
                    anhos.Add(t.FechaEntrega.Year);
                }
            }

            escogerAnho.Items.AddRange(anhos.ToArray());

            escogerAnho.SelectedItem = anhos.First();
            escogerAnho.Text = anhos.First().ToString();
            toret.Controls.Add(this.escogerAnho);
            toret.MaximumSize = new Size(int.MaxValue, escogerAnho.Height * 2);
            return toret;

        }
        private void Build()
        {
            this.SuspendLayout();

            this.panelSearch = new TableLayoutPanel { Dock = DockStyle.Fill };
            this.panelSearch.SuspendLayout();
            this.Controls.Add(this.panelSearch);


            var panelCliente = this.BuildPanelTipoCamion();
            this.panelSearch.Controls.Add(panelCliente);

            var panelPeriodo = this.BuildPanelPasadasOPendientes();
            this.panelSearch.Controls.Add(panelPeriodo);

            var panelAnhos = this.BuildPanelEscogerAnho();
            this.panelSearch.Controls.Add(panelAnhos);

            var pnlBotones = this.BuildPanelBotones();
            this.panelSearch.Controls.Add(pnlBotones);

            this.panelSearch.ResumeLayout(true);

            this.Text = "Busqueda de Transportes de clientes, pasadas o pendientes";
            this.Size = new Size(400, panelCliente.Height  + panelPeriodo.Height + panelPeriodo.Height + pnlBotones.Height);

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ResumeLayout(false);

        }

        private Panel panelSearch;

        private ComboBox escogerCliente { get; set; }
        private ComboBox escogerPeriodo { get; set; }
        private ComboBox escogerAnho { get; set; }

        public string Anho => escogerAnho.Text;
        public string Cliente => escogerCliente.Text;
        public string Periodo => escogerPeriodo.Text;
        public Button btCierra { get; set; }
        public Button btSearchTransporteCliente { get; set; }
    }



}

