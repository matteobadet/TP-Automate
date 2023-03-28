using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseAutomatique.Model.Automates.Etats
{
    public class EtatAttenteClient : Etat
    {
        public override string Message { get => "Bonjour, scannez votre premier article!";}
        public EtatAttenteClient(Caisse caisse,Automate automate) : base(caisse, automate)
        {
        }
        public override Etat Transition(Evenement e)
        {
            Etat res = null;
            switch (e)
            {
                case Evenement.SCANARTICLE:res =new EtatAttenteArticleDansPanier(Caisse, Automate);break;
                case Evenement.PROBLEME_POIDS:res = new EtatProblemePoids(Caisse, Automate);break;
                case Evenement.SAISIEQUANTITE:res = new EtatSaisieQuantité(Caisse, Automate);break;
                case Evenement.PREND_CONTROLE_ADMIN: res = new EtatControleAdmin(Caisse, Automate); break;
            }
            return res;
        }

        public override void Action(Evenement e)
        {
            switch (e)
            {
                case Evenement.SCANARTICLE:
                    Caisse.AddProduit();
                    break;
                case Evenement.SAISIEQUANTITE:
                    NotifyPropertyChanged("ScanArticleDenombrable");
                    break;
            }
        }
    }
}
