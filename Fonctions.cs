using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ProjetPendu
{
    /* ======================================THIS CLASS CONTAINS ALL FONCTIONS======================================================================================
     *      1. FONCTIONS POUR SOULAGER LE MAIN (Lig. 17)
     *          - DebutPartie
     *          - ActionsTour          
     *          
     *      2. FONCTIONS DE CHOIX (Lig. 107)
     *          - ChoixNbJoueurs
     *          - ChoixRoles
     *          - ChoixMotOrdi
     *          - ChoixMotHumain            
     *          
     *      3. FONCTIONS PROPOSITIONS (Lig. 252)
     *          - PropositionHumain
     *          - PropositionOrdi
     *          - PropositionLettreHumain
     *          - PropositionMotHumain
     *          - PropositionLettreOrdi
     *          - PropositionMotOrdi          
     *      
     *      4. FONCTIONS VERIFICATION (Lig. 474)
     *          - MotHumainDictionnaire
     *          - VerifierLettre
     *          - VerifierMot
     *          
     *      5. FONCTIONS ANNEXES (Lig. 595)
     *          - CompteLettreTrouvees
     *          - ModeOrdinateurOrdinateur
     *          - ModeHumainOrdinateur
     *          - ModeHumainHumain
    */


    class Fonctions
    {
        //=========================================================FONCTIONS POUR SOULAGER LE MAIN==========================================================================
       

        public static int DebutPartie(out int NbJoueursHumains)
        {
            /* Nom : DebutPartie
             * Objectif :  Permet de centraliser les actions de début de partie, à savoir l'affichage des règles et le nombre de joueurs
             * Paramètre(s) d'entrée : out int NbJoueursHumains = sera récupéré et qui correspond au nombre de joueurs humains
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

        public static int ActionsTour()
        {
            /* Nom : ActionsTour
             * Objectif :  Permet de centraliser les actions de CHAQUE tour
             * Paramètre(s) d'entrée : aucun
             * Variable de retour : int ChoixPartie = action selectionnée par le joueur 
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

        //===============================================================FONCTIONS DE CHOIX=================================================================================
        

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
            else if (NbJoueurHumain == 1)   // un joueur humain contre ordinateur ==> choisi son role dans ChoixRoles()
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


            if (ModeJeu == 0)// Humain devine mot de l'ordinateur
            {
                Console.WriteLine("Tu as choisi de deviner le mot que l'ordinateur a choisi");
                return ModeJeu;
            }
            else //Ordinateur devine le mot de l'humain
            {
                Console.WriteLine("Tu as choisi de faire deviner un mot à l'ordinateur");
                return ModeJeu;
            }

        }

        public static string ChoixMotOrdi()
        {
            /* Nom : ChoixMotOrdi
            * Objectif : Retourne un mot random selectionné par l'ordinateur (MotChoisi) dans le fichier DICOfr.txt
            * Paramètre(s) d'entrée : aucun
            * Variable de retour : string MotChoisi = mot selectionné par l'ordinateur
            */

            var lines = File.ReadAllLines(@"..\..\..\Tools\dicoFR.txt");        // On recupere le nombre de lines dans le dictionnaire
            var r = new Random();                                               // On crée un objet random
            var randomLineNumber = r.Next(0, lines.Length - 1);                 // On sélectionne une ligne random
            var MotChoisi = lines[randomLineNumber];                            // On met le mot random dans la var MotChoisi

            Console.WriteLine("\nL'ordinateur a choisi un mot, c'est parti !");
            return MotChoisi;
        }

        public static string ChoixMotHumain()
        {
            /* Nom : ChoixMotHumain
            * Objectif : Retourne un mot selectionné par le joueur humain (MotChoisi) dans le fichier DICOfr.txt qui va être vérifier
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
                MotDansDictionnaire = MotHumainDictionnaire(MotChoisi); // permet ensuite de vérifier si le mot choisi est bien dans le dictionnaire avec 
                                                                        //MotHUmainDictionnaire()
            } while (!MotDansDictionnaire);

            return MotChoisi;
        }




        //=========================================================FONCTIONS DE PROPOSITIONS===============================================================================
        public static bool PropositionHumain(string MotADeviner, char[] MotTrouve, ref int Tentative, ref int Pendu)
        {
            /* Nom : PropositionHumain
             * Objectif : Demande à l'humain un mot ou une lettre qui sera vérifié par VerifierLettre ou VerifierMot selon le choix de l'humain
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

            if (Tentative == 0) //Permet de vérifier si les tentatives ne sont pas épuisées sinon = PartiePerdue()
            {
                Procedures.PartiePerdue(MotADeviner);
                PartieFinie = true;
            }
            else
            {
                // Tant que l'humain ne propose pas 1 ou 2, on lui redemande
                do
                {
                    Console.WriteLine("\n\nSi vous voulez proposer une lettre, tapez 1");
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
                    MotTrouve = Fonctions.VerifierLettre(Lettre, MotADeviner, MotTrouve, ref Tentative, ref Pendu);  // On vérifie si la lettre est présente dans le mot
                    Procedures.AfficherMotADeviner(MotTrouve);
                }
                // --------------- L'humain veut proposer un mot --------------- //    
                else if (PropositionHumain == 2)
                {
                    PartieFinie = true;         // Indique que la partie est terminée après la proposition du mot
                    MotPropose = Fonctions.PropositionMotHumain(); // On renvoie l'humain dans PropositionMotHumain qui renvoie MotJuste
                    MotJuste = Fonctions.VerifierMot(MotPropose, MotADeviner);//Mot Juste est vérifié dans VerifierMot
                    if (MotJuste)//Test MotJuste pour afficher si victoire ou défaite puisque la partie est finie dès qu'il y a porposition de mot
                    {
                        Console.WriteLine("C'est la victoire ! Bravo au joueur qui devait deviner !");
                    }
                    else
                    {
                        Console.WriteLine("C'est perdu ...");
                        Procedures.PartieAbandonnee(MotADeviner);
                    }
                }
            }
            return PartieFinie;

        }

        public static bool PropositionOrdi(string MotADeviner, char[] MotTrouve, int CmptTour, ref int Tentative, ref int Pendu)
        {
            /* Nom : Propositions
             * Objectif : Gère les propositions faites par l'ordinateur ensuite vérifiées par VerifierLettre ou VerifierMot
             * Paramètre(s) d'entrée : string MotADeviner correspond au mot choisi par l'ordinateur 
             *                         char [] MotTrouve au mot avec les lettres trouvées et les _
             *                         int CmptTour compteur des tours, utilisé dans PropositionLettreOrdi
             *                         ref int Tentative compte les tentatives 
             *                         ref int Pendu prend la valeur de Tentative pourafficher le pendu 
             * Variable de retour : bool PartieFinie = signale si la partie se termine (prend la valeur true lorsque l'ordinateur propose un mot)
             *                      ref int Tentative = passerelle avec VerifierLettre 
             *                      ref int Pendu = passerelle comme Tentative  
            */

            char Lettre;
            string MotPropose;
            int NbLettre;
            double RatioLettre;
            bool MotJuste;
            bool PartieFinie = false;

            NbLettre = CompteLettreTrouvees(MotTrouve);
            RatioLettre = (100 * NbLettre) / MotTrouve.Length;      // On calcule le pourcentage de lettres trouvées

            if (RatioLettre < 50)       // Nombre de lettres devinées < 50%
            {
                // --------------- L'ordi proposer une lettre --------------- //
                Lettre = PropositionLettreOrdi(CmptTour);                     // L'ordi propose une lettre
                MotTrouve = VerifierLettre(Lettre, MotADeviner, MotTrouve, ref Tentative, ref Pendu);     // On vérifie si la lettre est présente dans le mot
                Procedures.AfficherMotADeviner(MotTrouve);
            }

            else // Nombre de lettres devinées > 50%
            {
                // ----------------- L'ordi proposer un mot ----------------- //
                PartieFinie = true;         // Indique que la partie est terminée après la proposition du mot
                MotPropose = PropositionMotOrdi(MotTrouve); //Fait appel à la fonction pour proposer un mot
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

        public static char PropositionLettreHumain()
        {
            /* Nom : PropositionLettreHumain
            * Objectif : Cette fonction n'est exécutée que lorsqu'il n'y a qu'1 joueur humain et elle permet à l'humain de proposer une lettre qui sera ensuite vérifier
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
            * Objectif : Cette fonction n'est exécutée que lorsqu'il n'y a qu'1 joueur humain et elle permet à l'humain de proposer un mot qui sera ensuite vérifié
            * dans MotHumainDictionnaire()
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
            * Objectif : Cette fonction n'est exécutée que lorsqu'il n'y a qu'1 joueur humain et elle permet à l'ordinateur de proposer une lettre qui sera ensuite vérifiée
            * dans VerifierLettre()
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
            * Objectif : Cette fonction n'est exécutée que lorsqu'il n'y a qu'1 joueur humain et elle permet à l'ordinateur de proposer un mot qui sera ensuite vérifié
            * dans cette fonction
            * Paramètre(s) d'entrée : char [] MotTrouve : mot avec les lettres trouvées et les _
            * Variable de retour : string Mot correspond au mot de retour venant de l'ordi
            * 
            */

            string MotPropose = "null";     // On initialise le MotPropose
            int CmptLettreOK = 0;   // compte le nombre de lettres correctes dans le mot en cours
            int CmptLettreMax = 0; // sauvegarde le nombre de lettre correctes maximum

            // L'ordinateur compare chaque mot du dicofr.txt au mot trouve. Le premier mot correspondant est retourné.

            string textFile = @"..\..\..\Tools\dicoFR.txt";     // correspond au chemin relatif du dictionnaire

            // Chaque ligne du fichier va être lue et être comparée au mot donné en paramètre pour le vérifier
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

 

        //===========================================================FONCTIONS DE VERIFICATION==============================================================================
        public static bool MotHumainDictionnaire(string MotADeviner)
        {
            /* Nom : MotHumainDictionnaire
             * Objectif : Cette fonction permet de vérifier si le mot choisi par le joueur humain est présent dans le dictionnaire ou non
             * Paramètre(s) d'entrée : string MotADeviner correspond au mot choisi par le joueur humain
             * Variable de retour : bool MotDansDictionnaire prend la valeur true quand le mot est dans le dictionnaire et false quand le mot est absent du dictionnaire
            */

            bool MotDansDictionnaire = false;
            string textFile = @"..\..\..\Tools\dicoFR.txt";     // On récupère le dico par le chemin relatif dans tools

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
                        MotDansDictionnaire = false; //Si le mot n'est pas dans le dictionnaire, on recommence cette fonction en passant par 
                                                     //la fonction PropositionMotHumain
                    }
                }
            }

            return MotDansDictionnaire;
        }

        public static char[] VerifierLettre(char Lettre, string MotChoisi, char[] MotTrouve, ref int Tentative, ref int Pendu)
        {
            /* Nom : VerifierLettre
             * Objectif : Verifie si la lettre donnée est juste ou fausse, et compte le nombre de tentative restante en fonction de si la proposition de lettre
             * est juste, fausse, ou déjà donné.
             * Paramètre(s) d'entrée :  char Lettre = lettre proposée par le joueur (humain ou ordinateur)
             *                          string MotChoisi = mot à deviner
             *                          char [] MotTrouve = mot dans l'état actuel (avec les lettres devinées et les _)
             *                          ref int Tentative = décrémente pour ensuite indiquer nbr tentatives restantes
             *                          ref int Pendu = associé à Tentative pour afficher dessin pendu en fonction des erreurs ou non
             *                          
             * Variable de retour : char [] MotTrouve est le mot dans l'état actuel (avec les lettres devinées et les _)
             *                      ref int Tentative = utilisé dans PropostitionHumain 
             *                      ref int Pendu
            */

            bool LettreJuste = false;
            bool LettreDejaDonnee = false;

            // On parcourt le mot choisi (qui est un tableau de char) pour comparer chaque lettre du mot avec la lettre donnée
            for (int i = 0; i < MotChoisi.Length; i++)
            {
                if (MotTrouve[i] == Lettre)//La lettre est déja trouvé dans MotTrouve
                {
                    LettreDejaDonnee = true;
                }
                else //La lettre n'a pas été déjà donné ET correspond à une lettre du mot à deviné (ici MotChoisi qui est un intermédiaire entre MotADeviner et MotTrouve)
                {
                    if (MotChoisi[i] == Lettre)
                    {
                        MotTrouve[i] = Lettre;
                        LettreJuste = true;
                    }
                }
            }

            if (LettreDejaDonnee)//Conséquences : si lettre déjà trouvé  
            {
                Console.WriteLine("La lettre a deja été donnée");
                Tentative--;                                        //= une tentative en moins
                Pendu = Tentative;                                  // = Le pendu prend un baton
                Procedures.AfficherPendu(ref Pendu);                //Affiche le pendu 
            }
            else
            {
                if (LettreJuste) //Affiche que la lettre est bien juste sinon
                {
                    Console.WriteLine("La lettre est juste !");
                }
                else //sinon affiche lettre fause + conséquences
                {
                    Console.WriteLine("La lettre est fausse ...");
                    Tentative--;                                    //= une tentative en moins
                    Pendu = Tentative;                              // = Le pendu prend un baton
                    Procedures.AfficherPendu(ref Pendu);            //Affiche le pendu 

                }
            }
            Console.WriteLine("Il vous reste {0} tentatives", Tentative);   //Affiche tentative restante

            return MotTrouve;

        }

        public static bool VerifierMot(string MotDonne, string MotADeviner)
        {
            /* Nom : VerifierMot
            * Objectif : Verifie si la mot (MotDonne) est équivalent au mot à deviner (MotADeviner)
            * Paramètre(s) d'entrée : string MotDonne = mot proposé par le joueur (humain ou ordinateur)
                                      string MotADeviner = mot choisi par l'ordinateur ou le joueur humain comme mot à deviner
            * Variable de retour : bool MotJuste prend la valeur true si le mot est juste (victoire) ou la valeur false si le mot est faux 
            * (défaite : affichage pendu + mot à deviner)
            */

            bool MotJuste;
            if (MotDonne == MotADeviner) //Proposition est juste
            {
                MotJuste = true;
            }
            else                        //Propostition erronée
            {
                MotJuste = false;
            }

            return MotJuste;
        }

        


        //===============================================================FONCTIONS ANNEXES==================================================================================
        public static int CompteLettreTrouvees(char[] MotTrouve)
        {
            /* Nom : CompteLettreTrouvees
             * Objectif : Permet de compter le nombre de lettre trouvées pour s'en servir dans PropositionOrdi = calculer pourcentage et 
             * faire en sorte que l'ordinateur s'adapte au jeu
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

        public static bool ModeOrdinateurOrdinateur(string MotADeviner, int CmptTour, bool MotDonné, char[] MotTrouve, bool PartieFinie, int ChoixPartie, ref int Tentative, ref int Pendu)
        {

            /*
             * Nom : ModeOrdinateurOrdinateur
             * Objectif : Correspond aux actions menées lorsque le mode choisi est le mode 1
             * Paramètre(s) d'entrée : string MotADeviner : correspon au mot à deviner
             *                         int CmptTour : compteur des tours, utilisé dans PropositionLettreOrdi
             *                         bool MotDonné : est true lorsque le mot à deviner a été donné, false quand ca n'est pas le cas
             *                         char[] MotTrouve : correspond à l'état actuel du mot à deviner (avec des lettres et des _)
             *                         bool PartieFinie : indique que la partie est finie
             *                         int ChoixPartie : entier qui correspond au choix de la partie(abandon, afficher règles ou continuer la partie)
             *                         ref int Tentative : correspond au nombre de tentatives restantes pour découvrire le mot
             *                         ref int Pendu : associé à Tentative pour afficher dessin pendu en fonction des erreurs ou non
             * Variables de retour : bool Partie Finie
             *                       ref int Tentative : correspond au nombre de tentatives restantes pour découvrire le mot
             *                       ref int Pendu : associé à Tentative pour afficher dessin pendu en fonction des erreurs ou non
            */


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
                PartieFinie = Fonctions.PropositionOrdi(MotADeviner, MotTrouve, CmptTour, ref Tentative, ref Pendu);    // L'ordinateur fait une proposition (lettre ou mot)
            } while ((ChoixPartie != 0) && (!PartieFinie));

            return PartieFinie;
        }

        public static bool ModeHumainOrdinateur(string MotADeviner, int CmptTour, bool MotDonné, char[] MotTrouve, bool PartieFinie, int ChoixPartie, int Roles, ref int Tentative, ref int Pendu)
        {

            /* Nom : ModeHumainOrdinateur
             * Objectifs : Correspond aux actions menées lorsque le mode choisi est le mode 2
             * Paramètre(s) d'entrée : string MotADeviner : correspon au mot à deviner
             *                          int CmptTour : compteur des tours, utilisé dans PropositionLettreOrdi
             *                          bool MotDonné : est true lorsque le mot à deviner a été donné, false quand ca n'est pas le cas
             *                          char[] MotTrouve : correspond à l'état actuel du mot à deviner (avec des lettres et des _)
             *                          bool PartieFinie : indique que la partie est finie
             *                          int ChoixPartie : entier qui correspond au choix de la partie (abandon, afficher règles ou continuer la partie)
             *                          int Roles : correspond au rôle (je devine ou je fais deviner)
             *                          ref int Tentative : correspond au nombre de tentatives restantes pour découvrire le mot
             *                          ref int Pendu : associé à Tentative pour afficher dessin pendu en fonction des erreurs ou non
             * Variable de sortie : bool PartieFinie : indique que la partie est finie
             *                      ref int Tentative : correspond au nombre de tentatives restantes pour découvrire le mot 
             *                      ref int Pendu : associé à Tentative pour afficher dessin pendu en fonction des erreurs ou non
             */


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

                    PartieFinie = Fonctions.PropositionOrdi(MotADeviner, MotTrouve, CmptTour, ref Tentative, ref Pendu);    // L'ordinateur fait une proposition (lettre ou mot)
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
                    PartieFinie = Fonctions.PropositionHumain(MotADeviner, MotTrouve, ref Tentative, ref Pendu);
                }
                else
                {
                    Console.WriteLine("Erreur dans l'attributuion des rôles");
                    PartieFinie = true;
                }
            } while ((ChoixPartie != 0) && (!PartieFinie));

            return PartieFinie;
        }

        public static bool ModeHumainHumain(string MotADeviner, bool MotDonné, char[] MotTrouve, bool PartieFinie, int ChoixPartie, ref int Tentative, ref int Pendu )
        {
            /* Nom : ModeHumainHumain
             * Objectifs : Correspond aux actions menées lorsque le mode choisi est le mode 3
             * Paramètre(s) d'entrée :  string MotADeviner : correspond au mot à deviner
             *                          bool MotDonné : est true lorsque le mot à deviner a été donné, false quand ca n'est pas le cas
             *                          char[] MotTrouve : correspond à l'état actuel du mot à deviner (avec des lettres et des _)
             *                          bool PartieFinie : indique que la partie est finie
             *                          int ChoixPartie : entier qui correspond au choix de la partie (abandon, afficher règles ou continuer la partie)
             *                          ref int Tentative : correspond au nombre de tentatives restantes pour découvrire le mot
             *                          ref int Pendu : associé à Tentative pour afficher dessin pendu en fonction des erreurs ou non
             * Variable de sortie :  ref int Tentative : correspond au nombre de tentatives restantes pour découvrire le mot
             *                       ref int Pendu : associé à Tentative pour afficher dessin pendu en fonction des erreurs ou non
             * 
             */

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
                PartieFinie = Fonctions.PropositionHumain(MotADeviner, MotTrouve, ref Tentative, ref Pendu);

            } while ((ChoixPartie != 0) && (!PartieFinie));
            return PartieFinie;
        }
    }
}
