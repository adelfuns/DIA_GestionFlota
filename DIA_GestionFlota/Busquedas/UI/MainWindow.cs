namespace Busquedas.Core
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Linq;

    class MainWindow : Form
    {
        public MainWindow()
        {
            this.MainWindowView = new MainWindowView();


            //this.flota = new Flota();
            //this.transportes = new Transportes();
            this.MainWindowView.operacionSalir.Click += (sender, e) => this.Salir();
            this.MainWindowView.operacionSearch1.Click += (sender, e) => this.transportePendientes();
            this.MainWindowView.operacionSearch2.Click += (sender, e) => this.disponibilidad();
            this.MainWindowView.operacionSearch3.Click += (sender, e) => this.reservasPorCLiente();
            this.MainWindowView.operacionSearch4.Click += (sender, e) => this.reservasPorCamion();
            this.MainWindowView.operacionSearch5.Click += (sender, e) => this.transportesPorCliente();
            this.MainWindowView.operacionSearch6.Click += (sender, e) => this.ocupacion();

            this.dtp = new DialogoTransportePendiente();

            this.dtp.btSearchDTP.Click += (sender, e) => this.DTPSearch();

            this.dtp.Shown += (sender, e) => { dtp.Reset(); /*dtp.Validar();*/ };
          //  this.dtp.edIdTransporte.LostFocus += (sender, e) => { dtp.ValidarPerdidaFoco(); };
         //   this.dtp.edIdTransporte.GotFocus += (sender, e) => { dtp.ValidarPerdidaFoco(); };
          //  this.dtp.edIdTransporte.TextChanged += (sender, e) => { dtp.ValidarPerdidaFoco(); };

        }

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
