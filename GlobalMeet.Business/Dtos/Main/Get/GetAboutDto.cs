﻿namespace GlobalMeet.Business.Dtos.Main.Get
{
    public class GetAboutDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<GetAboutFileDto> AboutFiles { get; set; }
    }
}
