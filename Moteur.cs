using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gestion_Garage
{
    /*
    public enum MoteurType
{
        DIESEL,
        ESSENCE,
        HYBRIDE,
        ELECTRIQUE


}*/
    [Serializable]

    internal class Moteur
    {
        //public MoteurType  type;
        private string nom;
        public static int globalCarID;
        public int puisssance;
        public int carID { get; private set; }
        private string type;
        public string Nom { get => nom; set => nom = value; }
        public int Puisssance { get => puisssance; set => puisssance = value; }
        public string Type { get => type; set => type = value; }

        //public MoteurType Type { get ; set; }


        public Moteur()
        {

        }
       

        public Moteur( string type, int puissance)
        {
            this.carID = Interlocked.Increment(ref globalCarID);
            if (type == "DIESEL" || type == "HYBRIDE" || type == "ELECTRIQUE" || type == "ESSENCE")
            {
                this.Type = type;

                this.puisssance = puissance;
            }
            else
            {
                this.type = "";
                this.puisssance = 0;
            }
        
        
            
           

       

        }
        public void AfficherMoteur()
        {
            Console.WriteLine("le moteur est de type : " + Type + " et de puissance " + puisssance + " CF");
        }


    }
}
