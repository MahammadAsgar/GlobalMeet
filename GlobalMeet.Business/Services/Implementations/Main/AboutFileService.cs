using AutoMapper;
using GlobalMeet.Business.Dtos.Main.Post;
using GlobalMeet.Business.Results;
using GlobalMeet.Business.Services.Abstractions.Main;
using GlobalMeet.Business.Services.Abstractions.Storage.Local;
using GlobalMeet.DataAccess.Entities.Main;
using GlobalMeet.DataAccess.UnitOfWorks;

namespace GlobalMeet.Business.Services.Implementations.Main
{
    public class AboutFileService : IAboutFileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileStorage _fileStorage;
        private readonly IMapper _mapper;

        public AboutFileService(IUnitOfWork unitOfWork, IFileStorage fileStorage, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _fileStorage = fileStorage;
            _mapper = mapper;
        }
        public async Task<ServiceResult> AddRangeAsync(AddAboutDto aboutDto, int aboutId)
        {

            List<(string fileName, string pathOrContainerName)> result = await _fileStorage.UploadAsync("photo-about", aboutDto.Files);
            var about = _unitOfWork.Repository<About>().Get(x => x.Id == aboutId);
            _unitOfWork.Repository<AboutFile>().AddRange(result.Select(x => new AboutFile
            {
                FileName = x.fileName,
                Path = x.pathOrContainerName,
                About = about
            }));

            _unitOfWork.Commit();
            return new ServiceResult(true);
        }

        public Task<ServiceResult> UpdateRangeAsync(AddAboutDto about, int aboutId)
        {
            throw new NotImplementedException();
        }
    }
}
