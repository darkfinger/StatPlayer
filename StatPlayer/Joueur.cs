using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatPlayer
{
    class Joueur
    {
        String nom_;
        String postNom_;
        char[] position_;
        uint nombreDeBut_;
        uint nombreDePasse_;
        uint nombreDeMatch_;

        public String Nom
        {
            get
            {
                return this.nom_;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value is String)
                {
                    this.nom_ = value;
                }
                else
                {
                    throw new Exception();
                }
            }
        }
        public String PostNom
        {
            get
            {
                return this.postNom_;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value is String)
                {
                    this.postNom_ = value;
                }
                else
                {
                    throw new Exception();
                }
            }
        }
        public uint NombreDeBut
        {
            get
            {
                return this.nombreDeBut_;
            }
            set
            {
                if (value >= 0)//if the but is positive
                {
                    //chack if the format is in the correct form
                    try { this.nombreDeBut_ = value; } catch (FormatException) { throw new Exception(); }

                }
                else
                {
                    throw new Exception();
                }
            }
        }
        public uint NombreDePasse
        {
            get
            {
                return this.nombreDePasse_;
            }
            set
            {
                if (value >= 0)//if the passe is positive
                {
                    //chack if the format is in the correct form
                    try { this.nombreDePasse_ = value; } catch (FormatException) { throw new Exception(); }

                }
                else
                {
                    throw new Exception();
                }
            }
        }
        public uint NombreDeMatch
        {
            get
            {
                return this.nombreDeMatch_;
            }
            set
            {
                if (value >= 0)//if the quantity is positive
                {
                    //chack if the format is in the correct form
                    try { this.nombreDeMatch_ = value; } catch (FormatException) { throw new Exception(); }

                }
                else
                {
                    throw new Exception();
                }
            }
        }
        public uint Total {
            get
            {
                return this.NombreDeBut+this.NombreDePasse;
            }
        }
    }
}
