using System;

namespace tic_tac_toe
{
    class Program
    {
        static void Main(string[] args)
        {
            Connect4 newConnect4Game = new Connect4();
            Tic_Tac_Toe newTicTacToeGame = new Tic_Tac_Toe();

            Console.WriteLine("Would you like to play (C)onnect4 or (T)icTacToe? ");
            string userChoice = Console.ReadLine();

            if(userChoice.ToLower() == "c")
            {
                newConnect4Game.Initialize();
            }
            else if(userChoice.ToLower() == "t")
            {
                newTicTacToeGame.Initialize();
            }
        }
    }
}
