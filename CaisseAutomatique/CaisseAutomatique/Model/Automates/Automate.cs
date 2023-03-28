using CaisseAutomatique.Model.Articles;
using CaisseAutomatique.Model.Automates.Etats;
using CaisseAutomatique.VueModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CaisseAutomatique.Model.Automates
{
    public class Automate : INotifyPropertyChanged
    {
        private Caisse caisse;
        private Etat etatCourant;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string Message { get => this.etatCourant.Message; }

        public Automate(Caisse caisse)
        {
            this.caisse = caisse;
            this.etatCourant = new EtatAttenteClient(caisse, this);
            this.etatCourant.PropertyChanged += EtatCourant_PropertyChanged;
        }
        public void Activer(Evenement e)
        {
            Trace.WriteLine(Message);
            Trace.WriteLine(e);
            this.etatCourant.Action(e);
            this.etatCourant = etatCourant.Transition(e);
            NotifyPropertyChanged("Message");
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void EtatCourant_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ScanArticleDenombrable")
            {
                NotifyPropertyChanged("ScanArticleDenombrable");
            }
        }
    }
}
