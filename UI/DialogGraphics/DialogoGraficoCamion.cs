namespace GestionFlotas.UI.DialogGraphics
{
    using DIA_GestionFlota;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Linq;
    class DialogoGraficoCamion : Form
    {
        public DialogoGraficoCamion()
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

            this.btGraficoGeneralTotal = new Button()
            {
                DialogResult = DialogResult.OK,
                Text = "&Total"
            };


            this.AcceptButton = this.btGraficoGeneralTotal;
            this.CancelButton = this.btCierra;

            toret.Controls.Add(this.btGraficoGeneralTotal);
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

        public Panel BuildPanelEscogerAnho()
        {
            var toret = new FlowLayoutPanel { Dock = DockStyle.Top, };
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

            this.btGraficoGeneralAnual = new Button()
            {
                DialogResult = DialogResult.OK,
                Text = "&Aceptar",
                Size = new Size(100, 20)
            };

            this.AcceptButton = this.btGraficoGeneralAnual;
            toret.Controls.Add(this.escogerAnho);
            toret.Controls.Add(this.btGraficoGeneralAnual);

            toret.MaximumSize = new Size(int.MaxValue, escogerAnho.Height * 2);
            return toret;
        }

        private void Build()
        {
            this.SuspendLayout();

            this.panelGrafico = new TableLayoutPanel { Dock = DockStyle.Fill };
            this.panelGrafico.SuspendLayout();
            this.Controls.Add(this.panelGrafico);


            var panelCamion = this.BuildPanelMatriculaCamion();
            this.panelGrafico.Controls.Add(panelCamion);

            var panelAnhos = this.BuildPanelEscogerAnho();
            this.panelGrafico.Controls.Add(panelAnhos);

            var pnlBotones = this.BuildPanelBotones();
            this.panelGrafico.Controls.Add(pnlBotones);

            this.panelGrafico.ResumeLayout(true);

            this.Text = "Gráfico de transportes por camion";
            this.Size = new Size(400, panelCamion.Height + pnlBotones.Height + panelAnhos.Height);

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ResumeLayout(false);

        }

        private Panel panelGrafico;

        private ComboBox escogerCamion { get; set; }
        private ComboBox escogerAnho { get; set; }

        public string Anho => escogerAnho.Text;
        public string Matricula => escogerCamion.Text;

        public Button btCierra { get; set; }
        public Button btGraficoGeneralAnual { get; set; }
        public Button btGraficoGeneralTotal { get; set; }
    }



}

