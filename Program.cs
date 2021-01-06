﻿using System;
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

                        PartieFinie = Fonctions.PropositionOrdi(MotADeviner, MotTrouve);    // L'ordinateur fait une proposition (lettre ou mot)
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
                        PartieFinie = Fonctions.PropositionHumain(MotADeviner, MotTrouve);
                    }
                    else
                    {
                        Console.WriteLine("Erreur dans l'attributuion des rôles");
                        PartieFinie = true;
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
