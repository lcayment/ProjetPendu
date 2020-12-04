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
            bool MotDansDictionnaire = false;
            bool MotDonné = false;
            char Lettre;
            int EtatLettre;

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

                if (MotDonné == false)      // Permet de choisir le mot de l'ordinateur une seule fois (et pas à chaque tour)
                {
                    MotADeviner = Fonctions.ChoixMotOrdi();
                    MotDonné = true;
                }

                // LA PARTIE CONTINUE 
                if (ChoixPartie == 1)          
                {
                    if (Roles == 1)     // L'ORDINATEUR DEVINE
                    {
                        MotADeviner = Fonctions.ChoixMotHumain();
                    }
                    else if (Roles == 0)    // LE JOUEUR HUMAIN DEVINE
                    {
                        Console.WriteLine("Proposez une lettre ou un mot en majuscules et sans accent :");
                        Lettre = char.Parse(Console.ReadLine());                        // L'utilisateur propose une lettre
                        EtatLettre = Fonctions.VerifierLettre(Lettre, MotADeviner);     // On vérifie si la lettre est présente dans le mot
                        // TODO : Affichermot
                    }
                    else
                    {
                        Console.WriteLine("Erreur dans l'attributuion des rôles");
                    }
                }

                // LA PARTIE EST ABANDONNEE
                else
                {
                    Procedures.PartieAbandonnee(MotADeviner);
                }

            } while (ChoixPartie != 0);



            //NOMBRE TENTATIVES RESTANTES



        }
    }
}
