using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Garage
{
    [Serializable]
    internal class Voiture : Vehicule
    {
        private int  puissanceCF;
        private int nbPorte;
        private int nbSiege;
        private int tailleCoffre;

        public override decimal Taxes => (decimal)(puissanceCF * 10);
        public int PuissanceCF { get => puissanceCF; set => puissanceCF = value; }
        public int NbPorte { get => nbPorte; set => nbPorte = value; }
        public int NbSiege { get => nbSiege; set => nbSiege = value; }
        public int TailleCoffre { get => tailleCoffre; set => tailleCoffre = value; }
       public Voiture() { }
      public Voiture(string nom, decimal prix, string marque, Option option, Moteur moteur,int puissanceCF,
          int NbPOrte, int NbSiege, int TailleCoffre) : base(nom, prix, marque, option, moteur)
        {
            this.puissanceCF=puissanceCF;
            this.TailleCoffre=tailleCoffre;
            this.NbPorte=NbPorte;
            this.NbSiege=NbSiege;
        }

        public override void AfficherMoreinfo()
        {
            Console.WriteLine("                    -----------------------");
            Console.WriteLine("La puissance de ce vehicule est de : " + PuissanceCF + " CF");
            Console.WriteLine("Le nombre de portes de ce vehicule est de : " + nbPorte);
            Console.WriteLine("Le nombre de siege de ce vehicule est de : " + nbSiege);
            Console.WriteLine("La taille du coffre de ce vehicule est de : " + TailleCoffre + " m3");
            Console.WriteLine("La taxe sur ce vehicule est de " + Taxes + " euros");




        }

    }
}