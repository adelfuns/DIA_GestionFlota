namespace DIA_GestionFlota
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
            this.SuspendLayout();
            this.AutoSize = true;
            this.AutoScroll = true;
            this.MinimumSize = new Size(300, 300);
            this.panelPrincipal = new Panel()
            {
                Dock = DockStyle.Fill,
                AutoSize = true,
                AutoScroll = true,
                BackColor = Color.Blue
            };

            this.panelPrincipal.MinimumSize = new Size(this.Width, this.Height);
            this.panelPrincipal.ClientSize = this.ClientSize;
            this.panelPrincipal.SuspendLayout();

            this.Controls.Add(this.panelPrincipal);
            this.BuildPanelLista();
            this.panelPrincipal.Controls.Add(this.panelLista);
            this.panelPrincipal.ResumeLayout(false);


            this.CenterToScreen();
            this.MaximizeBox = true;

            this.Dock = DockStyle.Fill;
            this.Text = "Lista de reparaciones";
            this.ResumeLayout(true);

            

        }
        private void BuildMenu()
        {
            this.menuPrincipal = new MainMenu();

            this.menuArchivo = new MenuItem("&Archivo");
            this.menuEditar = new MenuItem("&Buscar");
			this.menuGenerar = new MenuItem("&Generar");

            this.operacionSalir = new MenuItem("&Salir") { Shortcut = Shortcut.CtrlQ };

            //Operaciones búsqueda
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

			//Operaciones generar gráfico
			this.operacionActividadGeneral = new MenuItem("&Generar gráfico actvidad general: ")
            {
                Shortcut = Shortcut.Ctrl6
            };
			this.operacionActividadCliente = new MenuItem("&Generar gráfico actvidad cliente: ")
            {
                Shortcut = Shortcut.Ctrl7
            };
			this.operacionActividadCamion = new MenuItem("&Generar gráfico actvidad camión: ")
            {
                Shortcut = Shortcut.Ctrl8
            };
			this.operacionActividadComodidades = new MenuItem("&Generar gráfico comodidades: ")
            {
                Shortcut = Shortcut.Ctrl9
            };


			//Menú superior
			this.menuArchivo.MenuItems.Add(this.operacionSalir);
            this.menuPrincipal.MenuItems.Add(this.menuArchivo);
            this.menuPrincipal.MenuItems.Add(this.menuEditar);
			this.menuPrincipal.MenuItems.Add(this.menuGenerar);
            this.Menu = menuPrincipal;
            //Submenú búsqueda
            this.menuEditar.MenuItems.Add(this.operacionSearch1);
            this.menuEditar.MenuItems.Add(this.operacionSearch2);
            this.menuEditar.MenuItems.Add(this.operacionSearch3);
            this.menuEditar.MenuItems.Add(this.operacionSearch4);
            this.menuEditar.MenuItems.Add(this.operacionSearch5);
            this.menuEditar.MenuItems.Add(this.operacionSearch6);
			//Submenú gráficos
			this.menuGenerar.MenuItems.Add(this.operacionActividadGeneral);
			this.menuGenerar.MenuItems.Add(this.operacionActividadCliente);
			this.menuGenerar.MenuItems.Add(this.operacionActividadCamion);
			this.menuGenerar.MenuItems.Add(this.operacionActividadComodidades);
            

        }


        
      
        private void BuildPanelLista()
        {
            
            this.panelLista = new Panel();
            panelLista.SuspendLayout();
            panelLista.Dock = DockStyle.Fill;
            panelLista.AutoScroll = true;
           
            this.lTexto = new TextBox
            {
                AutoSize = true,
                Dock = DockStyle.Fill,
                ReadOnly = true,
                Multiline = true,
                ScrollBars = ScrollBars.Both,
                WordWrap = false,
                ClientSize  = new Size(this.panelPrincipal.Width, this.panelPrincipal.Height)
            };
            this.ClientSizeChanged += (sender, e) => { this.lTexto.ClientSize = this.ClientSize; this.lTexto.ClientSize = this.ClientSize; };
            panelLista.ClientSize = this.panelPrincipal.ClientSize;
            panelLista.Controls.Add(this.lTexto);
      

        }
        //Items del menú
        private MainMenu menuPrincipal;
        private MenuItem menuArchivo;
        private MenuItem menuEditar;
		private MenuItem menuGenerar;
        public Panel panelPrincipal { get; set; }

        public MenuItem operacionSalir { get; private set; }

        //Operaciones búsqueda
        public MenuItem operacionSearch1 { get; private set; }
        public MenuItem operacionSearch2 { get; private set; }
        public MenuItem operacionSearch3 { get; private set; }
        public MenuItem operacionSearch4 { get; private set; }
        public MenuItem operacionSearch5 { get; private set; }
        public MenuItem operacionSearch6 { get; private set; }
        //Operaciones generar gráficos
		public MenuItem operacionActividadGeneral { get; private set; }
		public MenuItem operacionActividadCliente { get; private set; }
		public MenuItem operacionActividadCamion { get; private set; }
		public MenuItem operacionActividadComodidades { get; private set; }


        public TextBox lTexto { get; private set; }
        public Panel panelLista;
    }
}
