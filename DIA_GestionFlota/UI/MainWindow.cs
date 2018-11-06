namespace DIA_GestionFlota
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;

    class MainWindow : Form
    {
		public MainWindow()
		{
			this.MainWindowView = new MainWindowView();


			Flota flota1 = new Flota(1.5, "AAA9999", "Furgoneta", "opel", "modelo", "20", new DateTime(2000, 12, 12), new DateTime(1999, 12, 12), new string[] { "wifi", "musica" });
			Flota flota2 = new Flota(2, "AAA6666", "Camion", "opel2", "modelo", "23", new DateTime(2013, 11, 10), new DateTime(2000, 10, 11), new string[] { "wifi", "musica" });
			this.flotas = new List<Flota>();
			flotas.Add(flota1);
			flotas.Add(flota2);
			Cliente cliente1 = new Cliente("6666666F", "Nombre", "telefono", "asdsa@asda", "323213");
			Cliente cliente2 = new Cliente("6667776F", "Nombre2", "telefono2", "asdsa2@asda", "323213");
			List<Cliente> clientes = new List<Cliente>();
			clientes.Add(cliente1);
			clientes.Add(cliente2);
			Transportes transportes1 = new Transportes("6666AAA12121112", flota1, cliente1, new DateTime(2018, 11, 06), "12", new DateTime(2018, 11, 07), new DateTime(2018, 11, 08), "20", "50", 10);
			Transportes transportes2 = new Transportes("6666AAA12121113", flota1, cliente1, new DateTime(2018, 11, 06), "12", new DateTime(2018, 11, 07), new DateTime(2018, 11, 06), "20", "50", 10);
			Transportes transportes3 = new Transportes("6666AAA12121114", flota1, cliente1, new DateTime(2018, 11, 06), "12", new DateTime(2018, 11, 07), new DateTime(2018, 11, 11), "20", "50", 10);
			Transportes transportes4 = new Transportes("6666AAA12121115", flota1, cliente1, new DateTime(2018, 11, 06), "12", new DateTime(2018, 11, 07), new DateTime(2018, 11, 08), "20", "50", 10);


			transportes = new List<Transportes>();
			transportes.Add(transportes1);
			transportes.Add(transportes2);
			transportes.Add(transportes3);
			transportes.Add(transportes4);

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
			this.MainWindowView.operacionActividadGeneral.Click += (sender, e) => this.ActividadGeneral();
			this.MainWindowView.operacionActividadCliente.Click += (sender, e) => this.ActividadCliente();
			this.MainWindowView.operacionActividadCamion.Click += (sender, e) => this.ActividadCamion();
			this.MainWindowView.operacionActividadComodidades.Click += (sender, e) => this.ActividadComodidades();

			//Operaciones graficos
			this.generalGraf = new GeneralChart();
			    
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
            this.DDCSearch();
        }

        private void transportePendientes()
        {
            this.DTPSearch();
        }
        
		private int busquedaGeneralMesesGrafico(int mes)
        {
			StringBuilder toret = new StringBuilder();

			var dataList = new List<Transportes>(
				from transporte in this.transportes
				where (transporte.FechaContratacion.Month == mes)
				orderby transporte.FechaEntrega
				select transporte);
			
			this.MainWindowView.lTexto.Text = dataList.Count.ToString();
			return dataList.Count;
        }
        //Transportes pendientes: Mostrará todas los transportes, para todo la flota o por camión, para los próximos cinco días.
        private void DTPSearch()
        {

            var transportesProximos = new List<Transportes>(
            from transporte in this.transportes
            where (DateTime.Compare(transporte.FechaEntrega, DateTime.Today.AddDays(5)) <= 0 
            && DateTime.Compare(transporte.FechaEntrega, DateTime.Today) >= 0)
            orderby transporte.IdTransporte
            select transporte);
            StringBuilder toret = new StringBuilder();

            transportesProximos.ForEach((x) => { toret.Append(x.ToString()); });           

            this.MainWindowView.lTexto.Text = toret.ToString();
        }
        //Disponibilidad: muestra los camiones libres, opcionalmente por tipo.
        private void DDCSearch()
        {

            var camionesDisponibles = new List<Flota>();

            
            foreach (Transportes trans in this.transportes)
            {
                foreach (Flota flota in this.flotas)
                {
                    if(!flota.Matricula.Equals(trans.IdTransporte.Substring(0, 7)))
                    {
                        camionesDisponibles.Add(flota);
                    }
                }
                
            }
            StringBuilder toret = new StringBuilder();

            camionesDisponibles.ForEach((x) => { toret.Append(x.ToString()); });

            this.MainWindowView.lTexto.Text = toret.ToString();

        }

        /* Métodos de gráficos */
        private void ActividadGeneral()
		{
			this.generalGraf.ShowDialog();
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
		private GeneralChart generalGraf;
        public List<Transportes> transportes;
        public List<Flota> flotas;
    }
        
}
