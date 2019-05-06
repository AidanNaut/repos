using System;

namespace RockPaperScissors
{
    class Program
    {
        public static bool loop = true;

        public static int wins;
        public static int totalwins;
        public static int losses;
        public static int totallosses;
        public static int ties;
        public static int totalties;
        public static int totalrounds;

        public static int roundnum;
        public static int compguess;

        public static string playerthrow;
        public static string compthrow;

        public static Random random = new Random();

        static void Main(string[] args)
        {

            // KEWL ASCII TITLE
            Console.WriteLine(@"                _                                             _                        ");
            Console.WriteLine(@"               | |                                           (_)                       ");
            Console.WriteLine(@" _ __ ___   ___| | __  _ __   __ _ _ __   ___ _ __   ___  ___ _ ___ ___  ___  _ __ ___ ");
            Console.WriteLine(@"| '__/ _ \ / __| |/ / | '_ \ / _` | '_ \ / _ \ '__| / __|/ __| / __/ __|/ _ \| '__/ __|");
            Console.WriteLine(@"| | | (_) | (__|   <  | |_) | (_| | |_) |  __/ |    \__ \ (__| \__ \__ \ (_) | |  \__ \");
            Console.WriteLine(@"|_|  \___/ \___|_|\_\ | .__/ \__,_| .__/ \___|_|    |___/\___|_|___/___/\___/|_|  |___/");
            Console.WriteLine(@"                      | |         | |                                                  ");
            Console.WriteLine(@"                      |_|         |_|                                                  ");
            Console.WriteLine("\n");
            Console.WriteLine("Program by: William Pasbrig      Title generated at: \'http://patorjk.com/software/taag\'");
            Console.WriteLine("\n");

            // Press any key to start... 
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("\n");
            Console.WriteLine("Press enter to start . . .");
            _ = Console.ReadLine();

            // call game method
            Game();

            while (loop == true)
            {
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine($"\nSince running this program, we've played a total of {totalrounds} rounds.\n");
                System.Threading.Thread.Sleep(500);
                Console.WriteLine($"Over which you have won {totalwins} times and lost {totallosses} times.\n");
                System.Threading.Thread.Sleep(500);
                Console.WriteLine($"You have also managed to tie {totalties} times.");

                System.Threading.Thread.Sleep(1000);

                Console.WriteLine("Would you like to play again? Y/N");
                string input = Console.ReadLine();
                if (input.ToLower() == "y")
                {
                    Game();
                }
                else
                {
                    Console.WriteLine("Thank you for playing! This program will now exit.");
                    break;
                }
            }
            // after game, ask if they want to play again, else quit.
        }

        static int NumRounds()
        {
            while (true)
            {
                Console.WriteLine("How many rounds would you like to play? Enter a number between 1 to 10");
                string input = Console.ReadLine();
                if (Int32.TryParse(input, out int result))
                {
                    if (result > 0 && result < 11)
                    {
                        return result;
                    }
                }
                else
                {
                    Console.WriteLine("Input is not valid. This program will now exit.");
                    System.Threading.Thread.Sleep(2000);
                    Environment.Exit(0);
                }
            }
        }

        static void Game()
        {
            wins = 0;
            losses = 0;
            ties = 0;
            // determine number of rounds
            Console.Clear();
            roundnum = NumRounds();


            System.Threading.Thread.Sleep(1000);
            if (roundnum == 1)
            {
                Console.WriteLine($"We will be playing {roundnum} round.");
            }
            else
            {
                Console.WriteLine($"We will be playing {roundnum} rounds.");
            }

            System.Threading.Thread.Sleep(2000);

            for (int i = 0; i < roundnum; i++)
            {
                // ask user for choice
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Make your throw! Type \'Rock\', \'Paper\', or \'Scissors\'.");

                    string input = Console.ReadLine().ToLower();
                    if (input == "rock" || input.ToLower() == "paper" || input.ToLower() == "scissors")
                    {
                        playerthrow = input;
                        break;
                    }
                    else if (input.ToLower() == "gun")
                    {
                        Console.WriteLine("Hey that's cheating! Try again.");
                    }
                    else
                    {
                        Console.WriteLine("Input is not valid. Try again.");
                    }
                }

                // computer randomly makes choice
                compguess = random.Next(3);
                switch (compguess)
                {
                    case 0:
                        compthrow = "rock";
                        Console.WriteLine("I throw \'Rock\'");
                        break;
                    case 1:
                        compthrow = "paper";
                        Console.WriteLine("I throw \'Paper\'");
                        break;
                    case 2:
                        compthrow = "scissors";
                        Console.WriteLine("I throw \'Scissors\'");
                        break;
                }

                System.Threading.Thread.Sleep(1000);

                Console.WriteLine($"\nSo you threw {playerthrow} and I threw {compthrow} . . .\n");

                System.Threading.Thread.Sleep(1000);
                // compare the two values using... something?
                bool x = true;
                switch (x)
                {
                    case true when playerthrow == compthrow:
                        Console.WriteLine("It's a tie!");
                        ties++;
                        break;
                    case true when playerthrow == "rock" && compthrow == "scissors":
                    case true when playerthrow == "paper" && compthrow == "rock":
                    case true when playerthrow == "scissors" && compthrow == "paper":
                        Console.WriteLine("Wow, you win!");
                        wins++;
                        break;
                    case true when playerthrow == "rock" && compthrow == "paper":
                    case true when playerthrow == "paper" && compthrow == "scissors":
                    case true when playerthrow == "scissors" && compthrow == "rock":
                        Console.WriteLine("It look's like I have won!");
                        losses++;
                        break;
                }


                System.Threading.Thread.Sleep(2000);
                // track rounds played and WLT. print out results
                if (i == 0)
                {
                    Console.WriteLine($"\nSo far . . . we have played {i + 1} round");
                }
                else
                {
                    Console.WriteLine($"\nSo far . . . we have played {i + 1} rounds");
                }
                System.Threading.Thread.Sleep(1000);
                Console.Write($"You have won {wins} times.");
                System.Threading.Thread.Sleep(500);
                Console.Write($" You have lost {losses} times.");
                System.Threading.Thread.Sleep(500);
                Console.Write($" We have tied {ties} times.");
                System.Threading.Thread.Sleep(2000);

                if ((i + 1) < roundnum)
                {
                    Console.WriteLine("\n\nLet's throw again!");
                    System.Threading.Thread.Sleep(2000);
                }
            }

            // after all rounds complete, declare winner
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("Looks like we have completed all rounds.\n");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine($"You have won {wins}, I won {losses} times, afterwhich we tied {ties} times.\n");
            System.Threading.Thread.Sleep(1000);
            if (wins > losses)
            {
                Console.WriteLine("You are the RPS Champion!");
            }
            else if (wins < losses)
            {
                Console.WriteLine("I have bested you! I WIN!");
            }
            else if (wins == losses)
            {
                Console.WriteLine("Amazing, after all of that we still are tied!");
            }

            totalwins += wins;
            totallosses += losses;
            totalties += ties;
            totalrounds += roundnum;
        }
    }
}
