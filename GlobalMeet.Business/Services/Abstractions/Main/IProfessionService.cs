using GlobalMeet.Business.Dtos.Main.Post;
using GlobalMeet.Business.Results;

namespace GlobalMeet.Business.Services.Abstractions.Main
{
    public interface IProfessionService
    {
        Task<ServiceResult> AddProfession(AddProfessionDto professionDto);
        Task<ServiceResult> UpdateProfession(AddProfessionDto professionDto, int id);
        Task<ServiceResult> DeleteProfession(int id);
        Task<ServiceResult> GetProfession(int id);
        Task<ServiceResult> GetProfessions();
    }
}
