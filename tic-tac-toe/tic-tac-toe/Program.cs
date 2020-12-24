
using System;
using System.Data;

namespace tic_tac_toe
{
    class Program
    {
        //current issues: 
        //Player can chooses O, but game starts player with X'
        //If player selects a option thats already filled, it'll skip a turn from X to O
        
        public BoardGames CurrentGame { get; set; }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.SelectGame();
        }

        public void SelectGame()
        {
            string userChoice = null;
            while (userChoice == null)
            {
                Console.WriteLine("Would you like to play (C)onnect4, (T)icTacToe, or (E)xit? ");
                userChoice = Console.ReadLine();

                if (userChoice.ToLower() == "c")
                {
                    CurrentGame = new Connect4();
                    GetUserInputPerGame();
                    GameCycle();
                }
                else if (userChoice.ToLower() == "t")
                {
                    CurrentGame = new Tic_Tac_Toe();
                    GetUserInputPerGame();
                    GameCycle();
                }
                else if (userChoice.ToLower() == "e")
                {
                    Console.WriteLine("Thanks for playing my game :)");
                    break;
                }
                else
                {
                    userChoice = null;
                }
            }
        }


        public void GameCycle()
        {
            while (!CurrentGame.GameOver(CurrentGame.GameBoard, CurrentGame.Player.CurrPlayer))
            {
                CurrentGame.Update();
                CurrentGame.Move(CurrentGame.Player.Move());
            }

            if(CurrentGame.EndOfGame())
            {
                SelectGame();
            }
            else
            {
                Console.WriteLine("Thanks for playing!!");
                Environment.Exit(0);
            }
        }

        public void GetUserInputPerGame()
        {

            Console.WriteLine($"Welcome to {CurrentGame.Title}!");

            string userChoice = null;
            while (userChoice == null)
            {
                Console.WriteLine("Would you like to play as (X) or (O)?");
                userChoice = Console.ReadLine();
                if (userChoice.ToLower() == "x" || userChoice.ToLower() == "o")
                {
                    break;
                }
                else
                {
                    userChoice = null;
                }
            }


            CurrentGame.SetPlayerPiece(userChoice);


            Console.WriteLine("Game Board Initialized");

        }
    }
}
