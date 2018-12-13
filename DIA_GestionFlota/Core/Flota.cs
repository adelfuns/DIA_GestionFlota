
namespace DIA_GestionFlota
{
    using System;
    using System.Text;

    public class Flota
    {
        public Flota(double Carga, string Matricula, string Tipo, 
            string Marca, string Modelo, string ConsumoKm,
            DateTime FechaAdquisicion, DateTime FechaFabricacion, 
            string[] Comodidades)
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
            foreach (String aux in Comodidades) { 
                toret.AppendLine("- " + aux);
            }   

            return toret.ToString();
        }

        public double Carga { get; }
        public string Matricula { get; }
        public string Tipo { get; }
        public string Marca { get; }
        public string Modelo { get; }
        public string ConsumoKm { get; }
        public DateTime FechaAdquisicion { get; }
        public DateTime FechaFabricacion { get; }
        public string[] Comodidades { get; }

    }
}
