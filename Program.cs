using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SimpleCalculator

{       
    /// <summary>
    ///  Example of Class using: Intro part of project
    /// </summary>
    
    class Wellcome
    {
        DateTime date = DateTime.Today;
        public string name;
        public int age;

        /// <summary>
        /// Funktion within Class that represents introduction of user and simple count of user's age
        /// </summary>
        public void StartIntro()
        {
            Console.WriteLine("Good day my friend! Let's get to know each other.");

            Console.Write("My name is Mackintosh. What is your name ?: ");
            name = Console.ReadLine();
            Console.Write("\nWow, {0} is my favorite name !", name);

            int yearFromUser;
            Console.Write("\nWhat is ur birth year? : ");
            string userBirthYear = Console.ReadLine();

            //checking for valid enter of the year                 
            while (!int.TryParse(userBirthYear, out yearFromUser))
            {
                Console.WriteLine("You are teasing me!");
                Console.Write("\nCan you write your birth year? ");
                userBirthYear = Console.ReadLine();
            }

            age = date.Year - yearFromUser;
 
                Console.WriteLine("\nDo you know that at age of {0} you can legaly do some calculations!\n Let's try it!",age);

        }

    }// end of Wellcome class


    /// <summary>
    /// Program consits of 3 parts: 
    /// - Introduction with Class implementation;
    /// - SimpleCalculator;
    /// - Array implementation example;
    /// </summary>
    
    class Program
    {
        // using enum type for storing values for possible operations within calculator. 
        public enum Operations {nothing, plus, minus, division, multiplication, exponentation, modulo};

        /// <summary>
        /// Presents 3 parts: Intro, Simple Calculator and Array example
        /// Consist user error-check loop for entered operation
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            /*Class implementation example*/
            Wellcome user = new Wellcome();
            user.StartIntro();

            // Ask user for valid numbers
            double firstNumber = GetNumber("\nPlease, enter your 1st number: ");
            double secondNumber = GetNumber("\nPlease, enter your 2nd number: ");

            //Ask user for valid operation
            
            Operations operation;
            string userInput;

             do
            {
                // Ask user valid operation to use
                Console.WriteLine("Enter the operation + , - , * , / , ^  or % : ");
                userInput = Console.ReadLine();

                // use for the string operation choice
                operation = ConvertUserInputToEnum(userInput);
            } while (operation == Operations.nothing);

            /*Calculator*/
            DoCalculation(firstNumber,secondNumber,operation);

            Console.WriteLine("Result of {0} {1} {2} is : {3}", firstNumber, userInput, secondNumber, DoCalculation(firstNumber, secondNumber, operation));
            
            /*Using array Example*/
            DoMyNumbersArray();

            Console.WriteLine("Boring? Press something to finish it!...");
            Console.ReadKey();
        }// end Main


        /// <summary>
        /// Funktion represents error-checks of user's input
        /// </summary>
        /// <param name="outputText">Text that helps users to understand next step</param>
        /// <returns> Returns number to be used in calculation </returns>
        
        static double GetNumber(string outputText)
        {
            double userNumber;
            Console.Write(outputText);
            string userInput = Console.ReadLine();

            /*do ask for number if convertation is not succeed*/
            while (!double.TryParse(userInput, out userNumber))
            {
                Console.Write(outputText);
                userInput = Console.ReadLine();
            }
         
            return userNumber;
        }//end GetNumber

        /// <summary>
        ///  Funktion to do convertion of user's entered operation for checking purpose
        /// </summary>
        /// <param name="userInput"> Original user's input </param>
        /// <returns> Converted value of user's input </returns>
        
        static Operations ConvertUserInputToEnum(string userInput)
        {
            switch (userInput)
            {
                case "+":
                    return Operations.plus;
                case "-":
                    return Operations.minus;
                case "/":
                    return Operations.division;
                case "*":
                    return Operations.multiplication;
                case "^":
                    return Operations.exponentation;
                case "%":
                    return Operations.modulo;
                default:
                    return Operations.nothing;
            }
        }// end ConvertUserInputtoEnum

        /// <summary>
        /// Simple Calculation funktions
        /// </summary>
        /// <param name="firstNumber"> Users' first number</param>
        /// <param name="secondNumber"> User's second number</param>
        /// <param name="userOperation">Operation to be implemented</param>
        /// <returns>Returns result of calculation</returns>
        
        static double DoCalculation (double firstNumber, double secondNumber, Operations userOperation)
        {
            switch (userOperation)
            {
                case Operations.plus:
                    return firstNumber+secondNumber;
                case Operations.minus:
                    return firstNumber-secondNumber;
                case Operations.division:
                    return firstNumber/secondNumber;
                case Operations.multiplication:
                    return firstNumber*secondNumber;
                case Operations.exponentation:
                    return Math.Pow(firstNumber,secondNumber);
                case Operations.modulo:
                    return firstNumber%secondNumber;
                case Operations.nothing:
                    return double.NaN;
                default:
                    return double.NaN;
            }
        }//end DoCalculation

        
        /// <summary>
        /// Simple example of array implementation
        /// Result is showing the maximum value among the users numbers
        /// </summary>
        static void DoMyNumbersArray()
        {
            double[] mynumbers = new double[6];
            
            Console.Write("\nLet's make an array of 6 numbers, \nI will find element that has the maximum value: ");
            int size = mynumbers.Length;

            //filling our array with user's data her
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("\nPlease, enter any number (integer or float): ");
                double userNumber = 0;

                if (double.TryParse(Console.ReadLine(), out userNumber))
                {
                    mynumbers[i] = userNumber;
                }else
                {
                    i--;
                }

            }

            //searching for maximum value her
            double maxValue = 0;
            maxValue = mynumbers[0];
            for (int i=0; i<mynumbers.Length;i++)
            if (maxValue < mynumbers[i])
            {
                maxValue = mynumbers[i];
            }
            Console.WriteLine("\nThe maximum value of your array is: {0}", maxValue);
        }// end DoMyNumbers

    }//END class Program

}//END
