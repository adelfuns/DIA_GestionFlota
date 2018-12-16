
namespace GestionFlotas.UI.DialogSearch
    {
        using DIA_GestionFlota;
        using System.Collections.Generic;
        using System.Drawing;
        using System.Linq;
        using System.Windows.Forms;

        class DialogoReservasCamion : Form
        {
            public DialogoReservasCamion()
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

                var panelMatriculaCamion = this.BuildPanelMatriculaCamion();
                this.panelSearch.Controls.Add(panelMatriculaCamion);

                var panelPeriodo = this.BuildPanelPasadasOPendientes();
                this.panelSearch.Controls.Add(panelPeriodo);

                var panelAnhos = this.BuildPanelEscogerAnho();
                this.panelSearch.Controls.Add(panelAnhos);

                var pnlBotones = this.BuildPanelBotones();
                this.panelSearch.Controls.Add(pnlBotones);

                this.panelSearch.ResumeLayout(true);

                this.Text = "Busqueda de Transportes,pasados o pendientes, para toda la flota o por camion";
                this.Size = new Size(400, panelMatriculaCamion.Height + panelPeriodo.Height + panelAnhos.Height + pnlBotones.Height);

                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.MinimizeBox = true;
                this.CenterToScreen();
                this.MaximizeBox = true;
                this.StartPosition = FormStartPosition.CenterParent;
                this.Dock = DockStyle.Fill;
            this.ResumeLayout(false);

            }

            private Panel panelSearch;

            private ComboBox escogerCamion { get; set; }
            private ComboBox escogerPeriodo { get; set; }
            private ComboBox escogerAnho { get; set; }

            public string Anho => escogerAnho.Text;
            public string Matricula { get => this.escogerCamion.Text.Trim(); set => Matricula = value.ToString(); }
            public string Periodo => escogerPeriodo.Text;


            public Button btCierra { get; set; }
            public Button btSearchCamiones { get; set; }
        }
    }
