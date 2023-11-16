using System;
using System.Collections.Generic;
using System.Linq;

enum Gender
{
    Male,
    Female
}

enum EducationForm
{
    FullTime,
    PartTime
}

interface IStudent
{
    string FullName { get; set; }
    string Group { get; set; }
    double AverageGrade { get; set; }
    double FamilyIncomePerMember { get; set; }
    int FamilySize { get; set; }
    Gender Gender { get; set; }
    EducationForm EducationForm { get; set; }
}

class Student : IStudent
{
    public string FullName { get; set; }
    public string Group { get; set; }
    public double AverageGrade { get; set; }
    public double FamilyIncomePerMember { get; set; }
    public int FamilySize { get; set; }
    public Gender Gender { get; set; }
    public EducationForm EducationForm { get; set; }

    public override string ToString()
    {
        return $"Name: {FullName}, Group: {Group}, Average Grade: {AverageGrade}, " +
               $"Family Income per Member: {FamilyIncomePerMember}, Family Size: {FamilySize}, " +
               $"Gender: {Gender}, Education Form: {EducationForm}";
    }
}

class Dormitory
{
    private List<IStudent> students = new List<IStudent>();

    public void AddStudent(IStudent student)
    {
        students.Add(student);
    }

    public void DisplayPriorityList()
    {
        var priorityList = students
            .OrderByDescending(s => s.FamilyIncomePerMember)
            .ThenByDescending(s => s.AverageGrade)
            .ToList();

        Console.WriteLine("\nPriority List for Dormitory Placement:");
        foreach (var student in priorityList)
        {
            Console.WriteLine(student);
        }
    }

    public void DisplayColorCodedList()
    {
        var colorCodedList = students
            .OrderByDescending(s => s.AverageGrade)
            .Select((s, index) => new { Student = s, Index = index })
            .ToList();

        Console.WriteLine("\nColor Coded List for Dormitory Placement:");
        foreach (var entry in colorCodedList)
        {
            if (entry.Index < 10)
                Console.ForegroundColor = ConsoleColor.Green;
            else if (entry.Index < 20)
                Console.ForegroundColor = ConsoleColor.Yellow;
            else
                Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(entry.Student);
            Console.ResetColor();
        }
    }

    public void DisplayIncompleteFamilyList()
    {
        var incompleteFamilyList = students
            .Where(s => s.FamilySize < 3)
            .ToList();

        Console.WriteLine("\nStudents with Incomplete Family:");
        foreach (var student in incompleteFamilyList)
        {
            Console.WriteLine(student);
        }
    }

    public void DisplayTopStudentsWithHighestGrades(int count)
    {
        var topStudents = students
            .OrderByDescending(s => s.AverageGrade)
            .Take(count)
            .ToList();

        Console.WriteLine($"\nTop {count} Students with Highest Grades:");
        foreach (var student in topStudents)
        {
            Console.WriteLine(student);
        }
    }

    public void DisplayTopStudentsWithLowestGrades(int count)
    {
        var lowGradesStudents = students
            .OrderBy(s => s.AverageGrade)
            .Take(count)
            .ToList();

        Console.WriteLine($"\nTop {count} Students with Lowest Grades:");
        foreach (var student in lowGradesStudents)
        {
            Console.WriteLine(student);
        }
    }

    public void DisplayStudentsWithLowestIncomeAndIncompleteFamily(int count)
    {
        var lowIncomeIncompleteFamilyList = students
            .Where(s => s.FamilySize < 3)
            .OrderBy(s => s.FamilyIncomePerMember)
            .Take(count)
            .ToList();

        Console.WriteLine($"\nStudents with Lowest Income and Incomplete Family:");
        foreach (var student in lowIncomeIncompleteFamilyList)
        {
            Console.WriteLine(student);
        }
    }
}

class Program
{
    static void Main()
    {
        Dormitory dormitory = new Dormitory();

        // Предварительно заполненные данные для студентов
        IStudent student1 = new Student
        {
            FullName = "John Doe",
            Group = "A123",
            AverageGrade = 4.5,
            FamilyIncomePerMember = 15000,
            FamilySize = 4,
            Gender = Gender.Male,
            EducationForm = EducationForm.FullTime
        };

        IStudent student2 = new Student
        {
            FullName = "Jane Smith",
            Group = "B456",
            AverageGrade = 5.0,
            FamilyIncomePerMember = 20000,
            FamilySize = 3,
            Gender = Gender.Female,
            EducationForm = EducationForm.PartTime
        };

        IStudent student3 = new Student
        {
            FullName = "Bob Johnson",
            Group = "A123",
            AverageGrade = 4.0,
            FamilyIncomePerMember = 12000,
            FamilySize = 2,
            Gender = Gender.Male,
            EducationForm = EducationForm.FullTime
        };

        IStudent student4 = new Student
        {
            FullName = "Alice Brown",
            Group = "C789",
            AverageGrade = 4.8,
            FamilyIncomePerMember = 18000,
            FamilySize = 5,
            Gender = Gender.Female,
            EducationForm = EducationForm.PartTime
        };
        IStudent student5 = new Student
        {
            FullName = "Bekbulet",
            Group = "C7",
            AverageGrade = 4.8,
            FamilyIncomePerMember = 18000,
            FamilySize = 5,
            Gender = Gender.Female,
            EducationForm = EducationForm.PartTime
        };
        IStudent student6 = new Student
        {
            FullName = "Nurkasym",
            Group = "C",
            AverageGrade = 4.8,
            FamilyIncomePerMember = 18000,
            FamilySize = 5,
            Gender = Gender.Female,
            EducationForm = EducationForm.PartTime
        };
        IStudent student7 = new Student
        {
            FullName = "Asanali",
            Group = "C9",
            AverageGrade = 4.8,
            FamilyIncomePerMember = 18000,
            FamilySize = 5,
            Gender = Gender.Female,
            EducationForm = EducationForm.PartTime
        };
        IStudent student8 = new Student
        {
            FullName = "Nurkasym",
            Group = "C89",
            AverageGrade = 4.8,
            FamilyIncomePerMember = 18000,
            FamilySize = 5,
            Gender = Gender.Female,
            EducationForm = EducationForm.PartTime
        };
        IStudent student9 = new Student
        {
            FullName = "Nurik",
            Group = "C9",
            AverageGrade = 4.8,
            FamilyIncomePerMember = 18000,
            FamilySize = 5,
            Gender = Gender.Female,
            EducationForm = EducationForm.PartTime
        };
        IStudent student10 = new Student
        {
            FullName = "Karlybai",
            Group = "C789",
            AverageGrade = 4.8,
            FamilyIncomePerMember = 18000,
            FamilySize = 5,
            Gender = Gender.Female,
            EducationForm = EducationForm.PartTime
        };
        IStudent student11 = new Student
        {
            FullName = "Akim",
            Group = "C789",
            AverageGrade = 4.8,
            FamilyIncomePerMember = 18000,
            FamilySize = 5,
            Gender = Gender.Female,
            EducationForm = EducationForm.PartTime
        };
        IStudent student12 = new Student
        {
            FullName = "Smith",
            Group = "C789",
            AverageGrade = 4.8,
            FamilyIncomePerMember = 18000,
            FamilySize = 5,
            Gender = Gender.Female,
            EducationForm = EducationForm.PartTime
        };
        IStudent student13 = new Student
        {
            FullName = "John",
            Group = "C789",
            AverageGrade = 4.8,
            FamilyIncomePerMember = 18000,
            FamilySize = 5,
            Gender = Gender.Female,
            EducationForm = EducationForm.PartTime
        };
        IStudent student14 = new Student
        {
            FullName = "Brown",
            Group = "C789",
            AverageGrade = 4.8,
            FamilyIncomePerMember = 18000,
            FamilySize = 5,
            Gender = Gender.Female,
            EducationForm = EducationForm.PartTime
        };
        IStudent student15 = new Student
        {
            FullName = "Askar",
            Group = "C789",
            AverageGrade = 4.8,
            FamilyIncomePerMember = 18000,
            FamilySize = 5,
            Gender = Gender.Female,
            EducationForm = EducationForm.PartTime
        };
        IStudent student16 = new Student
        {
            FullName = "Azamat",
            Group = "C789",
            AverageGrade = 4.8,
            FamilyIncomePerMember = 18000,
            FamilySize = 5,
            Gender = Gender.Female,
            EducationForm = EducationForm.PartTime
        };
        IStudent student17 = new Student
        {
            FullName = "Alex",
            Group = "C789",
            AverageGrade = 4.8,
            FamilyIncomePerMember = 18000,
            FamilySize = 5,
            Gender = Gender.Female,
            EducationForm = EducationForm.PartTime
        };
        IStudent student18 = new Student
        {
            FullName = "Mike",
            Group = "C",
            AverageGrade = 4.8,
            FamilyIncomePerMember = 18000,
            FamilySize = 5,
            Gender = Gender.Female,
            EducationForm = EducationForm.PartTime
        };
        IStudent student19 = new Student
        {
            FullName = "Nikole",
            Group = "C789",
            AverageGrade = 4.8,
            FamilyIncomePerMember = 18000,
            FamilySize = 5,
            Gender = Gender.Female,
            EducationForm = EducationForm.PartTime
        };
        IStudent student20 = new Student
        {
            FullName = "Aigerim",
            Group = "C789",
            AverageGrade = 4.8,
            FamilyIncomePerMember = 18000,
            FamilySize = 5,
            Gender = Gender.Female,
            EducationForm = EducationForm.PartTime
        };
        IStudent student21 = new Student
        {
            FullName = "Anastia",
            Group = "C789",
            AverageGrade = 4.8,
            FamilyIncomePerMember = 18000,
            FamilySize = 5,
            Gender = Gender.Female,
            EducationForm = EducationForm.PartTime
        };
        IStudent student22 = new Student
        {
            FullName = "Andrei",
            Group = "C789",
            AverageGrade = 4.8,
            FamilyIncomePerMember = 18000,
            FamilySize = 5,
            Gender = Gender.Female,
            EducationForm = EducationForm.PartTime
        };


        dormitory.AddStudent(student1);
        dormitory.AddStudent(student2);
        dormitory.AddStudent(student3);
        dormitory.AddStudent(student4);
        dormitory.AddStudent(student5);
        dormitory.AddStudent(student6);
        dormitory.AddStudent(student7);
        dormitory.AddStudent(student8);
        dormitory.AddStudent(student9);
        dormitory.AddStudent(student10);
        dormitory.AddStudent(student11);
        dormitory.AddStudent(student12);
        dormitory.AddStudent(student13);
        dormitory.AddStudent(student14);
        dormitory.AddStudent(student15);
        dormitory.AddStudent(student16);
        dormitory.AddStudent(student17);
        dormitory.AddStudent(student18);
        dormitory.AddStudent(student19);
        dormitory.AddStudent(student20);
        dormitory.AddStudent(student21);
        dormitory.AddStudent(student22);

        dormitory.DisplayPriorityList();
        dormitory.DisplayColorCodedList();
        dormitory.DisplayIncompleteFamilyList();
        dormitory.DisplayTopStudentsWithHighestGrades(10);
        dormitory.DisplayTopStudentsWithLowestGrades(10);
        dormitory.DisplayStudentsWithLowestIncomeAndIncompleteFamily(3);
    }
}
