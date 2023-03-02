using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalMeet.Business.Dtos.Main.Post
{
    public class AddAboutDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFileCollection? Files { get; set; }
    }
}
