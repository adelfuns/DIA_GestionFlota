namespace GestionFlota
{
    using GestionFlota;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Linq;
    class DialogoGraficoCliente : Form
    {
        /*
        public DialogoGraficoCliente()
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

        public Panel BuildPanelCliente()
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


            var panelCliente = this.BuildPanelCliente();
            this.panelGrafico.Controls.Add(panelCliente);

            var panelAnhos = this.BuildPanelEscogerAnho();
            this.panelGrafico.Controls.Add(panelAnhos);

            var pnlBotones = this.BuildPanelBotones();
            this.panelGrafico.Controls.Add(pnlBotones);

            this.panelGrafico.ResumeLayout(true);

            this.Text = "Gráfico de transportes por cliente";
            this.Size = new Size(400, panelCliente.Height + pnlBotones.Height + panelAnhos.Height);

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ResumeLayout(false);

        }

        private Panel panelGrafico;

        private ComboBox escogerCliente { get; set; }
        private ComboBox escogerAnho { get; set; }

        public string Anho => escogerAnho.Text;
        public string Cliente => escogerCliente.Text;
        public Button btCierra { get; set; }
        public Button btGraficoGeneralAnual { get; set; }
        public Button btGraficoGeneralTotal { get; set; }

    */
    }



}

