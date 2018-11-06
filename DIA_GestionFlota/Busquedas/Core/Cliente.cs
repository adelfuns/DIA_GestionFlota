
namespace Busquedas
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
        private string Nif { get; }
        private string Nombre { get; }
        private string Telefono { get; }
        private string Email { get; }
        private string DireccionPostal { get; }
    }
}
