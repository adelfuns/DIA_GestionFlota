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
            flotas = new List<Flota>();
            flotas.Add(flota1);
            flotas.Add(flota2);
            Cliente cliente1 = new Cliente("6666666F", "Nombre", "telefono", "asdsa@asda", "323213");
            Cliente cliente2 = new Cliente("6667776F", "Nombre2", "telefono2", "asdsa2@asda", "323213");
            clientes = new List<Cliente>();
            clientes.Add(cliente1);
            clientes.Add(cliente2);
            Transportes transportes1 = new Transportes("6666AAA12121112", flota1, cliente1, new DateTime(2017, 11, 06), "12", new DateTime(2017, 11, 07), new DateTime(2017, 11, 12), "20", "50", 10);
            Transportes transportes2 = new Transportes("6666AAA12121113", flota1, cliente1, new DateTime(2018, 11, 06), "12", new DateTime(2018, 11, 07), new DateTime(2018, 11, 11), "20", "50", 10);
            Transportes transportes3 = new Transportes("9999AAA12121114", flota1, cliente1, new DateTime(2018, 11, 06), "12", new DateTime(2018, 11, 07), new DateTime(2018, 11, 10), "20", "50", 10);
            Transportes transportes4 = new Transportes("9999AAA12121115", flota1, cliente2, new DateTime(2018, 11, 06), "12", new DateTime(2018, 11, 07), new DateTime(2018, 11, 15), "20", "50", 10);


            transportes = new List<Transportes>();
            transportes.Add(transportes1);
            transportes.Add(transportes2);
            transportes.Add(transportes3);
            transportes.Add(transportes4);

            //this.transportes = new Transportes();
            this.MainWindowView.operacionSalir.Click += (sender, e) => this.Salir();

            //Operaciones búsqueda
            //Inicializar dialogos
            this.dialogoTransportesPendientes = new DialogoTransportesPendientes();
            
            this.dialogoCamion = new DialogoCamiones();
            this.dialogoTransporteCliente = new DialogoTransporteCliente();
            this.dialogoReservasCamion = new DialogoReservasCamion();
            this.dialogoDni = new DialogoDniCliente();
            this.dialogoOcupacion = new DialogoOcupacion();

            //Menu
            this.MainWindowView.operacionSearch1.Click += (sender, e) => this.transportePendientes();
            this.MainWindowView.operacionSearch2.Click += (sender, e) => this.disponibilidad();
            this.MainWindowView.operacionSearch3.Click += (sender, e) => this.transportesPorCliente();
            this.MainWindowView.operacionSearch4.Click += (sender, e) => this.reservasPorCamion();
            this.MainWindowView.operacionSearch5.Click += (sender, e) => this.reservasPorCliente();
            this.MainWindowView.operacionSearch6.Click += (sender, e) => this.ocupacion();

            //Dialogos
            this.dialogoTransportesPendientes.btSearchCamiones.Click += (sender, e) => this.DTPSearch();
            this.dialogoCamion.btSearchCamiones.Click += (sender, e) => this.DDCSearch();
            this.dialogoTransporteCliente.btSearchTransporteCliente.Click += (sender, e) => this.mostrarTransporteCliente();
            this.dialogoReservasCamion.btSearchCamiones.Click += (sender, e) => this.DRC();
            this.dialogoDni.btSearchCliente.Click += (sender, e) => this.mostrarReservasPorCliente();
            this.dialogoOcupacion.btSearchOcupacionAnho.Click += (sender, e) => this.mostrarOcupacionAnho();
            this.dialogoOcupacion.btSearchOcupacionFecha.Click += (sender, e) => this.mostrarOcupacionFecha();

            //Operaciones graficos
            this.MainWindowView.operacionActividadGeneral.Click += (sender, e) => this.ActividadGeneral();
            this.MainWindowView.operacionActividadCliente.Click += (sender, e) => this.ActividadCliente();
            this.MainWindowView.operacionActividadCamion.Click += (sender, e) => this.ActividadCamion();
            this.MainWindowView.operacionActividadComodidades.Click += (sender, e) => this.ActividadComodidades();

            //Operaciones graficos
            this.generalGraf = new GeneralChart();

        }

        //Métodos búsqueda
        // Inicio Transportes pendientes: Mostrará todas los transportes, para todo la flota o por camión, para los próximos cinco días
        private void transportePendientes()
        {
            this.dialogoTransportesPendientes.ShowDialog();
        }

        private void DTPSearch()
        {
            var matricula = dialogoTransportesPendientes.Matricula;
            System.Console.WriteLine(matricula);
            if (matricula.Equals("Todos"))
            {
                matricula = "";
            }

            var transportesProximos = new List<Transportes>(
            from transporte in transportes
            where ( DateTime.Compare(transporte.FechaEntrega, DateTime.Today.AddDays(5)) <= 0
                    && DateTime.Compare(transporte.FechaEntrega, DateTime.Today) >= 0)
                    &&(matricula.Equals("") || (matricula.Substring(0, 3).Equals(transporte.IdTransporte.Substring(4, 3))
                    && matricula.Substring(3, 4).Equals(transporte.IdTransporte.Substring(0, 4))))
            orderby transporte.IdTransporte
            select transporte);

            StringBuilder toret = new StringBuilder();

            transportesProximos.ForEach((x) => { toret.Append(x.ToString()); });

            if (toret.ToString() == "")
            {
                toret.AppendLine("No hay resultados que coincidan con la busqueda");
            }

            this.MainWindowView.lTexto.Text = toret.ToString();
        }
        //Fin Transportes pendientes.

        //Inicio Disponibilidad: muestra los camiones libres, opcionalmente por tipo.
        private void disponibilidad()
        {
            this.dialogoCamion.ShowDialog();
        }

        private void DDCSearch()
        {
            var camionesDisponibles = new List<Flota>();
            var tipo = dialogoCamion.Tipo;
            System.Console.WriteLine(tipo);
            if (tipo.Equals("Todos")){
                tipo = "";
            }
          
            var transportesPosibles = new List<String>(
                from transporte in transportes
                where DateTime.Compare(transporte.FechaEntrega, DateTime.Today) > 0
                orderby transporte.IdTransporte
                select (transporte.IdTransporte.Substring(4, 3) + transporte.IdTransporte.Substring(0, 4)));

            var transportesOcupados = new List<String>(
                from transporte in transportes
                where DateTime.Compare(transporte.FechaEntrega, DateTime.Today) <= 0
                orderby transporte.IdTransporte
                select (transporte.IdTransporte.Substring(4, 3) + transporte.IdTransporte.Substring(0, 4)));

            var transportesLibres = transportesPosibles.Except(transportesOcupados);

            foreach (Flota flota in flotas){
               foreach(String trans in transportesLibres){
                    if (flota.Tipo.Contains(tipo)  && flota.Matricula.Equals(trans) && flota.Matricula.Equals(trans)){
                        if (!camionesDisponibles.Contains(flota)){
                            camionesDisponibles.Add(flota);
                        }
                    }
                }
            }

            StringBuilder toret = new StringBuilder();
            camionesDisponibles.ForEach((x) => { toret.Append(x.ToString()); });

            if(toret.ToString() == ""){
                toret.AppendLine("No hay resultados que coincidan con la busqueda");
            }

            this.MainWindowView.lTexto.Text = toret.ToString();

        }
        //Fin disponibilidad

        //Inicio Reservas por cliente: Mostrará todas los transportes para un cliente, pasadas o pendientes.
        private void transportesPorCliente()
        {
            this.dialogoTransporteCliente.ShowDialog();
        }

        private void mostrarTransporteCliente()
        {
            var nifClienteSeleccionado = this.dialogoTransporteCliente.Cliente;
            var periodoSeleccionado = this.dialogoTransporteCliente.Periodo;
            var anhosSeleccionado = this.dialogoTransporteCliente.Anho;
            List<Transportes> transportesCliente;


            transportesCliente = new List<Transportes>(
            from transporte in transportes
            where transporte.Cliente.Nif.Equals(nifClienteSeleccionado) && (anhosSeleccionado.Contains(transporte.FechaEntrega.Year.ToString()) || anhosSeleccionado.Equals(""))
                            && ((DateTime.Compare(transporte.FechaEntrega, DateTime.Today) < 0) && periodoSeleccionado.Equals("Transportes pasados")
                            || ( (DateTime.Compare(transporte.FechaSalida, DateTime.Today) <= 0
                            && DateTime.Compare(transporte.FechaEntrega, DateTime.Today) >= 0 && !periodoSeleccionado.Equals("Transportes pasados"))))
            orderby transporte.IdTransporte
            select transporte);

            StringBuilder toret = new StringBuilder();
            transportesCliente.ForEach((x) => { toret.Append(x.ToString()); });

            if (toret.ToString() == ""){
                toret.AppendLine("No hay resultados que coincidan con la busqueda");
            }

            this.MainWindowView.lTexto.Text = toret.ToString();
        }
        //Fin Reservas por cliente: Mostrará todas los transportes para un cliente, pasadas o pendientes.

        //Inicio Reservas por camión: Mostrará todas los transportes, pasados o pendientes, para todo la flota o por camión.
        private void reservasPorCamion()
        {
            this.dialogoReservasCamion.ShowDialog();
        }

        private void DRC()
        {

            var flotamatriculaSeleccionada = this.dialogoReservasCamion.Matricula;
            var periodoSeleccionado = this.dialogoReservasCamion.Periodo;
            var anhosSeleccionado = this.dialogoReservasCamion.Anho;

            if (flotamatriculaSeleccionada.Equals("Todos"))
            {
                flotamatriculaSeleccionada = "";
            }

            var camiones = new List<Transportes>(
                from trans in transportes
                where  (anhosSeleccionado.Contains(trans.FechaEntrega.Year.ToString()) || anhosSeleccionado.Equals("")) &&(
                   ((DateTime.Compare(trans.FechaEntrega, DateTime.Today) < 0) && periodoSeleccionado.Equals("Transportes pasados"))
                    || ((DateTime.Compare(trans.FechaSalida, DateTime.Today) <= 0) && (DateTime.Compare(trans.FechaEntrega, DateTime.Today) >= 0) && (!periodoSeleccionado.Equals("Transportes pasados")))
                    
                    && (flotamatriculaSeleccionada.Equals("") || (flotamatriculaSeleccionada.Substring(0, 3).Equals(trans.IdTransporte.Substring(4, 3))
                    && flotamatriculaSeleccionada.Substring(3, 4).Equals(trans.IdTransporte.Substring(0, 4)))))
                orderby trans.IdTransporte
                select trans);

            StringBuilder toret = new StringBuilder();
            camiones.ForEach((x) => { toret.Append(x.ToString()); });

            if (toret.ToString() == "")
            {
                toret.AppendLine("No hay resultados que coincidan con la busqueda");
            }

            this.MainWindowView.lTexto.Text = toret.ToString();
        }
        //Fin Reservas por camión: Mostrará todas los transportes, pasados o pendientes, para todo la flota o por camión.

        //Inicio Reservas por cliente: Mostrará todas las reservas para una persona
        private void reservasPorCliente()
        {
            this.dialogoDni.ShowDialog();
        }

        private void mostrarReservasPorCliente()
        {

            var anhosSeleccionado = this.dialogoDni.Anho;

            var reservas = new List<Transportes>(
            from transporte in transportes
            where transporte.Cliente.Nif == this.dialogoDni.idDni && (anhosSeleccionado.Contains(transporte.FechaEntrega.Year.ToString()) || anhosSeleccionado.Equals(""))
            orderby transporte.IdTransporte
            select transporte);
            StringBuilder toret = new StringBuilder();

            reservas.ForEach((x) => { toret.Append(x.ToString()); });

            if (toret.ToString() == "")
            {
                toret.AppendLine("No hay resultados que coincidan con la busqueda");
            }
            this.MainWindowView.lTexto.Text = toret.ToString();

        }
        //Fin Reservas por cliente: Mostrará todas las reservas para una persona

        //Inicio Ocupación: muestra los camiones con transportes realizados, para una determinada fecha o para un año completo.
        private void ocupacion()
        {
            this.dialogoOcupacion.ShowDialog();
        }

        private void mostrarOcupacionAnho()
        {

            var anhosSeleccionado = this.dialogoOcupacion.Anho;

            var reservas = new List<Transportes>(
            from transporte in transportes
            where(anhosSeleccionado.Contains(transporte.FechaEntrega.Year.ToString()) || anhosSeleccionado.Equals(""))
            orderby transporte.IdTransporte
            select transporte);
            StringBuilder toret = new StringBuilder();

            reservas.ForEach((x) => { toret.Append(x.ToString()); });

            if (toret.ToString() == "")
            {
                toret.AppendLine("No hay resultados que coincidan con la busqueda");
            }
            this.MainWindowView.lTexto.Text = toret.ToString();

        }

        private void mostrarOcupacionFecha()
        {
            var fechaSeleccionada = this.dialogoOcupacion.Fecha;
            var reservas = new List<Transportes>(
            from transporte in transportes
            where (DateTime.Compare(transporte.FechaEntrega, fechaSeleccionada) < 0)    
            orderby transporte.IdTransporte
            select transporte);
            StringBuilder toret = new StringBuilder();

            reservas.ForEach((x) => { toret.Append(x.ToString()); });

            if (toret.ToString() == "")
            {
                toret.AppendLine("No hay resultados que coincidan con la busqueda");
            }
            this.MainWindowView.lTexto.Text = toret.ToString();
        }
        //Fin ocupacion: muestra los camiones con transportes realizados, para una determinada fecha o para un año completo.

        /* Métodos de gráficos */

        private int busquedaGeneralMesesGrafico(int mes)
        {
            StringBuilder toret = new StringBuilder();

            var dataList = new List<Transportes>(
                from transporte in transportes
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
       
        public static List<Transportes> transportes;
        public static List<Flota> flotas;
        public static List<Cliente> clientes;
        
        //Busqueda
        public DialogoTransportesPendientes dialogoTransportesPendientes { get; private set; }
        public DialogoDniCliente dialogoDni { get; private set; }
        public DialogoCamiones dialogoCamion { get; private set; }
        public DialogoTransporteCliente dialogoTransporteCliente { get; private set; }
        public DialogoReservasCamion dialogoReservasCamion { get; private set; }
        public DialogoOcupacion dialogoOcupacion { get; private set; }
        //Graficos

        private GeneralChart generalGraf;

    }
        
}
