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

            Console.WriteLine("Choississez une action : ");
            Console.WriteLine("Tapez 1 pour afficher les règles !");
            Console.WriteLine("Tapez 2 pour commencer la partie !");
            int ChoixDebut = int.Parse(Console.ReadLine());

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
                    Fonctions.ChoixRoles();
                }
            }
            

            




        }
    }
}
