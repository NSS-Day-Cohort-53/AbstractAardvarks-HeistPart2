namespace HeistPart2
{
    public class Hacker : Bank, IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public void PerformSkill(Bank bank)
        {

        } 
    }
}