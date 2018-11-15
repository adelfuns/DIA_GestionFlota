namespace DIA_GestionFlota
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    class DialogoOcupacion : Form
    {
        public DialogoOcupacion()
        {

            this.Build();
        }


        private Panel BuildPanelFecha()
        {
            var toret = new Panel { Dock = DockStyle.Top };
            Text = "Month Calendar";
            Size = new Size(240, 240);
            calendar = new MonthCalendar();
            calendar.Parent = this;
            calendar.Location = new Point(10, 10);
            calendar.DateSelected += new DateRangeEventHandler(OnSelected);

            date = new Label();
            date.Parent = this;
            date.Location = new Point(40, 170);
            Fecha = calendar.SelectionStart;
            date.Text = Fecha.Month + "/" + Fecha.Day + "/" + Fecha.Year;


            toret.Controls.Add(this.calendar);
            toret.Controls.Add(this.date);

         
            toret.MinimumSize = new Size(int.MaxValue, calendar.Height + date.Height + 50 );
            return toret;
        }

        void OnSelected(object sender, EventArgs e)
        {
            Fecha = calendar.SelectionStart;
            date.Text = Fecha.Month + "/" + Fecha.Day + "/" + Fecha.Year;
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
                ColumnCount = 3,
                RowCount = 1
            };

            this.btCierra = new Button()
            {
                DialogResult = DialogResult.Cancel,
                Text = "&Cancelar",
                Size = new Size(100,20)
               
            };

            this.btSearchOcupacionFecha= new Button()
            {
                DialogResult = DialogResult.OK,
                Text = "&Buscar por fechas",
                Size = new Size(100, 20)
            };
            this.btSearchOcupacionAnho = new Button()
            {
                DialogResult = DialogResult.OK,
                Text = "&Buscar por anhos",
                Size = new Size(100, 20)
            };

            this.AcceptButton = this.btSearchOcupacionFecha;
            this.AcceptButton = this.btSearchOcupacionAnho;
            this.CancelButton = this.btCierra;

            toret.Controls.Add(this.btSearchOcupacionFecha);
            toret.Controls.Add(this.btSearchOcupacionAnho);
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


            var panelIdFecha = this.BuildPanelFecha();
            this.panelSearch.Controls.Add(panelIdFecha);

            var panelAnhos = this.BuildPanelEscogerAnho();
            this.panelSearch.Controls.Add(panelAnhos);

            var pnlBotones = this.BuildPanelBotones();
            this.panelSearch.Controls.Add(pnlBotones);

            this.panelSearch.ResumeLayout(true);

            this.Text = "muestra los camiones con transportes realizados, para una determinada fecha o para un año completo";
            this.Size = new Size(400, panelIdFecha.Height + panelAnhos.Height + pnlBotones.Height );

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ResumeLayout(false);

        }

        private Panel panelSearch;

        private MonthCalendar calendar { get; set; }
        public Label date { get; set; }
        private ComboBox escogerAnho { get; set; }

        public string Anho => escogerAnho.Text;
        public DateTime Fecha { get; set; }
        public Button btCierra { get; set; }
        public Button btSearchOcupacionFecha { get; set; }
        public Button btSearchOcupacionAnho { get; set; }
    }
}
