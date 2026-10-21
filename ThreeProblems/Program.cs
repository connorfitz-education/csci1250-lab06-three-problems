/*
* Name: Connor M Fitzgerald
* Course: CSCI 1250, Section 002
* Assignment: Lab 06, Three Short Problems
* Date: October 21, 2026
* Description: A menu that keeps running until the user quits, offering three
* independent exercises or all three at once. Each exercise
* practices decisions and one of the four loops.
*/

// The Menu
using System.Runtime.InteropServices;

int choice = 0;

// Initial Message

//Print the options and prompt the user for an input
do
{
    System.Console.WriteLine("=== CSCI 1250 Lab 06 ===");
    System.Console.WriteLine("1. The Grade Checker");  
    System.Console.WriteLine("2. The Dice Table");
    System.Console.WriteLine("3. The Score Report");
    System.Console.WriteLine("4. All three");
    System.Console.WriteLine("5. Quit");

    // User Input System and Input Check
    choice = UserInput("Choose 1 through 5");
    while(choice < 1 || choice > 5)
    {
        choice = UserInput("Please choose a number 1 through 5");
    }
    System.Console.Write("\n");

    
    //Outputs based on input
    if (choice == 1 || choice == 4)
    {
        // Exercise 1
        System.Console.WriteLine("=== Exercise 1: The Grade Checker ===");
        int score = UserInput("Score");
        while(score < 0 || score > 100)
        {
            System.Console.WriteLine("A score must be between 0 and 100.");
            score = UserInput("Score");
        }
        if(score < 60)
        {
            System.Console.WriteLine($"{score} earns an F.\n");
        }
        else if(score >= 60 && score < 70)
        {
            System.Console.WriteLine($"{score} earns an D.\n");
        }
        else if(score >= 70 && score < 80)
        {
            System.Console.WriteLine($"{score} earns a C.\n");
        }
        else if(score >= 80 && score < 90)
        {
            System.Console.WriteLine($"{score} earns a B.\n");
        }
        else if(score >= 90)
        {
            System.Console.WriteLine($"{score} earns an A.\n");
        }
    }
    if (choice == 2 || choice == 4)
    {
        // Exercise 2
    }
    if (choice == 3 || choice == 4)
    {
        // Exercise 3
    }



}while(choice != 5);

System.Console.WriteLine("Goodbye!");

static int UserInput(string inputMessage)
{
    Console.Write($"{inputMessage}: ");
    string userInput = Console.ReadLine();
    if(userInput == "" || !userInput.All(char.IsDigit))
    {
        userInput = "-1";
    }
    return Convert.ToInt32(userInput);
}