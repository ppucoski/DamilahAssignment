
public class Program
{
    static void Main(string[] args)
    {

        
        List<Subject> subjects = new List<Subject>()
        {
            new MathSubject(),
            new EnglishSubject(),
            new ArtSubject()
        };

        
        while (true)
        {
            Console.WriteLine("\nSchool Subjects Information System");
            Console.WriteLine("1. View all available subjects");
            Console.WriteLine("2. Get details for a specific subject");
            Console.WriteLine("3. Exit");

            int choice = GetIntInput("Enter your choice between  (1-3): ");

            switch (choice)
            {
                case 1:
                    DisplaySubjects(subjects);
                    break;
                case 2:
                    GetSubjectDetails(subjects);
                    break;
                case 3:
                    Console.WriteLine("Exiting application...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private static void DisplaySubjects(List<Subject> subjects)
    {
        Console.WriteLine("\nSubjects:");
        int counter = 1;
        foreach (Subject subject in subjects)
        {
            Console.WriteLine($"{counter}. {subject.Name}");
            counter++;
        }
    }

    private static void GetSubjectDetails(List<Subject> subjects)
    {
        int subjectIndex = GetIntInput("Enter subject number (1-{0}): ", subjects.Count);
        subjectIndex--; 

        if (subjectIndex >= 0 && subjectIndex < subjects.Count)
        {
            subjects[subjectIndex].ShowDetails();
        }
        else
        {
            Console.WriteLine("Invalid subject number.Please try again and enter a valid number.");
        }
    }

    private static int GetIntInput(string message, params object[] args)
    {
        while (true)
        {
            Console.Write(message, args);
            string input = Console.ReadLine();
            if (int.TryParse(input, out int value))
            {
                return value;
            }
            Console.WriteLine("Invalid input. Please try again and enter a valid number.");
        }
    }
}

public abstract class Subject
{
    public abstract string Name { get; }
    public abstract string Description { get; }
    public abstract int NumberOfWeeklyClasses { get; }
    public abstract List<string> LiteratureUsed { get; }

    public virtual void ShowDetails()
    {
        Console.WriteLine($"\nSubject: {Name}");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine($"Number of Weekly Classes: {NumberOfWeeklyClasses}");
        Console.WriteLine("Literature Used:");
        foreach (string book in LiteratureUsed)
        {
            Console.WriteLine($"- {book}");
        }
    }
}

public class MathSubject : Subject
{
    public override string Name => "Math";
    public override string Description => "Learning the fundamentals of the calculus.";
    public override int NumberOfWeeklyClasses => 4;
    public override List<string> LiteratureUsed => new List<string>() { "Math classbook", "Calculus for beginners" };
}

public class EnglishSubject : Subject
{
    public override string Name => "English";
    public override string Description => "Listening, reading, writing.";
    public override int NumberOfWeeklyClasses => 3;
    public override List<string> LiteratureUsed => new List<string>() { "English notebook", "English classbook" };
}

public class ArtSubject : Subject
{
    public override string Name => "Macedonian language";
    public override string Description => "Literature and grammar.";
    public override int NumberOfWeeklyClasses => 5;
    public override List<string> LiteratureUsed => new List<string>() { "Macedonian language schoolbook"};
}