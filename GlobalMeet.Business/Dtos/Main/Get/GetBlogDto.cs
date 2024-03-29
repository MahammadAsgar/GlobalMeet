﻿namespace GlobalMeet.Business.Dtos.Main.Get
{
    public class GetBlogDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<GetBlogFileDto> BlogFiles { get; set; }
    }
}
