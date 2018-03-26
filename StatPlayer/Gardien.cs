using System;

namespace StatPlayer
{
    class Gardien:Joueur
    {
        /// <summary>
        /// attribut declaration
        /// </summary>
        uint nombreDeMinute_;
        uint nombreVictoire_;
        uint nombreDefaite_;
        uint nombreTotalDeTire_;
        uint nombreButAlloue_;
        /// <summary>
        /// property for the nombreDeMinute_ att.
        /// </summary>
        public uint NombreDeMinute
        {
            get
            {
                return this.nombreDeMinute_;
            }
            set
            {
                if (value >= 0)//if the quantity is positive
                {
                    //chack if the format is in the correct form
                    try { this.nombreDeMinute_ = value; } catch (FormatException) { throw new ApplicationException("invalid format for NombreDeMinute"); }

                }
                else
                {
                    throw new ApplicationException("invalid format for NombreDeMinute");
                }
            }
        }
        /// <summary>
        /// property for the nombreVictoire att.
        /// </summary>
        public uint NombreDeVictoire
        {
            get
            {
                return this.nombreVictoire_;
            }
            set
            {
                if (value >= 0)//if the quantity is positive
                {
                    //chack if the format is in the correct form
                    try { this.nombreVictoire_ = value; } catch (FormatException) { throw new ApplicationException("invalid format for nombreVictoire"); }

                }
                else
                {
                    throw new ApplicationException("invalid format for nombreVictoire");
                }
            }
        }
        /// <summary>
        /// property for the nombreDefaite_ att.
        /// </summary>
        public uint NombreDefaite
        {
            get
            {
                return this.nombreDefaite_;
            }
            set
            {
                if (value >= 0)//if the quantity is positive
                {
                    //chack if the format is in the correct form
                    try { this.nombreDefaite_ = value; } catch (FormatException) { throw new ApplicationException("invalid format for nombreDefaite_"); }

                }
                else
                {
                    throw new ApplicationException("invalid format for nombreDefaite_");
                }
            }
        }
        /// <summary>
        /// property for the nombreTotalDeTire_ att.
        /// </summary>
        public uint NombreTotalDeTire
        {
            get
            {
                return this.nombreTotalDeTire_;
            }
            set
            {
                if (value >= 0)//if the quantity is positive
                {
                    //chack if the format is in the correct form
                    try { this.nombreTotalDeTire_ = value; } catch (FormatException) { throw new ApplicationException("invalid format for nombreTotalDeTire_"); }

                }
                else
                {
                    throw new ApplicationException("invalid format for nombreTotalDeTire_");
                }
            }
        }
        /// <summary>
        /// property for the nombreButAlloue_ att.
        /// </summary>
        public uint NombreButAlloue
        {
            get
            {
                return this.nombreButAlloue_;
            }
            set
            {
                if (value >= 0)//if the quantity is positive
                {
                    //chack if the format is in the correct form
                    try { this.nombreButAlloue_ = value; } catch (FormatException) { throw new ApplicationException("invalid format for nombreButAlloue_"); }

                }
                else
                {
                    throw new ApplicationException("invalid format for nombreButAlloue_");
                }
            }
        }                
        public Gardien(Joueur joueur) 
            : base(joueur)
        {
            if (!joueur.Position.ToUpper().Equals("G"))
            {
                throw new ApplicationException("only players with position G can be Gardien");
            }
            this.NombreDeMinute = 0;
            this.NombreDeBut = 0;
            this.NombreDePasse = 0;
            this.NombreDeVictoire = 0;
            this.NombreDefaite = 0;
            this.NombreTotalDeTire = 0;
            this.NombreButAlloue = 0;
        }
        public Gardien(Gardien gardien) 
            : base(gardien)
        {
            if (!gardien.Position.ToUpper().Equals("G"))
            {
                throw new ApplicationException("only players with position G can be Gardien");
            }
            this.NombreDeMinute = gardien.NombreDeMinute;
            this.NombreDeVictoire = gardien.NombreDeVictoire;
            this.NombreDefaite = gardien.NombreDefaite;
            this.NombreTotalDeTire = gardien.NombreTotalDeTire;
            this.NombreButAlloue = gardien.NombreButAlloue;
        }
        public Gardien(Joueur joueur,uint minute, uint nombreVictoire, uint nombreDefaite, uint nombreTotalDeTire, uint nombreButAlloue) 
            : base(joueur)
        {
            if (!joueur.Position.ToUpper().Equals("G"))
            {
                throw new ApplicationException("only players with position G can be Gardien");
            }
            this.NombreDeMinute = minute;
            if (this.NombreDeMinute < 1)
            {
                this.NombreDeBut = 0;
                this.NombreDePasse = 0;
                this.NombreTotalDeTire = 0;
                this.NombreButAlloue = 0;
            }
            else
            {
                this.NombreDeVictoire = nombreVictoire;
                this.NombreDefaite = nombreDefaite;
                this.NombreTotalDeTire = nombreTotalDeTire;
                this.NombreButAlloue = nombreButAlloue;
            }
            
        }
        public Gardien(string nom, string position, uint minute, uint but, uint passe, uint nombreVictoire, uint nombreDefaite, uint nombreTotalDeTire, uint nombreButAlloue) 
            : base(nom, position, but, passe)
        {
            if (!position.ToUpper().Equals("G"))
            {
                throw new ApplicationException("only players with position G can be Gardien");
            }
            this.NombreDeMinute=minute;
            if (this.NombreDeMinute < 1)
            {
                this.NombreDeBut = 0;
                this.NombreDePasse = 0;
                this.NombreDeVictoire = 0;
                this.NombreDefaite = 0;
                this.NombreTotalDeTire = 0;
                this.NombreButAlloue = 0;
            }
            else
            {
                this.NombreDeVictoire=nombreVictoire;
                this.NombreDefaite = nombreDefaite;
                this.NombreTotalDeTire = nombreTotalDeTire;
                this.NombreButAlloue = nombreButAlloue;
            }
        }
        /// <summary>
        /// toString ovverride to print out stat of an individual Gardien
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            String details;
            details = this.Nom + " " + this.PostNom + " " + this.Position + " " + this.NombreDeMinute
                        + " " + this.NombreDeBut + " " + this.NombreDePasse + " " + this.NombreDeVictoire
                        + " " + this.NombreDefaite + " " + this.NombreTotalDeTire + " " + this.NombreButAlloue;
            return details;
        }
    }
}