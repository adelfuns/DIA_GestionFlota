using GestionFlota;
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
        public string TipoTransporte { get; set; }
        public DateTime Fsalida { get; set; } //Fentrega - Fsalida
        public DateTime Fentrega { get; set; }
        public double Suplencia { get; set; }
        public Flota Vehiculo { get; set; }
        // public double Preciofactura { get;  set; }


        List<string> Reserva = new List<string>();


        public static Reservas Crea(string IdTransporte, Cliente Cliente, string tipoTrans, DateTime FContra, DateTime Fsal, DateTime Fent, double EDia, double Ekm, double km, double IVA, double gas, double suplencia, Flota vehiculo)
        {
            Reservas toret = null;

            toret = new Factura(IdTransporte, Cliente, tipoTrans, FContra, Fsal, Fent, EDia, Ekm, km, IVA, gas, suplencia, vehiculo);
            return toret;
        }
        public Reservas(string IdTransp, Cliente Cliente, string tipoTrans, DateTime FContra, DateTime Fsal, DateTime Fent, double EDia, double Ekm, double km, double iva, double gas, double suplencia, Flota vehiculo)
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
            this.Vehiculo = vehiculo;
            // this.PrecioFactura = precioFactura;

        }

        public override string ToString()
        {
            return "Cliente: " + Cliente.Nombre + ", Id: " + IdTransporte + ", Tipo: " + TipoTransporte + ", Fecha Contra: " + FechaContratacion +
                ", Fecha Salida: " + Fsalida + ", Fecha Entrega: " + Fentrega + ", Importe dia: " + ImporteDia + ", Importe kms: " + ImporteKm +
                ", Km Recorridos: " + kmRecorridos + ", IVA: " + IVA + ", Gas: " + Gas + ", Suplencia: " + Suplencia;
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
