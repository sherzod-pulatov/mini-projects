using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Student> students = new List<Student>();

        while (true)
        {
            Console.Clear();
            Student.Print(students);

            Console.WriteLine("Choose an option: ");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Sort Students by average grade");
            Console.WriteLine("3. Exit");

            string choice = Console.ReadLine()!;
            Console.Clear();

            switch (choice)
            {
                case "1":
                    Student.AddStudent(students);
                    break;
                case "2":
                    Student.Print(students.OrderByDescending(s => s.AvgGrade()).ToList());
                    Console.ReadKey();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Choose 1, 2 or 3 !!!");
                    Console.ReadKey();
                    break;
            }
        }
    }
}

class Student
{
    private string Name { get; set; }
    public List<double> Grades { get; set; }

    public Student(string name)
    {
        Name = name;
        Grades = new List<double>();
    }

    public static void AddStudent(List<Student> students)
    {
        Console.WriteLine("Enter student's name: ");
        students.Add(new Student(Console.ReadLine()));
        Console.WriteLine("Enter grades (separated by space): ");
        students[^1].Grades = Console.ReadLine()!.Split(' ').Select(double.Parse).ToList();
    }

    public double AvgGrade()
    {
        return Grades.Average();
    }

    public static void Print(List<Student> students)
    {
        foreach (var student in students)
        {
            Console.WriteLine(student);
        }
        Console.WriteLine();
    }

    public override string ToString()
    {
        return $"{Name} (Avg: {AvgGrade():F2})";
    }
}