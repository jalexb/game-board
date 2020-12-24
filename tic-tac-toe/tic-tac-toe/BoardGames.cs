using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using tic_tac_toe;

namespace tic_tac_toe
{
    /// <summary>
    /// builds and updates the game board
    /// </summary>
    public class BoardGames
    {
        public string Title { get; set; }

        public string[] GameBoard;

        public string[] emptyPositions;

        public string[] minimaxGameBoard;

        public int[] UserOptions { get; set; }

        public Player Player { get; set; }
        
        public int MovesMade { get; set; } = 0;
        public int minimaxMovesMade { get; set; } = 0;

        public int maxMoves = 0;
        public bool playerIsAI { get; set; } = false;
        public int accumulativeScores { get; set; } = 0;
        public int MaxMoves { get; set; }


        public virtual void Initialize()
        {}

        public void Update()
        {
            Player.CurrPlayer = Player.CurrPlayer == "X" ? "O" : "X";
            PrintBoard();
        }

        public void Move(int playerMove)
        {
            if (Player.MoveOptions.Contains(playerMove))
            {
                MovesMade++;
                UpdateGameBoard(playerMove);
            }
            else
            {
                Console.WriteLine("There's already a piece there.");
                Move(Player.Move());
            }
        }

        public void UpdateGameBoard(int selectedMove)
        {
            int gameboardIndexOfSelectedMove = UserOptions[selectedMove];
            GameBoard[gameboardIndexOfSelectedMove] = Player.CurrPlayer;
            Player.UpdateValidPositions(GameBoard, selectedMove);
        }

        public void SetPlayerPiece(string userChoice)
        {
            Player = new Player(userChoice, UserOptions);
        }

        public virtual bool GameOver(string[] gameBoard, string currPlayer) 
        {
            return false;
        }
        public bool EndOfGame()
        {

            PrintBoard();

            /*if (thereIsAWinner) {
                Console.WriteLine("Congratulations Player {0}, you won!", currPlayer);
            } else {
                Console.WriteLine("Game over. Nobody has won.");
            }*/

            string playAgain = null;
            while (playAgain == null)
            {
                Console.WriteLine("Would you like to play again? (Y)es or (N)o?");
                playAgain = Console.ReadLine();

                if (playAgain.ToUpper() == "Y")
                {
                    return true;
                }
                else if (playAgain.ToUpper() == "N")
                {
                    return false;
                }
                else 
                { 
                    playAgain = null; 
                }
            }

            return false;

            
        }


        /*
        public int Minimax()
        {
            EmptyPositionFinder();
            
            string currentPlayerPiece = (playerIsAI) ? (PlayerIsX) ? "O" : "X" : (PlayerIsX) ? "X" : "O";
            string aiPiece = PlayerIsX ? "O" : "X";
            string playerPiece = (PlayerIsX) ? "X" : "O";

            
            string[] newGameBoard = minimaxGameBoard;

            if (minimaxMovesMade < movesMade)
                minimaxMovesMade = movesMade;



            if (GameOver(newGameBoard, currentPlayerPiece))
            {
                if (currentPlayerPiece == aiPiece)
                {
                    accumulativeScores += 10;
                    return accumulativeScores;
                }
                if (currentPlayerPiece == playerPiece)
                {
                    accumulativeScores -= 10;
                    return accumulativeScores;
                }
            }
            else if (minimaxMovesMade == maxMoves)
            {
                return accumulativeScores;
            }
            else
            {
                for (var i = 0; i < emptyPositions.Length; i++)
                {
                    if (!playerIsAI) //min
                    {
                        int bestValue = -100000;
                        playerIsAI = true;
                        newGameBoard[int.Parse(emptyPositions[i]) - 1] = playerPiece;
                        minimaxGameBoard = newGameBoard;
                        int v = Minimax(); //5 -- 3 -- 1
                        bestValue = Math.Max(bestValue, v);
                        return bestValue;

                    }
                    else //max
                    {
                        int bestValue = 100000;
                        playerIsAI = false;
                        newGameBoard[int.Parse(emptyPositions[i]) - 1] = aiPiece;
                        minimaxGameBoard = newGameBoard;
                        int v = Minimax(); //6 -- 4 -- 2
                        bestValue = Math.Min(bestValue, v);
                        return bestValue;
                    }
                }
            }
            
        }*/

        public virtual void PrintBoard()
        {}
    }
}
