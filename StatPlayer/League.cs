using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatPlayer
{
    class League
    {
        uint nombreEquipe_;
        List<Equipe> listEquipe_;
        public uint NombreEquipe_
        {
            get { return this.nombreEquipe_; }
            set
            {

                if (value >= 0)//if the but is positive
                {
                    //chack if the format is in the correct form
                    try { this.nombreEquipe_ = value; } catch (FormatException) { throw new Exception(); }

                }
                else
                {
                    throw new Exception();
                }
            }
        }
        private List<Equipe> ListjoueurClesDeLaPartie
        {
            get
            {
                return this.listEquipe_;
            }
            set
            {
                try { this.listEquipe_ = value; } catch (Exception) { throw new Exception(); }
            }
        }
        public Equipe this[int index]
        {
            get
            {
                return new Equipe(listEquipe_[index]);
            }
        }
    }
}