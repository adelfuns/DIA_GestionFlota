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
        public double Gs { get; private set; }
        public Cliente Client { get; private set; } //cliente del tipo cliente
        public DateTime FechaContra { get; private set; }
        public String TipoTransp { get; private set; }
        public DateTime Fsal { get; private set; } //Fentrega - Fsalida
        public DateTime Fentr { get; private set; }
        public double Sup { get; private set; }
        public Flota Vehiculo { get; set; }



        public Factura(string IDTrans, Cliente cliente, String tipoTrans, DateTime Fcontra, DateTime Fsal, DateTime Fent, double Edia, double Ekm,
             double km, double iva, double gas, double suplencia, Flota vehiculo) :
            base(IDTrans, cliente, tipoTrans, Fcontra, Fsal, Fent, Edia, Ekm, km, iva, gas, suplencia, vehiculo)
        {
            this.Client = cliente;
            this.IDTransporte = IDTrans;
            this.TipoTransp = tipoTrans;
            this.Fsal = Fsal;
            this.Fentr = Fent;
            this.FechaContra = Fcontra;
            this.EDia = Edia;
            this.EKm = Ekm;
            this.Gs = gas;
            this.Sup = suplencia;
            this.IVA = iva;
            this.KmRecorridos = km;
            this.Vehiculo = vehiculo;
            // this.PrecioFactura = preciofactura;
        }
    }

}
