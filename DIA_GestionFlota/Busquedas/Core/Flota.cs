
namespace Busquedas.Core
{
    class Flota
    {
        public Flota(int Carga, string Matricula, string tipo, 
            string Marca, string Modelo, string ConsumoKm, 
            string FechaAdquisicion, string FechaFabricacion, 
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

        private int Carga { get; }
        private string Matricula { get; }
        private string Tipo { get; }
        private string Marca { get; }
        private string Modelo { get; }
        private string ConsumoKm { get; }
        private string FechaAdquisicion { get; }
        private string FechaFabricacion { get; }
        private string[] Comodidades { get; }

    }
}
