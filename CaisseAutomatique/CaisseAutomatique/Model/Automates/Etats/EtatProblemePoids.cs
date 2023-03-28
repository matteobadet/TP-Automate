using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseAutomatique.Model.Automates.Etats
{
    public class EtatProblemePoids : Etat
    {
        public EtatProblemePoids(Caisse caisse, Automate automate) : base(caisse, automate)
        {
        }

        public override string Message => "Problème poids.";

        public override void Action(Evenement e)
        {
            
        }

        public override Etat Transition(Evenement e)
        {
            Etat res = null;
            switch (e)
            {
                case Evenement.RESET:res = new EtatAttenteClient(Caisse, Automate);break;
                case Evenement.SCANARTICLE:res = new EtatAttenteProduitSuivant(Caisse, Automate);break;
                case Evenement.PREND_CONTROLE_ADMIN: res = new EtatControleAdmin(Caisse, Automate); break;
            }
            return res;
        }
    }
}
