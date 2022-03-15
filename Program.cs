using System;
using System.Collections.Generic;

namespace HeistPart2
{
  class Program
  {
    static void Main(string[] args)
    {
      List<IRobber> rolodex = new List<IRobber>
      {
          new Hacker
          {
              Name = "Hunter",
              SkillLevel = 45,
              PercentageCut = 10
          },

          new Muscle
          {
              Name = "Bryce",
              SkillLevel = 45,
              PercentageCut = 30
          },

          new LockSpecialist
          {
              Name = "Matthew",
              SkillLevel = 45,
              PercentageCut = 40
          },

          new Muscle
          {
              Name = "Sharif",
              SkillLevel = 45,
              PercentageCut = 15
          },

          new Hacker
          {
              Name = "Fred",
              SkillLevel = 45,
              PercentageCut = 5
          },

          new Muscle
          {
              Name = "Sara",
              SkillLevel = 45,
              PercentageCut = 25
          },

          new LockSpecialist
          {
              Name = "Sora",
              SkillLevel = 45,
              PercentageCut = 20
          },

          new LockSpecialist
          {
              Name = "Jury",
              SkillLevel = 45,
              PercentageCut = 20
          }
      };
      do
      {
        Console.WriteLine($"There are {rolodex.Count} Operatives currently available.");
        Console.WriteLine("");

        Console.Write("Please enter a new Operative: ");
        var newOperativeName = Console.ReadLine();
        if (String.IsNullOrWhiteSpace(newOperativeName))
        {
          break;
        }

        Console.WriteLine("Please select Operatives Skill:");
        Console.WriteLine("");
        Console.WriteLine("1. Hacker (Disables Alarms)");
        Console.WriteLine("2. Muscle (Incapacitates Guards)");
        Console.WriteLine("3. Lock Specialist (Cracks Vault)");
        Console.WriteLine("");
        var newOperativeSkill = Console.ReadLine();
        Console.WriteLine("");

        Console.Write("Please enter Operative's Skill Level(1-100): ");
        var newOperativeSkillLevel = Console.ReadLine();
        Console.WriteLine("");

        Console.Write("Please enter Operative's Percentage Cut(1-100): ");
        var newOperativePercentageCut = Console.ReadLine();

        switch (newOperativeSkill)
        {
          case "1":
            rolodex.Add
            (
              new Hacker
              {
                Name = newOperativeName,
                SkillLevel = int.Parse(newOperativeSkillLevel),
                PercentageCut = int.Parse(newOperativePercentageCut)
              });
            break;
          case "2":
            rolodex.Add
            (
              new Muscle
              {
                Name = newOperativeName,
                SkillLevel = int.Parse(newOperativeSkillLevel),
                PercentageCut = int.Parse(newOperativePercentageCut)
              });
            break;
          case "3":
            rolodex.Add
            (
              new LockSpecialist
              {
                Name = newOperativeName,
                SkillLevel = int.Parse(newOperativeSkillLevel),
                PercentageCut = int.Parse(newOperativePercentageCut)
              });
            break;
        }
      } while (true);

      Bank firstBankOfNss = new Bank
      {
        CashOnHand = new Random().Next(50000, 1000001),

        AlarmScore = new Random().Next(0, 101),

        VaultScore = new Random().Next(0, 101),

        SecurityGuardScore = new Random().Next(0, 101)

      };

      Console.WriteLine("");
      Console.WriteLine("---------------------------------------------");

      if (firstBankOfNss.AlarmScore > firstBankOfNss.VaultScore && firstBankOfNss.AlarmScore > firstBankOfNss.SecurityGuardScore)
      {
        Console.WriteLine("Most Secure: Alarm");
      }
      else if (firstBankOfNss.VaultScore > firstBankOfNss.AlarmScore && firstBankOfNss.VaultScore > firstBankOfNss.SecurityGuardScore)
      {
        Console.WriteLine("Most Secure: Vault");
      }
      else if (firstBankOfNss.SecurityGuardScore > firstBankOfNss.AlarmScore && firstBankOfNss.SecurityGuardScore > firstBankOfNss.VaultScore)
      {
        Console.WriteLine("Most Secure: Gaurds");
      }

      Console.WriteLine("");

      if (firstBankOfNss.AlarmScore < firstBankOfNss.VaultScore && firstBankOfNss.AlarmScore < firstBankOfNss.SecurityGuardScore)
      {
        Console.WriteLine("Least Secure: Alarm");
      }
      else if (firstBankOfNss.VaultScore < firstBankOfNss.AlarmScore && firstBankOfNss.VaultScore < firstBankOfNss.SecurityGuardScore)
      {
        Console.WriteLine("Least Secure: Vault");
      }
      else if (firstBankOfNss.SecurityGuardScore < firstBankOfNss.AlarmScore && firstBankOfNss.SecurityGuardScore < firstBankOfNss.VaultScore)
      {
        Console.WriteLine("Least Secure: Gaurds");
      }

    }
  }
}



