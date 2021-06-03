using System;

namespace RandomNumberGeneration
{
    class Program
    {
        static void Main(string[] args)
        {

            do
            {
                Console.WriteLine("Welcome to the Grand Circus Casino!");

                int numberOfSides = GetUserInputAsInt();

                int[] dice = RollTwoDice(numberOfSides);

                PrintResults(dice, numberOfSides);
            }
            while (GetContinue() == true);

        }


       public static bool GetContinue()
        {
            Console.WriteLine("Roll Again? (y/n)");
            string answer = Console.ReadLine().ToUpper();

            if (answer == "Y")
            {
                return true;
            }
            else if (answer == "N")
            {
                Console.WriteLine("Thanks for playing!");
                return false;
            }
            else
            {
                Console.WriteLine("I'm sorry, I didn't understand that. Please try again.");
                return GetContinue();

            }

        }
                  
        public static void PrintResults(int[] dice, int sides)
        {
            Console.WriteLine($"Roll One: {dice[0]}\tRoll Two: {dice[1]}\tTotal: {dice[0] + dice[1]}");
            if (sides == 6)
            {

                if (dice[0] == 1 && dice[1] == 1)
                {
                    Console.WriteLine($"You rolled a {dice[0]} & {dice[1]}, (total: {dice[0] + dice[1]}! \nSnake Eye's: Two 1s");
                }

                if ((dice[0] == 1 && dice[1] == 2) || (dice[0] == 2 && dice[1] == 1))
                {
                    Console.WriteLine($"You rolled a {dice[0]} & {dice[1]}, (total: {dice[0] + dice[1]}! \nAce Deuce: A 1 and 2");
                }

                if (dice[0] == 6 && dice[1] == 6)
                {
                    Console.WriteLine($"You rolled a {dice[0]} & {dice[1]}, (total: {dice[0] + dice[1]}! \nBox Cars: Two 6s");
                }

                if ((dice[0] + dice[1] == 7 || dice[0] + dice[1] == 11))
                {
                    Console.WriteLine($"You rolled a {dice[0]} & {dice[1]}, (total: {dice[0] + dice[1]}! \nWin: A total of 7 or 11");
                }

                if ((dice[0] + dice[1] == 2) || (dice[0] + dice[1] == 3) || (dice[0] + dice[1] == 12))
                {
                    Console.WriteLine("Craps!");
                }

            }
        }



        public static int[] RollTwoDice(int sides)
        {

            Random random = new Random();

            int[] diceRolls = new int[2];


            int roll1 = random.Next(1, sides + 1);
            int roll2 = random.Next(1, sides + 1);

            diceRolls[0] = roll1;
            diceRolls[1] = roll2;

            return diceRolls;
        }


        public static int GetUserInputAsInt()
        {

            int result = 0;
            bool goOn = true;
            while (goOn)
            {
                Console.WriteLine("How many sides should each dice have?");
                bool userInput = int.TryParse(Console.ReadLine(), out result);

                if (userInput == true)
                {
                    goOn = false;
                }
                else
                {
                    Console.WriteLine("I'm sorry, I didn't understand that. Please enter a valid number: ");
                }
            }
            return result;
        }
    }
}