using System;

namespace HeistPart2
{
  public class Hacker : Bank, IRobber
  {
    public string Name { get; set; }
    public int SkillLevel { get; set; }
    public int PercentageCut { get; set; }
    public void PerformSkill(Bank bank)
    {
      bank.AlarmScore = bank.AlarmScore - SkillLevel;

      Console.WriteLine($"{Name} is hacking the alarm system. Decreased security {SkillLevel} points.");

      if (bank.AlarmScore <= 0)
      {
        Console.WriteLine($"{Name} has disabled the alarm system!");
      }
    }
    public string Specialty()
    {
      return $"{Name} is a hacker with {SkillLevel} skill level and takes a {PercentageCut}% cut.";
    }
  }
}