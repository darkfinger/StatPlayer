using System;

namespace StatPlayer
{
    abstract class Joueur
    {
        /// <summary>
        /// une static readonly array considered as a constant array
        /// </summary>
        private static readonly String[]  POSITION = { "D", "G", "AG", "AD","C"};
        /// <summary>
        /// attribut declaration
        /// </summary>
        String nom_;
        String postNom_;
        String NomEquipe_;
        char[] position_;
        uint nombreDeBut_;
        uint nombreDePasse_;
        /// <summary>
        /// property for attribut Nom
        /// </summary>
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
        /// <summary>
        /// property for attribut postNom
        /// </summary>
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
        /// <summary>
        /// property for attribut nomEquipe
        /// </summary>
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
        /// <summary>
        /// property for attribut Position
        /// </summary>
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
                    //we cannot throw an Exception in an else, because we want to check that the value in every index of POSITION.
                    //if we throw it inside else, the program will stop after checking and not founding an accurate position at the first index 
                    if (value.ToUpper().Equals(p))
                    {
                        this.position_=value.ToUpper().ToCharArray();
                        break;//if we found one on the actual index, we break the if, we don't have to go all along.
                    }
                }
                //if the loop finds an accurate position then the attribut will be assigned, if it's still null 
                //it means it didn't found an accurate value, therefore we throw an error
                if (this.position_ == null)
                {
                    throw new ApplicationException("Mauvais format pour le Position d'un joueur"); ;
                }
            }
        }
        /// <summary>
        /// property for attribut NombreDeBut
        /// </summary>
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
                    try { this.nombreDeBut_ = value; } catch (FormatException) { throw new ApplicationException("Mauvais format pour le nombre de but"); }

                }
                else
                {
                    throw new ApplicationException("Mauvais format pour le nombre de but");
                }
            }
        }
        /// <summary>
        /// attribute for nombredePasse
        /// </summary>
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
                    try { this.nombreDePasse_ = value; } catch (FormatException) { throw new ApplicationException("Mauvais format pour le nombre de Pass"); }
                }
                else
                {
                    throw new ApplicationException("Mauvais format pour le nombre de Pass");
                }
            }
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="position"></param>
        /// <param name="but"></param>
        /// <param name="passe"></param>
        public Joueur(String nom, string position,uint but=0,uint passe=0)
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
            this.NombreDeBut = but;
            this.NombreDePasse = passe;        
        }
        /// <summary>
        /// copy constructor
        /// </summary>
        /// <param name="joueur"></param>
        public Joueur(Joueur joueur)
        {
            this.Nom = joueur.Nom;
            this.PostNom = joueur.PostNom;
            this.Position = joueur.Position;
            this.NombreDeBut = joueur.NombreDeBut;
            this.NombreDePasse = joueur.NombreDePasse;
        }
        /// <summary>
        /// toString ovverride to print out stat of an individual player
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            String details;
            details = this.Nom + " " + this.PostNom + " " + this.Position + " " + this.NombreDeBut + " " + this.NombreDePasse;
            return details;
        }
    }
}
