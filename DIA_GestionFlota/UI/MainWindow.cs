namespace GestionFlota
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
    using GestionFlota.Core;


    class MainWindow : Form
    {

    public MainWindow()
        {
            //Console.WriteLine(DateTime.Now.ToString());

            Reg = new Registro();
            RegClientes = Reg.GetClientes();
            RegReservas = Reg.GetReservas();
            flotas = Reg.GetFlotas();

            //RegClientes = new RegistroClientes();
            //RegClientes = RegistroClientes.RecuperaXml();

            //RegReservas = new RegistroReservas(RegClientes);
            //RegReservas = RegistroReservas.RecuperaXml();

            //this.MainWindowView = new MainWindowView();

            this.MainWindowViewReservas = new MainWindowViewReservas();
            inTransportes = true;
            inClientes = false;
            inFlota = false;

            //flotas = new ListaFlota();

            this.MainWindowViewReservas.FormClosed += (sender, e) => this.Salir();
            this.MainWindowViewReservas.operacionSalir.Click += (sender, e) => this.Salir();
            this.MainWindowViewReservas.menuAtras.Click += (sender, e) => this.mostrarTodosLosTransportes();
            //this.dialogoGraficoGeneral = new DialogoGraficoGeneral();
            // this.dialogoGraficoCliente = new DialogoGraficoCliente();
            //this.dialogoGraficoCamion = new DialogoGraficoCamion();
            //this.dialogoGraficoComodidades = new DialogoGraficoComodidades();



            this.MainWindowViewReservas.Load += (sender, e) => this.mostrarTodosLosTransportes();

            //Operaciones búsqueda
            //Inicializar dialogos
          //  this.dialogoCamion = new DialogoCamiones();

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

          //  this.dialogoCamion.btSearchCamiones.Click += (sender, e) => this.DDCSearch();

            //Operaciones graficos
            /*
            this.dialogoGraficoGeneral.btGraficoGeneralAnual.Click += (sender, e) => this.ActividadGeneralAnual(); //Grafico
            this.dialogoGraficoGeneral.btGraficoGeneralTotal.Click += (sender, e) => this.ActividadGeneralTotal(); //Grafico
            this.dialogoGraficoCliente.btGraficoGeneralAnual.Click += (sender, e) => this.ActividadClienteAnual(); //Grafico
            this.dialogoGraficoCliente.btGraficoGeneralTotal.Click += (sender, e) => this.ActividadClienteTotal(); //Grafico
            this.dialogoGraficoCamion.btGraficoGeneralAnual.Click += (sender, e) => this.ActividadCamionAnual(); //Grafico
            this.dialogoGraficoCamion.btGraficoGeneralTotal.Click += (sender, e) => this.ActividadCamionTotal(); //Grafico
            this.dialogoGraficoComodidades.btGraficoGeneralAnual.Click += (sender, e) => this.FlotaComodidadesAnual(); //Grafico
            this.dialogoGraficoComodidades.btGraficoGeneralTotal.Click += (sender, e) => this.FlotaComodidadesTotal(); //Grafico
            */
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
                MainWindowViewReservas.dialogos = MainWindowViewReservas.BoxAddReservas;
                MainWindowViewReservas.dialogosGrande.Controls.Add(MainWindowViewReservas.dialogos);
            };
        }

        private void ActividadGestionClientes()
        {
            MainWindowViewReservas.grdEventsList.Controls.Remove(MainWindowViewReservas.grdEventsListAux);
            MainWindowViewReservas.grdEventsListAux = MainWindowViewReservas.grdEventsListClientes;
            MainWindowViewReservas.dialogosGrande.Controls.Add(MainWindowViewReservas.grdEventsListAux);
            MainWindowViewReservas.dialogosGrande.Height = MainWindowViewReservas.grdEventsListClientes.Height;



            this.MainWindowViewReservas.CreateCliente.Click += (sender, e) => this.AddClient();
            this.MainWindowViewReservas.RemoveCliente.Click += (sender, e) => this.RemoveClient();
            this.MainWindowViewReservas.EditFindCliente.Click += (sender, e) => this.EditFindClient();
            this.MainWindowViewReservas.EditCliente.Click += (sender, e) => this.EditClient();

            //Clear();
            //ActualizarLista();
            //MainWindowViewClientes.Show();
        }

        private void ActividadGestionReservas()
        {

            MainWindowViewReservas.grdEventsList.Controls.Remove(MainWindowViewReservas.grdEventsListAux);
            MainWindowViewReservas.grdEventsListAux = MainWindowViewReservas.grdEventsListReservas;
            MainWindowViewReservas.dialogosGrande.Controls.Add(MainWindowViewReservas.grdEventsListAux);
            MainWindowViewReservas.dialogosGrande.Height = MainWindowViewReservas.grdEventsListReservas.Height;

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
 

        //Metodos Gestion Clientes
        private void RemoveClient()
        {
            RegClientes.RemoveAt(MainWindowViewReservas.evt.RowIndex);
            ActualizarLista();
        }

        private void EditFindClient()
        {
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
                cliente = Reg.FindByNif(Convert.ToString(edCliente.Text));
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


                if (Reg.IsIDTranspUnique(idTrans))
                {
                    if (idTrans.Length > 0)
                    {
                        Reservas r = new Factura(idTrans, cliente, new Flota(2.1,null,null,null,null,0, new DateTime(), new DateTime(),null), fcontra, fsalida, fentrega, edia, ekm, kmRecorridos, gas, iva, suplencia);
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

                Cliente = Reg.FindByNif(Convert.ToString(EdCliente.Text));
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
                    Reservas r = new Factura(idTransp, Cliente, new Flota(2.1, null, null, null, null, 0, new DateTime(), new DateTime(), null), Fcontra, Fsalida, Fentrega, ImporteDia, ImporteKm,
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
        /*
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
                var dataList = new List<Reservas>(
                from reservas in RegReservas
                where (reservas.Fentrega.Year.ToString().Equals(anhoSeleccionado))
                orderby reservas.Fentrega
                select reservas);

                this.MainWindowView.Height = 0;

                if (dataList.Count() != 0)
                {

                    MainWindowViewReservas.dialogosGrande.Controls.Remove(MainWindowViewReservas.dialogos);
                    MainWindowViewReservas.BuildPanelGraficoGeneral();
                    MainWindowViewReservas.setDataChart("Mes", "Nº transportes", valuesChartAnual(dataList));
                    MainWindowViewReservas.setDataLegend(emptyValue);
                    MainWindowViewReservas.Chart.Draw();
                    MainWindowViewReservas.dialogos = MainWindowViewReservas.panelGraficoGeneral;
                    MainWindowViewReservas.dialogosGrande.Controls.Add(MainWindowViewReservas.dialogosGrande);
                    this.MainWindowViewReservas.Width = MainWindowViewReservas.Chart.Size.Width;
                    this.MainWindowViewReservas.Height = MainWindowViewReservas.Chart.Size.Height + 220;
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
            IEnumerable<int> data = from transporte in RegReservas
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

            this.MainWindowView.Height = 0;

            if (data.Count() != 0)
            {
                MainWindowViewReservas.dialogosGrande.Controls.Remove(MainWindowViewReservas.dialogos);
                MainWindowViewReservas.BuildPanelGraficoGeneral();
                MainWindowViewReservas.setDataChart("Año", "Nº transportes", valuesChartTotal(distinctData));
                MainWindowViewReservas.setDataLegend(toLegend);
                MainWindowViewReservas.Chart.Draw();
                MainWindowViewReservas.dialogos = MainWindowViewReservas.panelGraficoGeneral;
                MainWindowViewReservas.dialogosGrande.Controls.Add(MainWindowViewReservas.dialogosGrande);
                this.MainWindowViewReservas.Width = MainWindowViewReservas.Chart.Size.Width;
                this.MainWindowViewReservas.Height = MainWindowViewReservas.Chart.Size.Height + 220;
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
                var data = new List<Reservas>(
                from transporte in RegReservas
                where transporte.Cliente.Nif.Equals(nifClienteSeleccionado) && (transporte.Fentrega.Year.ToString().Equals(anhoSeleccionado))
                orderby transporte.IdTransporte
                select transporte);

                this.MainWindowView.Height = 0;

                if (data.Count() != 0)
                {

                    MainWindowViewReservas.dialogosGrande.Controls.Remove(MainWindowViewReservas.dialogos);
                    MainWindowViewReservas.BuildPanelGraficoGeneral();
                    MainWindowViewReservas.setDataChart("Mes", "Nº transportes", valuesChartAnual(data));
                    MainWindowViewReservas.setDataLegend(emptyValue);
                    MainWindowViewReservas.Chart.Draw();
                    MainWindowViewReservas.dialogos = MainWindowViewReservas.panelGraficoGeneral;
                    MainWindowViewReservas.dialogosGrande.Controls.Add(MainWindowViewReservas.dialogosGrande);
                    this.MainWindowViewReservas.Width = MainWindowViewReservas.Chart.Size.Width;
                    this.MainWindowViewReservas.Height = MainWindowViewReservas.Chart.Size.Height + 220;

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
            IEnumerable<int> data = from transporte in RegReservas
                                    where transporte.Cliente.Nif.Equals(nifClienteSeleccionado)
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

            this.MainWindowView.Height = 0;

            if (data.Count() != 0)
            {

                MainWindowViewReservas.dialogosGrande.Controls.Remove(MainWindowViewReservas.dialogos);
                MainWindowViewReservas.BuildPanelGraficoGeneral();
                MainWindowViewReservas.setDataChart("Año", "Nº transportes", valuesChartTotalCliente(distinctData, nifClienteSeleccionado));
                MainWindowViewReservas.setDataLegend(toLegend);
                MainWindowViewReservas.Chart.Draw();
                MainWindowViewReservas.dialogos = MainWindowViewReservas.panelGraficoGeneral;
                MainWindowViewReservas.dialogosGrande.Controls.Add(MainWindowViewReservas.dialogosGrande);
                this.MainWindowViewReservas.Width = MainWindowViewReservas.Chart.Size.Width;
                this.MainWindowViewReservas.Height = MainWindowViewReservas.Chart.Size.Height + 220;

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
                var data = new List<Reservas>(
                from transporte in RegReservas
                where (matriculaCamionSeleccionado.Substring(0, 3).Equals(transporte.IdTransporte.Substring(4, 3)) &&
                        matriculaCamionSeleccionado.Substring(3, 4).Equals(transporte.IdTransporte.Substring(0, 4))) &&
                        (transporte.Fentrega.Year.ToString().Equals(anhoSeleccionado))
                orderby transporte.IdTransporte
                select transporte);

                this.MainWindowView.Height = 0;

                if (data.Count() != 0)
                {
                    MainWindowViewReservas.dialogosGrande.Controls.Remove(MainWindowViewReservas.dialogos);
                    MainWindowViewReservas.BuildPanelGraficoGeneral();
                    MainWindowViewReservas.setDataChart("Mes", "Nº transportes", valuesChartAnual(data));
                    MainWindowViewReservas.setDataLegend(emptyValue);
                    MainWindowViewReservas.Chart.Draw();
                    MainWindowViewReservas.dialogos = MainWindowViewReservas.panelGraficoGeneral;
                    MainWindowViewReservas.dialogosGrande.Controls.Add(MainWindowViewReservas.dialogosGrande);
                    this.MainWindowViewReservas.Width = MainWindowViewReservas.Chart.Size.Width;
                    this.MainWindowViewReservas.Height = MainWindowViewReservas.Chart.Size.Height + 220;


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
            IEnumerable<int> data = from transporte in RegReservas
                                    where (matriculaCamionSeleccionado.Substring(0, 3).Equals(transporte.IdTransporte.Substring(4, 3)) &&
                                            matriculaCamionSeleccionado.Substring(3, 4).Equals(transporte.IdTransporte.Substring(0, 4)))
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

            this.MainWindowView.Height = 0;

            if (data.Count() != 0)
            {

                MainWindowViewReservas.dialogosGrande.Controls.Remove(MainWindowViewReservas.dialogos);
                MainWindowViewReservas.BuildPanelGraficoGeneral();
                MainWindowViewReservas.setDataChart("Año", "Nº transportes", valuesChartTotalCamion(distinctData, matriculaCamionSeleccionado));
                MainWindowViewReservas.setDataLegend(toLegend);
                MainWindowViewReservas.Chart.Draw();
                MainWindowViewReservas.dialogos = MainWindowViewReservas.panelGraficoGeneral;
                MainWindowViewReservas.dialogosGrande.Controls.Add(MainWindowViewReservas.dialogosGrande);
                this.MainWindowViewReservas.Width = MainWindowViewReservas.Chart.Size.Width;
                this.MainWindowViewReservas.Height = MainWindowViewReservas.Chart.Size.Height + 220;


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

                    MainWindowViewReservas.dialogosGrande.Controls.Remove(MainWindowViewReservas.dialogos);
                    MainWindowViewReservas.BuildPanelGraficoGeneral();
                    MainWindowViewReservas.setDataChart("Mes", "Nº camiones", valuesChartAnualComodidades(data));
                    MainWindowViewReservas.setDataLegend(emptyValue);
                    MainWindowViewReservas.Chart.Draw();
                    MainWindowViewReservas.dialogos = MainWindowViewReservas.panelGraficoGeneral;
                    MainWindowViewReservas.dialogosGrande.Controls.Add(MainWindowViewReservas.dialogosGrande);
                    this.MainWindowViewReservas.Width = MainWindowViewReservas.Chart.Size.Width;
                    this.MainWindowViewReservas.Height = MainWindowViewReservas.Chart.Size.Height + 220;
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
                MainWindowViewReservas.dialogosGrande.Controls.Remove(MainWindowViewReservas.dialogos);
                MainWindowViewReservas.BuildPanelGraficoGeneral();
                MainWindowViewReservas.setDataChart("Año", "Nº camiones", valuesChartTotalComodidades(distinctData, comodidadSeleccionada));
                MainWindowViewReservas.setDataLegend(toLegend);
                MainWindowViewReservas.Chart.Draw();
                MainWindowViewReservas.dialogos = MainWindowViewReservas.panelGraficoGeneral;
                MainWindowViewReservas.dialogosGrande.Controls.Add(MainWindowViewReservas.dialogosGrande);
                this.MainWindowViewReservas.Width = MainWindowViewReservas.Chart.Size.Width;
                this.MainWindowViewReservas.Height = MainWindowViewReservas.Chart.Size.Height + 220;
            }
            else
            {
                MainWindowView.panelPrincipal.Controls.Remove(MainWindowView.panelLista);
                this.MainWindowView.Width = 200;
                this.MainWindowView.Height = 200;
            }
        }
        
        */
        //Fin grafico comodidades camion
        //Operacion salir
        void Salir()
        {
            Reg.GuardaXml();
            Application.Exit();
        }

        public MainWindowView MainWindowView { get; private set; }
        public MainWindowViewReservas MainWindowViewReservas { get; private set; }

        public Registro Reg { get; }
        public static List<Flota> flotas;
        public static List<Cliente> RegClientes { get; private set; }
        public static List<Reservas> RegReservas { get; private set; }


        //Busqueda
        public DialogoCamiones dialogoCamion { get; private set; }
        public List<Reservas> RegReservasBusqueda;

        public bool inTransportes;
        public bool inFlota;
        public bool inClientes;


        public DialogoGraficoGeneral dialogoGraficoGeneral { get; private set; } //Graficos
        public DialogoGraficoCliente dialogoGraficoCliente { get; private set; } //Graficos
        public DialogoGraficoCamion dialogoGraficoCamion { get; private set; } //Graficos
        public DialogoGraficoComodidades dialogoGraficoComodidades { get; private set; } //Graficos


        public static string[] emptyValue = new string[12] { "Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic" };





    }

}
