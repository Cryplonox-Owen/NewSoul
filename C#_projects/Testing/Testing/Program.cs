namespace Consolea


{

    internal class Program
    {


        static void Main()
        {
            string[] names = { "man, woman, they, them" };
            int[] ages = { 1231, 20043, 30, 2600 };
            GreetAndCount(names, ages);


        }
        static void GreetAndCount(string[] names, int[] array)
        {

            int oddCount = 0;
            int evenCount = 0;

            for (int i = 0; i < names.Length; i++)
            {
                string type = (array[i] % 2 == 0) ? "EVEN" : "ODD";
                if (type == "EVEN")
                    evenCount++;
                else
                    oddCount++;
                Console.WriteLine($"HELLO {names[i]}! You are {array[i]} years old - {type} ages");
            }
            Console.WriteLine();
            Console.WriteLine($"Total Even ages; {evenCount}");
            Console.WriteLine($"Total Odd ages; {oddCount}");

        }
    }
}

