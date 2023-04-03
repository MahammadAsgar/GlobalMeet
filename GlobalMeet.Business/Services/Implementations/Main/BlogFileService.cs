using AutoMapper;
using GlobalMeet.Business.Dtos.Main.Post;
using GlobalMeet.Business.Results;
using GlobalMeet.Business.Services.Abstractions.Main;
using GlobalMeet.Business.Services.Abstractions.Storage.Local;
using GlobalMeet.DataAccess.Entities.Main;
using GlobalMeet.DataAccess.UnitOfWorks;

namespace GlobalMeet.Business.Services.Implementations.Main
{
    public class BlogFileService : IBlogFileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileStorage _fileStorage;
        private readonly IMapper _mapper;

        public BlogFileService(IUnitOfWork unitOfWork, IFileStorage fileStorage, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _fileStorage = fileStorage;
            _mapper = mapper;
        }
        public async Task<ServiceResult> AddRangeAsync(AddBlogDto blogDto, int blogId)
        {
            List<(string fileName, string pathOrContainerName)> result = await _fileStorage.UploadAsync("photo-blog", blogDto.Files);
            var blog = _unitOfWork.Repository<Blog>().Get(x => x.Id == blogId);
            _unitOfWork.Repository<BlogFile>().AddRange(result.Select(x => new BlogFile
            {
                FileName = x.fileName,
                Path = x.pathOrContainerName,
                Blog = blog
            }));

            _unitOfWork.Commit();
            return new ServiceResult(true);
        }

        public Task<ServiceResult> UpdateRangeAsync(AddBlogDto blog, int blogId)
        {
            throw new NotImplementedException();
        }
    }
}
