namespace DIA_GestionFlota
{
    using System;
    using System.Text;

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
            StringBuilder toret = new StringBuilder();
            toret.AppendLine("---Transporte---");
            toret.AppendLine("IdTransporte: " + IdTransporte);

            toret.AppendLine("Cliente: " + Cliente.ToString());

            toret.AppendLine("FechaContratacion: " + FechaContratacion);

            toret.AppendLine("KmRecorridos: " + KmRecorridos);

            toret.AppendLine("FechaSalida: " + FechaSalida);

            toret.AppendLine("FechaEntrega: " + FechaEntrega);

            toret.AppendLine("ImportePorDia: " + ImportePorDia);

            toret.AppendLine("ImportePorKilometro: " + ImportePorKilometro);

            toret.AppendLine("IvaAplicado: " + IvaAplicado);


            return toret.ToString();
        }


        public string IdTransporte { get; }
        public Flota TipoTransporte { get; }
        public Cliente Cliente { get; }
        public DateTime FechaContratacion { get; }
        public string KmRecorridos { get; }
        public DateTime FechaSalida { get; }
        public DateTime FechaEntrega { get; }
        public string ImportePorDia { get; }
        public string ImportePorKilometro { get; }
        public int IvaAplicado { get; }

    }
}
