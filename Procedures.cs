using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetPendu
{
    /* THIS CLASS CONTAINS ALL PROCEDURES */
    class Procedures
    {
        public static void AfficherRegles()
        {
            /* Nom : AfficherRegles
             * Objectif :  Permet d'afficher les règles en lisant un fichier txt
             * Paramètre(s) d'entrée : aucun
             * Variable de retour : void
            */

            string text = System.IO.File.ReadAllText(@"..\..\..\Tools\ReglesJeu.txt");

            try
            {
                // Affiche le contenu du fichier
                System.Console.WriteLine(text);
            }
            catch (Exception ex)
            {
                // Code exécuté en cas d'exception 
                Console.Write("Une erreur est survenue au cours de la lecture des règles");
            }
        }

        public static void AfficherMotADeviner(int EtatLettre, string MotChoisi, char Lettre)
        {
            /* Nom : AfficherMotADeviner
             * Objectif :  A chaque tour, affiche le mot à deviner avec la nouvelle lettre donnée par l'utilisateur (Lettre)
             * Paramètre(s) d'entrée : char Lettre correspond à la lettre proposée par le joueur (humain ou ordinateur),
             * string MotChoisi correspond au mot à deviner et EtatLettre correspond au statut de la lettre (juste, fausse, deja donnée)
             * Variable de retour : void
             * 
             * TODO :
             * Afficher toutes les mêmes du mot si elle est proposé et présente plusieurs fois dans le mot
             * Recuperer EtatLettre
            */

            if (EtatLettre==0)
            {
                for (int i = 0; i < MotChoisi.Length; i++)
                {
                    Console.Write("_ ");
                }
            }
            else if (EtatLettre==1)
            {
                
                for (int i = 0; i < MotChoisi.Length; i++)
                {

                    if (Lettre == MotChoisi[i])
                    {
                        Console.Write(Lettre);
                    }
                    else
                    {
                        Console.Write("_ ");
                    }
                }
            }
        }

        public static void PartieAbandonnee(string MotADeviner)
        {
            /* Nom : PartieAbandonnee
             * Objectif :  Affiche "Abandon partie !" + le mot à deviner + dessin du pendu
             * Paramètre(s) d'entrée : aucun
             * Variable de retour : void
            */

            Console.WriteLine("Vous avez décidé d'abandonner la partie !");
            Console.WriteLine("Le mot à deviner était {0}", MotADeviner);
            Console.WriteLine("Dommage !");
            string text = System.IO.File.ReadAllText(@"..\..\..\Tools\DessinPendu.txt");

            try
            {
                // Affiche le contenu du fichier
                System.Console.WriteLine(text);

            }
            catch (Exception ex)
            {
                // Code exécuté en cas d'exception 
                Console.Write("Une erreur est survenue au cours de l'affichage du pendu");
            }

        }

        public static void Propositions(string MotADeviner)
        {
            /* Nom : Propositions
             * Objectif : Demande à l'humain un mot ou une lettre et la/le verifie
             * Paramètre(s) d'entrée : string MotADeviner correspond au mot choisi par l'ordinateur
             * Variable de retour : void
            */

            char Lettre;
            int EtatLettre;
            string MotPropose;
            int PropositionHumain;

            do
            {
                Console.WriteLine("Si vous voulez proposer une lettre, tapez 1");
                Console.WriteLine("Si vous voulez proposer un mot, tapez 2");

                PropositionHumain = int.Parse(Console.ReadLine());

                // --------------- L'humain veut proposer une lettre --------------- //
                if (PropositionHumain == 1)
                {
                    Lettre = Fonctions.PropositionLettreHumain();                   // L'humain propose une lettre
                    EtatLettre = Fonctions.VerifierLettre(Lettre, MotADeviner);     // On vérifie si la lettre est présente dans le mot

                    // TODO : Affichermot
                    Console.WriteLine("Mot :");
                    Procedures.AfficherMotADeviner(EtatLettre, MotADeviner, Lettre);
                }

                // --------------- L'humain veut proposer un mot --------------- //
                else if (PropositionHumain == 2)
                {
                    MotPropose = Fonctions.PropositionMotHumain();
                }

            } while ((PropositionHumain != 1) && (PropositionHumain != 2));

        }
    }
}
