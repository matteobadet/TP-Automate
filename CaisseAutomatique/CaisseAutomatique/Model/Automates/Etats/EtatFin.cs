using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace CaisseAutomatique.Model.Automates.Etats
{
    public class EtatFin : Etat
    {
        private static System.Timers.Timer timer;
        public EtatFin(Caisse caisse,Automate automate) : base(caisse, automate)
        {
            if(timer == null)//Si le timer n'est pas encore initialiser
            {
                timer = new System.Timers.Timer(2000);//On créé un nouveu timer de 2s
                timer.Elapsed += Timer_Elapsed;//J'assigne la méthode "Timer_Elapsed" à l'événement
                timer.AutoReset = false;//On désactive l'auto reset
                timer.Start();//On commence le timer
            }
        }

        public static System.Timers.Timer Timer { get => timer; set => timer = value; }

        public override string Message => "Au revoir !";

        private void Timer_Elapsed(object? sender,ElapsedEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate//J'actionne dans le thread principal
            {
                this.Automate.Activer(Evenement.RESET);//J'active l'événement reset
            });
            timer.Dispose();//J'arrète le timer
            timer = null;//Je détruit le timer
        }

        public override void Action(Evenement e)
        {
            switch (e)
            {
                case Evenement.RESET: Caisse.Reset();break;
            }
        }

        public override Etat Transition(Evenement e)
        {
            Etat res = null;
            switch (e)
            {
                case Evenement.RESET: res = new EtatAttenteClient(Caisse, Automate);break;
            }
            return res;
        }
    }
}
