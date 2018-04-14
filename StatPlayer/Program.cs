using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Linq;

namespace StatPlayer
{
    class Program
    {
        /// <summary>
        /// Declaration de la variable static ligue
        /// </summary>
        static League league;


        /// <summary>
        /// entrer du programme
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //initialisation du programme
            try
            {
                init();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur lors de l'unitialisation "+e.Message);
            }

            int chx=0;//variable contenant le choix de l'utilisateur durant le deroulement du programme.
            do
            {
                try
                {
                    //affichage du menu
                    Console.Write(AffichageBannerEtMenu());
                    chx = ChoixUtilisateur(0, 4);
                    while (chx == -1)//si la methode return une valeur negative donc le choix est errone.
                    {
                        Console.Write("Votre choix doit etre entre 0-4 : ");
                        chx = ChoixUtilisateur(0, 4);
                    }
                    if (chx == 1)//traitement au cas ou le choix de l utilisateur a 1.
                    {
                        Console.Write("Donnez le nom du fichier des resultats : ");
                        league.LectureResultat(DemandDuFichier());
                        Console.Write("Fichier traiter, retourner au menu principal pour afficher les resultats a jours ");
                        Console.ReadKey();
                    }
                    if (chx == 2)
                    {
                        Console.Write("Ou voulez-vous Afficher les statistique : \n1.Affichage a l'Ecrant \n2.Creer un fichier txt.\nVotre choix : ");
                        int affichage = ChoixUtilisateur(1, 2);
                        while (affichage == -1)
                        {
                            Console.Write("Votre choix doit etre entre 1.(Affichage Ecran) et 2.(Creer fichier) : ");
                            affichage = ChoixUtilisateur(1, 2);
                        }
                        if (affichage == 1)
                        {
                            EcrireSurEcran(league.ProduirClassementJoueurParEquipe());
                            Console.Write("Appuyez sur n'importe quelle touche pour revenir au menu principal : ");
                            Console.ReadKey();
                        }
                        if (affichage == 2)
                        {
                            EcrireSurFicher(league.ProduirClassementJoueurParEquipe(), NomDuFichierDestination());
                            Console.Write("Appuyez sur n'importe quelle touche pour revenir au menu principal : ");
                            chx = Console.ReadKey().KeyChar;
                        }
                    }
                    if (chx == 3)
                    {
                        Console.Write("Ou voulez-vous Afficher les statistique : \n1.Affichage a l'Ecrant \n2.Creer un fichier txt.\nVotre choix : ");
                        int affichage = ChoixUtilisateur(1, 2);
                        while (affichage == -1)
                        {
                            Console.Write("Votre choix doit etre entre 1.(Affichage Ecran) et 2.(Creer fichier) : ");
                            affichage = ChoixUtilisateur(1, 2);
                        }
                        if (affichage == 1)
                        {
                            EcrireSurEcran(league.ProduirClassementGenJoueurDeSurface());
                            Console.Write("Appuyez sur n'importe quelle touche pour revenir au menu principal : ");
                            chx = Console.ReadKey().KeyChar;
                        }
                        if (affichage == 2)
                        {
                            EcrireSurFicher(league.ProduirClassementGenJoueurDeSurface(), NomDuFichierDestination());
                            Console.Write("Appuyez sur n'importe quelle touche pour revenir au menu principal : ");
                            chx = Console.ReadKey().KeyChar;
                        }
                    }
                    if (chx == 4)
                    {
                        Console.Write("Ou voulez-vous Afficher les statistique : \n1.Affichage a l'Ecrant \n2.Creer un fichier txt.\nVotre choix : ");
                        int affichage = ChoixUtilisateur(1, 2);
                        while (affichage == -1)
                        {
                            Console.Write("Votre choix doit etre entre 1.(Affichage Ecran) et 2.(Creer fichier) : ");
                            affichage = ChoixUtilisateur(1, 2);
                        }
                        if (affichage == 1)
                        {
                            EcrireSurEcran(league.ProduirClassementGenGardien());
                            Console.Write("Appuyez sur n'importe quelle touche pour revenir au menu principal : ");
                            chx = Console.ReadKey().KeyChar;
                        }
                        if (affichage == 2)
                        {
                            EcrireSurFicher(league.ProduirClassementGenGardien(), NomDuFichierDestination());
                            Console.Write("Appuyez sur n'importe quelle touche pour revenir au menu principal : ");
                            chx = Console.ReadKey().KeyChar;
                        }
                    }
                    if (chx == 0)
                        chx = 0;
                }
                //vue qu'il ya une multitude d erreur pouvan arriver nous avons generaliser la capture, manque de temps 
                //pour les traiter toute une par une
                catch(ApplicationException e)
                {
                    Console.WriteLine("Erreur survenue :" + e.Message);
                    Console.WriteLine("le traitement a ete annuler, veriffier que l'erreur et fixee, puis recomencer le traitement");
                    Console.Read();
                }
            } while (chx != 0);
        }

        /// <summary>
        /// Methode static qui initialise le programe en lisant les fichier JoueurStat.txt
        /// et Equipe.txt et affecte chaque joueurs dans une Equipe
        /// </summary>
        private static void init()
        {
            league = new League(31);
            league.AffectationJoueurDansEquipe();
        }
        /// <summary>
        /// Methode static qui affiche l'entete et le menu principal
        /// </summary>
        /// <returns>retourne le string a affichier</returns>
        private static String AffichageBannerEtMenu()
        {
            Console.Clear();
            string msg = "\n";
            msg += new string(' ', 5);
            msg += new string('*', 60);
            msg += ("\n     *                                                          *");
            msg += ("\n     *                BIENVENUE SUR HOCKEYSTAT Ver1.0           *");
            msg += ("\n     *   Écrit par David K.-Rogers K.-Jean Robert L.-Abdel L.   *");
            msg += ("\n     *                    INF731 Class Project                  *");
            msg += ("\n     *                                                          *\n");
            msg += new string(' ', 5);
            msg += new string('*', 60);
            msg += "\n";
            msg += "\n";
            msg += "************************[Menu Principal]*************************\n";
            msg += "1. Traiter un ficher de resultats des matchs\n";
            msg += "2. Produire le classement des joueurs par Equipe\n";
            msg += "3. Produire le classement general des Joueurs de surface\n";
            msg += "4. Produire le classement general des Gardiens\n";
            msg += "\n";
            msg += "0. Quitter le programme\n";
            msg += "****************************************************************\n";
            msg += "Votre choix : ";
            return msg;
        }
        /// <summary>
        /// Methode static qui prend le choix de l'utilisateur prend en param l'interval du choix
        /// </summary>
        /// <param name="minRang">le choix minim</param>
        /// <param name="maxRange">le choix max</param>
        /// <returns></returns>
        private static int ChoixUtilisateur(int minRang, int maxRange)
        {
            int chx;
            try
            {
                chx =int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                return -1;
            }
            if ((chx >= minRang) && (chx <= maxRange))
            { return chx; }
            else { return -1; }
            
        }
        /// <summary>
        /// Methode static qui affiche a l'ecran les stats d'une list 
        /// </summary>
        /// <param name="list">la list a afficher</param>
        private static void EcrireSurEcran(List<Joueur> list)
        {
            Console.Clear();
            Console.WriteLine(ParseListToString(list));
        }
        /// <summary>
        /// Methode static qui affiche a l'ecran le stat d'un string deja formater (overload)
        /// </summary>
        /// <param name="list">string de la list formater</param>
        private static void EcrireSurEcran(String list)
        {
            Console.Clear();
            Console.WriteLine(list);
        }
        /// <summary>
        /// overload de la Methode static qui ecrit les stats dans un fichier
        /// </summary>
        /// <param name="list">la lis a ecrire</param>
        /// <param name="nom">le nom du ficheir de destination</param>
        private static void EcrireSurFicher(List<Joueur> list,String nom)
        {
            StreamWriter fWriter;
            try
            {
                fWriter = new StreamWriter("../../" + nom + ".txt");
                fWriter.WriteLine(ParseListToString(list));
            }
            catch (Exception)
            {
                throw new ApplicationException("Errreur lors de l'ecriture sur disk");
            }
            fWriter.Close();
        }
        /// <summary>
        /// overload Methode static qui ecrit les stats dans un fichier a partir du string formater
        /// </summary>
        /// <param name="list">string formater a ecrire</param>
        /// <param name="nom">nom du fichier destination</param>
        private static void EcrireSurFicher(String list, String nom)
        {
            StreamWriter fWriter=null;
            try
            {
                fWriter = new StreamWriter("../../" + nom + ".txt");
                fWriter.WriteLine(list);
            }
            catch (Exception)
            {
                throw new ApplicationException("Erreur lors de l'ecriture du fichier");
            }
            fWriter.Close();
        }
        /// <summary>
        /// Parse une liste en string pour etre affichee
        /// </summary>
        /// <param name="list">list a transferer</param>
        /// <returns></returns>
        private static String ParseListToString(List<Joueur> list)
        {
            String data = Environment.NewLine; 
            List<JoueurDeSurface> listJoueurDeSurface = list.OfType<JoueurDeSurface>().ToList();
            List<Gardien> lisGardien = list.OfType<Gardien>().ToList();
            if (listJoueurDeSurface.Count > 0)
            {
                data+= " *********************************classement general des Joueurs de surface******************************";
                data += Environment.NewLine;
                data += listJoueurDeSurface.ToStringTable(
                  new[] { "Nom", "Post-Nom", "Nom Equipe", "Position", "Match", "Buts", "Passes", "Total" },
                  a => a.Nom, a => a.PostNom, a => a.NomEquipe, a => a.Position, a => a.NombreDeMatch,
                  a => a.NombreDeBut, a => a.NombreDePasse, a => a.Rendement);
            }
            if (lisGardien.Count > 0)
            {
                data += " *************************************classement general des Gardiens******************************";
                data += Environment.NewLine;
                data += (lisGardien.ToStringTable(
                  new[] { "Nom", "Post-Nom", "Nom Equipe","V","D", "Min.", "B", "A","Tire","But Al.","Effic.", "Rend." },
                  a => a.Nom, a => a.PostNom, a => a.NomEquipe, a=> a.NombreDeVictoire,a =>a.NombreDefaite, a => a.NombreDeMinute + ":" + a.NombreDeSecond,
                  a => a.NombreDeBut, a => a.NombreDePasse, a => a.NombreTotalDeTire, a => a.NombreButAlloue, a => a.Efficacite, a => a.Rendement));
            }
            return data;
        }
        /// <summary>
        /// Methode static qui prend et verifi le nom du fichier contenant le resulta du match
        /// </summary>
        /// <returns>return le path du nom du fichier donner</returns>
        private static String DemandDuFichier()
        {  
            String path = Console.ReadLine();
            //we verify that the path is correct and that the file exist
            path = Path.GetFullPath(path);
            if (path.Contains("\\bin\\Debug\\"))
            {
                String[] spliter = { "\\bin\\Debug" };
                string[] pathPart = path.Split(spliter, StringSplitOptions.RemoveEmptyEntries);
                path = pathPart[0] + pathPart[1];
            }
            if (String.IsNullOrWhiteSpace(path) || !File.Exists(path))
            {
                throw new ApplicationException("Erreur: le fichier n'exist pas");
            }
            return path;
        }
        /// <summary>
        /// Methode static qui demand le nom du fichier dest.
        /// </summary>
        /// <returns>retourne le nom d un fichier destination si correct</returns>
        private static String NomDuFichierDestination()
        {
            Console.Write("Enregistrer le resultat sous quel nom : ");
            String nom = Console.ReadLine();
            return nom;
        }
    }
}