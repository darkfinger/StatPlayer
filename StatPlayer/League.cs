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
        const int MAX_NOMBRE_EQUIPE= 31;
        StreamReader streamReader=null;
        enum TYPEPARTIE{R='R',P='P',F='F'};
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

                if ((value > 0)&&(value<=MAX_NOMBRE_EQUIPE))//must be positive and less than Max
                {
                    //chack if the format is in the correct format
                    try { this.nombreEquipe_ = value; }
                    catch (FormatException) { throw new ApplicationException("Mauvais format du Nombre d'equipe"); }
                }
                else
                {
                    throw new ApplicationException("Nombre d'equipe superieur au max");
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
        public void LectureResultat(StreamReader streamReader, string resultat)
        {
            streamReader = new StreamReader("../../"+ resultat + ".txt");
            String chaine;
            int counter = 1, maxLine=0;
            int nombreMinute=0;
            Partie laPartie=null;
            while (!streamReader.EndOfStream)
            {
                chaine = streamReader.ReadLine();
                String[] part = chaine.Split(';');
                if (counter == 1)
                {
                    if (part.Length == 6)
                        nombreMinute = int.Parse(part[5]);
                    if (part.Length == 5 && char.Parse(part[4].ToUpper()) == 'F')
                        nombreMinute = 65;

                    nombreMinute = 60;
                    Equipe equipe1 = null, equipe2 = null;
                    foreach(Equipe e in this.ListEquipe)
                    {
                        if (part[0] == e.Nom)
                            equipe1 = e;

                        if (part[2] == e.Nom)
                            equipe2 = e;
                    }
                    laPartie = new Partie(equipe1, int.Parse(part[1]), equipe2, int.Parse(part[3]), char.Parse(part[4].ToUpper()));
                    maxLine = int.Parse(part[1]) + int.Parse(part[3]) + 1;
                    counter++;
                }
                if (counter == 2)
                {
                    if(!(ListJoueur.Any(g => (g.Nom + g.PostNom).Equals(part[1]))))
                    {
                        JournalDesErreurs(part[1]);
                    }
                    if (!(ListJoueur.Any(g => (g.Nom+g.PostNom).Equals(part[4]))))
                    {
                        JournalDesErreurs(part[4]);
                    }
                        Gardien gardien1 = (Gardien)ListJoueur.Find(g => (g.Nom + g.PostNom).Equals(part[1]));
                        Gardien gardien2 = (Gardien)ListJoueur.Find(g => (g.Nom + g.PostNom).Equals(part[4]));
                        gardien1.NombreTotalDeTire += uint.Parse(part[2]);
                        gardien1.NombreButAlloue += (uint)laPartie.NombreButEq2;
                        gardien1.NombreDeMinute = (uint)nombreMinute;
                        if (laPartie.Winner.Equals(laPartie.Equipe1.Nom))
                        {
                            gardien1.NombreDeVictoire += 1;
                            gardien2.NombreDefaite += 1;
                        }
                        else { gardien2.NombreDeVictoire += 1; gardien1.NombreDefaite += 1; }

                        gardien2.NombreTotalDeTire += uint.Parse(part[5]);
                        gardien2.NombreButAlloue += (uint)laPartie.NombreButEq1;
                        gardien2.NombreDeMinute = (uint)nombreMinute;

                        laPartie.AjouterJoueurDansLaListdeLaPartie(gardien1);
                        laPartie.AjouterJoueurDansLaListdeLaPartie(gardien2);
                    
                    counter++;
                }
                if (counter > 2)
                {
                    for(int i = 0; i <= part.Length; i++)
                    {
                        if (char.Parse(part[i].ToUpper()) == 'B')
                        {
                            if(ListJoueur.Any(j => (j.Nom+" "+j.PostNom).Equals(part[i - 1])))
                            {
                                var joueur = ListJoueur.Find(j => (j.Nom + " " + j.PostNom).Equals(part[i - 1]));
                                joueur.NombreDeBut++;
                                if(!(laPartie.GetListJoueurDeSurface().Any(j=> (j.Nom + " " + j.PostNom).Equals(part[i - 1]))))
                                {
                                    laPartie.AjouterJoueurDansLaListdeLaPartie(joueur);
                                }                                
                            }
                            else
                            {
                                JournalDesErreurs(part[i - 1] + " N'est pas repertoriee dans la ligue");
                            }
                            
                        }
                        if (char.Parse(part[i].ToUpper()) == 'A')
                        {
                            if (ListJoueur.Any(j => (j.Nom + " " + j.PostNom).Equals(part[i - 1])))
                            {
                                var joueur = ListJoueur.Find(j => (j.Nom + " " + j.PostNom).Equals(part[i - 1]));
                                joueur.NombreDePasse++;
                                if (!(laPartie.GetListJoueurDeSurface().Any(j => (j.Nom + " " + j.PostNom).Equals(part[i - 1]))))
                                {
                                    laPartie.AjouterJoueurDansLaListdeLaPartie(joueur);
                                }
                            }
                            else
                            {
                                JournalDesErreurs(part[i - 1] + " N'est pas repertoriee dans la ligue");
                            }
                        }
                    }
                    counter++;
                    if (counter == maxLine)
                    {
                        foreach(JoueurDeSurface j in laPartie.GetListJoueurDeSurface())
                        {
                            j.NombreDeMatch++;
                        }
                        counter = 1;
                    }
                        
                }

            }
            streamReader.Close();
        }
        public static void JournalDesErreurs(String j)
        {
            StreamWriter writer = new StreamWriter("../../JournalDesErreurs.txt");
            writer.WriteLine("Le joueur "+j+"n'est pas repertorier dans la list de la ligue");
            writer.Close();
        }
    }
}