
using System;
using System.Collections.Generic;
using System.Text;

namespace tic_tac_toe
{
    class Connect4 : BoardGames
    {

        //Initializes game board
        //Sets 0-6 options for the bottom row of the game.
        //Once a move is made, eg.) 6, it will set the user selection to the next row

        public Connect4()
        {
            Title = "Connect 4";
            MaxMoves = 42;
            UserOptions = new int[7];
            MovesMade = 0;
            GameBoard = new string[42];

            for (int i = 0; i < 42; i++)
            {
                if (i > 34)
                {
                    UserOptions[i - 35] = i;
                }
                GameBoard[i] = " ";
            }
        }


        public override bool GameOver(string[] gameBoard, string currPlayer)
        {
            for (int i = 0; i <= 17; i++)
            {
                if (gameBoard[i] == currPlayer &&
                    gameBoard[i + 8] == currPlayer &&
                    gameBoard[i + 16] == currPlayer &&
                    gameBoard[i + 24] == currPlayer)
                {
                    return true;
                }
                if (i == 3 || i == 10 || i == 17)
                {
                    i += 3;
                }
            }

            // '/' diagonal check(base: 4 min:+6 mid:+12 max: +18) maxI = 41-18=23
            for (int i = 4; i < 21; i++)
            {
                if (gameBoard[i] == currPlayer &&
                    gameBoard[i + 6] == currPlayer &&
                    gameBoard[i + 12] == currPlayer &&
                    gameBoard[i + 18] == currPlayer)
                {
                    return true;
                }
                if (i == 0 || i == 7 || i == 14)
                {
                    i += 2;
                }
            }

            // '|' check (base:0 min:+7 mid:+14 max:+21 ) maxI = 41-21=20
            for (int i = 0; i < 20; i++)
            {
                if (gameBoard[i] == currPlayer &&
                   gameBoard[i + 7] == currPlayer &&
                   gameBoard[i + 14] == currPlayer &&
                   gameBoard[i + 21] == currPlayer)
                {
                    return true;
                }
            }

            // '----' check (base:0 min:+1 mid:+2 max:+3 ) maxI = 41-3=38
            for (int i = 0; i < 38; i++)
            {
                if (gameBoard[i] == currPlayer &&
                   gameBoard[i + 1] == currPlayer &&
                   gameBoard[i + 2] == currPlayer &&
                   gameBoard[i + 3] == currPlayer)
                {
                    return true;
                }

                if (i == 3 || i == 10 || i == 17 || 1 == 24 || i == 31)
                {
                    i += 3;
                }
            }
            if (MovesMade == 41)
            {
                return true;
            }
            return false;
        }
        public override void PrintBoard() //7 columns 6 rows
        {
            Console.Clear();
            Console.WriteLine(" |{0}|{1}|{2}|{3}|{4}|{5}|{6}|", GameBoard[0], GameBoard[1], GameBoard[2], GameBoard[3], GameBoard[4], GameBoard[5], GameBoard[6]);
            Console.WriteLine(" |{0}|{1}|{2}|{3}|{4}|{5}|{6}|", GameBoard[7], GameBoard[8], GameBoard[9], GameBoard[10], GameBoard[11], GameBoard[12], GameBoard[13]);
            Console.WriteLine(" |{0}|{1}|{2}|{3}|{4}|{5}|{6}|", GameBoard[14], GameBoard[15], GameBoard[16], GameBoard[17], GameBoard[18], GameBoard[19], GameBoard[20]); 
            Console.WriteLine(" |{0}|{1}|{2}|{3}|{4}|{5}|{6}|", GameBoard[21], GameBoard[22], GameBoard[23], GameBoard[24], GameBoard[25], GameBoard[26], GameBoard[27]); 
            Console.WriteLine(" |{0}|{1}|{2}|{3}|{4}|{5}|{6}|", GameBoard[28], GameBoard[29], GameBoard[30], GameBoard[31], GameBoard[32], GameBoard[33], GameBoard[34]);
            Console.WriteLine(" |{0}|{1}|{2}|{3}|{4}|{5}|{6}|", GameBoard[35], GameBoard[36], GameBoard[37], GameBoard[38], GameBoard[39], GameBoard[40], GameBoard[41]);
            Console.WriteLine(" |―|―|―|―|―|―|―|");
            Console.WriteLine(" |0|1|2|3|4|5|6|");
        }
    }

    /*
         | | | | | | | |
         | | | | | | | |
         |X| |O|X| | | |
         |X|O|X|X| | | |
         |O|X|O|O| | | |
         |X|O|O|X| | | |
         |―|―|―|―|―|―|―|
         |0|1|2|3|4|5|6|
        Make your move. (0-6)
     */
}
