internal class Program
{
    private static void Main(string[] args)
    {

        bool reRun;
        do
        {
            // Display a welcome message and prompt user for names
            Console.WriteLine("Welcome!!!\n");
            Console.WriteLine("------------------------------------------");
            string studentLname = GetInput("Enter Last Name: ");
            string studentFname = GetInput("Enter First Name: ");
            string studentMname = GetInput("Enter Middle Name: ");
            char middleInitial = studentMname.Length > 0 ? studentMname[0] : '\0'; // Handle empty middle name

            // Define and display the list of courses
            string[] courses = { "BSCS", "BSIT", "BSBA", "BSAIS", "BSA", "BSHM", "BACOMM", "BMMA", "BSTM" };
            DisplayCourses(courses);

            // Prompt user to select a course
            string selectedCourse = SelectCourse(courses);
            Console.WriteLine($"You selected: {selectedCourse}");

            // Display full name
            Console.WriteLine($"Full name is: {studentLname}, {studentFname} {middleInitial}.");

            // Determine if we should rerun
            reRun = ShouldRerun();

        } while (reRun);

        Console.WriteLine("------------------------------------------");
        Console.WriteLine("Program stopped! Thank you!!");
    }

    // Method to get user input
    static string GetInput(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }

    // Method to display list of courses
    static void DisplayCourses(string[] courses)
    {
        Console.WriteLine("Available Courses:");
        for (int i = 0; i < courses.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {courses[i]}");
        }
    }

    // Method to handle course selection
    static string SelectCourse(string[] courses)
    {
        int choice;
        while (true)
        {
            Console.Write("Select a course by entering the corresponding number: ");
            if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= courses.Length)
            {
                return courses[choice - 1];
            }
            else
            {
                Console.WriteLine("Invalid selection. Please enter a number corresponding to one of the courses.");
            }
        }
    }

    // Method to determine if the program should rerun
    static bool ShouldRerun()
    {
        Console.WriteLine("Enter 'y' if you want to run the program again and 'n' to stop:");
        ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
        char ansRerun = char.ToLower(keyInfo.KeyChar);

        switch (ansRerun)
        {
            case 'y':
                return true;
            case 'n':
                return false;
            default:
                Console.WriteLine("\nInvalid input. Please enter 'y' or 'n'.");
                return false; // Optionally stop the loop on invalid input
        }

    }
}