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
	// Constructor initializing human player with two parameters
public HumanPlayer(string name, char symbol) : base(name, symbol)
{
}

// Implements the abstract method GetColumnChoice to get the column choice from the player
public override int GetColumnChoice()
{
    int column;
    if (!int.TryParse(Console.ReadLine(), out column) || column < 1 || column > 7)
    {
        return -1;
    }
    return column - 1;
}
	
    }

    // Class representing a computer player, inherits from Player

    class ComputerPlayer : Player
    {
	// Constructor initializing computer player with two parameters
public ComputerPlayer(string name, char symbol) : base(name, symbol)
{
}

// Implements the abstract method GetColumnChoice to get the column choice from the player
public override int GetColumnChoice()
{

    // Generate a random column index between 0 and 6
    Random random = new Random();
    return random.Next(0, 7);
}
    }

    // Program class

    class Program
    {
    static char[,] board = new char[6, 7];  // The board is in 2D array
    static Player player1;  // Player 1 instance
    static Player player2;  // Player 2 instance [human or computer]
    static bool player1Turn = true; // Player 1s turn indication

    // Initialization of game board
    // Initialize the game board with '-'character
    static void InitializeBoard()
    {
        for (int row = 0; row < 6; row++)
        {
            for (int col = 0; col < 7; col++)
            {
                board[row, col] = '-';
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
            return board[0, column] == '-';
        }

    // Drops the item in the specified column

        static void DropPiece(int column, char symbol)
        {
            for (int row = 5; row >= 0; row--)
            {
                if (board[row, column] == '-')
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
            if (board[row, col] != '-' &&
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
            if (board[row, col] != '-' &&
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
            if (board[row, col] != '-' &&
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
            if (board[row, col] != '-' &&
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

        static bool CheckForDraw()
        {
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    if (board[row, col] == '-')
                    {
                        return false;
                    }
                }
            }
            return true;
        } 
        
    // Method to handle the game logic
static void PlayGame()
{
    InitializeBoard(); // Resets the game

    do
    {
        PrintBoard(); // Prints the initial board or the board after each move

        // Determine the current player
        Player currentPlayer = player1Turn ? player1 : player2;
        Console.WriteLine($"\n{currentPlayer.Name}'s turn ({currentPlayer.Symbol}):");
        int column = currentPlayer.GetColumnChoice(); // Get the player's column choice

        // Validate the column choice
        if (column == -1 || !IsValidMove(column))
        {
            Console.WriteLine("\nInvalid column choice. Must be [1-7 only]");
            continue; // Restart the loop for the current player's turn
        }

        DropPiece(column, currentPlayer.Symbol); // Drop the player's piece

        Console.Clear(); // Clear the console before printing the updated board
        //PrintBoard(); // Print the updated board after the move

        player1Turn = !player1Turn; // Switch player's turn

    } while (!CheckForWin() && !CheckForDraw());

    // Display the outcome
            if (CheckForWin())
            {
                Player winner = player1Turn ? player2 : player1;
                Console.WriteLine("\nIt is a Connect 4.");
                Console.WriteLine("┌─────────────────────┐");
                Console.WriteLine($"  \"{winner.Name}\" WINS!");
                Console.WriteLine("└─────────────────────┘");
            }
            else
            {
                Console.WriteLine("\nThe game is a draw!");
            }
        }

    
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
