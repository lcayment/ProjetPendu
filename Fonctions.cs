using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ProjetPendu
{
    /* THIS CLASS CONTAINS ALL FONCTIONS */
    class Fonctions
    {
        public static bool VerifMotHumain(string MotADeviner)
        {
            /* Nom : VerifMotHumain
             * Objectif : Cette fonction permet de vérifier si le mot choisi par le joueur humain est présent dans le dictionnaire ou non
             * Paramètre(s) d'entrée : string MotADeviner correspond au mot choisi par le joueur humain
             * Variable de retour : bool MotDansDictionnaire prend la valeur true quand le mot est dans le dictionnaire et false quand le mot est absent du dictionnaire
            */

            bool MotDansDictionnaire = false;
            string textFile = @"..\..\..\Tools\dicoFR.txt";

            string[] lines = File.ReadAllLines(textFile);
            foreach (string line in lines)      // Action a faire à chaque ligne 
            {
                if (!MotDansDictionnaire)
                {
                    if (MotADeviner == line)
                    {
                        MotDansDictionnaire = true;
                        Console.WriteLine("Mot OK !");
                        Console.WriteLine(line);
                        Console.WriteLine(MotADeviner);
                    }
                    else
                    {
                        MotDansDictionnaire = false;
                    }
                }       
            }
            
            return MotDansDictionnaire;
        }

        //LOLO
        public static int VerifierLettre(char Lettre, string MotChoisi)
        {
            /* Nom : VerifierLettre
             * Objectif : Verifie si la lettre (Lettre) est juste, fausse ou a deja été donnée
             * Paramètre(s) d'entrée : char Lettre = lettre proposée par le joueur (humain ou ordinateur)
             * Variable de retour : int EtatLettre prend la valeur 0 si la lettre fausse ou la valeur 1 si la lettre juste ou la valeur -1 si la lettre déjà donnée
            */
            int EtatLettre = 0;
            bool Lettreok = false;
              
            for (int i = 0; i < MotChoisi.Length; i++)
            {
                if (Lettreok == false)          // Si la lettre a deja été trouvée, on ne refait pas de test
                {
                    if (MotChoisi[i] == Lettre)
                    {
                        EtatLettre = 1;         // La lettre est juste
                        Lettreok = true;        // On ne reteste pas le mot, on attend la fin de la boucle for
                    }
                    //Pour l'instant on dit simplement si la lettre est dans le mot ou non
                    else
                    {
                        EtatLettre = 0;
                        //TODO : Après voir lettre=-1 pour dire que la lettre a déjà été donné

                    }
                }                   
            }
            if (EtatLettre == 1)
            {
                Console.WriteLine("La lettre est juste !");
            }
            else
            {
                Console.WriteLine("La lettre est fausse ...");
            }
            return EtatLettre;
        }

        public static bool VerifierMot(string MotDonne, string MotADeviner)
        {
            /* Nom : VerifierMot
            * Objectif : Verifie si la mot (MotDonne) est équivalent au mot à deviner (MotADeviner)
            * Paramètre(s) d'entrée : string MotDonne = mot proposé par le joueur (humain ou ordinateur)
                                      string MotADeviner = mot choisi par l'ordinateur ou le joueur humain comme mot à deviner
            * Variable de retour : bool MotJuste prend la valeur true si le mot est juste (victoire) ou la valeur false si le mot est faux (défaite : affichage pendu + mot à deviner)
            */

            return false;
        }

        //LOLO
        public static string ChoixMotOrdi()
        {
            /* Nom : ChoixMotOrdi
            * Objectif : Retourne un mot selectionné par l'ordinateur (MotChoisi) dans le fichier DICOfr.txt
            * Paramètre(s) d'entrée : aucun
            * Variable de retour : string MotChoisi correspond au mot selectionné par l'ordinateur
            */

            // Recupération du fichier dicoFR et selection d'une ligne random puis affichage
            var lines = File.ReadAllLines(@"..\..\..\Tools\dicoFR.txt");
            var r = new Random();
            var randomLineNumber = r.Next(0, lines.Length - 1);
            var MotChoisi = lines[randomLineNumber];

            return MotChoisi;
        }

        public static string ChoixMotHumain()
        {
            /* Nom : ChoixMotHumain
            * Objectif : Retourne un mot selectionné par le joueur humain (MotChoisi) dans le fichier DICOfr.txt
            * Paramètre(s) d'entrée : aucun
            * Variable de retour : string MotChoisi correspond au mot selectionné par le joueur
            */

            string MotChoisi;
            bool MotDansDictionnaire;
            // Tant que le mot donné n'est pas dans le dictionnaire, il faut en redonner un 
            do
            {
                Console.WriteLine("Veuillez écrire un mot sans accent, en majuscules, présent dans le dictionnaire");
                MotChoisi = Console.ReadLine();
                MotDansDictionnaire = VerifMotHumain(MotChoisi);          // permet de vérifier si le mot choisi est bien dans le dictionnaire
            } while (!MotDansDictionnaire);
            
            return MotChoisi;
        }

        public static int ChoixNbJoueurs()
        {
            /* Nom : ChoixNbJoueurs
            * Objectif : Permet aux joueurs de sélectionner le nombre de joueurs
            * Paramètre(s) d'entrée : aucun
            * Variable de retour : int NbJoueursHumains prend la valeur 0 si l'ordinateur joue contre lui-même, 1 le joueur joue contre l'ordinateur, 2 deux joueurs humains jouent l'un contre l'autre
            */

            int NbJoueurHumain = 0;
            string stNbJoueurHumain = "";
            bool IsOk = false;
            do
            {
                Console.WriteLine("Combien de joueurs ?");
                stNbJoueurHumain = Console.ReadLine();
                IsOk = int.TryParse(stNbJoueurHumain, out NbJoueurHumain);
            } while (!IsOk || NbJoueurHumain < 0);

            if (NbJoueurHumain == 0)
            {
                Console.WriteLine("L'ordinateur joue seul :'(");
                return NbJoueurHumain;
            }
            else if (NbJoueurHumain == 1)
            {
                Console.WriteLine("Vous jouez contre l'ordinateur.");
                return NbJoueurHumain;
            }
            else if (NbJoueurHumain == 2)
            {
                Console.WriteLine("Vous jouerez contre un autre joueur.");
                return NbJoueurHumain;
            }
            else
            {
                return -1;
            }

        }

        public static int ChoixRoles()
        {
            /* Nom : ChoixRoles
            * Objectif : Cette fonction n'est exécuté que lorsqu'il n'y a qu'1 joueur humain et elle permet de choisir le mode de jeu
            * Paramètre(s) d'entrée : aucun
            * Variable de retour : int Modejeu prend la valeur 0 si le joueur humain devine le mot ou la valeur 1 si l'ordinateur devine
            */
            Console.WriteLine("Si souhaites deviner le mot que l'ordinateur a choisi : tape 0");
            Console.WriteLine("Si tu souhaites faire deviner le mot à l'ordinateur : tape 1");
            int ModeJeu = int.Parse(Console.ReadLine());

            if (ModeJeu == 0)
            {
                Console.WriteLine("Tu as choisi de deviner le mot que l'ordinateur a choisi");
                return ModeJeu;
            }
            else
            {
                Console.WriteLine("Tu as choisi de faire deviner un mot à l'ordinateur");
                return ModeJeu;
            }

        }

        public static char PropositionLettreHumain()
        {
            /* Nom : PropositionLettreHumain
            * Objectif : Cette fonction n'est exécuté que lorsqu'il n'y a qu'1 joueur humain et elle permet à l'humain de proposer une lettre
            * Paramètre(s) d'entrée : aucun
            * Variable de retour : char Lettre correspond à la lettre de retour venant de l'humain
            */

            char Lettre;

            Console.WriteLine("Proposez une lettre en majuscules et sans accent :");
            Lettre = char.Parse(Console.ReadLine());                        // L'utilisateur propose une lettre
            
            return (Lettre);
        }

        public static string PropositionMotHumain()
        {
            /* Nom : PropositionMotHumain
            * Objectif : Cette fonction n'est exécuté que lorsqu'il n'y a qu'1 joueur humain et elle permet à l'humain de proposer un mot
            * Paramètre(s) d'entrée : aucun
            * Variable de retour : string Mot correspond au mot de retour venant de l'humain
            */

            string MotPropose;

            Console.WriteLine("Proposez un mot en majuscules et sans accent :");
            MotPropose = Console.ReadLine();                        // L'utilisateur propose une lettre

            return (MotPropose);
        }

        public static char PropositionLettreOrdi()
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

        public static int ActionsTour()
        {
            /* Nom : ActionsTour
             * Objectif :  Permet de centraliser les actions de chaque tour
             * Paramètre(s) d'entrée : null
             * Variable de retour : int ChoixPartie qui correspond à l'action selectionnée
            */

            int ChoixPartie;

            Console.WriteLine("\nChoississez une action : ");
            Console.WriteLine("Tapez 0 pour abandonner !");
            Console.WriteLine("Tapez 1 pour afficher les règles !");
            Console.WriteLine("Tapez 2 pour continuer la partie !");

            ChoixPartie = int.Parse(Console.ReadLine());

            return ChoixPartie;
        }

        public static int DebutPartie(out int NbJoueursHumains)
        {
            /* Nom : DebutPartie
             * Objectif :  Permet de centraliser les actiosn de début de partie, à savoir l'affichage des règles et le nombre de joueurs
             * Paramètre(s) d'entrée : out int NbJoueursHumains est le paramètre qui sera récupéré qui correspond au nombre de joueurs humains
             * Variable de retour : int Roles qui correspond au role choisi au sein du jeu (je devine ou je fais deviner)
            */

            int ChoixDebut;
            int Roles = -1;
            NbJoueursHumains = -1;

            do
            {
                Console.WriteLine("Choississez une action : ");
                Console.WriteLine("Tapez 1 pour afficher les règles !");
                Console.WriteLine("Tapez 2 pour commencer la partie !");
                ChoixDebut = int.Parse(Console.ReadLine());

                if (ChoixDebut == 1)
                {
                    // AFFICHAGE DES REGLES //
                    Procedures.AfficherRegles();
                }
                else if (ChoixDebut == 2)
                {
                    // CHOIX DU NOMBRES DE JOUEURS //
                    NbJoueursHumains = Fonctions.ChoixNbJoueurs();
                    if (NbJoueursHumains == 1)     // Ordinateur contre humain 
                    {
                        Roles = Fonctions.ChoixRoles();
                    }
                }
            } while (ChoixDebut != 2);

            return Roles;
        }

    }
}
