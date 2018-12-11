using System;
using System.Collections.Generic;
using System.Xml;
using System.Collections;
using System.Text;
using System.IO;
using System.Xml.Linq;
using DIA_GestionFlota;

namespace GestionFlota.Core
{
    class ListaFlota : ICollection<Flota>
    {
        public List<Flota> flotaList;
        public const string ArchivoXml = "ListaFlota.xml";
        public const string EtqFlota = "flota";
        public const string EtqCarga = "carga";
        public const string EtqMatricula = "matricula";
        public const string EtqTipo = "tipo";
        public const string EtqMarca = "marca";
        public const string EtqModelo = "modelo";
        public const string EtqConsumoKm = "consumoKm";
        public const string EtqFechaAdquisicion = "fechaAdquisicion";
        public const string EtqFechaFabricacion = "fechaFabricacion";
        public const string EtqComodidades = "comodidades";
        public const string EtqComodidadesWifi = "comodidadesWifi";
        public const string EtqComodidadesBlue = "comodidadesBlue";
        public const string EtqComodidadesAire = "comodidadesAire";
        public const string EtqComodidadesLitera = "comodidadesLitera";
        public const string EtqComodidadesTv = "comodidadesTv";

        public ListaFlota()
        {
            flotaList = new List<Flota>();
        }


        public void Add(Flota flota)
        {
            flotaList.Add(flota);
        }

        public bool Remove(Flota flota)
        {
            return this.flotaList.Remove(flota);
        }

        public void RemoveAt(int i)
        {
            this.flotaList.RemoveAt(i);
        }

        public int Count
        {
            get { return this.flotaList.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }
        public void GuardaXml()
        {
            this.GuardaXml(ArchivoXml);
        }
        public void GuardaXml(string nf)
        {
            var doc = new XDocument();
            var root = new XElement(EtqFlota);

            foreach (Flota flota in this.flotaList)
            {
                root.Add(
                    new XElement(EtqFlota,
                    new XAttribute(EtqMatricula, flota.Matricula),
                    new XAttribute(EtqTipo, flota.Tipo),
                    new XAttribute(EtqMarca, flota.Marca),
                    new XAttribute(EtqConsumoKm, flota.ConsumoKm),
                    new XAttribute(EtqFechaAdquisicion, flota.FechaAdquisicion),
                    new XAttribute(EtqFechaFabricacion, flota.FechaFabricacion),
                    new XAttribute(EtqCarga, flota.Carga),
                    new XElement(EtqComodidades,
                    new XAttribute(EtqComodidadesWifi, flota.Comodidades.Contains("Wifi")),
                    new XAttribute(EtqComodidadesBlue, flota.Comodidades.Contains("Conexion Bluetooth")),
                    new XAttribute(EtqComodidadesAire, flota.Comodidades.Contains("Aire Acondicionado")),
                    new XAttribute(EtqComodidadesLitera, flota.Comodidades.Contains("Litera")),
                    new XAttribute(EtqComodidadesTv, flota.Comodidades.Contains("Tv"))
                    )));
            }

            doc.Add(root);
            doc.Save(nf);
        }

        public static ListaFlota RecuperaXml(string f)
        {
            var toret = new ListaFlota();
            try
            {
                var doc = XDocument.Load(f);

                if (doc.Root != null
                  && doc.Root.Name == EtqFlota)
                {
                    var flota = doc.Root.Elements(EtqFlota);
                    foreach (XElement FlotaXml in flota)
                    {
                        List<string> Comodidades = new List<string>();
                        if ((bool)FlotaXml.Attribute(EtqComodidadesWifi))
                        {
                            Comodidades.Add("Wifi");
                        }
                        else if ((bool)FlotaXml.Attribute(EtqComodidadesBlue))
                        {
                            Comodidades.Add("Conexion Bluetooth");
                        }
                        else if ((bool)FlotaXml.Attribute(EtqComodidadesAire))
                        {
                            Comodidades.Add("Aire Acondicionado");
                        }
                        else if ((bool)FlotaXml.Attribute(EtqComodidadesLitera))
                        {
                            Comodidades.Add("Litera");
                        }
                        else if ((bool)FlotaXml.Attribute(EtqComodidadesTv))
                        {
                            Comodidades.Add("Tv");
                        }

                        toret.Add(new Flota(
                        (double)FlotaXml.Attribute(EtqCarga),
                        (string)FlotaXml.Attribute(EtqMatricula),
                        (string)FlotaXml.Attribute(EtqTipo),
                        (string)FlotaXml.Attribute(EtqMarca),
                        (string)FlotaXml.Attribute(EtqModelo),
                        (double)FlotaXml.Attribute(EtqConsumoKm),
                        (System.DateTime)FlotaXml.Attribute(EtqFechaAdquisicion),
                        (System.DateTime)FlotaXml.Attribute(EtqFechaFabricacion),
                        Comodidades));

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

        public static ListaFlota RecuperaXml()
        {
            return RecuperaXml(ArchivoXml);
        }

        public void Clear()
        {
            this.flotaList.Clear();
        }

        public bool Contains(Flota flota)
        {
            return this.flotaList.Contains(flota);
        }

        public void CopyTo(Flota[] array, int arrayIndex)
        {
            this.flotaList.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Flota> GetEnumerator()
        {
            foreach (var v in this.flotaList)
            {
                yield return v;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var v in this.flotaList)
            {
                yield return v;
            }
        }
    }
}
