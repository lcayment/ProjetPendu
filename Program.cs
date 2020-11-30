using System;
using System.IO;

namespace ProjetPendu
{
    class Program
    {  

        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenue sur notre jeu de pendu");
            int NbJoueursHumains;
            int Roles = -1;
            int ChoixDebut, ChoixPartie;
            string MotADeviner = "null";

            // DEBUT DE PARTIE
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

            // LA PARTIE COMMENCE
            do
            {
                Console.WriteLine("Choississez une action : ");
                Console.WriteLine("Tapez 0 pour abandonner !");
                Console.WriteLine("Tapez 1 pour continuer la partie !");
                ChoixPartie = int.Parse(Console.ReadLine());
                MotADeviner = Fonctions.ChoixMotOrdi();
                Console.WriteLine(MotADeviner);

                /*if (ChoixPartie == 0)           // La partie est abandonnée
                {
                    Procedures.PartieAbandonnee(MotADeviner);
                }
                else
                {
                    if (Roles == 1) // L'ORDINATEUR DEVINE
                    {
                        Console.WriteLine("Veuillez rentrer un mot que l'ordinateur doit deviner :");
                        MotADeviner = Console.ReadLine();
                    }
                    else if (Roles == 0)    //LE JOUEUR HUMAIN DEVINE
                    {
                        MotADeviner = Fonctions.ChoixMotOrdi();
                        Console.WriteLine("Proposez une lettre ou un mot :");
                        // TODO
                    }
                    else
                    {
                        Console.WriteLine("Erreur dans l'attributuion des rôles");
                    }
                }*/

            } while (ChoixPartie != 0);



            //NOMBRE TENTATIVES RESTANTES



        }
    }
}
