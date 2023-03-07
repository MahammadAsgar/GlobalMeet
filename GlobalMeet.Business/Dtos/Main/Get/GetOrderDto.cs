﻿using GlobalMeet.Business.Dtos.User.Get;
using GlobalMeet.DataAccess.Entities.Main;
using GlobalMeet.DataAccess.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalMeet.Business.Dtos.Main.Get
{
    public class GetOrderDto
    {
        public int Id { get; set; }
        //public AppUserDto AppUser { get; set; }
        public GetMeetDateDto MeetDate { get; set; }
    }
}
