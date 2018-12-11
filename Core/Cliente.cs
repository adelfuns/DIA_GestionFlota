
namespace DIA_GestionFlota
{
    class Cliente
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
        public string Nombre { get; }
        public string Telefono { get; }
        public string Email { get; }
        public string DireccionPostal { get; }
    }
}
