/*
 * Name: Connor M Fitzgerald
 * Course: CSCI 1250, Section 002
 * Assignment: Lab 06, Three Short Problems
 * Date: October 21, 2026
 * Description: A menu that keeps running until the user quits, offering three
 * independent exercises or all three at once. Each exercise
 * practices decisions and one of the four loops.
 */

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
    choice = UserInput("Choose 1 through 5");

    // User Input Check. 
    // While loop so that the user is prompted after every invalid input, only if the first input was invalid.
    // this loop choice was also made so that an alternate message prints
    while(choice < 1 || choice > 5)
    {
        choice = UserInput("Please choose a number 1 through 5");
    }

    // Blank space for aesthetics
    System.Console.Write("\n");

    // Exercises

    // Exercise 1 (Score Check)
    if (choice == 1 || choice == 4)
    {
        System.Console.WriteLine("=== Exercise 1: The Grade Checker ===");
        
        //User Score Input and validation
        int score = UserInput("Score");

        // While score is anything other than an integer 0-100, re-prompt to input a number 0-100
        // Loop choice reasoning on lines 33 & 34
        while(score < 0 || score > 100)
        {
            System.Console.WriteLine("A score must be a whole number between 0 and 100.");
            score = UserInput("Score");
        }

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
            System.Console.Write("Roll again? ([Y]es/[N]o): ");
            char rollAgain = Console.ReadLine().ToUpper()[0];
            // Check if input begins with Y for yes or N for no and repeat question if either is false
            // Loop choice reasoning on line 33
            while(rollAgain != 'Y' && rollAgain != 'N')
            {
                Console.Write("Invalid input. Roll again? ([Y]es/[N]o): ");
                rollAgain = Console.ReadLine().ToUpper()[0];
            }
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
    
    // Exercise 3
    if (choice == 3 || choice == 4)
    {
        
    }



}while(choice != 5);

System.Console.WriteLine("Goodbye!");

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