using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseAutomatique.Model.Automates
{
    public enum Evenement
    {
        SCANARTICLE,
        PAYE,
        RESET,
        ATTENDRE_ARTICLE_PANIER,
        PROBLEME_POIDS,
        SAISIEQUANTITE
    }
}
