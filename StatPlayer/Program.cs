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
        static League league;
        
        static void Main(string[] args)
        {
            init();
            int chx=0;
            do
            {
                Console.Write(AffichageBannerEtMenu());
                chx = ChoixUtilisateur();
                while (chx == -1)
                {
                    Console.Write("Votre choix doit etre entre 0-4 : ");
                    chx = ChoixUtilisateur();
                }
                if (chx == 1)
                {
                    league.LectureResultat("resultat");
                    Console.Write("Appuyez sur n'importe quelle touche pour revenir au menu principal : ");
                    chx = Console.ReadKey().KeyChar;
                }
                if (chx == 2)
                {
                    EcrireSurEcran(league.ProduirClassementJoueurParEquipe());
                    Console.Write("Appuyez sur n'importe quelle touche pour revenir au menu principal : ");
                    chx=Console.ReadKey().KeyChar;
                    
                }
                if (chx == 3)
                {
                    EcrireSurEcran(league.ProduirClassementGenJoueurDeSurface());
                    Console.Write("Appuyez sur n'importe quelle touche pour revenir au menu principal : ");
                    chx = Console.ReadKey().KeyChar;
                }
                if (chx == 4)
                {
                    EcrireSurEcran(league.ProduirClassementGenGardien());
                    Console.Write("Appuyez sur n'importe quelle touche pour revenir au menu principal : ");
                    chx = Console.ReadKey().KeyChar;
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
        private static int ChoixUtilisateur()
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
            if ((chx > -1) && (chx < 5))
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
            try
            {
                StreamWriter fWriter = new StreamWriter("../../" + nom + ".txt");
                fWriter.WriteLine(ParseListToString(list));
            }
            catch (Exception)
            {
                throw new ApplicationException("Errreur lors de l'ecriture sur disk");
            }
            
        }
        private static void EcrireSurFicher(String list, String nom)
        {
            try
            {
                StreamWriter fWriter = new StreamWriter("../../" + nom + ".txt");
                fWriter.WriteLine(list);
            }
            catch (Exception)
            {
                throw new ApplicationException("Erreur lors de l'ecriture du fichier");
            }
        }
        private static String ParseListToString(List<Joueur> list)
        {
            String data="";
            List<JoueurDeSurface> listJoueurDeSurface = list.OfType<JoueurDeSurface>().ToList();
            List<Gardien> lisGardien = list.OfType<Gardien>().ToList();
            if (listJoueurDeSurface.Count > 0)
            {
                data+= " *********************************classement general des Joueurs de surface******************************\n";
                data += listJoueurDeSurface.ToStringTable(
                  new[] { "Nom", "Post-Nom", "Nom Equipe", "Position", "Match", "Buts", "Passes", "Total" },
                  a => a.Nom, a => a.PostNom, a => a.NomEquipe, a => a.Position, a => a.NombreDeMatch,
                  a => a.NombreDeBut, a => a.NombreDePasse, a => a.Rendement);
            }
            if (lisGardien.Count > 0)
            {
                data += " *************************************classement general des Gardiens******************************\n";
                data += (lisGardien.ToStringTable(
                  new[] { "Nom", "Post-Nom", "Nom Equipe", "Position", "Match", "Buts", "Passes", "Total" },
                  a => a.Nom, a => a.PostNom, a => a.NomEquipe, a => a.Position, a => a.NombreDeMinute,
                  a => a.NombreDeBut, a => a.NombreDePasse, a => a.Rendement));
            }
            return data;
        }
    }
}