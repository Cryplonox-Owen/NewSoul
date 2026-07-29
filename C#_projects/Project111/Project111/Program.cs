using System;

namespace Owens
{
  class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("[1] BMI scale");
            Console.WriteLine("[2] Leap Year");
            Console.Write("Select option (1–2): ");
            int Option = Convert.ToInt32(Console.ReadLine());
            if (Option == 1)
            {
                Console.WriteLine("Enter your Weight in kilogram");
                int Weight = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter your Height in meters");
                Double Height = Convert.ToDouble(Console.ReadLine());

                Height = Height * Height;
                double BMI = Weight / Height;
                Console.WriteLine(BMI);

                if (BMI < 18.49)
                    Console.WriteLine("You're Underweigh");
                else if (BMI > 18.15)
                    Console.WriteLine("You're Normal");
                else if (BMI > 24.9)
                    Console.WriteLine("You're Normal");
                else if (BMI > 25.0)
                    Console.WriteLine("You're Overweight");
                else if (BMI > 29.9)
                    Console.WriteLine("You're Overweight");
                else if (BMI > 30.0)
                    Console.WriteLine("You're Obese");

            }
            else if (Option == 2)
            {
                Console.WriteLine("Put the year that you want to check");
                int Year = Convert.ToInt32(Console.ReadLine());
                if (DateTime.IsLeapYear(Year))
                    Console.WriteLine("This is a leap Year");
                else 
                    Console.WriteLine("This isnt a Your leap Year");
            }




            }


        }
    }