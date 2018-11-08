namespace DIA_GestionFlota
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    class DialogoDniCliente : Form
    {
        public DialogoDniCliente()
        {

            this.Build();
        }

        public void Reset()
        {
            this.edIdDni.Text = "";
        }



        public bool Validar()
        {
            var btAccept = (Button)this.AcceptButton;
            bool invalid =
               string.IsNullOrWhiteSpace(this.idDni.ToString());

            if (invalid)
            {
                this.edIdDni.Text = "";
            }
            btAccept.Enabled = !invalid;

            return invalid;
        }

        public void ValidarPerdidaFoco()
        {
            var btAccept = (Button)this.AcceptButton;
            bool invalid =
                string.IsNullOrWhiteSpace(this.idDni.ToString());

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
            this.edIdDni = new TextBox { TextAlign = HorizontalAlignment.Right, Dock = DockStyle.Fill };

            var lbIdTransporte = new Label
            {
                Text = "Dni:",
                Dock = DockStyle.Left
            };

            toret.Controls.Add(this.edIdDni);
            toret.Controls.Add(lbIdTransporte);
            toret.MaximumSize = new Size(int.MaxValue, edIdDni.Height * 2);

            this.edIdDni.Validating += (sender, cancelArgs) => {
                var btAccept = (Button)this.AcceptButton;
                bool invalid = string.IsNullOrWhiteSpace(this.edIdDni.ToString());

                if (invalid)
                {
                    this.edIdDni.Text = "";
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
        public TextBox edIdDni { get; set; }
        public string idDni { get => this.edIdDni.Text.Trim(); set => idDni = value.ToString(); }
        public Button btCierra { get; set; }
        public Button btSearchCliente { get; set; }
    }
}
