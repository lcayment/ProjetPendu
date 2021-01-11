using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ProjetPendu
{
    /* THIS CLASS CONTAINS ALL FONCTIONS */
    class Fonctions
    {
        // FONCTIONS DE VERIFICATION
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

        public static char[] VerifierLettre(char Lettre, string MotChoisi, char[] MotTrouve, int Tentative)
        {
            /* Nom : VerifierLettre
             * Objectif : Verifie si la lettre donnée est juste ou fausse
             * Paramètre(s) d'entrée :  char Lettre = lettre proposée par le joueur (humain ou ordinateur)
             *                          string MotChoisi = mot à deviner
             *                          char [] MotTrouve = mot dans l'état actuel (avec les lettres devinées et les _)
             * Variable de retour : char [] MotTrouve est le mot dans l'état actuel (avec les lettres devinées et les _)
            */

            bool LettreJuste = false;
            bool LettreDejaDonnee = false;

            //La variable tentative s'incrémente seulement lorsque le joueur propose un mot
            //On récupère Tentative dans le main pour mettre cette variable en condition while<=11 pour continuer à jouer
            // ou pour dire si le joueur a perdu 
            /*Console.WriteLine("Tentative ="+Tentative);
            Tentative++;
            Console.WriteLine("tentative ="+Tentative);
            Console.WriteLine("Il vous reste " + (11 - Tentative) + " tentatives");
            if (Tentative>=11)
            {
                Procedures.PartiePerdue(MotChoisi);
            }
            */

            // On parcourt le mot choisi (qui est un tableau de char) pour comparer chaque lettre du mot avec la lettre donnée
            for (int i = 0; i < MotChoisi.Length; i++)
            {
                if (MotTrouve[i] == Lettre)
                {
                    LettreDejaDonnee = true;
                }
                else
                {
                    if (MotChoisi[i] == Lettre)
                    {
                        MotTrouve[i] = Lettre;
                        LettreJuste = true;
                    }
                }
            }

            if (LettreDejaDonnee)
            {
                Console.WriteLine("La lettre a deja été donnée");
            }
            else
            {
                if (LettreJuste)
                {
                    Console.WriteLine("La lettre est juste !");
                }
                else
                {
                    Console.WriteLine("La lettre est fausse ...");
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

        // FONCTIONS DE CHOIX
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

            Console.WriteLine("\nL'ordinateur a choisi un mot, c'est parti !");
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
                Console.WriteLine("\n--------------------------------------------------------------------------------");
                Console.WriteLine("Tape 0 pour que l'ordinateur joue seul \nTape 1 si tu veux jouer avec l'ordinateur \nTape 2 si tu veux joueur contre un autre humain !");
                Console.WriteLine("\nAlors ? Combien y-a-t-il de joueurs ?");

                // Permet de tester le type de la variable entrée, si ca n'est pas un int IsOk est false et la boucle recommence
                stNbJoueurHumain = Console.ReadLine();
                IsOk = int.TryParse(stNbJoueurHumain, out NbJoueurHumain);

            } while (!IsOk || NbJoueurHumain < 0);

            // Selon le nombre de joueurs, un mode différent est lancé
            if (NbJoueurHumain == 0)        // l'ordinateur joue seul
            {
                Console.WriteLine("L'ordinateur joue seul :'(");
                return NbJoueurHumain;
            }
            else if (NbJoueurHumain == 1)   // un joueur humain
            {
                Console.WriteLine("Vous jouez contre l'ordinateur.\n");
                return NbJoueurHumain;
            }
            else if (NbJoueurHumain == 2)   // deux joueurs humains
            {
                Console.WriteLine("Vous jouerez contre un autre joueur.");
                return NbJoueurHumain;      // Valeur à remplacer par NbJoueurHumain lorsque le mode sera implémenté
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

            int ModeJeu;
            string stModeJeu;
            bool IsOk;

            // Tant que le mode de jeu donné n'est pas valide, on le redemande
            do
            {
                Console.WriteLine("Si souhaites deviner le mot que l'ordinateur a choisi : tape 0");
                Console.WriteLine("Si tu souhaites faire deviner le mot à l'ordinateur : tape 1");

                // Permet de tester le type de la variable entrée, si ca n'est pas un int IsOk est false et la boucle recommence
                stModeJeu = Console.ReadLine();
                IsOk = int.TryParse(stModeJeu, out ModeJeu);

            } while (!IsOk || ModeJeu != 0 && ModeJeu != 1);


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

        // FONCTIONS DE PROPOSITIONS
        public static char PropositionLettreHumain()
        {
            /* Nom : PropositionLettreHumain
            * Objectif : Cette fonction n'est exécutée que lorsqu'il n'y a qu'1 joueur humain et elle permet à l'humain de proposer une lettre
            * Paramètre(s) d'entrée : aucun
            * Variable de retour : char Lettre correspond à la lettre de retour venant de l'humain
            */

            char Lettre;

            Console.WriteLine("\nProposez une lettre en majuscules et sans accent :");
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

        public static char PropositionLettreOrdi(int CmptTour)
        {
            /* Nom : PropositionLettreOrdi
            * Objectif : Cette fonction n'est exécutée que lorsqu'il n'y a qu'1 joueur humain et elle permet à l'ordinateur de proposer une lettre
            * Paramètre(s) d'entrée : aucun
            * Variable de retour : char Lettre correspond à la lettre de retour venant de l'ordi
            * 
            */
            char[] Alphabet = { 'E', 'A', 'I', 'S', 'N', 'R', 'T', 'O', 'L', 'U', 'D', 'C', 'M', 'P', 'G', 'B', 'V', 'H', 'F', 'Q', 'Y', 'X', 'J', 'K', 'W', 'Z' };

            Console.WriteLine("\nL'ordinateur propose la {0}e lettre du tableau : {1} ", CmptTour, Alphabet[CmptTour]);

            return Alphabet[CmptTour];
        }

        public static string PropositionMotOrdi(char[] MotTrouve)
        {
            /* Nom : PropositionMotOrdi
            * Objectif : Cette fonction n'est exécutée que lorsqu'il n'y a qu'1 joueur humain et elle permet à l'ordinateur de proposer un mot
            * Paramètre(s) d'entrée : char [] MotTrouve : mot avec les lettres trouvées et les _
            * Variable de retour : string Mot correspond au mot de retour venant de l'ordi
            * 
            */

            string MotPropose = "null";     // On initialise le MotPropose
            int CmptLettreOK = 0;   // compte le nombre de lettres correctes dans le mot en cours
            int CmptLettreMax = 0; // sauvegarde le nombre de lettre correctes maximum

            // L'ordinateur compare chaque mot du dicofr.txt au mot trouve. Le premier mot correspondant est retourné.

            string textFile = @"..\..\..\Tools\dicoFR.txt";     // correspond au chemin relatif du dictionnaire

            // Chaque ligne du fichier va être lue et être comparée au mot donné en paramètre
            string[] lines = File.ReadAllLines(textFile);

            foreach (string line in lines)      // Action a faire à chaque ligne 
            {
                if (line.Length == MotTrouve.Length)    // On ne va étudier que les mots qui ont la même longueur que le mot à trouver
                {
                    for (int i = 0; i < line.Length; i++)     // on parcourt le mot de la ligne en cours
                    {
                        if ((line[i] == MotTrouve[i]) || (MotTrouve[i] == '_'))       // on compare chaque lettre avec les lettres du MotTrouve
                        {
                            CmptLettreOK++;
                            if (CmptLettreOK > CmptLettreMax)
                            {
                                MotPropose = line;          // Le mot de la ligne pourrait correspondre au mot à trouver, on le sauvegarde
                                CmptLettreMax = CmptLettreOK;   // on sauvegarde le nombre de lettre correctes
                            }
                        }
                        else; // Ce mot ne correspond pas au MotTrouve
                    }
                    CmptLettreOK = 0;
                }
            }
            return MotPropose;
        }

        public static bool PropositionHumain(string MotADeviner, char[] MotTrouve, int Tentative)
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
            string stPropositionHumain;

            bool MotJuste;
            bool PartieFinie = false;
            bool IsOk;

            Tentative++;
            Console.WriteLine("tentative propositionHumain = " + Tentative);
            if (Tentative == 11)
            {
                Procedures.PartiePerdue(MotADeviner);
            }


            // Tant que l'humain ne propose pas 1 ou 2, on lui redemande
            do
            {
                Console.WriteLine("\nSi vous voulez proposer une lettre, tapez 1");
                Console.WriteLine("Si vous voulez proposer un mot, tapez 2");
                Console.WriteLine("Si vous voulez abandonner, tapez 0");

                // Permet de tester le type de la variable entrée, si ca n'est pas un int IsOk est false et la boucle recommence
                stPropositionHumain = Console.ReadLine();
                IsOk = int.TryParse(stPropositionHumain, out PropositionHumain);

            } while (!IsOk || (PropositionHumain != 1) && (PropositionHumain != 2) && (PropositionHumain != 0));

            // --------------- L'humain veut abandonner --------------- //
            if (PropositionHumain == 0)
            {
                PartieFinie = true;
                Procedures.PartieAbandonnee(MotADeviner);
            }
            // --------------- L'humain veut proposer une lettre --------------- //
            else if (PropositionHumain == 1)
            {
                Lettre = Fonctions.PropositionLettreHumain();                   // L'humain propose une lettre
                MotTrouve = Fonctions.VerifierLettre(Lettre, MotADeviner, MotTrouve, Tentative);     // On vérifie si la lettre est présente dans le mot
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
                    Console.WriteLine("C'est la victoire ! Bravo au joueur qui devait deviner !");
                }
                else
                {
                    Console.WriteLine("C'est perdu ...");
                    Procedures.PartieAbandonnee(MotADeviner);
                }
            }
            return PartieFinie;

        }

        public static bool PropositionOrdi(string MotADeviner, char[] MotTrouve, int CmptTour, int Tentative)
        {
            /* Nom : Propositions
             * Objectif : Gère les propositions faites par l'ordinateur
             * Paramètre(s) d'entrée : string MotADeviner correspond au mot choisi par l'ordinateur 
             *                         char [] MotTrouve au mot avec les lettres trouvées et les _
             * Variable de retour : bool PartieFinie = signale si la partie se termine (prend la valeur true lorsque l'ordinateur propose un mot)
             * 
            */

            char Lettre;
            string MotPropose;
            int NbLettre;
            double RatioLettre;
            bool MotJuste;
            bool PartieFinie = false;

            Console.WriteLine("\ntentative Porposition Ordi avant ++ = " + Tentative);
            Tentative++;
            Console.WriteLine("\ntentative Porposition Ordi= " + Tentative);
            if (Tentative == 11)
            {
                Procedures.PartiePerdue(MotADeviner);
            }

            NbLettre = CompteLettreTrouvees(MotTrouve);
            RatioLettre = (100 * NbLettre) / MotTrouve.Length;      // On calcule le pourcentage de lettres trouvées

            if (RatioLettre < 50)       // Nombre de lettres devinées < 50%
            {
                // --------------- L'ordi proposer une lettre --------------- //
                Lettre = PropositionLettreOrdi(CmptTour);                     // L'ordi propose une lettre
                MotTrouve = VerifierLettre(Lettre, MotADeviner, MotTrouve, Tentative);     // On vérifie si la lettre est présente dans le mot
                Procedures.AfficherMotADeviner(MotTrouve);
            }

            else // Nombre de lettres devinées > 50%
            {
                // ----------------- L'ordi proposer un mot ----------------- //
                PartieFinie = true;         // Indique que la partie est terminée après la proposition du mot
                MotPropose = PropositionMotOrdi(MotTrouve);
                Console.WriteLine("\nL'ordinateur propose : {0}", MotPropose);
                MotJuste = VerifierMot(MotPropose, MotADeviner);

                if (MotJuste)
                {
                    Console.WriteLine("C'est la victoire ! Bravo à l'ordinateur !");

                }
                else
                {
                    Console.WriteLine("C'est perdu ...");
                    Procedures.PartieAbandonnee(MotADeviner);
                }
            }
            return PartieFinie;

        }

        // FONCTIONS POUR SOULAGER LE MAIN
        public static int ActionsTour()
        {
            /* Nom : ActionsTour
             * Objectif :  Permet de centraliser les actions de chaque tour
             * Paramètre(s) d'entrée : aucun
             * Variable de retour : int ChoixPartie = action selectionnée
            */

            int ChoixPartie;
            string stChoixPartie;
            bool IsOk;

            // Tant que l'utilisateur n'a pas rentré 0, 1 ou 2, on lui redemande ce qu'il veut faire
            do
            {
                Console.WriteLine("\n--------------------------------------------------------------------------------");
                Console.WriteLine("Tapez 0 pour abandonner !");
                Console.WriteLine("Tapez 1 pour afficher les règles !");
                Console.WriteLine("Tapez 2 pour continuer la partie !");

                // Permet de tester le type de la variable entrée, si ca n'est pas un int IsOk est false et la boucle recommence
                stChoixPartie = Console.ReadLine();
                IsOk = int.TryParse(stChoixPartie, out ChoixPartie);

            } while (!IsOk || ((ChoixPartie != 0) && (ChoixPartie != 1) && (ChoixPartie != 2)));

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
            string stChoixDebut;
            int Roles = -1;
            NbJoueursHumains = -1;
            bool IsOk;

            // Tant que l'utilisateur n'as pas rentré 1 ou 2, on réitère la question
            do
            {
                do
                {
                    Console.WriteLine("\n--------------------------------------------------------------------------------");
                    Console.WriteLine("Choississez une action : ");
                    Console.WriteLine("Tapez 1 pour afficher les règles !");
                    Console.WriteLine("Tapez 2 pour commencer la partie !");

                    // Permet de tester le type de la variable entrée, si ca n'est pas un int IsOk est false et la boucle recommence
                    stChoixDebut = Console.ReadLine();
                    IsOk = int.TryParse(stChoixDebut, out ChoixDebut);

                } while (!IsOk || ChoixDebut < 1 || ChoixDebut > 2);

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
                    else if (NbJoueursHumains == 0)     // Ordinateur contre ordinateur
                    {

                    }
                    else if (NbJoueursHumains == 2)     // Humain contre humain
                    {

                    }

                }
            } while (ChoixDebut != 2);

            return Roles;
        }


        // FONCTIONS ANNEXES
        public static int CompteLettreTrouvees(char[] MotTrouve)
        {
            /* Nom : CompteLettreTrouvees
             * Objectif : Permet de compter le nombre de lettre trouvées
             * Paramètre(s) d'entrée : char [] MotTrouve au mot avec les lettres trouvées et les _
             * Variable de retour : int NbLettre = le nombre de lettres déjà trouvées
            */

            int NbLettre = 0;

            for (int i = 0; i < MotTrouve.Length; i++)
            {
                if (MotTrouve[i] != '_')        // Si le caractère n'est pas un _, alors c'est une lettre 
                {
                    NbLettre++;         // on incrémente notre valeur de retour
                }
            }
            return NbLettre;
        }

        public static bool ModeOrdinateurOrdinateur(string MotADeviner, int CmptTour, bool MotDonné, char[] MotTrouve, bool PartieFinie, int ChoixPartie, int Tentative)
        {
            do
            {
                CmptTour++;
                // L'ordinateur1 choisi un mot
                if (MotDonné == false)      // Permet de choisir le mot de l'ordinateur une seule fois (et pas à chaque tour)
                {
                    //Permet de choisir le mot de l'ordinateur
                    MotADeviner = Fonctions.ChoixMotOrdi();
                    MotDonné = true;

                    // Initialise le MotTrouve avec des _
                    MotTrouve = new char[MotADeviner.Length];
                    for (int i = 0; i < MotADeviner.Length; i++)
                    {
                        MotTrouve[i] = '_';
                    }
                }

                // L'ordinateur2 fais une proposition
                Console.WriteLine("\ntentative Mode ordi ordi = " + Tentative);
                PartieFinie = Fonctions.PropositionOrdi(MotADeviner, MotTrouve, CmptTour, Tentative);    // L'ordinateur fait une proposition (lettre ou mot)
            } while ((ChoixPartie != 0) && (!PartieFinie));

            return PartieFinie;
        }

        public static bool ModeHumainOrdinateur(string MotADeviner, int CmptTour, bool MotDonné, char[] MotTrouve, bool PartieFinie, int ChoixPartie, int Roles, int Tentative)
        {
            do
            {
                CmptTour++;
                if (Roles == 1)     // L'ordinateur devine
                {
                    if (MotDonné == false)      // Permet à au joueur humain de choisir le mot à deviner (et ce une unique fois, pas à chaque tour)
                    {
                        MotADeviner = Fonctions.ChoixMotHumain();
                        MotDonné = true;

                        // MotTrouve correspond au mot qui evoluera avec les nouvelles lettres trouvées
                        MotTrouve = new char[MotADeviner.Length];       // MotTrouve est de la même longueur que le mot à deviner
                                                                        // On initialise le MotTrouve avec des _
                        for (int i = 0; i < MotADeviner.Length; i++)
                        {
                            MotTrouve[i] = '_';
                        }
                    }

                    PartieFinie = Fonctions.PropositionOrdi(MotADeviner, MotTrouve, CmptTour, Tentative);    // L'ordinateur fait une proposition (lettre ou mot)
                }
                else if (Roles == 0)    // Le joueur humain devine
                {
                    if (MotDonné == false)      // Permet de choisir le mot de l'ordinateur une seule fois (et pas à chaque tour)
                    {
                        //Permet de choisir le mot de l'ordinateur
                        MotADeviner = Fonctions.ChoixMotOrdi();
                        MotDonné = true;

                        // Initialise le MotTrouve avec des _
                        MotTrouve = new char[MotADeviner.Length];
                        for (int i = 0; i < MotADeviner.Length; i++)
                        {
                            MotTrouve[i] = '_';
                        }
                    }
                    PartieFinie = Fonctions.PropositionHumain(MotADeviner, MotTrouve, Tentative);
                }
                else
                {
                    Console.WriteLine("Erreur dans l'attributuion des rôles");
                    PartieFinie = true;
                }
            } while ((ChoixPartie != 0) && (!PartieFinie));

            return PartieFinie;
        }

        public static bool ModeHumainHumain(string MotADeviner, bool MotDonné, char[] MotTrouve, bool PartieFinie, int ChoixPartie, int Tentative)
        {
            do
            {
                //Un joueur choisi un mot
                if (MotDonné == false)      // Permet à au joueur humain de choisir le mot à deviner (et ce une unique fois, pas à chaque tour)
                {
                    MotADeviner = Fonctions.ChoixMotHumain();
                    MotDonné = true;

                    // MotTrouve correspond au mot qui evoluera avec les nouvelles lettres trouvées
                    MotTrouve = new char[MotADeviner.Length];       // MotTrouve est de la même longueur que le mot à deviner
                                                                    // On initialise le MotTrouve avec des _
                    for (int i = 0; i < MotADeviner.Length; i++)
                    {
                        MotTrouve[i] = '_';
                    }
                    Console.Clear();
                }

                // Un joueur propose des lettres ou un mot
                PartieFinie = Fonctions.PropositionHumain(MotADeviner, MotTrouve, Tentative);

            } while ((ChoixPartie != 0) && (!PartieFinie));
            return PartieFinie;
        }
    }
}
