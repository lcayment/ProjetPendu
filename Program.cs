using System;
using System.IO;

namespace ProjetPendu
{
    class Program
    {
        /* PROCEDURES */
        public static void AfficherMotADeviner(char NouvelleLettre)
        {
            /* Nom : AfficherMotADeviner
             * Objectif :  A chaque tour, affiche le mot à deviner avec la nouvelle lettre donnée par l'utilisateur (NouvelleLettre)
             * Paramètre(s) d'entrée : char NouvelleLettre correspond à la lettre proposée par le joueur (humain ou ordinateur)
             * Variable de retour : void
            */


        }

        public static void PartieAbandonnee ()
        {
            /* Nom : PartieAbandonnee
             * Objectif :  Affiche "Abandon partie !" + le mot à deviner + dessin du pendu
             * Paramètre(s) d'entrée : aucun
             * Variable de retour : void
            */
        }

        /* FONCTIONS */
        public static bool VerifMotHumain (string MotADeviner)
        {
            /* Nom : VerifMotHumain
             * Objectif : Cette fonction permet de vérifier si le mot choisi par le joueur humain est présent dans le dictionnaire ou non
             * Paramètre(s) d'entrée : string MotADeviner correspond au mot choisi par le joueur humain
             * Variable de retour : bool MotDansDictionnaire prend la valeur true quand le mot est dans le dictionnaire et false quand le mot est absent du dictionnaire
            */


            return false;
        }


        public static int VerifierLettre (char Lettre)
        {
            /* Nom : VerifierLettre
             * Objectif : Verifie si la lettre (Lettre) est juste, fausse ou a deja été donnée
             * Paramètre(s) d'entrée : char Lettre = lettre proposée par le joueur (humain ou ordinateur)
             * Variable de retour : int EtatLettre prend la valeur 0 si la lettre fausse ou la valeur 1 si la lettre juste ou la valeur -1 si la lettre déjà donnée
            */


            return 0;
        }
        
        public static bool VerifierMot (string MotDonne, string MotADeviner)
        {
            /* Nom : VerifierMot
            * Objectif : Verifie si la mot (MotDonne) est équivalent au mot à deviner (MotADeviner)
            * Paramètre(s) d'entrée : string MotDonne = mot proposé par le joueur (humain ou ordinateur)
                                      string MotADeviner = mot choisi par l'ordinateur ou le joueur humain comme mot à deviner
            * Variable de retour : bool MotJuste prend la valeur true si le mot est juste (victoire) ou la valeur false si le mot est faux (défaite : affichage pendu + mot à deviner)
            */
            return false;
        }

        public static string ChoixMotOrdi ()
        {
            /* Nom : ChoixMotOrdi
            * Objectif : Retourne un mot selectionné par l'ordinateur (MotChoisi) dans le fichier DICOfr.txt
            * Paramètre(s) d'entrée : aucun
            * Variable de retour : string MotChoisi correspond au mot selectionné par l'ordinateur
            */

            return ("test");
        }

        public static int ChoixNbJoueurs ()
        {
            /* Nom : ChoixNbJoueurs
            * Objectif : Permet aux joueurs de sélectionner le nombre de joueurs
            * Paramètre(s) d'entrée : aucun
            * Variable de retour : int NbJoueursHumains prend la valeur 0 si l'ordinateur joue contre lui-même, 1 le joueur joue contre l'ordinateur, 2 deux joueurs humains jouent l'un contre l'autre
            */
            Console.WriteLine("Combien de joueurs ? ");
            int NbJoueurHumain = int.Parse(Console.ReadLine());
            
            if (NbJoueurHumain==0)
            {
                Console.WriteLine("L'ordinateur joue seul :'(");
            }
            else if (NbJoueurHumain==1)
            {
                Console.WriteLine("Vous jouez contre l'ordinateur.");
            }
            else if (NbJoueurHumain>1)
            {
                Console.WriteLine("Vous jouerez contre un autre joueur.");
            }

                return 1;
        }

        public static int ChoixRoles ()
        {

            Console.WriteLine("Si souhaites deviner le mot que l'ordinateur a choisi : tape 0");
            Console.WriteLine("Si tu souhaites faire deviner le mot à l'ordinateur : tape 1");
            int modejeu = int.Parse(Console.ReadLine());

            if (modejeu==0)
            {
                Console.WriteLine("Tu as choisi de deviner le mot que l'ordinateur a choisi");
            }
            else
            {
                Console.WriteLine("Tu as choisi de faire deviner un mot à l'ordinateur");

            }
            /* Nom : ChoixRoles
            * Objectif : Cette fonction n'est exécuté que lorsqu'il n'y a qu'1 joueur humain et elle permet de choisir le mode de jeu
            * Paramètre(s) d'entrée : aucun
            * Variable de retour : int Modejeu prend la valeur 0 si le joueur humain devine le mot ou la valeur 1 si l'ordinateur devine
            */
            return 1;
        }

        public static char PropositionLettreOrdi ()
        {
            /* Nom : PropositionLettreOrdi
            * Objectif : Cette fonction n'est exécuté que lorsqu'il n'y a qu'1 joueur humain et elle permet à l'ordinateur de proposer une lettre
            * Paramètre(s) d'entrée : aucun
            * Variable de retour : char Lettre correspond à la lettre de retour venant de l'ordi
            */

            return ('a');
        }

        public static string PropositionMotOrdi()
        {
            /* Nom : PropositionMotOrdi
            * Objectif : Cette fonction n'est exécuté que lorsqu'il n'y a qu'1 joueur humain et elle permet à l'ordinateur de proposer un mot
            * Paramètre(s) d'entrée : aucun
            * Variable de retour : string Mot correspond au mot de retour venant de l'ordi
            */

            return ("mot");
        }

        public static void AfficherRegles()
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\Lucie Vautier\Documents\00_ENSC\00_Cours\02_Programmation\ProjetPendu\Tools\ReglesJeu.txt");
   
            try
            {
                // Display the file contents to the console. Variable text is a string.
                System.Console.WriteLine(text);

            }
            catch (Exception ex)
            {
                // Code exécuté en cas d'exception 
                Console.Write("Une erreur est survenue au cours de la lecture des règles");               
            }
        }

     

        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenue sur notre jeu de pendu");
            int NbJoueursHumains;

            AfficherRegles();

            NbJoueursHumains = ChoixNbJoueurs();
            if ((NbJoueursHumains == 1)||(NbJoueursHumains == 2))      // Ordinateur contre humain ou humain contre humain
            {
                ChoixRoles();
            }


        }
    }
}
