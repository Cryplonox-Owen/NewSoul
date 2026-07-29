class Program
{
    static void Main()
    {
        string password;
        bool valid;

        do
        {
            valid = true;
            Console.Write("Enter password: ");
            password = Console.ReadLine();

            if (password.Length < 8)
            {
                Console.WriteLine("Password must be at least 8 characters.");
                valid = false;
            }

            bool hasUpper = false;
            bool hasDigit = false;
            bool hasSpecial = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c))
                    hasUpper = true;

                if (char.IsDigit(c))
                    hasDigit = true;

                if ("!@#$%".Contains(c))
                    hasSpecial = true;
            }

            if (!hasUpper)
            {
                Console.WriteLine("Password must contain at least one uppercase letter.");
                valid = false;
            }

            if (!hasDigit)
            {
                Console.WriteLine("Password must contain at least one digit.");
                valid = false;
            }

            if (!hasSpecial)
            {
                Console.WriteLine("Password must contain at least one special character (!@#$%).");
                valid = false;
            }

        } while (!valid);
    }
}