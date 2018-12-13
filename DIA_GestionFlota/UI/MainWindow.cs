namespace DIA_GestionFlota
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;
    using GestionFlotas.UI.DialogSearch;
    using GestionFlota.Core;
    using GestionFlota.UI;
    using System.Text.RegularExpressions;
    using GestionFlota;
 

    class MainWindow : Form
    {
        public MainWindow()
        {
            //Console.WriteLine(DateTime.Now.ToString());

            RegClientes = new RegistroClientes();
            RegClientes = RegistroClientes.RecuperaXml();

            RegReservas = new RegistroReservas(RegClientes);
            RegReservas = RegistroReservas.RecuperaXml();

            //this.MainWindowView = new MainWindowView();

            this.MainWindowViewReservas = new MainWindowViewReservas();
            inTransportes = true;
            inClientes = false;
            inFlota = false;
            Flota flota1 = new Flota(1.5, "AAA9999", "Mudanza", "opel", "modelo", "20", new DateTime(2000, 12, 12), new DateTime(1999, 12, 12), new string[] { "wifi", "musica" });
            Flota flota2 = new Flota(2, "AAA6666", "Transporte de mercancías", "opel2", "modelo", "23", new DateTime(2013, 11, 10), new DateTime(2000, 10, 11), new string[] { "wifi", "musica" });
            flotas = new List<Flota>();
            flotas.Add(flota1);
            flotas.Add(flota2);

            // TODO: Eliminar cuando funcione bien el registroReservas
            //RegReservas[0].TipoTransporte = flota1;
            //RegReservas[1].TipoTransporte = flota1;
            // RegReservas[2].TipoTransporte = flota2;
            //Cliente cliente1 = new Cliente("66666666F", "Nombre", "telefono", "asdsa@asda", "323213");
            //Cliente cliente2 = new Cliente("66677766F", "Nombre2", "telefono2", "asdsa2@asda", "323213");
            //clientes = new List<Cliente>();
            //clientes.Add(cliente1);
            //clientes.Add(cliente2);

            // Transportes transportes1 = new Transportes("6666AAA12121112", flota2, RegClientes[0], new DateTime(2017, 11, 06), "12", new DateTime(2017, 11, 07), new DateTime(2017, 11, 12), "20", "50", 10);
            // Transportes transportes2 = new Transportes("6666AAA12121113", flota2, RegClientes[0], new DateTime(2018, 11, 06), "12", new DateTime(2018, 11, 07), new DateTime(2018, 11, 23), "20", "50", 10);
            // Transportes transportes3 = new Transportes("9999AAA12121114", flota2, RegClientes[0], new DateTime(2018, 11, 06), "12", new DateTime(2018, 11, 07), new DateTime(2018, 12, 22), "20", "50", 10);
            // Transportes transportes4 = new Transportes("9999AAA12121115", flota2, RegClientes[1], new DateTime(2018, 11, 06), "12", new DateTime(2018, 11, 07), new DateTime(2018, 11, 21), "20", "50", 10);

            //transportes = new List<Transportes>();
            //transportes.Add(transportes1);
            //transportes.Add(transportes2);
            //transportes.Add(transportes3);
            //transportes.Add(transportes4);


            this.MainWindowViewReservas.FormClosed += (sender, e) => this.Salir();
            this.MainWindowViewReservas.operacionSalir.Click += (sender, e) => this.Salir();
            this.MainWindowViewReservas.menuAtras.Click += (sender, e) => this.mostrarTodosLosTransportes();

            this.MainWindowViewReservas.Load += (sender, e) => this.mostrarTodosLosTransportes();

            //Operaciones búsqueda
            //Inicializar dialogos
            this.dialogoCamion = new DialogoCamiones();

            //Menu de la MainWindowView
            this.MainWindowViewReservas.operacionSearch1.Click += (sender, e) => this.transportePendientes();
            this.MainWindowViewReservas.operacionSearch2.Click += (sender, e) => this.disponibilidad();
            this.MainWindowViewReservas.operacionSearch3.Click += (sender, e) => this.transportesPorCliente();
            this.MainWindowViewReservas.operacionSearch4.Click += (sender, e) => this.reservasPorCamion();
            this.MainWindowViewReservas.operacionSearch5.Click += (sender, e) => this.reservasPorCliente();
            this.MainWindowViewReservas.operacionSearch6.Click += (sender, e) => this.ocupacion();

            //Dialogos
            this.MainWindowViewReservas.btSearchCamiones.Click += (sender, e) => this.DTPSearch(); //TransportesPendientes

            this.MainWindowViewReservas.btSearchTransporteCliente.Click += (sender, e) => this.DTCSearch();//Transporte cliente    
            this.MainWindowViewReservas.btSearchCamiones2.Click += (sender, e) => this.DRCSearch();// Reservas Camion
            this.MainWindowViewReservas.btSearchCliente4.Click += (sender, e) => this.RPCSearch();//Reservas por cliente
            this.MainWindowViewReservas.btSearchOcupacionAnho5.Click += (sender, e) => this.OASearch();//Ocupacion
            this.MainWindowViewReservas.calendar.DateSelected += (sender, e) => this.OFSearch();//Ocupacion

            this.dialogoCamion.btSearchCamiones.Click += (sender, e) => this.DDCSearch();

            //Operaciones graficos
            this.MainWindowViewReservas.operacionActividadGeneral.Click += (sender, e) => this.ActividadGeneral();
            this.MainWindowViewReservas.operacionActividadCliente.Click += (sender, e) => this.ActividadCliente();
            this.MainWindowViewReservas.operacionActividadCamion.Click += (sender, e) => this.ActividadCamion();
            this.MainWindowViewReservas.operacionActividadComodidades.Click += (sender, e) => this.ActividadComodidades();

            //Operaciones Clientes
            if (!inClientes) {
                this.MainWindowViewReservas.operacionGestionarClientes.Click += (sender, e) => this.ActividadGestionClientes();
            }
            //Operaciones Reservas
            if (!inTransportes)
            {
                this.MainWindowViewReservas.operacionGestionarReservas.Click += (sender, e) => this.ActividadGestionReservas();
            }
            this.MainWindowViewReservas.operacionGestionarReservasForm.Click += (sender, e) => {
                MainWindowViewReservas.dialogosGrande.Controls.Remove(MainWindowViewReservas.dialogos);
                MainWindowViewReservas.dialogos = MainWindowViewReservas.BoxAdd;
                MainWindowViewReservas.dialogosGrande.Controls.Add(MainWindowViewReservas.dialogos);
            };
            //Operaciones graficos
            this.generalGraf = new GeneralChart();

        }

        private void ActividadGestionClientes()
        {
            //Form clientes = new Form();

            //clientes.AddOwnedForm(MainWindowViewClientes);

            this.MainWindowViewClientes = new MainWindowViewClientes();

            this.MainWindowViewClientes.CreateCliente.Click += (sender, e) => this.AddClient();
            this.MainWindowViewClientes.RemoveCliente.Click += (sender, e) => this.RemoveClient();
            this.MainWindowViewClientes.EditFindCliente.Click += (sender, e) => this.EditFindClient();
            this.MainWindowViewClientes.EditCliente.Click += (sender, e) => this.EditClient();

            Clear();
            ActualizarLista();
            //MainWindowViewClientes.Show();
        }

        private void ActividadGestionReservas()
        {
            this.MainWindowViewReservas = new MainWindowViewReservas();

            this.MainWindowViewReservas.CreateReserva.Click += (sender, e) => {


                this.Crear();

            };
            this.MainWindowViewReservas.RemoveReserva.Click += (sender, e) => this.RemoveReserv();
            this.MainWindowViewReservas.EditFindReserva.Click += (sender, e) => this.EditFindReserv();
            this.MainWindowViewReservas.EditReserva.Click += (sender, e) => this.EditReserv();

            ClearReservas();
            ActualizarListaReservas();
        }
        public void mostrarTodosLosTransportes()
        {
            RegReservasBusqueda = new List<Reservas>(
            from Reservas in RegReservas
            where DateTime.Compare(Reservas.Fentrega, DateTime.Today) >= 0
            orderby Reservas.IdTransporte
            select Reservas);

            ActualizarListaReservasBusqueda();
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

        /***********************************************************************************************************************
        /***********************************************************************************************************************
         ************************************************** Métodos búsqueda ************************************ ***************
        /***********************************************************************************************************************/
        // Inicio Transportes pendientes: Mostrará todas los transportes, para todo la flota o por camión, para los próximos cinco días
        private void transportePendientes()
        {
            MainWindowViewReservas.dialogosGrande.Controls.Remove(MainWindowViewReservas.dialogos);
            MainWindowViewReservas.dialogos = MainWindowViewReservas.buildPanelTransportesPendientes();
            MainWindowViewReservas.dialogosGrande.Controls.Add(MainWindowViewReservas.dialogos);
        }
        private void DTPSearch()
        {
            var matricula = this.MainWindowViewReservas.Matricula;
            //System.Console.WriteLine(matricula);
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

            ActualizarListaReservasBusqueda();

        }

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

            //ActualizaListaFlota(camionesDisponibles);

            /*
            MainWindowView.panelPrincipal.Controls.Remove(MainWindowView.panelLista);

            MainWindowView.panelLista = MainWindowView.panelListaFlota;
            MainWindowView.panelPrincipal.Controls.Add(MainWindowView.panelLista);

            MainWindowView.panelOpciones.Controls.Remove(MainWindowView.panelOpcionesPoner);
            MainWindowView.panelOpcionesPoner = MainWindowView.panelOpcionesFlota;
            MainWindowView.panelOpciones.Controls.Add(MainWindowView.panelOpcionesPoner);

            this.MainWindowView.Width = MainWindowView.grdListaFlota.Columns.GetColumnsWidth(0) + 20;
            this.MainWindowView.Height = MainWindowView.grdListaFlota.Rows.GetRowsHeight(0) + 84 + MainWindowView.panelOpciones.Height;*/

        }

        //Inicio Reservas por cliente: Mostrará todas los transportes para un cliente, pasadas o pendientes.
        private void transportesPorCliente()
        {
            MainWindowViewReservas.dialogosGrande.Controls.Remove(MainWindowViewReservas.dialogos);
            MainWindowViewReservas.dialogos = MainWindowViewReservas.buildPanelTransporteCliente();
            MainWindowViewReservas.dialogosGrande.Controls.Add(MainWindowViewReservas.dialogos);
        }
        private void DTCSearch()
        {
            var nifClienteSeleccionado = this.MainWindowViewReservas.Cliente;
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

            ActualizarListaReservasBusqueda();

        }

        //Inicio Reservas por camión: Mostrará todas los transportes, pasados o pendientes, para todo la flota o por camión.
        private void reservasPorCamion()
        {
            MainWindowViewReservas.dialogosGrande.Controls.Remove(MainWindowViewReservas.dialogos);
            MainWindowViewReservas.dialogos = MainWindowViewReservas.buildPanelReservasCamion();
            MainWindowViewReservas.dialogosGrande.Controls.Add(MainWindowViewReservas.dialogos);
        }
        private void DRCSearch()
        {
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

        //Inicio Reservas por cliente: Mostrará todas las reservas para una persona
        private void reservasPorCliente()
        {
            MainWindowViewReservas.dialogosGrande.Controls.Remove(MainWindowViewReservas.dialogos);
            MainWindowViewReservas.dialogos = MainWindowViewReservas.buildPanelReservasCliente();
            MainWindowViewReservas.dialogosGrande.Controls.Add(MainWindowViewReservas.dialogos);
        }

        private void RPCSearch()
        {
            var anhosSeleccionado = this.MainWindowViewReservas.Anho4;

            RegReservasBusqueda = new List<Reservas>(
            from reserva in RegReservas
            where reserva.Cliente.Nif == this.MainWindowViewReservas.idDni && (anhosSeleccionado.Contains(reserva.Fentrega.Year.ToString()) || anhosSeleccionado.Equals(""))
            orderby reserva.IdTransporte
            select reserva);

            ActualizarListaReservasBusqueda();

        }
        //Fin Reservas por cliente: Mostrará todas las reservas para una persona

        //Inicio Ocupación: muestra los camiones con transportes realizados, para una determinada fecha o para un año completo.
        private void ocupacion()
        {
            MainWindowViewReservas.dialogosGrande.Controls.Remove(MainWindowViewReservas.dialogos);
            MainWindowViewReservas.dialogos = MainWindowViewReservas.buildPanelOcupacion();
            MainWindowViewReservas.dialogosGrande.Controls.Add(MainWindowViewReservas.dialogos);
        }

        private void OASearch()
        {
            var anhosSeleccionado = this.MainWindowViewReservas.Anho5;

            RegReservasBusqueda = new List<Reservas>(
            from reserva in RegReservas
            where(anhosSeleccionado.Contains(reserva.Fentrega.Year.ToString()) || anhosSeleccionado.Equals(""))
            orderby reserva.IdTransporte
            select reserva);

            ActualizarListaReservasBusqueda();

        }

        private void OFSearch()
        {
            var fechaSeleccionada = this.MainWindowViewReservas.Fecha5;

            RegReservasBusqueda = new List<Reservas>(
            from reserva in RegReservas
            where (DateTime.Compare(reserva.Fentrega, fechaSeleccionada) < 0)    
            orderby reserva.IdTransporte
            select reserva);
            ActualizarListaReservasBusqueda();

        }
        //Fin ocupacion: muestra los camiones con transportes realizados, para una determinada fecha o para un año completo.
 
        /* Métodos de gráficos */

        private int busquedaGeneralMesesGrafico(int mes)
        {
            StringBuilder toret = new StringBuilder();

            var dataList = new List<Reservas>(
                from reserva in RegReservas
                where (reserva.FechaContratacion.Month == mes)
                orderby reserva.Fentrega
                select reserva);

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

        //Metodos Gestion Clientes
        private void RemoveClient()
        {
            RegClientes.RemoveAt(MainWindowViewClientes.evt.RowIndex);
            ActualizarLista();
        }

        private void EditFindClient()
        {
            try
            {
                Cliente c = RegClientes[MainWindowViewClientes.evt.RowIndex];

                MainWindowViewClientes.EdNif.Text = c.Nif;
                MainWindowViewClientes.EdNif.ReadOnly = true;
                MainWindowViewClientes.EdName.Text = c.Nombre;
                MainWindowViewClientes.EdTlf.Text = c.Telefono;
                MainWindowViewClientes.EdMail.Text = c.Email;
                MainWindowViewClientes.EdDirec.Text = c.DireccionPostal;

                MainWindowViewClientes.EditCliente.Enabled = true;
                MainWindowViewClientes.CreateCliente.Enabled = false;
                MainWindowViewClientes.lblCliente.Text = "Editar Cliente";
            }
            catch
            {
                Error("Error recuperando cliente");
            }
        }

        private void EditClient()
        {
            TextBox edNif = MainWindowViewClientes.EdNif;
            TextBox edName = MainWindowViewClientes.EdName;
            TextBox edTlf = MainWindowViewClientes.EdTlf;
            TextBox edMail = MainWindowViewClientes.EdMail;
            TextBox edDirec = MainWindowViewClientes.EdDirec;

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
                        RegClientes.Edit(c);
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
                MainWindowViewClientes.lblCliente.Text = "Nuevo Cliente";
                ActualizarLista();
            }
        }

        private void ActualizarLista()
        {
            MainWindowViewClientes.grdEventsList.Rows.Clear();
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

            MainWindowViewClientes.grdEventsList.Rows.Add(columnData.ToArray());
        }

        private void AddClient()
        {
            TextBox edNif = MainWindowViewClientes.EdNif;
            TextBox edName = MainWindowViewClientes.EdName;
            TextBox edTlf = MainWindowViewClientes.EdTlf;
            TextBox edMail = MainWindowViewClientes.EdMail;
            TextBox edDirec = MainWindowViewClientes.EdDirec;

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
                    if (RegClientes.IsNifUnique(nif))
                    {
                        if (name.Length > 0 && mail.Length > 0 && direc.Length > 0)
                        {
                            Cliente c = new Cliente(nif, name, tlf, mail, direc);
                            RegClientes.Add(c);
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
            MainWindowViewClientes.EdNif.Text = "";
            MainWindowViewClientes.EdName.Text = "";
            MainWindowViewClientes.EdTlf.Text = "";
            MainWindowViewClientes.EdMail.Text = "";
            MainWindowViewClientes.EdDirec.Text = "";
            //MainWindowView.EdNifRemove.Text = "";
            //MainWindowView.EdNifEdit.Text = "";

            MainWindowViewClientes.EdNif.ReadOnly = false;
            MainWindowViewClientes.EditCliente.Enabled = false;
            MainWindowViewClientes.CreateCliente.Enabled = true;
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

            MainWindowViewClientes.EdClientes.Text = toret.ToString();
        }

        private void Error(String msg)
        {
            System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();

            this.MainWindowViewClientes.EdMsg.Text = "ERROR: " + msg;

            t.Interval = 5000;
            t.Tick += new EventHandler(timer_Tick);
            t.Start();

            void timer_Tick(object sender, EventArgs e)
            {
                MainWindowViewClientes.EdMsg.Text = "";
                t.Stop();
            }

        }


        // Metodos Gestion Reservas
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
                cliente = RegClientes.FindByNif(Convert.ToString(edCliente.Text));
                idTrans = Convert.ToString(edIdtrans.Text);
                // TODO: Cambiar por funcion tipo FindByMatricula de RegistroFlota
                //tipoTransp = Convert.ToString(edTipoTransp.Text);
                fcontra = Convert.ToDateTime(edFcontra.Text);
                fsalida = Convert.ToDateTime(edFsalida.Text);
                fentrega = Convert.ToDateTime(edFentrega.Text);
                edia = Convert.ToDouble(edEdia.Text);
                ekm = Convert.ToDouble(edEkm.Text);
                kmRecorridos = Convert.ToDouble(edKmRecorridos.Text);
                iva = Convert.ToDouble(edIVA.Text);
                gas = Convert.ToDouble(edGas.Text);
                suplencia = Convert.ToDouble(edSuplencia.Text);


                if (RegReservas.IsIDTranspUnique(idTrans))
                {
                    if (idTrans.Length > 0)
                    {
                        Reservas r = new Factura(idTrans, cliente, new Flota(2.1,null,null,null,null,null, new DateTime(), new DateTime(),null), fcontra, fsalida, fentrega, edia, ekm, kmRecorridos, gas, iva, suplencia);
                        RegReservas.Add(r);
                        ActualizarLista();
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
            try
            {
                Reservas r = RegReservas[MainWindowViewReservas.evt.RowIndex];
                MainWindowViewReservas.tbIdTransp.Text = r.IdTransporte;
                MainWindowViewReservas.tbIdTransp.ReadOnly = true;
                MainWindowViewReservas.tbCliente.Text = r.Cliente.Nif;
                MainWindowViewReservas.tbTipoTrans.Text = r.TipoTransporte.Tipo;
                MainWindowViewReservas.tbFcontra.Text = r.FechaContratacion.ToString();
                MainWindowViewReservas.tbFsalida.Text = r.Fsalida.ToString();
                MainWindowViewReservas.tbFentrega.Text = r.Fentrega.ToString();
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
            Cliente Cliente;
            Flota tipoTransp;
            DateTime Fcontra, Fsalida, Fentrega;
            double ImporteDia, ImporteKm, kmRecorridos,
                IVA, Gas, Suplencia;

            try
            {

                Cliente = RegClientes.FindByNif(Convert.ToString(EdCliente.Text));
                idTransp = Convert.ToString(EdIdTransp.Text);
                // TODO: Cambiar por funcion tipo FindByMatricula de RegistroFlota
                //tipoTransp = Convert.ToString(EdTipoTransp.Text);
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
                    Reservas r = new Factura(idTransp, Cliente, new Flota(2.1, null, null, null, null, null, new DateTime(), new DateTime(), null), Fcontra, Fsalida, Fentrega, ImporteDia, ImporteKm,
                        kmRecorridos, IVA, Gas, Suplencia);
                    RegReservas.Edit(r);
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
            MainWindowViewReservas.grdEventsList.Rows.Clear();
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
            columnData.Add(reserva.Cliente);
            columnData.Add(reserva.TipoTransporte);
            columnData.Add(reserva.FechaContratacion);
            columnData.Add(reserva.Fsalida);
            columnData.Add(reserva.Fentrega);
            columnData.Add(reserva.ImporteDia);
            columnData.Add(reserva.ImporteKm);
            columnData.Add(reserva.kmRecorridos);
            columnData.Add(reserva.IVA);
            columnData.Add(reserva.Gas);
            columnData.Add(reserva.Suplencia);
            columnData.Add(reserva.PrecioFactura);

            MainWindowViewReservas.grdEventsList.Rows.Add(columnData.ToArray());
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
                MainWindowViewClientes.EdMsg.Text = "";
                t.Stop();
            }

        }

        //Metodos gestion reservas busqueda
        public void ActualizarListaReservasBusqueda()
        {
            MainWindowViewReservas.grdEventsList.Rows.Clear();
            foreach (var reserva in RegReservasBusqueda)
            {
                AddTableEventsListRowWithEvent(reserva);
            }

        }
 
        //Operacion salir
        void Salir()
        {
            RegClientes.GuardaXml();
            RegReservas.GuardaXml();
            Application.Exit();
        }

        public MainWindowView MainWindowView { get; private set; }
        public MainWindowViewClientes MainWindowViewClientes { get; private set; }
        public MainWindowViewReservas MainWindowViewReservas { get; private set; }

        //public static List<Reservas> reservas;
        public static List<Flota> flotas;
        //public static List<Cliente> clientes;

        public static RegistroClientes RegClientes { get; private set; }
        public static RegistroReservas RegReservas { get; private set; }


        //Busqueda
        public DialogoCamiones dialogoCamion { get; private set; }
        public List<Reservas> RegReservasBusqueda;

        //Graficos
        private GeneralChart generalGraf;


        public bool inTransportes;
        public bool inFlota;
        public bool inClientes;
    }
        
}
