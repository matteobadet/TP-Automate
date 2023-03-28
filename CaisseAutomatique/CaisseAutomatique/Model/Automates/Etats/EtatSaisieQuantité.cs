using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseAutomatique.Model.Automates.Etats
{
    public class EtatSaisieQuantité : Etat
    {
        public EtatSaisieQuantité(Caisse caisse, Automate automate) : base(caisse, automate)
        {
        }

        public override string Message => "Rentrer le nombre d'article voulue";

        public override void Action(Evenement e)
        {
            if (e == Evenement.SAISIEQUANTITE)
            {
                Caisse.AddProduit(Caisse.QuantiteSaise);
                NotifyPropertyChanged("ScanArticleDenombrable");
            }
        }

        public override Etat Transition(Evenement e)
        {
            return new EtatAttenteArticleDansPanier(Caisse, Automate);
        }
    }
}
