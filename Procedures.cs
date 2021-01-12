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

            //Récupere le fichier texte écrit au préalable 
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

            //Récupere le fichier texte écrit au préalable
            string text = System.IO.File.ReadAllText(@"..\..\..\Tools\DessinPendu.txt");
            Console.WriteLine("--------------------------------------------------------------------------------");

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

        public static void PartiePerdue(string MotADeviner)
        {
            /* Nom : PartiePerdue
             * Objectif :  Affiche message partie finie quand le joueur a utilisée toutes ses tentatives
             * Paramètre(s) d'entrée : string MotADeviner = mot qui était à deviner
             * Variable de retour : void
            */

            Console.WriteLine("\nPerduuuuuuuuu ! BOUUUUUUUH LE/LA NUL.LE");
            Console.WriteLine("Tu as utilisé toutes les tentatives !");
            Console.WriteLine("Le mot à deviner était {0}", MotADeviner);
            Console.WriteLine("Dommage !");
            //Récupere le fichier texte écrit au préalable
            string text = System.IO.File.ReadAllText(@"..\..\..\Tools\DessinPendu.txt");
            Console.WriteLine("--------------------------------------------------------------------------------");

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

        public static void AfficherPendu (ref int Pendu)
        {
            /* Nom : AfficherPendu
             * Objectif :  Affiche le pendu en fonction du nombre de tentatives restantes
             * Paramètre(s) d'entrée : ref int Pendu = nombre de tentatives restantes
             * Variable de retour : void
            */

            if (Pendu == 10)
            {
                //Récupere le fichier texte écrit au préalable
                string text = System.IO.File.ReadAllText(@"..\..\..\Tools\DessinPendu10.txt");
                // Affiche le contenu du fichier
                System.Console.WriteLine(text);

            }
            else if (Pendu == 9)
            {
                //Récupere le fichier texte écrit au préalable
                string text = System.IO.File.ReadAllText(@"..\..\..\Tools\DessinPendu9.txt");
                // Affiche le contenu du fichier
                System.Console.WriteLine(text);

            }
            else if (Pendu == 8)
            {
                //Récupere le fichier texte écrit au préalable
                string text = System.IO.File.ReadAllText(@"..\..\..\Tools\DessinPendu8.txt");
                // Affiche le contenu du fichier
                System.Console.WriteLine(text);

            }
            else if (Pendu == 7)
            {
                //Récupere le fichier texte écrit au préalable
                string text = System.IO.File.ReadAllText(@"..\..\..\Tools\DessinPendu7.txt");
                // Affiche le contenu du fichier
                System.Console.WriteLine(text);
            }
            else if (Pendu == 6)
            {
                //Récupere le fichier texte écrit au préalable
                string text = System.IO.File.ReadAllText(@"..\..\..\Tools\DessinPendu6.txt");
                // Affiche le contenu du fichier
                System.Console.WriteLine(text);

            }
            else if (Pendu == 5)
            {
                //Récupere le fichier texte écrit au préalable
                string text = System.IO.File.ReadAllText(@"..\..\..\Tools\DessinPendu5.txt");
                // Affiche le contenu du fichier
                System.Console.WriteLine(text);

            }
            else if (Pendu == 4)
            {
                //Récupere le fichier texte écrit au préalable
                string text = System.IO.File.ReadAllText(@"..\..\..\Tools\DessinPendu4.txt"); 
                // Affiche le contenu du fichier
                System.Console.WriteLine(text);

            }
            else if (Pendu == 3)
            {
                //Récupere le fichier texte écrit au préalable
                string text = System.IO.File.ReadAllText(@"..\..\..\Tools\DessinPendu3.txt");
                // Affiche le contenu du fichier
                System.Console.WriteLine(text);

            }
            else if (Pendu == 2)
            {
                //Récupere le fichier texte écrit au préalable
                string text = System.IO.File.ReadAllText(@"..\..\..\Tools\DessinPendu2.txt");
                // Affiche le contenu du fichier
                System.Console.WriteLine(text);
            }
            else if (Pendu == 1)
            {
                //Récupere le fichier texte écrit au préalable
                string text = System.IO.File.ReadAllText(@"..\..\..\Tools\DessinPendu1.txt");
                // Affiche le contenu du fichier
                System.Console.WriteLine(text);
            }
        }

    }
}
