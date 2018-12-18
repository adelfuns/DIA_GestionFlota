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
 
            reservasParaMostrarEnGrid = Reg.GetReservas();
            flotasParaMostrarEnGrid = Reg.GetFlotas();
            clientesParaMostrarEnGrid  = Reg.GetClientes();
            
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
                MainWindowViewReservas.lblCliente.Text = "Nuevo Cliente";
                MainWindowViewReservas.EditCliente.Enabled = true;
                MainWindowViewReservas.CreateCliente.Enabled = false;
                MainWindowViewReservas.EdNif.ReadOnly = false;
                MainWindowViewReservas.BoxAddClientes.Width = 390;
                Clear();
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
                MainWindowViewReservas.tbTipoTrans.ReadOnly = false;
                MainWindowViewReservas.tbFcontra.ReadOnly = false;
                ClearReservas();
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
                    Reservas r = reservasParaMostrarEnGrid[this.MainWindowViewReservas.grdEventsListReservas.CurrentRow.Index];
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

                    string matricula =  String.Concat(r.IdTransporte.Substring(4, 3),r.IdTransporte.Substring(0, 4));

                    flotasParaMostrarEnGrid = new List<Flota>(
                        from flota in Reg.GetFlotas()
                        where flota.Matricula == matricula
                        select flota);

                    ActualizarListaFlotaBusqueda(flotasParaMostrarEnGrid);
                }

                if(this.MainWindowViewReservas.grdEventsListReservas.CurrentCell.ColumnIndex == 1)
                {
                    Reservas r = reservasParaMostrarEnGrid[this.MainWindowViewReservas.grdEventsListReservas.CurrentRow.Index];

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

                    clientesParaMostrarEnGrid = new List<Cliente>(
                        from cliente in Reg.GetClientes()
                        where  cliente.Nif == r.Cliente.Nif
                        select cliente);

                    ActualizarListaClientesBusqueda(clientesParaMostrarEnGrid);
                }
            };
            this.MainWindowViewReservas.grdEventsListClientes.CellMouseClick += (sender, e) =>
            {
                if (this.MainWindowViewReservas.grdEventsListClientes.CurrentCell.ColumnIndex == 0)
                {

                    Cliente c = clientesParaMostrarEnGrid[this.MainWindowViewReservas.grdEventsListClientes.CurrentRow.Index];

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

                    reservasParaMostrarEnGrid = new List<Reservas>(
                        from reseva in Reg.GetReservas()
                        where reseva.Cliente.Nif == c.Nif
                        select reseva);

                    ActualizarListaReservasBusqueda();
                }
            };

            this.MainWindowViewReservas.grdEventsListFlota.CellMouseClick += (sender, e) =>
            {
                if (this.MainWindowViewReservas.grdEventsListFlota.CurrentCell.ColumnIndex == 0)
                {
                    Flota c = flotasParaMostrarEnGrid[this.MainWindowViewReservas.grdEventsListFlota.CurrentRow.Index];

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

                    reservasParaMostrarEnGrid = new List<Reservas>(
                        from reserva in Reg.GetReservas()
                        where c.Matricula.Substring(0, 3).Equals(reserva.IdTransporte.Substring(4, 3))
                             && c.Matricula.Substring(3, 4).Equals(reserva.IdTransporte.Substring(0, 4))
                        select reserva);

                    ActualizarListaReservasBusqueda();
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
        public static Registro Reg { get; set; }
        public Flota flota_mod { get; set; }
        public List<Reservas> reservasParaMostrarEnGrid;
        public List<Flota> flotasParaMostrarEnGrid;
        public List<Cliente> clientesParaMostrarEnGrid;

        public static string[] emptyValue = new string[12] { "Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic" };

        /*------------------------------------------------------------------*/
        /*-------------------Gestion Flota/Cliente/Reserva------------------*/
        /*------------------------------------------------------------------*/
        private void ActividadGestionFlota()
        {
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

            MainWindowViewReservas.Text = "Gestion Flota";

            ClearFlota();
            flotasParaMostrarEnGrid = Reg.GetFlotas();
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
            clientesParaMostrarEnGrid = Reg.GetClientes();
            ActualizarLista();
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

            reservasParaMostrarEnGrid = Reg.GetReservas();

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

            reservasParaMostrarEnGrid = new List<Reservas>(
            from Reservas in Reg.GetReservas()
            where DateTime.Compare(Reservas.Fentrega, DateTime.Today) >= 0
            orderby Reservas.IdTransporte
            select Reservas);
            MainWindowViewReservas.Text = "Gestion Reservas";

            ClearReservas();
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

            reservasParaMostrarEnGrid = new List<Reservas>(
            from Reservas in Reg.GetReservas()
            where ( DateTime.Compare(Reservas.Fentrega, DateTime.Today.AddDays(5)) <= 0
                    && DateTime.Compare(Reservas.Fentrega, DateTime.Today) >= 0)
                    &&(matricula.Equals("") || (matricula.Substring(0, 3).Equals(Reservas.IdTransporte.Substring(4, 3))
                    && matricula.Substring(3, 4).Equals(Reservas.IdTransporte.Substring(0, 4))))
            orderby Reservas.IdTransporte
            select Reservas);
            if (reservasParaMostrarEnGrid.Count == 0)
            {
                Error("No hay resultados");
            }
            MainWindowViewReservas.dialogosGrande.Controls.Remove(MainWindowViewReservas.dialogos);
            MainWindowViewReservas.dialogos = null;
            MainWindowViewReservas.dialogosGrande.Controls.Add(MainWindowViewReservas.dialogos);
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
                from Reservas in Reg.GetReservas()
                where DateTime.Compare(Reservas.Fentrega, DateTime.Today) < 0
                orderby Reservas.IdTransporte
                select (Reservas.IdTransporte.Substring(4, 3) + Reservas.IdTransporte.Substring(0, 4)));

            var transportesOcupados = new List<String>(
                from Reservas in Reg.GetReservas()
                where DateTime.Compare(Reservas.Fentrega, DateTime.Today) >= 0
                orderby Reservas.IdTransporte
                select (Reservas.IdTransporte.Substring(4, 3) + Reservas.IdTransporte.Substring(0, 4)));

            var transportesLibres = transportesPosibles.Except(transportesOcupados);

            foreach (Flota flota in Reg.GetFlotas()){
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
                //MessageBox.Show("No hay resultados.", "Alerta", MessageBoxButtons.OK);
                Error("No hay resultados");
            }

            ActualizarListaFlotaBusqueda(camionesDisponibles);
        }

        //Inicio Reservas por cliente: Mostrará todas los transportes para un cliente, pasadas o pendientes.
        private void transportesPorCliente()
        {
            if (clientesParaMostrarEnGrid.Count() > 0)
            {
                MainWindowViewReservas.escogerCliente.Text = clientesParaMostrarEnGrid[0].Nif.ToString();
            }
            this.MainWindowViewReservas.grdEventsListClientes.CellMouseClick += (sender, e) =>
            {
                MainWindowViewReservas.escogerCliente.Text = clientesParaMostrarEnGrid[MainWindowViewReservas.grdEventsListClientes.CurrentRow.Index].Nif.ToString();
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

            reservasParaMostrarEnGrid = new List<Reservas>(
            from reserva in Reg.GetReservas()
            where reserva.Cliente.Nif.Equals(nifClienteSeleccionado) && (anhosSeleccionado.Contains(reserva.Fentrega.Year.ToString()) || anhosSeleccionado.Equals(""))
                            && ((DateTime.Compare(reserva.Fentrega, DateTime.Today) < 0) && periodoSeleccionado.Equals("Transportes pasados")
                            || ( (DateTime.Compare(reserva.Fsalida, DateTime.Today) <= 0
                            && DateTime.Compare(reserva.Fentrega, DateTime.Today) >= 0 && !periodoSeleccionado.Equals("Transportes pasados"))))
            orderby reserva.IdTransporte
            select reserva);
            if (reservasParaMostrarEnGrid.Count == 0)
            {
                Error("No hay resultados");
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

            reservasParaMostrarEnGrid = new List<Reservas>(
            from reserva in Reg.GetReservas()
            where reserva.Cliente.Nif.Equals(MainWindowViewReservas.escogerCliente.Text) && (anhosSeleccionado.Contains(reserva.Fentrega.Year.ToString()) || anhosSeleccionado.Equals(""))
                            && ((DateTime.Compare(reserva.Fentrega, DateTime.Today) < 0) && periodoSeleccionado.Equals("Transportes pasados")
                            || ((DateTime.Compare(reserva.Fentrega, DateTime.Today) <= 0
                            && DateTime.Compare(reserva.Fentrega, DateTime.Today) >= 0 && !periodoSeleccionado.Equals("Transportes pasados"))))
            orderby reserva.IdTransporte
            select reserva);
            if (anhosSeleccionado.Equals("")) //Búsqueda por todos los años
            {
                this.generarGraficoClienteTotal(reservasParaMostrarEnGrid, MainWindowViewReservas.escogerCliente.Text);
            }
            else //Búsqueda por año concreto
            {
                this.generarGraficoClienteAnual(reservasParaMostrarEnGrid, MainWindowViewReservas.escogerCliente.Text, anhosSeleccionado);
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

            reservasParaMostrarEnGrid = new List<Reservas>(
                from reserva in Reg.GetReservas()
                where  (anhosSeleccionado.Contains(reserva.Fentrega.Year.ToString()) || anhosSeleccionado.Equals("")) 
                    && (flotamatriculaSeleccionada.Equals("") || (flotamatriculaSeleccionada.Substring(0, 3).Equals(reserva.IdTransporte.Substring(4, 3))
                    && flotamatriculaSeleccionada.Substring(3, 4).Equals(reserva.IdTransporte.Substring(0, 4))))
                    && (((DateTime.Compare(reserva.Fentrega, DateTime.Today) < 0) && periodoSeleccionado.Equals("Transportes pasados"))   
                    || ((DateTime.Compare(reserva.Fsalida, DateTime.Today) <= 0) && (DateTime.Compare(reserva.Fentrega, DateTime.Today) >= 0) 
                    && (!periodoSeleccionado.Equals("Transportes pasados"))))              
                orderby reserva.IdTransporte
                select reserva);

            MainWindowViewReservas.dialogosGrande.Controls.Remove(MainWindowViewReservas.dialogos);
            MainWindowViewReservas.dialogos = null;
            MainWindowViewReservas.dialogosGrande.Controls.Add(MainWindowViewReservas.dialogos);
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

            reservasParaMostrarEnGrid = new List<Reservas>(
                from reserva in Reg.GetReservas()
                where (anhosSeleccionado.Contains(reserva.Fentrega.Year.ToString()) || anhosSeleccionado.Equals(""))
                    && (flotamatriculaSeleccionada.Equals("") || (flotamatriculaSeleccionada.Substring(0, 3).Equals(reserva.IdTransporte.Substring(4, 3))
                    && flotamatriculaSeleccionada.Substring(3, 4).Equals(reserva.IdTransporte.Substring(0, 4))))
                    && (((DateTime.Compare(reserva.Fentrega, DateTime.Today) < 0) && periodoSeleccionado.Equals("Transportes pasados"))
                    || ((DateTime.Compare(reserva.Fsalida, DateTime.Today) <= 0) && (DateTime.Compare(reserva.Fentrega, DateTime.Today) >= 0)
                    && (!periodoSeleccionado.Equals("Transportes pasados"))))
                orderby reserva.IdTransporte
                select reserva);

            if (anhosSeleccionado.Equals("")) //Búsqueda por todos los años
            {
                if (flotamatriculaSeleccionada.Equals("")) //La búsqueda contiene todos los años y todas las matriculas
                {
                    //Lanzar un gráfico general de transportes pendientes total
                    this.generarGraficoGeneralTotal(reservasParaMostrarEnGrid);
                }
                else //La búsqueda contiene todos los años de una matricula especifica
                {
                    this.generarGraficoMatriculaTotal(reservasParaMostrarEnGrid, flotamatriculaSeleccionada);
                }
            }
            else
            {
                if (flotamatriculaSeleccionada.Equals("")) //La búsqueda es anual y todas las matriculas
                {
                    //Lanzar un gráfico general de transportes pendientes anual
                    this.generarGraficoGeneralAnual(reservasParaMostrarEnGrid, anhosSeleccionado);
                }
                else //La búsqueda contiene una matricula especifica en un año
                {
                    this.generarGraficoMatriculaAnual(reservasParaMostrarEnGrid, flotamatriculaSeleccionada, anhosSeleccionado);
                }
            }
            MainWindowViewReservas.dialogosGrande.Controls.Remove(MainWindowViewReservas.dialogos);
            MainWindowViewReservas.dialogos = null;
            MainWindowViewReservas.dialogosGrande.Controls.Add(MainWindowViewReservas.dialogos);
            ActualizarListaReservasBusqueda();
        }

        //Inicio Reservas por cliente: Mostrará todas las reservas para una persona
        private void reservasPorCliente()
        {
            if (clientesParaMostrarEnGrid.Count() > 0)
            {
                MainWindowViewReservas.escogerCliente4.Text = clientesParaMostrarEnGrid[0].Nif.ToString();
            }
            this.MainWindowViewReservas.grdEventsListClientes.CellMouseClick += (sender, e) =>
            {
                MainWindowViewReservas.escogerCliente4.Text = clientesParaMostrarEnGrid[MainWindowViewReservas.grdEventsListClientes.CurrentRow.Index].Nif.ToString();
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

            reservasParaMostrarEnGrid = new List<Reservas>(
            from reserva in Reg.GetReservas()
            where reserva.Cliente.Nif == MainWindowViewReservas.escogerCliente4.Text && (anhosSeleccionado.Contains(reserva.Fentrega.Year.ToString()) || anhosSeleccionado.Equals(""))
            orderby reserva.IdTransporte
            select reserva);
            if (reservasParaMostrarEnGrid.Count == 0)
            {
                Error("No hay resultados");
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

            reservasParaMostrarEnGrid = new List<Reservas>(
            from reserva in Reg.GetReservas()
            where reserva.Cliente.Nif == MainWindowViewReservas.escogerCliente4.Text && (anhosSeleccionado.Contains(reserva.Fentrega.Year.ToString()) || anhosSeleccionado.Equals(""))
            orderby reserva.IdTransporte
            select reserva);

            if (anhosSeleccionado.Equals("")) //Búsqueda por todos los años
            {
                this.generarGraficoClienteTotal(reservasParaMostrarEnGrid, MainWindowViewReservas.escogerCliente4.Text);
            }
            else //Búsqueda por año concreto
            {
                this.generarGraficoClienteAnual(reservasParaMostrarEnGrid, MainWindowViewReservas.escogerCliente4.Text, anhosSeleccionado);
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

            reservasParaMostrarEnGrid = new List<Reservas>(
            from reserva in Reg.GetReservas()
            where(anhosSeleccionado.Contains(reserva.Fentrega.Year.ToString()) || anhosSeleccionado.Equals(""))
            orderby reserva.IdTransporte
            select reserva);
            if (reservasParaMostrarEnGrid.Count == 0)
            {
                Error("No hay resultados");
            }
            ActualizarListaReservasBusqueda();

        }
        private void OFSearch()
        {       
            var fechaSeleccionada = this.MainWindowViewReservas.Fecha5;
            reservasParaMostrarEnGrid = new List<Reservas>(
            from reserva in Reg.GetReservas()
            where (DateTime.Compare(reserva.Fentrega, fechaSeleccionada) == 0)    
            orderby reserva.IdTransporte
            select reserva);
            if (reservasParaMostrarEnGrid.Count == 0)
            {
                Error("No hay resultados");
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

            flotasParaMostrarEnGrid = new List<Flota>(
                from flota in Reg.GetFlotas()
                where (flota.Comodidades.Contains(comodidadesSeleccionada)) 
                select flota);
            if (flotasParaMostrarEnGrid.Count == 0)
            {
                Error("No hay resultados");
            }

            ActualizarListaFlotaBusqueda(flotasParaMostrarEnGrid);
        }
        private void CCSearchGraph()
        {
            var comodidadesSeleccionada = this.MainWindowViewReservas.comodidad;

            flotasParaMostrarEnGrid = new List<Flota>(
                from flota in Reg.GetFlotas()
                where (flota.Comodidades.Contains(comodidadesSeleccionada))
                select flota);

            generarGraficoComodidadesTotal(flotasParaMostrarEnGrid, comodidadesSeleccionada );

            ActualizarListaFlotaBusqueda(flotasParaMostrarEnGrid);
        }
        /*------------------------------------------------------------------*/
        /*------------------Métodos Gestión Clientes------------------------*/
        /*------------------------------------------------------------------*/
        private void RemoveClient()
        {
            if (!Reg.ReservaContainsCliente(MainWindowViewReservas.evt.RowIndex))
            {
                Reg.RemoveClienteAt(MainWindowViewReservas.evt.RowIndex);
            }
            else
            {
                Error("No se puede eliminar el cliente. Existen Reservas asignadas.");
            }

            clientesParaMostrarEnGrid = Reg.GetClientes();
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
                Cliente c = clientesParaMostrarEnGrid[MainWindowViewReservas.evt.RowIndex];

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

                        clientesParaMostrarEnGrid = Reg.GetClientes();
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

                clientesParaMostrarEnGrid = Reg.GetClientes();
                ActualizarLista();
            }

            MainWindowViewReservas.dialogosGrande.Controls.Remove(MainWindowViewReservas.dialogos);
            MainWindowViewReservas.dialogos = null;
            MainWindowViewReservas.dialogosGrande.Controls.Add(MainWindowViewReservas.dialogos);
        }
        private void ActualizarLista()
        {
            MainWindowViewReservas.grdEventsListClientes.Rows.Clear();
            foreach (var cliente in clientesParaMostrarEnGrid)
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
                MainWindowViewReservas.lblCliente.Text = "Nuevo Cliente";

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
                            clientesParaMostrarEnGrid = Reg.GetClientes();
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

            foreach (Cliente c in Reg.GetClientes())
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
            Reg.RemoveReservaAt(MainWindowViewReservas.evt.RowIndex);
            reservasParaMostrarEnGrid = Reg.GetReservas();
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

            String tipo = this.MainWindowViewReservas.tipoTranss;

            string idTrans;
            Cliente cliente;
            Flota tipoTransp;
            DateTime fcontra, fsalida, fentrega;
            double edia, ekm, iva, kmRecorridos, gas, suplencia;

            try
            {
                cliente = Reg.FindByNif(edCliente.Text);
                //idTrans = Convert.ToString(edIdtrans.Text);
                tipoTransp = Reg.FindByMatricula(edTipoTransp.Text);
                fcontra = Convert.ToDateTime(edFcontra.Text).Date;
                fsalida = Convert.ToDateTime(edFsalida.Text).Date;
                fentrega = Convert.ToDateTime(edFentrega.Text).Date;
                edia = Convert.ToDouble(edEdia.Text);
                ekm = Convert.ToDouble(edEkm.Text);
                kmRecorridos = Convert.ToDouble(edKmRecorridos.Text);
                iva = Convert.ToDouble(edIVA.Text);
                gas = Convert.ToDouble(edGas.Text);
                suplencia = Convert.ToDouble(edSuplencia.Text);
                //idTrans = tipoTransp.Matricula + fcontra.Date.Year + fcontra.Date.Month + fcontra.Date.Day;

                String mes;
                String dia;
                if (fcontra.Date.Month.ToString().Count() == 1)
                {
                    mes = String.Concat("0", fcontra.Date.Month.ToString());
                }
                else
                {
                    mes = fcontra.Date.Month.ToString();
                }

                if (fcontra.Date.Day.ToString().Count() == 1)
                {
                    dia = String.Concat("0", fcontra.Date.Day.ToString());
                }
                else
                {
                    dia = fcontra.Date.Day.ToString();
                }
                idTrans = String.Concat(tipoTransp.Matricula.Substring(3, 4), tipoTransp.Matricula.Substring(0, 3)) + fcontra.Date.Year + mes + dia;


                if (Reg.IsIDTranspUnique(idTrans))
                {
                    if (idTrans.Length > 0 && tipo!="Seleccionar")
                    {
                        Reservas r = new Factura(idTrans, cliente, tipo, fcontra, fsalida, fentrega, edia, ekm, kmRecorridos, iva, gas, suplencia,tipoTransp);
                        Reg.Add(r);

                        reservasParaMostrarEnGrid = Reg.GetReservas();
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
                ErrorReserva("Error en datos introducidos");
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
                Reservas r = reservasParaMostrarEnGrid[MainWindowViewReservas.evt.RowIndex];
                MainWindowViewReservas.tipoTransReserva.SelectedItem = r.TipoTransporte;
              
                MainWindowViewReservas.tbIdTransp.Text = r.IdTransporte;
                MainWindowViewReservas.tbIdTransp.ReadOnly = true;
                MainWindowViewReservas.tbCliente.Text = r.Cliente.Nif;
                MainWindowViewReservas.tbTipoTrans.Text = r.Vehiculo.Matricula;
                MainWindowViewReservas.tbTipoTrans.ReadOnly = true;

                MainWindowViewReservas.tbFcontra.Text = r.FechaContratacion.Date.ToString().Substring(0, 10);
                MainWindowViewReservas.tbFcontra.ReadOnly = true;
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
            //TextBox EdPrecioFactura = MainWindowViewReservas.tbPrecioFactura;

            String tipo = this.MainWindowViewReservas.tipoTranss;

            string idTransp;
            Flota tipoTransp;
            Cliente Cliente;
            DateTime Fcontra, Fsalida, Fentrega;
            double ImporteDia, ImporteKm, kmRecorridos,
                IVA, Gas, Suplencia;

            try
            {

                Cliente = Reg.FindByNif(Convert.ToString(EdCliente.Text));
                //idTransp = Convert.ToString(EdIdTransp.Text);
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

                String mes;
                String dia;
                if(Fcontra.Date.Month.ToString().Count() == 1)
                {
                    mes = String.Concat("0", Fcontra.Date.Month.ToString());
                }else
                {
                    mes = Fcontra.Date.Month.ToString();
                }

                if (Fcontra.Date.Day.ToString().Count() == 1)
                {
                    dia = String.Concat("0", Fcontra.Date.Day.ToString());
                }
                else
                {
                    dia = Fcontra.Date.Day.ToString();
                }
                idTransp = String.Concat(tipoTransp.Matricula.Substring(3, 4), tipoTransp.Matricula.Substring(0, 3)) + Fcontra.Date.Year + mes + dia;


                if (idTransp.Length > 0 && tipo!="Seleccionar")
                {
                    //Reg.GetReservas
                    Reservas r = new Factura(idTransp, Cliente, tipo, Fcontra, Fsalida, Fentrega, ImporteDia, ImporteKm,
                        kmRecorridos, IVA, Gas, Suplencia,tipoTransp);
                    Reg.Edit(r);

                    reservasParaMostrarEnGrid = Reg.GetReservas();
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
                reservasParaMostrarEnGrid = Reg.GetReservas();
                ActualizarListaReservas();

                MainWindowViewReservas.dialogosGrande.Controls.Remove(MainWindowViewReservas.dialogos);
                MainWindowViewReservas.dialogos = null;
                MainWindowViewReservas.dialogosGrande.Controls.Add(MainWindowViewReservas.dialogos);
            }
        }
        public void ActualizarListaReservas()
        {
            MainWindowViewReservas.grdEventsListReservas.Rows.Clear();
            foreach (var reserva in reservasParaMostrarEnGrid)
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
            columnData.Add(reserva.TipoTransporte);
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

            foreach (Reservas r in reservasParaMostrarEnGrid)
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
            foreach (var reserva in reservasParaMostrarEnGrid)
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

            if (edLetrasMatricula.Text != "" && edDigitosMatricula.Text != ""
                && edCarga.Text != "" && edMarca.Text != ""
                && edModelo.Text != "" && edConsumoKm.Text != ""
                && edFechaAdquisicion.Text != "" && edFechaFabricacion.Text != "" 
                && tipo != ""
                ){

                if (tipo != "Selecciona")
                {


                    if (edLetrasMatricula.Text.Length == 3 && edDigitosMatricula.Text.Length == 4
                        && Regex.IsMatch(edLetrasMatricula.Text, @"^[a-zA-Z]+$")
                        && Regex.IsMatch(edDigitosMatricula.Text, @"^[0-9]+$"))
                    {
                        Double.TryParse(edCarga.Text, out carga);
                        matricula = String.Concat( edLetrasMatricula.Text, edDigitosMatricula.Text);
                        modelo = edModelo.Text;
                        Double.TryParse(edConsumoKm.Text, out consumo);
                        marca = edMarca.Text;

                        if (DateTime.TryParse(edFechaAdquisicion.Text, out fad) && DateTime.TryParse(edFechaFabricacion.Text, out ffab))
                        {
                            var matriculas = new List<Flota>(from mat in Reg.GetFlotas()
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
                                    Reg.Add(flota);
                                    MessageBox.Show("Vehículo introducido correctamente");

                                    flotasParaMostrarEnGrid = Reg.GetFlotas();
                                    cleanFlotaAdd();
                                    ActualizaListaFlota();

                                }
                                else Error("Superado Límite de Carga para el vehículo");
                            }
                            else Error("La matrícula ya está almacenada en el sistema");
                        }
                        else Error("Las fechas no son correctas");
                    }
                    else Error("La matrícula no es correcta");
                }
                else Error("Introduzca un tipo de vehículo");

            }
            else
            {
                Error("Algun campo está vacio");
            }
        }
        public void deleteFlota()
        {
            if (!Reg.ReservaContainsFlota(MainWindowViewReservas.evt.RowIndex))
            {
                Reg.RemoveFlotaAt(MainWindowViewReservas.evt.RowIndex);
                Error("Vehículo eliminado correctamente");
            }
            else
            {
                Error("No se puede eliminar la flota. Existen Reservas asignadas.");
                //MessageBox.Show("Vehículo no eliminado", "Error", MessageBoxButtons.OK);
            }

            flotasParaMostrarEnGrid = Reg.GetFlotas();
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
                Flota flot = flotasParaMostrarEnGrid[MainWindowViewReservas.evt.RowIndex];

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


            if (Matricula.Text != ""  && edCarga.Text != "" 
                && edMarca.Text != ""
                && edModelo.Text != ""
                && edConsumoKm.Text != ""
                && edFechaAdquisicion.Text != ""
                && edFechaFabricacion.Text != ""
                && tipo != ""
                )
            {
                var matriculas = new List<Flota>(from mat in Reg.GetFlotas()
                                                 where mat.Matricula.Equals(Matricula.Text)
                                                 select mat);
 

                if (matriculas.Count == 1)
                {
                    flota_mod = matriculas.ElementAt(0);
                    Reg.Remove(matriculas.ElementAt(0));
                    

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
                    if (tipo != "")
                    {
                        flota_mod.Tipo = tipo;
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
                    Reg.Remove(matriculas.ElementAt(0));

                    Reg.Add(flota_mod);

                    flotasParaMostrarEnGrid = Reg.GetFlotas();
                    cleanFlotaEdit();
                    ActualizaListaFlota();
                    MessageBox.Show("Modificación realizada con éxito", "", MessageBoxButtons.OK);

                }
            }
            else Error("Algun campo es vacio por lo tanto no se modifica");
            MainWindowViewReservas.dialogosGrande.Controls.Remove(MainWindowViewReservas.dialogos);
            MainWindowViewReservas.dialogos = null;
            MainWindowViewReservas.dialogosGrande.Controls.Add(MainWindowViewReservas.dialogos);

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
            foreach (Flota flots in flotasParaMostrarEnGrid)
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
        { 
            MainWindowViewReservas.edLetrasMatricula.Text = "";
            MainWindowViewReservas.edDigitosMatricula.Text = "";
            MainWindowViewReservas.edCarga.Text = "";
            MainWindowViewReservas.edMarca.Text = "";
            MainWindowViewReservas.edModelo.Text = "";
            MainWindowViewReservas.edConsumoKm.Text = "";
            MainWindowViewReservas.edFechaAdquisicion.Text = "";
            MainWindowViewReservas.edFechaFabricacion.Text = "";

            MainWindowViewReservas.edLetrasMatricula.ReadOnly = false;
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
                from transporte in Reg.GetReservas()
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
                from transporte in Reg.GetReservas()
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
                from transporte in Reg.GetReservas()
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
                 from flota in Reg.GetFlotas()
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
                Error("No hay resultados.");
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
                Error("No hay resultados.");
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
                Error("No hay resultados.");
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
                Error("No hay resultados.");
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
                Error("No hay resultados.");
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
                Error("No hay resultados.");
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
                Error("No hay resultados.");
            }
        }
    }
}
