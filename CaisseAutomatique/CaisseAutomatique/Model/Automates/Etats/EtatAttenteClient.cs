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
            return new EtatAttenteProduitSuivant(Caisse, Automate);
        }

        public override void Action(Evenement e)
        {
            switch (e)
            {
                case Evenement.SCANARTICLE: Caisse.AddProduit(); break;
            }
        }
    }
}
