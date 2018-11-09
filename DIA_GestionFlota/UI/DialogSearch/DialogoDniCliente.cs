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

            var pnlBotones = this.BuildPanelBotones();
            this.panelSearch.Controls.Add(pnlBotones);

            this.panelSearch.ResumeLayout(true);

            this.Text = "Busqueda de Transportes Pasados o Pendientes";
            this.Size = new Size(400, panelIdDni.Height + pnlBotones.Height);

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ResumeLayout(false);

        }

        private Panel panelSearch;
        public ComboBox escogerCliente { get; set; }
        public string idDni { get => this.escogerCliente.Text.Trim(); set => idDni = value.ToString(); }
        public Button btCierra { get; set; }
        public Button btSearchCliente { get; set; }
    }
}
