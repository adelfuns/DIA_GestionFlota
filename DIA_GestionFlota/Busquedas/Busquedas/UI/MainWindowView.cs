﻿namespace Busquedas.Core
{
    using System.Windows.Forms;
    using System.Drawing;

    class MainWindowView : Form
    {
        public MainWindowView()
        {
            this.Build();
        }

        private void Build()
        {
            this.BuildMenu();
            this.BuildPanelLista();

            this.SuspendLayout();
            this.panelPrincipal = new Panel()
            {
                Dock = DockStyle.Fill
            };

            this.panelPrincipal.SuspendLayout();
            this.Controls.Add(this.panelPrincipal);
            this.panelPrincipal.Controls.Add(this.BuildPanelLista());
            this.panelPrincipal.ResumeLayout(false);
            this.MinimumSize = new Size(500, this.panelPrincipal.Height);

            this.Text = "Lista de reparaciones";
            this.ResumeLayout(true);
        }

        private void BuildMenu()
        {
            this.menuPrincipal = new MainMenu();

            this.menuArchivo = new MenuItem("&Archivo");
            this.menuEditar = new MenuItem("&Insertar");

            this.operacionSalir = new MenuItem("&Salir") { Shortcut = Shortcut.CtrlQ };

            this.operacionSearch1 = new MenuItem("&Buscar transportes pendientes: ")
            {
                Shortcut = Shortcut.Ctrl0
            };
            this.operacionSearch2 = new MenuItem("&Disponibilidad: ")
            {
                Shortcut = Shortcut.Ctrl1
            };
            this.operacionSearch3 = new MenuItem("&Transportes por cliente: ")
            {
                Shortcut = Shortcut.Ctrl2
            };
            this.operacionSearch4 = new MenuItem("&Reservas por camion: ")
            {
                Shortcut = Shortcut.Ctrl3
            };
            this.operacionSearch5 = new MenuItem("&Reservas por cliente: ")
            {
                Shortcut = Shortcut.Ctrl4
            };
            this.operacionSearch6 = new MenuItem("&Ocupacion: ")
            {
                Shortcut = Shortcut.Ctrl5
            };

            this.menuArchivo.MenuItems.Add(this.operacionSalir);
            this.menuEditar.MenuItems.Add(this.operacionSearch1);
            this.menuEditar.MenuItems.Add(this.operacionSearch2);
            this.menuEditar.MenuItems.Add(this.operacionSearch3);
            this.menuEditar.MenuItems.Add(this.operacionSearch4);
            this.menuEditar.MenuItems.Add(this.operacionSearch5);
            this.menuEditar.MenuItems.Add(this.operacionSearch6);
            this.menuPrincipal.MenuItems.Add(this.menuArchivo);
            this.menuPrincipal.MenuItems.Add(this.menuEditar);
            this.Menu = menuPrincipal;

        }

        private Panel BuildPanelLista()
        {

            var panelLista = new Panel();
            panelLista.SuspendLayout();
            panelLista.Dock = DockStyle.Fill;

            this.lTexto = new Label
            {
                AutoSize = true
            };
            panelLista.Size = new Size(int.MaxValue, int.MaxValue);

            panelLista.Controls.Add(this.lTexto);

            return panelLista;
        }

        private MainMenu menuPrincipal;
        private MenuItem menuArchivo;
        private MenuItem menuEditar;
        private Panel panelPrincipal;

        public MenuItem operacionSalir { get; private set; }
        public MenuItem operacionSearch1 { get; private set; }
        public MenuItem operacionSearch2 { get; private set; }
        public MenuItem operacionSearch3 { get; private set; }
        public MenuItem operacionSearch4 { get; private set; }
        public MenuItem operacionSearch5 { get; private set; }
        public MenuItem operacionSearch6 { get; private set; }

        public Label lTexto { get; private set; }
    }
}
