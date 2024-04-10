/*===============================================================
Author: Leona Rose Ilao || Rogine Calicdan
Title: Connect 4 Final Project
Subject: Introduction to Object-Oriented Programming
*/

using System;

namespace ConnectFour
{

    // Abstract class that represents a player

    abstract class Player
    {

        // Properties to store the name of the player and symbol
        // Set getters and setters
        public string Name { get; set; }
        public char Symbol { get; set; }

        // Constructors to initialize the player name and symbol
        public Player(string name, char symbol)
        {
            Name = name;
            Symbol = symbol;
        }

        // Abstract method to get the column choice
        // This method must be implemented by subclasses (HumanPlayer or ComputerPlayer)
        public abstract int GetColumnChoice();  
        
    }

    // Class representing a human player, inherits from Player

    class HumanPlayer : Player
    {
    }

    // Class representing a computer player, inherits from Player

    class ComputerPlayer : Player
    {

    }

    // Program class

    class Program
    {
    static char[,] board = new char[6, 7];  // The board is in 2D array
    static Player player1;  // Player 1 instance
    static Player player2;  // Player 2 instance [human or computer]
    static bool player1Turn = true; // Player 1s turn indication

    // Initialization of game board
    // Initialize the game board with '#'character
    static void InitializeBoard()
    {
        for (int row = 0; row < 6; row++)
        {
            for (int col = 0; col < 7; col++)
            {
                board[row, col] = '#';
            }
        }
    }

    // Prints the current game board
    static void PrintBoard()
    {
        Console.WriteLine("\nConnect 4 Game Development Project:\n");

        for (int row = 0; row < 6; row++)
        {
            for (int col = 0; col < 7; col++)

            {
                Console.Write(board[row, col] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("1 2 3 4 5 6 7"); // Column numbers to press by players
    }

  

    // Checks the validity of the move

        static bool IsValidMove(int column)
        {
            return board[0, column] == '#';
        }

    // Drops the item in the specified column

        static void DropPiece(int column, char symbol)
        {
            for (int row = 5; row >= 0; row--)
            {
                if (board[row, column] == '#')
                {
                    board[row, column] = symbol;
                    break;
                }
            }
        }

    // Checks the winning combinations
static bool CheckForWin()
{
    // Check rows
    for (int row = 0; row < 6; row++)
    {
        for (int col = 0; col < 4; col++)
        {
            if (board[row, col] != '#' &&
                board[row, col] == board[row, col + 1] &&
                board[row, col] == board[row, col + 2] &&
                board[row, col] == board[row, col + 3])
            {
                return true;
            }
        }
    }

    // Check columns
    for (int col = 0; col < 7; col++)
    {
        for (int row = 0; row < 3; row++)
        {
            if (board[row, col] != '#' &&
                board[row, col] == board[row + 1, col] &&
                board[row, col] == board[row + 2, col] &&
                board[row, col] == board[row + 3, col])
            {
                return true;
            }
        }
    }

    // Check diagonals
    for (int row = 0; row < 3; row++)
    {
        for (int col = 0; col < 4; col++)
        {
            if (board[row, col] != '#' &&
                board[row, col] == board[row + 1, col + 1] &&
                board[row, col] == board[row + 2, col + 2] &&
                board[row, col] == board[row + 3, col + 3])
            {
                return true;
            }
        }
    }

    for (int row = 0; row < 3; row++)
    {
        for (int col = 3; col < 7; col++)
        {
            if (board[row, col] != '#' &&
                board[row, col] == board[row + 1, col - 1] &&
                board[row, col] == board[row + 2, col - 2] &&
                board[row, col] == board[row + 3, col - 3])
            {
                return true;
            }
        }
    }

    return false;
}



    // Checks if all pieces drop which results to draw

    // Method to handle the game logic

    // Display the outcome


    // Main start of the program

            static void Main(string[] args)
        {
            
            Console.WriteLine("Connect 4 Game Development Project:\n");

            // Initialize the game and players
            Console.Write("Enter Player 1's name: ");   // Player's 1's name
            string player1Name = Console.ReadLine();
            player1 = new HumanPlayer(player1Name, 'X');    // Create player 1 instance as human

            Console.Write("\nPlay against human or the computer?\n");
            Console.Write("Type: [human] || [computer]: "); // Determine human or computer choice
            string opponentChoice = Console.ReadLine().ToLower();

            if (opponentChoice == "human")
            {
                Console.Write("\nEnter Player 2's name: ");
                string player2Name = Console.ReadLine();
                player2 = new HumanPlayer(player2Name, 'O');    // Human instance
            }
            else if (opponentChoice == "computer")
            {
                player2 = new ComputerPlayer("Computer", 'O');  // Computer instance
            }
            else
            {
                Console.WriteLine("\nInvalid choice. Default: Human Player.");
                Console.Write("Enter Player 2's name: ");
                string player2Name = Console.ReadLine();
                player2 = new HumanPlayer(player2Name, 'O');
            }

            Console.WriteLine($"\n{player1.Name}: X | {player2.Name}: O\n");

            
  
}
