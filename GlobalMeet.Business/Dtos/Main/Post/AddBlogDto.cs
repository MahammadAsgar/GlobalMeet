using GlobalMeet.DataAccess.Entities.Main;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalMeet.Business.Dtos.Main.Post
{
    public class AddBlogDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFileCollection? Files { get; set; }
    }
}
