

namespace GestionFlotas.UI.DialogSearch
{
    using DIA_GestionFlota;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    class DialogoTransportesPendientes : Form
    {
        public DialogoTransportesPendientes()
        {
            this.Build();
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


        private void Build()
        {
            this.SuspendLayout();

            this.panelSearch = new TableLayoutPanel { Dock = DockStyle.Fill };
            this.panelSearch.SuspendLayout();
            this.Controls.Add(this.panelSearch);

            var panelMatriculaCamion = this.BuildPanelMatriculaCamion();
            this.panelSearch.Controls.Add(panelMatriculaCamion);

            var pnlBotones = this.BuildPanelBotones();
            this.panelSearch.Controls.Add(pnlBotones);

            this.panelSearch.ResumeLayout(true);

            this.Text = "Busqueda de Transportes Pendientes";
            this.Size = new Size(400, panelMatriculaCamion.Height + pnlBotones.Height);

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ResumeLayout(false);

        }

        private Panel panelSearch;

        private ComboBox escogerCamion { get; set; }
        public string Matricula { get => this.escogerCamion.Text.Trim(); set => Matricula = value.ToString(); }
        public Button btCierra { get; set; }
        public Button btSearchCamiones { get; set; }
    }
}






