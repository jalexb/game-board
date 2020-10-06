using BoredGames;
using System;
using System.Collections.Generic;
using System.Text;

namespace tic_tac_toe
{
    class Tic_Tac_Toe : BoardGames
    {
        public override void Move()
        {
            int move = -1;
            while (move < 0 || move > 8 )
            {
                Console.WriteLine("Make your move. (0-8)");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int result))
                {
                    move = result;
                }
            }

            if (gameBoard[move] != "X" && gameBoard[move] != "O")
            {
                movesMade++;
                gameBoard[move] = PlayerIsX ? "X" : "O";
                currPlayer = PlayerIsX ? "X" : "O";
                GameCycle("moved");
            }
            else
            {
                Console.WriteLine("Please make a valid choice.");
                Move();
            }
        }
        public override void PrintBoard()
        {
            Console.WriteLine(" {0} | {1} | {2} ", gameBoard[0], gameBoard[1], gameBoard[2]);
            Console.WriteLine("___|___|___ ");
            Console.WriteLine(" {0} | {1} | {2} ", gameBoard[3], gameBoard[4], gameBoard[5]);
            Console.WriteLine("___|___|___ ");
            Console.WriteLine(" {0} | {1} | {2} ", gameBoard[6], gameBoard[7], gameBoard[8]);
            Console.WriteLine("   |   |     ");
        }

        public override void Initialize()
        {
            movesMade = 0;
            Console.WriteLine("Would you like to play as (X) or (O)?");
            string playerChoice = Console.ReadLine();
            if (playerChoice.ToLower() == "x")
                PlayerIsX = true;
            else if (playerChoice.ToLower() == "o")
                PlayerIsX = false;
            else
            {
                Console.WriteLine("You didn't answer with (X) or (O), you've been place on X's team");
                PlayerIsX = true;
            }

            for (int i = 0; i < 9; i++)
            {
                gameBoard[i] = i.ToString();
            }

            Console.WriteLine("Game Board Initialized");
            PrintBoard();
            GameCycle("initialized");
        }

        public override void GameCycle(string state)
        {
            if (state == "moved") //checks if somebody won or the board is full
            {

                if ((gameBoard[0] == currPlayer && gameBoard[4] == currPlayer && gameBoard[8] == currPlayer) ||
                    (gameBoard[0] == currPlayer && gameBoard[1] == currPlayer && gameBoard[2] == currPlayer) ||
                    (gameBoard[0] == currPlayer && gameBoard[3] == currPlayer && gameBoard[6] == currPlayer) ||
                    (gameBoard[1] == currPlayer && gameBoard[4] == currPlayer && gameBoard[7] == currPlayer) ||
                    (gameBoard[2] == currPlayer && gameBoard[4] == currPlayer && gameBoard[6] == currPlayer) ||
                    (gameBoard[2] == currPlayer && gameBoard[5] == currPlayer && gameBoard[8] == currPlayer) ||
                    (gameBoard[3] == currPlayer && gameBoard[4] == currPlayer && gameBoard[5] == currPlayer) ||
                    (gameBoard[6] == currPlayer && gameBoard[7] == currPlayer && gameBoard[8] == currPlayer) ||
                    (movesMade == 9))
                    GameOver(true);
                else
                    Update();
            } //Checks if a player has won or the game board is full.

            if (state == "updated")
            {
                PlayerIsX = !PlayerIsX;
                Move();
            } //After the game board is updated, switch players and have them make a Move();

            if (state == "initialized")
            {
                Move();
            } //Makes player Move() after game boardhas initialized.
        }
    }
}
