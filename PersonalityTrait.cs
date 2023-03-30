using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week_1_assesment
{
    class PersonalityTrait
    {
        public static void DeterminePersonality()
        {
            Console.WriteLine("Welcome to the Personality Trait Application");
            Console.Write("What is your age? ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.Write("What is your gender? (M / F)");
            string gender = Console.ReadLine();
            Console.Write("What is your favorite color? ");
            string color = Console.ReadLine();
            Console.Write("What is your favorite animal? ");
            string animal = Console.ReadLine();

            Console.WriteLine("\nPersonality trait:");

            if (age >= 18 && gender == "M" && color == "Blue" && animal == "Dog")
            {
                Console.WriteLine("You are a sweet person.");
            }
            else if (age >= 18 && gender == "F" && color == "Pink" && animal == "Cat")
            {
                Console.WriteLine("You are an independent person.");
            }
            else if (age >= 18 && gender == "M" && color == "Green" && animal == "Bird")
            {
                Console.WriteLine("You are an adventurous person.");
            }
            else if (age >= 18 && gender == "F" && color == "Purple" && animal == "Fish")
            {
                Console.WriteLine("You are a creative person.");
            }
            else
            {
                Console.WriteLine("Sorry, we couldn't determine your personality.");
            }
            Console.ReadLine();
        }

        public static void DetermineAge(int year, int month, int date)
        {
            DateTime birthdate = new DateTime(year, month, date);
            TimeSpan age = DateTime.Today - birthdate;
            float years = (float)(age.TotalDays / 365.25);
            Console.WriteLine("Age: " + years.ToString("0.00"));
        }

        public static void DetermineZodiac()
        {
            Console.Write("Enter your month number eg(Jan = 1, Feb = 2): ");
            int month = Convert.ToInt32(Console.ReadLine());

            string zodiacSign = "";

            switch (month)
            {
                case 1: 
                    zodiacSign = "Capricorn";
                    break;
                case 2: 
                    zodiacSign = "Aquarius";
                    break;
                case 3: 
                    zodiacSign = "Pisces";
                    break;
                case 4: 
                    zodiacSign = "Aries";
                    break;
                case 5: 
                    zodiacSign = "Taurus";
                    break;
                case 6:
                    zodiacSign = "Gemini";
                    break;
                case 7:
                    zodiacSign = "Cancer";
                    break;
                case 8:
                    zodiacSign = "Leo";
                    break;
                case 9:
                    zodiacSign = "Virgo";
                    break;
                case 10:
                    zodiacSign = "Libra";
                    break;
                case 11:
                    zodiacSign = "Scorpio";
                    break;
                case 12: 
                    zodiacSign = "Sagittarius";
                    break;
                default:
                    zodiacSign = "none";
                    break;
            }

            Console.WriteLine(zodiacSign);

        }

        // renamed main to run another program
        static void main(string[] args)
        {
            DeterminePersonality();
            DetermineZodiac();
            DetermineAge(2002,05,06);
        }
    }
}
