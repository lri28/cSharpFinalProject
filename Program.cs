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
        Console.WriteLine("\nGame Development Project: Connect 4\n");

        for (int row = 0; row < 6; row++)
        {
            for (int col = 0; col < 7; col++)

            {
                Console.Write(board[row, col] + " ");
            }
            Console.WriteLine();
        }

	Console.WriteLine("─────────────"); 
	Console.WriteLine("1 2 3 4 5 6 7"); // Column numbers to press by players
	Console.WriteLine("─────────────");
	    
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
static void PlayGame(Player p1, Player p2)
{
    InitializeBoard(); // Resets the game

    do
    {
        PrintBoard(); // Prints the initial board or the board after each move

        // Determine the current player
        Player currentPlayer = player1Turn ? p1 : p2; 
        Console.Write($"\n{currentPlayer.Name}'s turn ({currentPlayer.Symbol}): ");
        
	int column;
        if (currentPlayer is HumanPlayer)
        {
           column = currentPlayer.GetColumnChoice();
        }
        else
        {
         column = currentPlayer.GetColumnChoice();
         Console.WriteLine("Computer processing...");
         Thread.Sleep(1500); // Delay for 1.5 seconds (1500milliseconds)
         }


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
            do
            {
                Console.WriteLine("Game Development Project: Connect 4\n");
                Console.WriteLine("=====================");
                Console.WriteLine("CHOOSE GAME MODE:");
                Console.WriteLine("=====================");
                Console.WriteLine("[1] Human vs. Human");
                Console.WriteLine("[2] Human vs. Computer");
                Console.WriteLine("[3] AI vs. AI");
                Console.Write("\nEnter your choice [1-3]: ");

                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
                {
                    Console.Write("Invalid choice. [Type 1, 2 or 3]: ");
                }

                if (choice == 1)
                {
                    Console.Write("Enter Player 1's name: ");
                    string player1Name = Console.ReadLine();
                    player1 = new HumanPlayer(player1Name, 'X');

                    Console.Write("Enter Player 2's name: ");
                    string player2Name = Console.ReadLine();
                    player2 = new HumanPlayer(player2Name, 'O');
                }
                else if (choice == 2)
                {
                    Console.Write("Enter your name: ");
                    string playerName = Console.ReadLine();
                    Console.WriteLine("You will play against the computer.");
                    Thread.Sleep(3000); // Delay for 3 seconds (3000 milliseconds);
                    player1 = new HumanPlayer(playerName, 'X');
                    player2 = new ComputerPlayer("Computer", 'O');
                }
                else
                {                  
                    player1 = new ComputerPlayer("AI Player 1", 'X');
                    player2 = new ComputerPlayer("AI Player 2", 'O');
                    
                }
                
                Console.WriteLine($"{player1.Name}: X | {player2.Name}: O");
                PlayGame(player1, player2);
               
                string restartChoice;
                do
                {
                    Console.Write("Restart? (Type 'yes' or 'no'): ");
                    restartChoice = Console.ReadLine().ToLower();

                    if (restartChoice != "yes" && restartChoice != "no")
                    {
                        Console.WriteLine("Invalid input. Please type 'yes' or 'no'");
                    }
                } while (restartChoice != "yes" && restartChoice != "no");

                if (restartChoice == "no")
                    break;

                Console.Clear();

            } while (true);

            Console.WriteLine("\nThanks for playing!");
        }
}
}
