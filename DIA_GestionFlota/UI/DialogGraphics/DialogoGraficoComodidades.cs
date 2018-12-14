namespace GestionFlota
{
    using GestionFlota;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Linq;
    class DialogoGraficoComodidades : Form
    {

        /*
        public DialogoGraficoComodidades()
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
            foreach (Flota t in MainWindow.flotas)
            {
                if (!anhos.Contains(t.FechaAdquisicion.Year))
                {
                    anhos.Add(t.FechaAdquisicion.Year);
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

        public Panel BuildPanelEscogerComodiadades()
        {
            var toret = new FlowLayoutPanel { Dock = DockStyle.Top, };
            Text = "ComboBox";
            Size = new Size(240, 240);

            escogerComodidades = new ComboBox();
            escogerComodidades.Parent = this;
            escogerComodidades.DropDownStyle = ComboBoxStyle.DropDownList;
            List<object> comodidades = new List<object>();
            foreach (Flota t in MainWindow.flotas)
            {
                for(int i = 0; i < t.Comodidades.Length; i++)
                {
                    if (!comodidades.Contains(t.Comodidades[i]))
                    {
                        comodidades.Add(t.Comodidades[i]);
                    }
                }
            }

            escogerComodidades.Items.AddRange(comodidades.ToArray());

            escogerComodidades.SelectedItem = comodidades.First();
            escogerComodidades.Text = comodidades.First().ToString();

            toret.Controls.Add(this.escogerComodidades);

            toret.MaximumSize = new Size(int.MaxValue, escogerComodidades.Height * 2);
            return toret;
        }

        private void Build()
        {
            this.SuspendLayout();

            this.panelGrafico = new TableLayoutPanel { Dock = DockStyle.Fill };
            this.panelGrafico.SuspendLayout();
            this.Controls.Add(this.panelGrafico);


            var panelComodidades = this.BuildPanelEscogerComodiadades();
            this.panelGrafico.Controls.Add(panelComodidades);

            var panelAnhos = this.BuildPanelEscogerAnho();
            this.panelGrafico.Controls.Add(panelAnhos);

            var pnlBotones = this.BuildPanelBotones();
            this.panelGrafico.Controls.Add(pnlBotones);

            this.panelGrafico.ResumeLayout(true);

            this.Text = "Gráfico de transportes por camion";
            this.Size = new Size(400, panelComodidades.Height + pnlBotones.Height + panelAnhos.Height);

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ResumeLayout(false);

        }

        private Panel panelGrafico;

        private ComboBox escogerComodidades { get; set; }
        private ComboBox escogerAnho { get; set; }

        public string Anho => escogerAnho.Text;
        public string Comodidad => escogerComodidades.Text;

        public Button btCierra { get; set; }
        public Button btGraficoGeneralAnual { get; set; }
        public Button btGraficoGeneralTotal { get; set; }

    */
    }



}

