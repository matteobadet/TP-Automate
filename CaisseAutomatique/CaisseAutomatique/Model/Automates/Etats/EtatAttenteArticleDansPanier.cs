using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public override string Message => "Déposez les/l'article(s) sur la balance";

        public override void Action(Evenement e)
        {
            
        }

        public override Etat Transition(Evenement e)
        {
            Etat res = null;
            switch (e)
            {
                case Evenement.SCANARTICLE:res = new EtatAttenteProduitSuivant(Caisse, Automate); break;
                case Evenement.PROBLEME_POIDS:res = new EtatProblemePoids(Caisse, Automate); break;
                case Evenement.PREND_CONTROLE_ADMIN:res = new EtatControleAdmin(Caisse, Automate);break;
            }
            return res;
        }
    }
}
