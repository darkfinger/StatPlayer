using System;

namespace StatPlayer
{
    class Joueur
    {
        private static readonly String[]  POSITION = { "D", "G", "AG", "AD","C"};
        String nom_;
        String postNom_;
        String NomEquipe_;
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
        public String NomEquipe
        {
            get
            {
                return this.NomEquipe_;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value is String)
                {
                    this.NomEquipe_ = value;
                }
                else
                {
                    throw new Exception();
                }
            }
        }
        public String Position
        {
            get
            {
                String pos="";
                foreach(char p in this.position_)
                {pos += p.ToString();}
                return pos.Replace(" ","");
            }
            set
            {
                foreach(String p in POSITION)
                {
                    //we cannot throw an Exception on an else, because we want to check that the value in every index of POSITION
                    //if we throw it, the program will stop after checking the first index and not founding an accurate position
                    if (value.ToUpper().Equals(p))
                    {
                        this.position_=value.ToUpper().ToCharArray();
                        break;//if we found one on the first position, we don't have to go all along.
                    }
                }
                //if the loop finds an accurate position then the attribut will be assigned, if it's still null 
                //it means it didn't found an accurate value, therefore we throw an error
                if (this.position_ == null)
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
        public Joueur(String nom, string position, uint match=0,uint but=0,uint passe=0)
        {
            String[] fullName = nom.Split(' ');
            if (fullName.Length == 1)
            {
                this.Nom = fullName[0];
            }
            else
            {
                this.Nom = fullName[0];
                for(int i=1; i<fullName.Length; i++)
                {
                    this.PostNom += fullName[i] + " ";
                }

            }
            this.Position = position;
            this.NombreDeMatch = match;
            if (this.NombreDeMatch == 0)
            {
                this.NombreDeBut = 0;
                this.NombreDePasse = 0;
            }
            else
            {
                this.NombreDeBut = but;
                this.NombreDePasse = passe;
            }
        }
        public Joueur(Joueur joueur)
        {
            this.Nom = joueur.Nom;
            this.PostNom = joueur.PostNom;
            this.Position = joueur.Position;
            this.NombreDeMatch = joueur.NombreDeMatch;
            this.NombreDeBut = joueur.NombreDeBut;
            this.NombreDePasse = joueur.NombreDePasse;
        }
        public override string ToString()
        {
            String details;
            details = this.Nom + " " + this.PostNom + " " + this.Position + " " + this.NombreDeMatch + " " + this.NombreDeBut + " " + this.NombreDePasse;
            return details;
        }
    }
}
