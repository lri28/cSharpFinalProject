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
    }

    // Prints the current game board

  

    // Checks the validity of the move


    // Drops the item in the specified column


    // Checks the winning combinations


    // Check columns


    // Check diagonals



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
