using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseAutomatique.Model.Automates.Etats
{
    public class EtatAttenteProduitSuivant : Etat
    {
        public EtatAttenteProduitSuivant(Caisse caisse, Automate automate) : base(caisse, automate)
        {
        }

        public override string Message { get => "Scannez le produit suivant !"; }
        public override void Action(Evenement e)
        {
            switch (e)
            {
                case Evenement.SCANARTICLE: Caisse.AddProduit(); break;
                case Evenement.PAYE: Caisse.ClearCaisse(); break;
            }
        }

        public override Etat Transition(Evenement e)
        {
            Etat res = null;
            switch (e)
            {
                case Evenement.SCANARTICLE:res= new EtatAttenteProduitSuivant(Caisse, Automate);break;
                case Evenement.PAYE:res = new EtatFin(Caisse, Automate);break;
            }
            return res;
        }
    }
}
