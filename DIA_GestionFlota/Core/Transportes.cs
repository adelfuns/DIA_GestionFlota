namespace DIA_GestionFlota
{
    using System;
    class Transportes
    {
        public Transportes(string idTransporte, Flota tipoTransporte, Cliente cliente, DateTime fechaContratacion, string kmRecorridos, System.DateTime fechaSalida, DateTime fechaEntrega, string importePorDia, string importePorKilometro, int ivaAplicado)
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

        public string IdTransporte { get; }
        public Flota TipoTransporte { get; }
        public Cliente Cliente { get; }
        public DateTime FechaContratacion { get; }
        public string KmRecorridos { get; }
        public System.DateTime FechaSalida { get; }
        public System.DateTime FechaEntrega { get; }
        public string ImportePorDia { get; }
        public string ImportePorKilometro { get; }
        public int IvaAplicado { get; }

    }
}
