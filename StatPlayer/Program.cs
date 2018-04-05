using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StatPlayer
{
    class Program
    {
        static League league;
        
        static void Main(string[] args)
        {
            init();
            Gardien n = new Gardien("Christopher", "Gibson", "G", 310, 0, 0, 4, 2, 211, 100);
            Console.WriteLine((float)(Math.Round((float)(4 / (60/60)), 2)));
    int chx=0;
            do
            {
                Console.Write(AffichageBannerEtMenu());
                chx = ChoixUtilisateur(0,4);
                while (chx == -1)
                {
                    Console.Write("Votre choix doit etre entre 0-4 : ");
                    chx = ChoixUtilisateur(0,4);
                }
                if (chx == 1)
                {
                    Console.Write("Give the result file's name : ");
                    league.LectureResultat(DemandDuFichier());
                    Console.Write("Appuyez sur n'importe quelle touche pour revenir au menu principal : ");
                    chx = Console.ReadKey().KeyChar;
                }
                if (chx == 2)
                {
                    Console.Write("Ou voulez-vous Afficher les statistique : \n1.Affichage a l'Ecrant \n2.Creer un fichier txt.");
                    int affichage = ChoixUtilisateur(1, 2);
                    while (affichage == -1)
                    {
                        Console.Write("Votre choix doit etre entre 1.(Affichage Ecran) et 2.(Creer fichier) : ");
                        affichage = ChoixUtilisateur(1,2);
                    }
                    if (affichage == 1)
                    {
                        EcrireSurEcran(league.ProduirClassementJoueurParEquipe());
                        Console.Write("Appuyez sur n'importe quelle touche pour revenir au menu principal : ");
                        chx=Console.ReadKey().KeyChar;
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
                    Console.Write("Ou voulez-vous Afficher les statistique : \n1.Affichage a l'Ecrant \n2.Creer un fichier txt.");
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
                    Console.Write("Ou voulez-vous Afficher les statistique : \n1.Affichage a l'Ecrant \n2.Creer un fichier txt.");
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

            } while (chx != 0);
        }
        private static void init()
        {
            league = new League(31);
            league.AffectationJoueurDansEquipe();
        }        
        private static String AffichageBannerEtMenu()
        {
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
        private static void EcrireSurEcran(List<Joueur> list)
        {
            Console.WriteLine(ParseListToString(list));
        }
        private static void EcrireSurEcran(String list)
        {
            Console.WriteLine(list);
        }
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
                  a => a.Nom, a => a.PostNom, a => a.NomEquipe, a=> a.NombreDeVictoire,a =>a.NombreDefaite, a => a.NombreDeMinute,
                  a => a.NombreDeBut, a => a.NombreDePasse, a => a.NombreTotalDeTire, a => a.NombreButAlloue, a => a.Efficacite, a => a.Rendement));
            }
            return data;
        }
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
        private static String NomDuFichierDestination()
        {
            Console.Write("Enregistrer le resultat sous quel nom : ");
            String nom = Console.ReadLine();
            return nom;
        }
    }
}