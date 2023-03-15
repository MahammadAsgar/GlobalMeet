using AutoMapper;
using GlobalMeet.Business.Dtos.Main.Get;
using GlobalMeet.Business.Dtos.Main.Post;
using GlobalMeet.Business.Dtos.User.Post;
using GlobalMeet.DataAccess.Entities.Main;
using GlobalMeet.DataAccess.Entities.User;


namespace GlobalMeet.Business.Mappings
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            #region User
            CreateMap<AppUser, RegisterUserDto>().ReverseMap();
            #endregion

            #region Main
            CreateMap<About, AddAboutDto>().ReverseMap();
            CreateMap<About, GetAboutDto>().ReverseMap();
            CreateMap<AboutFile, GetAboutFileDto>().ReverseMap();

            CreateMap<Blog, GetBlogDto>().ReverseMap();
            CreateMap<Blog, AddBlogDto>().ReverseMap();
            CreateMap<BlogFile, GetBlogFileDto>().ReverseMap();

            CreateMap<MeetDate, AddMeetDateDto>().ReverseMap();
            CreateMap<MeetDate, GetMeetDateDto>().ReverseMap();

            CreateMap<Status, AddStatusDto>().ReverseMap();
            CreateMap<Status, GetStatusDto>().ReverseMap();

            CreateMap<Category, AddCategoryDto>().ReverseMap();
            CreateMap<Category, GetCategoryDto>().ReverseMap();

            CreateMap<Order, AddOrderDto>().ReverseMap();
            CreateMap<Order, GetOrderDto>().ReverseMap();

            CreateMap<Company, AddCompanyDto>().ReverseMap();
            CreateMap<Company, GetCompanyDto>().ReverseMap();
            CreateMap<Company, GetCompanyNameDto>().ReverseMap();

            CreateMap<CompanyCategory, AddCompanyCategoryDto>().ReverseMap();
            CreateMap<CompanyCategory, GetCompanyCategoryDto>().ReverseMap();

            CreateMap<MeetType, AddMeetTypeDto>().ReverseMap();
            CreateMap<MeetType, GetMeetTypeDto>().ReverseMap();
            #endregion
        }
    }
}
