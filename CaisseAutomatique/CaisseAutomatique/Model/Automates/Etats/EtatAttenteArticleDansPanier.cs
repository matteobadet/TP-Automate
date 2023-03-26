using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseAutomatique.Model.Automates.Etats
{
    public class EtatAttenteArticleDansPanier : Etat
    {
        public EtatAttenteArticleDansPanier(Caisse caisse, Automate automate) : base(caisse, automate)
        {
        }

        public override string Message => "Déposez l'article sur la balance";

        public override void Action(Evenement e)
        {
            
        }

        public override Etat Transition(Evenement e)
        {
            return new EtatAttenteProduitSuivant(Caisse, Automate);
        }
    }
}
