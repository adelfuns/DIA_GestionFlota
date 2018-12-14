namespace DIA_GestionFlota
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;
    using GestionFlotas.UI.DialogSearch;
    using GestionFlotas.UI.DialogGraphics;

    class MainWindow : Form
    {
        public MainWindow()
        {
            this.MainWindowView = new MainWindowView();


            /** *********************** **/
            /** CREACION DE LOS OBJETOS **/
            /** *********************** **/

            //Flota
            Flota flota1 = new Flota(1.5, "AAA9999", "Mudanza", "opel", "modelo", "20",
                                 new DateTime(2000, 12, 12), new DateTime(1999, 12, 12), new string[] { "wifi", "musica" });
            Flota flota2 = new Flota(2, "AAA6666", "Transporte de mercancías", "opel2",
                                 "modelo", "23", new DateTime(2013, 11, 10), new DateTime(2000, 10, 11), new string[] { "wifi", "musica", "aire acondicionado" });

            Flota flota3 = new Flota(2, "AAA2201", "Transporte de mercancías", "opel5",
                                 "modelo", "23", new DateTime(2013, 10, 10), new DateTime(2000, 10, 11), new string[] { "wifi", "musica", "aire acondicionado" });
            Flota flota4 = new Flota(2, "AAA2222", "Transporte de mercancías", "opel3",
                                 "modelo", "23", new DateTime(2013, 11, 10), new DateTime(2000, 10, 11), new string[] { "wifi", "musica", "tv" });
            Flota flota5 = new Flota(2, "AAA3333", "Transporte de mercancías", "mazda",
                                 "modelo", "23", new DateTime(2000, 11, 10), new DateTime(2000, 10, 11), new string[] { "wifi", "musica", "aire acondicionado" });
            Flota flota6 = new Flota(2, "AAA4444", "Transporte de mercancías", "unlucky",
                                 "modelo", "23", new DateTime(2000, 11, 10), new DateTime(2000, 10, 11), new string[] { "wifi", "musica", "aire acondicionado" });
            Flota flota7 = new Flota(2, "AAA5555", "Transporte de mercancías", "opel2",
                                 "modelo", "23", new DateTime(2000, 11, 10), new DateTime(2000, 10, 11), new string[] { "wifi", "musica", "aire acondicionado" });
            Flota flota8 = new Flota(2, "AAA7777", "Transporte de mercancías", "opel2",
                                 "modelo", "23", new DateTime(2013, 3, 10), new DateTime(2000, 10, 11), new string[] { "wifi", "musica",  "aire acondicionado" });
            Flota flota9 = new Flota(2, "AAA8888", "Transporte de mercancías", "opel2",
                                 "modelo", "23", new DateTime(2013, 3, 10), new DateTime(2000, 10, 11), new string[] { "wifi", "litera de descanso", "aire acondicionado" });
            flotas = new List<Flota>();
            flotas.Add(flota1);
            flotas.Add(flota2);
            flotas.Add(flota3);
            flotas.Add(flota4);
            flotas.Add(flota5);
            flotas.Add(flota6);
            flotas.Add(flota7);
            flotas.Add(flota8);
            flotas.Add(flota9);

            //Clientes
            Cliente cliente1 = new Cliente("6666666F", "Nombre", "telefono", "asdsa@asda", "323213");
            Cliente cliente2 = new Cliente("6667776F", "Nombre2", "telefono2", "asdsa2@asda", "323213");

            Cliente cliente3 = new Cliente("6345345B", "Nombreaaaa", "telefono", "asdcscCecsa@asda", "323213");
            Cliente cliente4 = new Cliente("6123466D", "Nombre2eeee", "telefono3", "asdwgeq3wg422@asda", "323213");
            Cliente cliente5 = new Cliente("6699666A", "Nombrewefwr", "telefon4", "asergreg@asda", "323213");
            Cliente cliente6 = new Cliente("6999776S", "Nombre2ergerg", "telefasdgasro2", "aswefwefwefa2@asda", "323213");
            clientes = new List<Cliente>();
            clientes.Add(cliente1);
            clientes.Add(cliente2);
            clientes.Add(cliente3);
            clientes.Add(cliente4);
            clientes.Add(cliente5);
            clientes.Add(cliente6);
            
            //Transportes
            Transportes transportes1 = new Transportes("6666AAA12122202", flota2, cliente1, new DateTime(2017, 11, 06),
                                             "12", new DateTime(2017, 11, 07), new DateTime(2017, 11, 12), "20", "50", 10);
            Transportes transportes2 = new Transportes("6666AAA12122203", flota2, cliente1, new DateTime(2018, 11, 06),
                                             "12", new DateTime(2018, 11, 07), new DateTime(2018, 11, 23), "20", "50", 10);
            Transportes transportes3 = new Transportes("9999AAA12122204", flota2, cliente1, new DateTime(2018, 11, 06),
                                             "12", new DateTime(2018, 11, 07), new DateTime(2018, 11, 22), "20", "50", 10);
            Transportes transportes4 = new Transportes("9999AAA12122205", flota2, cliente2, new DateTime(2018, 11, 06),
                                             "12", new DateTime(2018, 11, 07), new DateTime(2018, 11, 21), "20", "50", 10);

            Transportes transportes5 = new Transportes("6666AAA34534623", flota1, cliente3, new DateTime(2014, 08, 07),
                                           "12", new DateTime(2014, 08, 07), new DateTime(2014, 10, 12), "20", "50", 10);
            Transportes transportes6 = new Transportes("6666AAA13263263", flota1, cliente3, new DateTime(2014, 08, 07),
                                             "12", new DateTime(2014, 08, 07), new DateTime(2014, 10, 23), "20", "50", 10);
            Transportes transportes7 = new Transportes("9999AAA22011234", flota3, cliente3, new DateTime(2014, 08, 07),
                                             "12", new DateTime(2014, 08, 07), new DateTime(2014, 10, 22), "20", "50", 10);
            Transportes transportes8 = new Transportes("9999AAA12123455", flota4, cliente3, new DateTime(2014, 08, 07),
                                             "12", new DateTime(2014, 08, 07), new DateTime(2014, 10, 21), "20", "50", 10);

            Transportes transportes9 = new Transportes("6666AAA13322202", flota5, cliente3, new DateTime(2015, 01, 07),
                                           "12", new DateTime(2015, 01, 07), new DateTime(2015, 05, 12), "20", "50", 10);
            Transportes transportes10 = new Transportes("6666AAA1334113", flota5, cliente4, new DateTime(2015, 02, 07),
                                             "12", new DateTime(2015, 02, 07), new DateTime(2015, 05, 23), "20", "50", 10);
            Transportes transportes11 = new Transportes("9999AAA1785514", flota5, cliente4, new DateTime(2015, 02, 07),
                                             "12", new DateTime(2015, 02, 07), new DateTime(2015, 06, 22), "20", "50", 10);
            Transportes transportes12 = new Transportes("9999AAA12889885", flota6, cliente5, new DateTime(2015, 04, 07),
                                             "12", new DateTime(2015, 04, 07), new DateTime(2015, 05, 21), "20", "50", 10);

            Transportes transportes13 = new Transportes("6666AAA88888882", flota7, cliente6, new DateTime(2014, 11, 07),
                                           "12", new DateTime(2014, 11, 07), new DateTime(2014, 11, 12), "20", "50", 10);
            Transportes transportes14 = new Transportes("6666AAA12999999", flota8, cliente6, new DateTime(2017, 03, 07),
                                             "12", new DateTime(2017, 03, 07), new DateTime(2017, 04, 23), "20", "50", 10);
            Transportes transportes15 = new Transportes("9999AAA16666666", flota9, cliente6, new DateTime(2018, 03, 07),
                                             "12", new DateTime(2018, 03, 07), new DateTime(2018, 04, 22), "20", "50", 10);
            Transportes transportes16 = new Transportes("9999AAA12000000", flota8, cliente6, new DateTime(2018, 03, 07),
                                             "12", new DateTime(2018, 03, 07), new DateTime(2018, 04, 21), "20", "50", 10);
            transportes = new List<Transportes>();
            transportes.Add(transportes1);
            transportes.Add(transportes2);
            transportes.Add(transportes3);
            transportes.Add(transportes4);
            transportes.Add(transportes5);
            transportes.Add(transportes6);
            transportes.Add(transportes7);
            transportes.Add(transportes8);
            transportes.Add(transportes9);
            transportes.Add(transportes10);
            transportes.Add(transportes11);
            transportes.Add(transportes12);
            transportes.Add(transportes13);
            transportes.Add(transportes14);
            transportes.Add(transportes15);
            transportes.Add(transportes16);

            /** *************************** **/
            /** FIN CREACION DE LOS OBJETOS **/
            /** *************************** **/

            /** ***************** **/
            /** MANEJO DE EVENTOS **/
            /** ***************** **/

            this.MainWindowView.operacionSalir.Click += (sender, e) => this.Salir();
            this.MainWindowView.menuAtras.Click += (sender, e) => this.mostrarTodosLosTransportes();

            this.MainWindowView.Load += (sender, e) => this.mostrarTodosLosTransportes();

            //Operaciones búsqueda
            //Inicializar dialogos
            this.dialogoTransportesPendientes = new DialogoTransportesPendientes();        
            this.dialogoCamion = new DialogoCamiones();
            this.dialogoTransporteCliente = new DialogoTransporteCliente();
            this.dialogoReservasCamion = new DialogoReservasCamion();
            this.dialogoDni = new DialogoDniCliente();
            this.dialogoOcupacion = new DialogoOcupacion();
            this.dialogoGraficoGeneral = new DialogoGraficoGeneral();
            this.dialogoGraficoCliente = new DialogoGraficoCliente();
            this.dialogoGraficoCamion = new DialogoGraficoCamion();
            this.dialogoGraficoComodidades = new DialogoGraficoComodidades();

            //Menu de la MainWindowView//
            this.MainWindowView.operacionSalir.Click += (sender, e) => this.Salir(); //Búsqueda
            this.MainWindowView.operacionSearch1.Click += (sender, e) => this.transportePendientes(); //Búsqueda
            this.MainWindowView.operacionSearch2.Click += (sender, e) => this.disponibilidad(); //Búsqueda
            this.MainWindowView.operacionSearch3.Click += (sender, e) => this.transportesPorCliente(); //Búsqueda
            this.MainWindowView.operacionSearch4.Click += (sender, e) => this.reservasPorCamion(); //Búsqueda
            this.MainWindowView.operacionSearch5.Click += (sender, e) => this.reservasPorCliente(); //Búsqueda
            this.MainWindowView.operacionSearch6.Click += (sender, e) => this.ocupacion(); //Búsqueda
            this.MainWindowView.operacionActividadGeneral.Click += (sender, e) => this.ActividadGeneral(); //Grafico
            this.MainWindowView.operacionActividadCliente.Click += (sender, e) => this.ActividadCliente(); //Grafico
            this.MainWindowView.operacionActividadCamion.Click += (sender, e) => this.ActividadCamion(); //Grafico
            this.MainWindowView.operacionActividadComodidades.Click += (sender, e) => this.ActividadComodidades(); //Grafico
            this.MainWindowView.btSearchTransporte.Click += (sender, e) => this.botonBusquedaTrasnporte(); //No se que son estos
            this.MainWindowView.btSearchFlota.Click += (sender, e) => this.botonBusquedaFlota(); //No se que son estos

            //Dialogos//
            this.dialogoTransportesPendientes.btSearchCamiones.Click += (sender, e) => this.DTPSearch(); //Búsqueda
            this.dialogoCamion.btSearchCamiones.Click += (sender, e) => this.DDCSearch(); //Búsqueda
            this.dialogoTransporteCliente.btSearchTransporteCliente.Click += (sender, e) => this.DTCSearch(); //Búsqueda
            this.dialogoReservasCamion.btSearchCamiones.Click += (sender, e) => this.DRCSearch(); //Búsqueda
            this.dialogoDni.btSearchCliente.Click += (sender, e) => this.RPCSearch(); //Búsqueda
            this.dialogoOcupacion.btSearchOcupacionAnho.Click += (sender, e) => this.OASearch(); //Búsqueda
            this.dialogoOcupacion.calendar.DateSelected += (sender, e) => this.OFSearch(); //Búsqueda
            this.dialogoGraficoGeneral.btGraficoGeneralAnual.Click += (sender, e) => this.ActividadGeneralAnual(); //Grafico
            this.dialogoGraficoGeneral.btGraficoGeneralTotal.Click += (sender, e) => this.ActividadGeneralTotal(); //Grafico
            this.dialogoGraficoCliente.btGraficoGeneralAnual.Click += (sender, e) => this.ActividadClienteAnual(); //Grafico
            this.dialogoGraficoCliente.btGraficoGeneralTotal.Click += (sender, e) => this.ActividadClienteTotal(); //Grafico
            this.dialogoGraficoCamion.btGraficoGeneralAnual.Click += (sender, e) => this.ActividadCamionAnual(); //Grafico
            this.dialogoGraficoCamion.btGraficoGeneralTotal.Click += (sender, e) => this.ActividadCamionTotal(); //Grafico
            this.dialogoGraficoComodidades.btGraficoGeneralAnual.Click += (sender, e) => this.FlotaComodidadesAnual(); //Grafico
            this.dialogoGraficoComodidades.btGraficoGeneralTotal.Click += (sender, e) => this.FlotaComodidadesTotal(); //Grafico

            /** ********************* **/
            /** FIN MANEJO DE EVENTOS **/
            /** ********************* **/

        }

        /** ******** **/
        /** BÚSQUEDA **/
        /** ******** **/

        public void mostrarTodosLosTransportes()
        {
            var trans = new List<Transportes>(
            from transporte in transportes
            where DateTime.Compare(transporte.FechaEntrega, DateTime.Today) >= 0
            orderby transporte.IdTransporte
            select transporte);

            ActualizaListaTransportes(trans);
            MainWindowView.panelPrincipal.Controls.Remove(MainWindowView.panelLista);
            MainWindowView.panelLista = MainWindowView.panelListaTransporte;
            MainWindowView.panelPrincipal.Controls.Add(MainWindowView.panelLista);

            MainWindowView.panelOpciones.Controls.Remove(MainWindowView.panelOpcionesPoner);
            MainWindowView.panelOpcionesPoner = MainWindowView.panelOpcionesTransportes;
            MainWindowView.panelOpciones.Controls.Add(MainWindowView.panelOpcionesPoner);

            this.MainWindowView.Width = MainWindowView.grdListaTransporte.Columns.GetColumnsWidth(0) + 20 ;
            this.MainWindowView.Height = MainWindowView.grdListaTransporte.Rows.GetRowsHeight(0) + 84 + MainWindowView.panelOpciones.Height;

        }

        private void botonBusquedaTrasnporte()
        {
            switch (MainWindowView.escogerBusquedaTrasnporte.Text) {
                case "Buscar transportes pendientes":
                    this.transportePendientes();
                    break;
                case "Transportes por cliente":
                    this.transportesPorCliente();
                    break;
                case "Reservas por camion":
                    this.reservasPorCamion();
                    break;
                case "Reservas por cliente":
                    this.reservasPorCliente();
                    break;
                case "Ocupacion":
                    this.ocupacion();
                    break;
            }
        }

        private void botonBusquedaFlota()
        {
            switch (MainWindowView.escogerBusquedaFlota.Text)
            {
                case "Disponibilidad":
                    this.disponibilidad();
                    break;
            }
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
            //System.Console.WriteLine(matricula);
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

            ActualizaListaTransportes(transportesProximos);
          
            MainWindowView.panelPrincipal.Controls.Remove(MainWindowView.panelLista);
            MainWindowView.panelLista = MainWindowView.panelListaTransporte;
            MainWindowView.panelPrincipal.Controls.Add(MainWindowView.panelLista);

            MainWindowView.panelOpciones.Controls.Remove(MainWindowView.panelOpcionesPoner);
            MainWindowView.panelOpcionesPoner = MainWindowView.panelOpcionesTransportes;
            MainWindowView.panelOpciones.Controls.Add(MainWindowView.panelOpcionesPoner);

            this.MainWindowView.Width = MainWindowView.grdListaTransporte.Columns.GetColumnsWidth(0) + 20;
            this.MainWindowView.Height = MainWindowView.grdListaTransporte.Rows.GetRowsHeight(0) + 84 + MainWindowView.panelOpciones.Height;
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

            if (tipo.Equals("Todos")){
                tipo = "";
            }
          
            var transportesPosibles = new List<String>(
                from transporte in transportes
                where DateTime.Compare(transporte.FechaEntrega, DateTime.Today) < 0
                orderby transporte.IdTransporte
                select (transporte.IdTransporte.Substring(4, 3) + transporte.IdTransporte.Substring(0, 4)));

            var transportesOcupados = new List<String>(
                from transporte in transportes
                where DateTime.Compare(transporte.FechaEntrega, DateTime.Today) >= 0
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

            ActualizaListaFlota(camionesDisponibles);
            MainWindowView.panelPrincipal.Controls.Remove(MainWindowView.panelLista);

            MainWindowView.panelLista = MainWindowView.panelListaFlota;
            MainWindowView.panelPrincipal.Controls.Add(MainWindowView.panelLista);

            MainWindowView.panelOpciones.Controls.Remove(MainWindowView.panelOpcionesPoner);
            MainWindowView.panelOpcionesPoner = MainWindowView.panelOpcionesFlota;
            MainWindowView.panelOpciones.Controls.Add(MainWindowView.panelOpcionesPoner);

            this.MainWindowView.Width = MainWindowView.grdListaFlota.Columns.GetColumnsWidth(0) + 20;
            this.MainWindowView.Height = MainWindowView.grdListaFlota.Rows.GetRowsHeight(0) + 84 + MainWindowView.panelOpciones.Height;

        }
        //Fin disponibilidad

        //Inicio Reservas por cliente: Mostrará todas los transportes para un cliente, pasadas o pendientes.
        private void transportesPorCliente()
        {
            this.dialogoTransporteCliente.ShowDialog();
        }

        private void DTCSearch()
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

            ActualizaListaTransportes(transportesCliente);
            MainWindowView.panelPrincipal.Controls.Remove(MainWindowView.panelLista);
            MainWindowView.panelLista = MainWindowView.panelListaTransporte;
            MainWindowView.panelPrincipal.Controls.Add(MainWindowView.panelLista);

            MainWindowView.panelOpciones.Controls.Remove(MainWindowView.panelOpcionesPoner);
            MainWindowView.panelOpcionesPoner = MainWindowView.panelOpcionesTransportes;
            MainWindowView.panelOpciones.Controls.Add(MainWindowView.panelOpcionesPoner);

            this.MainWindowView.Width = MainWindowView.grdListaTransporte.Columns.GetColumnsWidth(0) + 20;
            this.MainWindowView.Height = MainWindowView.grdListaTransporte.Rows.GetRowsHeight(0) + 84 + MainWindowView.panelOpciones.Height;
        }
        //Fin Reservas por cliente: Mostrará todas los transportes para un cliente, pasadas o pendientes.

        //Inicio Reservas por camión: Mostrará todas los transportes, pasados o pendientes, para todo la flota o por camión.
        private void reservasPorCamion()
        {
            this.dialogoReservasCamion.ShowDialog();
        }

        private void DRCSearch()
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

            ActualizaListaTransportes(camiones);
            MainWindowView.panelPrincipal.Controls.Remove(MainWindowView.panelLista);
            MainWindowView.panelLista = MainWindowView.panelListaTransporte;
            MainWindowView.panelPrincipal.Controls.Add(MainWindowView.panelLista);
            MainWindowView.panelOpciones.Controls.Remove(MainWindowView.panelOpcionesPoner);

            MainWindowView.panelOpcionesPoner = MainWindowView.panelOpcionesTransportes;
            MainWindowView.panelOpciones.Controls.Add(MainWindowView.panelOpcionesPoner);

            this.MainWindowView.Width = MainWindowView.grdListaTransporte.Columns.GetColumnsWidth(0) + 20;
            this.MainWindowView.Height = MainWindowView.grdListaTransporte.Rows.GetRowsHeight(0) + 84 + MainWindowView.panelOpciones.Height;
        }
        //Fin Reservas por camión: Mostrará todas los transportes, pasados o pendientes, para todo la flota o por camión.

        //Inicio Reservas por cliente: Mostrará todas las reservas para una persona
        private void reservasPorCliente()
        {
            this.dialogoDni.ShowDialog();
        }

        private void RPCSearch()
        {
            var anhosSeleccionado = this.dialogoDni.Anho;

            var reservas = new List<Transportes>(
            from transporte in transportes
            where transporte.Cliente.Nif == this.dialogoDni.idDni && (anhosSeleccionado.Contains(transporte.FechaEntrega.Year.ToString()) || anhosSeleccionado.Equals(""))
            orderby transporte.IdTransporte
            select transporte);

            ActualizaListaTransportes(reservas);
            MainWindowView.panelPrincipal.Controls.Remove(MainWindowView.panelLista);
            MainWindowView.panelLista = MainWindowView.panelListaTransporte;
            MainWindowView.panelPrincipal.Controls.Add(MainWindowView.panelLista);

            MainWindowView.panelOpciones.Controls.Remove(MainWindowView.panelOpcionesPoner);
            MainWindowView.panelOpcionesPoner = MainWindowView.panelOpcionesTransportes;
            MainWindowView.panelOpciones.Controls.Add(MainWindowView.panelOpcionesPoner);

            this.MainWindowView.Width = MainWindowView.grdListaTransporte.Columns.GetColumnsWidth(0) + 20;
            this.MainWindowView.Height = MainWindowView.grdListaTransporte.Rows.GetRowsHeight(0) + 84 + MainWindowView.panelOpciones.Height;
        }
        //Fin Reservas por cliente: Mostrará todas las reservas para una persona

        //Inicio Ocupación: muestra los camiones con transportes realizados, para una determinada fecha o para un año completo.
        private void ocupacion()
        {
            this.dialogoOcupacion.ShowDialog();
        }

        private void OASearch()
        {
            var anhosSeleccionado = this.dialogoOcupacion.Anho;

            var reservas = new List<Transportes>(
            from transporte in transportes
            where(anhosSeleccionado.Contains(transporte.FechaEntrega.Year.ToString()) || anhosSeleccionado.Equals(""))
            orderby transporte.IdTransporte
            select transporte);

            ActualizaListaTransportes(reservas);
            MainWindowView.panelPrincipal.Controls.Remove(MainWindowView.panelLista);
            MainWindowView.panelLista = MainWindowView.panelListaTransporte;
            MainWindowView.panelPrincipal.Controls.Add(MainWindowView.panelLista);

            MainWindowView.panelOpciones.Controls.Remove(MainWindowView.panelOpcionesPoner);
            MainWindowView.panelOpcionesPoner = MainWindowView.panelOpcionesTransportes;
            MainWindowView.panelOpciones.Controls.Add(MainWindowView.panelOpcionesPoner);

            this.MainWindowView.Width = MainWindowView.grdListaTransporte.Columns.GetColumnsWidth(0) + 20;
            this.MainWindowView.Height = MainWindowView.grdListaTransporte.Rows.GetRowsHeight(0) + 84 + MainWindowView.panelOpciones.Height;
        }

        private void OFSearch()
        {
            var fechaSeleccionada = this.dialogoOcupacion.Fecha;
           
            var reservas = new List<Transportes>(
            from transporte in transportes
            where (DateTime.Compare(transporte.FechaEntrega, fechaSeleccionada) < 0)    
            orderby transporte.IdTransporte
            select transporte);

            ActualizaListaTransportes(reservas);
            MainWindowView.panelPrincipal.Controls.Remove(MainWindowView.panelLista);
            MainWindowView.panelLista = MainWindowView.panelListaTransporte;
            MainWindowView.panelPrincipal.Controls.Add(MainWindowView.panelLista);

            MainWindowView.panelOpciones.Controls.Remove(MainWindowView.panelOpcionesPoner);
            MainWindowView.panelOpcionesPoner = MainWindowView.panelOpcionesTransportes;
            MainWindowView.panelOpciones.Controls.Add(MainWindowView.panelOpcionesPoner);

            this.MainWindowView.Width = MainWindowView.grdListaTransporte.Columns.GetColumnsWidth(0) + 20;
            this.MainWindowView.Height = MainWindowView.grdListaTransporte.Rows.GetRowsHeight(0) + 84 + MainWindowView.panelOpciones.Height;
        }
        //Fin ocupacion: muestra los camiones con transportes realizados, para una determinada fecha o para un año completo.

        private void ActualizaListaTransportes(List<Transportes> transportes)
        {
            int numTransportes = transportes.Count;

            int i = 0;
            foreach(Transportes t in transportes)
            {
                if(MainWindowView.grdListaTransporte.Rows.Count <= i)
                {
                    MainWindowView.grdListaTransporte.Rows.Add();
                }

                this.ActualizaFilaDeListaTransporte(i, t);
                i++;
            }

            int numExtra = MainWindowView.grdListaTransporte.Rows.Count - numTransportes;
            for (; numExtra > 0; --numExtra)
            {
                MainWindowView.grdListaTransporte.Rows.RemoveAt(numTransportes);
            }
        }

        private void ActualizaFilaDeListaTransporte(int rowIndex,Transportes t)
        {
            if (rowIndex < 0
              || rowIndex > MainWindowView.grdListaTransporte.Rows.Count)
            {
                throw new System.ArgumentOutOfRangeException(
                            "fila fuera de rango: " + nameof(rowIndex));
            }

            DataGridViewRow row = MainWindowView.grdListaTransporte.Rows[rowIndex];
            row.Cells[ColNum].Value = (rowIndex + 1).ToString().PadLeft(4, ' ');
            row.Cells[IdTransporte].Value = t.IdTransporte;
            row.Cells[Clien].Value = t.Cliente.Nombre;
            row.Cells[FechaDeContratación].Value = t.FechaContratacion;
            row.Cells[KilómetrosRecorridos].Value = t.KmRecorridos;
            row.Cells[FechaDeSalida].Value = t.FechaSalida;
            row.Cells[FechaDeEntrega].Value = t.FechaEntrega;
            row.Cells[ImportePorDia].Value = t.ImportePorDia;
            row.Cells[ImportePorKilometro].Value = t.ImportePorKilometro;
            row.Cells[IVAAplicado].Value = t.IvaAplicado;
           
        }

        private void ActualizaListaCliente(List<Cliente> clientes)
        {
            int numClientes = clientes.Count;

            int i = 0;
            foreach (Cliente t in clientes)
            {
                if (MainWindowView.grdListaCliente.Rows.Count <= i)
                {
                    MainWindowView.grdListaCliente.Rows.Add();
                }

                this.ActualizaFilaDeListaCliente(i, t);
                i++;
            }
            int numExtra = MainWindowView.grdListaCliente.Rows.Count - numClientes;
            for (; numExtra > 0; --numExtra)
            {
                MainWindowView.grdListaCliente.Rows.RemoveAt(numClientes);
            }
        }

        private void ActualizaFilaDeListaCliente(int rowIndex, Cliente c)
        {
            if (rowIndex < 0
              || rowIndex > MainWindowView.grdListaCliente.Rows.Count)
            {
                throw new System.ArgumentOutOfRangeException(
                            "fila fuera de rango: " + nameof(rowIndex));
            }

            DataGridViewRow row = MainWindowView.grdListaCliente.Rows[rowIndex];
            row.Cells[ColNum].Value = (rowIndex + 1).ToString().PadLeft(4, ' ');
            row.Cells[Nif].Value = c.Nif;
            row.Cells[Nombre].Value = c.Nombre;
            row.Cells[Telefono].Value = c.Telefono;
            row.Cells[Email].Value = c.Email;
            row.Cells[DireccionPostal].Value = c.DireccionPostal;
        }

        private void ActualizaListaFlota(List<Flota> flotas)
        {
            int numFlotas = flotas.Count;

            int i = 0;
            foreach(Flota f in flotas)
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

            StringBuilder comodidades = new StringBuilder();
            foreach (String aux in f.Comodidades)
            {
                comodidades.Append(aux + " ");
            }
            row.Cells[Comodidades].Value = comodidades.ToString();
        }
        /** ************ **/
        /** FIN BÚSQUEDA **/
        /** ************ **/

        /** ******** **/
        /** GRÁFICOS **/
        /** ******** **/
       
        //Diálogos//
        private void ActividadGeneral()
        {
            this.dialogoGraficoGeneral.ShowDialog();
        }
        private void ActividadCliente()
        {
            this.dialogoGraficoCliente.ShowDialog();
        }
        private void ActividadCamion()
        {
            this.dialogoGraficoCamion.ShowDialog();
        }
        private void ActividadComodidades()
        {
            this.dialogoGraficoComodidades.ShowDialog();
        }

        /* Métodos de gráficos */
            //Métodos comunes//
        private int busquedaGeneralMesesGrafico(List<Transportes> data, int mes)
        {
            var dataList = new List<Transportes>(
                from transporte in data
                where (transporte.FechaContratacion.Month == mes)
                orderby transporte.FechaEntrega
                select transporte);

            return dataList.Count;
        }
        private int BusquedaGeneralAnualGrafico(int anho)
        {
            var dataList = new List<Transportes>(
                from transporte in transportes
                where (transporte.FechaContratacion.Year == anho)
                orderby transporte.FechaEntrega
                select transporte);

            return dataList.Count;
        }
            //Metodos especificos general//
        private int[] valuesChartAnual(List<Transportes> data)
        {
            int[] values = new int[12];
            for (int i = 1; i <= 12; i++)
            {
                values[i - 1] = busquedaGeneralMesesGrafico(data, i);
            }
            return values;
        }
        private int[] valuesChartTotal(IEnumerable<int> data)
        {
            int[] values = new int[data.Count()];
            int i = 0;
            foreach(int x in data)
            {
                values[i] = BusquedaGeneralAnualGrafico(x);
                i++;
            }
            return values;
        }
            //Metodos especificos cliente//
        private int[] valuesChartTotalCliente(IEnumerable<int> data, string nif)
        {
            int[] values = new int[data.Count()];
            int i = 0;
            foreach (int x in data)
            {
                values[i] = BusquedaClienteAnualGrafico(x, nif);
                i++;
            }
            return values;
        }
        private int BusquedaClienteAnualGrafico(int anho, string nif)
        {
            var dataList = new List<Transportes>(
                from transporte in transportes
                where (transporte.FechaContratacion.Year == anho) && (transporte.Cliente.Nif.Equals(nif))
                orderby transporte.FechaEntrega
                select transporte);

            return dataList.Count;
        }
            //Métodos especificos camion//
        private int[] valuesChartTotalCamion(IEnumerable<int> data, string matricula)
        {
            int[] values = new int[data.Count()];
            int i = 0;
            foreach (int x in data)
            {
                values[i] = BusquedaCamionAnualGrafico(x, matricula);
                i++;
            }
            return values;
        }
        private int BusquedaCamionAnualGrafico(int anho, string matricula)
        {
            var dataList = new List<Transportes>(
                from transporte in transportes
                where (transporte.FechaContratacion.Year == anho) &&
                        (matricula.Substring(0, 3).Equals(transporte.IdTransporte.Substring(4, 3)) &&
                        matricula.Substring(3, 4).Equals(transporte.IdTransporte.Substring(0, 4)))
                orderby transporte.FechaEntrega
                select transporte);

            return dataList.Count;
        }
            //Metodos especificos comodidades//
        private int busquedaComodidadesMesesGrafico(List<Flota> data, int mes)
        {
            var dataList = new List<Flota>(
                from flota in data
                where (flota.FechaAdquisicion.Month == mes)
                orderby flota.Modelo
                select flota);

            return dataList.Count;
        }
        private int BusquedaComodidadesAnualGrafico(int anho, string comodidad)
        {
            var dataList = new List<Flota>(
                 from flota in flotas
                 where (flota.FechaAdquisicion.Year == anho) && (flota.Comodidades.Contains(comodidad))
                 orderby flota.Modelo
                 select flota);

            return dataList.Count;
        }
        private int[] valuesChartAnualComodidades(List<Flota> data)
        {
            int[] values = new int[12];
            for (int i = 1; i <= 12; i++)
            {
                values[i - 1] = busquedaComodidadesMesesGrafico(data, i);
            }
            return values;
        }
        private int[] valuesChartTotalComodidades(IEnumerable<int> data, string comodidad)
        {
            int[] values = new int[data.Count()];
            int i = 0;
            foreach (int x in data)
            {
                values[i] = BusquedaComodidadesAnualGrafico(x, comodidad);
                i++;
            }
            return values;
        }
        /* Fin de métodos de gráficos */

        //Gráfico general
        private void ActividadGeneralAnual()
        {

            var anhoSeleccionado = this.dialogoGraficoGeneral.Anho;
            if (anhoSeleccionado.Equals(""))
            {
                ActividadGeneralTotal();
            }
            else
            {
                var dataList = new List<Transportes>(
                from transporte in transportes
                where (transporte.FechaEntrega.Year.ToString().Equals(anhoSeleccionado))
                orderby transporte.FechaEntrega
                select transporte);

                this.MainWindowView.Height = 0;

                if (dataList.Count() != 0)
                {
                    MainWindowView.panelPrincipal.Controls.Remove(MainWindowView.panelLista);
                    MainWindowView.BuildPanelGraficoGeneral();
                    MainWindowView.setDataChart("Mes", "Nº transportes", valuesChartAnual(dataList));
                    MainWindowView.setDataLegend(emptyValue);
                    MainWindowView.Chart.Draw();
                    MainWindowView.panelLista = MainWindowView.panelGraficoGeneral;
                    MainWindowView.panelPrincipal.Controls.Add(MainWindowView.panelLista);
                    this.MainWindowView.Width = MainWindowView.Chart.Size.Width;
                    this.MainWindowView.Height = MainWindowView.Chart.Size.Height + 220;
                }
                else
                {
                    MainWindowView.panelPrincipal.Controls.Remove(MainWindowView.panelLista);
                    this.MainWindowView.Width = 200;
                    this.MainWindowView.Height = 200;
                }
            }
        }
        private void ActividadGeneralTotal()
        {
            IEnumerable<int> data = from transporte in transportes
                orderby transporte.FechaEntrega
                select transporte.FechaEntrega.Year;

            var distinctData = data.Select(x => x).Distinct();
            string[] toLegend = new string[distinctData.Count()];
            int i = 0;
            foreach(int t in distinctData)
            {
                toLegend[i] = Convert.ToString(t);
                i++;
            }

            this.MainWindowView.Height = 0;

            if (data.Count() != 0)
            {
                MainWindowView.panelPrincipal.Controls.Remove(MainWindowView.panelLista);
                MainWindowView.BuildPanelGraficoGeneral();
                MainWindowView.setDataChart("Año", "Nº transportes", valuesChartTotal(distinctData));
                MainWindowView.setDataLegend(toLegend);
                MainWindowView.Chart.Draw();
                MainWindowView.panelLista = MainWindowView.panelGraficoGeneral;
                MainWindowView.panelPrincipal.Controls.Add(MainWindowView.panelLista);
                this.MainWindowView.Width = MainWindowView.Chart.Size.Width;
                this.MainWindowView.Height = MainWindowView.Chart.Size.Height + 220;
            }
            else
            {
                MainWindowView.panelPrincipal.Controls.Remove(MainWindowView.panelLista);
                this.MainWindowView.Width = 200;
                this.MainWindowView.Height = 200;
            }
        }
        //Fin grafico general

        //Grafico cliente
        private void ActividadClienteAnual()
        {
            var anhoSeleccionado = this.dialogoGraficoCliente.Anho;
            var nifClienteSeleccionado = this.dialogoGraficoCliente.Cliente;
            if (anhoSeleccionado.Equals(""))
            {
                ActividadClienteTotal();
            }
            else
            {
                var data = new List<Transportes>(
                from transporte in transportes
                where transporte.Cliente.Nif.Equals(nifClienteSeleccionado) && (transporte.FechaEntrega.Year.ToString().Equals(anhoSeleccionado))
                orderby transporte.IdTransporte
                select transporte);

                this.MainWindowView.Height = 0;

                if (data.Count() != 0)
                {
                    MainWindowView.panelPrincipal.Controls.Remove(MainWindowView.panelLista);
                    MainWindowView.BuildPanelGraficoGeneral();
                    MainWindowView.setDataChart("Mes", "Nº transportes", valuesChartAnual(data));
                    MainWindowView.setDataLegend(emptyValue);
                    MainWindowView.Chart.Draw();
                    MainWindowView.panelLista = MainWindowView.panelGraficoGeneral;
                    MainWindowView.panelPrincipal.Controls.Add(MainWindowView.panelLista);
                    this.MainWindowView.Width = MainWindowView.Chart.Size.Width;
                    this.MainWindowView.Height = MainWindowView.Chart.Size.Height + 220;
                }
                else
                {
                    MainWindowView.panelPrincipal.Controls.Remove(MainWindowView.panelLista);
                    this.MainWindowView.Width = 200;
                    this.MainWindowView.Height = 200;
                }
            }
        }
        private void ActividadClienteTotal()
        {
            var nifClienteSeleccionado = this.dialogoGraficoCliente.Cliente;
            IEnumerable<int> data = from transporte in transportes
                                    where transporte.Cliente.Nif.Equals(nifClienteSeleccionado)
                                    orderby transporte.FechaEntrega
                                    select transporte.FechaEntrega.Year;

            var distinctData = data.Select(x => x).Distinct();
            string[] toLegend = new string[distinctData.Count()];
            int i = 0;
            foreach (int t in distinctData)
            {
                toLegend[i] = Convert.ToString(t);
                i++;
            }

            this.MainWindowView.Height = 0;

            if (data.Count() != 0)
            {
                MainWindowView.panelPrincipal.Controls.Remove(MainWindowView.panelLista);
                MainWindowView.BuildPanelGraficoGeneral();
                MainWindowView.setDataChart("Año", "Nº transportes", valuesChartTotalCliente(distinctData, nifClienteSeleccionado));
                MainWindowView.setDataLegend(toLegend);
                MainWindowView.Chart.Draw();
                MainWindowView.panelLista = MainWindowView.panelGraficoGeneral;
                MainWindowView.panelPrincipal.Controls.Add(MainWindowView.panelLista);
                this.MainWindowView.Width = MainWindowView.Chart.Size.Width;
                this.MainWindowView.Height = MainWindowView.Chart.Size.Height + 220;
            }
            else
            {
                MainWindowView.panelPrincipal.Controls.Remove(MainWindowView.panelLista);
                this.MainWindowView.Width = 200;
                this.MainWindowView.Height = 200;
            }
        }
        //Fin grafico cliente

        //Grafico actividad camion
        private void ActividadCamionAnual()
        {
            var anhoSeleccionado = this.dialogoGraficoCamion.Anho;
            var matriculaCamionSeleccionado = this.dialogoGraficoCamion.Matricula;
            if (anhoSeleccionado.Equals(""))
            {
                ActividadCamionTotal();
            }
            else
            {
                var data = new List<Transportes>(
                from transporte in transportes
                where (matriculaCamionSeleccionado.Substring(0, 3).Equals(transporte.IdTransporte.Substring(4, 3)) &&
                        matriculaCamionSeleccionado.Substring(3, 4).Equals(transporte.IdTransporte.Substring(0, 4))) &&
                        (transporte.FechaEntrega.Year.ToString().Equals(anhoSeleccionado))
                orderby transporte.IdTransporte
                select transporte);

                this.MainWindowView.Height = 0;

                if (data.Count() != 0)
                {
                    MainWindowView.panelPrincipal.Controls.Remove(MainWindowView.panelLista);
                    MainWindowView.BuildPanelGraficoGeneral();
                    MainWindowView.setDataChart("Mes", "Nº transportes", valuesChartAnual(data));
                    MainWindowView.setDataLegend(emptyValue);
                    MainWindowView.Chart.Draw();
                    MainWindowView.panelLista = MainWindowView.panelGraficoGeneral;
                    MainWindowView.panelPrincipal.Controls.Add(MainWindowView.panelLista);
                    this.MainWindowView.Width = MainWindowView.Chart.Size.Width;
                    this.MainWindowView.Height = MainWindowView.Chart.Size.Height + 220;
                }
                else
                {
                    MainWindowView.panelPrincipal.Controls.Remove(MainWindowView.panelLista);
                    this.MainWindowView.Width = 200;
                    this.MainWindowView.Height = 200;
                }
            }
        }
        private void ActividadCamionTotal()
        {
            var matriculaCamionSeleccionado = this.dialogoGraficoCamion.Matricula;
            IEnumerable<int> data = from transporte in transportes
                                    where (matriculaCamionSeleccionado.Substring(0, 3).Equals(transporte.IdTransporte.Substring(4, 3)) &&
                                            matriculaCamionSeleccionado.Substring(3, 4).Equals(transporte.IdTransporte.Substring(0, 4)))
                                    orderby transporte.FechaEntrega
                                    select transporte.FechaEntrega.Year;

            var distinctData = data.Select(x => x).Distinct();
            string[] toLegend = new string[distinctData.Count()];
            int i = 0;
            foreach (int t in distinctData)
            {
                toLegend[i] = Convert.ToString(t);
                i++;
            }

            this.MainWindowView.Height = 0;

            if (data.Count() != 0)
            {
                MainWindowView.panelPrincipal.Controls.Remove(MainWindowView.panelLista);
                MainWindowView.BuildPanelGraficoGeneral();
                MainWindowView.setDataChart("Año", "Nº transportes", valuesChartTotalCamion(distinctData, matriculaCamionSeleccionado));
                MainWindowView.setDataLegend(toLegend);
                MainWindowView.Chart.Draw();
                MainWindowView.panelLista = MainWindowView.panelGraficoGeneral;
                MainWindowView.panelPrincipal.Controls.Add(MainWindowView.panelLista);
                this.MainWindowView.Width = MainWindowView.Chart.Size.Width;
                this.MainWindowView.Height = MainWindowView.Chart.Size.Height + 220;
            }
            else
            {
                MainWindowView.panelPrincipal.Controls.Remove(MainWindowView.panelLista);
                this.MainWindowView.Width = 200;
                this.MainWindowView.Height = 200;
            }
        }
        //Fin grafico actividad camion

        //Grafico comodidades camion
        private void FlotaComodidadesAnual()
        {
            var anhoSeleccionado = this.dialogoGraficoComodidades.Anho;
            var comodidadSeleccionada = this.dialogoGraficoComodidades.Comodidad;
            if (anhoSeleccionado.Equals(""))
            {
                FlotaComodidadesTotal();
            }
            else
            {
                var data = new List<Flota>(
                from flota in flotas
                where (flota.Comodidades.Contains(comodidadSeleccionada)) &&
                (flota.FechaAdquisicion.Year.ToString().Equals(anhoSeleccionado))
                orderby flota.FechaAdquisicion
                select flota);

                this.MainWindowView.Height = 0;

                if (data.Count() != 0)
                {
                    MainWindowView.panelPrincipal.Controls.Remove(MainWindowView.panelLista);
                    MainWindowView.BuildPanelGraficoGeneral();
                    MainWindowView.setDataChart("Mes", "Nº camiones", valuesChartAnualComodidades(data));
                    MainWindowView.setDataLegend(emptyValue);
                    MainWindowView.Chart.Draw();
                    MainWindowView.panelLista = MainWindowView.panelGraficoGeneral;
                    MainWindowView.panelPrincipal.Controls.Add(MainWindowView.panelLista);
                    this.MainWindowView.Width = MainWindowView.Chart.Size.Width;
                    this.MainWindowView.Height = MainWindowView.Chart.Size.Height + 220;
                }
                else
                {
                    MainWindowView.panelPrincipal.Controls.Remove(MainWindowView.panelLista);
                    this.MainWindowView.Width = 200;
                    this.MainWindowView.Height = 200;
                }
            }
        }
        private void FlotaComodidadesTotal()
        {
            var comodidadSeleccionada = this.dialogoGraficoComodidades.Comodidad;
            IEnumerable<int> data = from flota in flotas
                                    where (flota.Comodidades.Contains(comodidadSeleccionada))
                                    orderby flota.FechaAdquisicion
                                    select flota.FechaAdquisicion.Year;

            var distinctData = data.Select(x => x).Distinct();
            string[] toLegend = new string[distinctData.Count()];
            int i = 0;
            foreach (int t in distinctData)
            {
                toLegend[i] = Convert.ToString(t);
                i++;
            }

            this.MainWindowView.Height = 0;

            if (data.Count() != 0)
            {
                MainWindowView.panelPrincipal.Controls.Remove(MainWindowView.panelLista);
                MainWindowView.BuildPanelGraficoGeneral();
                MainWindowView.setDataChart("Año", "Nº camiones", valuesChartTotalComodidades(distinctData, comodidadSeleccionada));
                MainWindowView.setDataLegend(toLegend);
                MainWindowView.Chart.Draw();
                MainWindowView.panelLista = MainWindowView.panelGraficoGeneral;
                MainWindowView.panelPrincipal.Controls.Add(MainWindowView.panelLista);
                this.MainWindowView.Width = MainWindowView.Chart.Size.Width;
                this.MainWindowView.Height = MainWindowView.Chart.Size.Height + 220;
            }
            else
            {
                MainWindowView.panelPrincipal.Controls.Remove(MainWindowView.panelLista);
                this.MainWindowView.Width = 200;
                this.MainWindowView.Height = 200;
            }
        }
        //Fin grafico comodidades camion

        //Operacion salir
        private void Salir()
        {
            Application.Exit();
        }

        /** ************ **/
        /** FIN GRÁFICOS **/
        /** ************ **/


        /** ********* **/
        /** ATRIBUTOS **/
        /** ********* **/

        public MainWindowView MainWindowView { get; private set; }
        //Objetos//
        public static List<Transportes> transportes;
        public static List<Flota> flotas;
        public static List<Cliente> clientes;
        //Dialogos//
        public DialogoTransportesPendientes dialogoTransportesPendientes { get; private set; } //Busquedas
        public DialogoDniCliente dialogoDni { get; private set; } //Busquedas
        public DialogoCamiones dialogoCamion { get; private set; } //Busquedas
        public DialogoTransporteCliente dialogoTransporteCliente { get; private set; } //Busquedas
        public DialogoReservasCamion dialogoReservasCamion { get; private set; } //Busquedas
        public DialogoOcupacion dialogoOcupacion { get; private set; } //Busquedas
			public DialogoGraficoGeneral dialogoGraficoGeneral { get; private set; } //Graficos
			public DialogoGraficoCliente dialogoGraficoCliente { get; private set; } //Graficos
			public DialogoGraficoCamion dialogoGraficoCamion { get; private set; } //Graficos
			public DialogoGraficoComodidades dialogoGraficoComodidades { get; private set; } //Graficos

        //Constantes + valores
        public static string[] emptyValue = new string[12] { "Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic" };
        public const int ColNum = 0;

        public const int IdTransporte = 1;
        public const int Clien = 2;
        public const int FechaDeContratación = 3;
        public const int KilómetrosRecorridos = 4;
        public const int FechaDeSalida = 5;
        public const int FechaDeEntrega = 6;
        public const int ImportePorDia = 7;
        public const int ImportePorKilometro = 8;
        public const int IVAAplicado = 9;

        public const int Nif = 1;
        public const int Nombre = 2;
        public const int Telefono = 3;
        public const int Email = 4;
        public const int DireccionPostal = 5;

        public const int Matricula = 1;
        public const int Tipo = 2;
        public const int Marca = 3;
        public const int Modelo = 4;
        public const int ConsumoKm = 5;
        public const int FechaAdquisicion = 6;
        public const int FechaFabricacion = 7;
        public const int Comodidades = 8;
        
        /** ************* **/
        /** FIN ATRIBUTOS **/
        /** ************* **/

    }
        
}
