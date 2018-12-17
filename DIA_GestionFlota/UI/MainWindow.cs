namespace GestionFlota
{
    using System;
    using System.Windows.Forms;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;
    using GestionFlota.Core;
    using GestionFlota.UI;
    using System.Text.RegularExpressions;


    class MainWindow : Form
    {
        /*------------------------------------------------------------------*/
        /*-------------------------Constructor------------------------------*/
        /*------------------------------------------------------------------*/
        public MainWindow()
        {
            Reg = new Registro();
            Reg.RecuperaXml();
            RegClientes = Reg.GetClientes();
            RegReservas = Reg.GetReservas();
            flotas = Reg.GetFlotas();

            /*----------------------------*/
            /*-INSERTS PARA EL PRIMER XML-*/
            /*----------------------------///Si pones asterisco antes de estas 3 barras se descomenta
            List<string> a = new List<string>();
          
            Flota flota1 = new Flota(1.5, "AAA1111", "Furgoneta", "Vendo", "Deluxe", 23.0, new DateTime(2000, 08, 12),
                new DateTime(1999, 10, 11), a);
            Flota flota2 = new Flota(1, "AAA2222", "Camion", "Opel", "Deluxe Plus", 23.0, new DateTime(2000, 11, 12),
                new DateTime(1999, 10, 11), a);
            Flota flota3 = new Flota(1.5, "AAA3333", "Furgoneta", "Corsa", "Deluxe Plus Plus", 23.0, new DateTime(2000, 11, 12),
                new DateTime(1999, 10, 11), a);
            Flota flota4 = new Flota(1.5, "AAA4444", "Camion", "Barato", "Deluxe++", 23.0, new DateTime(2001, 12, 12),
                new DateTime(1999, 10, 11), a);
            Flota flota5 = new Flota(1.5, "AAA5555", "Furgoneta", "Muy barato", "Deluxe--", 23.0, new DateTime(2012, 08, 12),
                new DateTime(1999, 10, 11), a);
            flotas.Add(flota1);
            flotas.Add(flota2);
            flotas.Add(flota3);
            flotas.Add(flota4);
            flotas.Add(flota5);

            Cliente cliente1 = new Cliente("15494356S", "Alfonso", "988769765", "cliente1@gmail.com", "35987");
            Cliente cliente2 = new Cliente("25422356G", "Sofia", "988749765", "cliente2@gmail.com", "35987");
            Cliente cliente3 = new Cliente("35433356D", "Mario", "988759765", "cliente3@gmail.com", "35987");
            Cliente cliente4 = new Cliente("45444356E", "Baltasar", "938769765", "cliente4@gmail.com", "35987");
            Cliente cliente5 = new Cliente("55455356F", "Miguel", "988269765", "cliente5@gmail.com", "35987");
            Cliente cliente6 = new Cliente("65466356I", "Fernando", "989769765", "cliente6@gmail.com", "35987");
            Cliente cliente7 = new Cliente("75477356L", "Juan", "981269765", "cliente7@gmail.com", "35987");
            Cliente cliente8 = new Cliente("85488356P", "Jimeno", "981169765", "cliente8@gmail.com", "35987");
            RegClientes.Add(cliente1);
            RegClientes.Add(cliente2);
            RegClientes.Add(cliente3);
            RegClientes.Add(cliente4);
            RegClientes.Add(cliente5);
            RegClientes.Add(cliente6);
            RegClientes.Add(cliente7);
            RegClientes.Add(cliente8);
           
            Reservas transportes1 = new Reservas("1111AAA20171106", cliente1, flota1, new DateTime(2017, 11, 06), new DateTime(2017, 11, 07), new DateTime(2017, 12, 01),
                                            23.2, 54.6, 30000.6, 0.21, 90.6, 22.0);
            Reservas transportes2 = new Reservas("1111AAA20171106", cliente1, flota1, new DateTime(2017, 11, 06), new DateTime(2017, 11, 07), new DateTime(2017, 12, 01),
                                            23.2, 54.6, 3550.6, 0.21, 90.6, 22.0);
            Reservas transportes3 = new Reservas("2222AAA20171106", cliente1, flota2, new DateTime(2017, 11, 06), new DateTime(2017, 11, 07), new DateTime(2017, 12, 02),
                                            23.2, 54.6, 330.6, 0.21, 90.6, 22.0);
            Reservas transportes4 = new Reservas("2222AAA20171106", cliente1, flota2, new DateTime(2017, 11, 06), new DateTime(2017, 11, 07), new DateTime(2017, 12, 02),
                                            23.2, 54.6, 310.6, 0.21, 90.6, 22.0);
            Reservas transportes5 = new Reservas("3333AAA20140406", cliente2, flota3, new DateTime(2014, 04, 06), new DateTime(2014, 06, 01), new DateTime(2014, 07, 01),
                                            24.2, 54.6, 3205.6, 0.21, 90.6, 22.0);
            Reservas transportes6 = new Reservas("3333AAA20140306", cliente2, flota3, new DateTime(2014, 03, 06), new DateTime(2014, 06, 01), new DateTime(2014, 07, 01),
                                            24.2, 54.6, 30055.6, 0.21, 90.6, 22.0);
            Reservas transportes7 = new Reservas("4444AAA20150206", cliente3, flota4, new DateTime(2015, 02, 06), new DateTime(2015, 11, 06), new DateTime(2015, 11, 07),
                                            24.2, 54.6, 300.6, 0.21, 90.6, 22.0);
            Reservas transportes8 = new Reservas("5555AAA20160606", cliente4, flota5, new DateTime(2016, 06, 06), new DateTime(2016, 11, 06), new DateTime(2016, 11, 07),
                                            24.2, 54.6, 30023.6, 0.21, 90.6, 22.0);
            Reservas transportes9 = new Reservas("5555AAA20160806", cliente5, flota5, new DateTime(2016, 08, 06), new DateTime(2016, 09, 06), new DateTime(2017, 09, 06),
                                            21.2, 54.6, 300111.6, 0.21, 90.6, 22);
            Reservas transportes10 = new Reservas("5555AAA20160806", cliente5, flota5, new DateTime(2016, 08, 06), new DateTime(2016, 12, 06), new DateTime(2016, 12, 13),
                                            21.2, 54.6, 30042.6, 0.21, 90.6, 22.0);
            Reservas transportes11 = new Reservas("1111AAA20170806", cliente6, flota1, new DateTime(2017, 08, 06), new DateTime(2017, 11, 06), new DateTime(2017, 11, 10),
                                            23.54, 54.6, 30054.6, 0.21, 90.6, 22.0);
            Reservas transportes12 = new Reservas("2222AAA20170806", cliente7, flota2, new DateTime(2017, 08, 06), new DateTime(2017, 11, 06), new DateTime(2019, 1, 10),
                                            23.22, 54.6, 30220.6, 0.21, 90.6, 22.0);
            Reservas transportes13 = new Reservas("3333AAA20170906", cliente8, flota3, new DateTime(2017, 09, 06), new DateTime(2017, 11, 06), new DateTime(2018, 12, 31),
                                            21.22, 54.6, 301230.6, 0.21, 90.6, 22.0);
            RegReservas.Add(transportes1);
            RegReservas.Add(transportes2);
            RegReservas.Add(transportes3);
            RegReservas.Add(transportes4);
            RegReservas.Add(transportes5);
            RegReservas.Add(transportes6);
            RegReservas.Add(transportes7);
            RegReservas.Add(transportes8);
            RegReservas.Add(transportes9);
            RegReservas.Add(transportes10);
            RegReservas.Add(transportes11);
            RegReservas.Add(transportes12);
            RegReservas.Add(transportes13);
            /*----------------------------*/
            /*-INSERTS PARA EL PRIMER XML-*/
            /*----------------------------*/


            this.MainWindowViewReservas = new MainWindowViewReservas();

            MainWindowViewReservas.grdEventsListAux = MainWindowViewReservas.grdEventsListReservas;
            this.mostrarTodosLosTransportes();

            this.MainWindowViewReservas.FormClosed += (sender, e) => this.Salir();
            this.MainWindowViewReservas.operacionSalir.Click += (sender, e) => this.Salir();
            this.MainWindowViewReservas.menuAtras.Click += (sender, e) => this.mostrarTodosLosTransportes();

           //this.mostrarTodosLosTransportes();
          
            //--Operaciones búsqueda--//
            //Opciones de la MainWindowView
            this.MainWindowViewReservas.operacionSearch1.Click += (sender, e) => this.transportePendientes();
            this.MainWindowViewReservas.operacionSearch2.Click += (sender, e) => this.disponibilidad();
            this.MainWindowViewReservas.operacionSearch3.Click += (sender, e) => this.transportesPorCliente();
            this.MainWindowViewReservas.operacionSearch4.Click += (sender, e) => this.reservasPorCamion();
            this.MainWindowViewReservas.operacionSearch5.Click += (sender, e) => this.reservasPorCliente();
            this.MainWindowViewReservas.operacionSearch6.Click += (sender, e) => this.ocupacion();
            this.MainWindowViewReservas.operacionSearch7.Click += (sender, e) => this.comodidades();

            //Dialogos
            this.MainWindowViewReservas.btSearchCamiones.Click += (sender, e) => this.DTPSearch(); //TransportesPendientes
            this.MainWindowViewReservas.btSearchDisponibilidad.Click += (sender, e) => this.DDCSearch(); //Disponibilidad
            this.MainWindowViewReservas.btSearchTransporteCliente.Click += (sender, e) => this.DTCSearch();//Transporte cliente
            this.MainWindowViewReservas.operacionGraficoCliente.Click += (sender, e) => this.DTCSearchGraph();//Transporte cliente grafico
            this.MainWindowViewReservas.btSearchCamiones2.Click += (sender, e) => this.DRCSearch();// Reservas camion
            this.MainWindowViewReservas.operacionGraficoCamion.Click += (sender, e) => this.DRCSearchGraph();// Reservas camion grafico
            this.MainWindowViewReservas.btSearchCliente4.Click += (sender, e) => this.RPCSearch();//Reservas por cliente
            this.MainWindowViewReservas.operacionGraficoCliente2.Click += (sender, e) => this.RPCSearchGraph();//Reservas por cliente grafico
            this.MainWindowViewReservas.btSearchOcupacionAnho5.Click += (sender, e) => this.OASearch();//Ocupacion
            this.MainWindowViewReservas.calendar.DateSelected += new DateRangeEventHandler(MainWindowViewReservas.OnSelected);
            this.MainWindowViewReservas.calendar.DateSelected += (sender, e) => this.OFSearch();//Ocupacion
           

            this.MainWindowViewReservas.btSearchComodidad.Click += (sender, e) => this.CCSearch();//Comodidades
            this.MainWindowViewReservas.operacionGraficoComodidades.Click += (sender, e) => this.CCSearchGraph();//Comodidades grafico

            //Cliente
            this.MainWindowViewReservas.CreateCliente.Click += (sender, e) => this.AddClient();
            this.MainWindowViewReservas.RemoveCliente.Click += (sender, e) => this.RemoveClient();
            this.MainWindowViewReservas.EditFindCliente.Click += (sender, e) => this.EditFindClient();
            this.MainWindowViewReservas.EditCliente.Click += (sender, e) => this.EditClient();
            this.MainWindowViewReservas.operacionGestionarClientes.Click += (sender, e) => this.ActividadGestionClientes();

            this.MainWindowViewReservas.btGestionClientes.Click += (sender, e) => {
                MainWindowViewReservas.dialogosGrande.Controls.Remove(MainWindowViewReservas.dialogos);
                MainWindowViewReservas.dialogos = MainWindowViewReservas.BoxAddClientes;
                MainWindowViewReservas.dialogosGrande.Controls.Add(MainWindowViewReservas.dialogos);
                MainWindowViewReservas.dialogosGrande.Height = MainWindowViewReservas.BoxAddClientes.Height;
                MainWindowViewReservas.BoxAddClientes.Width = 390;

            };

            //Reservas
            this.MainWindowViewReservas.CreateReserva.Click += (sender, e) => this.Crear();
            this.MainWindowViewReservas.RemoveReserva.Click += (sender, e) => this.RemoveReserv();
            this.MainWindowViewReservas.EditFindReserva.Click += (sender, e) => this.EditFindReserv();
            this.MainWindowViewReservas.EditReserva.Click += (sender, e) => this.EditReserv();
            this.MainWindowViewReservas.operacionGestionarReservas.Click += (sender, e) => this.ActividadGestionReservas();

            this.MainWindowViewReservas.btGestionReservas.Click += (sender, e) => {
                MainWindowViewReservas.dialogosGrande.Controls.Remove(MainWindowViewReservas.dialogos);
                MainWindowViewReservas.dialogos = MainWindowViewReservas.BoxAddReservas;
                MainWindowViewReservas.dialogosGrande.Controls.Add(MainWindowViewReservas.dialogos);
                MainWindowViewReservas.dialogosGrande.Height = MainWindowViewReservas.BoxAddReservas.Height;
                MainWindowViewReservas.BoxAddReservas.Width = 390;
            };

            //Flota
            this.MainWindowViewReservas.btAñadir.Click += (sender, e) => this.insertFlota();
            this.MainWindowViewReservas.DeleteFlota.Click += (sender, e) => this.deleteFlota();
            this.MainWindowViewReservas.EditFindFlota.Click += (sender, e) => this.EditFindFlota();
            this.MainWindowViewReservas.btModificar.Click += (sender, e) => this.modFlota();
            this.MainWindowViewReservas.operacionGestionarFlota.Click += (sender, e) => this.ActividadGestionFlota();

            this.MainWindowViewReservas.AnhadirFlota.Click += (sender, e) => {
               
                MainWindowViewReservas.dialogosGrande.Controls.Remove(MainWindowViewReservas.dialogos);
                MainWindowViewReservas.dialogos = MainWindowViewReservas.panelAnhadir;
                MainWindowViewReservas.dialogosGrande.Controls.Add(MainWindowViewReservas.dialogos);
                MainWindowViewReservas.dialogosGrande.Height = MainWindowViewReservas.panelAnhadir.Height;
                MainWindowViewReservas.dialogos.Width = 350;

                cleanFlotaAdd();
            };


            this.MainWindowViewReservas.grdEventsListReservas.CellMouseClick += (sender, e) =>
            {
                if(this.MainWindowViewReservas.grdEventsListReservas.CurrentCell.ColumnIndex == 0)
                {

                    Reservas r = RegReservas[this.MainWindowViewReservas.grdEventsListReservas.CurrentRow.Index];

                    MainWindowViewReservas.grdEventsList.Controls.Remove(MainWindowViewReservas.grdEventsListAux);
                    MainWindowViewReservas.grdEventsListAux = MainWindowViewReservas.grdEventsListFlota;
                    MainWindowViewReservas.grdEventsList.Controls.Add(MainWindowViewReservas.grdEventsListAux);
                    MainWindowViewReservas.grdEventsList.Height = MainWindowViewReservas.grdEventsListFlota.Height;
                    MainWindowViewReservas.grdEventsList.Width = MainWindowViewReservas.Width - 410;

                    MainWindowViewReservas.opcionesFijo.Controls.Remove(MainWindowViewReservas.opcionesPoner);
                    MainWindowViewReservas.opcionesPoner = MainWindowViewReservas.buildPanelOpcionesFlota();
                    MainWindowViewReservas.opcionesFijo.Controls.Add(MainWindowViewReservas.opcionesPoner);

                    MainWindowViewReservas.dialogosGrande.Controls.Remove(MainWindowViewReservas.dialogos);
                    MainWindowViewReservas.dialogos = null;
                    MainWindowViewReservas.dialogosGrande.Controls.Add(MainWindowViewReservas.dialogos);

                    string matricula =  String.Concat(r.IdTransporte.Substring(4, 3), r.IdTransporte.Substring(0, 4));


                    RegFlotasBusqueda = new List<Flota>(
                        from flota in flotas
                        where flota.Matricula == matricula
                        select flota);

                    ActualizarListaFlotaBusqueda(RegFlotasBusqueda);
                }

                if(this.MainWindowViewReservas.grdEventsListReservas.CurrentCell.ColumnIndex == 1)
                {
                    Reservas r = RegReservas[this.MainWindowViewReservas.grdEventsListReservas.CurrentRow.Index];

                    MainWindowViewReservas.grdEventsList.Controls.Remove(MainWindowViewReservas.grdEventsListAux);
                    MainWindowViewReservas.grdEventsListAux = MainWindowViewReservas.grdEventsListClientes;
                    MainWindowViewReservas.grdEventsList.Controls.Add(MainWindowViewReservas.grdEventsListAux);
                    MainWindowViewReservas.grdEventsList.Height = MainWindowViewReservas.grdEventsListClientes.Height;
                    MainWindowViewReservas.grdEventsList.Width = MainWindowViewReservas.Width - 410;


                    MainWindowViewReservas.opcionesFijo.Controls.Remove(MainWindowViewReservas.opcionesPoner);
                    MainWindowViewReservas.opcionesPoner = MainWindowViewReservas.buildPanelOpcionesClientes();
                    MainWindowViewReservas.opcionesFijo.Controls.Add(MainWindowViewReservas.opcionesPoner);

                    MainWindowViewReservas.dialogosGrande.Controls.Remove(MainWindowViewReservas.dialogos);
                    MainWindowViewReservas.dialogos = null;
                    MainWindowViewReservas.dialogosGrande.Controls.Add(MainWindowViewReservas.dialogos);

                    RegClientesBusqueda = new List<Cliente>(
                        from cliente in RegClientes
                        where  cliente.Nif == r.Cliente.Nif
                        select cliente);

                    ActualizarListaClientesBusqueda(RegClientesBusqueda);
                }
            };
        }
        void Salir()
        {
            Reg.GuardaXml();
            Application.Exit();
        }

        /*------------------------------------------------------------------*/
        /*--------------------------Atributos-------------------------------*/
        /*------------------------------------------------------------------*/
        public MainWindowViewReservas MainWindowViewReservas { get; private set; }
        public Registro Reg { get; }
        public static List<Flota> flotas;
        public static List<Cliente> RegClientes { get; private set; }
        public static List<Reservas> RegReservas { get; private set; }
        public Flota flota_mod { get; set; }

        //Busqueda
        public List<Reservas> RegReservasBusqueda;
        public List<Flota> RegFlotasBusqueda;
        public List<Cliente> RegClientesBusqueda;

        public static string[] emptyValue = new string[12] { "Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic" };

        /*------------------------------------------------------------------*/
        /*-------------------Gestion Flota/Cliente/Reserva------------------*/
        /*------------------------------------------------------------------*/
        private void ActividadGestionFlota()
        {
            MainWindowViewReservas.grdEventsList.Controls.Remove(MainWindowViewReservas.grdEventsListAux);
            MainWindowViewReservas.grdEventsListAux = MainWindowViewReservas.grdEventsListFlota;
            MainWindowViewReservas.grdEventsList.Controls.Add(MainWindowViewReservas.grdEventsListAux);
           // MainWindowViewReservas.grdEventsList.Height = MainWindowViewReservas.grdEventsListFlota.Height;
            MainWindowViewReservas.grdEventsList.Width = MainWindowViewReservas.Width - 410;

            MainWindowViewReservas.opcionesFijo.Controls.Remove(MainWindowViewReservas.opcionesPoner);
            MainWindowViewReservas.opcionesPoner = MainWindowViewReservas.buildPanelOpcionesFlota();
            MainWindowViewReservas.opcionesFijo.Controls.Add(MainWindowViewReservas.opcionesPoner);


            MainWindowViewReservas.dialogosGrande.Controls.Remove(MainWindowViewReservas.dialogos);
            MainWindowViewReservas.dialogos = null;
            MainWindowViewReservas.dialogosGrande.Controls.Add(MainWindowViewReservas.dialogos);

            MainWindowViewReservas.Text = "Gestion Flota";

            ClearFlota();
            ActualizaListaFlota();

        }
        private void ActividadGestionClientes()
        {
            MainWindowViewReservas.grdEventsList.Controls.Remove(MainWindowViewReservas.grdEventsListAux);
            MainWindowViewReservas.grdEventsListAux = MainWindowViewReservas.grdEventsListClientes;
            MainWindowViewReservas.grdEventsList.Controls.Add(MainWindowViewReservas.grdEventsListAux);
            MainWindowViewReservas.grdEventsList.Height = MainWindowViewReservas.grdEventsListClientes.Height;
            MainWindowViewReservas.grdEventsList.Width = MainWindowViewReservas.Width - 410;

            MainWindowViewReservas.opcionesFijo.Controls.Remove(MainWindowViewReservas.opcionesPoner);
            MainWindowViewReservas.opcionesPoner = MainWindowViewReservas.buildPanelOpcionesClientes();
            MainWindowViewReservas.opcionesFijo.Controls.Add(MainWindowViewReservas.opcionesPoner);

            MainWindowViewReservas.dialogosGrande.Controls.Remove(MainWindowViewReservas.dialogos);
            MainWindowViewReservas.dialogos = null;
            MainWindowViewReservas.dialogosGrande.Controls.Add(MainWindowViewReservas.dialogos);

            MainWindowViewReservas.Text = "Gestion Clientes";

            Clear();
            ActualizarLista();
            //MainWindowViewClientes.Show();
        }
        private void ActividadGestionReservas()
        {
            MainWindowViewReservas.grdEventsList.Controls.Remove(MainWindowViewReservas.grdEventsListAux);
            MainWindowViewReservas.grdEventsListAux = MainWindowViewReservas.grdEventsListReservas;
            MainWindowViewReservas.grdEventsList.Controls.Add(MainWindowViewReservas.grdEventsListAux);
            MainWindowViewReservas.grdEventsList.Height = MainWindowViewReservas.grdEventsListReservas.Height;
            MainWindowViewReservas.grdEventsList.Width = MainWindowViewReservas.Width - 410;

            MainWindowViewReservas.opcionesFijo.Controls.Remove(MainWindowViewReservas.opcionesPoner);
            MainWindowViewReservas.opcionesPoner = MainWindowViewReservas.buildPanelOpcionesReservas();
            MainWindowViewReservas.opcionesFijo.Controls.Add(MainWindowViewReservas.opcionesPoner);

            MainWindowViewReservas.dialogosGrande.Controls.Remove(MainWindowViewReservas.dialogos);
            MainWindowViewReservas.dialogos = null;
            MainWindowViewReservas.dialogosGrande.Controls.Add(MainWindowViewReservas.dialogos);

            MainWindowViewReservas.Text = "Gestion Reservas";

            ClearReservas();
            ActualizarListaReservas();
        }
        public void mostrarTodosLosTransportes()
        {
            MainWindowViewReservas.grdEventsList.Controls.Remove(MainWindowViewReservas.grdEventsListAux);
            MainWindowViewReservas.grdEventsListAux = MainWindowViewReservas.grdEventsListReservas;
            MainWindowViewReservas.grdEventsList.Controls.Add(MainWindowViewReservas.grdEventsListAux);
            MainWindowViewReservas.grdEventsList.Height = MainWindowViewReservas.grdEventsListReservas.Height;
            MainWindowViewReservas.grdEventsList.Width = MainWindowViewReservas.Width - 410;

            MainWindowViewReservas.opcionesFijo.Controls.Remove(MainWindowViewReservas.opcionesPoner);
            MainWindowViewReservas.opcionesPoner = MainWindowViewReservas.buildPanelOpcionesReservas();
            MainWindowViewReservas.opcionesFijo.Controls.Add(MainWindowViewReservas.opcionesPoner);


            MainWindowViewReservas.dialogosGrande.Controls.Remove(MainWindowViewReservas.dialogos);
            MainWindowViewReservas.dialogos = null;
            MainWindowViewReservas.dialogosGrande.Controls.Add(MainWindowViewReservas.dialogos);

            RegReservasBusqueda = new List<Reservas>(
            from Reservas in RegReservas
            where DateTime.Compare(Reservas.Fentrega, DateTime.Today) >= 0
            orderby Reservas.IdTransporte
            select Reservas);

            ActualizarListaReservasBusqueda();
        }

        /*------------------------------------------------------------------*/
        /*---------------------Métodos Búsquedas----------------------------*/
        /*------------------------------------------------------------------*/
        // Inicio Transportes pendientes: Mostrará todas los transportes, para todo la flota o por camión, para los próximos cinco días
        private void transportePendientes()
        {

            MainWindowViewReservas.dialogosGrande.Controls.Remove(MainWindowViewReservas.dialogos);
            MainWindowViewReservas.dialogos = MainWindowViewReservas.buildPanelTransportesPendientes();
            MainWindowViewReservas.dialogosGrande.Controls.Add(MainWindowViewReservas.dialogos);
            MainWindowViewReservas.dialogosGrande.Width = 390;

        }
        private void DTPSearch()
        {
            MainWindowViewReservas.grdEventsList.Controls.Remove(MainWindowViewReservas.grdEventsListAux);
            MainWindowViewReservas.grdEventsListAux = MainWindowViewReservas.grdEventsListReservas;
            MainWindowViewReservas.grdEventsList.Controls.Add(MainWindowViewReservas.grdEventsListAux);
            MainWindowViewReservas.grdEventsList.Height = MainWindowViewReservas.grdEventsListReservas.Height;
            MainWindowViewReservas.grdEventsList.Width = MainWindowViewReservas.Width - 410;

            MainWindowViewReservas.opcionesFijo.Controls.Remove(MainWindowViewReservas.opcionesPoner);
            MainWindowViewReservas.opcionesPoner = MainWindowViewReservas.buildPanelOpcionesReservas();
            MainWindowViewReservas.opcionesFijo.Controls.Add(MainWindowViewReservas.opcionesPoner);

            var matricula = this.MainWindowViewReservas.Matricula;
            if (matricula.Equals("Todos"))
            {
                matricula = "";
            }

            RegReservasBusqueda = new List<Reservas>(
            from Reservas in RegReservas
            where ( DateTime.Compare(Reservas.Fentrega, DateTime.Today.AddDays(5)) <= 0
                    && DateTime.Compare(Reservas.Fentrega, DateTime.Today) >= 0)
                    &&(matricula.Equals("") || (matricula.Substring(0, 3).Equals(Reservas.IdTransporte.Substring(4, 3))
                    && matricula.Substring(3, 4).Equals(Reservas.IdTransporte.Substring(0, 4))))
            orderby Reservas.IdTransporte
            select Reservas);
            if (RegReservasBusqueda.Count == 0)
            {
                MessageBox.Show("No hay resultados.", "Alerta", MessageBoxButtons.OK);
            }
            ActualizarListaReservasBusqueda();

        }
        
        //Inicio Disponibilidad: muestra los camiones libres, opcionalmente por tipo.
        private void disponibilidad()
        {
            MainWindowViewReservas.dialogosGrande.Controls.Remove(MainWindowViewReservas.dialogos);
            MainWindowViewReservas.dialogos = MainWindowViewReservas.buildPanelDisponibilidad();
            MainWindowViewReservas.dialogosGrande.Controls.Add(MainWindowViewReservas.dialogos);
            MainWindowViewReservas.dialogosGrande.Width = 390;

        }
        private void DDCSearch()
        {
            var camionesDisponibles = new List<Flota>();
            var tipo = this.MainWindowViewReservas.Tipo;

            if (tipo.Equals("Todos")){
                tipo = "";
            }
          
            var transportesPosibles = new List<String>(
                from Reservas in RegReservas
                where DateTime.Compare(Reservas.Fentrega, DateTime.Today) < 0
                orderby Reservas.IdTransporte
                select (Reservas.IdTransporte.Substring(4, 3) + Reservas.IdTransporte.Substring(0, 4)));

            var transportesOcupados = new List<String>(
                from Reservas in RegReservas
                where DateTime.Compare(Reservas.Fentrega, DateTime.Today) >= 0
                orderby Reservas.IdTransporte
                select (Reservas.IdTransporte.Substring(4, 3) + Reservas.IdTransporte.Substring(0, 4)));

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
            if (camionesDisponibles.Count == 0)
            {
                MessageBox.Show("No hay resultados.", "Alerta", MessageBoxButtons.OK);
            }
            //ActualizaListaFlota(camionesDisponibles);
            ActualizarListaFlotaBusqueda(camionesDisponibles);

        }

        //Inicio Reservas por cliente: Mostrará todas los transportes para un cliente, pasadas o pendientes.
        private void transportesPorCliente()
        {
            if (RegClientes.Count() > 0)
            {
                MainWindowViewReservas.escogerCliente.Text = RegClientes[0].Nif.ToString();
            }
            this.MainWindowViewReservas.grdEventsListClientes.CellMouseClick += (sender, e) =>
            {
                MainWindowViewReservas.escogerCliente.Text = RegClientes[MainWindowViewReservas.grdEventsListClientes.CurrentRow.Index].Nif.ToString();
            };
            MainWindowViewReservas.dialogosGrande.Controls.Remove(MainWindowViewReservas.dialogos);
            MainWindowViewReservas.dialogos = MainWindowViewReservas.panelSearchTransporteCLiente;
            MainWindowViewReservas.dialogosGrande.Controls.Add(MainWindowViewReservas.dialogos);
            MainWindowViewReservas.dialogosGrande.Width = 390;

          

        }
        private void DTCSearch()
        {
            MainWindowViewReservas.grdEventsList.Controls.Remove(MainWindowViewReservas.grdEventsListAux);
            MainWindowViewReservas.grdEventsListAux = MainWindowViewReservas.grdEventsListReservas;
            MainWindowViewReservas.grdEventsList.Controls.Add(MainWindowViewReservas.grdEventsListAux);
            MainWindowViewReservas.grdEventsList.Height = MainWindowViewReservas.grdEventsListReservas.Height;
            MainWindowViewReservas.grdEventsList.Width = MainWindowViewReservas.Width - 410;


            MainWindowViewReservas.opcionesFijo.Controls.Remove(MainWindowViewReservas.opcionesPoner);
            MainWindowViewReservas.opcionesPoner = MainWindowViewReservas.buildPanelOpcionesReservas();
            MainWindowViewReservas.opcionesFijo.Controls.Add(MainWindowViewReservas.opcionesPoner);


            MainWindowViewReservas.dialogosGrande.Controls.Remove(MainWindowViewReservas.dialogos);
            MainWindowViewReservas.dialogos = null;
            MainWindowViewReservas.dialogosGrande.Controls.Add(MainWindowViewReservas.dialogos);
            MainWindowViewReservas.dialogosGrande.Width = 390;

            var nifClienteSeleccionado = MainWindowViewReservas.escogerCliente.Text;
            var periodoSeleccionado = this.MainWindowViewReservas.Periodo2;
            var anhosSeleccionado = this.MainWindowViewReservas.Anho2;

            RegReservasBusqueda = new List<Reservas>(
            from reserva in RegReservas
            where reserva.Cliente.Nif.Equals(nifClienteSeleccionado) && (anhosSeleccionado.Contains(reserva.Fentrega.Year.ToString()) || anhosSeleccionado.Equals(""))
                            && ((DateTime.Compare(reserva.Fentrega, DateTime.Today) < 0) && periodoSeleccionado.Equals("Transportes pasados")
                            || ( (DateTime.Compare(reserva.Fsalida, DateTime.Today) <= 0
                            && DateTime.Compare(reserva.Fentrega, DateTime.Today) >= 0 && !periodoSeleccionado.Equals("Transportes pasados"))))
            orderby reserva.IdTransporte
            select reserva);
            if (RegReservasBusqueda.Count == 0)
            {
                MessageBox.Show("No hay resultados.", "Alerta", MessageBoxButtons.OK);
            }
            ActualizarListaReservasBusqueda();

        }
        private void DTCSearchGraph()
        {

            MainWindowViewReservas.grdEventsList.Controls.Remove(MainWindowViewReservas.grdEventsListAux);
            MainWindowViewReservas.grdEventsListAux = MainWindowViewReservas.grdEventsListReservas;
            MainWindowViewReservas.grdEventsList.Controls.Add(MainWindowViewReservas.grdEventsListAux);
            MainWindowViewReservas.grdEventsList.Height = MainWindowViewReservas.grdEventsListReservas.Height;
            MainWindowViewReservas.grdEventsList.Width = MainWindowViewReservas.Width - 410;


            MainWindowViewReservas.opcionesFijo.Controls.Remove(MainWindowViewReservas.opcionesPoner);
            MainWindowViewReservas.opcionesPoner = MainWindowViewReservas.buildPanelOpcionesReservas();
            MainWindowViewReservas.opcionesFijo.Controls.Add(MainWindowViewReservas.opcionesPoner);


            MainWindowViewReservas.dialogosGrande.Controls.Remove(MainWindowViewReservas.dialogos);
            MainWindowViewReservas.dialogos = null;
            MainWindowViewReservas.dialogosGrande.Controls.Add(MainWindowViewReservas.dialogos);
            MainWindowViewReservas.dialogosGrande.Width = 390;

            var periodoSeleccionado = this.MainWindowViewReservas.Periodo2;
            var anhosSeleccionado = this.MainWindowViewReservas.Anho2;

            RegReservasBusqueda = new List<Reservas>(
            from reserva in RegReservas
            where reserva.Cliente.Nif.Equals(MainWindowViewReservas.escogerCliente.Text) && (anhosSeleccionado.Contains(reserva.Fentrega.Year.ToString()) || anhosSeleccionado.Equals(""))
                            && ((DateTime.Compare(reserva.Fentrega, DateTime.Today) < 0) && periodoSeleccionado.Equals("Transportes pasados")
                            || ((DateTime.Compare(reserva.Fentrega, DateTime.Today) <= 0
                            && DateTime.Compare(reserva.Fentrega, DateTime.Today) >= 0 && !periodoSeleccionado.Equals("Transportes pasados"))))
            orderby reserva.IdTransporte
            select reserva);
            if (anhosSeleccionado.Equals("")) //Búsqueda por todos los años
            {
                this.generarGraficoClienteTotal(RegReservasBusqueda, MainWindowViewReservas.escogerCliente.Text);
            }
            else //Búsqueda por año concreto
            {
                this.generarGraficoClienteAnual(RegReservasBusqueda, MainWindowViewReservas.escogerCliente.Text, anhosSeleccionado);
            }
            ActualizarListaReservasBusqueda();

        }

        //Inicio Reservas por camión: Mostrará todas los transportes, pasados o pendientes, para todo la flota o por camión.
        private void reservasPorCamion()
        {
            MainWindowViewReservas.dialogosGrande.Controls.Remove(MainWindowViewReservas.dialogos);
            MainWindowViewReservas.dialogos = MainWindowViewReservas.panelSearchReservasCamion;
            MainWindowViewReservas.dialogosGrande.Controls.Add(MainWindowViewReservas.dialogos);
            MainWindowViewReservas.dialogosGrande.Width = 390;

        }
        private void DRCSearch()
        {

            MainWindowViewReservas.grdEventsList.Controls.Remove(MainWindowViewReservas.grdEventsListAux);
            MainWindowViewReservas.grdEventsListAux = MainWindowViewReservas.grdEventsListReservas;
            MainWindowViewReservas.grdEventsList.Controls.Add(MainWindowViewReservas.grdEventsListAux);
            MainWindowViewReservas.grdEventsList.Height = MainWindowViewReservas.grdEventsListReservas.Height;
            MainWindowViewReservas.grdEventsList.Width = MainWindowViewReservas.Width - 410;

            MainWindowViewReservas.opcionesFijo.Controls.Remove(MainWindowViewReservas.opcionesPoner);
            MainWindowViewReservas.opcionesPoner = MainWindowViewReservas.buildPanelOpcionesReservas();
            MainWindowViewReservas.opcionesFijo.Controls.Add(MainWindowViewReservas.opcionesPoner);

            var flotamatriculaSeleccionada = this.MainWindowViewReservas.Matricula2;
            var periodoSeleccionado = this.MainWindowViewReservas.Periodo;
            var anhosSeleccionado = this.MainWindowViewReservas.Anho;

            if (flotamatriculaSeleccionada.Equals("Todos"))
            {
                flotamatriculaSeleccionada = "";
            }

            RegReservasBusqueda = new List<Reservas>(
                from reserva in RegReservas
                where  (anhosSeleccionado.Contains(reserva.Fentrega.Year.ToString()) || anhosSeleccionado.Equals("")) &&(
                   ((DateTime.Compare(reserva.Fentrega, DateTime.Today) < 0) && periodoSeleccionado.Equals("Transportes pasados"))
                    || ((DateTime.Compare(reserva.Fsalida, DateTime.Today) <= 0) && (DateTime.Compare(reserva.Fentrega, DateTime.Today) >= 0) && (!periodoSeleccionado.Equals("Transportes pasados")))
                    
                    && (flotamatriculaSeleccionada.Equals("") || (flotamatriculaSeleccionada.Substring(0, 3).Equals(reserva.IdTransporte.Substring(4, 3))
                    && flotamatriculaSeleccionada.Substring(3, 4).Equals(reserva.IdTransporte.Substring(0, 4)))))
                orderby reserva.IdTransporte
                select reserva);

            ActualizarListaReservasBusqueda();

        }
        private void DRCSearchGraph()
        {
            MainWindowViewReservas.grdEventsList.Controls.Remove(MainWindowViewReservas.grdEventsListAux);
            MainWindowViewReservas.grdEventsListAux = MainWindowViewReservas.grdEventsListReservas;
            MainWindowViewReservas.grdEventsList.Controls.Add(MainWindowViewReservas.grdEventsListAux);
            MainWindowViewReservas.grdEventsList.Height = MainWindowViewReservas.grdEventsListReservas.Height;
            MainWindowViewReservas.grdEventsList.Width = MainWindowViewReservas.Width - 410;

            MainWindowViewReservas.opcionesFijo.Controls.Remove(MainWindowViewReservas.opcionesPoner);
            MainWindowViewReservas.opcionesPoner = MainWindowViewReservas.buildPanelOpcionesReservas();
            MainWindowViewReservas.opcionesFijo.Controls.Add(MainWindowViewReservas.opcionesPoner);

            var flotamatriculaSeleccionada = this.MainWindowViewReservas.Matricula2;
            var periodoSeleccionado = this.MainWindowViewReservas.Periodo;
            var anhosSeleccionado = this.MainWindowViewReservas.Anho;

            if (flotamatriculaSeleccionada.Equals("Todos"))
            {
                flotamatriculaSeleccionada = "";
            }

            RegReservasBusqueda = new List<Reservas>(
                 from reserva in RegReservas
                 where (anhosSeleccionado.Contains(reserva.Fentrega.Year.ToString()) || anhosSeleccionado.Equals("")) && (
                    ((DateTime.Compare(reserva.Fentrega, DateTime.Today) < 0) && periodoSeleccionado.Equals("Transportes pasados"))
                     && (flotamatriculaSeleccionada.Equals("") || (flotamatriculaSeleccionada.Substring(0, 3).Equals(reserva.IdTransporte.Substring(4, 3))
                     && flotamatriculaSeleccionada.Substring(3, 4).Equals(reserva.IdTransporte.Substring(0, 4)))))
                 orderby reserva.IdTransporte
                 select reserva);

            if (anhosSeleccionado.Equals("")) //Búsqueda por todos los años
            {
                if (flotamatriculaSeleccionada.Equals("")) //La búsqueda contiene todos los años y todas las matriculas
                {
                    //Lanzar un gráfico general de transportes pendientes total
                    this.generarGraficoGeneralTotal(RegReservasBusqueda);
                }
                else //La búsqueda contiene todos los años de una matricula especifica
                {
                    this.generarGraficoMatriculaTotal(RegReservasBusqueda, flotamatriculaSeleccionada);
                }
            }
            else
            {
                if (flotamatriculaSeleccionada.Equals("")) //La búsqueda es anual y todas las matriculas
                {
                    //Lanzar un gráfico general de transportes pendientes anual
                    this.generarGraficoGeneralAnual(RegReservasBusqueda, anhosSeleccionado);
                }
                else //La búsqueda contiene una matricula especifica en un año
                {
                    this.generarGraficoMatriculaAnual(RegReservasBusqueda, flotamatriculaSeleccionada, anhosSeleccionado);
                }
            }
            ActualizarListaReservasBusqueda();
        }

        //Inicio Reservas por cliente: Mostrará todas las reservas para una persona
        private void reservasPorCliente()
        {

            if (RegClientes.Count() > 0)
            {
                MainWindowViewReservas.escogerCliente4.Text = RegClientes[0].Nif.ToString();
            }
            this.MainWindowViewReservas.grdEventsListClientes.CellMouseClick += (sender, e) =>
            {
                MainWindowViewReservas.escogerCliente4.Text = RegClientes[MainWindowViewReservas.grdEventsListClientes.CurrentRow.Index].Nif.ToString();
            };

            MainWindowViewReservas.dialogosGrande.Controls.Remove(MainWindowViewReservas.dialogos);
            MainWindowViewReservas.dialogos = MainWindowViewReservas.panelSearchReservasCliente;
            MainWindowViewReservas.dialogosGrande.Controls.Add(MainWindowViewReservas.dialogos);
            MainWindowViewReservas.dialogosGrande.Width = 390;

        }
        private void RPCSearch()
        {
            MainWindowViewReservas.grdEventsList.Controls.Remove(MainWindowViewReservas.grdEventsListAux);
            MainWindowViewReservas.grdEventsListAux = MainWindowViewReservas.grdEventsListReservas;
            MainWindowViewReservas.grdEventsList.Controls.Add(MainWindowViewReservas.grdEventsListAux);
            MainWindowViewReservas.grdEventsList.Height = MainWindowViewReservas.grdEventsListReservas.Height;
            MainWindowViewReservas.grdEventsList.Width = MainWindowViewReservas.Width - 410;

            MainWindowViewReservas.opcionesFijo.Controls.Remove(MainWindowViewReservas.opcionesPoner);
            MainWindowViewReservas.opcionesPoner = MainWindowViewReservas.buildPanelOpcionesReservas();
            MainWindowViewReservas.opcionesFijo.Controls.Add(MainWindowViewReservas.opcionesPoner);


            MainWindowViewReservas.dialogosGrande.Controls.Remove(MainWindowViewReservas.dialogos);
            MainWindowViewReservas.dialogos = null;
            MainWindowViewReservas.dialogosGrande.Controls.Add(MainWindowViewReservas.dialogos);
            MainWindowViewReservas.dialogosGrande.Width = 390;

            var anhosSeleccionado = this.MainWindowViewReservas.Anho4;

            RegReservasBusqueda = new List<Reservas>(
            from reserva in RegReservas
            where reserva.Cliente.Nif == MainWindowViewReservas.escogerCliente4.Text && (anhosSeleccionado.Contains(reserva.Fentrega.Year.ToString()) || anhosSeleccionado.Equals(""))
            orderby reserva.IdTransporte
            select reserva);
            if (RegReservasBusqueda.Count == 0)
            {
                MessageBox.Show("No hay resultados.", "Alerta", MessageBoxButtons.OK);
            }
            ActualizarListaReservasBusqueda();

        }
        private void RPCSearchGraph()
        {
            MainWindowViewReservas.grdEventsList.Controls.Remove(MainWindowViewReservas.grdEventsListAux);
            MainWindowViewReservas.grdEventsListAux = MainWindowViewReservas.grdEventsListReservas;
            MainWindowViewReservas.grdEventsList.Controls.Add(MainWindowViewReservas.grdEventsListAux);
            MainWindowViewReservas.grdEventsList.Height = MainWindowViewReservas.grdEventsListReservas.Height;
            MainWindowViewReservas.grdEventsList.Width = MainWindowViewReservas.Width - 410;

            MainWindowViewReservas.opcionesFijo.Controls.Remove(MainWindowViewReservas.opcionesPoner);
            MainWindowViewReservas.opcionesPoner = MainWindowViewReservas.buildPanelOpcionesReservas();
            MainWindowViewReservas.opcionesFijo.Controls.Add(MainWindowViewReservas.opcionesPoner);


            MainWindowViewReservas.dialogosGrande.Controls.Remove(MainWindowViewReservas.dialogos);
            MainWindowViewReservas.dialogos = null;
            MainWindowViewReservas.dialogosGrande.Controls.Add(MainWindowViewReservas.dialogos);
            MainWindowViewReservas.dialogosGrande.Width = 390;

            var anhosSeleccionado = this.MainWindowViewReservas.Anho4;

            RegReservasBusqueda = new List<Reservas>(
            from reserva in RegReservas
            where reserva.Cliente.Nif == MainWindowViewReservas.escogerCliente4.Text && (anhosSeleccionado.Contains(reserva.Fentrega.Year.ToString()) || anhosSeleccionado.Equals(""))
            orderby reserva.IdTransporte
            select reserva);

            if (anhosSeleccionado.Equals("")) //Búsqueda por todos los años
            {
                this.generarGraficoClienteTotal(RegReservasBusqueda, MainWindowViewReservas.escogerCliente4.Text);
            }
            else //Búsqueda por año concreto
            {
                this.generarGraficoClienteAnual(RegReservasBusqueda, MainWindowViewReservas.escogerCliente4.Text, anhosSeleccionado);
            }

            ActualizarListaReservasBusqueda();
        }

        //Inicio Ocupación: muestra los camiones con transportes realizados, para una determinada fecha o para un año completo.
        private void ocupacion()
        {
            MainWindowViewReservas.grdEventsList.Controls.Remove(MainWindowViewReservas.grdEventsListAux);
            MainWindowViewReservas.grdEventsListAux = MainWindowViewReservas.grdEventsListReservas;
            MainWindowViewReservas.grdEventsList.Controls.Add(MainWindowViewReservas.grdEventsListAux);
            MainWindowViewReservas.grdEventsList.Height = MainWindowViewReservas.grdEventsListReservas.Height;
            MainWindowViewReservas.grdEventsList.Width = MainWindowViewReservas.Width - 410;

            MainWindowViewReservas.opcionesFijo.Controls.Remove(MainWindowViewReservas.opcionesPoner);
            MainWindowViewReservas.opcionesPoner = MainWindowViewReservas.buildPanelOpcionesReservas();
            MainWindowViewReservas.opcionesFijo.Controls.Add(MainWindowViewReservas.opcionesPoner);

            MainWindowViewReservas.dialogosGrande.Controls.Remove(MainWindowViewReservas.dialogos);
            MainWindowViewReservas.dialogos = MainWindowViewReservas.buildPanelOcupacion();
            MainWindowViewReservas.dialogosGrande.Controls.Add(MainWindowViewReservas.dialogos);
            MainWindowViewReservas.dialogosGrande.Width = 390;

        }
        private void OASearch()
        {
            var anhosSeleccionado = this.MainWindowViewReservas.Anho5;

            RegReservasBusqueda = new List<Reservas>(
            from reserva in RegReservas
            where(anhosSeleccionado.Contains(reserva.Fentrega.Year.ToString()) || anhosSeleccionado.Equals(""))
            orderby reserva.IdTransporte
            select reserva);
            if (RegReservasBusqueda.Count == 0)
            {
                MessageBox.Show("No hay resultados.", "Alerta", MessageBoxButtons.OK);
            }
            ActualizarListaReservasBusqueda();

        }
        private void OFSearch()
        {       
            var fechaSeleccionada = this.MainWindowViewReservas.Fecha5;
            RegReservasBusqueda = new List<Reservas>(
            from reserva in RegReservas
            where (DateTime.Compare(reserva.Fentrega, fechaSeleccionada) == 0)    
            orderby reserva.IdTransporte
            select reserva);
            if (RegReservasBusqueda.Count == 0)
            {
                MessageBox.Show("No hay resultados.", "Alerta", MessageBoxButtons.OK);
            }
            ActualizarListaReservasBusqueda();
        }

        //Inicio Comodidades: muestra los camiones con una comodidad concreta
        private void comodidades()
        {
            MainWindowViewReservas.dialogosGrande.Controls.Remove(MainWindowViewReservas.dialogos);
            MainWindowViewReservas.dialogos = MainWindowViewReservas.buildPanelComodidades();
            MainWindowViewReservas.dialogosGrande.Controls.Add(MainWindowViewReservas.dialogos);
            MainWindowViewReservas.dialogosGrande.Width = 390;

        }
        private void CCSearch()
        {
            var comodidadesSeleccionada = this.MainWindowViewReservas.comodidad;

            RegFlotasBusqueda = new List<Flota>(
                from flota in flotas
                where (flota.Comodidades.Contains(comodidadesSeleccionada)) 
                select flota);
            if (RegFlotasBusqueda.Count == 0)
            {
                MessageBox.Show("No hay resultados.", "Alerta", MessageBoxButtons.OK);
            }
            ActualizarListaFlotaBusqueda(RegFlotasBusqueda);
        }
        private void CCSearchGraph()
        {
            var comodidadesSeleccionada = this.MainWindowViewReservas.comodidad;

            RegFlotasBusqueda = new List<Flota>(
                from flota in flotas
                where (flota.Comodidades.Contains(comodidadesSeleccionada))
                select flota);
            generarGraficoComodidadesTotal(RegFlotasBusqueda, comodidadesSeleccionada);
            ActualizarListaFlotaBusqueda(RegFlotasBusqueda);
        }
        /*------------------------------------------------------------------*/
        /*------------------Métodos Gestión Clientes------------------------*/
        /*------------------------------------------------------------------*/
        private void RemoveClient()
        {
            if (!Reg.ReservaContainsCliente(MainWindowViewReservas.evt.RowIndex))
            {
                RegClientes.RemoveAt(MainWindowViewReservas.evt.RowIndex);
            }
            else
            {
                Error("No se puede eliminar el cliente. Existen Reservas asignadas.");
            }
            ActualizarLista();
        }
        private void EditFindClient()
        {
            MainWindowViewReservas.dialogosGrande.Controls.Remove(MainWindowViewReservas.dialogos);
            MainWindowViewReservas.dialogos = MainWindowViewReservas.BoxAddClientes;
            MainWindowViewReservas.dialogosGrande.Controls.Add(MainWindowViewReservas.dialogos);
            MainWindowViewReservas.dialogosGrande.Height = MainWindowViewReservas.BoxAddClientes.Height;
            MainWindowViewReservas.BoxAddClientes.Width = 390;
            try
            {
                Cliente c = RegClientes[MainWindowViewReservas.evt.RowIndex];

                MainWindowViewReservas.EdNif.Text = c.Nif;
                MainWindowViewReservas.EdNif.ReadOnly = true;
                MainWindowViewReservas.EdName.Text = c.Nombre;
                MainWindowViewReservas.EdTlf.Text = c.Telefono;
                MainWindowViewReservas.EdMail.Text = c.Email;
                MainWindowViewReservas.EdDirec.Text = c.DireccionPostal;

                MainWindowViewReservas.EditCliente.Enabled = true;
                MainWindowViewReservas.CreateCliente.Enabled = false;
                MainWindowViewReservas.lblCliente.Text = "Editar Cliente";
            }
            catch
            {
                Error("Error recuperando cliente");
            }
        }
        private void EditClient()
        {
            TextBox edNif = MainWindowViewReservas.EdNif;
            TextBox edName = MainWindowViewReservas.EdName;
            TextBox edTlf = MainWindowViewReservas.EdTlf;
            TextBox edMail = MainWindowViewReservas.EdMail;
            TextBox edDirec = MainWindowViewReservas.EdDirec;

            string nif, name, mail, direc, tlf;

            try
            {
                name = Convert.ToString(edName.Text);
                nif = Convert.ToString(edNif.Text);
                mail = Convert.ToString(edMail.Text);
                direc = Convert.ToString(edDirec.Text);
                tlf = Convert.ToString(edTlf.Text);

                if (Regex.IsMatch(nif, "[0-9]{8,8}[A-Za-z]{1}") && nif.Length == 9 && Regex.IsMatch(tlf, "[0-9]{9}") && tlf.Length == 9)
                {
                    if (name.Length > 0 && mail.Length > 0 && direc.Length > 0)
                    {
                        Cliente c = new Cliente(nif, name, tlf, mail, direc);
                        Reg.Edit(c);
                        //ActualizarLista();
                        Clear();
                    }
                    else
                    {
                        throw new ArgumentException();
                    }
                }
                else
                {
                    throw new FormatException();
                }
            }
            catch (ArgumentException)
            {
                Error("Error en datos introducidos");
            }
            catch (FormatException)
            {
                Error("Error, Nif o Télefono con formato incorrecto");
            }
            catch
            {
                Error("Error al crear nuevo cliente");
            }
            finally
            {
                MainWindowViewReservas.lblCliente.Text = "Nuevo Cliente";
                ActualizarLista();
            }
        }
        private void ActualizarLista()
        {
            MainWindowViewReservas.grdEventsListClientes.Rows.Clear();
            foreach (var cliente in RegClientes)
            {
                AddTableEventsListRowWithEvent(cliente);
            }

        }
        private void AddTableEventsListRowWithEvent(Cliente cliente)
        {
            var columnData = new List<object>();

            // Add the row with the event's data
            columnData.Add(cliente.Nif);
            columnData.Add(cliente.Nombre);
            columnData.Add(cliente.Telefono);
            columnData.Add(cliente.DireccionPostal);
            columnData.Add(cliente.Email);

            MainWindowViewReservas.grdEventsListClientes.Rows.Add(columnData.ToArray());

        }
        private void AddClient()
        {
            TextBox edNif = MainWindowViewReservas.EdNif;
            TextBox edName = MainWindowViewReservas.EdName;
            TextBox edTlf = MainWindowViewReservas.EdTlf;
            TextBox edMail = MainWindowViewReservas.EdMail;
            TextBox edDirec = MainWindowViewReservas.EdDirec;

            string nif, name, mail, direc, tlf;

            try
            {
                name = Convert.ToString(edName.Text);
                nif = Convert.ToString(edNif.Text);
                mail = Convert.ToString(edMail.Text);
                direc = Convert.ToString(edDirec.Text);
                tlf = Convert.ToString(edTlf.Text);

                if (Regex.IsMatch(nif, "[0-9]{8,8}[A-Za-z]{1}") && nif.Length == 9 && Regex.IsMatch(tlf, "[0-9]{9}") && tlf.Length == 9)
                {
                    if (Reg.IsNifUnique(nif))
                    {
                        if (name.Length > 0 && mail.Length > 0 && direc.Length > 0)
                        {
                            Cliente c = new Cliente(nif, name, tlf, mail, direc);
                            Reg.Add(c);
                            //Listar();
                            ActualizarLista();
                            Clear();
                        }
                        else
                        {
                            throw new ArgumentException();
                        }
                    }
                    else
                    {
                        throw new FormatException();
                    }
                }
                else
                {
                    Error("Error, Nif o Télefono con formato incorrecto");
                }
            }
            catch (ArgumentException)
            {
                Error("Error en datos introducidos");
            }
            catch (FormatException)
            {
                Error("Error, Nif repetido");
            }
            catch
            {
                Error("Error al crear nuevo cliente");
            }

        }
        private void Clear()
        {
            MainWindowViewReservas.EdNif.Text = "";
            MainWindowViewReservas.EdName.Text = "";
            MainWindowViewReservas.EdTlf.Text = "";
            MainWindowViewReservas.EdMail.Text = "";
            MainWindowViewReservas.EdDirec.Text = "";
            //MainWindowView.EdNifRemove.Text = "";
            //MainWindowView.EdNifEdit.Text = "";

            MainWindowViewReservas.EdNif.ReadOnly = false;
            MainWindowViewReservas.EditCliente.Enabled = false;
            MainWindowViewReservas.CreateCliente.Enabled = true;
        }
        private void Listar()
        {
            StringBuilder toret = new StringBuilder();

            foreach (Cliente c in RegClientes)
            {
                toret.Append(c.ToString());
                toret.Append("\n");
            }
            toret.Replace("\n", Environment.NewLine);

            MainWindowViewReservas.EdClientes.Text = toret.ToString();
        }
        private void Error(String msg)
        {
            System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();

            this.MainWindowViewReservas.EdMsg.Text = "ERROR: " + msg;

            t.Interval = 5000;
            t.Tick += new EventHandler(timer_Tick);
            t.Start();

            void timer_Tick(object sender, EventArgs e)
            {
                MainWindowViewReservas.EdMsg.Text = "";
                t.Stop();
            }

        }

        public void ActualizarListaClientesBusqueda(List<Cliente> clientes)
        {
            MainWindowViewReservas.grdEventsListClientes.Rows.Clear();
            foreach (var c in clientes)
            {
                AddTableEventsListRowWithEvent(c);
            }

        }

        /*------------------------------------------------------------------*/
        /*------------------Métodos Gestión Reservas------------------------*/
        /*------------------------------------------------------------------*/
        private void RemoveReserv()
        {
            RegReservas.RemoveAt(MainWindowViewReservas.evt.RowIndex);
            ActualizarListaReservas();
        }
        public void Crear()
        {

            TextBox edIdtrans = MainWindowViewReservas.tbIdTransp;
            TextBox edCliente = MainWindowViewReservas.tbCliente;
            TextBox edTipoTransp = MainWindowViewReservas.tbTipoTrans;
            TextBox edFcontra = MainWindowViewReservas.tbFcontra;
            TextBox edFsalida = MainWindowViewReservas.tbFsalida;
            TextBox edFentrega = MainWindowViewReservas.tbFentrega;
            TextBox edEdia = MainWindowViewReservas.tbEDia;
            TextBox edEkm = MainWindowViewReservas.tbEkm;
            TextBox edKmRecorridos = MainWindowViewReservas.tbKmRecorridos;
            TextBox edIVA = MainWindowViewReservas.tbIVA;
            TextBox edGas = MainWindowViewReservas.tbGas;
            TextBox edSuplencia = MainWindowViewReservas.tbSuplencia;



            string idTrans;
            Cliente cliente;
            Flota tipoTransp;
            DateTime fcontra, fsalida, fentrega;
            double edia, ekm, iva, kmRecorridos, gas, suplencia;

            try
            {
                cliente = Reg.FindByNif(Convert.ToString(edCliente.Text));
                idTrans = Convert.ToString(edIdtrans.Text);
                // TODO: Cambiar por funcion tipo FindByMatricula de RegistroFlota
                tipoTransp = Reg.FindByMatricula(Convert.ToString(edTipoTransp.Text));
                fcontra = Convert.ToDateTime(edFcontra.Text).Date;
                fsalida = Convert.ToDateTime(edFsalida.Text).Date;
                fentrega = Convert.ToDateTime(edFentrega.Text).Date;
                edia = Convert.ToDouble(edEdia.Text);
                ekm = Convert.ToDouble(edEkm.Text);
                kmRecorridos = Convert.ToDouble(edKmRecorridos.Text);
                iva = Convert.ToDouble(edIVA.Text);
                gas = Convert.ToDouble(edGas.Text);
                suplencia = Convert.ToDouble(edSuplencia.Text);

              
                if (Reg.IsIDTranspUnique(idTrans))
                {
                    if (idTrans.Length > 0)
                    {
                        Reservas r = new Factura(idTrans, cliente, tipoTransp, fcontra, fsalida, fentrega, edia, ekm, kmRecorridos, iva, gas, suplencia);
                        Reg.Add(r);
                        ActualizarListaReservas();
                        ClearReservas();
                    }
                    else
                    {
                        throw new ArgumentException();
                    }
                }

                else
                {
                    ErrorReserva("IdTransporte con formato incorrecto");
                }
            }
            catch (ArgumentException)
            {
                ErrorReserva("Error en datos introducidos");
            }
            catch (FormatException)
            {
                throw new FormatException();
            }
            catch
            {
                ErrorReserva("Error al crear una nueva reserva");
            }

        }
        private void EditFindReserv()
        {
            MainWindowViewReservas.dialogosGrande.Controls.Remove(MainWindowViewReservas.dialogos);
            MainWindowViewReservas.dialogos = MainWindowViewReservas.BoxAddReservas;
            MainWindowViewReservas.dialogosGrande.Controls.Add(MainWindowViewReservas.dialogos);
            MainWindowViewReservas.dialogosGrande.Height = MainWindowViewReservas.BoxAddReservas.Height;
            MainWindowViewReservas.BoxAddReservas.Width = 390;

            try
            {
                Reservas r = RegReservas[MainWindowViewReservas.evt.RowIndex];
                MainWindowViewReservas.tbIdTransp.Text = r.IdTransporte;
                MainWindowViewReservas.tbIdTransp.ReadOnly = true;
                MainWindowViewReservas.tbCliente.Text = r.Cliente.Nif;
                MainWindowViewReservas.tbTipoTrans.Text = r.TipoTransporte.Matricula;
                MainWindowViewReservas.tbFcontra.Text = r.FechaContratacion.Date.ToString().Substring(0, 10);
                MainWindowViewReservas.tbFsalida.Text = r.Fsalida.Date.ToString().Substring(0, 10);
                MainWindowViewReservas.tbFentrega.Text = r.Fentrega.Date.ToString().Substring(0, 10);
                MainWindowViewReservas.tbEDia.Text = r.ImporteDia.ToString();
                MainWindowViewReservas.tbEkm.Text = r.ImporteKm.ToString();
                MainWindowViewReservas.tbKmRecorridos.Text = r.kmRecorridos.ToString();
                MainWindowViewReservas.tbGas.Text = r.Gas.ToString();
                MainWindowViewReservas.tbIVA.Text = r.IVA.ToString();
                MainWindowViewReservas.tbSuplencia.Text = r.Suplencia.ToString();



                MainWindowViewReservas.EditReserva.Enabled = true;
                MainWindowViewReservas.CreateReserva.Enabled = false;
            }
            catch
            {
                ErrorReserva("Error recuperando reserva");
            }
        }
        private void EditReserv()
        {
            TextBox EdIdTransp = MainWindowViewReservas.tbIdTransp;
            TextBox EdCliente = MainWindowViewReservas.tbCliente;
            TextBox EdTipoTransp = MainWindowViewReservas.tbTipoTrans;
            TextBox EdFcontra = MainWindowViewReservas.tbFcontra;
            TextBox EdFsalida = MainWindowViewReservas.tbFsalida;
            TextBox EdFentrega = MainWindowViewReservas.tbFentrega;
            TextBox EdEdia = MainWindowViewReservas.tbEDia;
            TextBox EdEkm = MainWindowViewReservas.tbEkm;
            TextBox EdKmRecorridos = MainWindowViewReservas.tbKmRecorridos;
            TextBox EdIVA = MainWindowViewReservas.tbIVA;
            TextBox EdGas = MainWindowViewReservas.tbGas;
            TextBox EdSuplencia = MainWindowViewReservas.tbSuplencia;
            TextBox EdPrecioFactura = MainWindowViewReservas.tbPrecioFactura;

            string idTransp;
            Flota tipoTransp;
            Cliente Cliente;
            DateTime Fcontra, Fsalida, Fentrega;
            double ImporteDia, ImporteKm, kmRecorridos,
                IVA, Gas, Suplencia;

            try
            {

                Cliente = Reg.FindByNif(Convert.ToString(EdCliente.Text));
                idTransp = Convert.ToString(EdIdTransp.Text);
                // TODO: Cambiar por funcion tipo FindByMatricula de RegistroFlota
                tipoTransp = Reg.FindByMatricula(Convert.ToString(EdTipoTransp.Text));
                Fcontra = Convert.ToDateTime(EdFcontra.Text);
                Fsalida = Convert.ToDateTime(EdFsalida.Text);
                Fentrega = Convert.ToDateTime(EdFentrega.Text);
                ImporteDia = Convert.ToDouble(EdEdia.Text);
                ImporteKm = Convert.ToDouble(EdEkm.Text);
                kmRecorridos = Convert.ToDouble(EdKmRecorridos.Text);
                IVA = Convert.ToDouble(EdIVA.Text);
                Gas = Convert.ToDouble(EdGas.Text);
                Suplencia = Convert.ToDouble(EdSuplencia.Text);
               // PrecioFactura = Convert.ToDouble(reservas.PrecioFactura);


                if (idTransp.Length > 0)
                {
                    Reservas r = new Factura(idTransp, Cliente, tipoTransp, Fcontra, Fsalida, Fentrega, ImporteDia, ImporteKm,
                        kmRecorridos, IVA, Gas, Suplencia);
                    Reg.Edit(r);
                    ActualizarListaReservas();
                    ClearReservas();
                }
                else
                {
                    throw new ArgumentException();
                }

            }
            catch (ArgumentException)
            {
                ErrorReserva("Error en datos introducidos");
            }

            catch
            {
                ErrorReserva("Error al crear una reserva nueva");
            }
            finally
            {
                ActualizarLista();
            }
        }
        public void ActualizarListaReservas()
        {
            MainWindowViewReservas.grdEventsListReservas.Rows.Clear();
            foreach (var reserva in RegReservas)
            {
                AddTableEventsListRowWithEvent(reserva);
            }

        }
        private void AddTableEventsListRowWithEvent(Reservas reserva)
        {
            var columnData = new List<object>();

            // Add the row with the event's data
            columnData.Add(reserva.IdTransporte);
            columnData.Add(reserva.Cliente.Nif);
            columnData.Add(reserva.TipoTransporte.Tipo);
            columnData.Add(reserva.FechaContratacion.Date.ToString().Substring(0, 10));
            columnData.Add(reserva.Fsalida.Date.ToString().Substring(0, 10));
            columnData.Add(reserva.Fentrega.Date.ToString().Substring(0, 10));
            columnData.Add(reserva.ImporteDia);
            columnData.Add(reserva.ImporteKm);
            columnData.Add(reserva.kmRecorridos);
            columnData.Add(reserva.IVA);
            columnData.Add(reserva.Gas);
            columnData.Add(reserva.Suplencia);
            columnData.Add(reserva.PrecioFactura);

            MainWindowViewReservas.grdEventsListReservas.Rows.Add(columnData.ToArray());
        }
        public void ClearReservas()
        {
            MainWindowViewReservas.tbIdTransp.Text = "";
            MainWindowViewReservas.tbCliente.Text = "";
            MainWindowViewReservas.tbTipoTrans.Text = "";
            MainWindowViewReservas.tbFcontra.Text = "";
            MainWindowViewReservas.tbFsalida.Text = "";
            MainWindowViewReservas.tbFentrega.Text = "";
            MainWindowViewReservas.tbEDia.Text = "";
            MainWindowViewReservas.tbEkm.Text = "";
            MainWindowViewReservas.tbKmRecorridos.Text = "";
            MainWindowViewReservas.tbIVA.Text = "";
            MainWindowViewReservas.tbGas.Text = "";
            MainWindowViewReservas.tbSuplencia.Text = "";
            //MainWindowView.edPrecioFactura.Text = "";


            MainWindowViewReservas.tbIdTransp.ReadOnly = false;
            MainWindowViewReservas.EditReserva.Enabled = false;
            MainWindowViewReservas.CreateReserva.Enabled = true;
        }
        private void ListarReservas()
        {
            StringBuilder toret = new StringBuilder();

            foreach (Reservas r in RegReservas)
            {
                toret.Append(r.ToString());
                toret.Append("\n");
            }
            toret.Replace("\n", Environment.NewLine);

            MainWindowViewReservas.tbReservas.Text = toret.ToString();
        }
        private void ErrorReserva(String msg)
        {
            System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();

            this.MainWindowViewReservas.EdMsg.Text = "ERROR: " + msg;

            t.Interval = 5000;
            t.Tick += new EventHandler(timer_Tick);
            t.Start();

            void timer_Tick(object sender, EventArgs e)
            {
                MainWindowViewReservas.EdMsg.Text = "";
                t.Stop();
            }

        }

        //Metodos gestion reservas busqueda
        public void ActualizarListaReservasBusqueda()
        {
            MainWindowViewReservas.grdEventsListReservas.Rows.Clear();
            foreach (var reserva in RegReservasBusqueda)
            {
                AddTableEventsListRowWithEvent(reserva);
            }

        }

        //Metodos gestion reservas busqueda
        public void ActualizarListaFlotaBusqueda(List<Flota> camionesDisponibles)
        {
            MainWindowViewReservas.grdEventsListFlota.Rows.Clear();
            foreach (var flota in camionesDisponibles)
            {
                ActualizaFilaDeListaFlota(flota);
            }

        }

        /*------------------------------------------------------------------*/
        /*------------------Métodos Gestión Flota---------------------------*/
        /*------------------------------------------------------------------*/
        //Métodos para las operaciones
        public void insertFlota()
        {
            TextBox edLetrasMatricula = this.MainWindowViewReservas.edLetrasMatricula;
            TextBox edDigitosMatricula = this.MainWindowViewReservas.edDigitosMatricula;
            TextBox edCarga = this.MainWindowViewReservas.edCarga;
            TextBox edMarca = this.MainWindowViewReservas.edMarca;
            TextBox edModelo = this.MainWindowViewReservas.edModelo;
            TextBox edConsumoKm = this.MainWindowViewReservas.edConsumoKm;
            TextBox edFechaAdquisicion = this.MainWindowViewReservas.edFechaAdquisicion;
            TextBox edFechaFabricacion = this.MainWindowViewReservas.edFechaFabricacion;
            CheckBox ComodidadWifi = this.MainWindowViewReservas.ComodidadWifi;
            CheckBox ComodidadBlue = this.MainWindowViewReservas.ComodidadBlue;
            CheckBox ComodidadAire = this.MainWindowViewReservas.ComodidadAire;
            CheckBox ComodidadLitera = this.MainWindowViewReservas.ComodidadLitera;
            CheckBox ComodidadTv = this.MainWindowViewReservas.ComodidadTv;
            String tipo = this.MainWindowViewReservas.Tipo2;
            double carga;
            string matricula;
            string marca;
            string modelo;
            double consumo;
            DateTime fad;
            DateTime ffab;
            List<String> Comodidades = new List<string>();

            if (edLetrasMatricula.Text != "" || edDigitosMatricula.Text != "" 
                || edCarga.Text != "" || edMarca.Text != "" 
                || edModelo.Text != "" || edConsumoKm.Text != ""
                 || edFechaAdquisicion.Text != "" || edFechaFabricacion.Text != "" ||
                 tipo != ""
                ){

                if (tipo != "Selecciona")
                {


                    if (edLetrasMatricula.Text.Length == 3 && edDigitosMatricula.Text.Length == 4
                        && Regex.IsMatch(edLetrasMatricula.Text, @"^[a-zA-Z]+$")
                        && Regex.IsMatch(edDigitosMatricula.Text, @"^[0-9]+$"))
                    {
                        Double.TryParse(edCarga.Text, out carga);
                        matricula = String.Concat(edDigitosMatricula.Text, edLetrasMatricula.Text);
                        modelo = edModelo.Text;
                        Double.TryParse(edConsumoKm.Text, out consumo);
                        marca = edMarca.Text;

                        if (DateTime.TryParse(edFechaAdquisicion.Text, out fad) && DateTime.TryParse(edFechaFabricacion.Text, out ffab))
                        {
                            var matriculas = new List<Flota>(from mat in flotas
                                                             where mat.Matricula.Equals(matricula)
                                                             select mat);
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
                            if (matriculas.Count == 0)
                            {
                                Flota flota = new Flota(carga, matricula, tipo, marca, modelo, consumo, fad, ffab, Comodidades);
                                if (flota.ComprobarCarga())
                                {
                                    flotas.Add(flota);
                                    MessageBox.Show("Vehículo introducido correctamente", "", MessageBoxButtons.OK);
                                    ActualizaListaFlota();

                                }
                                else MessageBox.Show("Superado Límite de Carga para el vehículo", "", MessageBoxButtons.OK);
                            }
                            else MessageBox.Show("La matrícula ya está almacenada en el sistema");
                        }
                        else MessageBox.Show("Las fechas no son correctas");
                    }
                    else MessageBox.Show("La matrícula no es correcta");
                }
                else MessageBox.Show("Introduzca un tipo de vehículo");

            }
            else
            {
                MessageBox.Show("Algun campo es vacio");
            }
        }
        public void deleteFlota()
        {
            if (!Reg.ReservaContainsFlota(MainWindowViewReservas.evt.RowIndex))
            {
                flotas.RemoveAt(MainWindowViewReservas.evt.RowIndex);
                MessageBox.Show("Vehículo eliminado correctamente", "", MessageBoxButtons.OK);
            }
            else
            {
                Error("No se puede eliminar la flota. Existen Reservas asignadas.");
                MessageBox.Show("Vehículo no eliminado", "Error", MessageBoxButtons.OK);
            }
            
            ActualizaListaFlota();

        }
        private void EditFindFlota()
        {
            MainWindowViewReservas.dialogosGrande.Controls.Remove(MainWindowViewReservas.dialogos);
            MainWindowViewReservas.dialogos = MainWindowViewReservas.panelModificar;
            MainWindowViewReservas.dialogosGrande.Controls.Add(MainWindowViewReservas.dialogos);
            MainWindowViewReservas.dialogosGrande.Height = MainWindowViewReservas.panelModificar.Height;
            MainWindowViewReservas.panelModificar.Width = 350;
            try
            {
                cleanFlotaEdit();
                Flota flot = flotas[MainWindowViewReservas.evt.RowIndex];

                MainWindowViewReservas.edMatricula.Text = flot.Matricula;
                MainWindowViewReservas.escogerTipo2M.Text = flot.Tipo;

                MainWindowViewReservas.edMatricula.ReadOnly = true;
                MainWindowViewReservas.edMarcaM.Text = flot.Marca;
                MainWindowViewReservas.edModeloM.Text = flot.Modelo;
                MainWindowViewReservas.edConsumoKmM.Text = flot.ConsumoKm.ToString();
                MainWindowViewReservas.edCargaM.Text = flot.Carga.ToString();
                MainWindowViewReservas.edFechaAdquisicionM.Text = flot.FechaAdquisicion.ToString().Substring(0, 10);
                MainWindowViewReservas.edFechaFabricacionM.Text = flot.FechaFabricacion.ToString().Substring(0, 10);
                if (flot.Comodidades.Contains("Wifi"))
                {
                    MainWindowViewReservas.ComodidadWifiM.Checked = true;
                }
                if (flot.Comodidades.Contains("Conexion Bluetooth"))
                {
                    MainWindowViewReservas.ComodidadBlueM.Checked = true;
                }
                if (flot.Comodidades.Contains("Aire Acondicionado"))
                {
                    MainWindowViewReservas.ComodidadAireM.Checked = true;
                }
                if (flot.Comodidades.Contains("Litera"))
                {
                    MainWindowViewReservas.ComodidadLiteraM.Checked = true;
                }
                if (flot.Comodidades.Contains("Tv"))
                {
                    MainWindowViewReservas.ComodidadTvM.Checked = true;
                }
                MainWindowViewReservas.btModificar.Enabled = true;

            }
            catch
            {
                ErrorFlota("Error recuperando flota");
            }

        }
        private void ErrorFlota(String msg)
        {
            System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();

            this.MainWindowViewReservas.EdMsg.Text = "ERROR: " + msg;

            t.Interval = 5000;
            t.Tick += new EventHandler(timer_Tick);
            t.Start();

            void timer_Tick(object sender, EventArgs e)
            {
                MainWindowViewReservas.EdMsg.Text = "";
                t.Stop();
            }

        }
        public void modFlota()
        {
            TextBox edCarga = this.MainWindowViewReservas.edCargaM;
            TextBox Matricula = this.MainWindowViewReservas.edMatricula;
            TextBox edMarca = this.MainWindowViewReservas.edMarcaM;
            TextBox edModelo = this.MainWindowViewReservas.edModeloM;
            TextBox edConsumoKm = this.MainWindowViewReservas.edConsumoKmM;
            TextBox edFechaAdquisicion = this.MainWindowViewReservas.edFechaAdquisicionM;
            TextBox edFechaFabricacion = this.MainWindowViewReservas.edFechaFabricacionM;
            CheckBox ComodidadWifi = this.MainWindowViewReservas.ComodidadWifiM;
            CheckBox ComodidadBlue = this.MainWindowViewReservas.ComodidadBlueM;
            CheckBox ComodidadAire = this.MainWindowViewReservas.ComodidadAireM;
            CheckBox ComodidadLitera = this.MainWindowViewReservas.ComodidadLiteraM;
            CheckBox ComodidadTv = this.MainWindowViewReservas.ComodidadTvM;
            String tipo = this.MainWindowViewReservas.Tipo2M;

            double carga;
            double consumo;
            DateTime fad;
            DateTime ffab;
            List<String> Comodidades = new List<string>();


            var matriculas = new List<Flota>(from mat in flotas
                                             where mat.Matricula.Equals(Matricula.Text)
                                             select mat);

            if (matriculas.Count == 1)
            {
                flota_mod = matriculas.ElementAt(0);
                flotas.Remove(matriculas.ElementAt(0));

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
    
                if (edFechaAdquisicion.Text != "" && (DateTime.TryParse(edFechaAdquisicion.Text.Substring(0, 10), out fad)))
                {
                    flota_mod.FechaAdquisicion = fad;
                }
    
                if (edFechaFabricacion.Text != "" && (DateTime.TryParse(edFechaAdquisicion.Text.Substring(0, 10), out ffab)))
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
                    flotas.Remove(matriculas.ElementAt(0));
                    flotas.Add(flota_mod);
                    
                
                ActualizaListaFlota();
            }

        }
        public void cleanFlotaEdit()
        {
            MainWindowViewReservas.edMatricula.Text = "";
            MainWindowViewReservas.escogerTipo2M.Text = "";
            MainWindowViewReservas.edMarcaM.Text = "";
            MainWindowViewReservas.edModeloM.Text = "";
            MainWindowViewReservas.edConsumoKmM.Text = "";
            MainWindowViewReservas.edCargaM.Text = "";
            MainWindowViewReservas.edFechaAdquisicionM.Text = "";
            MainWindowViewReservas.edFechaFabricacionM.Text = "";
            MainWindowViewReservas.ComodidadWifiM.Checked = false;
            MainWindowViewReservas.ComodidadBlueM.Checked = false;
            MainWindowViewReservas.ComodidadAireM.Checked = false;
            MainWindowViewReservas.ComodidadLiteraM.Checked = false;
            MainWindowViewReservas.ComodidadTvM.Checked = false;
         }
        public void cleanFlotaAdd()
        {
            MainWindowViewReservas.edLetrasMatricula.Text = "";
            MainWindowViewReservas.edDigitosMatricula.Text = "";
            MainWindowViewReservas.escogerTipo2.Text = "";
            MainWindowViewReservas.edMarca.Text = "";
            MainWindowViewReservas.edModelo.Text = "";
            MainWindowViewReservas.edConsumoKm.Text = "";
            MainWindowViewReservas.edCarga.Text = "";
            MainWindowViewReservas.edFechaAdquisicion.Text = "";
            MainWindowViewReservas.edFechaFabricacion.Text = "";
            MainWindowViewReservas.ComodidadWifi.Checked = false;
            MainWindowViewReservas.ComodidadBlue.Checked = false;
            MainWindowViewReservas.ComodidadAire.Checked = false;
            MainWindowViewReservas.ComodidadLitera.Checked = false;
            MainWindowViewReservas.ComodidadTv.Checked = false;

        }

        //Muestra de datos

        private void ActualizaListaFlota()
        {

            MainWindowViewReservas.grdEventsListFlota.Rows.Clear();
            foreach (Flota flots in flotas)
            {
                ActualizaFilaDeListaFlota(flots);
            }
        }

        private void ActualizaFilaDeListaFlota(Flota f)
        {
            var columnData = new List<object>();

            // Add the row with the event's data
            columnData.Add(f.Matricula);
            columnData.Add(f.Carga);
            columnData.Add(f.Tipo);
            columnData.Add(f.Marca);
            columnData.Add(f.Modelo);
            columnData.Add(f.ConsumoKm);
            columnData.Add(f.FechaAdquisicion.ToString().Substring(0, 10));
            columnData.Add(f.FechaFabricacion.ToString().Substring(0, 10));
            StringBuilder comodidades = new StringBuilder();
            foreach (String aux in f.Comodidades)
            {
                comodidades.Append(aux + " ");
            }
            columnData.Add(comodidades.ToString());

            MainWindowViewReservas.grdEventsListFlota.Rows.Add(columnData.ToArray());

        }
        public void ClearFlota()
        {/* 
                 MainWindowViewReservas.edLetrasMatricula.Text = "";
                 MainWindowViewReservas.edDigitosMatricula.Text = "";
                 MainWindowViewReservas.edCarga.Text = "";
                 MainWindowViewReservas.edMarca.Text = "";
                 MainWindowViewReservas.edModelo.Text = "";
                 MainWindowViewReservas.edConsumoKm.Text = "";
                 MainWindowViewReservas.edFechaAdquisicion.Text = "";
                 MainWindowViewReservas.edFechaFabricacion.Text = "";

                 MainWindowViewReservas.edLetrasMatricula.ReadOnly = false;*/
        }

        /*------------------------------------------------------------------*/
        /*---------------------------Gráficos-------------------------------*/
        /*------------------------------------------------------------------*/

        /* Métodos de gráficos */
        //Métodos comunes//
        private int busquedaGeneralMesesGrafico(List<Reservas> data, int mes)
        {
            var dataList = new List<Reservas>(
                from transporte in data
                where (transporte.FechaContratacion.Month == mes)
                orderby transporte.Fentrega
                select transporte);

            return dataList.Count;
        }
        private int BusquedaGeneralAnualGrafico(int anho)
        {
            var dataList = new List<Reservas>(
                from transporte in RegReservas
                where (transporte.FechaContratacion.Year == anho)
                orderby transporte.Fentrega
                select transporte);

            return dataList.Count;
        }
        //Metodos especificos general//
        private int[] valuesChartAnual(List<Reservas> data)
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
            foreach (int x in data)
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
            var dataList = new List<Reservas>(
                from transporte in RegReservas
                where (transporte.FechaContratacion.Year == anho) && (transporte.Cliente.Nif.Equals(nif))
                orderby transporte.Fentrega
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
            var dataList = new List<Reservas>(
                from transporte in RegReservas
                where (transporte.FechaContratacion.Year == anho) &&
                        (matricula.Substring(0, 3).Equals(transporte.IdTransporte.Substring(4, 3)) &&
                        matricula.Substring(3, 4).Equals(transporte.IdTransporte.Substring(0, 4)))
                orderby transporte.Fentrega
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

        //Graficos generales
        private void generarGraficoGeneralTotal(List<Reservas> listaObjetos)
        {
            IEnumerable<int> data = from transporte in listaObjetos
                                    orderby transporte.Fentrega
                                    select transporte.Fentrega.Year;

            var distinctData = data.Select(x => x).Distinct();
            string[] toLegend = new string[distinctData.Count()];
            int i = 0;
            foreach (int t in distinctData)
            {
                toLegend[i] = Convert.ToString(t);
                i++;
            }

            if (listaObjetos.Count != 0)
            {
                Form frm = new Form() { Text = "Grafico actividad general" };
                MainWindowViewReservas.PanelGrafico = new Panel() { Dock = DockStyle.Fill};
                MainWindowViewReservas.BuildPanelGraficoGeneral();
                MainWindowViewReservas.setDataChart("Años", "Nº transportes", valuesChartTotal(distinctData));
                MainWindowViewReservas.setDataLegend(toLegend);
                MainWindowViewReservas.Chart.Draw();
                MainWindowViewReservas.PanelGrafico.Controls.Add(MainWindowViewReservas.panelGraficoGeneral);
                frm.Controls.Add(MainWindowViewReservas.PanelGrafico);
                frm.Height = MainWindowViewReservas.CHART_CANVAS_SIZE + 50;
                frm.Width = MainWindowViewReservas.CHART_CANVAS_SIZE;
                frm.Show();
            }
            else
            {
                MessageBox.Show("No hay resultados.", "Alerta", MessageBoxButtons.OK);
            }
        }
        private void generarGraficoGeneralAnual(List<Reservas> listaObjetos, string anho)
        {

            if (listaObjetos.Count != 0)
            {
                Form frm = new Form() { Text = "Grafico actividad general" };
                MainWindowViewReservas.PanelGrafico = new Panel() { Dock = DockStyle.Fill };
                MainWindowViewReservas.BuildPanelGraficoGeneral();
                MainWindowViewReservas.setDataChart(anho, "Nº transportes", valuesChartAnual(listaObjetos));
                MainWindowViewReservas.setDataLegend(emptyValue);
                MainWindowViewReservas.Chart.Draw();
                MainWindowViewReservas.PanelGrafico.Controls.Add(MainWindowViewReservas.panelGraficoGeneral);
                frm.Controls.Add(MainWindowViewReservas.PanelGrafico);
                frm.Height = MainWindowViewReservas.CHART_CANVAS_SIZE + 50;
                frm.Width = MainWindowViewReservas.CHART_CANVAS_SIZE;
                frm.Show();
            }
            else
            {
                MessageBox.Show("No hay resultados.", "Alerta", MessageBoxButtons.OK);
            }
        }
        //Matricula Especifica
        private void generarGraficoMatriculaTotal(List<Reservas> listaObjetos, string matricula)
        {
            IEnumerable<int> data = from transporte in listaObjetos
                                    where (matricula.Substring(0, 3).Equals(transporte.IdTransporte.Substring(4, 3)) &&
                                            matricula.Substring(3, 4).Equals(transporte.IdTransporte.Substring(0, 4)))
                                    orderby transporte.Fentrega
                                    select transporte.Fentrega.Year;

            var distinctData = data.Select(x => x).Distinct();
            string[] toLegend = new string[distinctData.Count()];
            int i = 0;
            foreach (int t in distinctData)
            {
                toLegend[i] = Convert.ToString(t);
                i++;
            }

            if (listaObjetos.Count != 0)
            {
                Form frm = new Form() { Text = "Grafico actividad total del camión con matrícula: " + matricula };
                MainWindowViewReservas.PanelGrafico = new Panel() { Dock = DockStyle.Fill };
                MainWindowViewReservas.BuildPanelGraficoGeneral();
                MainWindowViewReservas.setDataChart("Años", "Nº transportes", valuesChartTotalCamion(distinctData, matricula));
                MainWindowViewReservas.setDataLegend(toLegend);
                MainWindowViewReservas.Chart.Draw();
                MainWindowViewReservas.PanelGrafico.Controls.Add(MainWindowViewReservas.panelGraficoGeneral);
                frm.Controls.Add(MainWindowViewReservas.PanelGrafico);
                frm.Height = MainWindowViewReservas.CHART_CANVAS_SIZE + 50;
                frm.Width = MainWindowViewReservas.CHART_CANVAS_SIZE;
                frm.Show();
            }
            else
            {
                MessageBox.Show("No hay resultados.", "Alerta", MessageBoxButtons.OK);
            }
        }
        private void generarGraficoMatriculaAnual(List<Reservas> listaObjetos, string matricula, string anho)
        {
            if (listaObjetos.Count != 0)
            {
                Form frm = new Form() { Text = "Grafico actividad total del camión con matrícula: " + matricula };
                MainWindowViewReservas.PanelGrafico = new Panel() { Dock = DockStyle.Fill };
                MainWindowViewReservas.BuildPanelGraficoGeneral();
                MainWindowViewReservas.setDataChart(anho, "Nº transportes", valuesChartAnual(listaObjetos));
                MainWindowViewReservas.setDataLegend(emptyValue);
                MainWindowViewReservas.Chart.Draw();
                MainWindowViewReservas.PanelGrafico.Controls.Add(MainWindowViewReservas.panelGraficoGeneral);
                frm.Controls.Add(MainWindowViewReservas.PanelGrafico);
                frm.Height = MainWindowViewReservas.CHART_CANVAS_SIZE + 50;
                frm.Width = MainWindowViewReservas.CHART_CANVAS_SIZE;
                frm.Show();
            }
            else
            {
                MessageBox.Show("No hay resultados.", "Alerta", MessageBoxButtons.OK);
            }

        }
        //Cliente específico
        private void generarGraficoClienteTotal(List<Reservas> listaObjetos, string nif)
        {
            IEnumerable<int> data = from transporte in listaObjetos
                                    where transporte.Cliente.Nif.Equals(nif) 
                                    orderby transporte.Fentrega
                                    select transporte.Fentrega.Year; 
 
            var distinctData = data.Select(x => x).Distinct(); 
            string[] toLegend = new string[distinctData.Count()]; 
            int i = 0; 
            foreach (int t in distinctData) 
            { 
                toLegend[i] = Convert.ToString(t); 
                i++; 
            }

            if (listaObjetos.Count != 0)
            {
                Form frm = new Form() { Text = "Grafico actividad total del cliente con DNI: " + nif };
                MainWindowViewReservas.PanelGrafico = new Panel() { Dock = DockStyle.Fill };
                MainWindowViewReservas.BuildPanelGraficoGeneral();
                MainWindowViewReservas.setDataChart("Años", "Nº transportes", valuesChartTotalCliente(distinctData, nif));
                MainWindowViewReservas.setDataLegend(toLegend);
                MainWindowViewReservas.Chart.Draw();
                MainWindowViewReservas.PanelGrafico.Controls.Add(MainWindowViewReservas.panelGraficoGeneral);
                frm.Controls.Add(MainWindowViewReservas.PanelGrafico);
                frm.Height = MainWindowViewReservas.CHART_CANVAS_SIZE + 50;
                frm.Width = MainWindowViewReservas.CHART_CANVAS_SIZE;
                frm.Show();
            }
            else
            {
                MessageBox.Show("No hay resultados.", "Alerta", MessageBoxButtons.OK);
            }
        }
        private void generarGraficoClienteAnual(List<Reservas> listaObjetos, string nif, string anho)
        {
            if (listaObjetos.Count != 0)
            {
                Form frm = new Form() { Text = "Grafico actividad anual del cliente con DNI: " + nif };
                MainWindowViewReservas.PanelGrafico = new Panel() { Dock = DockStyle.Fill };
                MainWindowViewReservas.BuildPanelGraficoGeneral();
                MainWindowViewReservas.setDataChart(anho, "Nº transportes", valuesChartAnual(listaObjetos));
                MainWindowViewReservas.setDataLegend(emptyValue);
                MainWindowViewReservas.Chart.Draw();
                MainWindowViewReservas.PanelGrafico.Controls.Add(MainWindowViewReservas.panelGraficoGeneral);
                frm.Controls.Add(MainWindowViewReservas.PanelGrafico);
                frm.Height = MainWindowViewReservas.CHART_CANVAS_SIZE + 50;
                frm.Width = MainWindowViewReservas.CHART_CANVAS_SIZE;
                frm.Show();
            }
            else
            {
                MessageBox.Show("No hay resultados.", "Alerta", MessageBoxButtons.OK);
            }

        }
        //Comodidad específica
        private void generarGraficoComodidadesTotal(List<Flota> listaObjetos, string comodidad)
        {
            IEnumerable<int> data = from flota in listaObjetos
                                    where (flota.Comodidades.Contains(comodidad))
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

            if (listaObjetos.Count != 0)
            {
                Form frm = new Form() { Text = "Grafico actividad de la comodidad: " + comodidad };
                MainWindowViewReservas.PanelGrafico = new Panel() { Dock = DockStyle.Fill };
                MainWindowViewReservas.BuildPanelGraficoGeneral();
                MainWindowViewReservas.setDataChart(comodidad, "Nº transportes", valuesChartTotalComodidades(distinctData, comodidad));
                MainWindowViewReservas.setDataLegend(toLegend);
                MainWindowViewReservas.Chart.Draw();
                MainWindowViewReservas.PanelGrafico.Controls.Add(MainWindowViewReservas.panelGraficoGeneral);
                frm.Controls.Add(MainWindowViewReservas.PanelGrafico);
                frm.Height = MainWindowViewReservas.CHART_CANVAS_SIZE + 50;
                frm.Width = MainWindowViewReservas.CHART_CANVAS_SIZE;
                frm.Show();
            }
            else
            {
                MessageBox.Show("No hay resultados.", "Alerta", MessageBoxButtons.OK);
            }
        }
    }
}
