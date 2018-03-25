using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatPlayer
{
    class Equipe
    {
        string nom_;
        string ville_;
        string division_;
        string conference_;
        List<Joueur> listJoueurs_;
    
        public string Nom
        {
            get
            {
                return nom_;

            }
             private set
            {
                nom_ = value;
            }
            
        }

        public string Ville
        {
            get
            {
                return ville_;
            }

            private set
            {
                ville_ = value;
            }
        }
        public string Division
        {
            get
            {
                return division_;
            }

            private set
            {
                division_ = value;
            }
        }


        public string Conference 
        {
            get
            {
                return conference_;
            }

            private set
            {
                conference_= value;
            }
        }

        public List<Joueur> ListJoueurs

        {
            get

            {
                return listJoueurs_;
            }

            private set
            {
                listJoueurs_ = value;
            } 
        }
    }
}
