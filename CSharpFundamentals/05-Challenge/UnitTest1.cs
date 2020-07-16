using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _05_Challenge
{
    [TestClass]
    public class UnitTest1
    {
        public enum MenuItem {GrilledCheese, FriedOnions, FriedPotatoes};
        [TestMethod]
        public void TestMethod1()
        {
            string title = "Cheezers";
            double rating = 5.0d;
            bool isOpen = false;
            DateTime openTime = DateTime.Now;
            Int32 customers = 1000000;

            MenuItem order = MenuItem.GrilledCheese;

            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"Rating: {rating}");
            Console.WriteLine($"Open: {isOpen}");
            Console.WriteLine($"Open Time: {openTime}");
            Console.WriteLine($"# of Customers: {customers}");
            Console.WriteLine($"Your Order: {order}");

            string color = "gold";

            string welcomeMessage = "Your shipment of a t-shirt is on its way. Color is: {0}";

            Console.WriteLine(welcomeMessage, color);


            string cheese = "string cheese";
            string pasta = "mac and cheese";
            string beans = "kidney beans";

            string randomSentence = $"I mixed my {cheese} with my {pasta} and somehow ended up with {beans}!";
            Console.WriteLine(randomSentence);


            string word = "Hello";

            Console.WriteLine(word + " world, and " + word + " class. Welcome to Gold Badge.");
            Console.WriteLine("{0} world, and {0} class. Welcome to Gold Badge.", word);
            Console.WriteLine($"{word} world, and {word} class. Welcome to Gold Badge.");

            char[] favLetters = {'u', 'r', 'a', 'q', 't'};
            Console.WriteLine(favLetters[2]);

            List<string> favFruits = new List<string>() { "Apple", "Avocado?", "Grapefruit", "Mango", "Orange", "Tomato" };


            int a = 42;
            int b = 5;

            int first = a * b;
            int second = a + b;
            int third = a / b;
            int bonus1 = (2 * a) + b;
            int bonus2 = a + (2 * b);

            int day = 23;

            if (day > 13 || day < 21)
            {
                Console.WriteLine("Mid month madness");
            } else if (day > 21)
            {
                Console.WriteLine("End month euphoria");
            } else if (day < 13)
            {
                Console.WriteLine("Beginning month blues");
            } else if (day < 13 && day > 21)
            {
                Console.WriteLine("You must be in the twilight zone.");
            }

            if (day.GetType() == typeof(int))
            {
                Console.WriteLine("We're on track.");
            }

            int sleepHours = 3;

            if (sleepHours < 8)
            {
                Console.WriteLine("You must be tired!");
            } else if (sleepHours > 20)
            {
                Console.WriteLine("We need to check your pulse.");
            }

            bool isCarOn = true;
            bool carHasGas = false;

            if(isCarOn)
            {
                if(carHasGas)
                {
                    Console.WriteLine("Let's-a go!");
                } else
                {
                    Console.WriteLine("Need fuel!");
                }
            } else
            {
                Console.WriteLine("Turn that puppy on.");
            }

            string hogwartsHouse = "I don't know Harry Potter lore.";
            switch (hogwartsHouse) {
                case "House1":
                    Console.WriteLine("You are in house 1");
                    break;
                case "House2":
                    Console.WriteLine("What are the house names again?");
                    break;
                case "I don't know Harry Potter lore.":
                    Console.WriteLine("That's okay.");
                    break;
                default:
                    break;
            }

            int volumeLevel = 6;
            volumeLevel = volumeLevel > 10 ? 10 : volumeLevel < 3 ? 3 : volumeLevel;

            bool canSee = false;
            bool light = canSee ? false : true;

            bool done = false;
            int i = 0;
            while (!done)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine(i);
                }

                i++;

                done = i > 50;
            }

            for (i=1; i<=50; i++)
            {
                if (i % 5 == 0)
                {
                    Console.WriteLine(i);
                }
            }
            
            float[] acceptableNumbers = { 5f, 42f, 3f, 3f, 3f, 3f, 3f, 3.14159f };
            foreach (float number in acceptableNumbers)
            {
                Console.WriteLine(number);
            }

            i = 0;
            do
            {
                Console.WriteLine(i);
                i++;
            } while (i < 1);
            Console.WriteLine("Loop has finished.");

            i = 0;
            do
            {
                Console.WriteLine(i);
                i++;
            } while (i < 10);

            PrintEachLetter("AESTHeTIC");
            double.Parse("1");


        }

        public void PrintEachLetter(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                Console.WriteLine(input[i]);
            }
        }

        public void WelcomeGreeting(string name)
        {
            Console.WriteLine($"Hello and welcome, {name}.");
        }

        public int multiplyNumbers(int a, int b)
        {
            return a * b;
        }

        public float multiplyNumbers(float a, float b, float c)
        {
            return a * b * c;
        }

        public void BirthdayWishes(DateTime birthdate)
        {
            int timebetween = DateTime.Now.Year - birthdate.Year;
            Console.WriteLine($"User is {timebetween} years old.");
        }

        public double Divide(int a, int b) { 
            return double.Parse((a / b).ToString()); 
        }

        public void FizzBuzz(int number) { 
            for (int i = 1; i <= number; i++) 
            { 
                if (i % 5 == 0 && i % 3 == 0) 
                {
                    Console.WriteLine("FizzBuzz");
                } else if (i % 5 == 0)
                {
                    Console.WriteLine("Fizz");
                } else if (i % 3 == 0)
                {
                    Console.WriteLine("Buzz");
                } else
                {
                    Console.WriteLine(i);
                }
            } 
        }
    }
}
