
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tic_tac_toe
{
    public class Player
    {
        //-------connect 4 ------
        public bool PlayerIsX { get; set; }
        public string CurrPlayer { get; set; }
        public int[] MoveOptions { get; set; } //need userOptions(0-8),(0-6) corresponding to the gameIndicies(0-8),(35-41)
        public int[] IndexOfMoveOption { get; set; }//gameIndicies(0-6) keeps userOptions(0-6)

        public Player(string playerPiece, int[] moveOptionIndicies)
        {
            if (playerPiece == "x")
            {
                PlayerIsX = true;
                CurrPlayer = "X";
            }
            else
            {
                PlayerIsX = false;
                CurrPlayer = "O";
            }
            IndexOfMoveOption = moveOptionIndicies;

            MoveOptions = new int[moveOptionIndicies.Length];

            for(int i = 0; i < IndexOfMoveOption.Length; i++)
            {
                MoveOptions[i] = i;
            }
        }

        public int Move()
        {
            int move = -1;
            while (move < 0) //can be sent to base.Move(int maxMove)
            {
                Console.WriteLine($"Make your move. ({string.Join(",",MoveOptions)})");
                int.TryParse(Console.ReadLine(), out int input);
                if (MoveOptions.Contains(input))
                {
                    move = input;
                }
            }

            return move;
        }

        public void UpdateValidPositions(string[] gameBoard, int userMove) //gameIndicies(0-5) keeps userOptions(0-5) in connect4
        {

            List<int> ValidGameBoardPositions = GetSplitGameBoard(gameBoard); //contains all available gameboard indexes

            if (gameBoard.Length > 9) //connect4 41 40 39 38 37 36 35
            {

                //the MoveOptions removes the ability to select the 4th column
                //by populating MoveOptions 0-3 and 5-6
                //4 is not in play anymore..

                //When the move option
                if(ValidGameBoardPositions.Contains(IndexOfMoveOption[userMove] - 7)) //Index of userMove - 7 is a valid move
                {
                    IndexOfMoveOption[userMove] = IndexOfMoveOption[userMove] - 7;
                }
                else//Removes the ability to select userMove from MoveOptions, updates IndexOfMoveOption
                {
                    int[] tempMoveOptions = new int[MoveOptions.Length - 1];
                    int[] tempIndexOfMoveOption = new int[IndexOfMoveOption.Length - 1];
                    bool userMoveFound = false;
                    for(int i = 1; i < MoveOptions.Length; i++)
                    {
                        if(MoveOptions[i] == userMove)
                        {
                            userMoveFound = true;
                            continue;
                        }

                        if (userMoveFound)
                        {
                            tempMoveOptions[i] = i - 1;
                            tempIndexOfMoveOption[i - 1] = IndexOfMoveOption[i];
                            continue;
                        }
                        tempIndexOfMoveOption[i] = IndexOfMoveOption[i];
                        tempMoveOptions[i] = i;
                    }

                    IndexOfMoveOption = tempIndexOfMoveOption;
                    MoveOptions = tempMoveOptions;
                }
            }
            else
            {
                MoveOptions = new int[ValidGameBoardPositions.Count];
                MoveOptions = ValidGameBoardPositions.ToArray();
                IndexOfMoveOption = ValidGameBoardPositions.ToArray();
            }
        }

        public List<int> GetSplitGameBoard(string[] gameBoard)
        {
            char[] splitOn = { 'X', 'O', ',' };
            string gameBoardString = string.Join(",", gameBoard);
            string[] splitOnFilledPositions = gameBoardString.Split(splitOn);

            List<int> emptyValueRemoval = new List<int>();
            int j = -1;
            for (int i = 0; i < splitOnFilledPositions.Length; i++)
            {
                if (splitOnFilledPositions[i] == "")
                {
                    j++;
                    continue;
                }
                emptyValueRemoval.Add(i - j);
            }


            return emptyValueRemoval;

        }
    }
}
