using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseAutomatique.Model.Automates.Etats
{
    public class EtatAttenteClient : Etat
    {
        public string Message { get => "Bonjour, scannez votre premier article!";}
        public EtatAttenteClient(Caisse caisse) : base(caisse)
        {
        }
        public override Etat Transition(Evenement e)
        {
            return this;
        }

        public override void Action(Evenement e)
        {
            throw new NotImplementedException();
        }
    }
}
