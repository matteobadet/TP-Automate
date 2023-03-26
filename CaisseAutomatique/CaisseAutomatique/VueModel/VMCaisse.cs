using CaisseAutomatique.Model;
using CaisseAutomatique.Model.Articles;
using CaisseAutomatique.Model.Articles.Realisations;
using CaisseAutomatique.Model.Automates;
using CaisseAutomatique.Vue;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace CaisseAutomatique.VueModel
{
    /// <summary>
    /// Vue-Model de la caisse automatique
    /// </summary>
    public class VMCaisse : INotifyPropertyChanged
    {
        /// <summary>
        /// La caisse automatique (couche métier)
        /// </summary>
        private Caisse metier;
        private Automate automate;

        public string Message { get => this.automate.Message; }

        /// <summary>
        /// Liste des articles de la caisse
        /// </summary>
        public ObservableCollection<Article> Articles { get=> articles; set => articles = value; }
        private ObservableCollection<Article> articles;

        /// <summary>
        /// La caisse est-elle disponible pour un nouveau client
        /// </summary>
        private bool estDisponible;

        public event PropertyChangedEventHandler? PropertyChanged;

        public bool EstDisponible 
        { 
            get => estDisponible;
            set
            {
                estDisponible = value;
                this.NotifyPropertyChanged("EstDisponnible");
            }
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        public VMCaisse()
        {
            this.EstDisponible = true;
            this.metier = new Caisse();
            this.automate = new Automate(this.metier);
            this.metier.PropertyChanged += Metier_PropertyChanged;
            this.automate.PropertyChanged += Automate_PropertyChanged;
            this.articles = new ObservableCollection<Article>();
            this.AjouterLigneTotalEtResteAPayer();
        }

        /// <summary>
        /// Ajout des lignes "Total" et "Reste à payer" dans la facture
        /// </summary>
        private void AjouterLigneTotalEtResteAPayer()
        {
            this.Articles.Add(new ArticleVirtuel("Total", this.metier.PrixTotal));
            this.Articles.Add(new ArticleVirtuel("Reste à payer : ", this.metier.PrixTotal - this.metier.SommePayee));
        }

        /// <summary>
        /// Modification du métier observée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Metier_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Articles")
            {
                this.articles.Clear();
                foreach (Article article in this.metier.Articles) this.Articles.Add(article);
                this.AjouterLigneTotalEtResteAPayer();
            }
            else if(e.PropertyName =="SommePayee")
            {
                if(this.Articles.Count > 0)
                {
                    this.Articles.RemoveAt(this.Articles.Count - 1);
                    this.Articles.Add(new ArticleVirtuel("Reste à payer : ", this.metier.PrixTotal - this.metier.SommePayee));
                }
            }
            else if (e.PropertyName == "Reset")
            {
                this.articles.Clear();
                foreach (Article article in this.metier.Articles) this.Articles.Add(article);
                this.AjouterLigneTotalEtResteAPayer();
                this.EstDisponible = true;
            }
        }

        /// <summary>
        /// Ouvrir l'écran de sélection des quantités pour un article dénombrable
        /// </summary>
        private void OuvrirEcranSelectionQuantite()
        {
            new EcranSelectionQuantite(this).Show();
        }

        /// <summary>
        /// Ouvrir l'écran d'administration
        /// </summary>
        private void OuvrirEcranAdministration()
        {
            new EcranAdministration(this).Show();
        }

        /// <summary>
        /// L'utilisateur tente de scanner un produit
        /// </summary>
        /// <param name="vueArticle">Vue de l'article scanné</param>
        public void PasseUnArticleDevantLeScannair(VueArticle vueArticle)
        {
            this.metier.ScanArticle(vueArticle.Article);
            if (vueArticle.Article.IsDenombrable == false)
            {
                this.automate.Activer(Evenement.SCANARTICLE);
            } else
            {
                this.automate.Activer(Evenement.SAISIEQUANTITE);
            }
        }

        /// <summary>
        /// L'utilisateur pose un article sur la balance
        /// </summary>
        /// <param name="vueArticle">Vue de l'article posé sur la balance</param>
        public void PoseUnArticleSurLaBalance(VueArticle vueArticle)
        {
            if(metier.DernierArticleScanne == vueArticle.Article)
            {
                metier.AjoutPoidBalance();
                this.automate.Activer(Evenement.SCANARTICLE);
            }
            if (metier.PoidsAttendu != metier.PoidsBalance || vueArticle.Article != metier.DernierArticleScanne)
            {
                this.automate.Activer(Evenement.PROBLEME_POIDS);
            }
        }

        /// <summary>
        /// L'utilisateur enlève un article de la balance
        /// </summary>
        /// <param name="vueArticle">Vue de l'article enlevé de la balance</param>
        public void EnleveUnArticleDeLaBalance(VueArticle vueArticle)
        {
            if (metier.DernierArticleScanne == vueArticle.Article)
            {
                metier.EnlevePoidBalance();
            }
            if(metier.PoidsAttendu != metier.PoidsBalance)
            {
                this.automate.Activer(Evenement.PROBLEME_POIDS);
            }
            if(metier.PoidsAttendu == metier.PoidsBalance)
            {
                if(articles.Count == 2)
                {
                    this.automate.Activer(Evenement.RESET);
                } else
                {
                    this.automate.Activer(Evenement.SCANARTICLE);
                }
            }
        }

        /// <summary>
        /// L'utilisateur saisit un nombre d'articles dénombrables
        /// </summary>
        /// <param name="nbArticle">Nombre d'articles</param>
        public void SaisirNombreArticle(int nbArticle)
        {
            this.metier.SaisieQuantite(nbArticle);
            this.automate.Activer(Evenement.SAISIEQUANTITE);
        }

        /// <summary>
        /// L'utilisateur essaye de payer
        /// </summary>
        public void Paye()
        {
            this.automate.Activer(Evenement.PAYE);
        }

        /// <summary>
        /// Un administrateur active le mode administrateur
        /// </summary>
        public void DebutModeAdministration()
        {
        }

        /// <summary>
        /// Un administrateur termine le mode administrateur
        /// </summary>
        public void FinModeAdministration()
        {
        }

        /// <summary>
        /// L'administrateur annule le dernier article
        /// </summary>
        public void AnnuleDernierArticle()
        {
        }

        /// <summary>
        /// L'administrateur annule tous les articles
        /// </summary>
        public void AnnuleTousLesArticles()
        {
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Automate_PropertyChanged(object? sender,PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "Message")
            {
                this.NotifyPropertyChanged("Message");
            }
            if(e.PropertyName == "ScanArticleDenombrable")
            {
                OuvrirEcranSelectionQuantite();
            }
        }
    }
}
