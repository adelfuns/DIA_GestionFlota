using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Collections;
using System.Xml.Linq;
using GestionFlota.Core;
using GestionFlota;
namespace GestionFlota.Core
{
    class RegistroReservas : ICollection<Reservas>

    {
        public const string ArchivoXml = "reservas.xml";
        public const string EtqReservas = "Reservas";
        public const string EtqReserva = "reserva";
        public const string EtqCliente = "cliente";
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

        private static RegistroClientes regClientes;



        public RegistroReservas( RegistroClientes reg)
        {
            regClientes = reg;
            this.reservas = new List<Reservas>();
        }

        public void GuardaXml()
        {
            this.GuardaXml(ArchivoXml);
        }

        public void GuardaXml(string nf)
        {
            var doc = new XDocument();
            var root = new XElement(EtqReservas);

            foreach (Reservas r in this.reservas)
            {

                //System.Xml.XmlException: 'El carácter ' ', con valor hexadecimal 0x20, no puede incluirse en un nombre.'

                root.Add(
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

            doc.Add(root);
            doc.Save(nf);
        }

        public static RegistroReservas RecuperaXml()
        {
            return RecuperaXml(ArchivoXml);
        }

        private static Flota flota(Object x)
        {
            return new Flota(2.1, null, null, null, null, 0, DateTime.Now, DateTime.Now, null);
        }

        private static DateTime formatDate(String date)
        {
            return DateTime.ParseExact(date, "dd/MM/yyyy H:mm:ss", null);
        }

        public static RegistroReservas RecuperaXml(string f)
        {
            var toret = new RegistroReservas(regClientes);

            try
            {
                var doc = XDocument.Load(f);

                if (doc.Root != null
                  && doc.Root.Name == EtqReservas)
                {
                    var reservas = doc.Root.Elements(EtqReserva);

                    foreach (XElement reservasxml in reservas)
                    {
                        Reservas r = new Reservas((string)reservasxml.Attribute(EtqIdTrans),
                                            (Cliente)regClientes.FindByNif(reservasxml.Attribute(EtqCliente).Value.ToString()),
                                            //(Flota)reservasxml.Attribute(EtqTipoTrans),
                                            
                                            (Flota)flota(reservasxml.Attribute(EtqTipoTrans).Value.ToString()),
                                            (DateTime)formatDate(reservasxml.Attribute(EtqFcontra).Value.ToString()),
                                            (DateTime)formatDate(reservasxml.Attribute(EtqFsal).Value.ToString()),
                                            (DateTime)formatDate(reservasxml.Attribute(EtqFentrada).Value.ToString()),
                                            (double)reservasxml.Attribute(EtqEdia),
                                            (double)reservasxml.Attribute(EtqEkm),
                                            (double)reservasxml.Attribute(Etqkm),
                                            (double)reservasxml.Attribute(EtqIVA),
                                            (double)reservasxml.Attribute(EtqGas),
                                            (double)reservasxml.Attribute(EtqSuplencia)
                                            );
                        toret.Add(r);
                    }
                }
            }
            catch (XmlException)
            {
                toret.Clear();
            }
            catch (IOException)
            {
                toret.Clear();
            }
            return toret;
        }


        public void Add(Reservas r)
        {
            this.reservas.Add(r);
        }

        public bool Remove(Reservas r)
        {
            return this.reservas.Remove(r);
        }

        public void RemoveAt(int i)
        {
            this.reservas.RemoveAt(i);
        }

        public void AddRange(ICollection<Reservas> r)
        {
            this.reservas.AddRange(r);
        }

        public int Count
        {
            get { return this.reservas.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public void Clear()
        {
            this.reservas.Clear();
        }

        public bool Contains(Reservas r)
        {
            return this.reservas.Contains(r);
        }

        public void CopyTo(Reservas[] v, int i)
        {
            this.reservas.CopyTo(v, i);
        }

        public Reservas FindByIDTransp(String idTransp)
        {
            Reservas toret = null;
            foreach (Reservas r in this.reservas)
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
            foreach (Reservas r in this.reservas)
            {
                if (r.IdTransporte == idTransp)
                {
                    toret = false;
                }
            }
            return toret;
        }

        public void Edit(Reservas r)
        {
            foreach (Reservas aux in this.reservas)
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


        // Enumerador genérico
        IEnumerator<Reservas> IEnumerable<Reservas>.GetEnumerator()
        {
            foreach (var r in this.reservas)
            {
                yield return r;
            }
        }

        // Enumerador básico
        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var r in this.reservas)
            {
                yield return r;
            }
        }
        // Indizador
        public Reservas this[int i]
        {
            get { return this.reservas[i]; }
            set { this.reservas[i] = value; }
        }
        public override string ToString()
        {
            var toret = new StringBuilder();

            foreach (var r in this.reservas)
            {
                toret.AppendLine(r.ToString());
            }

            return toret.ToString();
        }

        public List<Reservas> reservas;
    }
}
