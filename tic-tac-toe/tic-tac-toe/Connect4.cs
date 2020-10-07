using BoredGames;
using System;
using System.Collections.Generic;
using System.Text;

namespace tic_tac_toe
{
    class Connect4 : BoardGames
    {
        public int[] userOptions { get; private set; } = new int[7];
        public int highestVerticalRow { get; private set; } = 35;

        //Initializes game board
        //Sets 0-6 options for the bottom row of the game.
        //Once a move is made, eg.) 6, it will set the user selection to the next row
        public override void Initialize()
        {
            movesMade = 0;


            Console.WriteLine("Welcome to Connect 4!");
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

            for (int i = 0; i < 42; i++)
            {
                if(i > 34)
                {
                    //gameBoard[i] = (i - 35).ToString(); //sets up userOptions visuals
                    userOptions[i - 35] = i; //saves the gameboard index of the user options
                    //continue;
                }
                gameBoard[i] = " ";
            }

            

            Console.WriteLine("Game Board Initialized");
            PrintBoard();
            GameCycle("initialized");
        }

        public override void Move()
        {
            //Console.Clear();
            int move = -1;
            while (move < 0 || move > 6) //can be sent to base.Move(int maxMove)
            {
                Console.WriteLine("Make your move. (0-6)");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int result))
                {
                    move = result;
                }
            }

            if (gameBoard[move] != "X" && gameBoard[move] != "O") //this down can be set in base.Move()
            {
                
                movesMade++;
                gameBoard[userOptions[move]] = PlayerIsX ? "X" : "O";
                currPlayer = PlayerIsX ? "X" : "O";
                //gameBoard[userOptions[move] - 7] = move.ToString(); //sets the option to the next row
                userOptions[move] = userOptions[move] - 7;
                GameCycle("moved");
            }
            else
            {
                Console.WriteLine("Please make a valid choice.");
                Move();
            }
        }

        public override void GameCycle(string state)
        {
            //if gameboard is full
            //if someone has connected4
            //connects 4 does either diagonal, vertical, or horizontal
            //diagonals would be: increasing 4,10,16,22   || decreasing 0,8,16,24
            //vertical: -7    horizontal: +1
            if (state == "moved") //checks if somebody won or the board is full
            {
                // '\' diagonal check(base: 0 min: +8 mid: +16 max: +24)   maxI = 41-24=17
                for(int i = 0; i <= 17; i++)
                {
                    if(gameBoard[i] == currPlayer && 
                        gameBoard[i + 8] == currPlayer && 
                        gameBoard[i + 16] == currPlayer && 
                        gameBoard[i + 24] == currPlayer)
                    {
                        GameOver(true);
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
                        GameOver(true);
                    }
                    if (i == 0 || i == 7 || i == 14)
                    {
                        i += 3;
                    }
                }

                // '|' check (base:0 min:+7 mid:+14 max:+21 ) maxI = 41-21=20
                for(int i = 0; i < 20; i++)
                {
                    if(gameBoard[i] == currPlayer && 
                       gameBoard[i + 7] == currPlayer && 
                       gameBoard[i + 14] == currPlayer && 
                       gameBoard[i + 21] == currPlayer)
                    {
                        GameOver(true);
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
                        GameOver(true);
                    }

                    if (i == 3 || i == 10 || i == 17 || i == 31)
                    {
                        i += 4;
                    }
                }

                if(movesMade == 41)
                {
                    GameOver(false);
                }

                Update();
            }

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
        public override void PrintBoard() //7 columns 6 rows
        {
            Console.WriteLine(" |{0}|{1}|{2}|{3}|{4}|{5}|{6}|", gameBoard[0], gameBoard[1], gameBoard[2], gameBoard[3], gameBoard[4], gameBoard[5], gameBoard[6]);
            Console.WriteLine(" |{0}|{1}|{2}|{3}|{4}|{5}|{6}|", gameBoard[7], gameBoard[8], gameBoard[9], gameBoard[10], gameBoard[11], gameBoard[12], gameBoard[13]);
            Console.WriteLine(" |{0}|{1}|{2}|{3}|{4}|{5}|{6}|", gameBoard[14], gameBoard[15], gameBoard[16], gameBoard[17], gameBoard[18], gameBoard[19], gameBoard[20]); 
            Console.WriteLine(" |{0}|{1}|{2}|{3}|{4}|{5}|{6}|", gameBoard[21], gameBoard[22], gameBoard[23], gameBoard[24], gameBoard[25], gameBoard[26], gameBoard[27]); 
            Console.WriteLine(" |{0}|{1}|{2}|{3}|{4}|{5}|{6}|", gameBoard[28], gameBoard[29], gameBoard[30], gameBoard[31], gameBoard[32], gameBoard[33], gameBoard[34]);
            Console.WriteLine(" |{0}|{1}|{2}|{3}|{4}|{5}|{6}|", gameBoard[35], gameBoard[36], gameBoard[37], gameBoard[38], gameBoard[39], gameBoard[40], gameBoard[41]);
            Console.WriteLine(" |―|―|―|―|―|―|―|");
            Console.WriteLine(" |0|1|2|3|4|5|6|");
        }
    }

    /*
        |O| | | | | |X|
        |O| | | | | |X|
        |O| | | | |X|X|
        |X|X| | | |O|O|
        |X|X| | | |O|O|
        |X|X| | | |O|O|
        |-|-|-|-|-|-|-|
        |0|1|2|3|4|5|6|
        Congratulations Player X, you won!
     */
}
