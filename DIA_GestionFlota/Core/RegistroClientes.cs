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
    class RegistroClientes : ICollection<Cliente>
    {
        private const string archivo = "clientes.xml";
        public const string EtqClientes = "clientes";
        public const string EtqCliente = "cliente";
        public const string EtqNif = "nif";
        public const string EtqNombre = "nombre";
        public const string EtqTelefono = "telefono";
        public const string EtqEmail = "email";
        public const string EtqDireccionPostal = "direccionPostal";


        public RegistroClientes()
        {
            this.clientes = new List<Cliente>();
        }

        public RegistroClientes(IEnumerable<Cliente> reaparaciones) : this()
        {
            this.clientes.AddRange(clientes);
        }

        public void Add(Cliente r)
        {
            this.clientes.Add(r);
        }

        public bool Remove(Cliente r)
        {
            return this.clientes.Remove(r);
        }

        public void RemoveAt(int i)
        {
            this.clientes.RemoveAt(i);
        }

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
            foreach (Cliente c in this.clientes)
            {
                if (c.Nif == nif)
                {
                    toret = false;
                }
            }
            return toret;
        }

        public void Edit(Cliente c)
        {
            foreach (Cliente aux in this.clientes)
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

        public void AddRange(IEnumerable<Cliente> clientes)
        {
            this.clientes.AddRange(clientes);
        }

        public int Count
        {
            get { return this.clientes.Count(); }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public void Clear()
        {
            this.clientes.Clear();
        }

        // Enumerador aplicado a Cliente.
        IEnumerator<Cliente> IEnumerable<Cliente>.GetEnumerator()
        {
            foreach (var v in this.clientes)
            {
                yield return v;
            }
        }

        // Enumerador sin tipo
        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var v in this.clientes)
            {
                yield return v;
            }
        }


        public void GuardaXml()
        {
            this.GuardaXml(archivo);
        }

        public void GuardaXml(string nf)
        {
            var doc = new XDocument();
            var root = new XElement(EtqClientes);

            foreach (Cliente c in this.clientes)
            {
                root.Add(
                    new XElement(EtqCliente,
                            new XAttribute(EtqNif, c.Nif),
                            new XAttribute(EtqNombre, c.Nombre),
                            new XAttribute(EtqTelefono, c.Telefono),
                            new XAttribute(EtqEmail, c.Email),
                            new XAttribute(EtqDireccionPostal, c.DireccionPostal)
                            ));
            }

            doc.Add(root);
            doc.Save(nf);
        }

        public static RegistroClientes RecuperaXml()
        {
            return RecuperaXml(archivo);
        }

        public static RegistroClientes RecuperaXml(string f)
        {
            var toret = new RegistroClientes();
            //var toret = GetClientes();

            try
            {
                var doc = XDocument.Load(f);

                if (doc.Root != null
                  && doc.Root.Name == EtqClientes)
                {
                    var clientes = doc.Root.Elements(EtqCliente);

                    foreach (XElement clienteXml in clientes)
                    {
                        Cliente c = new Cliente((string)clienteXml.Attribute(EtqNif),
                                            (string)clienteXml.Attribute(EtqNombre),
                                            (string)clienteXml.Attribute(EtqTelefono),
                                            (string)clienteXml.Attribute(EtqEmail),
                                            (string)clienteXml.Attribute(EtqDireccionPostal)
                                            );

                        toret.Add(c);
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

        public override string ToString()
        {
            var toret = new StringBuilder();

            foreach (Cliente v in this.clientes)
            {
                toret.AppendLine(v.ToString());
            }

            return toret.ToString();
        }

        public bool Contains(Cliente item)
        {
            return this.clientes.Contains(item);
        }

        public void CopyTo(Cliente[] array, int arrayIndex)
        {
            this.clientes.CopyTo(array, arrayIndex);
        }

        // Indizador
        public Cliente this[int i]
        {
            get { return this.clientes[i]; }
            set { this.clientes[i] = value; }
        }

        private List<Cliente> clientes;
    }
}

