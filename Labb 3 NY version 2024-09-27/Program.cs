namespace Labb_3_NY_version_2024_09_27
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool gameOn = true;

            Console.WriteLine("Hej och välkommen till GuessNumber!");
            Console.WriteLine("Jag tänker på ett nummer. Kan du gissa vilket? Du får fem försök.");
            

            while (gameOn)
            {
                int guessResult;
                int maxTries = 5;

                Random rand = new Random();
                guessResult = rand.Next(1, 20); // Generar ett tal mellan 1 - 20

                Console.WriteLine("Jag har tänkt på ett nummer mellan 1 och 20. Gissa vilket!");

                int remainingTries = maxTries;

                while (remainingTries > 0)
                {
                   
                    bool isNumber = int.TryParse(Console.ReadLine(), out int userGuess);


                    if (!isNumber)
                    {
                        Console.WriteLine("Nu blev det fel inmatning! Försök igen!");
                        continue;
                    }

                    //Hämtar checkGuess metoden
                    if (CheckGuess(userGuess, guessResult, ref remainingTries))
                    {
                        Console.WriteLine("Yess! Du gissade rätt! Du vann!");
                        Console.WriteLine($"Du hade {remainingTries} gissningar kvar");
                        break;
                    }
                    Console.WriteLine($"Du har {remainingTries} gissningar kvar");

                }


                if (remainingTries == 0)
                {
                    Console.WriteLine($"Du har inga gissningar kvar. Det rätta numret var {guessResult}. Du förlorade!");
                }

                // Om du skulle vilja spela igen
                Console.WriteLine("Vill du spela igen? (y/n)");
                string playAgain = Console.ReadLine();
                if (playAgain.ToLower() != "y")
                {
                    gameOn = false;
                }
                Console.Clear();
            }
        }


        //Hämtar CheckGuess metoden med en switch case för att se resultatet från användaren 
        static bool CheckGuess(int userGuess, int guessResult, ref int remaniningTries)
        {   /*
            remainingTries--; // Decrease remaining tries

            // Determine the relationship between userGuess and guessResult
            int result;
            if (userGuess == guessResult)
            {
                result = 1; // Correct guess
            }
            else if (userGuess < guessResult && guessResult - userGuess <= 3)
            {
                result = 2; // Slightly too low
            }
            else if (userGuess < guessResult)
            {
                result = 3; // Too low
            }
            else if (userGuess > guessResult && userGuess - guessResult <= 3)
            {
                result = 4; // Slightly too high
            }
            else
            {
                result = 5; // Too high
            }

            // Using the result in the switch statement
            switch (result)
            {
                case 1:
                    // Case when the guess is correct
                    return true;

                case 2:
                    // Slightly too low
                    Console.WriteLine("Lite för lågt men väldigt nära!");
                    break;

                case 3:
                    // Too low
                    Console.WriteLine("Väldigt lågt tal! Gissa högre.");
                    break;

                case 4:
                    // Slightly too high
                    Console.WriteLine("Lite för högt men väldigt nära!");
                    break;

                case 5:
                    // Too high
                    Console.WriteLine("Väldigt högt tal! Gissa lägre.");
                    break;
            }
            */ // Gjorde om switch casen för den blev för lång 

            remaniningTries--;

            switch (userGuess)
            {
                case int n when n == guessResult:
                    return true;

                case int n when n < guessResult:
                    if (guessResult - n <= 3)
                    {
                        Console.WriteLine("Lit för lågt men nära!");
                    }
                    else
                    {
                        Console.WriteLine("Väldigt lågt tal! Gissa högre.");
                    }
                    break;

                case int n when n > guessResult:
                    if (n - guessResult <= 3)
                    {
                        Console.WriteLine("Lite för högt men väldigt nära!");
                    }
                    else
                    {
                        Console.WriteLine("Väldigt högt tal! Gissa lägre.");
                    }
                    break;
            }
            return false;
        }
    }
}


 
    

