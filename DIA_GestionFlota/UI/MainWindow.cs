namespace DIA_GestionFlota
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;
    using GestionFlotas.UI.DialogSearch;

    class MainWindow : Form
    {
        public MainWindow()
        {
            this.MainWindowView = new MainWindowView();


            Flota flota1 = new Flota(1.5, "AAA9999", "Mudanza", "opel", "modelo", "20", new DateTime(2000, 12, 12), new DateTime(1999, 12, 12), new string[] { "wifi", "musica" });
            Flota flota2 = new Flota(2, "AAA6666", "Transporte de mercancías", "opel2", "modelo", "23", new DateTime(2013, 11, 10), new DateTime(2000, 10, 11), new string[] { "wifi", "musica" });
            this.flotas = new List<Flota>();
            flotas.Add(flota1);
            flotas.Add(flota2);
            Cliente cliente1 = new Cliente("6666666F", "Nombre", "telefono", "asdsa@asda", "323213");
            Cliente cliente2 = new Cliente("6667776F", "Nombre2", "telefono2", "asdsa2@asda", "323213");
            List<Cliente> clientes = new List<Cliente>();
            clientes.Add(cliente1);
            clientes.Add(cliente2);
            Transportes transportes1 = new Transportes("6666AAA12121112", flota1, cliente1, new DateTime(2018, 11, 06), "12", new DateTime(2018, 11, 07), new DateTime(2018, 11, 09), "20", "50", 10);
            Transportes transportes2 = new Transportes("6666AAA12121113", flota1, cliente1, new DateTime(2018, 11, 06), "12", new DateTime(2018, 11, 07), new DateTime(2018, 11, 09), "20", "50", 10);
            Transportes transportes3 = new Transportes("6666AAA12121114", flota1, cliente1, new DateTime(2018, 11, 06), "12", new DateTime(2018, 11, 07), new DateTime(2018, 11, 09), "20", "50", 10);
            Transportes transportes4 = new Transportes("9999AAA12121115", flota1, cliente1, new DateTime(2018, 11, 06), "12", new DateTime(2018, 11, 07), new DateTime(2018, 11, 08), "20", "50", 10);


            transportes = new List<Transportes>();
            transportes.Add(transportes1);
            transportes.Add(transportes2);
            transportes.Add(transportes3);
            transportes.Add(transportes4);

            //this.transportes = new Transportes();
            this.MainWindowView.operacionSalir.Click += (sender, e) => this.Salir();

            //Operaciones búsqueda
            //Inicializar dialogos
            this.dialogoDni = new DialogoDniCliente();
            this.dialogoCamion = new DialogoCamiones();
            //Menu
            this.MainWindowView.operacionSearch1.Click += (sender, e) => this.transportePendientes();
            this.MainWindowView.operacionSearch2.Click += (sender, e) => this.disponibilidad();
            this.MainWindowView.operacionSearch3.Click += (sender, e) => this.transportesPorCliente();
            this.MainWindowView.operacionSearch4.Click += (sender, e) => this.reservasPorCamion();
            this.MainWindowView.operacionSearch5.Click += (sender, e) => this.reservasPorCliente();
            this.MainWindowView.operacionSearch6.Click += (sender, e) => this.ocupacion();

            //Dialogos
            this.dialogoDni.btSearchCliente.Click += (sender, e) => this.mostrarReservasPorCliente();
            this.dialogoCamion.btSearchCamiones.Click +=(sender,e) => this.DDCSearch();



            //Operaciones graficos
            this.MainWindowView.operacionActividadGeneral.Click += (sender, e) => this.ActividadGeneral();
            this.MainWindowView.operacionActividadCliente.Click += (sender, e) => this.ActividadCliente();
            this.MainWindowView.operacionActividadCamion.Click += (sender, e) => this.ActividadCamion();
            this.MainWindowView.operacionActividadComodidades.Click += (sender, e) => this.ActividadComodidades();

            //Operaciones graficos
            this.generalGraf = new GeneralChart();

        }

        //Métodos búsqueda
        //Transportes pendientes: Mostrará todas los transportes, para todo la flota o por camión, para los próximos cinco días.
        private void transportePendientes()
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

        private void disponibilidad()
        {
            this.dialogoCamion.ShowDialog();
        }

        //Disponibilidad: muestra los camiones libres, opcionalmente por tipo.
        private void DDCSearch()
        {

            var camionesDisponibles = new List<Flota>();
            var tipo = dialogoCamion.Tipo;

           if (tipo.Equals("Todos"))
           {
                tipo = "";
            }
           /*
            bool añadir = false;
            
            foreach (Flota flota in this.flotas)
            {
                foreach (Transportes trans in this.transportes)
                {
                    if (!(flota.Matricula.Equals(trans.IdTransporte.Substring(0, 7))) && flota.Tipo.Contains(tipo)
                          && DateTime.Compare(trans.FechaEntrega, DateTime.Today) >= 0)
                    {
                        añadir = true;
                        break;
                    }
                }

                if (añadir)
                {
                    camionesDisponibles.Add(flota);
                    añadir = false;
                }
            }*/
            var transportesLibres = new List<Transportes>(
                from transporte in this.transportes
                where DateTime.Compare(transporte.FechaEntrega, DateTime.Today) <= 0
                orderby transporte.IdTransporte
                select transporte);
            /*
            foreach(Transportes t in transportesLibres)
            {
                System.Console.WriteLine(t);
            }*/
            
            foreach(Flota flota in flotas)
            {
               foreach(Transportes trans in transportesLibres)
                {
                    //System.Console.WriteLine(flota.Tipo.Contains(tipo));
                    System.Console.WriteLine(flota.Matricula.Substring(3, 4));
                    System.Console.WriteLine(trans.IdTransporte.Substring(0, 4));
                    if ( flota.Tipo.Contains(tipo) 
                        
                        &&  flota.Matricula.Substring(0,3).Equals(trans.IdTransporte.Substring(4, 3))
                        && flota.Matricula.Substring(3, 4).Equals(trans.IdTransporte.Substring(0,4))
                        && !camionesDisponibles.Contains(flota))
                    {
                        System.Console.WriteLine(flota);
                        camionesDisponibles.Add(flota);
                    }
                }
            }


            StringBuilder toret = new StringBuilder();

            camionesDisponibles.ForEach((x) => { toret.Append(x.ToString()); });


            this.MainWindowView.lTexto.Text = toret.ToString();

        }

        private void ocupacion()
        {

        }

        private void transportesPorCliente()
        {

        }

        private void reservasPorCamion()
        {
            var camiones = new List<Transportes>(
            from transporte in this.transportes
            orderby transporte.IdTransporte
            select transporte);
            StringBuilder toret = new StringBuilder();

            camiones.ForEach((x) => { toret.Append(x.ToString()); });

            this.MainWindowView.lTexto.Text = toret.ToString();
        }

        //Reservas por cliente: Mostrará todas las reservas para una persona
        private void reservasPorCliente()
        {
            this.dialogoDni.ShowDialog();
        }
        private void mostrarReservasPorCliente()
        {
            var reservas = new List<Transportes>(
            from transporte in this.transportes
            where transporte.Cliente.Nif == dialogoDni.idDni
            orderby transporte.IdTransporte
            select transporte);
            StringBuilder toret = new StringBuilder();

            reservas.ForEach((x) => { toret.Append(x.ToString()); });

            this.MainWindowView.lTexto.Text = toret.ToString();

        }



        /* Métodos de gráficos */

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

        //Busqueda

        public DialogoDniCliente dialogoDni { get; private set; }
        public DialogoCamiones dialogoCamion { get; private set; }


        //Graficos





    }
        
}
