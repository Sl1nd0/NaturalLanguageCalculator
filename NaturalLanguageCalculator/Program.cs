using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalLanguageCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var myText = ""; //"four plus five subtract six add one less nine"   //You may copy and use line for testing that it works
            Console.WriteLine("Enter the calculation: ");
            myText = Console.ReadLine();

            Console.WriteLine(GetNumbers(myText) + "  IS MY ANSWER FROM THE NATURAL LANGUAGE FUNCTION ");
            Console.ReadLine();
        }


        public static int GetNumbers(string myText)
        {
            string[] words = myText.Split(' ');
            int[] numbers = { };
            string ind = "";
            string[] index = { };
            string strToTest = "";
            int answer = 0;

            for (int i = 0; i < words.Length; i++)
            {

                Console.WriteLine(" => Decoding the words to operators and numbers ");
                words[i] = DecodeNumbers(words[i]);
                strToTest += words[i] + " ";

                if (words[i] == "+")
                {
                    Console.WriteLine(" => Setting the index for the + arithmetic operator");
                    ind += i.ToString() + " ";
                }

                if (words[i] == "-")
                {
                    Console.WriteLine(" => Setting the index for the - arithmetic operator ");
                    ind += i.ToString() + " ";
                }
            }

            Console.WriteLine(strToTest);
            if (strToTest.Contains("NoSign") == false)
            {

                ind = ind.Remove(ind.Length - 1, 1);
                //Create Array
                index = ind.Split(' ');

                int sol = 0;
                int myIndex2 = 0;

                sol += Int32.Parse(words[0]);
                Console.WriteLine(sol + " => initial value ");
                for (int i = 0; i < index.Length; i++)
                {
                    myIndex2 = Int32.Parse(index[i]);
                    Console.WriteLine(words[myIndex2 + 1] + " => value after operator ");

                    if (words[myIndex2] == "+")
                    {
                        sol += Int32.Parse(words[myIndex2 + 1]);
                    }

                    if (words[myIndex2] == "-")
                    {
                        sol -= Int32.Parse(words[myIndex2 + 1]);
                    }
                }
                answer = sol;
                Console.WriteLine(sol + " => Answer ");

            }
            else
            {
                answer = 0;
                Console.WriteLine(" => Answer is " + " 0 ");
            }
            return answer;
        }

        public static string DecodeNumbers(string myText)
        {
            var result = "";
            switch (myText.ToLower())
            {
                case "one":
                    result = "1";
                    break;
                case "two":
                    result = "2";
                    break;
                case "three":
                    result = "3";
                    break;
                case "four":
                    result = "4";
                    break;
                case "five":
                    result = "5";
                    break;
                case "six":
                    result = "6";
                    break;
                case "seven":
                    result = "7";
                    break;
                case "eight":
                    result = "8";
                    break;
                case "nine":
                    result = "9";
                    break;
                case "zero":
                    result = "0";
                    break;
                default:
                    result = "NA";
                    break;
            }

            if (result == "NA")
            {
                result = DecodeSign(myText);
            }

            return result;
        }


        public static string DecodeSign(string myText)
        {
            var result = "";
            switch (myText.ToLower())
            {
                case "add":
                    result = "+";
                    break;
                case "plus":
                    result = "+";
                    break;
                case "subtract":
                    result = "-";
                    break;
                case "minus":
                    result = "-";
                    break;
                case "less":
                    result = "-";
                    break;
                default:
                    result = "NoSign";
                    break;
            }
            return result;
        }
    }
}
