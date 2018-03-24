using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatPlayer
{
    class Joueur
    {
        string nomJ_;
        string nomEquip_;
        Char position_;
        uint nbrBut_;
        uint nbrPass_;

        public string NomJ
        {
            get
            {
                return nomJ_;
            }

            private set
            {
                nomJ_= value;
            }
        }



        public string NomEquip
        {
            get
            {
                return nomEquip_;
            }

            private set
            {
                nomEquip_= value;
            }
        }

        public char Position
        {
            get
            {
                return position_;
            }

            private set
            {
                position_= value;
            }
        }



        public uint NbrBut
        {
            get
            {
                return nbrBut_;
            }

            private set
            {
                nbrBut_= value;
            }
        }




        public uint NbrPass
        {
            get
            {
                return nbrPass_;
            }

            private set
            {
                nbrPass_= value;
            }
        }




    }



}
