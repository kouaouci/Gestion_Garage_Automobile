
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Garage
{
    [Serializable]
    internal class Camion : Vehicule
    {
        private int nb_Essieu;
        private int poids;
        private int volume;

        public int Nb_Essieu { get => nb_Essieu; set => nb_Essieu = value; }
        public int Poids { get => poids; set => poids = value; }
        public int Volume { get => volume; set => volume = value; }

        public override decimal  Taxes => (nb_Essieu * 50);
        public Camion()
        {
       
        }

        public Camion(string nom, decimal prix, string marque, Option option, Moteur moteur, int nb_Essieu, int poids, int volume)
          : base(nom, prix, marque, option, moteur)

        {
            this.nb_Essieu = nb_Essieu;
            this.poids = poids;
            this.volume = volume;

        }
        public override void AfficherMoreinfo()
        {
            Console.WriteLine("                    -----------------------");
            Console.WriteLine("Le nombre d'essieux est de : " + nb_Essieu);
            Console.WriteLine("Le poids de chargement  est de : " + poids+ " kg");
            Console.WriteLine("Le volume de chargement  est de : " + volume + " m3");
            Console.WriteLine("la taxe sur ce vehicule est de " + Taxes + " euros");
        }

    }
}