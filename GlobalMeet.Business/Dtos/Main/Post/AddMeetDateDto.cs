using GlobalMeet.DataAccess.Entities.Main;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalMeet.Business.Dtos.Main.Post
{
    public class AddMeetDateDto
    {
        public int Id { get; set; }
        public DateTime Day { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDateDate { get; set; }
        public int StatusId { get; set; }
    }
}
