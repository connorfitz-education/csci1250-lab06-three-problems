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

    //Input system and check
    System.Console.Write("Chose 1 through 5: ");
    string? userInput = Console.ReadLine();
    while(!userInput.All(char.IsDigit) || userInput == "" || Convert.ToInt32(userInput) > 5 || Convert.ToInt32(userInput) < 1)
    {
        System.Console.Write("Chose a number 1 through 5: ");
        userInput = Console.ReadLine();
    }
    choice = Convert.ToInt32(userInput);
    System.Console.Write("\n");

    
    //Outputs based on input
    if (choice == 1 || choice == 4)
    {
        // Exercise 1
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

