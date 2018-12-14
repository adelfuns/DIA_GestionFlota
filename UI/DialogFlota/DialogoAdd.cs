namespace ProyectoFlota.UI.DialogFlota
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Linq;
    using System.Collections.Generic;
    using ProyectoFlota.Core;
    using System.Text.RegularExpressions;

    class DialogoAdd : Form
    {
        public DialogoAdd()
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

            this.btAñadir = new Button()
            {
                DialogResult = DialogResult.OK,
                Text = "&Añadir"
            };

            this.AcceptButton = this.btAñadir;
            this.CancelButton = this.btCierra;

            toret.Controls.Add(this.btAñadir);
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
            escogerTipo.DropDownStyle = ComboBoxStyle.DropDownList;


            escogerTipo.Items.AddRange(new object[] {"Selecciona",
                "Furgoneta",
                "Camion",
                "Camion articulado"});

            escogerTipo.SelectedItem = "Selecciona";
            escogerTipo.Text = "Selecciona";
            toret.Controls.Add(this.escogerTipo);

            toret.MaximumSize = new Size(int.MaxValue, escogerTipo.Height * 2);
            return toret;

        }
        Panel buildPanelCarga()
        {
            var panel = new Panel { Dock = DockStyle.Top };
            var lbCarga = new Label { Text = " Carga ", Dock = DockStyle.Left };
            this.edCarga = new TextBox { Dock = DockStyle.Fill, Text = "", TextAlign = HorizontalAlignment.Right };

            panel.Controls.Add(lbCarga);
            panel.Controls.Add(edCarga);
            panel.MaximumSize = new Size(int.MaxValue, this.edCarga.Height);
            return panel;
        }
        Panel buildPanelLetrasMatricula()
        {
            var panel = new Panel { Dock = DockStyle.Top };
            var lbLetrasMatricula = new Label { Text = " Letras Matricula ", Dock = DockStyle.Left };
            this.edLetrasMatricula = new TextBox { Dock = DockStyle.Fill, Text = "", TextAlign = HorizontalAlignment.Right };

            panel.Controls.Add(lbLetrasMatricula);
            panel.Controls.Add(edLetrasMatricula);
            panel.MaximumSize = new Size(int.MaxValue, this.edLetrasMatricula.Height);
            return panel;
        }
        Panel buildPanelDigitosMatricula()
        {
            var panel = new Panel { Dock = DockStyle.Top };
            var lbDigitosMatricula = new Label { Text = " Digitos Matricula ", Dock = DockStyle.Left };
            this.edDigitosMatricula = new TextBox { Dock = DockStyle.Fill, Text = "", TextAlign = HorizontalAlignment.Right };

            panel.Controls.Add(lbDigitosMatricula);
            panel.Controls.Add(edDigitosMatricula);
            panel.MaximumSize = new Size(int.MaxValue, this.edDigitosMatricula.Height);
            return panel;
        }
        Panel buildPanelMarca()
        {
            var panel = new Panel { Dock = DockStyle.Top };
            var lbMarca = new Label { Text = " Marca ", Dock = DockStyle.Left };
            this.edMarca = new TextBox { Dock = DockStyle.Fill, Text = "", TextAlign = HorizontalAlignment.Right };

            panel.Controls.Add(lbMarca);
            panel.Controls.Add(edMarca);
            panel.MaximumSize = new Size(int.MaxValue, this.edMarca.Height);
            return panel;
        }
        Panel buildPanelModelo()
        {
            var panel = new Panel { Dock = DockStyle.Top };
            var lbModelo = new Label { Text = " Modelo ", Dock = DockStyle.Left };
            this.edModelo = new TextBox { Dock = DockStyle.Fill, Text = "", TextAlign = HorizontalAlignment.Right };

            panel.Controls.Add(lbModelo);
            panel.Controls.Add(edModelo);
            panel.MaximumSize = new Size(int.MaxValue, this.edModelo.Height);
            return panel;
        }
        Panel buildPanelConsumoKm()
        {
            var panel = new Panel { Dock = DockStyle.Top };
            var lbConsumoKm = new Label { Text = " Consumo Km ", Dock = DockStyle.Left };
            this.edConsumoKm = new TextBox { Dock = DockStyle.Fill, Text = "", TextAlign = HorizontalAlignment.Right };

            panel.Controls.Add(lbConsumoKm);
            panel.Controls.Add(edConsumoKm);
            panel.MaximumSize = new Size(int.MaxValue, edConsumoKm.Height);
            return panel;
        }
        Panel buildPanelFechaAdquisicion()
        {
            var panel = new Panel { Dock = DockStyle.Top };
            var lbFechaAdquisicion = new Label { Text = " F.Adquisición ", Dock = DockStyle.Left };
            this.edFechaAdquisicion = new TextBox { Dock = DockStyle.Fill, Text = "", TextAlign = HorizontalAlignment.Right };

            panel.Controls.Add(lbFechaAdquisicion);
            panel.Controls.Add(edFechaAdquisicion);
            panel.MaximumSize = new Size(int.MaxValue, edFechaAdquisicion.Height);
            return panel;
        }
        Panel buildPanelFechaFabricacion()
        {
            var panel = new Panel { Dock = DockStyle.Top };
            var lbFechaFabricacion = new Label { Text = " F.Fabricación ", Dock = DockStyle.Left };
            this.edFechaFabricacion = new TextBox { Dock = DockStyle.Fill, Text = "", TextAlign = HorizontalAlignment.Right };

            panel.Controls.Add(lbFechaFabricacion);
            panel.Controls.Add(edFechaFabricacion);
            panel.MaximumSize = new Size(int.MaxValue, edFechaFabricacion.Height);
            return panel;
        }
        Panel buildPanelComodidades()
        {
            var panel = new Panel { Dock = DockStyle.Top };
            var lbComodidades = new Label { Text = " Comodidades ", Dock = DockStyle.Left };
            this.ComodidadWifi = new CheckBox { Text = "Wifi", Dock = DockStyle.Left, AutoCheck = true };
            this.ComodidadBlue = new CheckBox { Text = "Conexion Bluetooth", Dock = DockStyle.Left, AutoCheck = true };
            this.ComodidadAire = new CheckBox { Text = "Aire Acondicionado", Dock = DockStyle.Left, AutoCheck = true };
            this.ComodidadLitera = new CheckBox { Text = "Litera", Dock = DockStyle.Left, AutoCheck = true };
            this.ComodidadTv = new CheckBox { Text = "Tv", Dock = DockStyle.Left, AutoCheck = true };

            panel.Controls.Add(lbComodidades);
            panel.Controls.Add(ComodidadWifi);
            panel.Controls.Add(ComodidadAire);
            panel.Controls.Add(ComodidadLitera);
            panel.Controls.Add(ComodidadBlue);
            panel.Controls.Add(ComodidadTv);
            panel.MaximumSize = new Size(int.MaxValue, ComodidadWifi.Height);
            return panel;
        }
        public void insertFlota()
        {
            TextBox edLetrasMatricula = this.edLetrasMatricula;
            TextBox edDigitosMatricula = this.edDigitosMatricula;
            TextBox edCarga = this.edCarga;
            TextBox edMarca = this.edMarca;
            TextBox edModelo = this.edModelo;
            TextBox edConsumoKm = this.edConsumoKm;
            TextBox edFechaAdquisicion = this.edFechaAdquisicion;
            TextBox edFechaFabricacion = this.edFechaFabricacion;
            CheckBox ComodidadWifi = this.ComodidadWifi;
            CheckBox ComodidadBlue = this.ComodidadBlue;
            CheckBox ComodidadAire = this.ComodidadAire;
            CheckBox ComodidadLitera = this.ComodidadLitera;
            CheckBox ComodidadTv = this.ComodidadTv;
            String tipo = this.Tipo;

            double carga;
            string matricula;
            string marca;
            string modelo;
            double consumo;
            DateTime fad;
            DateTime ffab;
            List<String> Comodidades = new List<string>();
            if (tipo != "Selecciona")
            {


                if (edLetrasMatricula.Text.Length == 3 && edDigitosMatricula.Text.Length == 4
                    && Regex.IsMatch(edLetrasMatricula.Text, @"^[a-zA-Z]+$")
                    && Regex.IsMatch(edDigitosMatricula.Text, @"^[0-9]+$"))
                {
                    Double.TryParse(edCarga.Text, out carga);
                    Console.WriteLine(carga);
                    matricula = String.Concat(edLetrasMatricula.Text, edDigitosMatricula.Text);
                    modelo = edModelo.Text;
                    Double.TryParse(edConsumoKm.Text, out consumo);
                    marca = edMarca.Text;
                    if (DateTime.TryParse(edFechaAdquisicion.Text, out fad) && DateTime.TryParse(edFechaFabricacion.Text, out ffab))
                    {
                        var matriculas = new List<Flota>(from mat in MainWindow.flotas
                                                         where mat.Matricula.Equals(matricula)
                                                         select mat);
                        if (ComodidadWifi.Checked)
                        {
                            Comodidades.Add("Wifi");
                        }
                        if (ComodidadBlue.Checked)
                        {
                            Comodidades.Add("Conexion Bluetooth");
                        }
                        if (ComodidadAire.Checked)
                        {
                            Comodidades.Add("Aire Acondicionado");
                        }
                        if (ComodidadLitera.Checked)
                        {
                            Comodidades.Add("Litera");
                        }
                        if (ComodidadTv.Checked)
                        {
                            Comodidades.Add("Tv");
                        }
                        if (matriculas.Count == 0)
                        {
                            Flota flota = new Flota(carga, matricula, tipo, marca, modelo, consumo, fad, ffab, Comodidades);
                            if (flota.ComprobarCarga())
                            {
                                MainWindow.flotas.Add(flota);
                                MessageBox.Show("Vehículo introducido correctamente", "", MessageBoxButtons.OK);
                            }
                            else MessageBox.Show("Superado Límite de Carga para el vehículo", "", MessageBoxButtons.OK);
                        }
                        else MessageBox.Show("La matrícula ya está almacenada en el sistema");
                    }
                    else MessageBox.Show("La matrícula no es correcta");
                }
                else MessageBox.Show("Las fechas no son correctas");
            }
            else MessageBox.Show("Introduzca un tipo de vehículo");
        }


        private void Build()
        {
            this.SuspendLayout();

            this.panelAñadir = new TableLayoutPanel { Dock = DockStyle.Fill };
            this.panelAñadir.SuspendLayout();
            this.Controls.Add(this.panelAñadir);

            var panelTipoCamion = this.BuildPanelTipoCamion();
            this.panelAñadir.Controls.Add(panelTipoCamion);

            var panelCarga = this.buildPanelCarga();
            this.panelAñadir.Controls.Add(panelCarga);

            var panelLetrasMatricula = this.buildPanelLetrasMatricula();
            this.panelAñadir.Controls.Add(panelLetrasMatricula);

            var panelDigitosMatricula = this.buildPanelDigitosMatricula();
            this.panelAñadir.Controls.Add(panelDigitosMatricula);

            var panelMarca = this.buildPanelMarca();
            this.panelAñadir.Controls.Add(panelMarca);

            var panelModelo = this.buildPanelModelo();
            this.panelAñadir.Controls.Add(panelModelo);

            var panelConsumoKm = this.buildPanelConsumoKm();
            this.panelAñadir.Controls.Add(panelConsumoKm);

            var panelFechaFabricacion = this.buildPanelFechaFabricacion();
            this.panelAñadir.Controls.Add(panelFechaFabricacion);

            var panelFechaAdquisicion = this.buildPanelFechaAdquisicion();
            this.panelAñadir.Controls.Add(panelFechaAdquisicion);

            var panelComodidades = this.buildPanelComodidades();
            this.panelAñadir.Controls.Add(panelComodidades);

            var pnlBotones = this.BuildPanelBotones();
            this.panelAñadir.Controls.Add(pnlBotones);

            this.panelAñadir.ResumeLayout(true);

            this.Text = "Añadir vehículo a la flota";
            this.Size = new Size(500, panelTipoCamion.Height * 9 + pnlBotones.Height);

            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MinimizeBox = true;
            this.CenterToScreen();
            this.MaximizeBox = true;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Dock = DockStyle.Fill;
            this.ResumeLayout(false);

        }

        private Panel panelAñadir;
        private ComboBox escogerTipo { get; set; }
        public string Tipo => escogerTipo.Text;
        public Button btCierra { get; set; }
        public Button btAñadir { get; set; }
        public TextBox edLetrasMatricula { get; set; }
        public TextBox edDigitosMatricula { get; set; }
        public TextBox edCarga { get; set; }
        public TextBox edMarca { get; set; }
        public TextBox edModelo { get; set; }
        public TextBox edConsumoKm { get; set; }
        public TextBox edFechaAdquisicion { get; set; }
        public TextBox edFechaFabricacion { get; set; }
        public CheckBox ComodidadWifi { get; set; }
        public CheckBox ComodidadBlue { get; set; }
        public CheckBox ComodidadAire { get; set; }
        public CheckBox ComodidadLitera { get; set; }
        public CheckBox ComodidadTv { get; set; }

    }
}

