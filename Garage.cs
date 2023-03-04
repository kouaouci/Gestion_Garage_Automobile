using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Gestion_Garage;

namespace Gestion_Garage
{
    internal class VehiculesIsEmptyException : Exception
    {
      
        public VehiculesIsEmptyException() : base("Aucun véhicule présent")
        {

        }
    }
    [Serializable]

    internal class Garage
        {
            private string nom;
            private string Marque;
            private string Moteur;
            private string Option;


            public string Nom { get => nom; set => nom = value; }

            public Garage() { }
            public Garage(string Nom)
            {
                this.Nom = Nom;
                Console.WriteLine("                       --------------------------------");
                Console.WriteLine("                       Garage : " + Nom);
            }
            public List<Vehicule> VehiculesList = new List<Vehicule>();
            public List<Moteur> moteurslist = new List<Moteur>();
            public List<Option> optionslist = new List<Option>();
            // Ajouter une vehicule
            public void AjouterVehicule(Vehicule vehicule)
            {

                VehiculesList.Add(vehicule);
                Console.WriteLine(vehicule.Nom);
            }

            public void AfficherInformation()
            {

                Console.WriteLine("                            ---------------------------------");
                Console.WriteLine("                                  Informations Garage " + Nom);

                foreach (Vehicule vehicule in VehiculesList)
                {
                    Console.WriteLine(" Son nom est : " + vehicule.Nom);

                }
            }
            // afficher voiture
            public void AfficherVoiture()
            {
                foreach (Vehicule vehicule in VehiculesList)
                {
                    if (vehicule is Voiture)
                    {
                        vehicule.AfficherInfos();
                    }


                }
            }


            public void AfficherCamion()
            {
                foreach (Vehicule vehicule in VehiculesList)
                {
                    if (vehicule is Camion)
                    {
                        vehicule.AfficherInfos();
                    }


                }


            }
            public void AfficherMoto()
            {
                foreach (Vehicule vehicule in VehiculesList)
                {
                    if (vehicule is Moto)
                    {
                        vehicule.AfficherInfos();
                    }


                }

            }

            // trier vehicule
            public void trierVehicule()
            {

                VehiculesList.Sort();
            }
            // afficher vehicule 
            public void AfficherVehicules()
            {
                for (int i = 0; i < VehiculesList.Count; i++)
                {

                    Console.WriteLine(string.Format("Vehicule dans le garage {0}: {1} {2}", Nom, VehiculesList[i].Nom, VehiculesList[i].Marque));
                    Console.WriteLine(string.Format(""));

                }

                if (VehiculesList.Count() == 0)
                {
                    throw new VehiculesIsEmptyException();
                }
            }

            // afficher la marque 
            public void AfficherMarque()
            {
                for (int i = 0; i < VehiculesList.Count; i++)
                {
                    Console.WriteLine(string.Format("Liste des marques dans le garage {0} : {1}", Marque, VehiculesList[i].Marque));
                    Console.WriteLine(string.Format(""));
                }
                if (VehiculesList.Count() == 0)
                {
                    throw new VehiculesIsEmptyException();
                }
            }
            // Ajouter un moteur
            public void AjouterMoteur(Moteur moteur)
            {
                moteurslist.Add(moteur);
            }
            // Afficher les types de moteurs
            public void AfficherTypesMoteur()
            {
                for (int i = 0; i < VehiculesList.Count; i++)
                {
                    Console.WriteLine(string.Format("Type du moteur : {0}, ", Moteur, VehiculesList[i].Moteur));
                }
            }
            // Ajouter une options
            public void AjouterOption(Option option)
            {
                optionslist.Add(option);
            }
            // Afficher une option
            public void AfficherOption()
            {
                for (int i = 0; i < optionslist.Count; i++)
                {
                    Console.WriteLine(string.Format("Options présentes du vehicule : {0}", Option, optionslist[i].Nom));
                }
            }
            // afficher options de vehicule
            public void AfficherOptionVehicule()
            {
                for (int i = 0; i < VehiculesList.Count; i++)
                {
                    Console.WriteLine(string.Format("Options du véhicule : {0,}", Option, VehiculesList[i].Option));
                }
            }

            //supprimer une vehicule
            public void SupprimerVehicule(Vehicule vehicule)
            {
                VehiculesList.Remove(vehicule);
            }


            //
            public void SupprimerOptionsVehicule()
            {
                for (int i = 0; i < VehiculesList.Count; i++)
                {

                    Console.WriteLine(string.Format("Options du véhicule :  {0}", Option, VehiculesList[i].Option));
                  VehiculesList.Remove(VehiculesList [i]);
                }


            }





      






    }
}






        


    

