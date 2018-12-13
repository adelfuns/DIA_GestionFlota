using DIA_GestionFlota;
using System;
using System.Collections.Generic;

namespace GestionFlota.Core
{
    public class Reservas
    {
        public double ImporteDia { get; set; } //ppd
        public double IVA { get; set; }
        public double ImporteKm { get; set; } //ppkm
        public string IdTransporte { get; } //
        public double kmRecorridos { get; set; } //km
        public double Gas { get; set; }
        public Cliente Cliente { get; set; } //cliente del tipo cliente
        public DateTime FechaContratacion { get; set; }
        public Flota TipoTransporte { get; set; }
        public DateTime Fsalida { get; set; } //Fentrega - Fsalida
        public DateTime Fentrega { get; set; }
        public double Suplencia { get; set; }
        // public double Preciofactura { get;  set; }


        List<string> Reserva = new List<string>();


        public static Reservas Crea(string IdTransporte, Cliente Cliente, Flota tipoTrans, DateTime FContra, DateTime Fsal, DateTime Fent, double EDia, double Ekm, double km, double IVA, double gas, double suplencia)
        {
            Reservas toret = null;

            toret = new Factura(IdTransporte, Cliente, tipoTrans, FContra, Fsal, Fent, EDia, Ekm, km, IVA, gas, suplencia);
            return toret;
        }
        public Reservas(string IdTransp, Cliente Cliente, Flota tipoTrans, DateTime FContra, DateTime Fsal, DateTime Fent, double EDia, double Ekm, double km, double iva, double gas, double suplencia)
        {
            this.Cliente = Cliente;
            this.IdTransporte = IdTransp;
            this.TipoTransporte = tipoTrans;
            this.FechaContratacion = FContra;
            this.Fsalida = Fsal;
            this.Fentrega = Fent;
            this.ImporteDia = EDia;
            this.ImporteKm = Ekm;
            this.kmRecorridos = km;
            this.IVA = iva;
            this.Gas = gas;
            this.Suplencia = suplencia;
            // this.PrecioFactura = precioFactura;

        }

        public double PrecioFactura
        {
            get
            {
                double factura;
                double ppD = this.ImporteDia * 8;
                double ppKm = this.ImporteKm * 3;
                TimeSpan dif = this.Fentrega - this.Fsalida;
                int numd = dif.Days;
                if (numd > 1)
                {
                    this.Suplencia = 2;
                }
                else
                    this.Suplencia = 1;

                return factura = (numd * ppD * this.Suplencia) + (this.kmRecorridos * ppKm) + this.Gas;
            }


        }


    }


}
