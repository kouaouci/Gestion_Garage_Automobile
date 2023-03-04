using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Garage
{
    [Serializable]
    internal class Moto : Vehicule

    {

        private int cylindree;

        public int Cylindree { get => cylindree; set => cylindree = value; }
        public override decimal Taxes =>(decimal) Math.Truncate(cylindree * 0.3);
        public Moto()
        {

        }

        public Moto(string nom, decimal prix, string marque, Option option, Moteur moteur, int cylindree) : base (nom,prix, marque, option, moteur)
        {
            this.Cylindree = cylindree;
        }





        public override void AfficherMoreinfo()
        {
            Console.WriteLine("                    -----------------------");
            Console.WriteLine("Le volume du cylindre est de : " + cylindree + " m3");
            Console.WriteLine("la taxe sur ce vehicule est de " + Taxes + "euros");
        }
    }
}
