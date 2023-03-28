using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseAutomatique.Model.Automates.Etats
{
    public class EtatControleAdmin : Etat
    {
        private bool resetAll;
        public EtatControleAdmin(Caisse caisse, Automate automate) : base(caisse, automate)
        {
            resetAll = false;
        }

        public override string Message => "Borne Désactiver (Contrôle Admin)";

        public override void Action(Evenement e)
        {
            switch (e)
            {
                case Evenement.ANNULE_DERNIER_ARTICLE:
                    {
                        this.Caisse.DeleteProduit();
                        break;
                    }
                case Evenement.ANNULE_COMMANDE:
                    {
                        this.resetAll = true;
                        this.Caisse.Reset();
                        break;
                    }
            }
        }

        public override Etat Transition(Evenement e)
        {
            Etat res = null;
            switch (e)
            {
                case Evenement.QUITTE_CONTROLE_ADMIN:
                    {
                        if (this.resetAll)
                        {
                            res = new EtatAttenteClient(Caisse, Automate);
                        } else
                        {
                            res = new EtatAttenteProduitSuivant(Caisse, Automate);
                        }
                        break;
                    }
                case Evenement.ANNULE_DERNIER_ARTICLE: res = this; break;
                case Evenement.ANNULE_COMMANDE: res = this;break;
            }
            return res;
        }
    }
}
