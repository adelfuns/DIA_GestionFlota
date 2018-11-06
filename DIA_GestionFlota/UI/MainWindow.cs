namespace DIA_GestionFlota
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Linq;
    
    using System.Collections.Generic;

    class MainWindow : Form
    {
        public MainWindow()
        {
            this.MainWindowView = new MainWindowView();


            Flota flota1 = new Flota(1.5, "AAA9999", "Furgoneta", "opel", "modelo", "20", "12/12/1912", "12/12/1913",new string[] { "wifi", "musica" });
            Flota flota2 = new Flota(2, "AAA6666", "Camion", "opel2", "modelo", "23", "12/12/1912", "12/12/1913", new string[] { "wifi", "musica" });
            List<Flota> flotas = new List<Flota>();
            flotas.Add(flota1);
            flotas.Add(flota2);

            Cliente cliente1 = new Cliente("6666666F", "Nombre", "telefono", "asdsa@asda", "323213");
            Cliente cliente2 = new Cliente("6667776F", "Nombre2", "telefono2", "asdsa2@asda", "323213");
            List<Cliente> clientes = new List<Cliente>();
            clientes.Add(cliente1);
            clientes.Add(cliente2);
            Transportes transportes1 = new Transportes("6666AAA12121112", flota1, cliente1, "12/11/1212", "12", "15/13/1212", "22/11/1212", "20", "50", 10);
            List<Transportes> transportes = new List<Transportes>();
            transportes.Add(transportes1);



            //this.transportes = new Transportes();
            this.MainWindowView.operacionSalir.Click += (sender, e) => this.Salir();

            //Operaciones búsqueda
            this.MainWindowView.operacionSearch1.Click += (sender, e) => this.transportePendientes();
            this.MainWindowView.operacionSearch2.Click += (sender, e) => this.disponibilidad();
            this.MainWindowView.operacionSearch3.Click += (sender, e) => this.reservasPorCLiente();
            this.MainWindowView.operacionSearch4.Click += (sender, e) => this.reservasPorCamion();
            this.MainWindowView.operacionSearch5.Click += (sender, e) => this.transportesPorCliente();
            this.MainWindowView.operacionSearch6.Click += (sender, e) => this.ocupacion();

            //Operaciones graficos
			this.MainWindowView.operacionActividadGeneral.Click += (sender, e) => this.ActividadCamion();
			this.MainWindowView.operacionActividadCliente.Click += (sender, e) => this.ActividadCliente();
			this.MainWindowView.operacionActividadCamion.Click += (sender, e) => this.ActividadCamion();
			this.MainWindowView.operacionActividadComodidades.Click += (sender, e) => this.ActividadComodidades();


            this.dtp = new DialogoTransportePendiente();

            this.dtp.btSearchDTP.Click += (sender, e) => this.DTPSearch();

            this.dtp.Shown += (sender, e) => { dtp.Reset(); /*dtp.Validar();*/ };
          //  this.dtp.edIdTransporte.LostFocus += (sender, e) => { dtp.ValidarPerdidaFoco(); };
         //   this.dtp.edIdTransporte.GotFocus += (sender, e) => { dtp.ValidarPerdidaFoco(); };
          //  this.dtp.edIdTransporte.TextChanged += (sender, e) => { dtp.ValidarPerdidaFoco(); };

        }

        //Métodos búsqueda
        private void ocupacion()
        {
           
        }

        private void transportesPorCliente()
        {
      
        }

        private void reservasPorCamion()
        {

        }

        private void reservasPorCLiente()
        {
        
        }

        private void disponibilidad()
        {
   
        }

        private void transportePendientes()
        {
            this.dtp.ShowDialog();
        }

        private void DTPSearch()
        {
            String muestra = "";

            if(this.dtp.idTransporte == "")
            {

            }
            else
            {

            }

            this.MainWindowView.lTexto.Text = muestra;
        }

        //Métodos de gráficos

        private void ActividadGeneral()
		{
			
		}

		private void ActividadCliente()
        {

        }

		private void ActividadCamion()
        {

        }

		private void ActividadComodidades()
        {

        }

        //Operacion salir
        void Salir()
        {
          Application.Exit();
        }

        public MainWindowView MainWindowView { get; private set; }
        private DialogoTransportePendiente dtp;

        //public Flota flota;
        //public Transporte transportes;
    }

   
}
