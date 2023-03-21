using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseAutomatique.Model.Automates.Etats
{
    public class EtatAttenteProduitSuivant : Etat
    {
        public EtatAttenteProduitSuivant(Caisse caisse) : base(caisse)
        {
        }

        public override string Message { get => "Scannez le produit suivant !"; }
        public override void Action(Evenement e)
        {
            throw new NotImplementedException(); 
        }

        public override Etat Transition(Evenement e)
        {
            throw new NotImplementedException();
        }
    }
}
