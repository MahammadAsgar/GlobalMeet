using Microsoft.AspNetCore.Http;

namespace GlobalMeet.Business.Dtos.Main.Post
{
    public class AddAboutDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFileCollection? Files { get; set; }
    }
}
