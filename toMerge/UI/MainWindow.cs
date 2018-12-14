namespace ProyectoFlota.UI
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;
    using ProyectoFlota.Core;
    using ProyectoFlota.UI.DialogFlota;

    class MainWindow
    {
        public MainWindow()
        {
            flotas = new ListaFlota();
            try
            {
                flotas = ListaFlota.RecuperaXml();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            this.MainWindowView = new MainWindowView();
            this.MainWindowView.operacionSalir.Click += (sender, e) => this.Salir();
            this.MainWindowView.menuAtras.Click += (sender, e) => this.mostrarTodasLasFlotas();
            this.MainWindowView.Load += (sender, e) => this.mostrarTodasLasFlotas();
            this.dialogoAdd = new DialogoAdd();
            this.dialogoEliminar = new DialogoEliminar();
            this.dialogoModificar = new DialogoModificar();
            this.MainWindowView.añadirFlota.Click += (sender, e) => this.AddFlota();
            this.MainWindowView.eliminarFlota.Click += (sender, e) => this.EliminarFlota();
            this.MainWindowView.modificarFlota.Click += (sender, e) => this.ModificarFlota();
            this.dialogoAdd.btAñadir.Click += (sender, e) => this.dialogoAdd.insertFlota();
            this.dialogoEliminar.btAñadir.Click += (sender, e) => this.dialogoEliminar.deleteFlota();
            this.dialogoModificar.btAñadir.Click += (sende, e) => this.dialogoModificar.modFlota();
        }
        private void AddFlota()
        {
            this.dialogoAdd.ShowDialog();
        }

        private void EliminarFlota()
        {
            this.dialogoEliminar.ShowDialog();    
        }
        private void ModificarFlota()
        {
            this.dialogoModificar.ShowDialog();
        }
                    
        
        public void mostrarTodasLasFlotas()
        {
            ActualizaListaFlota(flotas);
            MainWindowView.panelPrincipal.Controls.Remove(MainWindowView.panelListaFlota);
            MainWindowView.panelPrincipal.Controls.Add(MainWindowView.panelListaFlota);
            this.MainWindowView.Width = MainWindowView.grdListaFlota.Columns.GetColumnsWidth(0) + 20;
            this.MainWindowView.Height = MainWindowView.grdListaFlota.Rows.GetRowsHeight(0) + 84 + MainWindowView.panelOpciones.Height;
        }
        
        private void ActualizaListaFlota(ListaFlota flotas)
        {
            int numFlotas = flotas.Count;

            int i = 0;
            foreach (Flota f in flotas)
            {
                if (MainWindowView.grdListaFlota.Rows.Count <= i)
                {
                    MainWindowView.grdListaFlota.Rows.Add();
                }

                this.ActualizaFilaDeListaFlota(i, f);
                i++;
            }
            int numExtra = MainWindowView.grdListaFlota.Rows.Count - numFlotas;
            for (; numExtra > 0; --numExtra)
            {
                MainWindowView.grdListaFlota.Rows.RemoveAt(numFlotas);
            }
        }

        private void ActualizaFilaDeListaFlota(int rowIndex, Flota f)
        {
            if (rowIndex < 0
              || rowIndex > MainWindowView.grdListaFlota.Rows.Count)
            {
                throw new System.ArgumentOutOfRangeException(
                            "fila fuera de rango: " + nameof(rowIndex));
            }

            DataGridViewRow row = MainWindowView.grdListaFlota.Rows[rowIndex];
            row.Cells[ColNum].Value = (rowIndex + 1).ToString().PadLeft(4, ' ');
            row.Cells[Matricula].Value = f.Matricula;
            row.Cells[Tipo].Value = f.Tipo;
            row.Cells[Marca].Value = f.Marca;
            row.Cells[Modelo].Value = f.Modelo;
            row.Cells[ConsumoKm].Value = f.ConsumoKm;
            row.Cells[FechaAdquisicion].Value = f.FechaAdquisicion;
            row.Cells[FechaFabricacion].Value = f.FechaFabricacion;
            row.Cells[Carga].Value = f.Carga;

            StringBuilder comodidades = new StringBuilder();
            foreach (String aux in f.Comodidades)
            {
                comodidades.Append(aux + " ");
            }
            row.Cells[Comodidades].Value = comodidades.ToString();
        }
        void Salir()
        {
            ListaFlota.GuardaXml();
            Application.Exit();
        }
        public DialogoAdd dialogoAdd { get; set; }
        public DialogoEliminar dialogoEliminar { get; set; }
        public DialogoModificar dialogoModificar { get; set; }
        public MainWindowView MainWindowView { get; private set; }
        public static ListaFlota flotas;
        public const int ColNum = 0;
        public const int Carga = 1;
        public const int Matricula = 2;
        public const int Tipo = 3;
        public const int Marca = 4;
        public const int Modelo = 5;
        public const int ConsumoKm = 6;
        public const int FechaAdquisicion = 7;
        public const int FechaFabricacion = 8;
        public const int Comodidades = 9;
    }
}
