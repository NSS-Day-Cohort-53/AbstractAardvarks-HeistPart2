using System;

namespace HeistPart2
{
  public class LockSpecialist : IRobber
  {
    public string Name { get; set; }
    public int SkillLevel { get; set; }
    public int PercentageCut { get; set; }
    public void PerformSkill(Bank bank)
    {
      int lockSmith = bank.VaultScore - SkillLevel;

      Console.WriteLine($"{Name} is cracking the vault. Decreased security {SkillLevel} points.");

      if (lockSmith <= 0)
      {
        Console.WriteLine($"{Name} has unlocked the vault!");
      }
    }
  }
}