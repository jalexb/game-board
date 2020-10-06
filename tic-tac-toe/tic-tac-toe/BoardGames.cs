using System;
using System.Collections.Generic;
using System.Text;

namespace BoredGames
{
    /// <summary>
    /// builds and updates the game board
    /// </summary>
    public class BoardGames
    {

        //The game board class should have methods in properties that connect 4 and tic tac toe inherit
        //Those classes include:
        //printing a game board
        //checking the state of the game
        //having a winner, or a draw
        //instantiating the game board, and the movesDictionary
        
        //There should be classes that are seperate from tic tac to and connect 4
        //things that be seperate should include:
        //each player of the game
        //updating the game board
        //initializing the game board

        //Game Board Player:
        //counts the moves
        //

        //IsXPlayer
        //YPlayer
        //Dictionary from 1-9
        // 1 2 3
        // 4 5 6
        // 7 8 9

        //Methods:
        //update()   updates and prints the game board
        //move() waits for player to make a move
        //initialize() initializes the board, resets the dictionary
        //GameOver() when the game board is full, or someone won
        //GameState() ensures the game completes the game cycle.
        //MinMax value system for the computer to calculate the nextmove

        public Dictionary<int, string> gameBoard = new Dictionary<int, string>();
        public bool PlayerIsX { get; set; }
        public bool WinnerIsX { get; set; }
        public string currPlayer { get; set; }
        public int movesMade { get; set; } = 0;

        public virtual void Initialize()
        {}

        public void Update()
        {
            PrintBoard();
            GameCycle("updated");
        }

        public virtual void Move()
        {}

        public virtual void GameCycle(string state)
        {}

        public void GameOver(bool thereIsAWinner)
        {

            PrintBoard();

            if (thereIsAWinner) {
                Console.WriteLine("Congratulations Player {0}, you won!", currPlayer);
            } else {
                Console.WriteLine("Game over. Nobody has won.");
            }

            Console.WriteLine("Would you like to play again? (Y)es or (N)o?");
            string playAgain = Console.ReadLine();

            if (playAgain.ToLower() == "y") {
                Initialize();
            } else {
                Console.WriteLine("Thanks for playing!!");
                System.Environment.Exit(1);
            }

            
        }

        public virtual void PrintBoard()
        {}
    }
}
