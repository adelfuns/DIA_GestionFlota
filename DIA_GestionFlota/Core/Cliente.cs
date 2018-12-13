
namespace DIA_GestionFlota
{
    public class Cliente
    {
    


        public Cliente(string Nif, string Nombre, string Telefono, string Email, string DireccionPostal)
        {
            this.Nif = Nif;
            this.Nombre = Nombre;
            this.Telefono = Telefono;
            this.Email = Email;
            this.DireccionPostal = DireccionPostal;
        }

        
        public override string ToString()
        {
            return "Nif: " + Nif + ", Nombre: " + Nombre + ", Telefono: " + Telefono + ", Email" + Email + ", DireccionPostal: " + DireccionPostal;
        }
        public string Nif { get; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string DireccionPostal { get; set; }
    }
}
