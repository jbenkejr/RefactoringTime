using System;
using System.Collections.Generic;

namespace RefactoringTime_
{
    class Program
    {
        static bool goAgain = true;
        static void Main(string[] args)
        {
            List<string> students = new List<string>() { "Jim", "Sam", "Sandra", "Steve", "Krystal" };
            List<string> favFood = new List<string>() { "Pizza", "Cake", "Salad", "Tacos", "Hot Wings" };
            List<string> homeTown = new List<string>() { "Brownstown", "Coldwater", "San Francisco", "LA", "Detroit" };
            List<string> age = new List<string>() { "31", "26", "28", "29", "32" };
            List<string> pet = new List<string>() { "Dog", "Mini Pig", "Chicken", "Mini Horse", "Iguana" };

            do
            {
                PrintClassMates(students);
                Console.WriteLine();
                int index = ValidateRange($"Welcome to our C# class! Which student would you like to learn more about? (enter a number 1 - {students.Count}): ", students);


                Console.Write($"\nStudent {index + 1} is: {students[index]}. \n");

                do
                {
                    string index1 = GetUserInput($"\nWhat would you like to know about {students[index]}? (enter hometown[home], favorite food[food], age[age] or pet[pet]): ");

                    if (index1 == "home")
                    {
                        Console.Write($"\n{students[index]} is from {homeTown[index]}. Would you like to know more about {students[index]}? (y/n): ");
                    }
                    else if (index1 == "food")
                    {
                        Console.Write($"\n{students[index]}'s favorite food is {favFood[index]}. Would you like to know more about {students[index]}? (y/n): ");
                    }
                    else if (index1 == "age")
                    {
                        Console.Write($"\n{students[index]} is {age[index]} years old. Would you like to know more about {students[index]}? (y/n): ");
                    }
                    else if (index1 == "pet")
                    {
                        Console.Write($"\n{students[index]}'s pet is a {pet[index]}. Would you like to know more about {students[index]}? (y/n): ");
                    }
                    goAgain = GetContinue();

                } while (goAgain);

                Console.Write("\nWould you like to know more about another student? (y/n): ");
                goAgain = GetContinue();
                Console.Clear();


                Console.WriteLine("Would you like to add a student to the class? (y/n)");
                goAgain = GetContinue();
                AddToLIst(students, favFood, homeTown, age, pet);


            } while (goAgain);

        }

        public static bool GetContinue()
        {
            string doOver = Console.ReadLine();
            if (doOver.ToLower().Equals("y"))
            {

                return true;
            }
            else
            {
                return false;
            }
        }

        public static void AddToLIst(List<string> newStudents, List<string> addFood, List<string> addHometown, List<string> addAge, List<string> addPet)
        {

            Console.WriteLine("What is the new students name?");
            string student = Console.ReadLine();
            newStudents.Add(student);
            Console.WriteLine($"What is {student}'s favorite food?");
            string food = Console.ReadLine();
            addFood.Add(food);
            Console.WriteLine($"Where is {student}'s hometown?");
            string hometown = Console.ReadLine();
            addHometown.Add(hometown);
            Console.WriteLine($"How old is {student}?");
            string age = Console.ReadLine();
            addAge.Add(age);
            Console.WriteLine($"What kind of pet does {student} have?");
            string pet = Console.ReadLine();
            addPet.Add(pet);

        }

        public static int ValidateRange(string message, List<string> students)
        {
            try
            {
                int number = ParseString(message);
                number--;
                string student = students[number];
                return number;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                return ValidateRange(message, students);
            }
        }

        public static string GetUserInput(string message)
        {
            Console.Write(message);
            string input = Console.ReadLine();
            return input;
        }

        public static void PrintClassMates(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {list[i]}");
            }
        }

        public static int ParseString(string message)
        {
            try
            {
                string input = GetUserInput(message);
                int number = int.Parse(input);
                return number;
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                return ParseString(message);
            }
            catch
            {
                return ParseString(message);
            }
        }
    }
}

