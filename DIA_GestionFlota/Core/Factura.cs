using GestionFlota.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace GestionFlota.Core
{

    public class Factura : Reservas
    {
        //public double factura { get; private set; }
        public double EDia { get; private set; } //ppd
        public double Iva { get; private set; }
        public double EKm { get; private set; } //ppkm
        public string IDTransporte { get; private set; } //MIRAR TIPO
        public double KmRecorridos { get; private set; } //km
        public double Gas { get; private set; }
        public Cliente Cliente { get; private set; } //cliente del tipo cliente
        public DateTime FechaContra { get; private set; }
        public Flota TipoTransp { get; private set; }
        public DateTime Fsalida { get; private set; } //Fentrega - Fsalida
        public DateTime Fentrega { get; private set; }
        public double Suplencia { get; private set; }



        public Factura(string IDTrans, Cliente cliente, Flota tipoTrans, DateTime Fcontra, DateTime Fsal, DateTime Fent, double Edia, double Ekm,
             double km, double iva, double gas, double suplencia) :
            base(IDTrans, cliente, tipoTrans, Fcontra, Fsal, Fent, Edia, Ekm, km, iva, gas, suplencia)
        {
            this.Cliente = cliente;
            this.IDTransporte = IDTrans;
            this.TipoTransp = tipoTrans;
            this.Fsalida = Fsal;
            this.Fentrega = Fent;
            this.FechaContra = Fcontra;
            this.EDia = Edia;
            this.EKm = Ekm;
            this.Gas = gas;
            this.Suplencia = suplencia;
            this.IVA = iva;
            this.KmRecorridos = km;
            // this.PrecioFactura = preciofactura;
        }
    }

}
