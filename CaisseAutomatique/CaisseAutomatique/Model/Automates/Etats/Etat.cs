using CaisseAutomatique.Model.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CaisseAutomatique.Model.Automates.Etats
{
    public abstract class Etat
    {
        private Caisse caisse;

        public Etat(Caisse caisse)
        {
            this.caisse = caisse;
        }

        public Caisse Caisse { get => caisse; }
        public abstract string Message { get; }

        public abstract Etat Transition(Evenement e);
        public abstract void Action(Evenement e);
    }
}
