using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Garage
{
    public class MenuException : Exception
    {
        public MenuException() : base("Le choix n'est pas compris entre O et 11")
        {
        }
    }
    [Serializable]
    internal class Menu
    {
        public Garage Garage { get; set; }
        public Vehicule Vehicule { get; set; }
        public Option Option { get; set; }
      private string path = "../../../garage.bin";

        public Menu(Garage garage)
        {
            this.Garage = garage;
          
          

        }
        public void start()
        {
            int choix = -1;
            do
            {
                Console.WriteLine(string.Format("********** Gestion de Garage**********"));
                Console.WriteLine(string.Format("1. Afficher les véhicules"));
                Console.WriteLine(string.Format("2. Ajouter un véhicule"));
                Console.WriteLine(string.Format("3. Sélectionner un véhicule"));
                Console.WriteLine(string.Format("4. Supprimer le véhicule"));
                Console.WriteLine(string.Format("5. Afficher les options du véhicule"));
                Console.WriteLine(string.Format("6. Ajouter des options au véhicule"));
                Console.WriteLine(string.Format("7. Supprimer des options au véhicule"));
                Console.WriteLine(string.Format("8. Afficher les options"));
                Console.WriteLine(string.Format("9. Afficher les marques"));
                Console.WriteLine(string.Format("10. Afficher les types de moteurs"));
                Console.WriteLine(string.Format("11. Sauvegarder le garage"));
                Console.WriteLine(string.Format("0. Quitter l'application"));
                Console.WriteLine(string.Format(""));

                try
                {
                    choix = GetChoixMenu();

                    switch (choix)
                    {

                        case 1:
                            AfficherVehicule();
                            break;
                        case 2:
                            AjouterVehicule();
                            break;
                        case 3:
                            SelectionVehicules();
                            break;
                        case 4:
                            SuprrimerVehicules();
                            break;
                        case 5:
                            AfficherOptionVehicules();
                            break;
                        case 6:
                            AjouterOption();
                            break;
                        case 7:
                            SupprimerOptionsVehicule();
                            break;
                        case 8:
                            AfficherOptions();
                            break;
                        case 9:
                            AfficherMarques();
                            break;

                        case 10:
                            AfficherTypesMoteurs();
                            break;
                        case 11:
                            SauvegarderGarages();
                            break;
                        case 12:
                            ChargerGarages();
                            break;
                        case 13:
                            QuitterApplication();
                            break;
                        default: //throw new ArgumentOutOfRangeException(nameof(choix));
                            break;

                    }

                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Erreur : {0}", ex.Message);
                    start();
                }
                catch (MenuException ex)
                {
                    Console.WriteLine("Erreur : {0}", ex.Message);
                    start();
                }

            } while (choix != 0);
            Console.WriteLine(String.Format("Au revoir"));

        }



        public int GetChoix()
        {
            try
            {
                Console.Write("\nVotre choix : ");
                int choix = Int32.Parse(Console.ReadLine());

                return choix;
            }
            catch (FormatException)
            {
                throw new FormatException("Le choix saisie n'est pas un nombre");
            }


        }
        public int GetChoixMenu()
        {
            int choix = GetChoix();

            if (choix < 0 || choix > 11)
            {
                throw new MenuException();
            }

            return choix;
        }
        public void AfficherVehicules()
        {
            Garage.AfficherVehicules();
        }
        public void AjouterVehicule()
        {

            int choixCreation;
            Console.WriteLine("Veuillez entrer le nom du Vehicule");
            string nom = Console.ReadLine();
            Console.WriteLine("Veuillez entrer le prix du vehicule (nombre) € ");
            decimal prix = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Veuillez entrer la marque du vehicule ");
            string marque = Console.ReadLine();
            Moteur Diesel = new Moteur("ESSENCE", 136);
            Option BoiteAuto = new Option("Boite Automatique", 2500);
            Console.WriteLine("Veuillez entrer le type du Vehicule : 1->(Voiture) 2-> (moto)  3->(camion)");
            choixCreation = Convert.ToInt32(Console.ReadLine());
            if (choixCreation == 1)
            {
                Console.WriteLine("Veuillez entrer la puissance de la voiture ");
                int puissance = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Veuillez entrer le nombre de porte de la voiture");
                int NbPorte = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Veuillez entrer le nombre de sieges de la voiture");
                int NbSiege = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Veuillez entrer la taille du coffre de la voiture ");
                int ailleCoffre = Convert.ToInt32(Console.ReadLine());

                Voiture voiture = new Voiture(nom, prix, marque, BoiteAuto, Diesel, puissance, NbPorte, NbSiege, ailleCoffre);
                Console.WriteLine(" Voiture crée");
                Garage.AjouterVehicule(voiture);
            }

            else if (choixCreation == 2)
            {
                Console.WriteLine(" Veuillez entrer le volume cylindré de la moto ");
                int cylindree = Convert.ToInt32(Console.ReadLine());


                Moto moto = new Moto(nom, prix, marque, BoiteAuto, Diesel, cylindree);
                Console.WriteLine(" Moto crée ");
                Garage.AjouterVehicule(moto);
            }
            else if (choixCreation == 3)
            {
                Console.WriteLine("Veuillez entrer le nombre d 'Essieux du camion ");
                int nb_Essieu = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Veuillez rentrer le poid de la charge du camion");
                int poids = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Veuillez entrer le volume de camion");
                int volume = Convert.ToInt32(Console.ReadLine());
                Camion camion = new Camion(nom, prix, marque, BoiteAuto, Diesel, nb_Essieu, poids, volume);
                Console.WriteLine("Camion crée");
                Garage.AjouterVehicule(camion);
            }
        }
        public void SuprrimerVehicules()
        {


            Console.WriteLine(" Veuillez entrer le nom du Vehicule à supprimer ");
            string nom = Console.ReadLine();


            Vehicule vehicule = null;
            if (Garage.VehiculesList.Count > 0)
            {

                for (int i = 0; i < Garage.VehiculesList.Count; i++)
                {
                    if (Garage.VehiculesList[i].Nom == nom)
                    {
                        vehicule = Garage.VehiculesList[i];
                    }
                }

                Garage.SupprimerVehicule(vehicule);
                Console.WriteLine(" Voiture supprimée ");
            }
            else
            {
                Console.WriteLine("\n > On ne peut supprimer de vehicule s'il n'en existe pas !\n");
            }

        }
        public void SelectionVehicules()
        {


            Console.WriteLine(" Veuillez entrer le nom du Vehicule séléctionner ");
            string nom = Console.ReadLine();


            Vehicule vehicule = null;

            if (Garage.VehiculesList.Count > 0)
            {

                for (int i = 0; i < Garage.VehiculesList.Count; i++)
                {
                    if (Garage.VehiculesList[i].Nom == nom)
                    {
                        vehicule = Garage.VehiculesList[i];
                    }

                }

                vehicule.AfficherInfos();
                Console.WriteLine();

            }
            else
            {
                Console.WriteLine("\n > On ne peut séléctionner de vehicule s'il n'en existe pas !\n");
            }

        }

        public void AfficherOptionVehicules()
        {
            Garage.AfficherOptionVehicule();
        }
        public void AjouterOption()
        {
            Console.WriteLine("les options de votre véhicule");
            Console.WriteLine(" Veuillez entrer le nom de votre option  ");
            string nom = Console.ReadLine();

            Console.WriteLine(" Veuillez entrer le prix de votre option  ");
            decimal prix = Convert.ToInt32(Console.ReadLine());

            Option option = new Option(nom, prix);
            Console.WriteLine("Option de votre véhicule créee");
            Garage.AjouterOption(option);

        }


        public void SupprimerOptionsVehicule()
        {
            Garage.SupprimerOptionsVehicule();
        }
        public void AfficherOptions()
        {
            Garage.AjouterOption(Option);
        }
        public void AfficherMarques()
        {
            Garage.AfficherMarque();
        }
        public void AfficherTypesMoteurs()
        {
            Garage.AfficherTypesMoteur();
        }


        public void AfficherVehicule()
        {
            Garage.AfficherVehicules();
        }
          public void SauvegarderGarages()
        {
            SauvegarderGarages();
        }
       

        public  void ChargerGarages()
        {
            try
            {
                Garage = ChargerGarages<Garage>(path);
                Console.WriteLine("**** Votre garage a été correctement recréer ! ****");
            }
            catch (MenuException e) { Console.WriteLine("Err : " + e.ToString()); }
        }


        public void SauvegarderGarages(object toSave, string path)
        {
            // On utilise la classe BinaryFormatter dans le namespace System.Runtime.Serialization.Formatters.Binary.
            BinaryFormatter formatter = new BinaryFormatter();
            // La classe BinaryFormatter ne fonctionne qu'avec un flux, et non pas un TextWriter.
            // Nous allons donc utiliser un FileStream.
            FileStream flux = null;
            try
            {
                // On ouvre le flux en mode création / écrasement de fichier et on
                // donne au flux le droit en écriture seulement.
                flux = new FileStream(path, FileMode.Create, FileAccess.Write);

                // On sérialise                
                formatter.Serialize(flux, toSave);

                // On s'assure que le tout soit écrit dans le fichier.
                flux.Flush();

                Console.WriteLine("Enregistrement bien effectué");
            }
            catch
            {
                Console.WriteLine("Erreur lors de la sauvegarde");
            }
            finally
            {
                // On ferme le flux.
                if (flux != null)
                    flux.Close();
            }

        }

        public static T ChargerGarages<T>(string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream flux = null;
            try
            {
                // On ouvre le fichier en mode lecture seule. De plus, puisqu'on a sélectionné le mode Open,
                // si le fichier n'existe pas, une exception sera levée.                
                flux = new FileStream(path, FileMode.Open, FileAccess.Read);
                return (T)formatter.Deserialize(flux);
            }
            catch
            {
                // On retourne la valeur par défaut du type T.
                return default(T);
            }
            finally
            {
                if (flux != null)
                    flux.Close();
            }


        }


        public void QuitterApplication()
        {
            Environment.Exit(0);
        }










    }

}









