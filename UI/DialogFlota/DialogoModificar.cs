namespace ProyectoFlota.UI.DialogFlota
{
    
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Linq;
    using System.Collections.Generic;
    using ProyectoFlota.Core;
    using System.Text.RegularExpressions;
    class DialogoModificar : Form
    {
        public DialogoModificar()
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
                Text = "&Modificar"
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
        public void modFlota()
        {
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
            double consumo;
            DateTime fad;
            DateTime ffab;
            List<String> Comodidades = new List<string>();

            var matriculas = new List<Flota>(from mat in MainWindow.flotas
                                             where mat.Matricula.Equals(Matricula)
                                             select mat);

            if (matriculas.Count == 1)
            {

                flota_mod = matriculas.ElementAt(0);
                MainWindow.flotas.Remove(matriculas.ElementAt(0));
                if (edCarga.Text != "")
                {
                    if (Double.TryParse(edCarga.Text, out carga))
                    {
                        var tmp = flota_mod.Carga;
                        flota_mod.Carga = carga;
                        if (!flota_mod.ComprobarCarga())
                        {
                            flota_mod.Carga = tmp;
                        }

                    }
                                                         
                }
                if (edMarca.Text != "")
                {
                    flota_mod.Marca = edMarca.Text;
                }
                if (edModelo.Text != "")
                {
                    flota_mod.Modelo = edModelo.Text;
                }
                if (edConsumoKm.Text != "")
                {
                    if (Double.TryParse(edConsumoKm.Text, out consumo))
                    {
                        flota_mod.ConsumoKm = consumo;
                    }
                }
                if (edFechaAdquisicion.Text != "" && (DateTime.TryParse(edFechaAdquisicion.Text, out fad)))
                {
                    flota_mod.FechaAdquisicion = fad;
                }
                if (edFechaFabricacion.Text != "" && (DateTime.TryParse(edFechaAdquisicion.Text, out ffab)))
                {
                    flota_mod.FechaAdquisicion = ffab;
                }
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
                flota_mod.Comodidades = Comodidades;
                MainWindow.flotas.Remove(matriculas.ElementAt(0));
                MainWindow.flotas.Add(flota_mod);
                MessageBox.Show("Modificación realizada con éxito", "", MessageBoxButtons.OK);
            }
            
        }            


        private void Build()
        {
            this.SuspendLayout();

            this.panelAñadir = new TableLayoutPanel { Dock = DockStyle.Fill };
            this.panelAñadir.SuspendLayout();
            this.Controls.Add(this.panelAñadir);

            var panelMatricula = this.buildPanelMatricula();
            this.panelAñadir.Controls.Add(panelMatricula);
                  
              
            var panelTipoCamion = this.BuildPanelTipoCamion();
            this.panelAñadir.Controls.Add(panelTipoCamion);

            var panelCarga = this.buildPanelCarga();
            this.panelAñadir.Controls.Add(panelCarga);

           
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
            this.Size = new Size(500, panelMatricula.Height * 8 + pnlBotones.Height);

            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MinimizeBox = true;
            this.CenterToScreen();
            this.MaximizeBox = true;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Dock = DockStyle.Fill;
            this.ResumeLayout(false);

        }

        private Panel panelAñadir;
        private ComboBox escogerCamion;
        public string Matricula => escogerCamion.Text;
        private ComboBox escogerTipo { get; set; }
        public string Tipo => escogerTipo.Text;
        public Flota flota_mod { get; set; }
        public Button btCierra { get; set; }
        public Button btAñadir { get; set; }
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
