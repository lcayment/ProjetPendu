﻿using System;
using System.IO;

namespace ProjetPendu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenue sur notre jeu de pendu");
            /* VARIABLES - A modifier pour rendre plus propre*/
            int Roles;
            int ChoixPartie;
            string MotADeviner = "null";
            bool MotDonné = false;
            char[] MotTrouve = new char[2];     // la taille est random
            bool PartieFinie = false;

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
                    Console.WriteLine("Vous avez choisi d'abandonner !");
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
                    if (Roles == 1)     // l'ordinateur devine
                    {
                        Fonctions.PropositionLettreOrdi();
                        MotADeviner = Fonctions.ChoixMotHumain();
                        MotTrouve = new char[MotADeviner.Length];
                    }
                    else if (Roles == 0)    // le joueur devine
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
                        PartieFinie = Procedures.PropositionHumain(MotADeviner, MotTrouve);
                    }
                    else
                    {
                        Console.WriteLine("Erreur dans l'attributuion des rôles");
                    }
                }

                else
                {
                    Console.WriteLine("Erreur sur l'action choisie");
                }

            } while ((ChoixPartie != 0) && (!PartieFinie));

            //NOMBRE TENTATIVES RESTANTES

        }
    }
}
