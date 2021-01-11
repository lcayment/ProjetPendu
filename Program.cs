using System;
using System.IO;

namespace ProjetPendu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("BIENVENUE SUR NOTRE JEU DU PENDU");
            /* VARIABLES */
            int Roles;
            int ChoixPartie;
            string MotADeviner = "null";
            bool MotDonné = false;
            char[] MotTrouve = new char[40];     // la taille est attribuée au hasard
            bool PartieFinie = false;           // variable indiquant la fin de la partie
            int CmptTour = 0;                   // compte le tour de jeu
            int Tentative = 0;                  // compte le nombre de tentatives restantes

            /* --------------- */

            /* DEBUT DE PARTIE */
            Roles = Fonctions.DebutPartie(out int NbJoueursHumains);

            /* LA PARTIE COMMENCE */
            do
            {
                ChoixPartie = Fonctions.ActionsTour();        // Présentation des actions possibles à chaque tour

                // --------------- Abandon de la partie --------------- //
                if (ChoixPartie == 0)
                {
                    Console.WriteLine("\nVous avez choisi d'abandonner !");
                    Procedures.PartieAbandonnee(MotADeviner);
                }

                // --------------- Affichage des règles --------------- //
                else if (ChoixPartie == 1)
                {
                    Procedures.AfficherRegles();
                }

                // ---------------  Suite de la partie --------------- // 
                else if (ChoixPartie == 2)
                {
                    if (NbJoueursHumains == 0)
                    {
                        Console.WriteLine("\ntentative main= " + Tentative);
                        PartieFinie = Fonctions.ModeOrdinateurOrdinateur(MotADeviner, CmptTour, MotDonné, MotTrouve, PartieFinie, ChoixPartie, Tentative);
                    }
                    else if (NbJoueursHumains == 1)
                    {
                        PartieFinie = Fonctions.ModeHumainOrdinateur(MotADeviner, CmptTour, MotDonné, MotTrouve, PartieFinie, ChoixPartie, Roles, Tentative);
                    }
                    else if (NbJoueursHumains == 2)
                    {
                        PartieFinie = Fonctions.ModeHumainHumain(MotADeviner, MotDonné, MotTrouve, PartieFinie, ChoixPartie, Tentative);
                    }
                }

                else
                {
                    Console.WriteLine("Erreur sur l'action choisie");
                }

            } while ((ChoixPartie != 0) && (!PartieFinie));

        }
    }
}
