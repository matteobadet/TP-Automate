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
                case Evenement.SCANARTICLE:
                    if(this.Caisse.DernierArticleScanne.IsDenombrable == false)
                    {
                        Caisse.AddProduit();
                    } else
                    {
                        NotifyPropertyChanged("ScanArticleDenombrable");
                    }
                    break;
                case Evenement.PAYE: Caisse.ClearCaisse(); break;
            }
        }

        public override Etat Transition(Evenement e)
        {
            Etat res = null;
            switch (e)
            {
                case Evenement.SCANARTICLE:res= new EtatAttenteArticleDansPanier(Caisse,Automate);break;
                case Evenement.PAYE:res = new EtatFin(Caisse, Automate);break;
                case Evenement.PROBLEME_POIDS: res = new EtatProblemePoids(Caisse, Automate);break;
                case Evenement.SAISIEQUANTITE: res = new EtatSaisieQuantité(Caisse, Automate); break;
                case Evenement.PREND_CONTROLE_ADMIN: res = new EtatControleAdmin(Caisse, Automate); break;
                case Evenement.RESET: res = new EtatAttenteClient(Caisse, Automate);break;
            }
            return res;
        }
    }
}
