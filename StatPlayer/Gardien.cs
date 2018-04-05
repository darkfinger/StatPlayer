using System;

namespace StatPlayer
{
    class Gardien:Joueur,IComparable
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
        public override float Rendement
        {
            get
            {
                float tranch=(float)this.NombreDeMinute / 60;
                if (tranch > 0)
                {
                    tranch = (float)(Math.Round((float)(NombreButAlloue / tranch), 1));
                    return tranch;
                }
                else { return 0; }
            }
        }
        public float Efficacite
        {
            get
            {
                uint tireArretes = NombreTotalDeTire - NombreButAlloue;
                float eff = (float)tireArretes / NombreTotalDeTire;
                eff = (float)(Math.Round((float)eff, 3));
                return  eff;
            }
        }
        public Gardien(Gardien gardien) 
            : base(gardien)
        {
            this.NombreDeMinute = gardien.NombreDeMinute;
            this.NombreDeVictoire = gardien.NombreDeVictoire;
            this.NombreDefaite = gardien.NombreDefaite;
            this.NombreTotalDeTire = gardien.NombreTotalDeTire;
            this.NombreButAlloue = gardien.NombreButAlloue;
        }
        public Gardien(String nomEquipe, string nom, string position, uint minute, uint but, uint passe, uint nombreVictoire, uint nombreDefaite, uint nombreTotalDeTire, uint nombreButAlloue) 
            : base(nomEquipe, nom, position, but, passe)
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
            details =this.Nom + " " + this.PostNom + " " +this.NomEquipe+" "+  this.Position + " " + this.NombreDeMinute
                        + " " + this.NombreDeBut + " " + this.NombreDePasse + " " + this.NombreDeVictoire
                        + " " + this.NombreDefaite + " " + this.NombreTotalDeTire + " " + this.NombreButAlloue
                        + " " + this.Efficacite + " " + this.Rendement;
            return details;
        }

        public int CompareTo(object obj)
        {
            if (!(obj is Gardien))
            {
                throw new ArgumentException("L'objet n'est pas de la classe Etudiant");
            }
            Gardien autreGardien = obj as Gardien;
            int comparaison = (Rendement.CompareTo(autreGardien.Rendement));
            //Console.WriteLine(Rendement + " est sup que " + autreJoueur.Rendement + " comp==" + comparaison);
            if (comparaison == 0)
            {
                comparaison = -(NombreDeMinute.CompareTo(autreGardien.NombreDeMinute));
            }
            if (comparaison == 0)
            {
                comparaison = -(Efficacite.CompareTo(autreGardien.Efficacite));
            }
            if (comparaison == 0)
            {
                comparaison = (Nom.CompareTo(autreGardien.Nom));
            }
            if (comparaison == 0)
            {
                comparaison = (PostNom.CompareTo(autreGardien.PostNom));
            }
            return comparaison;
        }
    }
}