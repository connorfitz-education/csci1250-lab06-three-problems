/*
 * Name: Connor M Fitzgerald
 * Course: CSCI 1250, Section 002
 * Assignment: Lab 06, Three Short Problems
 * Date: October 21, 2026
 * Description: A menu that keeps running until the user quits, offering three
 * independent exercises or all three at once. Each exercise
 * practices decisions and one of the four loops.
 */

using System.Numerics;

int choice = 0;
Random rng = new Random(4000);


// Print the menu options and prompt the user for an input until they input the exit value
// Do While loop so that the program repeats until the user tells it to stop
do
{
    // The Menu

    // Initial Message
    System.Console.WriteLine("=== CSCI 1250 Lab 06 ===");
    System.Console.WriteLine("1. The Grade Checker");  
    System.Console.WriteLine("2. The Dice Table");
    System.Console.WriteLine("3. The Score Report");
    System.Console.WriteLine("4. All three");
    System.Console.WriteLine("5. Quit");

    // User input
    choice = UserInput("Choose 1 through 5", "Choose a number 1 through 5", 1, 5);

    // Blank space for aesthetics
    System.Console.Write("\n");

    // Exercises

    // Exercise 1 (Score Check)
    if (choice == 1 || choice == 4)
    {
        System.Console.WriteLine("=== Exercise 1: The Grade Checker ===");
        
        //User Score Input and validation
        int score = UserInput("Score", "A score must be a whole number between 0 and 100.\nScore", 0, 100);

        //Output letter grade based on score
        ScoreCheck(score);     
    }

    // Exercise 2 (Dice Table)
    if (choice == 2 || choice == 4)
    {
        System.Console.WriteLine("=== Exercise 2: The Dice Table ===");
        int rollNumber = 1;
        int wins = 0;
        bool diceGameActive = true;

        /*
        The loop below does the following:
        Roll 2 dice (6 sided).
        Output: the result of each dice roll, the total of the two dice rolls, the result of the roll.
        Prompt the user to roll again.
        Quit if user does not wish to roll again.
        */
        // Do While loop so that the game repeats until the user says to end it.
        do
        {
            // Roll 2 six-sided die.
            int die1 = rng.Next(1,7);
            int die2 = rng.Next(1,7);
            
            //Output message
            System.Console.Write($"Roll {rollNumber}: {die1} and {die2}, total {die1+die2}. ");
            
            if(die1 == 1 && die2 == 1)
            {
                System.Console.WriteLine("Snake Eyes.");
            }
            else if(die1 == die2)
            {
                System.Console.WriteLine("Doubles!");
            }
            else if(die1+die2 == 7 || die1+die2 == 11)
            {
                System.Console.WriteLine("A winner.");
                ++wins;
            }
            else
            {
                System.Console.Write("\n");
            }

            //User input
            char rollAgain = CharUserInput();
            // Output based on input
            if(rollAgain == 'N')
            {
                DiceGameCheck(rollNumber, wins);
                System.Console.Write("\n");
                diceGameActive = false;
            }
            if(rollAgain == 'Y')
            {
                ++rollNumber;
            }
        }while(diceGameActive);

    }
    
    // Exercise 3 (Score Report)
    if (choice == 3 || choice == 4)
    {
        
        System.Console.WriteLine("=== Exercise 3: The Score Report ===");
        int numOfScores = UserInput("Please enter an amount of scores to check (MIN 1, MAX 20): ", "Please enter a VALID number of scores (1-20) to check:", 1, 20);
        int[] scores = new int[numOfScores];
        //For loop because it repeats until every possible score in the score array is filled (when used like this)
        for(int i = 0; i < scores.Length; i++)
        {
            scores[i] = UserInput($"Score {i+1}", $"A score must be a whole number between 0 and 100.\nScore {i+1}", 0, 100);
        }
        int highest = scores[0];
        int total = 0;
        int passing = 0;
        foreach(int score in scores)
        {
            total += score;
            if(score > highest)
            {
                highest = score;
            }
            if(score > 60)
            {
                ++passing;
            }

        }
        double avg = (double)total/scores.Length;

        System.Console.WriteLine($"\nScores entered: {scores.Length}");
        System.Console.WriteLine($"Total: {total}");
        System.Console.WriteLine($"Average: {avg:F1}");
        System.Console.WriteLine($"Highest: {highest}");
        System.Console.WriteLine($"Passing {passing} of {scores.Length}\n");

    }



}while(choice != 5);

System.Console.WriteLine("Goodbye.");

static void DiceGameCheck(int rollNumber, int wins)
{
    if(rollNumber == 1)
    {
        if(wins == 0)
        {
            System.Console.WriteLine($"You rolled once and lost.");
        }
        else
        {
            System.Console.WriteLine($"You rolled once and won.");
        }
        
    }
    else
    {
        if(wins == 0)
        {
            System.Console.WriteLine($"You rolled {rollNumber} times and lost every game.");
        }
        else if(wins == 1)
        {
            System.Console.WriteLine($"You rolled {rollNumber} times and won once.");
        }
        else if(wins > 1)
        {
            System.Console.WriteLine($"You rolled {rollNumber} times and won {wins} times.");
        }
    }
}

static int UserInput(string inputMessage, string errorMessage, int rangeMin, int rangeMax)
{
    Console.Write($"{inputMessage}: ");
    string userInput = Console.ReadLine();
    
    // While loop so that it only runs if necessary, repeats forever until valid input is entered
    // chosen over do while loop so that the input can contain a different message than the initial input message

    while(userInput == "" || !userInput.All(char.IsDigit) || Convert.ToInt32(userInput) < rangeMin || Convert.ToInt32(userInput) > rangeMax)
    {
        System.Console.Write($"{errorMessage}: ");
        userInput = Console.ReadLine();
    }
    return Convert.ToInt32(userInput);
}

static char CharUserInput()
{
    System.Console.Write("Roll again? ([Y]es/[N]o): ");
    char rollAgain = Console.ReadLine().ToUpper()[0];
    
    // Check if input begins with Y for yes or N for no and repeat question if either is fals
    // While loop so that it only runs if necessary, repeats forever until valid input is entered
    // chosen over do while loop so that the input can contain a different message than the initial input message
    while(rollAgain != 'Y' && rollAgain != 'N')
    {
        Console.Write("Invalid input. Roll again? ([Y]es/[N]o): ");
        rollAgain = Console.ReadLine().ToUpper()[0];
    }
    return rollAgain;
}

static void ScoreCheck(int score)
{
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