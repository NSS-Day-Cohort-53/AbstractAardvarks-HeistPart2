using System;

namespace HeistPart2
{
  public class Muscle : IRobber
  {
    public string Name { get; set; }
    public int SkillLevel { get; set; }
    public int PercentageCut { get; set; }
    public void PerformSkill(Bank bank)
    {
      int muscle = bank.SecurityGuardScore - SkillLevel;

      Console.WriteLine($"{Name} is beating the security guard. Decreased security {SkillLevel} points.");

      if (muscle <= 0)
      {
        Console.WriteLine($"{Name} has incapacitated the security guard!");
      }
    }
  }
}