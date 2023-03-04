using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gestion_Garage
{
    [Serializable]
    internal abstract class Vehicule : IComparable<Vehicule>
    {
        //Attributs
        public static int globalCarID;
        protected string nom;
        protected decimal prix;
        protected string marque;
        public Option Option;

     
        public int carID { get; private set; }

        private Moteur moteur;

        public string Nom { get ; set; }

        public decimal Prix { get => prix; set => prix = value; }
   



        // constructeur
        public Vehicule()
        {

        }
        public Vehicule(string nom, decimal prix, string marque, Option option, Moteur moteur)
        {

            if (marque == "PEUGEOT" || marque == "RENAULT" || marque == "CITROEN" || marque == "FERRARI"|| marque=="AUDI")
            {
                this.Marque = marque;
            }

            else
            {
                this.Marque = "";
               
            }



            this.Nom = nom;
            this.Prix = prix;
 
            this.Option = option;
            this.Moteur = Moteur;
            this.carID = Interlocked.Increment(ref globalCarID);
            

        }




        // methode

       
        public void AfficherInfos()
        {
            Console.WriteLine("                                ----------------------------------");
            Console.WriteLine("                                Informations du véhicule");
            Console.WriteLine("");
            Console.WriteLine("L 'id du véhicule est : " +carID);
            Console.WriteLine("Son nom est : " + Nom);
            Console.WriteLine("Sa marque est : " + Marque);
            Console.WriteLine("Son prix est : " + Prix+ "euros");
            Moteur.AfficherMoteur();
            Option.AfficherOption();

        }
        public List<Option> optionslist = new List<Option>();

      

        public void AfficherOptions()
        {
            Console.WriteLine("                              --------------------------------------------");
            Console.WriteLine("le moteur de ce " + Nom + "est" + Option.Nom);
            for (int i = 0; i < optionslist.Count; i++)
            {
                Console.WriteLine("le moteur de ce " + Nom + "est: " + optionslist[i].Nom);
            }
        }
        public void AfficherMoteur()
        {
            Console.WriteLine("                    -----------------------");
            Console.WriteLine("le moteur de ce " + Nom + " est : " + Moteur.Type);
        }
        public void AfficherMarque()
        {

            Console.WriteLine("                    -----------------------");
            Console.WriteLine("la marque de ce " + Nom + " est : " + Marque);
        }
        public void AfficherPrixVehicule()
        {
            Console.WriteLine("                    -----------------------");
            Console.WriteLine("la marque de ce " + Nom + " est : " + Prix + "euros");
            Console.WriteLine("la taxe sur ce vehicule est de " + Taxes);


        }
        public void AjouterOptions(Option option)
        {
            this.optionslist.Add(option);
            Console.WriteLine("-- Les options ajouté(es) --");
            option.AfficherOption();

        }
        public abstract void AfficherMoreinfo();
          public abstract decimal Taxes { get; }
       
        public string Marque { get; private set; }
        internal Moteur Moteur { get => moteur; set => moteur = value; }

        /*public void CalculTaxe()
        {

        }*/
        public void PrixTotal()
        {


           decimal Total = 0;

            for (int i = 0; i < optionslist.Count; i++)
            {
                Total = Total + optionslist[i].Prix;
            }

            Total = Total + Taxes + prix;
            Console.WriteLine("                    -----------------------");
            Console.WriteLine("                              TOTAL " + Nom);
            Console.WriteLine("le prix TTC de ce vehicule est de : " + Total);
        }




        public int CompareTo(Vehicule Other_vehicule)
        {

            if (this.Prix == Other_vehicule.Prix)
            {
                return this.Nom.CompareTo(Other_vehicule.Nom);
            }
            return this.Prix.CompareTo(Other_vehicule.Prix);
        }

    }
}

