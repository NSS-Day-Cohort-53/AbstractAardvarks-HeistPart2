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
      int hack = bank.AlarmScore - SkillLevel;

      Console.WriteLine($"{Name} is hacking the alarm system. Decreased security {SkillLevel} points.");

      if (hack <= 0)
      {
        Console.WriteLine($"{Name} has disabled the alarm system!");
      }
    }
  }
}