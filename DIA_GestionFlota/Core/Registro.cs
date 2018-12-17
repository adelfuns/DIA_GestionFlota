using GestionFlota.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace GestionFlota.Core
{
    class Registro
    {
        //De Clientes
        private const string archivo = "registro.xml";
        public const string EtqRegistro = "registro";

        public const string EtqClientes = "clientes";
        public const string EtqCliente = "cliente";
        public const string EtqNif = "nif";
        public const string EtqNombre = "nombre";
        public const string EtqTelefono = "telefono";
        public const string EtqEmail = "email";
        public const string EtqDireccionPostal = "direccionPostal";


        //De Reserva
        public const string EtqReservas = "reservas";
        public const string EtqReserva = "reserva";
        public const string EtqTipoTrans = "TipoTrans";
        public const string EtqIdTrans = "IdTrans";
        public const string EtqFcontra = "Fcontra";
        public const string EtqFsal = "Fsal";
        public const string EtqFentrada = "Fentrada";
        public const string EtqEdia = "Edia";
        public const string EtqEkm = "Ekm";
        public const string Etqkm = "km";
        public const string EtqIVA = "IVA";
        public const string EtqSuplencia = "Suplencia";
        public const string EtqGas = "Gas";
        public const string EtqPFactura = "Precio_total";

        //De flota
        public const string EtqFlotas = "flotas";
        public const string EtqFlota = "flota";
        public const string EtqCarga = "carga";
        public const string EtqMatricula = "matricula";
        public const string EtqTipo = "tipo";
        public const string EtqMarca = "marca";
        public const string EtqModelo = "modelo";
        public const string EtqConsumoKm = "consumoKm";
        public const string EtqFechaAdquisicion = "fechaAdquisicion";
        public const string EtqFechaFabricacion = "fechaFabricacion";
        public const string EtqComodidadesWifi = "comodidadesWifi";
        public const string EtqComodidadesBlue = "comodidadesBlue";
        public const string EtqComodidadesAire = "comodidadesAire";
        public const string EtqComodidadesLitera = "comodidadesLitera";
        public const string EtqComodidadesTv = "comodidadesTv";


        public Registro()
        {
            clientes = new List<Cliente>();
            reservas = new List<Reservas>();
            flotaList = new List<Flota>();
        }

        public List<Cliente> GetClientes()
        {
            return clientes;
        }

        public List<Reservas> GetReservas()
        {
            return reservas;
        }

        public List<Flota> GetFlotas()
        {
            return flotaList;
        }

        public void Add(Cliente r)
        {
            clientes.Add(r);
        }

        public void Add(Reservas r)
        {
            reservas.Add(r);
        }

        public void Add(Flota r)
        {
            flotaList.Add(r);
        }

        public bool Remove(Cliente r)
        {
            return clientes.Remove(r);
        }

        public bool Remove(Reservas r)
        {
            return reservas.Remove(r);
        }

        public bool Remove(Flota r)
        {
            return flotaList.Remove(r);
        }

        public void RemoveClienteAt(int i)
        {
            clientes.RemoveAt(i);
        }

        public void RemoveReservaAt(int i)
        {
            reservas.RemoveAt(i);
        }

        public void RemoveFlotaAt(int i)
        {
            flotaList.RemoveAt(i);
        }

        public void ClearClientes()
        {
            clientes.Clear();
        }

        public void ClearReservas()
        {
            reservas.Clear();
        }

        public void ClearFlota()
        {
            flotaList.Clear();
        }

        public void Edit(Cliente c)
        {
            foreach (Cliente aux in clientes)
            {
                if (aux.Nif == c.Nif)
                {
                    aux.Nombre = c.Nombre;
                    aux.Email = c.Email;
                    aux.Telefono = c.Telefono;
                    aux.DireccionPostal = c.DireccionPostal;
                    break;
                }
            }
        }

        public void Edit(Reservas r)
        {
            foreach (Reservas aux in reservas)
            {
                if (aux.IdTransporte == r.IdTransporte)
                {
                    aux.Cliente = r.Cliente;
                    aux.TipoTransporte = r.TipoTransporte;
                    aux.FechaContratacion = r.FechaContratacion;
                    aux.Fsalida = r.Fsalida;
                    aux.Fentrega = r.Fentrega;
                    aux.ImporteDia = r.ImporteDia;
                    aux.ImporteKm = r.ImporteKm;
                    aux.kmRecorridos = r.kmRecorridos;
                    aux.IVA = r.IVA;
                    aux.Gas = r.Gas;
                    aux.Suplencia = r.Suplencia;
                    break;
                }
            }
        }

        public bool Contains(Cliente item)
        {
            return clientes.Contains(item);
        }

        public bool Contains(Reservas item)
        {
            return reservas.Contains(item);
        }

        public bool Contains(Flota item)
        {
            return flotaList.Contains(item);
        }

        public bool ReservaContainsCliente(int c)
        {
            var cliente = clientes[c];
            foreach(Reservas r in reservas)
            {
                if (r.Cliente == cliente)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ReservaContainsFlota(int c)
        {
            var flota = flotaList[c];
            foreach (Reservas r in reservas)
            {
                if (r.TipoTransporte == flota)
                {
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            var toret = new StringBuilder();

            foreach (Cliente v in clientes)
            {
                toret.AppendLine(v.ToString());
            }

            foreach (Reservas r in reservas)
            {
                toret.AppendLine(r.ToString());
            }

            foreach (Flota f in flotaList)
            {
                toret.AppendLine(f.ToString());
            }

            return toret.ToString();
        }

        //Metodos especificos de clientes
        public Cliente FindByNif(String nif)
        {
            Cliente toret = null;
            foreach (Cliente c in clientes)
            {
                if (c.Nif == nif)
                {
                    toret = c;
                }
            }
            return toret;
        }

        public bool IsNifUnique(String nif)
        {
            bool toret = true;
            foreach (Cliente c in clientes)
            {
                if (c.Nif == nif)
                {
                    toret = false;
                }
            }
            return toret;
        }

        //Metodos especificos de reservas
        private static DateTime formatDate(String date)
        {
            return DateTime.ParseExact(date, "dd/MM/yyyy H:mm:ss", null);
        }

        public Reservas FindByIDTransp(String idTransp)
        {
            Reservas toret = null;
            foreach (Reservas r in reservas)
            {
                if (r.IdTransporte == idTransp)
                {
                    toret = r;
                }
            }

            return toret;
        }

        public bool IsIDTranspUnique(String idTransp)
        {
            bool toret = true;
            foreach (Reservas r in reservas)
            {
                if (r.IdTransporte == idTransp)
                {
                    toret = false;
                }
            }
            return toret;
        }

        //Metodos especificos de Flota
        public Flota FindByMatricula(String matricula)
        {
            Flota toret = null;
            foreach (Flota f in flotaList)
            {
                if (f.Matricula == matricula)
                {
                    toret = f;
                }
            }
            return toret;
        }

        public bool IsMatriculaUnique(String matricula)
        {
            bool toret = true;
            foreach (Flota f in flotaList)
            {
                if (f.Matricula == matricula)
                {
                    toret = false;
                }
            }
            return toret;
        }

        public void GuardaXml()
        {
            this.GuardaXml(archivo);
        }

        public void GuardaXml(string nf)
        {
            var doc = new XDocument();
            var root = new XElement(EtqRegistro);
            var clientesXML = new XElement(EtqClientes);
            var reservasXML = new XElement(EtqReservas);
            var flotasXML = new XElement(EtqFlotas);

            //Guarda Clientes en el XML
            foreach (Cliente c in clientes)
            {
                clientesXML.Add(
                    new XElement(EtqCliente,
                            new XAttribute(EtqNif, c.Nif),
                            new XAttribute(EtqNombre, c.Nombre),
                            new XAttribute(EtqTelefono, c.Telefono),
                            new XAttribute(EtqEmail, c.Email),
                            new XAttribute(EtqDireccionPostal, c.DireccionPostal)
                            ));
            }

            //Guarda Flotas en el XML
            foreach (Flota flota in flotaList)
            {
                flotasXML.Add(
                   new XElement(EtqFlota,
                   new XAttribute(EtqMatricula, flota.Matricula),
                   new XAttribute(EtqTipo, flota.Tipo),
                   new XAttribute(EtqMarca, flota.Marca),
                   new XAttribute(EtqModelo, flota.Modelo),
                   new XAttribute(EtqConsumoKm, flota.ConsumoKm.ToString()),
                   new XAttribute(EtqFechaAdquisicion, flota.FechaAdquisicion.ToString()),
                   new XAttribute(EtqFechaFabricacion, flota.FechaFabricacion.ToString()),
                   new XAttribute(EtqCarga, flota.Carga.ToString()),
                   new XAttribute(EtqComodidadesWifi, flota.Comodidades.Contains("Wifi").ToString()),
                   new XAttribute(EtqComodidadesBlue, flota.Comodidades.Contains("Conexion Bluetooth").ToString()),
                   new XAttribute(EtqComodidadesAire, flota.Comodidades.Contains("Aire Acondicionado").ToString()),
                   new XAttribute(EtqComodidadesLitera, flota.Comodidades.Contains("Litera").ToString()),
                   new XAttribute(EtqComodidadesTv, flota.Comodidades.Contains("Tv").ToString())
                   ));


            }

            //Guarda Reservas en el XML
            foreach (Reservas r in reservas)
            {
                reservasXML.Add(
                    new XElement(EtqReserva,
                            new XAttribute(EtqIdTrans, r.IdTransporte),
                            new XAttribute(EtqCliente, r.Cliente.Nif),
                            new XAttribute(EtqTipoTrans, r.TipoTransporte.Matricula),
                            new XAttribute(EtqFcontra, r.FechaContratacion.ToString()),
                            new XAttribute(EtqFsal, r.Fsalida.ToString()),
                            new XAttribute(EtqFentrada, r.Fentrega.ToString()),
                            new XAttribute(EtqEdia, r.ImporteDia.ToString()),
                            new XAttribute(EtqEkm, r.ImporteKm.ToString()),
                            new XAttribute(Etqkm, r.kmRecorridos.ToString()),
                            new XAttribute(EtqIVA, r.IVA.ToString()),
                            new XAttribute(EtqGas, r.Gas.ToString()),
                            new XAttribute(EtqSuplencia, r.Suplencia.ToString()),
                            new XAttribute(EtqPFactura, r.PrecioFactura.ToString())
                            ));
            }

            root.Add(clientesXML);
            root.Add(flotasXML);
            root.Add(reservasXML);
            doc.Add(root);
            doc.Save(nf);
        }

        public void RecuperaXml()
        {
            RecuperaXml(archivo);
        }

        public void RecuperaXml(string f)
        {
            clientes = new List<Cliente>();
            reservas = new List<Reservas>();
            flotaList = new List<Flota>();

            try
            {
                var doc = XDocument.Load(f);

                if (doc.Root != null
                  && doc.Root.Name == EtqRegistro)
                {
                    //Recuperamos Clientes
                    var clientesXML = doc.Root.Elements(EtqClientes).Elements(EtqCliente);

                    foreach (XElement clienteXml in clientesXML)
                    {
                        Cliente c = new Cliente((string)clienteXml.Attribute(EtqNif),
                                            (string)clienteXml.Attribute(EtqNombre),
                                            (string)clienteXml.Attribute(EtqTelefono),
                                            (string)clienteXml.Attribute(EtqEmail),
                                            (string)clienteXml.Attribute(EtqDireccionPostal)
                                            );

                        clientes.Add(c);
                    }

                    //Recuperamos Flotas
                    var flota = doc.Root.Elements(EtqFlotas).Elements(EtqFlota);
                    foreach (XElement FlotaXml in flota)
                    {
                        /*COMPROBACION DE SI EL XML ESTA BIEN GENERADO*/
                        if ((FlotaXml.Attribute(EtqCarga) == null) ||
                            (FlotaXml.Attribute(EtqMatricula) == null) ||
                            (FlotaXml.Attribute(EtqTipo) == null) ||
                            (FlotaXml.Attribute(EtqMarca) == null) ||
                            (FlotaXml.Attribute(EtqModelo) == null) ||
                            (FlotaXml.Attribute(EtqConsumoKm) == null) ||
                            (formatDate(FlotaXml.Attribute(EtqFechaAdquisicion).Value.ToString()) == null) ||
                            (formatDate(FlotaXml.Attribute(EtqFechaFabricacion).Value.ToString()) == null))
                        {
                            throw new Exception("XML mal generado");
                        }
                        /*FIN COMPROBACION DE SI EL XML ESTA BIEN GENERADO*/
                        List<string> Comodidades = new List<string> { };
                        if ((FlotaXml.Attribute(EtqComodidadesWifi) != null) && FlotaXml.Attribute(EtqComodidadesWifi).Value.ToString().Equals("True"))
                        {
                            Comodidades.Add("Wifi");
                        }
                        if ((FlotaXml.Attribute(EtqComodidadesBlue) != null) && (FlotaXml.Attribute(EtqComodidadesBlue).Value.ToString().Equals("True")))
                        {
                            Comodidades.Add("Conexion Bluetooth");
                        }
                        if ((FlotaXml.Attribute(EtqComodidadesAire) != null) && (FlotaXml.Attribute(EtqComodidadesAire).Value.ToString().Equals("True")))
                        {
                            Comodidades.Add("Aire Acondicionado");
                        }
                        if ((FlotaXml.Attribute(EtqComodidadesLitera) != null) && (FlotaXml.Attribute(EtqComodidadesLitera).Value.ToString().Equals("True")))
                        {
                            Comodidades.Add("Litera");
                        }
                        if ((FlotaXml.Attribute(EtqComodidadesTv) != null) && (FlotaXml.Attribute(EtqComodidadesTv).Value.ToString().Equals("True")))
                        {
                            Comodidades.Add("Tv");
                        }

                        flotaList.Add(new Flota(
                        Convert.ToDouble(FlotaXml.Attribute(EtqCarga).Value.ToString()),
                        (string)FlotaXml.Attribute(EtqMatricula),
                        (string)FlotaXml.Attribute(EtqTipo),
                        (string)FlotaXml.Attribute(EtqMarca),
                        (string)FlotaXml.Attribute(EtqModelo),
                        Convert.ToDouble(FlotaXml.Attribute(EtqConsumoKm).Value.ToString()),
                        formatDate(FlotaXml.Attribute(EtqFechaAdquisicion).Value.ToString()),
                        formatDate(FlotaXml.Attribute(EtqFechaFabricacion).Value.ToString()),
                        Comodidades));

                        //Console.WriteLine(
                        //Convert.ToDouble(FlotaXml.Attribute(EtqCarga).Value.ToString())+
                        //(string)FlotaXml.Attribute(EtqMatricula)+
                        //(string)FlotaXml.Attribute(EtqTipo)+
                        //(string)FlotaXml.Attribute(EtqMarca)+
                        //(string)FlotaXml.Attribute(EtqModelo)+
                        //Convert.ToDouble(FlotaXml.Attribute(EtqConsumoKm).Value.ToString())+
                        //formatDate(FlotaXml.Attribute(EtqFechaAdquisicion).Value.ToString())+
                        //formatDate(FlotaXml.Attribute(EtqFechaFabricacion).Value.ToString())+
                        //Comodidades);
                    }

                    //Recuperamos Reservas
                    var reservaXML = doc.Root.Elements(EtqReservas).Elements(EtqReserva);

                    foreach (XElement reservasxml in reservaXML)
                    {
                        Reservas r = new Reservas((string)reservasxml.Attribute(EtqIdTrans),
                                            FindByNif(reservasxml.Attribute(EtqCliente).Value.ToString()),
                                            FindByMatricula(reservasxml.Attribute(EtqTipoTrans).Value.ToString()),
                                            (DateTime)formatDate(reservasxml.Attribute(EtqFcontra).Value.ToString()),
                                            (DateTime)formatDate(reservasxml.Attribute(EtqFsal).Value.ToString()),
                                            (DateTime)formatDate(reservasxml.Attribute(EtqFentrada).Value.ToString()),
                                            Convert.ToDouble(reservasxml.Attribute(EtqEdia).Value.ToString()),
                                            Convert.ToDouble(reservasxml.Attribute(EtqEkm).Value.ToString()),
                                            Convert.ToDouble(reservasxml.Attribute(Etqkm).Value.ToString()),
                                            Convert.ToDouble(reservasxml.Attribute(EtqIVA).Value.ToString()),
                                            Convert.ToDouble(reservasxml.Attribute(EtqGas).Value.ToString()),
                                            Convert.ToDouble(reservasxml.Attribute(EtqSuplencia).Value.ToString())
                                            );
                        reservas.Add(r);
                    }
                }
            }
            catch (XmlException)
            {
                clientes.Clear();
                reservas.Clear();
                flotaList.Clear();
            }
            catch (IOException)
            {
                clientes.Clear();
                reservas.Clear();
                flotaList.Clear();
            }
        }

        public void CopyTo(Cliente[] array, int arrayIndex)
        {
            clientes.CopyTo(array, arrayIndex);
        }


        // Indizador
        public Cliente this[int i]
        {
            get { return clientes[i]; }
            set { clientes[i] = value; }
        }

        public static List<Cliente> clientes;
        public static List<Reservas> reservas;
        public static List<Flota> flotaList;
    }
}

