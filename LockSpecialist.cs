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
      bank.VaultScore = bank.VaultScore - SkillLevel;

      Console.WriteLine($"{Name} is cracking the vault. Decreased security {SkillLevel} points.");

      if (bank.VaultScore <= 0)
      {
        Console.WriteLine($"{Name} has unlocked the vault!");
      }
    }
    public string Specialty()
    {
      return $"{Name} is a lock smith with {SkillLevel} skill level and takes a {PercentageCut}% cut.";
    }
  }
}