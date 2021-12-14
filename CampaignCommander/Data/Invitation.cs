using Microsoft.EntityFrameworkCore;

namespace CampaignCommander.Data
{
    [Owned]
    public class Invitation
    {
        public int InvitationID { get; set; }
        public string Email { get; set; }
        public DateTime InvitationDate { get; set; }
    }
}
