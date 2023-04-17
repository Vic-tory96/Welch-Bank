using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Welch_Bank
{
    public class Utility
    {
       public static void CenterText(string text)
        {
            int screenWidth = Console.WindowWidth;
            int textWidth = text.Length;
            int left = (screenWidth / 2) - (textWidth / 2);
            Console.SetCursorPosition(left, Console.CursorTop);
            Console.WriteLine(text);
        }
        public static int GetValidInputInt(string inputMessage)
        {
            int number;
            while (true)
            {
                Console.Write(inputMessage);
                if (int.TryParse(Console.ReadLine(), out number))
                {
                    break;

                }
                Console.WriteLine("InvalidCastException input. Please enter a valid number");

            }
            return number;

        }

        public static decimal GetValidInput(string inputMessage)
        {
            decimal number;
            while (true)
            {
                Console.Write(inputMessage);
                if(decimal.TryParse(Console.ReadLine(), out number))
                {
                    break;
                    
                }
                Console.WriteLine("InvalidCastException input. Please enter a valid number");

            }
            return number;

        }
        public static int ValidInput(string inputMessage ,int maxAmount )
        {
            int number;
            while (true)
            {

                Console.Write(inputMessage);
               
                if (int.TryParse(Console.ReadLine(), out number))
                {
                        if(number > 0  && number < maxAmount+1)
                         {
                            break;
                         }
                        else
                        {
                            Console.WriteLine("invalid operational index, please enter a valid number");
                        }
                }
                else
                {
                    Console.WriteLine("InvalidCastException input. Please enter a valid number");
                }



            }
            return number;
        }
        

    }
}
