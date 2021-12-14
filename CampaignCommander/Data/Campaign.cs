namespace CampaignCommander.Data
{
    public class Campaign
    {
        public int CampaignID { get; set; }
        public string CampaignName { get; set; }
        public string? CampaignDescription { get; set; }
        public string GameMasterId { get; set; }
        public ApplicationUser GameMaster { get; set; }
        public ICollection<ApplicationUser> Players { get; set; }
        public ICollection<Invitation> Invitations { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
