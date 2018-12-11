namespace GestionFlota.UI
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    using System.Collections.Generic;
    using GestionFlota.Core;

    class DialogoModificar : Form
    {
        public DialogoModificar()
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
        Panel buildPanelMatricula()
        {
            var panel = new Panel { Dock = DockStyle.Top };
            var lbMatricula = new Label { Text = " Matricula ", Dock = DockStyle.Left };
            this.edMatricula = new TextBox { Dock = DockStyle.Fill, Text = "", TextAlign = HorizontalAlignment.Right };

            panel.Controls.Add(lbMatricula);
            panel.Controls.Add(edMatricula);
            panel.MaximumSize = new Size(int.MaxValue, this.edMatricula.Height);
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
            var edConsumoKm = new TextBox { Dock = DockStyle.Fill, Text = "", TextAlign = HorizontalAlignment.Right };

            panel.Controls.Add(lbConsumoKm);
            panel.Controls.Add(edConsumoKm);
            panel.MaximumSize = new Size(int.MaxValue, edConsumoKm.Height);
            return panel;
        }
        Panel buildPanelFechaAdquisicion()
        {
            var panel = new Panel { Dock = DockStyle.Top };
            var lbFechaAdquisicion = new Label { Text = " F.Adquisición ", Dock = DockStyle.Left };
            var edFechaAdquisicion = new TextBox { Dock = DockStyle.Fill, Text = "", TextAlign = HorizontalAlignment.Right };

            panel.Controls.Add(lbFechaAdquisicion);
            panel.Controls.Add(edFechaAdquisicion);
            panel.MaximumSize = new Size(int.MaxValue, edFechaAdquisicion.Height);
            return panel;
        }
        Panel buildPanelFechaFabricacion()
        {
            var panel = new Panel { Dock = DockStyle.Top };
            var lbFechaFabricacion = new Label { Text = " F.Fabricación ", Dock = DockStyle.Left };
            var edFechaFabricacion = new TextBox { Dock = DockStyle.Fill, Text = "", TextAlign = HorizontalAlignment.Right };

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
        void insertFlota()
        {
            TextBox edMatricula = this.edMatricula;
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


            carga = System.Convert.ToDouble(edCarga.Text);
            matricula = System.Convert.ToString(edMatricula.Text);
            modelo = System.Convert.ToString(edModelo.Text);
            consumo = System.Convert.ToDouble(edConsumoKm.Text);
            marca = System.Convert.ToString(edMarca.Text);
            fad = System.Convert.ToDateTime(edFechaAdquisicion);
            ffab = System.Convert.ToDateTime(edFechaFabricacion);
            if (System.Convert.ToBoolean(ComodidadWifi.CheckState))
            {
                Comodidades.Add("Wifi");
            }
            else if (System.Convert.ToBoolean(ComodidadWifi.CheckState))
            {
                Comodidades.Add("Conexion Bluetooth");
            }
            else if (System.Convert.ToBoolean(ComodidadWifi.CheckState))
            {
                Comodidades.Add("Aire Acondicionado");
            }
            else if (System.Convert.ToBoolean(ComodidadWifi.CheckState))
            {
                Comodidades.Add("Litera");
            }
            else if (System.Convert.ToBoolean(ComodidadWifi.CheckState))
            {
                Comodidades.Add("Tv");
            }

            Flota flota = new Flota(carga, matricula, tipo, marca, modelo, consumo, fad, ffab, Comodidades);
            if (flota.ComprobarCarga())
            {
                listaFlota.Add(flota);
                listaFlota.GuardaXml();
                MessageBox.Show("Vehículo introducido correctamente", "", MessageBoxButtons.OK);
            }
            else MessageBox.Show("Superado Límite de Carga para el vehículo", "", MessageBoxButtons.OK);

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

            var panelMatricula = this.buildPanelMatricula();
            this.panelAñadir.Controls.Add(panelTipoCamion);

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
            this.Size = new Size(500, panelTipoCamion.Height * 7 + pnlBotones.Height);

            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MinimizeBox = true;
            this.CenterToScreen();
            this.MaximizeBox = true;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Dock = DockStyle.Fill;
            this.ResumeLayout(false);

        }

        private Panel panelAñadir;
        ListaFlota listaFlota = ListaFlota.RecuperaXml();
        private ComboBox escogerTipo { get; set; }
        public string Tipo => escogerTipo.Text;
        public Button btCierra { get; set; }
        public Button btAñadir { get; set; }
        public TextBox edMatricula { get; set; }
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