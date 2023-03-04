using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gestion_Garage
{
    [Serializable]
    internal class Option
    {
        public static int globalCarID;
        public string Nom { get; set; }
        decimal prix;
        public int carID { get; private set; }


        public decimal Prix { get => prix; set => prix = value; }

        public Option(string nom, decimal prix)
        {

            this.carID = Interlocked.Increment(ref globalCarID);

            this.Nom = nom;
         this.Prix = prix;
        }

        public void AfficherOption()
        {
            Console.WriteLine(Nom + " est une option qui coute : " + Prix + " euros");
        }

    }
}
