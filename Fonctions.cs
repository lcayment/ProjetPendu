using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ProjetPendu
{
    /* THIS CLASS CONTAINS ALL FONCTIONS */
    class Fonctions
    {
        public static bool MotHumainDictionnaire(string MotADeviner)
        {
            /* Nom : MotHumainDictionnaire
             * Objectif : Cette fonction permet de vérifier si le mot choisi par le joueur humain est présent dans le dictionnaire ou non
             * Paramètre(s) d'entrée : string MotADeviner correspond au mot choisi par le joueur humain
             * Variable de retour : bool MotDansDictionnaire prend la valeur true quand le mot est dans le dictionnaire et false quand le mot est absent du dictionnaire
            */

            bool MotDansDictionnaire = false;
            string textFile = @"..\..\..\Tools\dicoFR.txt";     // correspond au chemin relatif du dictionnaire

            // Chaque ligne du fichier va être lue et être comparée au mot donné en paramètre
            string[] lines = File.ReadAllLines(textFile);

            foreach (string line in lines)      // Action a faire à chaque ligne 
            {
                if (!MotDansDictionnaire)       // Si le mot est dans le dictionnaire les tests ne sons pas refait
                {
                    if (MotADeviner == line)        // Le mot est en effet dans le dictionnaire
                    {
                        MotDansDictionnaire = true;
                        Console.WriteLine("Mot OK !");
                    }
                    else                           // Le mot n'est pas dans le dictionnaire
                    {
                        MotDansDictionnaire = false;
                    }
                }       
            }
            
            return MotDansDictionnaire;
        }

        public static char[] VerifierLettre(char Lettre, string MotChoisi, char[] MotTrouve)
        {
            /* Nom : VerifierLettre
             * Objectif : Verifie si la lettre donnée est juste ou fausse
             * Paramètre(s) d'entrée :  char Lettre = lettre proposée par le joueur (humain ou ordinateur)
             *                          string MotChoisi = mot à deviner
             *                          char [] MotTrouve = mot dans l'état actuel (avec les lettres devinées et les _)
             * Variable de retour : char [] MotTrouve est le mot dans l'état actuel (avec les lettres devinées et les _)
            */

            // On parcourt le mot choisi (qui est un tableau de char) pour comparer chaque lettre du mot avec la lettre donnée
            for (int i = 0; i < MotChoisi.Length; i++)
            {
                if (MotChoisi[i] == Lettre)
                {     
                    MotTrouve[i] = Lettre;
                }                
            }
            return MotTrouve;
        }

        public static bool VerifierMot(string MotDonne, string MotADeviner)
        {
            /* Nom : VerifierMot
            * Objectif : Verifie si la mot (MotDonne) est équivalent au mot à deviner (MotADeviner)
            * Paramètre(s) d'entrée : string MotDonne = mot proposé par le joueur (humain ou ordinateur)
                                      string MotADeviner = mot choisi par l'ordinateur ou le joueur humain comme mot à deviner
            * Variable de retour : bool MotJuste prend la valeur true si le mot est juste (victoire) ou la valeur false si le mot est faux (défaite : affichage pendu + mot à deviner)
            */
            bool MotJuste;
            if (MotDonne == MotADeviner)
            {
                MotJuste = true;
            }
            else
            {
                MotJuste = false;
            }

            return MotJuste;
        }

        public static string ChoixMotOrdi()
        {
            /* Nom : ChoixMotOrdi
            * Objectif : Retourne un mot selectionné par l'ordinateur (MotChoisi) dans le fichier DICOfr.txt
            * Paramètre(s) d'entrée : aucun
            * Variable de retour : string MotChoisi = mot selectionné par l'ordinateur
            */

            var lines = File.ReadAllLines(@"..\..\..\Tools\dicoFR.txt");        // On recupere le nombre de lines dans le dictionnaire
            var r = new Random();                                               // On crée un objet random
            var randomLineNumber = r.Next(0, lines.Length - 1);                 // On sélectionne une ligne random
            var MotChoisi = lines[randomLineNumber];                            // On lit le mot associé à la ligne

            return MotChoisi;
        }

        public static string ChoixMotHumain()
        {
            /* Nom : ChoixMotHumain
            * Objectif : Retourne un mot selectionné par le joueur humain (MotChoisi) dans le fichier DICOfr.txt qui a été vérifié
            * Paramètre(s) d'entrée : aucun
            * Variable de retour : string MotChoisi = mot selectionné par le joueur humain
            */

            string MotChoisi;
            bool MotDansDictionnaire;

            // Tant que le mot donné n'est pas dans le dictionnaire, il faut en redonner un 
            do
            {
                Console.WriteLine("Veuillez écrire un mot sans accent, en majuscules, présent dans le dictionnaire");
                MotChoisi = Console.ReadLine();
                MotDansDictionnaire = MotHumainDictionnaire(MotChoisi);          // permet de vérifier si le mot choisi est bien dans le dictionnaire
            } while (!MotDansDictionnaire);
            
            return MotChoisi;
        }

        public static int ChoixNbJoueurs()
        {
            /* Nom : ChoixNbJoueurs
            * Objectif : Permet aux joueurs de sélectionner le nombre de joueurs humains
            * Paramètre(s) d'entrée : aucun
            * Variable de retour : int NbJoueursHumains prend la valeur 0 si l'ordinateur joue contre lui-même, 
            *                                                           1 le joueur joue contre l'ordinateur, 
            *                                                           2 deux joueurs humains jouent l'un contre l'autre
            */

            int NbJoueurHumain;
            string stNbJoueurHumain;
            bool IsOk;

            // Tant que le nombre de joueurs donné n'est pas valide, on redemande un nombre de joueurs
            do
            {
                Console.WriteLine("Combien de joueurs ?");
                stNbJoueurHumain = Console.ReadLine();
                IsOk = int.TryParse(stNbJoueurHumain, out NbJoueurHumain);
            } while (!IsOk || NbJoueurHumain < 0);

            // Selon le nombre de joueurs, un mode différent est lancé
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
            * Objectif : Cette fonction n'est exécutée que lorsqu'il n'y a qu'1 joueur humain et elle permet de choisir le mode de jeu
            * Paramètre(s) d'entrée : aucun
            * Variable de retour : int Modejeu prend la valeur 0 si le joueur humain devine le mot,
            *                                                  1 si l'ordinateur devine
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
            * Objectif : Cette fonction n'est exécutée que lorsqu'il n'y a qu'1 joueur humain et elle permet à l'humain de proposer une lettre
            * Paramètre(s) d'entrée : aucun
            * Variable de retour : char Lettre correspond à la lettre de retour venant de l'humain
            */

            char Lettre;

            Console.WriteLine("Proposez une lettre en majuscules et sans accent :");
            Lettre = char.Parse(Console.ReadLine());    // L'utilisateur propose une lettre
            
            return (Lettre);
        }

        public static string PropositionMotHumain()
        {
            /* Nom : PropositionMotHumain
            * Objectif : Cette fonction n'est exécutée que lorsqu'il n'y a qu'1 joueur humain et elle permet à l'humain de proposer un mot
            * Paramètre(s) d'entrée : aucun
            * Variable de retour : string Mot = mot de retour venant de l'humain
            */

            string MotPropose;

            Console.WriteLine("Proposez un mot en majuscules et sans accent :");
            MotPropose = Console.ReadLine();      // L'utilisateur propose un mot

            return (MotPropose);
        }

        public static char PropositionLettreOrdi()
        {
            /* Nom : PropositionLettreOrdi
            * Objectif : Cette fonction n'est exécutée que lorsqu'il n'y a qu'1 joueur humain et elle permet à l'ordinateur de proposer une lettre
            * Paramètre(s) d'entrée : aucun
            * Variable de retour : char Lettre correspond à la lettre de retour venant de l'ordi
            */
            char Lettre;
            var r = new Random();

            Lettre = (char)r.Next('A', 'Z');
            Console.WriteLine("Lettre ordi : " + Lettre);

            return Lettre;
        }

        public static char[] PropositionMotOrdi(char[] MotTrouve)
        {
            /* Nom : PropositionMotOrdi
            * Objectif : Cette fonction n'est exécutée que lorsqu'il n'y a qu'1 joueur humain et elle permet à l'ordinateur de proposer un mot
            * Paramètre(s) d'entrée : char [] MotTrouve : mot avec les lettres trouvées et les _
            * Variable de retour : string Mot correspond au mot de retour venant de l'ordi
            * 
            * TO TEST
            */
            char[] MotPropose = { 'n', 'u', 'l', 'l' };     // On initialise le MotPropose
            int CmptLettreOK = 0;   // compte le nombre de lettres correctes dans le mot en cours
            int CmptLettreMax = 0; // sauvegarde le nombre de lettre correctes maximum

            // L'ordinateur compare chaque mot du dicofr.txt au mot trouve. Le premier mot correspondant est retourné.

            string textFile = @"..\..\..\Tools\dicoFR.txt";     // correspond au chemin relatif du dictionnaire

            // Chaque ligne du fichier va être lue et être comparée au mot donné en paramètre
            string[] lines = File.ReadAllLines(textFile);

            foreach (string line in lines)      // Action a faire à chaque ligne 
            {
                for (int i=0; i < line.Length; i++)     // on parcourt le mot de la ligne en cours
                {
                    if ((line[i] == MotTrouve[i]) || (MotTrouve[i] == '_'))       // on compare chaque lettre avec les lettres du MotTrouve
                    {
                        CmptLettreOK++;
                        if (CmptLettreOK > CmptLettreMax)
                        {
                            MotPropose = MotTrouve;
                            CmptLettreOK = CmptLettreMax;
                        }
                    }
                    else  // Ce mot ne correspond pas au MotTrouve
                    {
                        
                    }
                }
                CmptLettreOK = 0; 
            }
            return MotPropose;
        }

        public static int ActionsTour()
        {
            /* Nom : ActionsTour
             * Objectif :  Permet de centraliser les actions de chaque tour
             * Paramètre(s) d'entrée : aucun
             * Variable de retour : int ChoixPartie = action selectionnée
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
             * Objectif :  Permet de centraliser les actions de début de partie, à savoir l'affichage des règles et le nombre de joueurs
             * Paramètre(s) d'entrée : out int NbJoueursHumains est le paramètre qui sera récupéré qui correspond au nombre de joueurs humains
             * Variable de retour : int Roles = role choisi au sein du jeu (je devine ou je fais deviner)
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
                    // --------------- Affichage des règles --------------- //
                    Procedures.AfficherRegles();
                }
                else if (ChoixDebut == 2)
                {
                    // ------------ Choix du nombre de joueurs ------------ //
                    NbJoueursHumains = Fonctions.ChoixNbJoueurs();
                    if (NbJoueursHumains == 1)     // Ordinateur contre humain 
                    {
                        Roles = Fonctions.ChoixRoles();
                    }
                }
            } while (ChoixDebut != 2);

            return Roles;
        }

        public static bool PropositionHumain(string MotADeviner, char[] MotTrouve)
        {
            /* Nom : PropositionHumain
             * Objectif : Demande à l'humain un mot ou une lettre et le/la verifie
             * Paramètre(s) d'entrée : string MotADeviner correspond au mot choisi par l'ordinateur
             *                         char [] MotTrouve au mot avec les lettres trouvées et les _
             * Variable de retour : bool PartieFinie = signale si la partie se termine (prend la valeur true lorsque le joueur propose un mot)
            */

            char Lettre;
            string MotPropose;
            int PropositionHumain;
            bool MotJuste;
            bool PartieFinie = false;

            do
            {
                Console.WriteLine("Si vous voulez proposer une lettre, tapez 1");
                Console.WriteLine("Si vous voulez proposer un mot, tapez 2");

                PropositionHumain = int.Parse(Console.ReadLine());
            } while ((PropositionHumain != 1) && (PropositionHumain != 2));


            // --------------- L'humain veut proposer une lettre --------------- //
            if (PropositionHumain == 1)
            {
                Lettre = Fonctions.PropositionLettreHumain();                   // L'humain propose une lettre
                MotTrouve = Fonctions.VerifierLettre(Lettre, MotADeviner, MotTrouve);     // On vérifie si la lettre est présente dans le mot
                Procedures.AfficherMotADeviner(MotTrouve);
            }

            // --------------- L'humain veut proposer un mot --------------- //     TODO
            else if (PropositionHumain == 2)
            {
                PartieFinie = true;         // Indique que la partie est terminée après la proposition du mot
                MotPropose = Fonctions.PropositionMotHumain();
                MotJuste = Fonctions.VerifierMot(MotPropose, MotADeviner);
                if (MotJuste)
                {
                    Console.WriteLine("C'est la victoire ! Bravo !");
                }
                else
                {
                    Console.WriteLine("C'est perdu, dommage");
                    Procedures.PartieAbandonnee(MotADeviner);
                }
            }
            return PartieFinie;



        }
    }
}
