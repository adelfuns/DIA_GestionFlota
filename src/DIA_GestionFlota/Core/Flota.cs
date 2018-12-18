namespace GestionFlota.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Flota
    {
        public Flota(double Carga, string Matricula, string Tipo,
               string Marca, string Modelo, double ConsumoKm,
               DateTime FechaAdquisicion, DateTime FechaFabricacion,
               List<String> Comodidades)
        {
            this.Carga = Carga;
            this.Matricula = Matricula;
            this.Tipo = Tipo;
            this.Marca = Marca;
            this.Modelo = Modelo;
            this.ConsumoKm = ConsumoKm;
            this.FechaAdquisicion = FechaAdquisicion;
            this.FechaFabricacion = FechaFabricacion;
            this.Comodidades = Comodidades;
        }

        public override string ToString()
        {
            StringBuilder toret = new StringBuilder();
            toret.AppendLine("---Flota---");
            toret.AppendLine("Carga: " + Carga);

            toret.AppendLine("Matricula: " + Matricula);

            toret.AppendLine("Tipo: " + Tipo);

            toret.AppendLine("Marca: " + Marca);

            toret.AppendLine("Modelo: " + Modelo);

            toret.AppendLine("ConsumoKm: " + ConsumoKm);

            toret.AppendLine("FechaAdquisicion: " + FechaAdquisicion);

            toret.AppendLine("FechaFabricacion: " + FechaFabricacion);
            toret.AppendLine("Comodidades: ");
            if (Comodidades != null)
            {
                foreach (String aux in Comodidades)
                {
                    toret.AppendLine(" " + aux);
                }
            }
            return toret.ToString();
        }

        public bool ComprobarCarga()
        {
            if ((Tipo == "Furgoneta") && Carga > 1.5 
                ||(Tipo == "Camion") && Carga > 25.0 
                ||(Tipo == "Camion Articulado") && Carga > 40.0)
            {
                return false;
            }
            return true;
        }
        public double Carga { get;  set; }
        public string Matricula { get;  set; }
        public string Tipo { get;  set; }
        public string Marca { get;  set; }
        public string Modelo { get; set; }
        public double ConsumoKm { get; set; }
        public DateTime FechaAdquisicion { get;  set; }
        public DateTime FechaFabricacion { get;  set; }
        public List<String> Comodidades { get; set; }

    }
}