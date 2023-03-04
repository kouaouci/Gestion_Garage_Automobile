using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;


namespace Gestion_Garage
{
   
    internal class Program
    {
        static void Main(string[] args)

        {
            /*Option Phare = new Option("Neon", 10);
            Phare.AfficherOption();

            Option Volant = new Option("volant", 25);
            Volant.AfficherOption();
            Moteur diesel=new Moteur("DIESEL",6);
            diesel.AfficherMoteur();
            Moto moto=new Moto("MotoMoh",20,"AUDI",Phare, diesel,5);
            moto.AfficherInfos();
            Voiture voiture = new Voiture("VoitureKar", 35, "seat", Phare, diesel, 158, 6, 3, 10);
            voiture.AfficherInfos();*/
            Garage g = new Garage("Garage République");
            /* Console.WriteLine("---Les véhicules ajouté(es) --");
             g.AjouterVehicule(voiture);
             g.AjouterVehicule(moto);

             Camion camion = new Camion("CamionRomain",15,"Scania", Phare, diesel,6,3, 10);
             camion.AfficherInfos();
             camion.AjouterOptions(Volant);
             camion.AfficherMoreinfo();
             camion.PrixTotal();*/



            Menu Accueil = new Menu(g);
            Accueil.start();

        }




        






    }
}
