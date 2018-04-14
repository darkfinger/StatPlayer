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
        /// <summary>
        /// constant for the nombre of team
        /// </summary>
        const int MAX_NOMBRE_EQUIPE= 31;
        /// <summary>
        /// variable declaration
        /// </summary>
        StreamReader streamReader=null;
        uint nombreEquipe_;
        List<Equipe> listEquipe_;
        List<Joueur> listJoueur_;

        /// <summary>
        /// properties definition
        /// </summary>
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
        
        //ends of properties definition

            /// <summary>
            /// constructor
            /// </summary>
            /// <param name="nombreEquipe"></param>
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
        /// <summary>
        /// reading the joueurstat.txt
        /// </summary>
        /// <param name="streamReader"></param>
        /// <returns>list of players found</returns>
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
            streamReader.Close();
            return listJoueur;
        }    
        /// <summary>
        /// reading the equipe.txt
        /// </summary>
        /// <param name="streamReader"></param>
        /// <returns>list of teams found</returns>
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
            streamReader.Close();
            return listEquipe;
        }
        /// <summary>
        /// put each player into his apropriete team
        /// </summary>
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
        /// <summary>
        /// methode that return a string of stat by team, ready to be printed
        /// </summary>
        /// <returns></returns>
        public String ProduirClassementJoueurParEquipe()
        {
            String classementparEquip = "";
            List<JoueurDeSurface> listJoueurAAfficher = new List<JoueurDeSurface>();
            List<Gardien> listGardienAAfficher=new List<Gardien>();
            this.ListEquipe.Sort();
            foreach (Equipe e in this.ListEquipe)
            {
                classementparEquip += Environment.NewLine;
                classementparEquip += "***********************************************************" +
                                       "**********************************************************";
                classementparEquip += Environment.NewLine;
                classementparEquip +="  "+ e + " ";
                classementparEquip += Environment.NewLine;
                classementparEquip += "***********************************************************" +
                                       "**********************************************************";
                classementparEquip += Environment.NewLine;

                List<JoueurDeSurface> listJoueurOrdonnee = e.GetListJoueurDeSurface();
                listJoueurOrdonnee.Sort();                
                foreach (JoueurDeSurface j in listJoueurOrdonnee)
                {
                    listJoueurAAfficher.Add(j);
                }
                //utilisation de l'API extern pour la methode ToStringTable
                classementparEquip += (listJoueurAAfficher.ToStringTable(
                       new[] { "Nom", "Post-Nom", "Nom Equipe", "Position", "Match", "Buts", "Passes", "Total" },
                       a => a.Nom, a => a.PostNom, a => a.NomEquipe, a => a.Position, a => a.NombreDeMatch,
                       a => a.NombreDeBut, a => a.NombreDePasse, a => a.Rendement));
                classementparEquip += Environment.NewLine;

                List<Gardien> listGardienOrdonnee = e.GetListGardien();
                listGardienOrdonnee.Sort();
                foreach (Gardien j in listGardienOrdonnee)
                {
                    listGardienAAfficher.Add(j);
                }
                //utilisation de l'API extern pour la methode ToStringTable
                classementparEquip += (listGardienAAfficher.ToStringTable(
                      new[] { "Nom", "Post-Nom", "Nom Equipe", "V", "D", "Min.", "B", "A", "Tire", "But Al.", "Effic.", "Rend." },
                      a => a.Nom, a => a.PostNom, a => a.NomEquipe, a => a.NombreDeVictoire, a => a.NombreDefaite, a => a.NombreDeMinute+":"+a.NombreDeSecond,
                      a => a.NombreDeBut, a => a.NombreDePasse, a => a.NombreTotalDeTire, a => a.NombreButAlloue, a => a.Efficacite, a => a.Rendement));

                listJoueurAAfficher.Clear();
                listGardienAAfficher.Clear();
            }
            classementparEquip += Environment.NewLine;
            return classementparEquip;
        }
        /// <summary>
        /// methode that return ordored list of joueur de surface
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// methode that return an ordered list for goalkeeper stat
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Methode that handle new games result
        /// </summary>
        /// <param name="resultat">file that contain result</param>
        public void LectureResultat(string resultat)
        {
            StreamReader streamReader = new StreamReader(resultat);
            String chaine;
            int pointerLine = 1, maxLine=0;
            int nombreMinute=0;
            int nombreSec = 0;
            Partie laPartie=null;
            while (!streamReader.EndOfStream)
            {
                chaine = streamReader.ReadLine();
                String[] part = chaine.Split(';');
                //if the size of the line is less then 2, then skip to the line, otherwise treat the line
                if (part.Length > 2)
                {                
                    //if poiter is 1 means we are at the game resume line
                    if (pointerLine == 1)
                    {
                        //if length of the line is six means is a P type of game
                        if (part.Length == 6)
                        {
                            string[] temp = part[5].Split(':');
                            try {
                                nombreMinute = int.Parse(temp[0]);
                                nombreSec = int.Parse(temp[1]);
                            }
                            catch
                            {
                                //if we cannoct affect the time we use the default one
                                nombreMinute = 60;
                                nombreSec = 0;
                            }
                            
                        }
                        if (part.Length == 5 && char.Parse(part[4].ToUpper()) == 'F')
                        {
                            nombreMinute = 65;
                        }
                        else { nombreMinute = 60;}
                    
                        Equipe equipe1 = null, equipe2 = null;
                        foreach(Equipe e in this.ListEquipe)
                        {
                            if (part[0] == e.Nom)
                                equipe1 = e;

                            if (part[2] == e.Nom)
                                equipe2 = e;
                        }
                        laPartie = new Partie(equipe1, int.Parse(part[1]), equipe2, int.Parse(part[3]), char.Parse(part[4].ToUpper()));
                        maxLine = int.Parse(part[1]) + int.Parse(part[3]) + 2;
                    }
                    //if pointer is 2, we are at the gardien line
                    if (pointerLine == 2)
                    {
                        Gardien gardien1=null;
                        Gardien gardien2=null;
                        //i=1,i=4 are the gardien name
                        for (int i = 1; i <= part.Length; i = i + 3)
                        {
                            //verify if the name exist
                            if (IsJoueurExistInTheList(ListJoueur, part[i]))
                            {
                                try
                                {
                                    //gardien one
                                    if (i == 1)
                                    {
                                        gardien1 = (Gardien)FindJoueurInTheList(ListJoueur, part[i]);
                                        gardien1.NombreTotalDeTire += uint.Parse(part[2]);
                                        gardien1.NombreButAlloue += (uint)laPartie.NombreButEq2;
                                        gardien1.NombreDeMinute += (uint)nombreMinute;
                                        gardien1.NombreDeSecond += (uint)nombreSec;
                                        laPartie.AjouterJoueurDansLaListdeLaPartie(gardien1);
                                    }
                                    //gardien 2
                                    if (i == 4)
                                    {
                                        gardien2 = (Gardien)FindJoueurInTheList(ListJoueur, part[i]);
                                        gardien2.NombreTotalDeTire += uint.Parse(part[5]);
                                        gardien2.NombreButAlloue += (uint)laPartie.NombreButEq1;
                                        gardien2.NombreDeMinute += (uint)nombreMinute;
                                        gardien2.NombreDeSecond += (uint)nombreSec;
                                        laPartie.AjouterJoueurDansLaListdeLaPartie(gardien2);
                                    }
                                }
                                catch (Exception)
                                {
                                    throw new ApplicationException("Erreur lors de la mis a jour des nouvelles valeurs du gardien, \n" +
                                        "veriffier votre fichier de resultat pour les valeur du gardien");
                                }
                            }
                            else
                            {
                                JournalDesErreurs(part[i]);
                            }
                        }
                        if (laPartie.Winner.Equals(laPartie.Equipe1.Nom))
                        {
                            gardien1.NombreDeVictoire += 1;
                            gardien2.NombreDefaite += 1;
                        }
                        else { gardien2.NombreDeVictoire += 1; gardien1.NombreDefaite += 1; }
                    }
                    //if pointer is >2 then we are at the score line
                    if (pointerLine > 2)
                    {
                        char CeDontLeJoueurAFait;
                        //i+2 from i=2, algorithm to find the index of what the players did
                        for (int i = 2; i <= part.Length; i = i + 2)
                        {
                            if (char.TryParse(part[i].ToUpper(), out CeDontLeJoueurAFait))
                            {
                                if (CeDontLeJoueurAFait == 'B')
                                {
                                    if (IsJoueurExistInTheList(ListJoueur,part[i - 1]))
                                    {
                                        var joueur = FindJoueurInTheList(ListJoueur,part[i - 1]);
                                        //Console.WriteLine("joueur trouver? : " + (joueur.Nom + " " + joueur.PostNom).ToUpper());
                                        joueur.NombreDeBut++;
                                        if (!IsJoueurExistInTheList(laPartie.GetListJoueurEnGeneral(), part[i - 1]))
                                        {
                                            laPartie.AjouterJoueurDansLaListdeLaPartie(joueur);
                                        }
                                    }
                                    else
                                    {
                                        JournalDesErreurs(part[i - 1] + " N'est pas repertoriee dans la ligue");
                                    }
                                }
                                if (CeDontLeJoueurAFait == 'A')
                                {
                                    if (IsJoueurExistInTheList(ListJoueur, part[i - 1]))
                                    {
                                        var joueur = FindJoueurInTheList(ListJoueur, part[i - 1]); 
                                        joueur.NombreDePasse++;
                                        if (!IsJoueurExistInTheList(laPartie.GetListJoueurEnGeneral(), part[i - 1]))
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
                        }                      
                    }
                    if (pointerLine == maxLine)
                    {
                        //since we don't have a specific information about who played, we increment NombreDeMatch for all player in the team
                        foreach (JoueurDeSurface j in laPartie.Equipe1.GetListJoueurDeSurface())
                        {
                            j.NombreDeMatch++;
                        }
                        foreach (JoueurDeSurface j in laPartie.Equipe2.GetListJoueurDeSurface())
                        {
                            j.NombreDeMatch++;
                        }
                        pointerLine = 1;
                    }
                    else
                    {
                        pointerLine++;
                    }
                }
            }
            streamReader.Close();
        }
        /// <summary>
        /// methode to write error in the log
        /// </summary>
        /// <param name="j"></param>
        public static void JournalDesErreurs(String j)
        {
            StreamWriter writer = new StreamWriter("../../JournalDesErreurs.txt",true);
            writer.WriteLine("Le joueur "+j+" n'est pas repertorier dans la list de la ligue");
            writer.WriteLine(Environment.NewLine);
            writer.Close();
        }
        /// <summary>
        /// methode that check if a player exist in the league
        /// </summary>
        /// <param name="listJouer">list of league player</param>
        /// <param name="nomJoueurAVerifier">name to find</param>
        /// <returns>retun true if the player exist</returns>
        public bool IsJoueurExistInTheList(List<Joueur> listJouer, String nomJoueurAVerifier)
        {
            if (listJouer.Any(j => (j.Nom + " " + j.PostNom).Trim().ToUpper().Equals(nomJoueurAVerifier.Trim().ToUpper())))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// method that find and return the player from the league list of player
        /// </summary>
        /// <param name="listJouer">list of player of the league</param>
        /// <param name="nomJoueurATrouver">name to find</param>
        /// <returns>return the joueur object</returns>
        public Joueur FindJoueurInTheList(List<Joueur> listJouer, string nomJoueurATrouver)
        {
            Joueur joueur = listJouer.Find(j => (j.Nom + " " + j.PostNom).Trim().ToUpper().Equals(nomJoueurATrouver.Trim().ToUpper()));
            return joueur;
        }
    }
}