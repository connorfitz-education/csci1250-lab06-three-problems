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

// Initial Message
System.Console.WriteLine("=== CSCI 1250 Lab 06 === \n1. The Grade Checker \n2. The Dice Table 3. \nThe Score Report \n4. All three 5. Quit");

//Input system and check
System.Console.Write("Chose 1 through 5: ");
string userInput = Console.ReadLine();
while(!userInput.All(char.IsDigit) || userInput == "" || Convert.ToInt32(userInput) > 5 || Convert.ToInt32(userInput) < 0)
{
    System.Console.Write("Chose a number 1 through 5: ");
    userInput = Console.ReadLine();
}
int choice = Convert.ToInt32(userInput);

System.Console.WriteLine($"Choice = {choice}");