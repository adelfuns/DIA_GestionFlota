namespace DIA_GestionFlota
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    class DialogoDniCliente : Form
    {
        public DialogoDniCliente()
        {

            this.Build();
        }


        private Panel BuildPanelIdTransporte()
        {
            var toret = new Panel { Dock = DockStyle.Top };
            Text = "ComboBox";
            Size = new Size(240, 240);

            escogerCliente = new ComboBox();
            escogerCliente.Parent = this;
            escogerCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            List<object> NIFs = new List<object>();

            foreach (Cliente c in MainWindow.clientes)
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

            this.btSearchCliente = new Button()
            {
                DialogResult = DialogResult.OK,
                Text = "&Buscar"
            };


            this.AcceptButton = this.btSearchCliente;
            this.CancelButton = this.btCierra;

            toret.Controls.Add(this.btSearchCliente);
            toret.Controls.Add(this.btCierra);
            toret.Dock = DockStyle.Top;


            return toret;
        }

        private void Build()
        {
            this.SuspendLayout();

            this.panelSearch = new TableLayoutPanel { Dock = DockStyle.Fill };
            this.panelSearch.SuspendLayout();
            this.Controls.Add(this.panelSearch);


            var panelIdDni = this.BuildPanelIdTransporte();
            this.panelSearch.Controls.Add(panelIdDni);

            var panelAnhos = this.BuildPanelEscogerAnho();
            this.panelSearch.Controls.Add(panelAnhos);

            var pnlBotones = this.BuildPanelBotones();
            this.panelSearch.Controls.Add(pnlBotones);

            this.panelSearch.ResumeLayout(true);

            this.Text = "Busqueda de Reservas para una persona";
            this.Size = new Size(400, panelIdDni.Height + panelAnhos.Height + pnlBotones.Height);

            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MinimizeBox = true;
            this.CenterToScreen();
            this.MaximizeBox = true;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Dock = DockStyle.Fill;
            this.ResumeLayout(false);

        }

        private Panel panelSearch;
        public ComboBox escogerCliente { get; set; }
        private ComboBox escogerAnho { get; set; }

        public string Anho => escogerAnho.Text;
        public string idDni { get => this.escogerCliente.Text.Trim(); set => idDni = value.ToString(); }
        public Button btCierra { get; set; }
        public Button btSearchCliente { get; set; }
    }
}
