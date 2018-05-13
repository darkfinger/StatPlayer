# StatPlayer
INF731 Programmation Orienté Objet - TPII Hiver 2018
Statistique de rendement des joueurs de la LNH

Par : David Kapanga, Abdelwahab Laouni, Jean Robert LeRiche, Rogers Mukuna Kashala

Le travail consiste à mettre en place un système qui permettra de produire des statistiques sur le rendement des joueurs de la LNH.
Le système devra produire des statistiques sur le rendement des joueurs, s’exécutera avec des fichiers contenant des données initiales sur les détails des équipes et les statistiques des joueurs, qui établira l’état initiale du système, qui se fera une fois au début de chaque exécution.

A.	Établir la composition de chaque équipe ; les joueurs et leurs statistiques
B.	Le système devra offrir un menu utilisateur avec les choix suivant :
1.	Traiter un fichier des résultats des matchs – permettra au système de traiter de nouvelles données pour faire évoluer les statistiques des joueurs 
2.	Produire le classement des joueurs par équipe
3.	Produire le classement général des joueurs
4.	Produire le classement général des gardiens
5.	Option pour quitte le programme  
C.	Le programme devra prévoir une fonctionnalité qui permettra de produire un journal des erreurs qui indiquera l’information d’un joueur inexistant qui sera entré lors du traitement des statistiques.
D.	La fonctionnalité de traiter un fichier de résultats des matchs.
E.	Produire le classement des joueurs par équipe, avec option d’affichage à l’écran ou dans production des résultats dans un fichier.
F.	Présentation des joueurs équipe par équipe en ordre alphabétique et en ordre décroissant.
Format des fichiers

Le programme a été conçu de manière à fonctionner uniquement avec des fichiers de format texte.
Il utilisera des fichiers textes pour son démarrage, recevra des et produira des fichiers texte

3.4.	Fonctionnalités développées

Les fonctionnalités suivantes ont été mises en place afin de repondre au besoins:
1.	Un menu principal avec les options utilisateurs suivantes :
a.	Traiter un fichier des résultats des matchs
b.	Produire le classement général des joueurs par équipe
c.	Produire le classement général des joueurs de surface
d.	Produire le classement général des gardiens
e.	Quitter le programme

Chaque option offre une pssibilité d’affichage à l’écran ou la création d’un fichier text contenant les résultats d’exécution.
La fonction de lecture de fichier Equipes.txt, qui permet d’ouvrir le fichier, lire le fichier, ajouter les équipes dans une liste, valide le nombre d’entrées, un nombre maximun de 30 est défini, les noms en double sont ignorés et ferme le fichier. 
La fonctionnalité lire fichier JoueursStats.txt permet d’ouvrir le fichier, lire le fichier, ajouter les noms des joueurs dans une liste, detecte s’il s’agit d’un gardien ou un joueur de position puis ferme le fichier. La fonctionnalité lire fichier ResultatMatch.txt permet de lire le fichier, ajouter les matchs dans un liste et fait une validation afin de s’assurer qu’il ne peut y avoir plus de deux aides pour un but, il doit y avoir autant de compteurs que de but sauf pour les fusillades, s’assure que le même gardien de l’équipe occupe le filet pendant tout le match, il detecte s’il y a plus qu’un match.

Le temps des gardiens sera déterminé selon le type de rencontre:

1.	Rencontre étant fini d’une manière régulière au bout de 60 minutes
2.	Rencontre  étant fini par fusillade
3.	Rencontre étant fini en prolongation

Dans une rencontre finissant regulièrement les buts sont additionnés
Dans une rencontre finissant en fusillade donne deux points sont accordés à l'équipe gagnante et un point à l'équipe perdante

Les détails suivants seront disponibles s’il s’agit d’un jour de surface : 
1.	Le total des buts
2.	Les joueurs ayant totalisé plus de buts que les autres s’affichera en premier, sinon, 

3.	L’ordre alphabétique sera un point de décision

Quant au gardients, ils seront classés selon les critères suivants :
1.	Par le moyenne en ordre croissant
2.	Nombre de minutes jouées
3.	En ordre alphabétique 

Le programme lors de la creation du rapports de classement des joueurs par  équipe intérrogera l’utilisateur sur le mode création du rapport ; sur l’écran ou dans un fichier
1.	Traiter un ficher de resultats des matchs
2.	Produire le classement des joueurs par Equipe
3.	Produire le classement general des Joueurs de surface
4.	Produire le classement general des Gardiens

Il est aussi prévu une autre option qui permet à l’utilisateur de quitter prematuréement le programme qui est l’option 0.
	
	L’option 1 - demandera à l’utilisateur de fournir le fichier des résultats des matchs
 

Les options 2, 3 et 4 pour le création des differents rapports de classement des joueurs par Equipe, classement general des Joueurs de surface et classement general des Gardiens demanderont à l’usager de choisir le mode de creation du rapport ; soit sur l’écran ou dans un fichier .txt


3.5.	Bugs restants et limites
	
Aucun bug n’a été identifié durant les derniers tests effectués, néanmoins il n’est pas exclu qu’il pourrait en subvenir en cours d’exécution du programme, ce qui demandera évidemment une correction du programme. Aucune erreur n’a été détectée lors de test avec des fichiers cohérent (Equipe.txt, JoueurStat.txt, resultat.txt). Le programme marche correctement et produit le résultat attendu. 

3.6.	Test

Plusieurs tests ont été effectués afin de vérifier que le programme fonctionne correctement et qu’aucun aspect du problème ni détails n’ont été mis de côté.
4.	Spécification technique
	
4.1.	Données d’entrée et information fournie

1.	Un fichier équipe dans le format ci-dessous : Équipe, ville, division, association

2.	Un fichier des statistiques des joueurs ‘JoueursStats, dans le format ci-dessous :
Joueur de surface : Défenseur, Allier Gauche, Allier Droit, Centre avec les attributs suivant : Nom Equipe, Nom Joueur, Position, Nombre Match, Nombre But, Nombre Passe
Gardien de but avec les attributs suivants : Nom Equipe, Nom Joueur, Position, Nombre Minutes Jouées, Nombre Victoires, Nombre Défaites, Nombre Buts Comptes

3.	Un fichier des résultats des matchs dans le format ci-dessous avec les attributs : 
NomEquipe1, NombreBut1, NomEquipe2, NombreBut2, TypePartie (= Regulier, Prolongation, Fusillade)

4.2.	Gestion des erreurs

Vue le manque de temps alloué au Project, toutes les erreurs ont été gérées comme des erreurs d’application « ApplicationException » et sont capturées en un seul block dans la méthode principale du programme client, (ces erreurs entrainent l’affichage d’un message mais n’arrêtent pas l’exécution du programme, le traitement spécifique ayant entrainé l’erreur est Just ignoré.
Notez aussi qu’une erreur survenue lors de l’initialisation du programme entraine son arrêt car le programme doit commencer avec un état cohérent, l’utilisateur doit s’assurer que le fichier Equipe.txt et JoueurStat.txt dès l’initialisation sont dans un bon format.
Certains cas d’exception plus complexe n’ont pas été traité tell que :
	Joueur de même Nom dans une même Equipe.
	Un fichier résultat contenant deux assistances du même joueur pour un but.

4.3.	Environnement de développement

En de la réalisation de ce projet et selon les requis, l’outil de développement Microsoft Visual studio est celui qui a été utilisé
	
4.4.	Codes du programme

Le code du programme se trouve en annexe du présent journal de développement.	
5.	Conclusion

Différent aspect de la programmation orienté objet vues durant le cours ont été mis en pratique dans le cadre de la réalisation du présent travail.
Une analyse préliminaire et détaillée du problème afin de déterminer l’approche à suivre afin de répondre aux besoins de réalisation.
