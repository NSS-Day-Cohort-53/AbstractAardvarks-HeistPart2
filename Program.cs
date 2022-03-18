using System;
using System.Collections.Generic;
using System.Linq;

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
              SkillLevel = 40,
              PercentageCut = 10
          },

          new LockSpecialist
          {
              Name = "Matthew",
              SkillLevel = 50,
              PercentageCut = 10
          },

          new Muscle
          {
              Name = "Sharif",
              SkillLevel = 45,
              PercentageCut = 10
          },

          new Hacker
          {
              Name = "Fred",
              SkillLevel = 60,
              PercentageCut = 10
          },

          new Muscle
          {
              Name = "Sara",
              SkillLevel = 45,
              PercentageCut = 10
          },

          new LockSpecialist
          {
              Name = "Sora",
              SkillLevel = 62,
              PercentageCut = 10
          },

          new LockSpecialist
          {
              Name = "Jury",
              SkillLevel = 45,
              PercentageCut = 10
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

        AlarmScore = new Random().Next(101),

        VaultScore = new Random().Next(101),

        SecurityGuardScore = new Random().Next(101)

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
        Console.WriteLine("Most Secure: Guards");
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
        Console.WriteLine("Least Secure: Guards");
      }

      List<IRobber> crew = new List<IRobber>();

      Console.WriteLine("");
      Console.WriteLine("Please Create a Crew.");
      Console.WriteLine("");

      while (true)
      {
        int currentPercentage = crew.Sum(c => c.PercentageCut);
        Console.WriteLine($"Current Cut Total: {currentPercentage}");
        Console.WriteLine("");

        for (int i = 0; i < rolodex.Count; i++)
        {
          if (rolodex[i].PercentageCut + currentPercentage <= 100)
          {
            Console.WriteLine($"{i + 1}. {rolodex[i].Specialty()}");
          }
        }

        Console.WriteLine("");
        string opChoice = Console.ReadLine();
        Console.WriteLine("");

        if (String.IsNullOrWhiteSpace(opChoice))
        {
          break;
        }

        if (int.TryParse(opChoice, out int choice))
        {
          if (choice > 0 && choice <= rolodex.Count)
          {
            IRobber crewMember = rolodex[choice - 1];
            crew.Add(crewMember);
            rolodex.Remove(crewMember);
          }
          else
          {
            Console.WriteLine("Select a valid Option.");
          }
        }
        else
        {
          Console.WriteLine("Select a valid Option.");
        }
      }

      crew.ForEach(c => c.PerformSkill(firstBankOfNss));

      if (firstBankOfNss.IsSecure)
      {
        Console.WriteLine("");
        Console.WriteLine("Heist Failed.");
      }
      else
      {
        Console.WriteLine("");
        Console.WriteLine("Heist Successful.");
        Console.WriteLine("");
        decimal userCut = firstBankOfNss.CashOnHand;

        crew.ForEach(c =>
        {
          decimal memberCut = ((c.PercentageCut * .01M) * firstBankOfNss.CashOnHand);
          userCut -= memberCut;
          Console.WriteLine($"{c.Name} took home ${memberCut}");
        });

        Console.WriteLine($"Your cut is ${userCut}.");
      }

    }
  }
}



