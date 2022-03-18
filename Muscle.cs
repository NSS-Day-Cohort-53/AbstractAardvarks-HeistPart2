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
      bank.SecurityGuardScore = bank.SecurityGuardScore - SkillLevel;

      Console.WriteLine($"{Name} is beating the security guard. Decreased security {SkillLevel} points.");

      if (bank.SecurityGuardScore <= 0)
      {
        Console.WriteLine($"{Name} has incapacitated the security guard!");
      }
    }
    public string Specialty()
    {
      return $"{Name} is a tough guy with {SkillLevel} skill level and takes a {PercentageCut}% cut.";
    }
  }
}