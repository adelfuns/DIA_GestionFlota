namespace ProyectoFlota.Core
{
    using System;
    using System.Collections.Generic;
    using System.Xml;
    using System.Collections;
    using System.Text;
    using System.IO;
    using System.Xml.Linq;
    class ListaFlota : ICollection<Flota>
    {
        public static List<Flota> flotaList;
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
            return flotaList.Remove(flota);
        }

        public void RemoveAt(int i)
        {
            flotaList.RemoveAt(i);
        }

        public int Count
        {
            get { return flotaList.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }
        public static void GuardaXml()
        {
            GuardaXml(ArchivoXml);
        }
        public static void GuardaXml(string nf)
        {
            var doc = new XDocument();
            var root = new XElement(EtqFlota);

            foreach (Flota flota in flotaList)
            {
                 root.Add(
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

            doc.Add(root);
            doc.Save(nf);
            //Console.WriteLine(File.ReadAllText(nf));
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
                        /*COMPROBACION DE SI EL XML ESTA BIEN GENERADO*/
                        if((FlotaXml.Attribute(EtqCarga) == null) ||
                            (FlotaXml.Attribute(EtqMatricula) == null) ||
                            (FlotaXml.Attribute(EtqTipo) == null) ||
                            (FlotaXml.Attribute(EtqMarca) == null) ||
                            (FlotaXml.Attribute(EtqModelo) == null) ||
                            (FlotaXml.Attribute(EtqConsumoKm) == null) ||
                            (FlotaXml.Attribute(EtqFechaAdquisicion) == null) ||
                            ((System.DateTime)FlotaXml.Attribute(EtqFechaFabricacion) == null))
                        {
                            throw new Exception("XML mal generado");
                        }
                        /*FIN COMPROBACION DE SI EL XML ESTA BIEN GENERADO*/
                        List<string> Comodidades = new List<string>();
                        if ((FlotaXml.Attribute(EtqComodidadesWifi) != null) && (FlotaXml.Attribute(EtqComodidadesWifi).ToString().Equals("true")))
                        {
                            Comodidades.Add("Wifi");
                        }
                        if ((FlotaXml.Attribute(EtqComodidadesBlue) != null) && (FlotaXml.Attribute(EtqComodidadesBlue).ToString().Equals("true")))
                        {
                            Comodidades.Add("Conexion Bluetooth");
                        }
                        if ((FlotaXml.Attribute(EtqComodidadesAire) != null) && (FlotaXml.Attribute(EtqComodidadesAire).ToString().Equals("true")))
                        {
                            Comodidades.Add("Aire Acondicionado");
                        }
                        if ((FlotaXml.Attribute(EtqComodidadesLitera) != null) && (FlotaXml.Attribute(EtqComodidadesLitera).ToString().Equals("true")))
                        {
                            Comodidades.Add("Litera");
                        }
                        if ((FlotaXml.Attribute(EtqComodidadesTv) != null) && (FlotaXml.Attribute(EtqComodidadesTv).ToString().Equals("true")))
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
            flotaList.Clear();
        }

        public bool Contains(Flota flota)
        {
            return flotaList.Contains(flota);
        }

        public void CopyTo(Flota[] array, int arrayIndex)
        {
            flotaList.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Flota> GetEnumerator()
        {
            foreach (var v in flotaList)
            {
                yield return v;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var v in flotaList)
            {
                yield return v;
            }
        }
    }
}
