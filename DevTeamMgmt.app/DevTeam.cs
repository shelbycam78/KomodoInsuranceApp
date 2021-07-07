namespace DevTeamMgmt.app
{
    internal class DevTeam
    {
        public DevTeam(string userInputTeamName, System.Collections.Generic.List<DevTeamMgmtApp.poco.DeveloperPoco> devsToBeAddedToTeam)
        {
        }

        public string TeamId { get; internal set; }
        public string Developers { get; internal set; }
        public string TeamName { get; internal set; }
    }
}