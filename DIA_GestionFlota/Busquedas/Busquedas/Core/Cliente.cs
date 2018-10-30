
namespace Busquedas.Core
{
    class Cliente
    {
    
        private string Nif { get; }
        private string Nombre;
        private string Telefono;
        private string Email;
        private string DireccionPostal;

        public Cliente(string Nif, string Nombre, string Telefono, string Email, string DireccionPostal)
        {
            this.Nif = Nif;
            this.Nombre = Nombre;
            this.Telefono = Telefono;
            this.Email = Email;
            this.DireccionPostal = DireccionPostal;
        }


    }
}
