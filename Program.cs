using System;

namespace Revisao
{
  class Program
  {
    static void Main(string[] args)
    {
      Student[] studentsGroup = new Student[5];
      string userOption = GetUserOption();
      int studentIdx = 0;

      while (userOption.ToUpper() != "X")
      {
        switch (userOption)
        {
          case "1":
            // TODO: adicionar aluno
            AddStudent(studentsGroup, studentIdx);
            break;

          case "2":
            // TODO: listar alunos
            ShowAllStudents(studentsGroup);
            break;

          case "3":
            // TODO: calcular média geral
            CalculateMedia(studentsGroup);
            break;

          default:
            throw new ArgumentOutOfRangeException("Option not found");
        }

        userOption = GetUserOption();
      }
    }

    private static void CalculateMedia(Student[] studentsGroup)
    {
      decimal totalNote = 0;
      int amountStudents = 0;

      for (int i = 0; i < studentsGroup.Length; i++)
      {
        if (!string.IsNullOrEmpty(studentsGroup[i].Name))
        {
          totalNote += studentsGroup[i].Note;
          amountStudents++;
        }
      }

      decimal media = totalNote / amountStudents;
      Conceito conceits;

      if (media < 2)
      {
        conceits = Conceito.E;
      }
      else if (media < 4)
      {
        conceits = Conceito.D;
      }
      else if (media < 6)
      {
        conceits = Conceito.C;
      }
      else if (media < 8)
      {
        conceits = Conceito.B;
      }
      else
      {
        conceits = Conceito.A;
      }

      Console.WriteLine($"MÉDIA GERAL: {media} - CONCEITO: {conceits}");

    }

    private static void ShowAllStudents(Student[] studentsGroup)
    {
      foreach (Student stud in studentsGroup)
      {
        if (!string.IsNullOrEmpty(stud.Name))
        {
          Console.WriteLine($"ALUNO: {stud.Name} - NOTA: {stud.Note}");
        }
      }
    }

    private static void AddStudent(Student[] studentsGroup, int studentIdx)
    {
      Console.WriteLine("Informe o nome do aluno: ");

      Student student = new Student();
      student.Name = Console.ReadLine();

      Console.WriteLine("Informe a nota do aluno: ");
      if (decimal.TryParse(Console.ReadLine(), out decimal note))
      {
        student.Note = note;
      }
      else
      {
        throw new ArgumentException("Note not is decimal");
      }

      studentsGroup[studentIdx] = student;
      studentIdx++;
    }

    private static string GetUserOption()
    {
      Console.WriteLine();
      Console.WriteLine("Informe a opção desejada:");
      Console.WriteLine("1 - Inserir novo aluno");
      Console.WriteLine("2 - Listar alunos");
      Console.WriteLine("3 - Calcular média geral");
      Console.WriteLine("X - Sair");
      Console.WriteLine();

      return Console.ReadLine();
    }
  }
}
