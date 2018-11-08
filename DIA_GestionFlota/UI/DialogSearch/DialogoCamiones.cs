namespace GestionFlotas.UI.DialogSearch
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    class DialogoCamiones : Form
    {
        public DialogoCamiones()
        {

            this.Build();
        }

        public void Reset()
        {
            this.escogerTipo.Text = "";
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

            this.btSearchCamiones = new Button()
            {
                DialogResult = DialogResult.OK,
                Text = "&Buscar"
            };


            this.AcceptButton = this.btSearchCamiones;
            this.CancelButton = this.btCierra;

            toret.Controls.Add(this.btSearchCamiones);
            toret.Controls.Add(this.btCierra);
            toret.Dock = DockStyle.Top;


            return toret;
        }

        public Panel BuildPanelTipoCamion()
        {

            var toret = new Panel { Dock = DockStyle.Top };
            Text = "ComboBox";
            Size = new Size(240, 240);

            escogerTipo = new ComboBox();
            escogerTipo.Parent = this;


            escogerTipo.Items.AddRange(new object[] {"Todos",
            "Mudanza",
            "Transporte de mercancías",
            "Transporte de vehículos"});

            escogerTipo.SelectedItem = "Todos";
            escogerTipo.Text = "Todos";
            toret.Controls.Add(this.escogerTipo);
            toret.MaximumSize = new Size(int.MaxValue, escogerTipo.Height * 2);
            return toret;

        }


        private void Build()
        {
            this.SuspendLayout();

            this.panelSearch = new TableLayoutPanel { Dock = DockStyle.Fill };
            this.panelSearch.SuspendLayout();
            this.Controls.Add(this.panelSearch);


            var panelTipoCamion = this.BuildPanelTipoCamion();
            this.panelSearch.Controls.Add(panelTipoCamion);

            var pnlBotones = this.BuildPanelBotones();
            this.panelSearch.Controls.Add(pnlBotones);

            this.panelSearch.ResumeLayout(true);

            this.Text = "Busqueda de Camiones libres";
            this.Size = new Size(400, panelTipoCamion.Height + pnlBotones.Height);

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ResumeLayout(false);

        }

        private Panel panelSearch;

        private ComboBox escogerTipo { get; set; }
        public string Tipo => escogerTipo.Text;
        public Button btCierra { get; set; }
        public Button btSearchCamiones { get; set; }
    }
}
