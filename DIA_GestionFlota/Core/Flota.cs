
namespace DIA_GestionFlota
{
    using System;
    class Flota
    {
        public Flota(double Carga, string Matricula, string tipo, 
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
            return "Carga: " + Carga + ", Matricula: " + Matricula
                + ", Tipo: " + Tipo + ", Marca" + Marca + ", Modelo: " +
                Modelo + ", ConsumoKm: " + ConsumoKm + ", FechaAdquisicion: "
                + FechaAdquisicion + ", FechaFabricacion: " + FechaFabricacion
                + ", Comodidades: " + Comodidades.ToString();
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
