using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatPlayer
{
    class JoueurdeS : Joueur
    {
        uint nbrMatch_;

        public uint NbrMatch

        {
            get

            {
                return nbrMatch_;

            }

            private set
            {
                nbrMatch_ = value;
            }
        }

        public JoueurdeS(string ne, string nj, char pos, uint nb, uint np, uint nm) : base(ne, nj, p, nb, np)
        {

        }
       


    }
}
