
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tic_tac_toe
{
    class Tic_Tac_Toe : BoardGames
    {

        public Tic_Tac_Toe()
        {
            Title = "Tic Tac Toe";
            MaxMoves = 9;
            UserOptions = new int[9];
            MovesMade = 0;
            GameBoard = new string[9];

            for (int i = 0; i < 9; i++)
            {
                UserOptions[i] = i;
                GameBoard[i] = i.ToString();
            }
        }

        public override void PrintBoard()
        {
            Console.Clear();
            Console.WriteLine(" {0} | {1} | {2} ", GameBoard[0], GameBoard[1], GameBoard[2]);
            Console.WriteLine("___|___|___ ");
            Console.WriteLine(" {0} | {1} | {2} ", GameBoard[3], GameBoard[4], GameBoard[5]);
            Console.WriteLine("___|___|___ ");
            Console.WriteLine(" {0} | {1} | {2} ", GameBoard[6], GameBoard[7], GameBoard[8]);
            Console.WriteLine("   |   |     ");
        }
        public override bool GameOver(string[] thisthing, string currPlayer)
        {
            if ((GameBoard[0] == currPlayer && GameBoard[4] == currPlayer && GameBoard[8] == currPlayer) ||
                    (GameBoard[0] == currPlayer && GameBoard[1] == currPlayer && GameBoard[2] == currPlayer) ||
                    (GameBoard[0] == currPlayer && GameBoard[3] == currPlayer && GameBoard[6] == currPlayer) ||
                    (GameBoard[1] == currPlayer && GameBoard[4] == currPlayer && GameBoard[7] == currPlayer) ||
                    (GameBoard[2] == currPlayer && GameBoard[4] == currPlayer && GameBoard[6] == currPlayer) ||
                    (GameBoard[2] == currPlayer && GameBoard[5] == currPlayer && GameBoard[8] == currPlayer) ||
                    (GameBoard[3] == currPlayer && GameBoard[4] == currPlayer && GameBoard[5] == currPlayer) ||
                    (GameBoard[6] == currPlayer && GameBoard[7] == currPlayer && GameBoard[8] == currPlayer) ||
                    (MovesMade == 9))
                return true;
            else
                return false;
        }
    }
}
