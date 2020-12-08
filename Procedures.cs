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

        public static void AfficherMotADeviner(char[] MotTrouve)
        {
            /* Nom : AfficherMotADeviner
             * Objectif :  A chaque tour, affiche le mot à deviner avec la nouvelle lettre donnée par l'utilisateur (Lettre)
             * Paramètre(s) d'entrée : char [] MotTrouve correspond au mot en l'état actuelle (avec les lettres devinées et les underscore)
             * Variable de retour : void
            */

            for (int i = 0; i < MotTrouve.Length; i++)
            {
                Console.Write(MotTrouve[i]);
            }
           
        }
        public static void PartieAbandonnee(string MotADeviner)
        {
            /* Nom : PartieAbandonnee
             * Objectif :  Affiche "Abandon partie !" + le mot à deviner + dessin du pendu
             * Paramètre(s) d'entrée : string MotADeviner = mot qui était à deviner
             * Variable de retour : void
            */

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

       

        public static void PropositionOrdi(string MotADeviner, char [] MotTrouve)
        {
            /* Nom : Propositions
             * Objectif : Gère les propositions faites par l'ordinateur
             * Paramètre(s) d'entrée : string MotADeviner correspond au mot choisi par l'ordinateur 
             *                         char [] MotTrouve au mot avec les lettres trouvées et les _
             * Variable de retour : void
             * 
             * TODO
            */

            char Lettre;
            string MotPropose;

            if (true)       // Nombre de lettres devinées < 75%
            {
                // --------------- L'ordi proposer une lettre --------------- //
                Lettre = Fonctions.PropositionLettreOrdi();                     // L'ordi propose une lettre
                MotTrouve = Fonctions.VerifierLettre(Lettre, MotADeviner, MotTrouve);     // On vérifie si la lettre est présente dans le mot
                AfficherMotADeviner( MotTrouve);
            }
            

            else // Nombre de lettres devinées < 75%
            {
                // ----------------- L'ordi proposer un mot ----------------- //
                /* Si il y a 75% du mot */
                MotPropose = Fonctions.PropositionMotOrdi();
            }
                 
            
        }
    }
}
