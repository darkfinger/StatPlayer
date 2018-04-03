using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StatPlayer
{
    class League
    {
        StreamReader streamReader;
        uint nombreEquipe_;
        List<Equipe> listEquipe_;
        List<Joueur> listJoueur_;
        private List<Equipe> ListEquipe
        {
            get
            {
                return this.listEquipe_;
            }
            set
            {
                try
                {
                    this.listEquipe_ = value;
                }
                catch (Exception)
                {
                    throw new ApplicationException("list not Formated");
                }
            }
        }
        private List<Joueur> ListJoueur
        {
            get
            {
                return this.listJoueur_;
            }
            set
            {
                try
                {
                    this.listJoueur_ = value;
                }
                catch (Exception)
                {
                    throw new ApplicationException("list not Formated");
                }
            }
        }
        public uint NombreEquipe
        {
            get { return this.nombreEquipe_; }
            set
            {

                if (value > 0)//must be positive and less then 32 equipe
                {
                    //chack if the format is in the correct format
                    try { this.nombreEquipe_ = value; } catch (FormatException) { throw new Exception(); }
                }
                else
                {
                    throw new ApplicationException("Nombre d'equipe pas compatible");
                }
            }
        }       
        public League(uint nombreEquipe)
        {
            this.NombreEquipe = nombreEquipe;
            if (this.LectureEquipe(streamReader).Count<=this.NombreEquipe)
            {
            this.ListEquipe = this.LectureEquipe(streamReader);
            }
            else
            {
                throw new ApplicationException("Nombre Equipe depasse le max (31)");
            }
            this.ListJoueur = LectureJoueurStats(streamReader);
        }
        public List<Joueur> LectureJoueurStats(StreamReader streamReader)
        { streamReader = new StreamReader("../../JoueursStats.txt");
            String chaine;
            List<Joueur> listJoueur = new List<Joueur>(); 
            while (!streamReader.EndOfStream)
            {
                chaine = streamReader.ReadLine();
                String[] part = chaine.Split(';');
                if (part[2].ToUpper().Equals("G"))
                {
                    Gardien gardien = new Gardien(part[0], part[1], part[2], uint.Parse(part[3]), uint.Parse(part[4]), uint.Parse(part[5]), 
                                                    uint.Parse(part[6]), uint.Parse(part[7]), uint.Parse(part[8]),uint.Parse(part[9]));
                    listJoueur.Add(gardien);
                }
                else
                {
                    JoueurDeSurface joueurDeSurface = new JoueurDeSurface(part[0], part[1], part[2], uint.Parse(part[3]), uint.Parse(part[4]), uint.Parse(part[5]));
                    listJoueur.Add(joueurDeSurface);
                }
            }
            return listJoueur;
        }    
        public List<Equipe> LectureEquipe(StreamReader streamReader)
        {
            streamReader = new StreamReader("../../Equipe.txt");
            String chaine;
            List<Equipe> listEquipe = new List<Equipe>();
            while (!streamReader.EndOfStream)
            {
                chaine = streamReader.ReadLine();
                String[] part = chaine.Split(';');
                Equipe equipe = new Equipe(part[0], part[1], part[2], part[3]);
                listEquipe.Add(equipe);
               
            }
            return listEquipe;
        }
        public List<Equipe> GetEquipes()
        {
            return new List<Equipe>(this.ListEquipe);
        }
        public void AffectationJoueurDansEquipe()
        {
            foreach(Joueur j in ListJoueur)
            {
                foreach (Equipe e in ListEquipe)
                {
                    if (j.NomEquipe.Equals(e.Nom))
                    {
                        e.AddJoueurToTheTeam(j);
                    }
                }
            }
        }
        public String ProduirClassementJoueurParEquipe()
        {
            String classementparEquip = "";
            List<JoueurDeSurface> listJoueurAAfficher = new List<JoueurDeSurface>();
            List<Gardien> listGardienAAfficher=new List<Gardien>();
            this.ListEquipe.Sort();
            foreach (Equipe e in this.ListEquipe)
            {
                classementparEquip += "\n";
                classementparEquip += "***********************************************************" +
                                       "**********************************************************\n";
                classementparEquip +="  "+ e + "\n";
                classementparEquip += "***********************************************************" +
                                       "**********************************************************\n";

                List<JoueurDeSurface> listJoueurOrdonnee = e.GetListJoueurDeSurface();
                listJoueurOrdonnee.Sort();                
                foreach (JoueurDeSurface j in listJoueurOrdonnee)
                {
                    listJoueurAAfficher.Add(j);
                }
                classementparEquip += (listJoueurAAfficher.ToStringTable(
                       new[] { "Nom", "Post-Nom", "Nom Equipe", "Position", "Match", "Buts", "Passes", "Total" },
                       a => a.Nom, a => a.PostNom, a => a.NomEquipe, a => a.Position, a => a.NombreDeMatch,
                       a => a.NombreDeBut, a => a.NombreDePasse, a => a.Rendement)+"\n");

                List<Gardien> listGardienOrdonnee = e.GetListGardien();
                listGardienOrdonnee.Sort();
                foreach (Gardien j in listGardienOrdonnee)
                {
                    listGardienAAfficher.Add(j);
                }
                classementparEquip += (listGardienAAfficher.ToStringTable(
                      new[] { "Nom", "Post-Nom", "Nom Equipe", "Position", "Match", "Buts", "Passes", "Total" },
                      a => a.Nom, a => a.PostNom, a => a.NomEquipe, a => a.Position, a => a.NombreDeMinute,
                      a => a.NombreDeBut, a => a.NombreDePasse, a => a.Rendement));
                listJoueurAAfficher.Clear();
                listGardienAAfficher.Clear();
            }
            return classementparEquip;
        }
        public List<Joueur> ProduirClassementGenJoueurDeSurface()
        {
            List<Joueur> classementJoueur = new List<Joueur>();
            foreach (Equipe e in this.ListEquipe)
            {
                List<JoueurDeSurface> ljs = e.GetListJoueurDeSurface();                
                foreach (JoueurDeSurface j in ljs)
                {
                    classementJoueur.Add(j);
                }
            }
            classementJoueur.Sort();
            return classementJoueur;
        }
        public List<Joueur> ProduirClassementGenGardien()
        {
            List<Joueur> classementparGardien = new List<Joueur>();
            foreach (Equipe e in this.ListEquipe)
            {
                List<Gardien> ljs = e.GetListGardien(); 
                foreach (Gardien j in ljs)
                {
                    classementparGardien.Add(j);
                }
            }
            classementparGardien.Sort();
            return classementparGardien;
        }
    }
}