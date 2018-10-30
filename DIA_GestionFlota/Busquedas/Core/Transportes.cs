namespace Busquedas
{
    class Transportes
    {
        public Transportes(string idTransporte, Flota tipoTransporte, Cliente cliente, string fechaContratacion, string kmRecorridos, string fechaSalida, string fechaEntrega, string importePorDia, string importePorKilometro, int ivaAplicado)
        {
            IdTransporte = idTransporte;
            TipoTransporte = tipoTransporte;
            Cliente = cliente;
            FechaContratacion = fechaContratacion;
            KmRecorridos = kmRecorridos;
            FechaSalida = fechaSalida;
            FechaEntrega = fechaEntrega;
            ImportePorDia = importePorDia;
            ImportePorKilometro = importePorKilometro;
            IvaAplicado = ivaAplicado;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        private string IdTransporte { get; }
        private Flota TipoTransporte { get; }
        private Cliente Cliente { get; }
        private string FechaContratacion { get; }
        private string KmRecorridos { get; }
        private string FechaSalida { get; }
        private string FechaEntrega { get; }
        private string ImportePorDia { get; }
        private string ImportePorKilometro { get; }
        private int IvaAplicado { get; }

    }
}
