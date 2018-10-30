namespace Busquedas.Core
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    class DialogoTransportePendiente : Form
    {
        public DialogoTransportePendiente()
        {

            this.Build();
        }

        public void Reset()
        {
            this.edIdTransporte.Text = "";

        }

        public bool Validar()
        {
            var btAccept = (Button)this.AcceptButton;
            bool invalid =
               string.IsNullOrWhiteSpace(this.idTransporte.ToString());

            if (invalid)
            {
                this.edIdTransporte.Text = "";
            }
            btAccept.Enabled = !invalid;

            return invalid;
        }

        public void ValidarPerdidaFoco()
        {
            var btAccept = (Button)this.AcceptButton;
            bool invalid =
                string.IsNullOrWhiteSpace(this.idTransporte.ToString());

            if (invalid)
            {
                btAccept.Enabled = false;
            }
            else
            {
                btAccept.Enabled = true;

            }

        }

        private Panel BuildPanelIdTransporte()
        {
            var toret = new Panel { Dock = DockStyle.Top };
            this.edIdTransporte = new TextBox { TextAlign = HorizontalAlignment.Right, Dock = DockStyle.Fill };

            var lbIdTransporte = new Label
            {
                Text = "IdTransporte:",
                Dock = DockStyle.Left
            };

            toret.Controls.Add(this.edIdTransporte);
            toret.Controls.Add(lbIdTransporte);
            toret.MaximumSize = new Size(int.MaxValue, edIdTransporte.Height * 2);

            this.edIdTransporte.Validating += (sender, cancelArgs) => {
                var btAccept = (Button)this.AcceptButton;
                bool invalid = string.IsNullOrWhiteSpace(this.edIdTransporte.ToString());

                if (invalid)
                {
                    this.edIdTransporte.Text = "";
                }
                btAccept.Enabled = !invalid;

            };

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

            this.btSearchDTP = new Button()
            {
                DialogResult = DialogResult.OK,
                Text = "&Buscar"
            };


            this.AcceptButton = this.btSearchDTP;
            this.CancelButton = this.btCierra;

            toret.Controls.Add(this.btSearchDTP);
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


            var panelIdTransporte = this.BuildPanelIdTransporte();
            this.panelSearch.Controls.Add(panelIdTransporte);

            var pnlBotones = this.BuildPanelBotones();
            this.panelSearch.Controls.Add(pnlBotones);

            this.panelSearch.ResumeLayout(true);

            this.Text = "Busqueda de Transportes Pendientes";
            this.Size = new Size(400, panelIdTransporte.Height + pnlBotones.Height);

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ResumeLayout(false);

        }

        private Panel panelSearch;
        public TextBox edIdTransporte { get; set; }
        public string idTransporte { get => this.edIdTransporte.Text.Trim(); set => idTransporte = value.ToString(); }
        public Button btCierra { get; set; }
        public Button btSearchDTP { get; set; }
    }
}
