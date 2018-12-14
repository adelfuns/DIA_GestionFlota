namespace ProyectoFlota.UI.DialogFlota
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Linq;
    using System.Collections.Generic;
    using ProyectoFlota.Core;
    using System.Text.RegularExpressions;
    class DialogoEliminar : Form
    {
        public DialogoEliminar()
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

            this.btAñadir = new Button()
            {
                DialogResult = DialogResult.OK,
                Text = "&Borrar"
            };

            this.AcceptButton = this.btAñadir;
            this.CancelButton = this.btCierra;

            toret.Controls.Add(this.btAñadir);
            toret.Controls.Add(this.btCierra);
            toret.Dock = DockStyle.Top;

            return toret;
        }
        Panel buildPanelMatricula()
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
        
        public void deleteFlota()
        {
           var matriculas = new List<Flota>(from mat in MainWindow.flotas
                                            where mat.Matricula.Equals(Matricula)
                                            select mat);

                if (matriculas.Count == 1)
                {
                    MainWindow.flotas.Remove(matriculas.ElementAt(0));
                    MessageBox.Show("Vehículo eliminado correctamente", "", MessageBoxButtons.OK);
                }else MessageBox.Show("No se encuentra vehículo con esa matrícula", "", MessageBoxButtons.OK);

           
        }
            

        private void Build()
        {
            this.SuspendLayout();

            this.panelAñadir = new TableLayoutPanel { Dock = DockStyle.Fill };
            this.panelAñadir.SuspendLayout();
            this.Controls.Add(this.panelAñadir);

            var panelMatricula = this.buildPanelMatricula();
            this.panelAñadir.Controls.Add(panelMatricula);


            var pnlBotones = this.BuildPanelBotones();
            this.panelAñadir.Controls.Add(pnlBotones);

            this.panelAñadir.ResumeLayout(true);

            this.Text = "Añadir vehículo a la flota";
            this.Size = new Size(500, panelMatricula.Height + pnlBotones.Height);

            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MinimizeBox = true;
            this.CenterToScreen();
            this.MaximizeBox = true;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Dock = DockStyle.Fill;
            this.ResumeLayout(false);

        }

        private Panel panelAñadir;
        public Button btCierra { get; set; }
        public Button btAñadir { get; set; }
        public TextBox edLetrasMatricula { get; set; }
        public TextBox edDigitosMatricula { get; set; }
        private ComboBox escogerCamion;
        public string Matricula => escogerCamion.Text;


    }
}
