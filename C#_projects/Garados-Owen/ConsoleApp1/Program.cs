namespace OopInterfacesAndSorting
// Owen B. Garados BSCS-2B1
{
    // =========================================================================
    // 1. INTERFACE & ENCAPSULATION (BANK ACCOUNT)
    // =========================================================================


    public interface IAccount
    {
        void Deposit(decimal amount);
        void Withdraw(decimal amount);
        decimal GetBalance();
    }


    public class BankAccount : IAccount
    {
        private decimal _balance;
        private readonly string _accountNumber;
        private readonly string _accountHolder;

        public string AccountNumber => _accountNumber;
        public string AccountHolder => _accountHolder;

        public BankAccount(string accountNumber, string accountHolder, decimal initialBalance = 0m)
        {
            if (string.IsNullOrWhiteSpace(accountNumber))
                throw new ArgumentException("Account number cannot be empty.", nameof(accountNumber));

            if (string.IsNullOrWhiteSpace(accountHolder))
                throw new ArgumentException("Account holder name cannot be empty.", nameof(accountHolder));

            if (initialBalance < 0)
                throw new ArgumentOutOfRangeException(nameof(initialBalance), "Initial balance cannot be negative.");

            _accountNumber = accountNumber;
            _accountHolder = accountHolder;
            _balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Deposit amount must be strictly greater than zero.");
            }

            _balance += amount;
            Console.WriteLine($"  [DEPOSIT] Deposited ${amount:N2}. New Balance: ${_balance:N2}");
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Withdrawal amount must be strictly greater than zero.");
            }

            if (amount > _balance)
            {
                throw new InvalidOperationException($"Insufficient funds. Attempted to withdraw ${amount:N2}, but current balance is ${_balance:N2}.");
            }

            _balance -= amount;
            Console.WriteLine($"  [WITHDRAW] Withdrew ${amount:N2}. Remaining Balance: ${_balance:N2}");
        }

        public decimal GetBalance()
        {
            return _balance;
        }
    }

    // =========================================================================
    // 2. STUDENT DOMAIN MODEL WITH ICOMPARABLE & IMMUTABILITY
    // =========================================================================
    public class Student : IComparable<Student>
    {

        public string Name { get; init; }
        public double Gpa { get; init; }
        public int Age { get; init; }

        public Student(string name, double gpa, int age)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty.", nameof(name));

            if (gpa < 0.0 || gpa > 4.0)
                throw new ArgumentOutOfRangeException(nameof(gpa), "GPA must be between 0.0 and 4.0.");

            if (age < 0)
                throw new ArgumentOutOfRangeException(nameof(age), "Age cannot be negative.");

            Name = name;
            Gpa = gpa;
            Age = age;
        }

        public int CompareTo(Student other)
        {
            if (other == null) return 1;


            int gpaComparison = other.Gpa.CompareTo(this.Gpa);
            if (gpaComparison != 0)
            {
                return gpaComparison;
            }


            return string.Compare(this.Name, other.Name, StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString()
        {
            return $"{Name,-10} | GPA: {Gpa:F2} | Age: {Age}";
        }
    }

    // =========================================================================
    // 3. SEPARATE ICOMPARER IMPLEMENTATIONS
    // =========================================================================


    public class NameComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            if (ReferenceEquals(x, y)) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            return string.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase);
        }
    }


    public class AgeComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            if (ReferenceEquals(x, y)) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            int ageComparison = x.Age.CompareTo(y.Age);
            if (ageComparison != 0)
            {
                return ageComparison;
            }

            return string.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase);
        }
    }

    // =========================================================================
    // MAIN EXECUTABLE PROGRAM
    // =========================================================================

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==================================================================");
            Console.WriteLine("  BANK ACCOUNT DEMONSTRATION (INTERFACE & ENCAPSULATION)");
            Console.WriteLine("==================================================================");


            IAccount account = new BankAccount("ACC-100234", "John Doe", 250.00m);
            Console.WriteLine($"Created Account ACC-100234 for John Doe with initial balance: ${account.GetBalance():N2}\n");

            account.Deposit(150.00m);
            account.Withdraw(75.50m);


            Console.WriteLine("\n  --> Attempting invalid deposit (-$50.00)...");
            try
            {
                account.Deposit(-50.00m);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"  [VALIDATION CAUGHT]: {ex.Message}");
            }


            Console.WriteLine("\n  --> Attempting overdraft withdrawal ($1,000.00)...");
            try
            {
                account.Withdraw(1000.00m);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"  [VALIDATION CAUGHT]: {ex.Message}");
            }

            Console.WriteLine($"\nFinal Balance: ${account.GetBalance():N2}");

            Console.WriteLine("\n==================================================================");
            Console.WriteLine("  STUDENT SORTING DEMONSTRATION (ICOMPARABLE & ICOMPARER)");
            Console.WriteLine("==================================================================");

            List<Student> students = new List<Student>
            {
                new Student("Charlie", 3.8, 22),
                new Student("Alice",   3.9, 20),
                new Student("Bob",     3.8, 21),
                new Student("Diana",   4.0, 19),
                new Student("Eve",     3.5, 23),
                new Student("Aaron",   3.9, 20)
            };

            Console.WriteLine("\nUnsorted Student List:");
            PrintStudentList(students);


            List<Student> naturalSorted = new List<Student>(students);
            naturalSorted.Sort();
            Console.WriteLine("\nSorted by Natural Order (IComparable: GPA Descending, Name Ascending):");
            PrintStudentList(naturalSorted);


            List<Student> nameSorted = new List<Student>(students);
            nameSorted.Sort(new NameComparer());
            Console.WriteLine("\nSorted by Name (NameComparer via List.Sort):");
            PrintStudentList(nameSorted);

            var nameSortedLinq = students.OrderBy(s => s, new NameComparer());
            Console.WriteLine("\nSorted by Name (NameComparer via LINQ OrderBy):");
            PrintStudentList(nameSortedLinq);


            List<Student> ageSorted = new List<Student>(students);
            ageSorted.Sort(new AgeComparer());
            Console.WriteLine("\nSorted by Age (AgeComparer: Age Ascending, Name Ascending via List.Sort):");
            PrintStudentList(ageSorted);

            var ageSortedLinq = students.OrderBy(s => s, new AgeComparer());
            Console.WriteLine("\nSorted by Age (AgeComparer: Age Ascending, Name Ascending via LINQ OrderBy):");
            PrintStudentList(ageSortedLinq);

            Console.WriteLine("\nProgram execution completed successfully.");
        }

        private static void PrintStudentList(IEnumerable<Student> list)
        {
            Console.WriteLine("--------------------------------------------------");
            foreach (var student in list)
            {
                Console.WriteLine($"  {student}");
            }
            Console.WriteLine("--------------------------------------------------");
        }
    }
}
