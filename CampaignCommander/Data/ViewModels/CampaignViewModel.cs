namespace CampaignCommander.Data.ViewModels
{
    public class CampaignViewModel
    {
        public int CampaignID { get; set; }
        public string CampaignName { get; set; }
        public string? CampaignDescription { get; set; }
        public string GameMasterId { get; set; }
        public int GameId { get; set; }
        public List<string> Invitations { get; set; }
    }
}
