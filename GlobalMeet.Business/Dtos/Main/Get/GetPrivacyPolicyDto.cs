

namespace GlobalMeet.Business.Dtos.Main.Get
{
    public class GetPrivacyPolicyDto
    {
        public int Id { get; set; }
        public string Terms { get; set; }
        public GetPolicyTypeDto PolicyType { get; set; }
    }
}
